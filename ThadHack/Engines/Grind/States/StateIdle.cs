using ZzukBot.FSM;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateIdle : State
    {
        public StateIdle(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => true;

        internal override string Name => "Idle";

        internal override void Run()
        {
        }
    }
}