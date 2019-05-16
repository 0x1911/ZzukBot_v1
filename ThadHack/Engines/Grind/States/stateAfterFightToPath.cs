using System.Collections.Generic;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateAfterFightToPath : State
    {
        public StateAfterFightToPath(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.PathAfterFightToWaypoint.NeedToReturn() && !Grinder.Access.Info.Rest.NeedToDrink && !Grinder.Access.Info.Rest.NeedToEat;

        internal override string Name => "Back to path";

        internal override void Run()
        {
            Shared.RandomJump();
                        
            var tu = Grinder.Access.Info.PathToPosition.ToPos(Grinder.Access.Info.Waypoints.CurrentWaypoint);
            ObjectManager.Player.CtmTo(tu);           
        }
    }
}