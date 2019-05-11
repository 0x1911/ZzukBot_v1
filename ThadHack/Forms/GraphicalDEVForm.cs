using System;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Constants;
using System.Windows.Forms;
using System.Collections.Generic;
using ZzukBot.Engines.Grind;
using ZzukBot.AntiWarden;
using System.Drawing;

namespace ZzukBot.Forms
{
    public partial class GraphicalDEVForm : Form
    {
        public GraphicalDEVForm()
        {
            InitializeComponent();
        }

        private void btn_Skills_Click(object sender, EventArgs e)
        {
            if (!ObjectManager.IsInGame) { return; }

            var player = ObjectManager.Player;

            if(!ObjectManager.IsInGame) { return; }
            //List<Game.Static.Skills.Skill> Skills = new Game.Static.Skills().GetAllPlayerSkills();
            player.Skills = new Game.Static.Skills().GetAllPlayerSkills();

            foreach (var tmpPlayerSkill in player.Skills)
            {
                Enums.Skills tmpSkill = tmpPlayerSkill.Id;
                Helpers.Logger.Append("My skill in " + tmpSkill.ToString() + " is " + tmpPlayerSkill.CurrentLevel + "/ " + tmpPlayerSkill.MaxLevel);                
            }
        }

        private void btn_travelToVendor_Click(object sender, EventArgs e)
        {
            if (!ObjectManager.IsInGame) { return; }

            if (Grinder.Access.Info.Vendor.TravelingToVendor == false)
            {
                Grinder.Access.Info.Vendor.TravelingToVendor = true;
            }
            else
            {
                Grinder.Access.Info.Vendor.TravelingToVendor = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ObjectManager.IsInGame) { return; }

            List<Objects.WoWItem> tmpAllItemsList = ObjectManager.Items;

            Helpers.Logger.Append("item name | id");
            foreach (Objects.WoWItem tmpItem in tmpAllItemsList)
            {
                Helpers.Logger.Append(tmpItem.Name + " | " + tmpItem.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relog.EnterWorld();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helpers.Logger.Append("teeeeeeeest neu");
            Helpers.Logger.Append("teeeeeeeest alt");

        }

        private void btn_Talents_Click(object sender, EventArgs e)
        {
            if (!ObjectManager.IsInGame) { return; }

            Game.Static.TalentTree tmpTalentTree = new Game.Static.TalentTree();

            Helpers.Logger.Append("We got " + tmpTalentTree.GetUnspentPointsCount() + " unspent talent points.");

            IList<Game.Static.Classes.Talent> TalentsList = tmpTalentTree.GetTalents();
            foreach (Game.Static.Classes.Talent tmpTalent in TalentsList)
            {
                Helpers.Logger.Append(tmpTalent.Name + " [" + tmpTalent.CurrentRank + "/ " + tmpTalent.MaxRank + "] I: " + tmpTalent.Index);
            }

            /*
            string[] targetTalentTree =
            {
            "05000000000000000000000000000005002520103511051"
            };
            tmpTalentTree.LearnTalents(targetTalentTree); */
        }

        private void btn_Party_Click(object sender, EventArgs e)
        {
            if (!API.BMain.Me.IsInParty)
            {
                Helpers.Logger.Append("We are not in a party..");
                return;
            }

            if (API.BMain.Me.IsPartyLeader)
            {
                Helpers.Logger.Append("I am the great party leader!");
            }

            var tmpPartyMemberList = API.BParty.GetMembers();

            foreach(Objects.WoWUnit tmpMember in tmpPartyMemberList)
            {
                Helpers.Logger.Append(tmpMember.Name + ", " + tmpMember.Level + ", " + tmpMember.HealthPercent + "% HP");
            }
        }

        private void btn_FishingTest_Click(object sender, EventArgs e)
        {
            var tmpInventory = new Game.Static.Inventory();
            Objects.WoWItem tmpMainHandItem = tmpInventory.GetEquippedItem(Enums.EquipSlot.MainHand);
            

            if (tmpMainHandItem == null) { return; }

            Helpers.Logger.Append("Equipped in main hand: " + tmpMainHandItem.Name + ", id: " + tmpMainHandItem.Id);

            foreach(Game.Static.Items.FishingPole tmpFPole in Game.Static.Items.Fishing.FishingPoleList)
            {
                if(tmpFPole.Id == tmpMainHandItem.Id)
                {
                    Helpers.Logger.Append(tmpFPole.Name + " is giving us +" + tmpFPole.SkillEnhancement + " fishing skill");
                    break;
                }
            }

            var player = ObjectManager.Player;
            int currentFishingSkill = 0;
            int maxFishingSkill = 0;
            #region gathering fishing skill info
            //update the skills, just in case
            player.Skills = new Game.Static.Skills().GetAllPlayerSkills();

            foreach (var tmpPlayerSkill in player.Skills)
            {
                if (tmpPlayerSkill.Id == Enums.Skills.FISHING)
                {
                    currentFishingSkill = tmpPlayerSkill.CurrentLevel;
                    maxFishingSkill = tmpPlayerSkill.MaxLevel;
                    break;
                }
            }
            #endregion
            string fishingSpellNameString = "Fishing";
            int fishingRank = ObjectManager.Player.Spells.GetSpellRank(fishingSpellNameString);
            if (fishingRank > 0 && currentFishingSkill > 0)
            {
                Helpers.Logger.Append("We do have the fishing spell and a current skill of " + currentFishingSkill + "/ " + maxFishingSkill);
            }
        }

        private void btnToggleRender_Click(object sender, EventArgs e)
        {
            Hack renderWorld = HookWardenMemScan.GetHack("RenderWorlObjectsPatch");

            //setup render world patch if unknown to us
            if (renderWorld == null)
            {
                var RenderWorldPatch = new Hack(ZzukBot.Constants.Offsets.Hacks.RenderDisable, new byte[] { 0x00 }, "RenderWorlObjectsPatch");
                HookWardenMemScan.AddHack(RenderWorldPatch);

                renderWorld = HookWardenMemScan.GetHack("RenderWorlObjectsPatch");
            }

            #region toggle render world
            if (!renderWorld.IsActivated)
            {
                renderWorld.Apply();
                return;
            }


            renderWorld.Remove();
            #endregion
        }

        private void btn_ResizeWindow_Click(object sender, EventArgs e)
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

                int targetWidth = 407;
                int targetHeight = 316;

                //set wow window to location and resize
                WinImports.SetWindowPos(Mem.WindowProcHook.HWnD, 0, 1, 1, targetWidth, targetHeight, SWP_NOZORDER | SWP_SHOWWINDOW);

                //set bot mainform to a location below
                GuiCore.MainForm.Location = new Point(1, 1+targetHeight);
            }
        }
    }
}
