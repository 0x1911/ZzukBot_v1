using System;
using ZzukBot.Engines;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.API
{
    public static class BMain
    {
        public static LocalPlayer Me => ObjectManager.Player;

        public static long RuntimeTicks => ((DateTime.Now.Ticks - EngineManager.StartTick) / 1000);
    }
}
