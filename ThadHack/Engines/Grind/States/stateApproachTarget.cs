﻿using System;
using System.Collections.Generic;
using ZzukBot.Engines.CustomClass;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateApproachTarget : State
    {
        private readonly Random ran = new Random();
        private WoWUnit target;

        public StateApproachTarget(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => Grinder.Access.Info.Target.ShouldAttackTarget;

        internal override string Name => "Approaching Target";

        internal override void Run()
        {

            target = ObjectManager.Target;
            if (target == null) return;
            if (Grinder.Access.Info.Combat.IsBlacklisted(target)) return;
            var player = ObjectManager.Player;
            var IsCasting = !(player.Casting == 0 && player.Channeling == 0);
            var targetIsMoving = (target.MovementState & 0x1) == 0x1;
            var playerIsMoving = (player.MovementState & 0x1) == 0x1;
            var distanceToTarget =
                Calc.Distance3D(player.Position, target.Position);

            Grinder.Access.Info.PathAfterFightToWaypoint.SetAfterFightMovement();
            Grinder.Access.Info.Loot.RemoveRespawnedMobsFromBlacklist(target.Guid);
            Grinder.Access.Info.Target.SearchDirect = true;
            Grinder.Access.Info.Combat.LastFightTick = Environment.TickCount + ran.Next(50, 100);

            Grinder.Access.Info.Mount.ShouldMount = false;
            if (target != null)
            {
                //start auto attack
                ObjectManager.Player.Spells.Attack();

                try
                {
                    if (Grinder.Access.Info.Combat.Attackers.Count != 0 &&
                        !Grinder.Access.Info.Combat.IsAttacker(target.Guid))
                    {
                        var tmpUnit = Grinder.Access.Info.Combat.Attackers[0];
                        if (tmpUnit == null) return;
                        player.SetTarget(tmpUnit.Guid);
                        target = tmpUnit;
                        ObjectManager.Player.Spells.StopCasting();
                    }
                }
                catch
                {
                }


                if (distanceToTarget >= Grinder.Access.Info.Target.CombatDistance && ((!IsCasting
                                                                                       &&
                                                                                       !Grinder.Access.Info.Combat
                                                                                           .IsMoving) ||
                                                                                      !Grinder.Access.Info.Target
                                                                                          .InSightWithTarget))
                {
                    //lets sprinkle in a random jump once in while, maybe?
                    Shared.RandomJump();
                    var tu = Grinder.Access.Info.PathToUnit.ToUnit(target);
                    if (tu.Item1)
                        player.CtmTo(tu.Item2);
                }
                else
                {
                    if (!Grinder.Access.Info.Combat.IsMoving)
                    {
                        if (playerIsMoving)
                        {
                            if (!(Grinder.Access.Info.Target.CombatDistance <= 4 && IsCasting && targetIsMoving))
                                player.CtmStopMovement();
                        }
                        else
                        {
                            ObjectManager.Player.CtmSetToIdle();
                            player.Face(target);
                        }
                    }
                    else
                    {
                        if (Grinder.Access.Info.Combat.IsMovingBack)
                        {
                        }
                        else if (Grinder.Access.Info.Target.FixFacing)
                        {
                            Grinder.Access.Info.Target.FixFacing = false;
                        }
                    }
                }
                CCManager.PreFightPulse(ref target);
            }
        }
    }
}