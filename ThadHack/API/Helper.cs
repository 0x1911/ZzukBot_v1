
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
                Mem.Functions.DoString("Jump()");
            }
        }
    }
}
