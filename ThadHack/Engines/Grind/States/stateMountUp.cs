using ZzukBot.FSM;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateMountUp : State
    {
        public StateMountUp(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.Mount.ShouldMount && Grinder.Access.Info.Mount.CouldMount();

        internal override string Name => "Mounting";

        internal override void Run()
        {
            // start movement to the current waypoint
            if (ObjectManager.Player.Casting != 0)
                return;

            //mount if possible
            Grinder.Access.Info.Mount.MountUp();
        }
    }
}