using ZzukBot.Engines.Grind.Info;
using ZzukBot.Engines.Grind.Info.Path;

namespace ZzukBot.Engines.Grind
{
    internal class SessionContainer
    {
        internal int Latency = 0;

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        internal SessionContainer()
        {
            Waypoints = new _Waypoints();
            Rest = new _Rest();
            Target = new _Target();
            Combat = new _Combat();
            Loot = new _Loot();
            Gather = new _Gather();
            Vendor = new _Vendor();
            PathAfterFightToWaypoint = new _PathAfterFightToWaypoint();
            PathToPosition = new _PathToPosition();
            PathToUnit = new _PathToUnit();
            PathToObject = new _PathToObject();
            PathSafeGhostwalk = new _PathSafeGhostwalk();
            PathBackup = new _PathBackup();
            PathForceBackup = new _PathForceBackup();
            PathManager = new _PathManager();
            SpiritWalk = new _SpiritWalk();
            RareSpotter = new _RareSpotter();
            BreakHelper = new _BreakHelper();
            Mount = new Mount();
        }

        #endregion

        internal _BreakHelper BreakHelper { get; set; }
        internal _RareSpotter RareSpotter { get; set; }
        internal _SpiritWalk SpiritWalk { get; set; }
        internal _Waypoints Waypoints { get; set; }
        internal _Rest Rest { get; set; }
        internal _Target Target { get; set; }
        internal _Combat Combat { get; set; }
        internal _Loot Loot { get; set; }
        internal _Gather Gather { get; set; }
        internal _Vendor Vendor { get; set; }

        internal _PathAfterFightToWaypoint PathAfterFightToWaypoint { get; set; }
        internal _PathToPosition PathToPosition { get; set; }
        internal _PathToUnit PathToUnit { get; set; }
        internal _PathToObject PathToObject { get; set; }
        internal _PathSafeGhostwalk PathSafeGhostwalk { get; set; }
        internal _PathBackup PathBackup { get; set; }
        internal _PathForceBackup PathForceBackup { get; set; }
        internal _PathManager PathManager { get; set; }
        internal Mount Mount { get; set; }
    }
}