using System;
using System.Windows.Forms;
using ZzukBot.Constants;
using ZzukBot.Engines;
using ZzukBot.Engines.CustomClass;
using ZzukBot.Settings;
using ZzukBot.Helpers;

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
    }
}
