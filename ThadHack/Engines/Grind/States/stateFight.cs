using System;
using System.Collections.Generic;
using System.Linq;
using ZzukBot.Constants;
using ZzukBot.Engines.CustomClass;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateFight : State
    {
        private bool CanceledLogout = true;
        private readonly Random ran = new Random();

        internal override int Priority => 50;

        internal override bool NeedToRun => Grinder.Access.Info.Combat.Attackers.Count != 0;

        internal override string Name => "Fight";

        internal override void Run()
        {

            #region do we have a target? get one
            WoWUnit target = ObjectManager.Target;
            if (target == null)
            {
                var tmp = Grinder.Access.Info.Combat.Attackers.OrderBy(i => i.Health).FirstOrDefault();
                if (tmp == null) return;
                ObjectManager.Player.SetTarget(tmp);
                return;
            }
            #endregion
            
            var player = ObjectManager.Player;
            var IsCasting = !(player.Casting == 0 && player.Channeling == 0);
            var targetIsMoving = (target.MovementState & 0x1) == 0x1;
            var playerIsMoving = (player.MovementState & 0x1) == 0x1;
            var distanceToTarget = Calc.Distance3D(player.Position, target.Position);
            //reset resources so they dont get blacklisted because of a fight
            player.DiscoveredResources = new Dictionary<WoWGameObject, TimeSpan>();

            //move out of the campfire if we are standing in one
            API.Helper.MoveOutOfCampfire();

            //do we need to repair or empty out our bags?
            if (Grinder.Access.Info.Vendor.GoBackToGrindAfterVendor || Grinder.Access.Info.Vendor.TravelingToVendor) { Grinder.Access.Info.Vendor.RegenerateSubPath = true; }

            Grinder.Access.Info.PathAfterFightToWaypoint.SetAfterFightMovement();
            Grinder.Access.Info.Combat.LastFightTick = Environment.TickCount + ran.Next(50, 100);
            Grinder.Access.Info.Loot.RemoveRespawnedMobsFromBlacklist(Grinder.Access.Info.Combat.Attackers);
            Grinder.Access.Info.Target.SearchDirect = true;

            #region Is it break/pause time?
            if (Grinder.Access.Info.BreakHelper.NeedToBreak)
            {
                if (CanceledLogout)
                {
                    Functions.DoString("CancelLogout()");
                    CanceledLogout = false;
                }
            }
            else { CanceledLogout = true; }
            #endregion

            #region set the correct target, or target overall if we dont have one yet
            if (!Grinder.Access.Info.Combat.IsAttacker(target.Guid))
            {
                var tmp = Grinder.Access.Info.Combat.Attackers.OrderBy(i => i.Health).FirstOrDefault();
                if (tmp == null) return;
                ObjectManager.Player.SetTarget(tmp);
                ObjectManager.Player.Spells.StopCasting();
                return;
            }
            #endregion

            #region Stop Movement, Face Target
            if (Grinder.Access.Info.Combat.IsMoving || playerIsMoving || Grinder.Access.Info.Combat.IsMovingBack)
            {
                player.CtmStopMovement();
                player.StopMovement(Enums.ControlBits.All);
                API.Helper.FixFacing(target);
            }
            else
            {
                ObjectManager.Player.CtmSetToIdle();
                player.Face(target);
            }

            if (Grinder.Access.Info.Target.FixFacing)
            {
                API.Helper.FixFacing(target);
            }
            #endregion
            
            #region move back into combat distance range or 'Line of Sight'
            if (distanceToTarget >= Grinder.Access.Info.Target.CombatDistance && 
                ((!IsCasting && !Grinder.Access.Info.Combat.IsMoving) ||
                !Grinder.Access.Info.Target.InSightWithTarget))
            {
                var tu = Grinder.Access.Info.PathToUnit.ToUnit(target);
                if (tu.Item1)
                    player.CtmTo(tu.Item2);
            }
            #endregion


            //hand the control over to the CustomClass
            CCManager.FightPulse(ref target);
        }
    }
}