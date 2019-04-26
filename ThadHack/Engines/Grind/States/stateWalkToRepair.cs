using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateWalkToRepair : State
    {
        internal override int Priority => 41;

        internal override bool NeedToRun => Grinder.Access.Info.Vendor.TravelingToVendor;

        internal override string Name => "Travel to Vendor";

        internal override void Run()
        {
            //do we have a repair NPC saved?
            if (Grinder.Access.Profile.RepairNPC == null)
            {
                //there is nothing we can do without the proper data..
                Grinder.Access.Info.Vendor.TravelingToVendor = false;
                return;
            }


            XYZ tmpNpcCoords = Grinder.Access.Profile.RepairNPC.Coordinates;
            if (Calc.Distance3D(tmpNpcCoords, ObjectManager.Player.Position) > 4)
            {
                //lets sprinkle in a random jump once in while
                Shared.RandomJump();

                var to = Grinder.Access.Info.PathToPosition.ToPos(tmpNpcCoords);
                ObjectManager.Player.CtmTo(to);
            }
            else
            {
                Grinder.Access.Info.Vendor.TravelingToVendor = false;
            }
        }
    }
}