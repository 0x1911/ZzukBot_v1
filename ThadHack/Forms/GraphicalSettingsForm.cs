using System;
using System.Windows.Forms;
using ZzukBot.Constants;
using ZzukBot.Engines;
using ZzukBot.Engines.CustomClass;
using ZzukBot.Settings;
using ZzukBot.Helpers;
using System.Drawing;

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
            Options.BeepOnName = GuiCore.SettingsForm.cbBeepName.Checked;
            Options.BeepOnSay = GuiCore.SettingsForm.cbBeepSay.Checked;
            Options.BeepOnWhisper = GuiCore.SettingsForm.cbBeepWhisper.Checked;
            Options.NotifyOnRare = GuiCore.SettingsForm.cbNotifyRare.Checked;
            Options.StopOnRare = GuiCore.SettingsForm.cbStopOnRare.Checked;

            Options.PetFood = GuiCore.SettingsForm.tbPetFood.Text;
            Options.AccountName = GuiCore.SettingsForm.tbAccount.Text;
            Options.AccountPassword = GuiCore.SettingsForm.tbPassword.Text;
            Options.CharacterName = GuiCore.SettingsForm.txt_Character.Text;
            Options.RestManaAt = (int)GuiCore.SettingsForm.nudDrinkAt.Value;
            Options.Drink = GuiCore.SettingsForm.tbDrink.Text;
            Options.RestHealthAt = (int)GuiCore.SettingsForm.nudEatAt.Value;
            Options.Food = GuiCore.SettingsForm.tbFood.Text;
            Options.MobSearchRange = (float)GuiCore.SettingsForm.nudMobSearchRange.Value;
            Options.MaxDiffToWp = (float)GuiCore.SettingsForm.nudRoamFromWp.Value;
            Options.CombatDistance = (float)GuiCore.SettingsForm.nudCombatRange.Value;
            Options.MinFreeSlotsBeforeVendor = (int)GuiCore.SettingsForm.nudFreeSlots.Value;
            Options.WaypointModifier = GuiCore.SettingsForm.nudWaypointModifier.Value;
            Options.KeepItemsFromQuality =
                (int)Enum.Parse(typeof(Enums.ItemQuality),
                    (string)GuiCore.SettingsForm.cbKeepQuality.SelectedItem);

            Options.ForceBreakAfter = (int)GuiCore.SettingsForm.nudForceBreakAfter.Value;
            Options.BreakFor = (int)GuiCore.SettingsForm.nudBreakFor.Value;

            Options.ProtectedItems = GuiCore.SettingsForm.tbProtectedItems.Text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);

            Options.IRCBotChannel = GuiCore.SettingsForm.tbIRCBotChannel.Text;
            Options.IRCBotNickname = GuiCore.SettingsForm.tbIRCBotNickname.Text;
            Options.UseIRC = GuiCore.SettingsForm.cbIRCConnect.Checked;

            Options.SkinUnits = GuiCore.SettingsForm.cbSkinUnits.Checked;
            Options.NinjaSkin = GuiCore.SettingsForm.cbNinjaSkin.Checked;
            Options.Herb = GuiCore.SettingsForm.cbHerb.Checked;
            Options.Mine = GuiCore.SettingsForm.cbMine.Checked;
            Options.LootUnits = GuiCore.SettingsForm.cbLootUnits.Checked;

            #region settings - windows tabpage
            //wow window location
            Options.WowWindowX = GuiCore.SettingsForm.txt_WowWindowX.Text;
            Options.WowWindowY = GuiCore.SettingsForm.txt_WowWindowY.Text;

            //wow window size
            Options.WowWindowWidth = GuiCore.SettingsForm.txt_WowWindowWidth.Text;
            Options.WowWindowHeight = GuiCore.SettingsForm.txt_WowWindowHeigth.Text;

            //bot window location
            Options.BotWindowX = GuiCore.SettingsForm.txt_BotWindowX.Text;
            Options.BotWindowY = GuiCore.SettingsForm.txt_BotWindowY.Text;
            #endregion

            OptionManager.SaveSettings();

            SetupIrc();
        }
        public void SetupIrc()
        {
            if (Options.UseIRC)
            {
                IrcMonitor.Instance.Start(Options.IRCBotChannel, Options.IRCBotNickname);
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionManager.LoadSettings();
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

        private void cbIRCConnect_CheckedChanged(object sender, EventArgs e)
        {

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
        
    }
}
