using System;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Constants;
using ZzukBot.Objects;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateWalkToGather : State
    {
        private int lastCheck;
        private ulong oldResourceGuid;

        private readonly Random ran = new Random();
        private int randomOpenLootDelay;
        private int randomTakeLootDelay;

        internal override int Priority => 35;

        internal override bool NeedToRun => Grinder.Access.Info.Gather.SearchGatherObjects();

        internal override string Name => "Gathering";

        internal override void Run()
        {
            WoWGameObject savedResource = Grinder.Access.Info.Gather.GetNearestResource();

            if (savedResource == null) { Wait.Remove("Gathering"); return; }

            //if (lastCheck + 10000 >= Environment.TickCount) { Wait.Remove("Gathering"); return; }
            //lastCheck = Environment.TickCount;

            Helpers.Logger.Append("Want to gather " + savedResource.Name + " in " + Calc.Distance3D(savedResource.Position, ObjectManager.Player.Position));

            if (savedResource.Guid != oldResourceGuid)
            {
                oldResourceGuid = savedResource.Guid;
                lastCheck = Environment.TickCount;
                Wait.Remove("Gathering");
            }
            if (Calc.Distance3D(savedResource.Position, ObjectManager.Player.Position) > 5)
            {
                //lets sprinkle in a random jump once in while, maybe?
                Shared.RandomJump();

                var tu = Grinder.Access.Info.PathToObject.ToUnit(savedResource);
                if (tu.Item1)
                    ObjectManager.Player.CtmTo(tu.Item2);

                if (Environment.TickCount - lastCheck >= 5000)
                {
                    Wait.Remove("Gathering");
                }
                lastCheck = Environment.TickCount;

                if (Wait.For("Gathering", 20000))
                {
                    Grinder.Access.Info.Gather.AddToGatherBlacklist(savedResource.Guid);
                }
                Wait.Remove("Gathering");
                randomOpenLootDelay = ran.Next(200, 550) + Grinder.Access.Info.Latency;
                randomTakeLootDelay = ran.Next(50, 250) + Grinder.Access.Info.Latency;
            }
            else
            {
                ObjectManager.Player.StopMovement(Enums.ControlBits.All);
                ObjectManager.Player.CtmStopMovement();

                if (!ObjectManager.Player.IsLooting)
                {
                    if (Wait.For("LootClick", randomOpenLootDelay))
                        savedResource.Interact(false);
                }
                else
                {
                    if (Wait.For("LootTake12", randomTakeLootDelay))
                    {
                        ObjectManager.Player.LootAll();
                        if (ObjectManager.Player.LootSlots == 0)
                        {
                           // Grinder.Access.Info.Gather.AddToGatherBlacklist(savedResource.Guid);
                        }
                           
                        Wait.Remove("Gathering");
                    }
                }
                if (Wait.For("Gathering", 5300))
                {
                   // Grinder.Access.Info.Gather.AddToGatherBlacklist(savedResource.Guid);
                   // savedResource = null;
                }
            }
        }
    }
}