using System;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Constants;
using System.Windows.Forms;
using System.Collections.Generic;
using ZzukBot.Engines.Grind;

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
            var player = ObjectManager.Player;
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
            if(Grinder.Access.Info.Vendor.TravelingToVendor == false)
            {
                Grinder.Access.Info.Vendor.TravelingToVendor = true;
            }
            else
            {
                Grinder.Access.Info.Vendor.TravelingToVendor = false;
            }
        }
    }
}
