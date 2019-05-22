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
        private readonly Random ran = new Random();
        private int randomOpenLootDelay;
        private int randomTakeLootDelay;
        private float lastResourceDistance;

        public StateWalkToGather(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => !Grinder.Access.Info.Vendor.NeedToVendor && Grinder.Access.Info.Gather.GatherObjectInRange() && !Grinder.Access.Info.Rest.NeedToDrink && !Grinder.Access.Info.Rest.NeedToEat;

        internal override string Name => "Gathering";

        internal override void Run()
        {
            WoWGameObject nextResource = Grinder.Access.Info.Gather.GetNearestResource();

            if(!ObjectManager.Player.DiscoveredResources.ContainsKey(nextResource)) { ObjectManager.Player.DiscoveredResources.Add(nextResource, TimeSpan.FromTicks(DateTime.Now.Ticks));  }

            if (nextResource == null || Grinder.Access.Info.Gather.IsOnGatherBlacklist(nextResource.Guid)) { if (Wait.For("GatherTimeout", 5000)) Wait.Remove("Gathering"); return; }
            
            float nextResourceDistance = Calc.Distance3D(nextResource.Position, ObjectManager.Player.Position);
            //  Helpers.Logger.Append("Want to gather " + nextResource.Name + " in " + (int)nextResourceDistance);

            if (nextResourceDistance > 4.5)
            {
                //lets sprinkle in a random jump once in while
                Shared.RandomJump();
                Grinder.Access.Info.Mount.ShouldMount = true;

                var tu = Grinder.Access.Info.PathToPosition.ToPos(nextResource.Position);
                ObjectManager.Player.CtmTo(tu);

                if (ObjectManager.Player.DiscoveredResources.ContainsKey(nextResource))
                {
                    TimeSpan tmpResource = ObjectManager.Player.DiscoveredResources[nextResource];
                    if(tmpResource.TotalSeconds + 40 < TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds)
                    {
                        Helpers.Logger.Append("Blacklisting resource " + nextResource.Name + " guid: " + nextResource.Guid);
                        Grinder.Access.Info.Gather.AddToGatherBlacklist(nextResource.Guid);
                    }
                }
            }
            else
            {
                Grinder.Access.Info.Mount.ShouldMount = false;
                randomOpenLootDelay = ran.Next(200, 550) + Grinder.Access.Info.Latency;
                randomTakeLootDelay = ran.Next(50, 250) + Grinder.Access.Info.Latency;

                ObjectManager.Player.StopMovement(Enums.ControlBits.All);
                ObjectManager.Player.CtmStopMovement();

                nextResource = Grinder.Access.Info.Gather.GetNearestResource();

                if (!ObjectManager.Player.IsLooting && nextResource != null)
                {
                    if (Wait.For("LootClick", randomOpenLootDelay)) { nextResource.Interact(true); }                        
                }
                else if(nextResource != null)
                {
                    if (Wait.For("LootTake12", randomTakeLootDelay)) { ObjectManager.Player.LootAll(); }
                }

                Wait.For("Gathering", 5300);               
            }
        }
    }
}