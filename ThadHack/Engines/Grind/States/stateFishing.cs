using System;
using System.Collections.Generic;
using System.Linq;
using ZzukBot.Constants;
using ZzukBot.Engines.CustomClass;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Objects;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateFishing : State
    {
        internal override bool NeedToRun => knownFishingRodEquipped() && !API.BMain.Me.IsDrinking && !API.BMain.Me.IsEating && !API.BMain.Me.IsDead;

        internal override string Name => "Fishing";
        
        private readonly Random rand = new Random();
        bool firstRound = true;
        ulong _oldBobberGuid;
        int maxFishingSkill;
        int currentFishingSkill;
        int previousFishingSkill;

        public StateFishing(int priority) : base(priority)
        {
        }

        internal override void Run()
        {
            UpdateFishingSkillKnowledge();

            #region Search For my Bobber and loot
            var bobber = ObjectManager.GameObjects.FirstOrDefault(x => x.OwnedBy == ObjectManager.Player.Guid && x.Guid != _oldBobberGuid);
            // No bobber? Fail.. Bobber got no fish? Waiting!
            if (bobber != null && bobber.IsBobbing)
            {
                // Got a fish on bobber? Loot it and add the guid of the bobber to the blacklist               
                if (Wait.For("BobberLootClick", rand.Next(400, 950)))
                {
                    bobber.Interact(true);
                    _oldBobberGuid = bobber.Guid;
                }                
            }
            #endregion

            #region apply fishing bait/lure
            Game.Static.Items.Bait bait = null;
            //iterate through the full list so we use the bait with the biggest +skill possible first
            foreach (Game.Static.Items.Bait tmpBait in Game.Static.Items.Fishing.BaitList)
            {
                //would we be able to use the lure?
                if (tmpBait.SkillRequirement <= currentFishingSkill)
                {
                    //search for it in our bag
                    if (ObjectManager.Player.Inventory.ItemCount(tmpBait.Name) > 0)
                    {
                        bait = tmpBait;
                    }
                }
            }

            //did we get a bait item in our bags and our main hand is not enchanted yet?
            if (bait != null && !ObjectManager.Player.Inventory.IsMainhandEnchanted)
            {
                Helpers.Logger.Append("Applying fishing bait " + bait.Name + " for a +" + bait.SkillEnhancement + " skill boost");

                if (Wait.For("ApplyingLureItem", rand.Next(5500, 6666)))
                {
                    ObjectManager.Player.Inventory.EnchantMainhandItem(bait.Name);
                }
            }
            #endregion

            #region Start Fishing
            string fishingSpellNameString = "Fishing";
            int fishingRank = ObjectManager.Player.Spells.GetSpellRank(fishingSpellNameString);
            if (fishingRank > 0 && currentFishingSkill > 0)
            {
                if (API.BMain.Me.IsDead || API.BMain.Me.IsEating || API.BMain.Me.IsDrinking || API.BMain.Me.Channeling > 0 || API.BMain.Me.Casting > 0) { return; }

                if (ObjectManager.Player.Spells.IsSpellReady(fishingSpellNameString) && Wait.For("WaitingForFishStart", rand.Next(800, 1599)))
                {
                    ObjectManager.Player.Spells.Cast(fishingSpellNameString, fishingRank);
                }
            }
            #endregion

            #region report Skill Progress
            if(currentFishingSkill > previousFishingSkill)
            {
                Helpers.Logger.Append("Fishing Skill increased from " + previousFishingSkill + " to "+ currentFishingSkill + "/ " + maxFishingSkill);
                previousFishingSkill = currentFishingSkill;
            }
            #endregion

            
            firstRound = false;
        }

        private void UpdateFishingSkillKnowledge()
        {
            var player = ObjectManager.Player;
            #region gathering fishing skill info
            //update the skills, just in case
            player.Skills = new Game.Static.Skills().GetAllPlayerSkills();
            foreach (var tmpPlayerSkill in ObjectManager.Player.Skills)
            {
                if (tmpPlayerSkill.Id == Enums.Skills.FISHING)
                {
                    if (firstRound)
                        previousFishingSkill = tmpPlayerSkill.CurrentLevel;

                    currentFishingSkill = tmpPlayerSkill.CurrentLevel;
                    maxFishingSkill = tmpPlayerSkill.MaxLevel;
                    break;
                }
            }
            #endregion
        }

        private bool knownFishingRodEquipped()
        {
            var tmpInventory = new Game.Static.Inventory();
            Objects.WoWItem tmpMainHandItem = tmpInventory.GetEquippedItem(Enums.EquipSlot.MainHand);

            if (tmpMainHandItem == null) { return false; }

            foreach (Game.Static.Items.FishingPole tmpFPole in Game.Static.Items.Fishing.FishingPoleList)
            {
                if (tmpFPole.Id == tmpMainHandItem.Id)
                {
                    if (firstRound)
                    {
                        UpdateFishingSkillKnowledge();
                        Helpers.Logger.Append(tmpMainHandItem.Name + " is equipped in main hand. Going fishing!");
                        Helpers.Logger.Append(tmpFPole.Name + " is giving us +" + tmpFPole.SkillEnhancement + " fishing skill");
                        Helpers.Logger.Append("We do have the Fishing spell and a current skill of " + currentFishingSkill + "/ " + maxFishingSkill);                        
                    }


                    return true;
                }
            }


            return false;
        }
    }
}
