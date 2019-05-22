﻿using System;
using System.Collections.Generic;
using ZzukBot.Constants;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateWalk : State
    {
        internal Random ran = new Random();
        internal bool _AdjustWaypoints = false;

        public StateWalk(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => (((ObjectManager.Player.MovementState &
                                               (int)Enums.MovementFlags.Front)
                                              != (int)Enums.MovementFlags.Front)
                                             || !Grinder.Access.Info.Waypoints.NeedToLoadNextWaypoint())
                                            && ObjectManager.Player.Casting == 0
                                            && ObjectManager.Player.Channeling == 0
                                            && !API.BMain.Me.IsLooting;

        internal override string Name => "Walking";


        internal override void Run()
        {
            // start movement to the current waypoint
            if (ObjectManager.Player.Casting != 0)
                return;

            Shared.RandomJump();

            Grinder.Access.Info.Mount.ShouldMount = true;

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (Grinder.Access.Info.PathAfterFightToWaypoint.AfterFightMovement)
            {
                if (Mem.ObjectManager.Player.IsSwimming)
                {
                    API.Helper.StayOnWaterTop();
                    return;
                }

                ObjectManager.Player.CtmTo(
                   Grinder.Access.Info.PathToPosition.ToPos(Grinder.Access.Info.Waypoints.CurrentWaypoint));
            }
            else
            {
                if (Mem.ObjectManager.Player.IsSwimming)
                {
                    API.Helper.StayOnWaterTop();
                    return;
                }

                ObjectManager.Player.CtmTo(
                   Grinder.Access.Info.PathToPosition.ToPos(Grinder.Access.Info.Waypoints.CurrentWaypoint));
            }
        }
    }
}