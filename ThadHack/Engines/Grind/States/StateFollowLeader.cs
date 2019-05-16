using ZzukBot.FSM;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateFollowLeader : State
    {
        public StateFollowLeader(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => API.BParty.IsInParty && !API.BParty.IsPartyLeader();

        internal override string Name => "Following Party Leader";

        internal override void Run()
        {
            API.BParty.MoveNearLeader();

            Shared.RandomJump();

            API.Helper.StayOnWaterTop();
        }
    }
}