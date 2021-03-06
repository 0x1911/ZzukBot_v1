using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZzukBot.AntiWarden;
using ZzukBot.Constants;
using ZzukBot.Engines;
using ZzukBot.Engines.CustomClass;
using ZzukBot.Engines.ProfileCreation;
using ZzukBot.Helpers;
using ZzukBot.Hooks;
using ZzukBot.Mem;
using ZzukBot.Properties;
using ZzukBot.Settings;

namespace ZzukBot.Forms
{
    internal partial class GraphicalMainForm : Form
    {
        #region Constructor

        /// <summary>
        ///     Main constructor
        /// </summary>
        internal GraphicalMainForm()
        {
            InitializeComponent();
            Text += " - " + Assembly.GetExecutingAssembly().GetName().Version;
            PrepareForLaunch();

            //set string bytes[] former set received from the auth server
            try
            {
                var loadDetour =
            "MOV [0xCE8978], EAX[|]" +
            "pushfd[|]" +
            "pushad[|]" +
            "push EAX[|]" +
            "call [|addr|][|]" +
            "popad[|]" +
            "popfd[|]" +
            "jmp 0x006CA233[|]";
                var memcpyDetour =
            "PUSH ESI[|]" +
            "PUSH EDI[|]" +
            "CLD[|]" +
            "MOV EDX, [ESP+20][|]" +
            "MOV ESI, [ESP+16][|]" +
            "MOV EAX, [ESP+12][|]" +
            "MOV ECX, EDX[|]" +
            "MOV EDI, EAX[|]" +
            "pushfd[|]" +
            "pushad[|]" +
            "PUSH EDI[|]" +
            "PUSH ECX[|]" +
            "PUSH ESI[|]" +
            "call [|addr|][|]" +
            "popad[|]" +
            "popfd[|]" +
            "POP EDI[|]" +
            "POP ESI[|]" +
            "jmp [|addr|][|]";
                var eventSignal0 =
            "PUSH ESI[|]" +
            "CALL 0x007040D0[|]" +
            "pushfd[|]" +
            "pushad[|]" +
            "mov EDI, [EDI][|]" +
            "push EDI[|]" +
            "call [|addr|][|]" +
            "popad[|]" +
            "popfd[|]" +
            "jmp [|addr|][|]";
                var eventSignal =
            "PUSH EBX[|]" +
            "PUSH ESI[|]" +
            "CALL 0x007040D0[|]" +
            "pushfd[|]" +
            "pushad[|]" +
            "mov EAX, EBP[|]" +
            "ADD EAX, 0x10[|]" +
            "push eax[|]" +
            "mov EAX, [EBP + 0xC][|]" +
            "push EAX[|]" +
            "mov EDI, [EDI][|]" +
            "push EDI[|]" +
            "call [|addr|][|]" +
            "popad[|]" +
            "popfd[|]" +
            "jmp [|addr|][|]";

                Constants.Warden.WardenLoadDetour = loadDetour.Split(new string[] { "[|]" }, StringSplitOptions.RemoveEmptyEntries);
                Constants.Warden.WardenMemCpyDetour = memcpyDetour.Split(new string[] { "[|]" }, StringSplitOptions.RemoveEmptyEntries);
                Constants.Warden.EventSignal0 = eventSignal0.Split(new string[] { "[|]" }, StringSplitOptions.RemoveEmptyEntries);
                Constants.Warden.EventSignal = eventSignal.Split(new string[] { "[|]" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
            }
            
                Task.Run(() => EndLaunchPrepare());                   
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        #endregion

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        private void PrepareForLaunch()
        {
           // GuiCore.MainForm = this;
            Enabled = false;
            SettingsManager.LoadXmlSettings();
            LoginBlock.Enable();
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        internal void EndLaunchPrepare()
        {            
            Memory.Init();
            SettingsManager.LoadSettings();
            CCManager.LoadCCs();

            #region set wow & bot window location and size
            Helpers.WindowInteraction.SetWowWindow();
            Helpers.WindowInteraction.SetBotWindow();
            #endregion

            #region setup world render minimize if enabled in settings
            if(Settings.Settings.MinimizeWorldRender)
            {
                Hack renderWorld = HookWardenMemScan.GetHack("RenderWorlObjectsPatch");

                //setup render world patch if unknown to us
                if (renderWorld == null)
                {
                    var RenderWorldPatch = new Hack(ZzukBot.Constants.Offsets.Hacks.RenderDisable, new byte[] { 0x00 }, "RenderWorlObjectsPatch");
                    HookWardenMemScan.AddHack(RenderWorldPatch);

                    renderWorld = HookWardenMemScan.GetHack("RenderWorlObjectsPatch");
                }

                if (!renderWorld.IsActivated && Settings.Settings.MinimizeWorldRender)
                {
                    renderWorld.Apply();
                }
            }            
            #endregion
            IrcMonitor.Instance.MessageReceived += ChannelMessageRecieved;
            GuiCore.SettingsForm.SetupIrc();
            Enums.DynamicFlags.AdjustToRealm();
            GuiCore.MainForm.Enabled = true;
            ChatHook.OnNewChatMessage += updateChat;
            LoginBlock.Disable();
        }
        
        private void PlayBeep()
        {
            WinImports.PlaySound(Resources.beep, IntPtr.Zero,
                WinImports.SoundFlags.SND_ASYNC | WinImports.SoundFlags.SND_MEMORY);
        }


        internal void updateNotification(string parMessage)
        {
            Invoke(new MethodInvoker(delegate
            {
                var count = dgNotifications.Rows.Count;
                dgNotifications.Rows.Add(DateTime.Now.ToString("HH:mm"), parMessage);
                dgNotifications.Rows[count].Cells[1].ToolTipText = parMessage;
                IrcMonitor.Instance.SendMessage(parMessage);
                PlayBeep();
            }));
        }

        internal void updateChat(ChatMessage e)
        {
            if(!API.BMain.IsInGame || ObjectManager.Player == null) { return; }


            Invoke(new MethodInvoker(delegate
            {
                if (e.Type == (int) Enums.ChatType.Channel)
                {
                    if (!e.Message.ToLower().Contains(ObjectManager.Player.Name.ToLower()))
                        return;
                }

                if (
                    e.Type == (int)Enums.ChatType.Say && Settings.Settings.BeepOnSay ||
                    e.Type == (int)Enums.ChatType.Whisper && Settings.Settings.BeepOnWhisper ||
                    e.Type == (int)Enums.ChatType.Channel && Settings.Settings.BeepOnName
                    )
                {
                    PlayBeep();
                }

                var count = dgChat.Rows.Count;
                dgChat.Rows.Add(((Enums.ChatType) e.Type).ToString(), DateTime.Now.ToString("HH:mm"), e.Owner, e.Message);
                dgChat.Rows[count].Cells[3].ToolTipText = e.Message;
                dgChat.CurrentCell = dgChat[0, dgChat.Rows.Count - 1];

                IrcMonitor.Instance.SendMessage("[" + e.Owner + "] " + (Enums.ChatType)e.Type + ": " + e.Message);
                //Monitor.SendChannelMessage("[" + e.Owner + "] " + (Enums.ChatType) e.Type + ": " + e.Message);
            }));
        }

        //#region Modify, Save and load settings
        /// <summary>
        ///     Delegate used to update controls on the form
        /// </summary>
        internal void UpdateControl<T>(object Value, T control) where T : Control
        {
            Invoke(new MethodInvoker(delegate
            {
                if (control.GetType() == typeof (TextBox))
                {
                    if (Value.GetType() == typeof (string[]))
                    {
                        (control as TextBox).Text = "";
                        foreach (var x in (string[]) Value)
                        {
                            (control as TextBox).Text
                                += x + Environment.NewLine;
                        }
                    }
                    else if (Value is string)
                    {
                        (control as TextBox).Text = (string) Value;
                    }
                }
                else if (control.GetType() == typeof (NumericUpDown))
                {
                    var val = Convert.ToDecimal(Value);
                    if (val < (control as NumericUpDown).Minimum)
                        // ReSharper disable once RedundantAssignment
                        val = (control as NumericUpDown).Minimum;
                    (control as NumericUpDown).Value = Convert.ToDecimal(Value);
                }
                else if (control.GetType() == typeof (ComboBox))
                {
                    var i = 0;
                    for (; i < (control as ComboBox).Items.Count; i++)
                    {
                        if (
                            (string) (control as ComboBox).Items[i] ==
                            ((Enums.ItemQuality) Value).ToString())
                        {
                            break;
                        }
                    }
                    (control as ComboBox).SelectedIndex = i;
                }
                else if (control.GetType() == typeof (Label))
                {
                    (control as Label).Text = (string) Value;
                }
                else if (control.GetType() == typeof (CheckBox))
                {
                    (control as CheckBox).Checked = (bool) Value;
                }
            }));
        }
                
        private static void ChannelMessageRecieved(object S, IrcMonitor.MessageArgs e)
        {
            var msg = e.Message.Split(' ');
            if (!msg[0].StartsWith("!")) return;

            var command = msg[0];
            var text = "";
            switch (command)
            {
                case "!help":
                    IrcMonitor.Instance.SendMessage("Commands: !help, !say, !whisper, !guild, !group, !quit, !lua");
                    IrcMonitor.Instance.SendMessage("Usage of chat commands: !command recipent message or !command message");
                    IrcMonitor.Instance.SendMessage("Usage of lua command: !lua scriptcode");
                    break;

                case "!say":
                    for (var i = 1; i < msg.Length; i++)
                        text += msg[i] + " ";
                    Lua.RunInMainthread("SendChatMessage('" + text + "' ,'say' , nil, nil);");
                    break;

                case "!guild":
                    for (var i = 1; i < msg.Length; i++)
                        text += msg[i] + " ";
                    Lua.RunInMainthread("SendChatMessage('" + text + "' ,'guild' , nil, nil);");
                    break;

                case "!party":
                    for (var i = 1; i < msg.Length; i++)
                        text += msg[i] + " ";
                    Lua.RunInMainthread("SendChatMessage('" + text + "' ,'party' , nil, nil);");
                    break;

                case "!whisper":
                    var reciever = msg[1];
                    for (var i = 2; i < msg.Length; i++)
                        text += msg[i] + " ";
                    Lua.RunInMainthread("SendChatMessage('" + text + "' ,'whisper' , nil, '" + reciever + "');");
                    break;

                case "!lua":
                    for (var i = 1; i < msg.Length; i++)
                        text += msg[i] + " ";
                    Lua.RunInMainthread(text);
                    break;

                case "!quit":
                    Environment.Exit(-1);
                    break;
            }
        }
        
        private void bClearChatLog_Click(object sender, EventArgs e)
        {
            dgChat.Rows.Clear();
        }        

        
        #region Top menu tool strip        
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EngineManager.ResumeCurrentEngine();

            if (EngineManager.CurrentEngineType != Engines.Engines.None) return;
                     

            Relog.LoginHandling();

            EngineManager.StartGrinder(GuiCore.MainForm.cbLoadLastProfile.Checked);
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EngineManager.PauseCurrentEngine();
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EngineManager.StopCurrentEngine();
        }   
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GuiCore.SettingsForm == null)
            {
                GuiCore.SettingsForm = new Forms.GraphicalSettingsForm();
            }

            GuiCore.SettingsForm.StartPosition = FormStartPosition.Manual;
            GuiCore.SettingsForm.Location = new Point(GuiCore.MainForm.Location.X, GuiCore.MainForm.Location.Y);
            
            GuiCore.SettingsForm.Show();
            GuiCore.SettingsForm.BringToFront();
        }
        private void dEVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpDevForm = new Forms.GraphicalDEVForm();
            
            tmpDevForm.StartPosition = FormStartPosition.Manual;
            tmpDevForm.Location = new Point(GuiCore.MainForm.Location.X, GuiCore.MainForm.Location.Y);

            tmpDevForm.Show();
        }
        #endregion

        private void GraphicalMainForm_Load(object sender, EventArgs e)
        {
            GuiCore.MainForm.dEVToolStripMenuItem.Visible = false;
            GuiCore.MainForm.dEVToolStripMenuItem.Enabled = false;
#if DEBUG
            GuiCore.MainForm.dEVToolStripMenuItem.Visible = true;
            GuiCore.MainForm.dEVToolStripMenuItem.Enabled = true;
#endif           
        }
    }
}