using System;
using System.Windows.Forms;
using ZzukBot.Constants;
using ZzukBot.Engines;
using ZzukBot.Engines.CustomClass;
using ZzukBot.Settings;
using ZzukBot.Helpers;
using System.Drawing;
using System.Reflection;

namespace ZzukBot.Forms
{
    public partial class GraphicalSettingsForm : Form
    {
        public GraphicalSettingsForm()
        {
            InitializeComponent();
        }

        private void GraphicalSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //hide instead of dispose
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Settings.BeepOnName = GuiCore.SettingsForm.cbBeepName.Checked;
            Settings.Settings.BeepOnSay = GuiCore.SettingsForm.cbBeepSay.Checked;
            Settings.Settings.BeepOnWhisper = GuiCore.SettingsForm.cbBeepWhisper.Checked;
            Settings.Settings.NotifyOnRare = GuiCore.SettingsForm.cbNotifyRare.Checked;
            Settings.Settings.StopOnRare = GuiCore.SettingsForm.cbStopOnRare.Checked;

            Settings.Settings.PetFood = GuiCore.SettingsForm.tbPetFood.Text;
            Settings.Settings.AccountName = GuiCore.SettingsForm.tbAccount.Text;
            Settings.Settings.AccountPassword = GuiCore.SettingsForm.tbPassword.Text;
            Settings.Settings.CharacterName = GuiCore.SettingsForm.txt_Character.Text;
            Settings.Settings.RestManaAt = (int)GuiCore.SettingsForm.nudDrinkAt.Value;
            Settings.Settings.Drink = GuiCore.SettingsForm.tbDrink.Text;
            Settings.Settings.RestHealthAt = (int)GuiCore.SettingsForm.nudEatAt.Value;
            Settings.Settings.Food = GuiCore.SettingsForm.tbFood.Text;
            Settings.Settings.MobSearchRange = (float)GuiCore.SettingsForm.nudMobSearchRange.Value;
            Settings.Settings.MaxDiffToWp = (float)GuiCore.SettingsForm.nudRoamFromWp.Value;
            Settings.Settings.CombatDistance = (float)GuiCore.SettingsForm.nudCombatRange.Value;
            Settings.Settings.MinFreeSlotsBeforeVendor = (int)GuiCore.SettingsForm.nudFreeSlots.Value;
            Settings.Settings.WaypointModifier = GuiCore.SettingsForm.nudWaypointModifier.Value;
            Settings.Settings.KeepItemsFromQuality =
                (int)Enum.Parse(typeof(Enums.ItemQuality),
                    (string)GuiCore.SettingsForm.cbKeepQuality.SelectedItem);

            Settings.Settings.ForceBreakAfter = (int)GuiCore.SettingsForm.nudForceBreakAfter.Value;
            Settings.Settings.BreakFor = (int)GuiCore.SettingsForm.nudBreakFor.Value;

            Settings.Settings.ProtectedItems = GuiCore.SettingsForm.tbProtectedItems.Text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);

            Settings.Settings.IRCBotChannel = GuiCore.SettingsForm.tbIRCBotChannel.Text;
            Settings.Settings.IRCBotNickname = GuiCore.SettingsForm.tbIRCBotNickname.Text;
            Settings.Settings.UseIRC = GuiCore.SettingsForm.cbIRCConnect.Checked;

            Settings.Settings.SkinUnits = GuiCore.SettingsForm.cbSkinUnits.Checked;
            Settings.Settings.NinjaSkin = GuiCore.SettingsForm.cbNinjaSkin.Checked;
            Settings.Settings.Herb = GuiCore.SettingsForm.cbHerb.Checked;
            Settings.Settings.Mine = GuiCore.SettingsForm.cbMine.Checked;
            Settings.Settings.LootUnits = GuiCore.SettingsForm.cbLootUnits.Checked;
            Settings.Settings.DoRandomJumps = GuiCore.SettingsForm.cbRandomJumps.Checked;
            Settings.Settings.MinimizeWorldRender = GuiCore.SettingsForm.cbWorldRender.Checked;

            #region settings - windows tabpage
            //wow window location
            Settings.Settings.WowWindowX = GuiCore.SettingsForm.txt_WowWindowX.Text;
            Settings.Settings.WowWindowY = GuiCore.SettingsForm.txt_WowWindowY.Text;

            //wow window size
            Settings.Settings.WowWindowWidth = GuiCore.SettingsForm.txt_WowWindowWidth.Text;
            Settings.Settings.WowWindowHeight = GuiCore.SettingsForm.txt_WowWindowHeigth.Text;

            //bot window location
            Settings.Settings.BotWindowX = GuiCore.SettingsForm.txt_BotWindowX.Text;
            Settings.Settings.BotWindowY = GuiCore.SettingsForm.txt_BotWindowY.Text;
            #endregion

            SettingsManager.SaveSettings();

            SetupIrc();
        }
        public void SetupIrc()
        {
            if (Settings.Settings.UseIRC)
            {
                IrcMonitor.Instance.Start(Settings.Settings.IRCBotChannel, Settings.Settings.IRCBotNickname);
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsManager.LoadSettings();
            if (EngineManager.CurrentEngineType == Engines.Engines.None)
                CCManager.LoadCCs();
        }

        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpNewProfileForm = new Forms.GraphicalProfileCreationForm();

            if (EngineManager.CurrentEngineType != Engines.Engines.None) { EngineManager.StopCurrentEngine(); }


            tmpNewProfileForm.StartPosition = FormStartPosition.Manual;
            tmpNewProfileForm.Location = new Point(GuiCore.MainForm.Location.X, GuiCore.MainForm.Location.Y);

            EngineManager.StartProfileCreation(tmpNewProfileForm);
            tmpNewProfileForm.Show();
        }
        
        private void btn_ConnectIrc_Click(object sender, EventArgs e)
        {
            if (!GuiCore.SettingsForm.cbIRCConnect.Checked)
            {
                var botName = GuiCore.SettingsForm.tbIRCBotNickname.Text;
                var botChannel = GuiCore.SettingsForm.tbIRCBotChannel.Text;
                if (string.IsNullOrWhiteSpace(botName))
                {
                    MessageBox.Show("Bot Nickname cant be empty");
                    return;
                }
                if (!botChannel.StartsWith("#") || string.IsNullOrWhiteSpace(botChannel))
                {
                    MessageBox.Show("Channel must start with a #");
                    return;
                }
                GuiCore.SettingsForm.cbIRCConnect.Checked = true;
            }
            else
                GuiCore.SettingsForm.cbIRCConnect.Checked = false;
        }

        private void btn_GetWowWindow_Click(object sender, EventArgs e)
        {
            const short SWP_NOMOVE = 0X2;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            if (Mem.WindowProcHook.HWnD != IntPtr.Zero && Mem.WindowProcHook.HWnD != null)
            {
                Size cSize = new Size();
                var tmpRect = new WinImports.RECT();
                WinImports.GetWindowRect(Mem.WindowProcHook.HWnD, out tmpRect);

                cSize.Width = tmpRect.Right - tmpRect.Left;
                cSize.Height = tmpRect.Bottom - tmpRect.Top;

                //window location
                GuiCore.SettingsForm.txt_WowWindowX.Text = tmpRect.Left.ToString();
                GuiCore.SettingsForm.txt_WowWindowY.Text = tmpRect.Top.ToString();

                //window size
                GuiCore.SettingsForm.txt_WowWindowWidth.Text = cSize.Width.ToString();
                GuiCore.SettingsForm.txt_WowWindowHeigth.Text = cSize.Height.ToString();
            }
        }

        private void btn_GetBotWindow_Click(object sender, EventArgs e)
        {
            GuiCore.SettingsForm.txt_BotWindowX.Text = GuiCore.MainForm.Location.X.ToString();
            GuiCore.SettingsForm.txt_BotWindowY.Text = GuiCore.MainForm.Location.Y.ToString();
        }

        private void btn_ChooseWowExe_Click(object sender, EventArgs e)
        {
            var loc = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "executable (*.exe)|*.exe",
                FilterIndex = 1,
                Title = "Locate the WoW 1.12.1 *.exe file you want the bot to use"
            };
            if (loc.ShowDialog() == DialogResult.OK)
            {
                if (loc.FileName == Assembly.GetExecutingAssembly().Location)
                {
                    MessageBox.Show(
                        "We need the WoW *.exe not the bot *.exe file..");
                }
                else
                {
                    GuiCore.SettingsForm.txt_WowPath.Text = loc.FileName;
                    Settings.Settings.WowExePath = loc.FileName;
                }
            }
        }

        private void btn_chooseProfilesDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    GuiCore.SettingsForm.txt_ProfilesDirectory.Text = fbd.SelectedPath;
                    Settings.Settings.ProfilesDirectory = fbd.SelectedPath;
                }
            }
        }

        private void btn_ChooseCustomClassesDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    GuiCore.SettingsForm.txt_CCDirectory.Text = fbd.SelectedPath;
                    Settings.Settings.CCDirectory = fbd.SelectedPath;
                }
            }
        }
    }
}
