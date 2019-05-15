using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateStartBreak : State
    {
        public StateStartBreak(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.BreakHelper.NeedToBreak;

        internal override string Name => "Starting break";

        internal override void Run()
        {
            if (Wait.For("ForceBreakLogoutTimer", 5000))
            {
                Functions.DoString("Logout()");
            }
        }
    }
}