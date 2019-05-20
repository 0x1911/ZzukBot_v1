using ZzukBot.Mem;
using ZzukBot.Objects;
using System.Collections.Generic;
using ZzukBot.Constants;
using ZzukBot.Helpers;
using System.Linq;

namespace ZzukBot.Engines.Grind.Info
{
    internal class _Gather
    {
        private List<ulong> ResourceBlacklist { get; }

        internal _Gather()
        {
            ResourceBlacklist = new List<ulong>();
        }

        internal bool GatherObjectInRange()
        {
            //do we even want to gather?
            if(!Settings.Settings.Mine && !Settings.Settings.Herb) { return false; }
            //any possible objects to gather?
            if (ObjectManager.GameObjects == null) { return false; }

            var tmpPossibleGatherObjects = ObjectManager.GameObjects;
            var player = ObjectManager.Player;

            int tmpCount = 0;
            foreach (var tmpWoWObject in tmpPossibleGatherObjects)
            {
                if (Settings.Settings.Herb && tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism && HasEnoughSkill(Enums.Skills.HERBALISM, tmpWoWObject) ||
                    Settings.Settings.Mine && tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining && HasEnoughSkill(Enums.Skills.MINING, tmpWoWObject))
                {
                    if(!IsOnGatherBlacklist(tmpWoWObject.Guid))
                        return true;
                }
            }
            

            return false;
        }

        internal WoWGameObject GetNearestResource()
        {
            if (ObjectManager.GameObjects == null) { return null; }
            var tmpPossibleGatherObjects = ObjectManager.GameObjects;
            var player = ObjectManager.Player;

            Dictionary<WoWGameObject, float> tmpResources = new Dictionary<WoWGameObject, float>();
 
            foreach (var tmpWoWObject in tmpPossibleGatherObjects)
            {
                if (Settings.Settings.Herb && tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism && HasEnoughSkill(Enums.Skills.HERBALISM, tmpWoWObject) ||
                    Settings.Settings.Mine && tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining && HasEnoughSkill(Enums.Skills.MINING, tmpWoWObject))
                {
                    tmpResources.Add(tmpWoWObject, Calc.Distance3D(tmpWoWObject.Position, ObjectManager.Player.Position));
                }
            }
            
            var items = from pair in tmpResources
                        orderby pair.Value ascending
                        select pair;

           
            foreach (KeyValuePair<WoWGameObject, float> pair in items)
            {
                if(!IsOnGatherBlacklist(pair.Key.Guid))
                    return pair.Key;
            }


            return null;
        }
        
        /// <summary>
        /// Check if we have a high enough skill to gather the resource in question
        /// </summary>
        /// <param name="skillType"></param>
        /// <param name="targetObject"></param>
        /// <returns></returns>
        private bool HasEnoughSkill(Enums.Skills skillType, WoWGameObject targetObject)
        {
            var player = ObjectManager.Player;
            //update the skills, just in case
            player.Skills = new Game.Static.Skills().GetAllPlayerSkills();

            foreach (var tmpPlayerSkill in player.Skills)
            {
                if (tmpPlayerSkill.Id == skillType)
                {
                    if (tmpPlayerSkill.CurrentLevel >= targetObject.GatherInfo.RequiredSkill)
                    {
                        return true;
                    }


                    return false;
                }
            }


            return false;
        }

        internal void AddToGatherBlacklist(ulong guid)
        {
            if (!ResourceBlacklist.Contains(guid))
            {
                ResourceBlacklist.Add(guid);
            }               
        }

        internal bool IsOnGatherBlacklist(ulong guid)
        {
            if (ResourceBlacklist.Contains(guid)) { return true; }

            return false;
        }
    }
}
