using System;
using System.Linq;
using ZzukBot.Engines.CustomClass;
using ZzukBot.API;

/*
CHANGELOG:
---
7. of May ^by 0x1911
- kicked Mind Flay usage.. too much mana wasted for less effect
1. of May ^ by 0x1911: 
- Removed Rest() Logic -> bot logic can handle the drink selecting by itself
* Talentpoint spending will be handled by the internal bot logic now, just the talentstring needs to be given
---
MiniPriest is a modded version of ShadyPriest
Original CC by EmuPriest, list of changes and additions:
-added Mind Blast support [on pull]
-multiple add handling behaviour (in line with this goes the usage of devouring plague, if you are undead)
-drink selection
-Shadowform
-Mind Flaying up to b% target health. Depending on your wand (!) this value needs to be adjusted. With a bad wand im running with 55%.

CREDITS
to krycess for his CasinoFury2, I have taken his approach to handling adds and selecting drinks and implemented those in here.
to uh.. Emu? for providing the original EmuPriest.
to Fedelis for his FedLock - it seems his approach of GCD checking via CanUse has fixed my wanding issue.


05000000000000000000000000000005002520103511051
*/

namespace MiniPriest
{
    internal static class Constants
    {
        public static readonly Version Release = new Version(0, 1);

        /* http://rpgworld.altervista.org/classic_vanilla_talent/priest.php */
        public static readonly string[] TalentStrings =
        {
            "05000000000000000000000000000005002520103511051"
        };

    }

    public class MiniPriest : CustomClass
    {
        public MiniPriest()
        {

        }

        public override byte DesignedForClass
        {
            get
            {
                return PlayerClass.Priest;
            }
        }

        public override string CustomClassName
        {
            get
            {
                return "MiniPriest 1.3.0";
            }
        }

        /*
		Change this value to determine the point at which you want to stop using mind flay and start wanding.
        for example: 65 for mind flay until the enemy has 65% health, wanding from then on.
        I feel like this is highly subjective and depends on how much time you want to spend drinking / how good your wand damage is,
        so play around with it to figure something out that suits your character.
        Change useShadowForm to true in case you have specced into it.
        Change useSilence to true in case you have specced into it / want to use it.
        useWand should never have to be changed, this was kind of experimental. The no-wand logic will still trigger with this set to true.
        Do NOT set debug to true unless you want your ingame chat to be spammed with status messages. I use this to figure out confilcting conditions.
        (Like why on earth the character starts trying to spam wand before the DoTs are even finished applying)
        */
        bool isPlayerSub14 = false;
        int healthP = 65;
        bool useSilence = false;
        bool useShadowForm = true;
        bool debug = false;
        bool useVEmb = false;
        bool useWand = true;
        bool useTouchOfWeakness = false;
        bool useMultiDot = true;


        public void pullPriority()
        {
            if (this.Player.GetSpellRank("Mind Blast") != 0)
            {
                if (this.Player.CanUse("Mind Blast"))
                {
                    this.Player.Cast("Mind Blast");
                }
            }
            else if (this.Player.GetSpellRank("Shadow Word: Pain") != 0)
            {
                if (!Target.GotDebuff("Shadow Word: Pain"))
                {
                    this.Player.Cast("Shadow Word: Pain");
                }
            }
            else
            {	// to ensure this works from level 1.
                this.Player.Cast("Smite");
            }
        }


        public bool MultiDotting()
        {
            if (this.Attackers.Count >= 2 && this.Player.ManaPercent >= 40 && useMultiDot == true)
            {
                var properTarget = this.Attackers.FirstOrDefault(t => t.HealthPercent <= 99);
                int newAddH = this.Attackers.Max(Mob => Mob.HealthPercent);
                var newAdd = this.Attackers.SingleOrDefault(Mob => Mob.HealthPercent == newAddH);
                if (newAdd != null && newAdd.Guid != this.Target.Guid && !newAdd.GotDebuff("Shadow Word: Pain"))
                {
                    if (this.Player.GetSpellRank("Shadow Word: Pain") != 0)
                    {
                        if (this.Player.CanUse("Shadow Word: Pain"))
                        {
                            this.Player.SetTargetTo(newAdd);
                            this.Player.Cast("Shadow Word: Pain");
                        }
                    }
                }
                this.Player.SetTargetTo(properTarget);
            }

            return true;
        }

        public void gotWand()
        {

            if (useShadowForm)
            {
                if (this.Player.ManaPercent < 10 || this.Target.HealthPercent < healthP)
                {
                    if (debug == true)
                    {
                        this.Player.DoString("OutPut1 = 'Starting to Wand'");
                        this.Player.DoString("DEFAULT_CHAT_FRAME:AddMessage('trying to start wanding with shadowform')");
                    }
                    this.Player.StartWand();
                }
            }
            if (debug == true)
            {
                this.Player.DoString("DEFAULT_CHAT_FRAME:AddMessage('trying to start wanding without SForm')");
            }
            this.Player.StartWand();
        }

        public void noWand()
        {
            if (debug == true)
            {
                this.Player.DoString("DEFAULT_CHAT_FRAME:AddMessage('no wand present! attacking otherwise')");
            }
            if (this.Player.ManaPercent > 50)
            {
                this.Player.Cast("Smite");
            }
            else if (this.Target.IsFleeing)
            {
                this.Player.Cast("Smite");
            }
            else
            {
                this.Player.Attack();
            }
        }
                
        public void SelectHPotion()
        {
            if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Major Healing Potion") != 0)
                this.Player.UseItem("Major Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Superior Healing Potion") != 0)
                this.Player.UseItem("Superior Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Greater Healing Potion") != 0)
                this.Player.UseItem("Greater Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Healing Potion") != 0)
                this.Player.UseItem("Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Discolored Healing Potion") != 0)
                this.Player.UseItem("Discolored Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Lesser Healing Potion") != 0)
                this.Player.UseItem("Lesser Healing Potion");
            else if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Minor Healing Potion") != 0)
                this.Player.UseItem("Minor Healing Potion");
        }


        public void SelectMPotion()
        {
            if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Major Mana Potion") != 0)
                this.Player.UseItem("Major Mana Potion");
            else if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Superior Mana Potion") != 0)
                this.Player.UseItem("Superior Mana Potion");
            else if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Greater Mana Potion") != 0)
                this.Player.UseItem("Greater Mana Potion");
            else if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Mana Potion") != 0)
                this.Player.UseItem("Mana Potion");
            else if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Lesser Mana Potion") != 0)
                this.Player.UseItem("Lesser Mana Potion");
            else if (this.Player.ManaPercent <= 20 && this.Player.ItemCount("Minor Healing Potion") != 0)
                this.Player.UseItem("Minor Mana Potion");
        }

        public void SilenceEnemy()
        {   
            //I will be using this condition until I can figure out why Silence is sometimes used at random.
            if (this.Player.ManaPercent >= 75)
            {   //lookig for spells being cast right now
                if (this.Target.IsCasting != "" || this.Target.IsChanneling != "")
                {   // checking, if you are specced into Silence
                    if (this.Player.GetSpellRank("Silence") != 0)
                    {   //Off CD?
                        if (this.Player.CanUse("Silence"))
                        {
                            this.Player.StopCasting();
                            this.Player.Cast("Silence");
                            return;
                        }
                    }
                }
            }
        }

        public void MultipleEnemies()
        {
            if (this.Player.GetSpellRank("Psychic Scream") != 0 && this.Attackers.Count >= 2 && this.Player.CanUse("Psychic Scream") && this.Player.ManaPercent >= 30 && this.Player.HealthPercent <= 90 && this.Target.DistanceToPlayer <= 8)
            {
                this.Player.Cast("Psychic Scream");
            }
            if (this.Player.GetSpellRank("Devouring Plague") != 0 && this.Attackers.Count >= 2 && this.Player.CanUse("Devouring Plague") && this.Player.ManaPercent >= 50 && this.Target.HealthPercent >= 50)
            {
                this.Player.Cast("Devouring Plague");
            }
            if (this.Player.GetSpellRank("Renew") != 0 && this.Attackers.Count >= 2 && this.Player.ManaPercent >= 50 && this.Player.HealthPercent <= 80 && !this.Player.GotBuff("Renew") && !useShadowForm)
            {
                this.Player.Cast("Shadowform");
                this.Player.CastWait("Renew", 1000);
            }
        }

        public void OffensiveSpells()
        {   
            //Make sure to have PW:S up before trying any funky attack stuff after pulling
            if (!this.Player.GotBuff("Power Word Shield") && !this.Player.GotDebuff("Weakened Soul") && this.Player.CanUse("Power Word:Shield"))
            {
                this.Player.Cast("Power Word:Shield");
            }


            /*if (!this.Target.GotDebuff("Shadow Word: Pain") ||
        		(this.Player.CanUse("Mind Flay") && this.Target.HealthPercent >= healthP) ||
        		(this.Player.CanUse("Vampiric Embrace") && !this.Target.GotDebuff("Vampiric Embrace")) ||
        		(this.Target.HealthPercent > 95 && this.Player.CanUse("Mind Blast")))
        	{*/
            if (debug == true)
            {
                this.Player.DoString("DEFAULT_CHAT_FRAME:AddMessage('trying to reapply dots')");
            }
            if (!this.Player.GotBuff("Shadowform") && this.Player.GetSpellRank("Shadowform") != 0)
            {
                this.Player.Cast("Shadowform");
            }

            if (this.Player.GetSpellRank("Shadow Word: Pain") != 0 && this.Target.HealthPercent >= 5 && this.Player.ManaPercent >= 10 && this.Player.IsChanneling == "" && this.Player.IsCasting == "")
            {
                if (!this.Target.GotDebuff("Shadow Word: Pain"))
                {

                    this.Player.Cast("Shadow Word: Pain");
                }
            }

            if (this.Player.CanUse("Berserking"))
            {
                this.Player.TryCast("Berserking");
            }



            if (this.Target.HealthPercent > 95 && this.Player.GetSpellRank("Mind Blast") != 0 && this.Player.CanUse("Mind Blast"))
            {   //In case we bodypull / get a second enemy while fighting, the precast mind blast wont happen.
                this.Player.Cast("Mind Blast");
            }

            if (useVEmb == true)
            {
                if (this.Player.GetSpellRank("Vampiric Embrace") != 0)
                {
                    if (!this.Target.GotDebuff("Vampiric Embrace"))
                    {

                        this.Player.Cast("Vampiric Embrace");
                    }
                }
            }
        }

        public void DefensiveSpells()
        {
            if (this.Player.GetSpellRank("Renew") != 0 && !this.Player.GotBuff("Renew") && this.Player.ManaPercent >= 60 && this.Player.HealthPercent <= 90)
            {
                this.Player.CastWait("Renew", 1000);
            }

            if ((!this.Player.GotBuff("Power Word: Shield") && !this.Player.GotDebuff("Weakened Soul")) ||
                this.Player.HealthPercent <= 40 ||
                !this.Player.GotBuff("Inner Fire"))
            {

                if (debug == true)
                {
                    this.Player.DoString("DEFAULT_CHAT_FRAME:AddMessage('trying to reapply shield or heal')");
                }
                if (this.Player.GetSpellRank("Power Word: Shield") != 0)
                {
                    if (!this.Player.GotBuff("Power Word: Shield") && !this.Player.GotDebuff("Weakened Soul") && this.Player.ManaPercent >= 10)
                    {

                        this.Player.Cast("Power Word: Shield");
                    }
                }

                if (this.Player.HealthPercent <= 40)
                {
                    if (this.Player.GetSpellRank("Flash Heal") != 0 && this.Player.ManaPercent >= 60)
                    {
                        if (this.Player.GotBuff("Shadowform"))
                        {
                            this.Player.Cast("Shadowform");
                        }

                        this.Player.CastWait("Flash Heal", 1000);
                    }
                    else
                    {
                        if (this.Player.GetSpellRank("Heal") != 0)
                        {
                            this.Player.CastWait("Heal", 1000);
                        }
                        this.Player.CastWait("Lesser Heal", 1000);
                    }
                }

                if (this.Player.GetSpellRank("Inner Fire") != 0)
                {
                    if (!Player.GotBuff("Inner Fire"))
                    {
                        this.Player.Cast("Inner Fire");
                    }
                }
            }
        }
        


        public override void PreFight()
        {
            //You can change this value if you have specced into Shadow Reach: 1/3 = 30*1.06 = 32 , 2/3 = 30*1.13 = 34 , 3/3 = 30*1.2 = 36
            this.SetCombatDistance(30);
            pullPriority();

        }

        public override void Fight()
        {
            bool canWand = this.Player.IsWandEquipped();

            MultipleEnemies();
            DefensiveSpells();
            OffensiveSpells();
            MultiDotting();
            SelectMPotion();
            SelectHPotion();

            if (useSilence == true)
            {
                SilenceEnemy();
            }


            if (canWand == true && useWand == true && this.Player.CanUse("Shadow Word: Pain") && this.Player.IsCasting == "" && this.Player.IsChanneling == "")
            {
                gotWand();
            }

            if (canWand == false || useWand == false)
            {
                noWand();
            }
        }




        public override void Rest()
        {
            // Let the internal bot logic handle the drinking for us
        }


        public override bool Buff()
        {
            try
            {

                if (this.Player.GetSpellRank("Touch of Weakness") != 0 && useTouchOfWeakness == true)
                {
                    if (!this.Player.GotBuff("Touch of Weakness"))
                    {
                        this.Player.Cast("Touch of Weakness");
                        return false;
                    }
                }
                if (this.Player.GetSpellRank("Inner Fire") != 0)
                {
                    if (!this.Player.GotBuff("Inner Fire"))
                    {
                        this.Player.Cast("Inner Fire");
                        return false;
                    }
                }
                if (this.Player.GetSpellRank("Power Word: Fortitude") != 0)
                {
                    if (!this.Player.GotBuff("Power Word: Fortitude"))
                    {
                        this.Player.Cast("Power Word: Fortitude");
                        return false;
                    }
                }
                if (this.Player.GetSpellRank("Divine Spirit") != 0)
                {
                    if (!this.Player.GotBuff("Divine Spirit"))
                    {
                        this.Player.Cast("Divine Spirit");
                        return false;
                    }
                }

                if (useShadowForm == true && !this.Player.GotBuff("Shadowform") && this.Player.CanUse("Shadowform"))
                {
                    this.Player.Cast("Shadowform");
                    return false;
                }


                //Talent point spending
                if (BMain.Me.TalentPointsAvailable() > 0)
                {
                    BMain.Me.TalentsLearnByString(Constants.TalentStrings);
                }
            }
            catch (Exception) { }
            //True means we are done buffing, or cannot buff
            return true;
        }
    }
}