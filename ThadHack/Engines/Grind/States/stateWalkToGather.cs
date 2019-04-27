﻿using System;
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

        internal override int Priority => 35;

        internal override bool NeedToRun => Grinder.Access.Info.Gather.SearchGatherObjects() && !Grinder.Access.Info.Rest.NeedToDrink && !Grinder.Access.Info.Rest.NeedToEat;

        internal override string Name => "Gathering";

        internal override void Run()
        {
            WoWGameObject nextResource = Grinder.Access.Info.Gather.GetNearestResource();

            if (nextResource == null || Grinder.Access.Info.Gather.IsOnGatherBlacklist(nextResource.Guid)) { Wait.Remove("Gathering"); return; }

            float nextResourceDistance = Calc.Distance3D(nextResource.Position, ObjectManager.Player.Position);
            Helpers.Logger.Append("Want to gather " + nextResource.Name + " in " + (int)nextResourceDistance);

            if (nextResourceDistance > 5)
            {
                lastResourceDistance = nextResourceDistance;
                //lets sprinkle in a random jump once in while
                Shared.RandomJump();

                var tu = Grinder.Access.Info.PathToPosition.ToPos(nextResource.Position);
                ObjectManager.Player.CtmTo(tu);

               /* float prevDistance = nextResourceDistance;
                if (Wait.For("TimeTillBlacklistCheck", 20000))
                {
                    float newDistance = Calc.Distance3D(nextResource.Position, ObjectManager.Player.Position);
                    if(prevDistance - newDistance < 0.2f)
                    {
                        Helpers.Logger.Append("Blacklisting resource " + nextResource.Name + " in " + (int)newDistance);
                        Grinder.Access.Info.Gather.AddToGatherBlacklist(nextResource.Guid);
                    }
                }*/
            }
            else
            {
                randomOpenLootDelay = ran.Next(200, 550) + Grinder.Access.Info.Latency;
                randomTakeLootDelay = ran.Next(50, 250) + Grinder.Access.Info.Latency;

                ObjectManager.Player.StopMovement(Enums.ControlBits.All);
                ObjectManager.Player.CtmStopMovement();

                if (!ObjectManager.Player.IsLooting)
                {
                    if (Wait.For("LootClick", randomOpenLootDelay)) { nextResource.Interact(false); }                        
                }
                else
                {
                    if (Wait.For("LootTake12", randomTakeLootDelay)) { ObjectManager.Player.LootAll(); }
                }

                Wait.For("Gathering", 5300);               
            }
        }
    }
}