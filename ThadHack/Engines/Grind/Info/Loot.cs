using System.Collections.Generic;
using System.Linq;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Objects;
using ZzukBot.Settings;

namespace ZzukBot.Engines.Grind.Info
{
    internal class _Loot
    {
        internal volatile bool BlacklistCurrentLoot;
        private List<ulong> LootBlacklist { get; }

        internal _Loot()
        {
            LootBlacklist = new List<ulong>();
        }
        
        internal WoWUnit LootableMob
        {
            get
            {
                var mobs = ObjectManager.Npcs;

                #region ninja skin
                if (Settings.Settings.NinjaSkin)
                {
                    return mobs
                    .Where(i => (i.IsSkinable
                                && !LootBlacklist.Contains(i.Guid)
                                && (Calc.Distance3D(i.Position, ObjectManager.Player.Position) < 32)))
                                .OrderBy(i => Calc.Distance3D(i.Position, ObjectManager.Player.Position))
                    .FirstOrDefault();
                }
                #endregion

                #region standard skin own units
                if(Settings.Settings.SkinUnits)
                {
                    return mobs
                    .Where(i => (i.IsSkinable
                                && (i.TappedByMe || !i.TappedByOther)
                                && !LootBlacklist.Contains(i.Guid)
                                && (Calc.Distance3D(i.Position, ObjectManager.Player.Position) < 32)))
                                .OrderBy(i => Calc.Distance3D(i.Position, ObjectManager.Player.Position))
                    .FirstOrDefault();
                }
                #endregion

                //just return the standard loot mobs
                return mobs
                    .Where(i => (i.CanBeLooted && i.TappedByMe)
                                && !LootBlacklist.Contains(i.Guid)
                                && Calc.Distance3D(i.Position, ObjectManager.Player.Position) < 32)
                    .OrderBy(i => Calc.Distance3D(i.Position, ObjectManager.Player.Position))
                    .FirstOrDefault();
            }
        }

        internal bool NeedToLoot
        {
            get
            {
                var tmp = LootableMob;
                if (tmp != null && BlacklistCurrentLoot)
                {
                    LootBlacklist.Add(tmp.Guid);
                    BlacklistCurrentLoot = false;
                    return false;
                }
                return ObjectManager.Player.Inventory.FreeSlots >= Settings.Settings.MinFreeSlotsBeforeVendor && tmp != null;
            }
        }

        internal void AddToLootBlacklist(ulong guid)
        {
            if (!LootBlacklist.Contains(guid))
                LootBlacklist.Add(guid);
        }

        internal void RemoveRespawnedMobsFromBlacklist(List<WoWUnit> parList)
        {
            parList.ForEach(i => LootBlacklist.Remove(i.Guid));
        }

        internal void RemoveRespawnedMobsFromBlacklist(ulong parGuid)
        {
            LootBlacklist.Remove(parGuid);
        }
    }
}