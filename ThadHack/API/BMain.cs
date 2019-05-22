using System;
using ZzukBot.Engines;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.API
{
    public static class BMain
    {
        public static LocalPlayer Me => ObjectManager.Player;

        public static string RunTimeSpan()
        {
            TimeSpan time = TimeSpan.FromTicks(DateTime.Now.Ticks - EngineManager.StartTick);

            //here backslash is must to tell that colon is
            //not the part of format, it just a character that we want in output
            string str = time.ToString(@"hh\:mm\:ss\:fff");

            return str;
        }

        public static bool IsInGame => API.BPreWorld.CurrentWindowName == "WorldFrame";

        public static bool IsOnCharSelect => API.BPreWorld.CurrentWindowName == "CharacterSelectUI";
    }
}
