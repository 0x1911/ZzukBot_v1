using ZzukBot.Engines.CustomClass;
using ZzukBot.FSM;
using ZzukBot.Mem;

namespace ZzukBot.Engines.Grind.States
{
    internal class StateRest : State
    {
        internal override int Priority => 45;

        internal override bool NeedToRun => (Grinder.Access.Info.Rest.NeedToDrink || Grinder.Access.Info.Rest.NeedToEat) &&
                                            !ObjectManager.Player.IsInCampfire && !ObjectManager.Player.IsSwimming;

        internal override string Name => "Resting";

        private void ClearTarget()
        {
            var guid = ObjectManager.Player.Guid;
            var tarGuid = ObjectManager.Player.TargetGuid;
            if (tarGuid != 0
                &&
                tarGuid != guid && ObjectManager.Player.HasPet && tarGuid != ObjectManager.Player.Pet.Guid)
            {
                ObjectManager.Player.SetTarget(guid);
            }
        }

        internal override void Run()
        {
            ObjectManager.Player.CtmStopMovement();
            ClearTarget();
            CCManager.Rest();
            Shared.ResetJumper();

            //don't just stand around like a bot.. At least sit down while resting!
            ObjectManager.Player.DoString("DoEmote('sit');");

            string FoodAuraString = "Food";
            string DrinkAuraString = "Drink";
            if (!ObjectManager.Player.GotAura(FoodAuraString) && !ObjectManager.Player.GotAura(DrinkAuraString))
            {
                //lets check if we can find something to eat in the bags   
                var tmpPlayer = ObjectManager.Player;

                #region health regen
                if (!tmpPlayer.GotAura(FoodAuraString) && Grinder.Access.Info.Rest.NeedToEat)
                {
                    foreach (Objects.WoWItem tmpItem in ObjectManager.Items)
                    {
                        if (Game.Static.Consumeables.FoodsDictionary.ContainsKey(tmpItem.Id))
                        {
                            int tmpFoodLevel;
                            Game.Static.Consumeables.FoodsDictionary.TryGetValue(tmpItem.Id, out tmpFoodLevel);
                            if (tmpPlayer.Level >= tmpFoodLevel)
                            {
                                tmpPlayer.Inventory.UseItemByObject(tmpItem);
                                Helpers.Logger.Append("Eating " + tmpItem.Name);
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region mana regen
                if (!tmpPlayer.GotAura(DrinkAuraString) && Grinder.Access.Info.Rest.NeedToDrink)
                {
                    foreach (Objects.WoWItem tmpItem in ObjectManager.Items)
                    {
                        if (Game.Static.Consumeables.DrinksDictionary.ContainsKey(tmpItem.Id))
                        {
                            int tmpDrinkLevel;
                            Game.Static.Consumeables.DrinksDictionary.TryGetValue(tmpItem.Id, out tmpDrinkLevel);

                            if (tmpPlayer.Level >= tmpDrinkLevel)
                            {
                                tmpPlayer.Inventory.UseItemByObject(tmpItem);
                                Helpers.Logger.Append("Drinking " + tmpItem.Name);
                                break;
                            }
                        }
                    }
                }
                #endregion
            }

        }
    }
}