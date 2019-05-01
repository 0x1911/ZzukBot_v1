using System;
using System.Collections.Generic;
using ZzukBot.Mem;

namespace ZzukBot.Game.Static
{
    public class TalentTree
    {
        private readonly Objects.LocalPlayer Me = ObjectManager.Player;

        public TalentTree()
        {
            Me = ObjectManager.Player;
        }

        /// <summary>
        /// Learn new talents according to a given string.
        /// Can be generated from http://rpgworld.altervista.org/classic_vanilla_talent/ for your class
        /// </summary>
        /// <param name="talentStrings"></param>
        public void LearnTalents(string[] talentStrings)
        {
            var unspentPointsCount = this.GetUnspentPointsCount();
            if (unspentPointsCount == 0) { return; }

            var talents = this.GetTalents();
            for (int i = 0; i < talentStrings.Length; i++)
            {
                var talentString = talentStrings[i];
                for (int j = 0; j < talentString.Length; j++)
                {
                    var c = talentString.Substring(j, 1);
                    var number = Convert.ToInt32(c);
                    if (number > talents[j].CurrentRank && number <= talents[j].MaxRank)
                    {
                        this.Me.DoString(string.Format("LearnTalent({0}, {1});", talents[j].Tab, talents[j].Index));
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Return our current unspent Talent points
        /// </summary>
        /// <returns>int</returns>
        public int GetUnspentPointsCount()
        {
            this.Me.DoString("TM_unspentTalentPoints, TM_learnedProfessions = UnitCharacterPoints(\"player\");");

            return Convert.ToInt32(this.Me.GetText("TM_unspentTalentPoints"));             
        }

        /// <summary>
        /// Get our current talent tree
        /// </summary>
        /// <returns></returns>
        public IList<Game.Static.Classes.Talent> GetTalents()
        {
            var talents = new List<Game.Static.Classes.Talent>();
            this.Me.DoString("TM_numberOfTabs = GetNumTalentTabs()");
            int tabCount = Convert.ToInt32(this.Me.GetText("TM_numberOfTabs"));

            for (int i = 1; i <= tabCount; i++)
            {
                this.Me.DoString(string.Format("TM_numberOfTalents = GetNumTalents({0})", i));
                int talentCount = Convert.ToInt32(this.Me.GetText("TM_numberOfTalents"));
                for (int j = 1; j <= talentCount; j++)
                {
                    this.Me.DoString(string.Format("TM_nameTalent, TM_icon, TM_tier, TM_column, TM_currRank, TM_maxRank = GetTalentInfo({0},{1});", i, j));
                    var talent = new Game.Static.Classes.Talent(this.Me.GetText("TM_nameTalent"), Convert.ToInt32(this.Me.GetText("TM_currRank")), Convert.ToInt32(this.Me.GetText("TM_maxRank")), i, j);
                    talents.Add(talent);
                }
            }


            return talents;
        }
    }
}






