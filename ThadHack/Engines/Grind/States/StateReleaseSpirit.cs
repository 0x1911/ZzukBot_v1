﻿using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateReleaseSpirit : State
    {
        public StateReleaseSpirit(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => ObjectManager.Player.IsDead;

        internal override string Name => "Releasing Spirit";

        internal override void Run()
        {
            if (!Wait.For("ReleasingSpirit", 250)) return;
            ObjectManager.Player.CtmStopMovement();
            Wait.Remove("StartGhostWalk");
            Functions.DoString("RepopMe()");
            Grinder.Access.Info.SpiritWalk.GeneratePath = true;
        }
    }
}