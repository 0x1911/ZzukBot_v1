
namespace ZzukBot.API
{
    public static class Helper
    {
        /// <summary>
        /// Move out of campfires to avoid periodic damage via a, hopefully, classy jump
        /// </summary>
        public static void MoveOutOfCampfire()
        {
            var tmpPlayer = Mem.ObjectManager.Player;

            if (tmpPlayer.IsInCampfire)
            {
                tmpPlayer.StartMovement(Constants.Enums.ControlBits.StrafeLeft);
                Mem.Functions.DoString("Jump()");
                tmpPlayer.StopMovement(Constants.Enums.ControlBits.StrafeLeft);
            }
        }

        /// <summary>
        /// if we are swimming make sure we stay above the water line so we don't drown
        /// </summary>
        public static void StayOnWaterTop()
        {
            if (Mem.ObjectManager.Player.IsSwimming)
            {
                Mem.ObjectManager.Player.StartMovement(Constants.Enums.ControlBits.Front);
                Mem.Functions.DoString("Jump()");
            }
        }

        /// <summary>
        /// Fix facing towards our current target
        /// </summary>
        public static void FixFacing(Objects.WoWUnit target)
        {
            if (Mem.ObjectManager.Player.IsFacing(target.Position))
            {
                if (!Mem.ObjectManager.Player.IsCtmIdle)
                {
                    Mem.ObjectManager.Player.CtmStopMovement();
                }
                else
                {
                    if (Mem.ObjectManager.Player.MovementState != 0x2)
                        Mem.ObjectManager.Player.StartMovement(Constants.Enums.ControlBits.Back);
                }
            }
            else
            {
                Engines.Grind.Grinder.Access.Info.Target.FixFacing = false;
                Mem.ObjectManager.Player.StopMovement(Constants.Enums.ControlBits.Back);
            }
            if (Helpers.Wait.For("FixFacingTimer", 1000))
            {
                Engines.Grind.Grinder.Access.Info.Target.FixFacing = false;
                Mem.ObjectManager.Player.StopMovement(Constants.Enums.ControlBits.Back);
            }
        }
    }
}
