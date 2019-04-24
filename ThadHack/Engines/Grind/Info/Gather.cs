using ZzukBot.Mem;
using ZzukBot.Objects;
using System.Collections.Generic;

namespace ZzukBot.Engines.Grind.Info
{
    internal class _Gather
    {
        internal volatile bool BlacklistCurrentResource;
        private List<ulong> ResourceBlacklist { get; }

        internal _Gather()
        {
            ResourceBlacklist = new List<ulong>();
        }

        internal bool SearchGatherObjects()
        {
            if(ObjectManager.GameObjects == null) { return false; }
            var tmpPossibleGatherObjects = ObjectManager.GameObjects;
            var player = ObjectManager.Player;
            
            int tmpCount = 0;
            foreach (var tmpWoWObject in tmpPossibleGatherObjects)
            {
                if (tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism)
                {
                    Helpers.Logger.Append("herb found: " + tmpWoWObject.Guid + " " + tmpWoWObject.DistanceTo(player));
                    tmpCount++;
                }
                if (tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining)
                {
                    Helpers.Logger.Append("mineral found: " + tmpWoWObject.Guid + " " + tmpWoWObject.DistanceTo(player));
                    tmpCount++;
                }
            }

            if (tmpCount > 0) { return true; }
            

            return false;
        }

        internal WoWGameObject GetNearestResource()
        {
            if (ObjectManager.GameObjects == null) { return null; }
            var tmpPossibleGatherObjects = ObjectManager.GameObjects;
            var player = ObjectManager.Player;

            foreach (var tmpWoWObject in tmpPossibleGatherObjects)
            {
                if (tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism)
                {
                    return tmpWoWObject;
                }
            }


            return null;
        }

        internal void AddToGatherBlacklist(ulong guid)
        {
            if (!ResourceBlacklist.Contains(guid))
                ResourceBlacklist.Add(guid);
        }
    }
}
