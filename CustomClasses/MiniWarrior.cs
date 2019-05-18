using ZzukBot.API;
using ZzukBot.Engines.CustomClass;

namespace something
{
	// based on Schouten_Warrior 'rework'
    public class MiniWarrior : CustomClass
    {
        /* http://rpgworld.altervista.org/classic_vanilla_talent/warrior.php */
        public static readonly string[] TalentStrings =
        {
            "0000000000000000000505003502501005100000000000000000"
        };
        public override byte DesignedForClass
        {
            get { return (int)ZzukBot.API.Enums.ClassType.Warrior; }
        }
        public override string CustomClassName
        {
            get
            {
                return "MiniWarrior";
            }
        }

			
		
        public override void PreFight()
        {
            if (this.Player.GetSpellRank("Charge") != 0)
            {
                if (this.Player.CanUse("Charge"))
                {
                    this.Player.Cast("Charge");
                    return;
                }
            }
            if (this.Player.GetSpellRank("Intercept") != 0)
            {
                if (this.Player.CanUse("Intercept"))
                {
                    this.Player.Cast("Intercept");
                    return;
                }
            }
            this.Player.Attack();
            this.SetCombatDistance(3);
            return;
        }

        public override void Rest()
        {
            if (this.Player.HealthPercent < 60)
                this.Player.Eat();
            Player.DoString("DoEmote('Sit')");
        }

        public override void Fight()
        {
            this.Player.Attack();
            #region handle multi-mob
            if (this.Attackers.Count >= 2)
            {                
                //how about a little retaliation?
                if (this.Player.GetSpellRank("Retaliation") != 0)
                {
                    if (this.Player.CanUse("Retaliation"))
                    {
                        this.Player.Cast("Retaliation");
                        return;
                    }
                }
                //cleave them down if there is lots of rage
                if (this.Player.GetSpellRank("Cleave") != 0)
                {
                    if (this.Player.CanUse("Cleave"))
                    {
                        this.Player.Cast("Cleave");
                        return;
                    }
                }
            }
            #endregion

            //Health Potion
            if (this.Player.HealthPercent <= 22 && this.Player.ItemCount("Superior Healing Potion") != 0)
             {
                this.Player.UseItem("Superior Healing Potion");
             }
          
             if (this.Player.HealthPercent <= 22 && this.Player.ItemCount("Greater Healing Potion") != 0)
             {
                this.Player.UseItem("Greater Healing Potion");
             }

             if (this.Player.HealthPercent <= 22 && this.Player.ItemCount("Healing Potion") != 0)
             {
                this.Player.UseItem("Healing Potion");
             }

             if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Lesser Healing Potion") != 0)
             {
                this.Player.UseItem("Lesser Healing Potion");
             }
          
             if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Minor Healing Potion") != 0)
             {
                this.Player.UseItem("Minor Healing Potion");
             }   			
			
            if (this.Player.GetSpellRank("Battle Shout") != 0 && !this.Player.GotBuff("Battle Shout"))
            {
                if (this.Player.CanUse("Battle Shout"))
                {
                    this.Player.Cast("Battle Shout");
                    return;
                }
            }
            
            if (this.Player.GetSpellRank("Rend") != 0 && !this.Target.GotDebuff("Rend") && this.Target.HealthPercent > 50)
            {
                if (this.Player.CanUse("Rend"))
                {
                    this.Player.Cast("Rend");
                    return;
                }
            }
            string HamstringSpell = "Hamstring";
            if (this.Player.GetSpellRank(HamstringSpell) != 0 && !this.Target.GotDebuff(HamstringSpell) && this.Target.HealthPercent < 50)
            {
                if (this.Player.CanUse(HamstringSpell))
                {
                    this.Player.Cast(HamstringSpell);
                    return;
                }
            }

            if (this.Player.GetSpellRank("Execute") != 0 && this.Target.HealthPercent <= 20)
            {
                if (this.Player.CanUse("Execute"))
                {
                    this.Player.Cast("Execute");
                    return;
                }
            }

            if(this.Player.GetSpellRank("Overpower") != 0)
            {
                if(this.Player.CanUse("Overpower"))
                {
                    this.Player.Cast("Overpower");
                    return;
                }
            }

            if (this.Player.GetSpellRank("Thunder Clap") != 0 && !this.Target.GotDebuff("Thunder Clap"))
            {
                if (this.Player.CanUse("Thunder Clap"))
                {
                    this.Player.Cast("Thunder Clap");
                    return;
                }
            }
            if (this.Player.GetSpellRank("Demoralizing Shout") != 0 && !this.Target.GotDebuff("Demoralizing Shout"))
            {
                if (this.Player.CanUse("Demoralizing Shout"))
                {
                    this.Player.Cast("Demoralizing Shout");
                    return;
                }
            }
            //interrupt casting
            if (this.Player.GetSpellRank("Pummel") != 0 && this.Target.IsCasting != "" || this.Target.IsChanneling != "")
            {
                if (this.Player.CanUse("Pummel"))
                {
                    this.Player.Cast("Pummel");
                }
            }
            if (this.Player.GetSpellRank("Berserker Rage") != 0)
            {
                if (this.Player.CanUse("Berserker Rage"))
                {
                    this.Player.Cast("Berserker Rage");
                }
            }

            if (this.Player.GetSpellRank("Bloodthirst") != 0)
            {
                if (this.Player.CanUse("Bloodthirst"))
                {
                    this.Player.Cast("Bloodthirst");
                    return;
                }
            }
            
            if (this.Player.GetSpellRank("Mortal Strike") != 0)
            {
                if (this.Player.CanUse("Mortal Strike"))
                {
                    this.Player.Cast("Mortal Strike");
                    return;
                }
            }

            if (this.Player.GetSpellRank("Heroic Strike") != 0)
            {
                if (this.Player.CanUse("Heroic Strike"))
                {
                    this.Player.Cast("Heroic Strike");
                    return;
                }
            }

            if (this.Player.GetSpellRank("Bloodrage") != 0)
            {
                if (this.Player.CanUse("Bloodrage"))
                {
                    this.Player.Cast("Bloodrage");
                    return;
                }
            }
            this.Player.Attack();
            return;
        }

        public override bool Buff()
        {
            //Talent point spending
            if (BMain.Me.TalentPointsAvailable() > 0)
            {
                BMain.Me.TalentsLearnByString(TalentStrings);
            }
            return true;
        }
    }
}
