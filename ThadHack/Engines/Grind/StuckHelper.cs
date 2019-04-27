using System;
using ZzukBot.AntiWarden;
using ZzukBot.Constants;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.Engines.Grind
{
    internal class _StuckHelper
    {
        private readonly Hack Col = HookWardenMemScan.GetHack("Collision");
        private readonly Hack Col3 = HookWardenMemScan.GetHack("Collision3");
        private float diffToPoint;


        private XYZ oldPosition = new XYZ(0, 0, 0);
        private int StuckAtPointSince;

        internal _StuckHelper()
        {
            ObjectManager.Player.OnCtmAction += CtmAreWeStuck;
        }

        ~_StuckHelper()
        {
            ObjectManager.Player.OnCtmAction -= CtmAreWeStuck;
        }

        internal void CtmAreWeStuck(CtmAction e)
        {
            var parType = e.Type;
            var parPosition = e.Position;

            switch (parType)
            {
                case Enums.CtmType.Move:
                    if (Calc.Distance3D(oldPosition, parPosition) > 0.1f)
                    {
                        oldPosition = parPosition;
                        StuckAtPointSince = Environment.TickCount;
                        diffToPoint = Calc.Distance3D(ObjectManager.Player.Position, parPosition);
                        Col.Remove();
                        Col3.Remove();
                    }
                    else
                    {
                        var newDiffToPoint = Calc.Distance3D(ObjectManager.Player.Position, parPosition);
                        if (Math.Abs(newDiffToPoint - diffToPoint) > 1.5f || newDiffToPoint < 1.3f)
                        {
                            diffToPoint = newDiffToPoint;
                            StuckAtPointSince = Environment.TickCount;
                        }
                        else if (Environment.TickCount - StuckAtPointSince > 3000)
                        {
                            Col.Apply();
                            Col3.Apply();
                        }
                    }
                    break;

                case Enums.CtmType.None:
                case Enums.CtmType.Idle:
                    StuckAtPointSince = Environment.TickCount;
                    oldPosition = new XYZ(0, 0, 0);
                    Col.Remove();
                    Col3.Remove();
                    break;
            }
        }

        internal void CheckForStuck()
        {
            if (Calc.Distance2D(oldPosition, ObjectManager.Player.Position) < 0.2f)
            {
                oldPosition = ObjectManager.Player.Position;
                StuckAtPointSince = Environment.TickCount;
                TryUnstuck();
            }
        }

        internal void TryUnstuck()
        {
            Helpers.Logger.Append("Trying to unstuck ourself..");

            EngineManager.StopCurrentEngine();
            EngineManager.StartGrinder(true);
          /*  ObjectManager.Player.StopMovement(Enums.ControlBits.All);
            ObjectManager.Player.CtmStopMovement();
            ObjectManager.Player.CtmSetToIdle();

            var randomMethod = new Random().Next(1, 4);
            var randomRunTime = new Random().Next(2000, 3000);
            if (1 == randomMethod)
            {
                ObjectManager.Player.StartMovement(Enums.ControlBits.StrafeRight);                
            }
            if (2 == randomMethod)
            {
                ObjectManager.Player.StartMovement(Enums.ControlBits.StrafeLeft);       
            }
            if (3 == randomMethod)
            {
                ObjectManager.Player.StartMovement(Enums.ControlBits.StrafeLeft);
                ObjectManager.Player.StartMovement(Enums.ControlBits.Back);
            }
            if (4 == randomMethod)
            {
                ObjectManager.Player.StartMovement(Enums.ControlBits.StrafeRight);
                ObjectManager.Player.StartMovement(Enums.ControlBits.Back);
            }

            Shared.RandomJump();
            var tmpTickCount = Environment.TickCount + 2000;
            while(Environment.TickCount < tmpTickCount)
            {
                Shared.RandomJump();
            }

            ObjectManager.Player.StopMovement(Enums.ControlBits.All); */
        }

        internal void Reset()
        {
            StuckAtPointSince = 0;
            oldPosition = new XYZ(0, 0, 0);
            Col.Remove();
            Col3.Remove();
        }
    }
}