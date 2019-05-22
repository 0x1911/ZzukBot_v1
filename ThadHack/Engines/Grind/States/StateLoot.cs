using System;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateLoot : State
    {
        private int lastCheck;

        private ulong oldMobGuid;
        private readonly Random ran = new Random();
        private int randomOpenLootDelay;
        private int randomTakeLootDelay;

        public StateLoot(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.Loot.NeedToLoot && !Grinder.Access.Info.Vendor.GoBackToGrindAfterVendor
                                            && !Grinder.Access.Info.Vendor.TravelingToVendor;

        internal override string Name => "Looting";

        internal override void Run()
        {
            var mob = Grinder.Access.Info.Loot.LootableMob;
            if (mob == null) return;


            Grinder.Access.Info.Mount.ShouldMount = false;
            if (mob.Guid != oldMobGuid)
            {
                oldMobGuid = mob.Guid;
                lastCheck = Environment.TickCount;
                Wait.Remove("RunToLoot");
                Wait.Remove("Looting");
            }
            if (Calc.Distance3D(mob.Position, ObjectManager.Player.Position) > 4)
            {
                var tu = Grinder.Access.Info.PathToUnit.ToUnit(mob);
                if (tu.Item1)
                    ObjectManager.Player.CtmTo(tu.Item2);

                if (Environment.TickCount - lastCheck >= 5000)
                {
                    Wait.Remove("RunToLoot");
                }
                lastCheck = Environment.TickCount;

                if (Wait.For("RunToLoot", 10000))
                {
                    Grinder.Access.Info.Loot.AddToLootBlacklist(mob.Guid);
                }
                Wait.Remove("Looting");
                randomOpenLootDelay = ran.Next(250, 750) + Grinder.Access.Info.Latency;
                randomTakeLootDelay = ran.Next(50, 250) + Grinder.Access.Info.Latency;
            }
            else
            {                                
                // standard looting
                if(mob != null)
                {
                    if (Wait.For("LootTake12", randomTakeLootDelay))
                    {
                        ObjectManager.Player.LootAll();
                      /*  if (ObjectManager.Player.LootSlots == 0)
                        {
                            Grinder.Access.Info.Loot.AddToLootBlacklist(mob.Guid);
                        } */
                    }
                }

                // skin unit if set so in settings
                if (mob != null && mob.IsSkinable && (Settings.Settings.SkinUnits || Settings.Settings.NinjaSkin))
                {
                    // var auto = mob.IsSkinable;
                    if (Wait.For("LootClick", randomOpenLootDelay))
                    {
                        ObjectManager.Player.RightClick(mob);
                    }
                }
                                
                int LootTimeOut = 1500;
                //increase lootTimeOut if we need to skin the(a) mob!
                if(Settings.Settings.SkinUnits || Settings.Settings.NinjaSkin) { LootTimeOut = 5500; }
                // everything loot related seems to be done.. blacklist the mob
                if (mob != null && (!Settings.Settings.SkinUnits || !mob.IsSkinable) && Wait.For("Looting", LootTimeOut))
                {
                    Grinder.Access.Info.Loot.AddToLootBlacklist(mob.Guid);
                    Wait.Remove("Looting");
                }
            }
        }
    }
}