using System;
using System.Collections.Generic;
using ZzukBot.Engines.CustomClass;
using ZzukBot.API;


namespace MiniMage
{
    internal static class Constants
    {
        public static readonly Version Release = new Version(0, 1);

        /* http://rpgworld.altervista.org/classic_vanilla_talent/ */
        public static readonly string[] TalentStrings =
        {
            "0000000000000000000000000000000005353233132351051"
        };

    }
    // This is a modified EmuMage & TwinRovaMage for leveling as frost. Credit goes to Emu&TwinRova for the original script. Credits to PhoenixWarlock as well.
    public class Bokutox : CustomClass
    {
        //Edit to true if you want these spells
        bool useManaShield = true;
        bool useDampenMagic = true;
        bool useIceBlock = true;
        bool useCounterSpell = true;
        bool useBlink = true;
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        //This enum will be used later in the fight loop to improve the class greatly.
        enum fightingStateEnum { Bursting, LowPlayerHealth, LowPlayerMana, LowTargetHealth, FrostNovaToBlink, Polymorphing, AoEPull, RunAway, EnemyFlee };

        fightingStateEnum fightState = fightingStateEnum.Bursting;

        private string[] WaterName = {"", "Conjured Water", "Conjured Fresh Water",
                                  "Conjured Purified Water", "Conjured Spring Water",
                                  "Conjured Mineral Water", "Conjured Sparkling Water",
                                  "Conjured Crystal Water"};

        private string[] FoodName = {"", "Conjured Muffin", "Conjured Bread",
                                  "Conjured Rye", "Conjured Pumpernickel",
                                  "Conjured Sourdough", "Conjured Sweet Roll",
                                  "Conjured Cinnamon Roll"};

        private string[] ManaGem = { "Mana Agate", "Mana Jade", "Mana Citrine", "Mana Ruby" };


        //Mage Class
        public override byte DesignedForClass
        {
            get { return (int)ZzukBot.API.Enums.ClassType.Mage; }
        }


        //CustomClass name
        public override string CustomClassName
        {
            get
            {
                return "MiniMage";
            }
        }


        //Prefight
        public override void PreFight()
        {
            this.Player.Attack();
            this.SetCombatDistance(31);
            if (this.Player.GetSpellRank("Ice Barrier") != 0)
            {
                if (!this.Player.GotBuff("Ice Barrier"))
                {
                    if (this.Player.CanUse("Ice Barrier"))
                    {
                        this.Player.Cast("Ice Barrier");
                    }
                }
            }

            // ** Change 1st And 3rd "Frostbolt" TO -- "Fireball" to Make bot Cast Fireball FIRST (Visa Versa)

            if (this.Player.GetSpellRank("Frostbolt") == 0)
            {
                this.Player.Cast("Fireball");
            }
            else
            {
                this.Player.Cast("Frostbolt");
            }
        }


        //FIGHT!
        public override void Fight()
        {

            bool canWand = this.Player.IsWandEquipped();

            if (!canWand)
            {
                Player.Attack();
            }

            //Mana Gem
            if (this.Player.ManaPercent < 25)
            {
                this.Player.UseItem("Mana Jade");
            }

            //Health Potion
            if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Superior Healing Potion") != 0)
            {
                this.Player.UseItem("Superior Healing Potion");
            }

            if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Greater Healing Potion") != 0)
            {
                this.Player.UseItem("Greater Healing Potion");
            }

            if (this.Player.HealthPercent <= 20 && this.Player.ItemCount("Healing Potion") != 0)
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

            //Wand
            if (this.Player.ManaPercent < 1 || Target.HealthPercent < 1)
            {
                if (canWand && this.Player.IsCasting != "Shoot" && this.Player.IsChanneling != "Shoot")
                {
                    this.Player.StartWand();
                    return;
                }
            }


            //Blink on CC
            if (this.Player.GotDebuff("Frost Nova") && this.Target.GotDebuff("Frost Nova")
            || this.Player.GotDebuff("Tendon Rip") && this.Target.GotDebuff("Frost Nova")
            || this.Player.GotDebuff("Entangling Roots") && this.Target.GotDebuff("Frost Nova")
            || this.Player.GotDebuff("Web") && this.Target.GotDebuff("Frost Nova")
            || this.Player.GotDebuff("Kidney Shot") || this.Player.GotDebuff("Intercept Stun")
            || this.Player.GotDebuff("Hammer of Justice") || this.Player.GotDebuff("Stun"))
            {
                if (this.Player.CanUse("Blink") && useBlink)
                {
                    this.Player.Cast("Blink");
                }
            }


            //Counterspell
            if (this.Target.IsCasting != "" || this.Target.IsChanneling != "" && useCounterSpell)
            {
                if (this.Player.GetSpellRank("Counterspell") != 0)
                {
                    if (this.Player.CanUse("Counterspell"))
                    {
                        this.Player.Cast("Counterspell");
                        return;
                    }
                }
            }


            /*
            //Fire Ward
            if (this.Target.isCasting = "Fireball" || this.Target.isCasting = "Scorch" || this.Target.isCasting = "Searing Pain")
            {
               if (this.Player.GetSpellRank("Fire Ward")  != 0)
               {
                  if (this.Player.CanUse("Fire Ward"))
                  {
                     this.Player.Cast("Fire Ward");
                     return;
                  }
               }
            }


            //Frost Ward
            if (this.Target.isCasting = "Frostbolt")
            {
               if (this.Player.GetSpellRank("Frost Ward")  != 0)
               {
                  if (this.Player.CanUse("Frost Ward"))
                  {
                     this.Player.Cast("Frost Ward");
                     return;
                  }
               }
            }
            */


            //mana shield
            if (this.Player.HealthPercent <= 10 && !this.Player.GotBuff("Mana Shield") && useManaShield)
            {
                if (this.Player.GetSpellRank("Mana Shield") != 0)
                {
                    this.Player.Cast("Mana Shield");
                }
            }


            //Ice Block
            if (this.Player.HealthPercent <= 15 && this.Player.CanUse("Ice Block") && useIceBlock)
            {
                this.Player.Cast("Ice Block");
            }


            //ice barrier
            if (this.Player.GetSpellRank("Ice Barrier") != 0 && (this.Attackers.Count > 1 || this.Target.HealthPercent > 10))
            {
                if (!this.Player.GotBuff("Ice Barrier"))
                {
                    if (this.Player.CanUse("Ice Barrier"))
                    {
                        this.Player.Cast("Ice Barrier");
                    }
                }
            }


            /*
            //Sheep add
            if (Attackers.Count > 1)
            {            
               int LowerHP = this.Attackers.Min(Mob => Mob.HealthPercent);
               var LowerHPUnit = this.Attackers.SingleOrDefault(Mob => Mob.HealthPercent == LowerHP);

               int HigherHp = this.Attackers.Max(Mob => Mob.HealthPercent);
               var HigherHpUnit = this.Attackers.SingleOrDefault(Mob => Mob.HealthPercent == HigherHp);
               if(HigherHpUnit != null && !HigherHpUnit.GotDebuff("Polymorph") && HigherHpUnit.Guid != this.Target.Guid)
               {
                  this.Player.SetTargetTo(HigherHpUnit);
                  if(!this.Target.GotDebuff("Polymorph") && this.Player.GetSpellRank("Polymorph") != 0 && this.Player.CanUse("Polymorph"))
                  {
                     this.Player.Cast("Polymorph");
                  }
                  this.Player.SetTargetTo(LowerHPUnit);
               }
            }
            */


            //Backup from Frost Novad target
            if (this.Target.GotDebuff("Frost Nova") && this.Target.DistanceToPlayer <= 10)
            {
                //Use Blink if low hp
                if (this.Player.CanUse("Blink") && useBlink && this.Player.HealthPercent <= 30)
                {
                    this.Player.Cast("Blink");
                }
                else
                {
                    bool res = Player.ForceBackup(8);
                }
            }
            else
            {
                Player.StopForceBackup();
            }

            /*
            //Backup from Frostbite
            if (this.Target.GotDebuff("Frostbite") && this.Target.DistanceToPlayer <=5)
            {
               bool res = Player.ForceBackup(8);
            }
            else
            {
               Player.StopForceBackup();
            }
            */


            //Cone of Cold as finisher if 2+ mobs
            if (this.Player.GetSpellRank("Cone of Cold") != 0 && this.Target.DistanceToPlayer <= 10 && this.Target.HealthPercent < 28 && this.Attackers.Count > 1)
            {
                if (this.Player.CanUse("Cone of Cold"))
                {
                    this.Player.Cast("Cone of Cold");
                    return;
                }
            }


            //Fire Blast as finisher
            if (this.Player.GetSpellRank("Fire Blast") != 0 && this.Target.DistanceToPlayer <= 20 && this.Target.HealthPercent > 28)
            {
                if (this.Player.CanUse("Fire Blast"))
                {
                    this.Player.Cast("Fire Blast");
                    return;
                }
            }


            //Frost Nova Burst
            if (this.Target.GotDebuff("Frost Nova") || this.Target.GotDebuff("Frostbite") || this.Target.GotDebuff("Freeze"))
            {
                if (this.Player.GetSpellRank("Cone of Cold") != 0 && this.Target.DistanceToPlayer <= 10)
                {
                    if (this.Player.CanUse("Cone of Cold") && this.Player.CanUse("Frostbolt"))
                    {
                        this.Player.CastWait("Frostbolt", 4000);
                        this.Player.Cast("Cone of Cold");
                        return;
                    }
                }
                else if (this.Player.GetSpellRank("Fire Blast") != 0 && this.Target.DistanceToPlayer <= 20)
                {
                    if (this.Player.CanUse("Fire Blast") && this.Player.CanUse("Frostbolt"))
                    {
                        this.Player.CastWait("Frostbolt", 4000);
                        this.Player.Cast("Fire Blast");
                        return;
                    }
                }
                else if (this.Player.CanUse("Frostbolt"))
                {
                    this.Player.Cast("Frostbolt");
                    return;
                }
            }


            //Frost Nova
            if (this.Player.CanUse("Frost Nova") && this.Target.DistanceToPlayer <= 10 && this.Target.HealthPercent >= 28 && !this.Target.GotDebuff("Frost Nova")
            && !this.Target.GotDebuff("Frostbite"))
            {
                this.Player.Cast("Frost Nova");
                return;
            }


            //Coldsnap if Frost Nova is on CD and HP is low
            else if (this.Player.CanUse("Frost Nova") == false && this.Target.DistanceToPlayer <= 5 && this.Target.HealthPercent >= 28
            && this.Player.CanUse("Cold Snap") && this.Player.HealthPercent <= 40 && !this.Target.GotDebuff("Frost Nova"))
            {
                this.Player.Cast("Cold Snap");
                return;
            }


            //Spam Frostbolt, if  not Scorch or Fireball
            if (this.Player.GetSpellRank("Frostbolt") == 0)
            {
                this.Player.Cast("Fireball");
            }
            else
            {
                if (this.Player.CanUse("Frostbolt"))
                {
                    this.Player.Cast("Frostbolt");
                }
                else if (this.Player.CanUse("Scorch"))
                {
                    this.Player.Cast("Scorch");
                }
                else if (this.Player.CanUse("Fireball"))
                {
                    this.Player.Cast("Fireball");
                }
                else
                {
                    //this.Player.Cast("Arcane Missiles");
                }
            }
        }

        // Rest
        public override void Rest()
        {

            //evocate for mana if we can
            if (this.Player.GetSpellRank("Evocation") != 0)
            {

                if (this.Player.CanUse("Evocation") && Player.ManaPercent <= 20)
                {
                    this.Player.CastWait("Evocation", 8000);
                    //return;
                }
            }

            //dont cancel evocation if we're casting it.
            if (this.Player.IsChanneling != "Evocation" && this.Player.IsCasting != "Evocation")
            {

                if (this.Player.ItemCount(FoodName[this.Player.GetSpellRank("Conjure Food")]) >= 5)
                {
                    this.Player.Eat(FoodName[this.Player.GetSpellRank("Conjure Food")]);
                }
                else
                {
                    Player.Eat();
                }
                if (this.Player.ItemCount(WaterName[this.Player.GetSpellRank("Conjure Water")]) >= 5)
                {
                    this.Player.Drink(WaterName[this.Player.GetSpellRank("Conjure Water")]);
                }
                else
                {
                    Player.Drink();
                }
            }


        }

        //Buffs
        public override bool Buff()
        {

            if (this.Player.IsCasting != "")
                return false;

            // Conjure Water
            if (this.Player.GetSpellRank("Conjure Water") != 0)
            {
                if (this.Player.ItemCount(WaterName[this.Player.GetSpellRank("Conjure Water")]) <= 5)
                {
                    this.Player.Cast("Conjure Water");
                    return false;
                }
            }

            // Conjure Food
            if (this.Player.GetSpellRank("Conjure Food") != 0)
            {
                if (this.Player.ItemCount(FoodName[this.Player.GetSpellRank("Conjure Food")]) <= 5)
                {
                    this.Player.Cast("Conjure Food");
                    return false;
                }
            }

            // Mage ARMOR Buffs ( Change "Mage" to whatever armor you want for the bot to cast it.)
            if (this.Player.GetSpellRank("Ice Armor") != 0)
            {
                if (!this.Player.GotBuff("Ice Armor"))
                {
                    this.Player.Cast("Ice Armor");
                    return false;
                }
            }
            else
            {
                if (this.Player.GetSpellRank("Frost Armor") != 0)
                {
                    if (!this.Player.GotBuff("Frost Armor"))
                    {
                        this.Player.Cast("Frost Armor");
                        return false;
                    }
                }
            }

            if (this.Player.GetSpellRank("Arcane Intellect") != 0)
            {
                if (!this.Player.GotBuff("Arcane Intellect"))
                {
                    this.Player.Cast("Arcane Intellect");
                    return false;
                }
            }
             if (this.Player.GetSpellRank("Dampen Magic") != 0 && useDampenMagic)
                {
                    if (!this.Player.GotBuff("Dampen Magic"))
                    {
                        this.Player.Cast("Dampen Magic");
                        return false;
                    }
                }

                if (this.Player.ItemCount("Mana Agate") == 0)
                {
                    if (this.Player.TryCast("Conjure Mana Agate") && this.Player.ItemCount("Mana Agate") == 0)
                    {
                        this.Player.Cast("Conjure Mana Agate");
                        return false;
                    }
                }

                if (this.Player.GetSpellRank("Ice Barrier") != 0)
                {
                    if (!this.Player.GotBuff("Ice Barrier"))
                    {
                        if (this.Player.CanUse("Ice Barrier"))
                        {
                            this.Player.Cast("Ice Barrier");
                            return false;
                        }
                        scrollBuff();
                    }
                }
            #region party buffing
            try
            {
                if (ZzukBot.API.BParty.IsInParty)
                {
                    List<ZzukBot.Objects.WoWUnit> tmpPartyMemberList = BParty.GetMembers();

                    foreach (ZzukBot.Objects.WoWUnit tmpMember in tmpPartyMemberList)
                    {
                        if (tmpMember.HealthPercent <= 1 || tmpMember.DistanceToPlayer > 28) { continue; }


                        if (!tmpMember.GotAura("Arcane Intellect") && this.Player.GetSpellRank("Arcane Intellect") != 0)
                        {
                            if (this.Player.TargetPartyMember(tmpMember))
                            { 
                                this.Player.Cast("Arcane Intellect");
                                ZzukBot.API.BMain.Me.ClearTarget();
                            }
                        }
                    }
                }
            }
            catch
            {
                return true;
            }
            #endregion
           

            //Talent point spending
            if (BMain.Me.TalentPointsAvailable() > 0)
            {
                BMain.Me.TalentsLearnByString(Constants.TalentStrings);
            }

            //True means we are done buffing, or cannot buff
            return true;
        }

        //buff with any scrolls that you have
        public void scrollBuff()
        {
            if (this.Player.CanUse("Scroll of Strength I") && this.Player.ItemCount("Scroll of Strength I") > 0 && (!this.Player.GotBuff("Scroll of Strength I") || !this.Player.GotBuff("Scroll of Strength II") || !this.Player.GotBuff("Scroll of Strength III") || !this.Player.GotBuff("Scroll of Strength IV")))
            {
                this.Player.UseItem("Scroll of Strength I");
            }
            if (this.Player.CanUse("Scroll of Strength II") && this.Player.ItemCount("Scroll of Strength II") > 0 && (!this.Player.GotBuff("Scroll of Strength I") || !this.Player.GotBuff("Scroll of Strength II") || !this.Player.GotBuff("Scroll of Strength III") || !this.Player.GotBuff("Scroll of Strength IV")))
            {
                this.Player.UseItem("Scroll of Strength II");
            }
            if (this.Player.CanUse("Scroll of Strength III") && this.Player.ItemCount("Scroll of Strength III") > 0 && (!this.Player.GotBuff("Scroll of Strength I") || !this.Player.GotBuff("Scroll of Strength II") || !this.Player.GotBuff("Scroll of Strength III") || !this.Player.GotBuff("Scroll of Strength IV")))
            {
                this.Player.UseItem("Scroll of Strength III");
            }
            if (this.Player.CanUse("Scroll of Strength IV") && this.Player.ItemCount("Scroll of Strength IV") > 0 && (!this.Player.GotBuff("Scroll of Strength I") || !this.Player.GotBuff("Scroll of Strength II") || !this.Player.GotBuff("Scroll of Strength III") || !this.Player.GotBuff("Scroll of Strength IV")))
            {
                this.Player.UseItem("Scroll of Strength IV");
            }
            if (this.Player.CanUse("Scroll of Agility I") && this.Player.ItemCount("Scroll of Agility I") > 0 && (!this.Player.GotBuff("Scroll of Agility I") || !this.Player.GotBuff("Scroll of Agility II") || !this.Player.GotBuff("Scroll of Agility III") || !this.Player.GotBuff("Scroll of Agility IV")))
            {
                this.Player.UseItem("Scroll of Agility I");
            }
            if (this.Player.CanUse("Scroll of Agility II") && this.Player.ItemCount("Scroll of Agility II") > 0 && (!this.Player.GotBuff("Scroll of Agility I") || !this.Player.GotBuff("Scroll of Agility II") || !this.Player.GotBuff("Scroll of Agility III") || !this.Player.GotBuff("Scroll of Agility IV")))
            {
                this.Player.UseItem("Scroll of Agility II");
            }
            if (this.Player.CanUse("Scroll of Agility III") && this.Player.ItemCount("Scroll of Agility III") > 0 && (!this.Player.GotBuff("Scroll of Agility I") || !this.Player.GotBuff("Scroll of Agility II") || !this.Player.GotBuff("Scroll of Agility III") || !this.Player.GotBuff("Scroll of Agility IV")))
            {
                this.Player.UseItem("Scroll of Agility III");
            }
            if (this.Player.CanUse("Scroll of Agility IV") && this.Player.ItemCount("Scroll of Agility IV") > 0 && (!this.Player.GotBuff("Scroll of Agility I") || !this.Player.GotBuff("Scroll of Agility II") || !this.Player.GotBuff("Scroll of Agility III") || !this.Player.GotBuff("Scroll of Agility IV")))
            {
                this.Player.UseItem("Scroll of Agility IV");
            }
            if (this.Player.CanUse("Scroll of Stamina I") && this.Player.ItemCount("Scroll of Stamina I") > 0 && (!this.Player.GotBuff("Scroll of Stamina I") || !this.Player.GotBuff("Scroll of Stamina II") || !this.Player.GotBuff("Scroll of Stamina III") || !this.Player.GotBuff("Scroll of Stamina IV")))
            {
                this.Player.UseItem("Scroll of Stamina I");
            }
            if (this.Player.CanUse("Scroll of Stamina II") && this.Player.ItemCount("Scroll of Stamina II") > 0 && (!this.Player.GotBuff("Scroll of Stamina I") || !this.Player.GotBuff("Scroll of Stamina II") || !this.Player.GotBuff("Scroll of Stamina III") || !this.Player.GotBuff("Scroll of Stamina IV")))
            {
                this.Player.UseItem("Scroll of Stamina II");
            }
            if (this.Player.CanUse("Scroll of Stamina III") && this.Player.ItemCount("Scroll of Stamina III") > 0 && (!this.Player.GotBuff("Scroll of Stamina I") || !this.Player.GotBuff("Scroll of Stamina II") || !this.Player.GotBuff("Scroll of Stamina III") || !this.Player.GotBuff("Scroll of Stamina IV")))
            {
                this.Player.UseItem("Scroll of Stamina III");
            }
            if (this.Player.CanUse("Scroll of Stamina IV") && this.Player.ItemCount("Scroll of Stamina IV") > 0 && (!this.Player.GotBuff("Scroll of Stamina I") || !this.Player.GotBuff("Scroll of Stamina II") || !this.Player.GotBuff("Scroll of Stamina III") || !this.Player.GotBuff("Scroll of Stamina IV")))
            {
                this.Player.UseItem("Scroll of Stamina IV");
            }
            if (this.Player.CanUse("Scroll of Spirit I") && this.Player.ItemCount("Scroll of Spirit I") > 0 && (!this.Player.GotBuff("Scroll of Spirit I") || !this.Player.GotBuff("Scroll of Spirit II") || !this.Player.GotBuff("Scroll of Spirit III") || !this.Player.GotBuff("Scroll of Spirit IV")))
            {
                this.Player.UseItem("Scroll of Spirit I");
            }
            if (this.Player.CanUse("Scroll of Spirit II") && this.Player.ItemCount("Scroll of Spirit II") > 0 && (!this.Player.GotBuff("Scroll of Spirit I") || !this.Player.GotBuff("Scroll of Spirit II") || !this.Player.GotBuff("Scroll of Spirit III") || !this.Player.GotBuff("Scroll of Spirit IV")))
            {
                this.Player.UseItem("Scroll of Spirit II");
            }
            if (this.Player.CanUse("Scroll of Spirit III") && this.Player.ItemCount("Scroll of Spirit III") > 0 && (!this.Player.GotBuff("Scroll of Spirit I") || !this.Player.GotBuff("Scroll of Spirit II") || !this.Player.GotBuff("Scroll of Spirit III") || !this.Player.GotBuff("Scroll of Spirit IV")))
            {
                this.Player.UseItem("Scroll of Spirit III");
            }
            if (this.Player.CanUse("Scroll of Spirit IV") && this.Player.ItemCount("Scroll of Spirit IV") > 0 && (!this.Player.GotBuff("Scroll of Spirit I") || !this.Player.GotBuff("Scroll of Spirit II") || !this.Player.GotBuff("Scroll of Spirit III") || !this.Player.GotBuff("Scroll of Spirit IV")))
            {
                this.Player.UseItem("Scroll of Spirit IV");
            }
            if (this.Player.CanUse("Scroll of Intellect I") && this.Player.ItemCount("Scroll of Intellect I") > 0 && (!this.Player.GotBuff("Scroll of Intellect I") || !this.Player.GotBuff("Scroll of Intellect II") || !this.Player.GotBuff("Scroll of Intellect III") || !this.Player.GotBuff("Scroll of Intellect IV")))
            {
                this.Player.UseItem("Scroll of Intellect I");
            }
            if (this.Player.CanUse("Scroll of Intellect II") && this.Player.ItemCount("Scroll of Intellect II") > 0 && (!this.Player.GotBuff("Scroll of Intellect I") || !this.Player.GotBuff("Scroll of Intellect II") || !this.Player.GotBuff("Scroll of Intellect III") || !this.Player.GotBuff("Scroll of Intellect IV")))
            {
                this.Player.UseItem("Scroll of Intellect II");
            }
            if (this.Player.CanUse("Scroll of Intellect III") && this.Player.ItemCount("Scroll of Intellect III") > 0 && (!this.Player.GotBuff("Scroll of Intellect I") || !this.Player.GotBuff("Scroll of Intellect II") || !this.Player.GotBuff("Scroll of Intellect III") || !this.Player.GotBuff("Scroll of Intellect IV")))
            {
                this.Player.UseItem("Scroll of Intellect III");
            }
            if (this.Player.CanUse("Scroll of Intellect IV") && this.Player.ItemCount("Scroll of Intellect IV") > 0 && (!this.Player.GotBuff("Scroll of Intellect I") || !this.Player.GotBuff("Scroll of Intellect II") || !this.Player.GotBuff("Scroll of Intellect III") || !this.Player.GotBuff("Scroll of Intellect IV")))
            {
                this.Player.UseItem("Scroll of Intellect IV");
            }
        }

        //cheked each fight loop for the best fight state
        private fightingStateEnum GetFightingState()
        {
            if (Target.DistanceToPlayer <= 7)
            {
                return fightingStateEnum.FrostNovaToBlink;
            }
            else if (this.Player.HealthPercent <= 15)
            {
                return fightingStateEnum.LowPlayerHealth;
            }
            else if (this.Player.ManaPercent <= 10)
            {
                return fightingStateEnum.LowPlayerMana;
            }
            else
            {
                return fightingStateEnum.Bursting;
            }
        }

        //runs all Zzukbot checks for a spell cast. Saves time.
        public bool CheckIfUseableFull(string spellName)
        {
            if (this.Player.GetSpellRank(spellName) != 0 && this.Player.CanUse(spellName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateManaGem()
        {
            if (this.Player.TryCast("Conjure Mana Ruby") && this.Player.ItemCount("Mana Ruby") == 0)
            {
                this.Player.Cast("Conjure Mana Ruby");
            }
            else if (this.Player.TryCast("Conjure Mana Citrine") && this.Player.ItemCount("Mana Citrine") == 0)
            {
                this.Player.Cast("Conjure Mana Citrine");
            }
            else if (this.Player.TryCast("Conjure Mana Jade") && this.Player.ItemCount("Mana Jade") == 0)
            {
                this.Player.Cast("Conjure Mana Jade");
            }
            else if (this.Player.TryCast("Conjure Mana Agate") && this.Player.ItemCount("Mana Agate") == 0)
            {
                this.Player.Cast("Conjure Mana Agate");
            }
        }

        public void UseManaGem()
        {
            if (this.Player.ItemCount(this.Player.GetLastItem(ManaGem)) != 0)
            {
                this.Player.UseItem(this.Player.GetLastItem(ManaGem));
            }
        }
    }
}