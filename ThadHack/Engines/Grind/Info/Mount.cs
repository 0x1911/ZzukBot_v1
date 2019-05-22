using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.Info
{    
    internal class Mount
    {
        internal bool ShouldMount { get; set; }

        internal bool IsMounted => ObjectManager.Player.GotAura(Settings.Settings.MountName);

        private XYZ LastMountTryPosition = new XYZ(0, 0, 0);
        public bool CouldMount()
        {
            if (IsMounted || 
                API.BMain.Me.IsIndoors || 
                API.BMain.Me.Level < 40 || 
                Settings.Settings.MountName.Length <= 3 || 
                !API.BMain.IsInGame || 
                API.BMain.Me.IsDead || 
                API.BMain.Me.IsInCampfire || 
                API.BMain.Me.IsInCC || 
                API.BMain.Me.IsSwimming || 
                API.BMain.Me.IsConfused || 
                API.BMain.Me.IsInCombat || 
                API.BMain.Me.IsFleeing || 
                API.BMain.Me.IsEating || 
                API.BMain.Me.IsDrinking || 
                API.BMain.Me.IsLooting)
            {
                if (Calc.Distance3D(ObjectManager.Player.Position, LastMountTryPosition) > 10 && API.BMain.Me.IsIndoors)
                {
                    API.BMain.Me.IsIndoors = false;
                    LastMountTryPosition = API.BMain.Me.Position;
                }


                return false;
            }


            return true;
        }

        public bool MountUp()
        {
            if (!CouldMount()) { return false; }

            if (!IsMounted)
            {
                API.BMain.Me.StopMovement(Constants.Enums.ControlBits.All);
                API.BMain.Me.CtmStopMovement();
                API.BMain.Me.Inventory.UseItemByName(Settings.Settings.MountName);
            }

            return true;
        }
    }
}
