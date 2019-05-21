namespace ZzukBot.Settings
{
    /// <summary>
    ///     The class containing settings the user made
    /// </summary>
    internal static class Settings
    {
        internal static string AccountName = "";
        internal static string AccountPassword = "";
        internal static string CharacterName = string.Empty;
        internal static int RestManaAt = 40;
        internal static string Drink = "";
        internal static int RestHealthAt = 40;
        internal static string Food = "";
        internal static string PetFood = "";
        internal static float MobSearchRange = 20;
        internal static float MaxDiffToWp = 100;
        internal static float CombatDistance = 4;
        internal static int MinFreeSlotsBeforeVendor = 3;
        internal static int KeepItemsFromQuality = 2;
        internal static string[] ProtectedItems = {};
        internal static decimal WaypointModifier = 0;

        internal static string LastProfileFileName = "";

        //internal static int CapFpsTo = 60;

        internal static bool StopOnRare = false;
        internal static bool NotifyOnRare = false;

        internal static int ForceBreakAfter = 0;
        internal static int BreakFor = 0;

        internal static string RealmList = "";

        internal static bool BeepOnWhisper = false;
        internal static bool BeepOnSay = false;
        internal static bool BeepOnName = false;

        internal static bool UseIRC = false;
        internal static string IRCBotNickname = "";
        internal static string IRCBotChannel = "";

        internal static bool SkinUnits = false;
        internal static bool NinjaSkin = false;
        internal static bool LootUnits = true;
        internal static bool Herb = false;
        internal static bool Mine = false;

        internal static string WowExePath = string.Empty;
        internal static string ProfilesDirectory = string.Empty;
        internal static string CCDirectory = string.Empty;

        internal static string WowWindowX = "0";
        internal static string WowWindowY = "0";
        internal static string WowWindowWidth = "0";
        internal static string WowWindowHeight = "0";
        internal static string BotWindowX = "0";
        internal static string BotWindowY = "0";

        internal static bool DoRandomJumps = false;
        internal static bool MinimizeWorldRender = false;
    }
}