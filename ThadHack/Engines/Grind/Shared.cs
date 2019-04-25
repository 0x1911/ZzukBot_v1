using System;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind
{
    internal class Shared
    {
        private static readonly Random ran = new Random();

        internal static bool StartedMovement = false;

        private static readonly Random random = new Random();

        internal static bool IgnoreZAxis = false;

        internal static void RandomJump()
        {
            if (Wait.For("RandomJump1", 1000))
            {
                var ranNumber = ran.Next(1, 10);
                if(ranNumber == 5)
                {
                    Functions.DoString("Jump()");
                }
            }
        }

        internal static void ResetJumper()
        {
            Wait.Remove("RandomJump1");
        }

        internal static void ResetJumperComplete()
        {
            Wait.Remove("RandomJump2");
        }

        internal static void RandomResetJumper()
        {
            if (random.Next(1, 3) == 2)
                ResetJumper();
        }

        public static void RandomResetJumperComplete()
        {
            if (random.Next(1, 4) == 2)
            {
                ResetJumper();
                ResetJumperComplete();
            }
        }
    }
}