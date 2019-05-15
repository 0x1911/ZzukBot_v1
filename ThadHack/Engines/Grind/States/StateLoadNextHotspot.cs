using ZzukBot.FSM;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateLoadNextHotspot : State
    {
        public StateLoadNextHotspot(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.Waypoints.AtLastWaypoint;

        internal override string Name => "Loading next Hotspot";

        internal override void Run()
        {
            // Load the next hotspot in line
            Grinder.Access.Info.Waypoints.LoadNextHotspot();
        }
    }
}