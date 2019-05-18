using ZzukBot.FSM;

namespace ZzukBot.Engines.Grind.States
{
    internal class stateWaitForMembers : State
    {
        public stateWaitForMembers(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => API.BParty.IsInParty && API.BParty.IsPartyLeader() && API.BParty.NeedToWaitForGroup();

        internal override string Name => "Waiting for Party Member";

        internal override void Run()
        {
            Shared.RandomJump();

            API.Helper.StayOnWaterTop();
        }
    }
}