﻿using ZzukBot.FSM;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateWalkBackToGrind : State
    {
        public StateWalkBackToGrind(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.Vendor.GoBackToGrindAfterVendor;

        internal override string Name => "Travel back to Grind";

        internal override void Run()
        {
            //lets sprinkle in a random jump once in while, maybe?
            Shared.RandomJump();

            Grinder.Access.Info.Mount.ShouldMount = true;

            if (Grinder.Access.Info.PathManager.GrindToVendor != null && Grinder.Access.Info.Vendor.RegenerateSubPath)
            {
                Grinder.Access.Info.PathManager.GrindToVendor.RegenerateSubPath();
                Grinder.Access.Info.Vendor.RegenerateSubPath = false;
            }

            var to = Grinder.Access.Info.PathManager.VendorToGrind.NextWaypoint;
            ObjectManager.Player.CtmTo(to);

            if (Grinder.Access.Info.PathManager.VendorToGrind.ArrivedAtDestination)
            {
                Grinder.Access.Info.Vendor.GoBackToGrindAfterVendor = false;
                Grinder.Access.Info.Waypoints.ResetGrindPath();
            }

            API.Helper.StayOnWaterTop();
        }
    }
}