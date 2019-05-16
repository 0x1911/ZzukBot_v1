    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using ZzukBot.Engines.CustomClass;

    namespace ConsoleApplication1
    {
        class Fedlock : CustomClass
        {
            //Set to true if you are fighting monsters that cleave or false if monsters don't cleave
            bool backup = false;
            //Set to true if you want to lifetap instead of resting, false to rest instead of lifetapping
            bool lifeTapAtRest = false;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            public override byte DesignedForClass
        {
            get { return (int)ZzukBot.API.Enums.ClassType.Warlock; }
        }

            public override string CustomClassName
            {
                get
                {
                    return "Fedlock v1.7.4";
                }
            }

            public override void PreFight()
            {
                this.SetCombatDistance(29);
                if (this.Player.GotPet())
                {
                    this.Pet.Attack();
                }
                //Agony to pull
                else if (this.Player.CanUse("Curse of Agony") && this.Player.GetSpellRank("Curse of Agony") != 0)
                {
                    this.Player.CastWait("Curse of Agony", 500);
                }
                //Immolate
                else if (this.Player.CanUse("Immolate") && this.Player.GetSpellRank("Immolate") != 0)
                {
                    this.Player.CastWait("Immolate", 500);
                }
            }       
           
            public override void Fight()
            {
                // Send our pet to attack (He should already be doing this anyway)
                if (this.Player.GotPet() && Pet.HealthPercent > 0)
                {
                    this.Pet.Attack();
                }
                //Use Healthstones
                if (this.Player.ItemCount("Minor Healthstone") == 1 && this.Player.HealthPercent <= 15 && !this.Target.GotDebuff("Drain Life"))
                {
                    this.Player.UseItem("Minor Healthstone");
                }
                if (this.Player.ItemCount("Lesser Healthstone") == 1 && this.Player.HealthPercent <= 15 && !this.Target.GotDebuff("Drain Life"))
                {
                    this.Player.UseItem("Lesser Healthstone");
                }
                if (this.Player.ItemCount("Healthstone") == 1 && this.Player.HealthPercent <= 15 && !this.Target.GotDebuff("Drain Life"))
                {
                    this.Player.UseItem("Healthstone");
                }
                if (this.Player.ItemCount("Greater Healthstone") == 1 && this.Player.HealthPercent <= 15 && !this.Target.GotDebuff("Drain Life"))
                {
                    this.Player.UseItem("Greater Healthstone");
                }
                if (this.Player.ItemCount("Major Healthstone") == 1 && this.Player.HealthPercent <= 15 && !this.Target.GotDebuff("Drain Life"))
                {
                    this.Player.UseItem("Major Healthstone");
                }
                //Sacrifice Pet if he (or I) is getting to low on health
                if (this.Player.GotPet())
                {
                    if ((Pet.CanUse("Sacrifice") && Pet.HealthPercent < 9 && Pet.HealthPercent > 0) || (Pet.CanUse("Sacrifice") && this.Player.HealthPercent <= 9 && Pet.HealthPercent > 0))
                    {
                        this.Player.CastWait("Sacrifice", 10000);
                    }
                }
                //Soul Shards, make sure the number of soul shards is the same as the one in the wanding logic
                if (this.Player.ItemCount("Soul Shard") < 3 && this.Target.HealthPercent <= 10 && this.Player.IsCasting == "" && this.Player.IsChanneling == "")
                {
                    this.Player.CastWait("Drain Soul", 1000);
                }
                //HANDLE MULTITARGET FIGHTS >>Credit to dgcfus<<
                if (this.Player.GotPet())
                {
                    if (this.Attackers.Count >= 2 && this.Player.GotPet() && Pet.HealthPercent > 0)
                    {
                        //MAKES THE PET ATTACK THE MOB WHO IS ATTACKING THE TOON, Casts suffering
                        var UnitToAttack = this.Attackers.FirstOrDefault(Mob => Mob.TargetGuid == this.Player.Guid);
                        if (UnitToAttack != null)
                        {
                            this.Player.SetTargetTo(UnitToAttack);
                            if (!this.Pet.IsOnMyTarget())
                            {
                                this.Pet.Attack();
                                this.Player.Cast("Suffering");
                                //Thanks dgcfus
                            }
                        }
                        //IF ALL THE MOBS ARE ATTACKING THE PET FOCUS THE LOWER HP ONE
                        else
                        {
                            int LowerHP = this.Attackers.Min(Mob => Mob.HealthPercent);
                            var LowerHPUnit = this.Attackers.SingleOrDefault(Mob => Mob.HealthPercent == LowerHP);
                            if (LowerHPUnit != null && LowerHPUnit.Guid != this.Target.Guid)
                            {
                                this.Player.SetTargetTo(LowerHPUnit);
                                //Thanks dgcfus
                            }
                        }
                    }
                }
                // Heal Pet
                if (this.Player.IsCasting == "Health Funnel" || this.Player.IsChanneling == "Health Funnel")
                {
                    if (this.Player.HealthPercent >= 20)
                    {
                    return;
                    }
                    else if (this.Player.HealthPercent < 20)
                    {
                        this.Player.StopCasting();
                    }
                }
                else if (this.Player.GotPet())
                {
                    if (Pet.HealthPercent < 40 && Pet.HealthPercent > 0 && this.Player.HealthPercent >= 60 && this.Player.IsCasting == "")
                    {
                        if (this.Player.GetSpellRank("Health Funnel") != 0 && !this.Target.GotDebuff("Drain Life") && this.Player.IsChanneling != "Health Funnel" && this.Player.IsCasting != "Health Funnel")
                        {
                            this.Player.CastWait("Health Funnel", 5000);
                        }
                    }
                }
                //Nightfall!
                if (this.Player.GotBuff("Shadow Trance"))
                {
                    this.Player.CastWait("Shadow Bolt", 1000);
                }
                //Shadowburn
                if (this.Player.CanUse("Shadowburn") && this.Player.GetSpellRank("Shadowburn") != 0 && this.Target.HealthPercent <= 20 && this.Player.ManaPercent >= 10)
                {
                    this.Player.CastWait("Shadowburn", 500);
                }
                //Convenience Life Tap
                if (this.Player.IsCasting == "Drain Soul" || this.Player.IsChanneling == "Drain Soul")
                {
                    return;
                }
                else if (this.Attackers.Count <= 1 && this.Target.HealthPercent <= 10 && this.Player.GotPet() && Pet.HealthPercent > 40 && this.Player.ManaPercent <= 30 && this.Player.GetSpellRank("Life Tap") != 0 && !this.Target.GotDebuff("Drain Life") && this.Player.HealthPercent >= 40)
                {
                    this.Player.Cast("Life Tap");
                }
                //Start DOTs
                //Shadow Bolt if we don't have Immolate
                if (this.Player.GetSpellRank("Immolate") == 0 && this.Player.CanUse("Shadow Bolt") && this.Player.IsCasting == "" && this.Target.HealthPercent >= 80 && this.Player.ManaPercent >= 30)
                {
                    this.Player.CastWait("Shadow Bolt", 2000);
                }
                //Corruption
                if (this.Player.CanUse("Corruption") && this.Player.GetSpellRank("Corruption") != 0 && !this.Target.GotDebuff("Corruption") && !this.Target.GotDebuff("Drain Life") && this.Target.HealthPercent >= 12 && this.Player.ManaPercent >= 10)
                {
                    this.Player.CastWait("Corruption", 500);
                }
                //Agony
                if (this.Player.CanUse("Curse of Agony") && this.Player.GetSpellRank("Curse of Agony") != 0 && !this.Target.GotDebuff("Curse of Agony") && !this.Target.GotDebuff("Drain Life") && this.Target.HealthPercent >= 12 && this.Player.ManaPercent >= 10)
                {
                    this.Player.CastWait("Curse of Agony", 500);
                }
                //SL
                if (this.Player.CanUse("Siphon Life") && this.Player.GetSpellRank("Siphon Life") != 0 && !this.Target.GotDebuff("Siphon Life") && !this.Target.GotDebuff("Drain Life") && this.Target.HealthPercent >= 12 && this.Player.ManaPercent >= 10)
                {
                    this.Player.CastWait("Siphon Life", 500);
                }
                //Drain Life
                if (this.Player.HealthPercent <= 60 && this.Player.ManaPercent >= 20 && !this.Target.GotDebuff("Drain Life") && this.Player.GetSpellRank("Drain Life") != 0 && this.Target.HealthPercent >= 10)
                {
                    this.SetCombatDistance(19);
                    this.Player.CastWait("Drain Life", 1000);
                }
                //Immolate
                if (this.Player.CanUse("Immolate") && this.Player.GetSpellRank("Immolate") != 0 && !this.Target.GotDebuff("Immolate") && !this.Target.GotDebuff("Drain Life") && this.Target.HealthPercent >= 12 && this.Player.ManaPercent >= 10)
                {
                    this.Player.CastWait("Immolate", 500);
                }
                //Necessity Life Tap
                if ((this.Player.CanUse("Life Tap") && this.Player.ManaPercent <= 30 && this.Player.GetSpellRank("Life Tap") != 0 && !this.Target.GotDebuff("Drain Life") && this.Player.HealthPercent >= 60) || (this.Player.ManaPercent <= 80 && this.Player.GetSpellRank("Life Tap") != 0 && !this.Target.GotDebuff("Drain Life") && this.Player.HealthPercent >= 90))
                {
                    this.Player.Cast("Life Tap");
                }
                //Try to stay at 8 yards in case of cleave
                if (this.Pet.IsTanking())
                {
                    if (this.Target.DistanceToPlayer < 8 && backup)
                    {
                        bool res = Player.ForceBackup(8);
                    }
                    else
                    {
                        Player.StopForceBackup();
                    }
                }
                //Wanding
                if (this.Player.IsCasting == "" && this.Player.IsChanneling == "")
                {
                    bool canWand = this.Player.IsWandEquipped();
                    //Check if we can use immolate just as a GCD tracker.  Set soul shard value to that in drain soul logic.
                    if ((!this.Player.GotPet() || this.Player.CanUse("Immolate") && this.Player.ManaPercent <= 20) || (this.Player.CanUse("Immolate") && this.Player.HealthPercent > 60 && this.Player.ManaPercent > 30 && this.Target.GotDebuff("Immolate") && this.Target.GotDebuff("Corruption") && this.Target.GotDebuff("Curse of Agony")) || (this.Player.CanUse("Immolate") && this.Player.ItemCount("Soul Shard") == 3 && this.Target.HealthPercent < 12 && this.Attackers.Count <= 1) || this.Player.GetSpellRank("Curse of Agony") == 0)
                    {
                        if (canWand)
                        {
                            this.Player.StartWand();
                        }
                        else
                        {
                            this.SetCombatDistance(4);
                            this.Player.Attack();
                        }
                    }
                }
            }
           
            public override void Rest()
            {
                if (lifeTapAtRest)
                {
                    if ((this.Player.CanUse("Life Tap") && this.Player.ManaPercent <= 80 && this.Player.HealthPercent >= 80) || (this.Player.CanUse("Life Tap") && this.Player.ManaPercent <= 60 && this.Player.HealthPercent >= 60) || (this.Player.CanUse("Life Tap") && this.Player.ManaPercent <= 30 && this.Player.HealthPercent >= 30) || (this.Player.CanUse("Life Tap") && this.Player.ManaPercent <= 10 && this.Player.HealthPercent >= 10))
                    {
                        this.Player.Cast("Life Tap");
                    }
                }
                else if (this.Player.HealthPercent <= 20 && this.Player.IsCasting == "Health Funnel")
                {
                    this.Player.StopCasting();
                }
                else if (this.Player.HealthPercent <= 20 && this.Player.IsChanneling == "Health Funnel")
                {
                    this.Player.StopCasting();
                }
                else if (Pet.HealthPercent < 60 && Pet.HealthPercent > 0 && this.Player.HealthPercent >= 80 && this.Player.IsCasting == "" && this.Player.IsChanneling == "")
                {
                    if (this.Player.GetSpellRank("Health Funnel") != 0 && !this.Target.GotDebuff("Drain Life") && this.Player.IsChanneling != "Health Funnel" && this.Player.IsCasting != "Health Funnel")
                        {
                            this.Player.CastWait("Health Funnel", 5000);
                        }
                }
                else if ( this.Player.IsCasting == "" && this.Player.IsChanneling == "")
                {
                    this.Player.Drink();
                    this.Player.Eat();
                }
            }
           
            public override bool Buff()
            {
                if (this.Player.IsCasting == "Summon Voidwalker")
                {
                    return false;
                }
                if (this.Player.IsCasting == "Summon Imp")
                {
                    return false;
                }
                if (this.Player.IsCasting == "Health Funnel")
                {
                    return false;
                }
                if (this.Player.IsCasting == "Create Healthstone (Minor)")
                {         
                    return false;
                }
                if (this.Player.IsCasting == "Create Healthstone (Lesser)")
                {         
                    return false;
                }
                if (this.Player.IsCasting == "Create Healthstone")
                {         
                    return false;
                }
                if (this.Player.IsCasting == "Create Healthstone (Greater)")
                {         
                    return false;
                }
                if (this.Player.IsCasting == "Create Healthstone (Major)")
                {         
                    return false;
                }
                //Summon Pet
                if (this.Player.IsCasting == "")
                {
                    if (this.Player.GotPet())
                    {
                        if (Pet.HealthPercent <= 0)
                        {
                            if (this.Player.CanUse("Summon Voidwalker") && this.Player.GetSpellRank("Summon Voidwalker") != 0 && this.Player.ItemCount("Soul Shard") >= 1)
                            {
                                this.Player.Cast("Summon Voidwalker");
                                return false;
                            }
                        }
                    }
                    else           
                    {
                        if (this.Player.CanUse("Summon Voidwalker") && this.Player.GetSpellRank("Summon Voidwalker") != 0 && this.Player.ItemCount("Soul Shard") >= 1)
                        {
                            this.Player.Cast("Summon Voidwalker");
                            return false;
                        }
                        else if (this.Player.CanUse("Summon Imp") && this.Player.GetSpellRank("Summon Imp") != 0)
                        {
                            this.Player.Cast("Summon Imp");
                            return false;
                        }
                        else
                        {
                            return false;   
                        }
                    }
                }//End Summon Pet
                //Create Health Stones
                if (this.Player.GetSpellRank("Create Healthstone (Major)") != 0 && this.Player.ItemCount("Major Healthstone") < 1 && this.Player.ItemCount("Soul Shard") >= 2)
                {
                    this.Player.CastWait("Create Healthstone (Major)()", 3500);
                    return false;
                }
                if (this.Player.GetSpellRank("Create Healthstone (Greater)") != 0 && this.Player.ItemCount("Major Healthstone") < 1 && this.Player.ItemCount("Greater Healthstone") < 1 && this.Player.ItemCount("Soul Shard") >= 2)
                {
                    this.Player.CastWait("Create Healthstone (Greater)()", 3500);
                    return false;
                }          
                if (this.Player.GetSpellRank("Create Healthstone") != 0 && this.Player.ItemCount("Major Healthstone") < 1 && this.Player.ItemCount("Greater Healthstone") < 1 && this.Player.ItemCount("Healthstone") < 1 && this.Player.ItemCount("Soul Shard") >= 2)
                {
                    this.Player.CastWait("Create Healthstone()", 3500);
                    return false;
                }          
                if (this.Player.GetSpellRank("Create Healthstone (Lesser)") != 0 && this.Player.ItemCount("Major Healthstone") < 1 && this.Player.ItemCount("Greater Healthstone") < 1 && this.Player.ItemCount("Healthstone") < 1 && this.Player.ItemCount("Lesser Healthstone") < 1 && this.Player.ItemCount("Soul Shard") >= 2)
                {
                    this.Player.CastWait("Create Healthstone (Lesser)()", 3500);
                    return false;
                }          
                if (this.Player.GetSpellRank("Create Healthstone (Minor)") != 0 && this.Player.ItemCount("Major Healthstone") < 1 && this.Player.ItemCount("Greater Healthstone") < 1 && this.Player.ItemCount("Healthstone") < 1 && this.Player.ItemCount("Lesser Healthstone") < 1 && this.Player.ItemCount("Minor Healthstone") < 1 && this.Player.ItemCount("Soul Shard") >= 2)
                {
                    this.Player.CastWait("Create Healthstone (Minor)()", 3500);
                    return false;
                }//End Healthstones
                //Armor         
                if (this.Player.CanUse("Demon Armor") && this.Player.GetSpellRank("Demon Armor") != 0)
                {
                    if (!this.Player.GotBuff("Demon Armor"))
                    {
                        this.Player.Cast("Demon Armor");
                        return false;
                    }
                }
                else if (this.Player.CanUse("Demon Skin") && this.Player.GetSpellRank("Demon Skin") != 0)
                {
                    if (!this.Player.GotBuff("Demon Skin"))
                    {
                        this.Player.Cast("Demon Skin");
                        return false;
                    }
                }
                else
                {
                    return false;   
                }//End Armor
                return true;
            }
        }
    }