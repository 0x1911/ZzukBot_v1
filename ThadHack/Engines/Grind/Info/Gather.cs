using ZzukBot.Mem;
using ZzukBot.Objects;
using System.Collections.Generic;
using ZzukBot.Constants;

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
                if (tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism && HasSkill(Enums.Skills.HERBALISM)) // || tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining && HasSkill(Enums.Skills.MINING))//|| tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining)
                {
                    if(!Grinder.Access.Info.Gather.ResourceBlacklist.Contains(tmpWoWObject.Guid))
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

            foreach (var tmpWoWObject in tmpPossibleGatherObjects)
            {
                if (tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Herbalism ) // && HasEnoughSkill(Enums.Skills.HERBALISM, tmpWoWObject) || tmpWoWObject.GatherInfo.Type == Constants.Enums.GatherType.Mining && HasEnoughSkill(Enums.Skills.MINING, tmpWoWObject))
                {
                    return tmpWoWObject;
                }
            }



            return null;
        }

        /// <summary>
        /// Check if we have the required Skill
        /// </summary>
        /// <param name="skillType"></param>
        /// <returns></returns>
        private bool HasSkill(Enums.Skills skillType)
        {
            /* var player = ObjectManager.Player;

             foreach (var tmpPlayerSkill in player.Skills)
             {
                 Enums.Skills tmpSkill = tmpPlayerSkill.Id;
                 Helpers.Logger.Append("My skill in " + tmpSkill.ToString() + " is " + tmpPlayerSkill.CurrentLevel + "/ " + tmpPlayerSkill.MaxLevel);

                 if (tmpPlayerSkill.Id == skillType)
                 {
                     if (tmpPlayerSkill.CurrentLevel >= 1)
                     {
                         return true;
                     }


                     return false;
                 }
             }

             return false; */
            return true;
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

            foreach (var tmpPlayerSkill in player.Skills)
            {
                if (tmpPlayerSkill.Id == skillType)
                {
                    if(tmpPlayerSkill.CurrentLevel >= targetObject.GatherInfo.RequiredSkill)
                    {
                        Enums.Skills tmpSkill = tmpPlayerSkill.Id;
                        Helpers.Logger.Append("Our skill in " + tmpSkill.ToString() + " is " + tmpPlayerSkill.CurrentLevel + "/ " + tmpPlayerSkill.MaxLevel + ". The resource needs: " + targetObject.GatherInfo.RequiredSkill);
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
                ResourceBlacklist.Add(guid);
        }
    }
}
