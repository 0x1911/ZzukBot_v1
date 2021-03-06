﻿using System;
using System.Collections.Generic;
using System.Linq;
using ZzukBot.Constants;
using ZzukBot.Mem;
using ZzukBot.Objects;
using ZzukBot.Settings;

namespace ZzukBot.Game.Static
{
    internal class Inventory
    {
        private readonly List<ulong> VendorExclude = new List<ulong>();

        /// <summary>
        ///     Get free slots
        /// </summary>
        internal int FreeSlots => _FreeSlots(false);

        internal int FreeSlotsWithQuiver => _FreeSlots(true);

        private Tuple<int, int> VendorItem
        {
            get
            {
                // Iterate through base bag
                for (var i = 0; i < 16; i++)
                {
                    // get guid of the item stored in current slot (i = slot number)
                    ulong tmpSlotGuid = 0;
                    try
                    {
                        tmpSlotGuid = ObjectManager.Player.GetDescriptor<ulong>(0x850 + i*8);
                    }
                    catch
                    {
                    }
                    if (tmpSlotGuid != 0)
                    {
                        var tmp = ObjectManager.Items
                            .FirstOrDefault(x => x.Guid == tmpSlotGuid);

                        var itemName = Settings.Settings.ProtectedItems.FirstOrDefault(x => x.StartsWith("*") && tmp.Name.Contains(x.TrimStart('*')));

                        //don't sell protected items or food & drinks
                        if (string.IsNullOrEmpty(itemName) && !Settings.Settings.ProtectedItems.Contains(tmp.Name) && !Game.Static.Consumeables.DrinksDictionary.ContainsKey(tmp.Id) && !Game.Static.Consumeables.FoodsDictionary.ContainsKey(tmp.Id))
                        {
                            if (tmp.Quality < Settings.Settings.KeepItemsFromQuality)
                            {
                                if (!VendorExclude.Contains(tmp.Guid) || Game.Static.Consumeables.DrinksDictionary.ContainsKey(tmp.Id) || Game.Static.Consumeables.FoodsDictionary.ContainsKey(tmp.Id))
                                {
                                    VendorExclude.Add(tmp.Guid);
                                    return Tuple.Create(0, i + 1);
                                }
                            }
                        }
                    }
                }

                var tmpItems = new List<WoWItem>();
                var BagsFound = ObjectManager.Items
                    .Where(x => x.Slots != 0).ToList();
                for (var i = 0; i < 4; i++)
                {
                    // read bag guid (i = bag number starting right)
                    var bagGuid = (IntPtr.Add(new IntPtr(0xBDD060), i*8)).ReadAs<ulong>();
                    if (bagGuid == 0) continue;

                    var tmpBag = BagsFound.FirstOrDefault(x => bagGuid == x.Guid);
                    if (tmpBag == null) continue;
                    tmpItems.Add(tmpBag);
                }
                // Filter out our bags from the item list maintained
                // by the object manager


                var counter = 1;
                // iterate over the bag list
                foreach (var bag in tmpItems)
                {
                    // iterate over the current bag and count free slots
                    // i = current slot
                    for (var i = 1; i < bag.Slots + 1; i++)
                    {
                        ulong tmpSlotGuid = 0;
                        try
                        {
                            tmpSlotGuid = bag.GetDescriptor<ulong>(0xC0 + i*8);
                        }
                        catch
                        {
                        }
                        if (tmpSlotGuid != 0)
                        {
                            var tmp = ObjectManager.Items
                                .FirstOrDefault(x => x.Guid == tmpSlotGuid);
                            if (!Settings.Settings.ProtectedItems.Contains(tmp.Name))
                            {
                                if (tmp.Quality < Settings.Settings.KeepItemsFromQuality)
                                {
                                    if (!VendorExclude.Contains(tmp.Guid))
                                    {
                                        VendorExclude.Add(tmp.Guid);
                                        return Tuple.Create(counter, i);
                                    }
                                }
                            }
                        }
                    }
                    counter++;
                }
                return Tuple.Create(-1, -1);
            }
        }

        /// <summary>
        ///     Get durability of all equipped items in percentage
        /// </summary>
        internal int DurabilityPercentage
        {
            get
            {
                try
                {
                    // 0x798 = descriptor to the equipped head item
                    var offset = 0x798;
                var inventoryGuids = new List<ulong>();

                // We got 19 equipped items
                for (var i = 0; i < 19; i++)
                {
                    var guid = ObjectManager.Player.GetDescriptor<ulong>(offset + 0x8*i);
                    if (guid != 0)
                        inventoryGuids.Add(guid);
                }

                // calculate durability of equipped items in percentage
                var duraAll = 0;
                var duraMaxAll = 0;
                
                    var tmpItems = ObjectManager.Items.Where(i => inventoryGuids.Contains(i.Guid)).ToList();
                    foreach (var x in tmpItems)
                    {
                        var tmpDura = x.Durability;
                        var tmpDuraMax = x.MaxDurability;

                        duraAll += tmpDura;
                        duraMaxAll += tmpDuraMax;
                    }

                    if (duraMaxAll == 0) return 100;
                    return (int)(duraAll / (float)duraMaxAll * 100);
                }
                catch
                {
                    return 100;
                }
            }
        }

        /// <summary>
        ///     is mainhand enchanted
        /// </summary>
        internal bool IsMainhandEnchanted
        {
            get
            {
                try
                {
                    var encrypted = Strings.GT_IsMainhandEnchanted.GenLuaVarName();
                    Functions.DoString(Strings.IsMainhandEnchanted.Replace(Strings.GT_IsMainhandEnchanted, encrypted));
                    return Functions.GetText(encrypted) == "1";
                }
                catch
                {
                    return true;
                }
            }
        }

        /// <summary>
        ///     is offhand enchanted
        /// </summary>
        internal bool IsOffhandEnchanted
        {
            get
            {
                try
                {
                    string encrypted = Strings.GT_IsOffhandEnchanted.GenLuaVarName();
                    Functions.DoString(Strings.IsOffhandEnchanted.Replace(Strings.GT_IsOffhandEnchanted, encrypted));
                    return Functions.GetText(encrypted) == "1";
                }
                catch
                {
                    return true;
                }
            }
        }


        private int _FreeSlots(bool parCountQuiverSlots)
        {
            var freeSlots = 0;
            try
            {
                // Itera through base bag
                for (var i = 0; i < 16; i++)
                {
                    // get guid of the item stored in current slot (i = slot number)
                    var tmpSlotGuid = ObjectManager.Player.GetDescriptor<ulong>(0x850 + i*8);
                    // current slot empty? +1 free slot
                    if (tmpSlotGuid == 0) freeSlots++;
                }
                // List where we store guids of our equipped bags
                var BagGuids = new List<ulong>();
                for (var i = 0; i < 4; i++)
                {
                    // read bag guid (i = bag number starting right)
                    BagGuids.Add(IntPtr.Add(new IntPtr(0xBDD060), i*8).ReadAs<ulong>());
                }
                // Filter out our bags from the item list maintained
                // by the object manager
                var tmpItems = ObjectManager.Items
                    .Where(i => i.Slots != 0
                                && BagGuids.Contains(i.Guid)).ToList();

                // iterate over the bag list
                foreach (var bag in tmpItems)
                {
                    if ((!bag.Name.Contains("Quiver") && !bag.Name.Contains("Ammo") && !bag.Name.Contains("Shot"))
                        || parCountQuiverSlots)
                    {
                        // iterate over the current bag and count free slots
                        // i = current slot
                        for (var i = 1; i < bag.Slots + 1; i++)
                        {
                            var tmpSlotGuid = bag.GetDescriptor<ulong>(0xC0 + i*8);
                            if (tmpSlotGuid == 0) freeSlots++;
                        }
                    }
                }
                // return the total free slots
                return freeSlots;
            }
            catch
            {
                return 16;
            }
        }

        private bool GotItemInBag(ulong guid)
        {
            // Itera through base bag
            for (var i = 0; i < 16; i++)
            {
                // get guid of the item stored in current slot (i = slot number)
                var tmpSlotGuid = ObjectManager.Player.GetDescriptor<ulong>(0x850 + i * 8);
                // current slot empty? +1 free slot
                if (tmpSlotGuid == guid) return true;
            }
            // List where we store guids of our equipped bags
            var BagGuids = new List<ulong>();
            for (var i = 0; i < 4; i++)
            {
                // read bag guid (i = bag number starting right)
                BagGuids.Add(IntPtr.Add(new IntPtr(0xBDD060), i * 8).ReadAs<ulong>());
            }
            // Filter out our bags from the item list maintained
            // by the object manager
            var tmpItems = ObjectManager.Items
                .Where(i => i.Slots != 0
                            && BagGuids.Contains(i.Guid)).ToList();

            // iterate over the bag list
            foreach (var bag in tmpItems)
            {

                // iterate over the current bag and count free slots
                // i = current slot
                for (var i = 1; i < bag.Slots + 1; i++)
                {
                    var tmpSlotGuid = bag.GetDescriptor<ulong>(0xC0 + i*8);
                    if (tmpSlotGuid == guid) return true;
                }
            }
            return false;
        }

        internal bool VendorItems()
        {
            var slot = VendorItem;
            if (slot.Item1 != -1)
            {
                Functions.DoString(
                    "UseContainerItem(" + slot.Item1 + "," + slot.Item2 + ")"
                    );
                return true;
            }
            VendorExclude.Clear();
            return false;
        }

        /// <summary>
        ///     Get Item count
        /// </summary>
        internal int ItemCount(string ItemName)
        {
            try
            {
                // get all items which contain the item name provided by the function
                var tmpList = ObjectManager.Items.Where(i => i.Name == ItemName).ToList();
                if (tmpList.Count == 0)
                    return 0;
                var tmpCount = 0;
                // iterate over them and add the stack count to the total count
                try
                {
                    tmpCount += tmpList.Sum(item => item.StackCount);
                    return tmpCount;
                }
                catch (Exception) //Access Violation
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        // <summary>
        // Takes an array of items (Ordered least important to most)
        // Returns the name of the most important currently in the inventory
        // </summary>
        internal string GetLastItem(string[] parListOfNames)
        {
            try
            {
                for (var i = parListOfNames.Length - 1; i >= 0; i--)
                {
                    var tmpList = ObjectManager.Items.Where(a => a.Name == parListOfNames[i]).ToList();
                    if (tmpList.Count != 0)
                        return parListOfNames[i];
                }
            }
            catch (Exception)
            {
                //Access Violation
            }
            return "";
        }

        /// <summary>
        ///     enchant mainhand
        /// </summary>
        internal void EnchantMainhandItem(string itemName)
        {
            UseItemByName(itemName);
            Functions.DoString(Strings.EnchantMainhand);
        }

        /// <summary>
        ///     enchant offhand
        /// </summary>
        internal void EnchantOffhandItem(string itemName)
        {
            UseItemByName(itemName);
            Functions.DoString(Strings.EnchantOffhand);
        }

        /// <summary>
        ///     Use an item
        /// </summary>
        internal void UseItemByName(string Name)
        {
            try
            {
                var tmpItem =
                    ObjectManager.Items
                        .Where(i => string.Equals(i.Name, Name, StringComparison.OrdinalIgnoreCase)).ToList();
                WoWItem myItem = null;
                foreach (var item in tmpItem)
                {
                    if (item.StackCount <= 1)
                    {
                        if (!GotItemInBag(item.Guid)) continue;
                        myItem = item;
                        break;
                    }
                    else
                    {
                        myItem = item;
                        break;
                    }


                }
                if (myItem == null) return;
                var ptr = myItem.Pointer;
                //IntPtr ptr2 = tmpItem.UseItemPointer;
                ulong useOn = 0;
                Functions.UseItem(ptr, useOn); //ptr2);
            }
            catch
            {
            }
        }

        internal void UseItemByObject(WoWItem Item)
        {
            try
            {
                if (Item == null) return;
                //IntPtr ptr2 = tmpItem.UseItemPointer;
                ulong useOn = 0;
                Functions.UseItem(Item.Pointer, useOn); //ptr2);
            }
            catch
            {
            }
        }

        internal void RepairAll()
        {
            Functions.DoString(Strings.RepairAll);
        }

        /// <summary>
        ///     Get an item equipped at a specific equipment slot
        /// </summary>
        /// <param name="parSlot">The slot</param>
        /// <returns>null or the item represented as WoWItem</returns>
        internal WoWItem GetEquippedItem(Enums.EquipSlot parSlot)
        {
            var slot = (int)parSlot;
            var guid = ObjectManager.Player.ReadRelative<ulong>(0x2508 + (slot - 1) * 0x8);
            if (guid == 0) return null;
            return ObjectManager.Items.FirstOrDefault(i => i.Guid == guid);
        }
    }
}