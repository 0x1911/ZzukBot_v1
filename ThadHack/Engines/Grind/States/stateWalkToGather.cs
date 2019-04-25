using System;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Constants;

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

        internal override string Name => "Traveling to gathering spot";

        internal override void Run()
        {
            var resource = Grinder.Access.Info.Gather.GetNearestResource();

            if (resource == null) return;
            if (resource.Guid != oldResourceGuid)
            {
                oldResourceGuid = resource.Guid;
                lastCheck = Environment.TickCount;
                Wait.Remove("RunToGather");
                Wait.Remove("Gathering");
            }
            if (Calc.Distance3D(resource.Position, ObjectManager.Player.Position) > 4)
            {
                var tu = Grinder.Access.Info.PathToObject.ToUnit(resource);
                if (tu.Item1)
                    ObjectManager.Player.CtmTo(tu.Item2);

                if (Environment.TickCount - lastCheck >= 5000)
                {
                    Wait.Remove("RunToGather");
                }
                lastCheck = Environment.TickCount;

                if (Wait.For("RunToGather", 20000))
                {
                    Grinder.Access.Info.Gather.AddToGatherBlacklist(resource.Guid);
                }
                Wait.Remove("Gathering");
                randomOpenLootDelay = ran.Next(5050, 7550) + Grinder.Access.Info.Latency;
                randomTakeLootDelay = ran.Next(50, 250) + Grinder.Access.Info.Latency;
            }
            else
            {
                if (!ObjectManager.Player.IsLooting)
                {
                    ObjectManager.Player.StopMovement(Enums.ControlBits.All);

                    if (Wait.For("LootClick", randomOpenLootDelay))
                        resource.Interact(false);
                }
                else
                {
                    if (Wait.For("LootTake12", randomTakeLootDelay))
                    {
                        ObjectManager.Player.LootAll();
                        if (ObjectManager.Player.LootSlots == 0)
                           // Grinder.Access.Info.Gather.AddToGatherBlacklist(resource.Guid);
                        Wait.Remove("Gathering");
                    }
                }
                if (Wait.For("Gathering", 5300))
                {
                   // Grinder.Access.Info.Gather.AddToGatherBlacklist(resource.Guid);
                }
            }
        }
    }
}