using System.Collections.Generic;
using ZzukBot.AntiWarden;
using ZzukBot.Constants;
using ZzukBot.Engines.Grind.Info.Path.Base;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateGhostWalk : State
    {
        public StateGhostWalk(int priority) : base(priority)
        {
        }

        internal override bool NeedToRun => ObjectManager.Player.InGhostForm;

        internal override string Name => "Ghostwalk";

        internal override void Run()
        {
            //lets sprinkle in a random jump once in while, maybe?
            Shared.RandomJump();

            if (!Wait.For("StartGhostWalk", 5000, false))
            {
                return;
            }

            if (Grinder.Access.Info.SpiritWalk.GeneratePath)
            {
                var waypoints = new List<Waypoint>();
                if (Grinder.Access.Profile.GhostHotspots != null
                    && Grinder.Access.Profile.GhostHotspots.Length != 0)
                {
                    //if (Calc.Distance2D(Grinder.Access.Profile.GhostHotspots[0].Position,
                    //    ObjectManager.Player.Position) <= 10)
                    {
                        waypoints.AddRange(Grinder.Access.Profile.GhostHotspots);
                    }
                }
                var tmp = new Waypoint
                {
                    Position = ObjectManager.Player.CorpsePosition,
                    Type = Enums.PositionType.Hotspot
                };
                waypoints.Add(tmp);

                Grinder.Access.Info.PathManager.Ghostwalk = new BasePath(waypoints);
                Grinder.Access.Info.SpiritWalk.GeneratePath = false;
                Grinder.Access.Info.PathSafeGhostwalk.Reset();
            }

            if (Grinder.Access.Info.SpiritWalk.DistanceToCorpse <= 40)
            {               
                Grinder.Access.Info.SpiritWalk.ArrivedAtCorpse = true;
                if (Grinder.Access.Info.PathSafeGhostwalk.FindSafePath())
                {
                    var poi = Grinder.Access.Info.PathSafeGhostwalk.NextSafeWaypoint;
                    if (!poi.Item2)
                    {
                        ObjectManager.Player.CtmTo(poi.Item1);
                    }
                    else
                    {
                        Resurrect();
                    }
                }
                else
                {
                     Resurrect();
                }
            }
            else // walk to the general region where our corpse is at
            {
                var to = Grinder.Access.Info.PathToPosition.ToPos(ObjectManager.Player.CorpsePosition);
                ObjectManager.Player.CtmTo(to);                
                Grinder.Access.Info.SpiritWalk.ArrivedAtCorpse = false;
            }
        }

        public static float ToSingle(double value)
        {
            return (float)value;
        }

        private void Resurrect()
        {
            if (Wait.For("ResurrectTimer112", 500))
            {
                if (ObjectManager.Player.TimeUntilResurrect == 0)
                {
                    if (HookWardenMemScan.GetHack("Collision").IsActivated)
                    {
                        HookWardenMemScan.GetHack("Collision").Remove();
                        ObjectManager.Player.CtmStopMovement();
                        Grinder.Access.Info.Rest.ForceRest();
                    }
                    Functions.DoString("RetrieveCorpse()");
                }
            }
        }
    }
}