﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using ZzukBot.Forms;

namespace ZzukBot.Settings
{
    /// <summary>
    ///     Class to manage the options
    /// </summary>
    internal static class OptionManager
    {
        /// <summary>
        ///     Holding the path to the xml file
        /// </summary>
        private static XDocument doc;

        private static string ProtectedItems => Paths.Root + "\\Settings\\ProtectedItems.ini";

        internal static bool SaveZzukPassword
        {
            get
            {
                var element = doc.Element("Settings");
                var tmp = element.Element("ZzukSavePassword");
                if (tmp == null)
                {
                    element.Add(new XElement("ZzukSavePassword", false));
                }

                doc.Save(Paths.Settings);
                return (bool) element.Element("ZzukSavePassword");
            }
        }

        /// <summary>
        ///     Set the path to the xml file and the form
        /// </summary>
        internal static void LoadXmlSettings()
        {
            doc = XDocument.Load(Paths.Settings);
        }

        /// <summary>
        ///     load all settings
        /// </summary>
        internal static void LoadSettings()
        {
            LoadFromXml();
            AppendProtectedItemsFromFile(GuiCore.SettingsForm.tbProtectedItems);
        }

        private static void AppendProtectedItemsFromFile(TextBox parTb)
        {
            if (!File.Exists(ProtectedItems))
                File.Create(ProtectedItems).Close();

            var tmpItems = new List<string>();
            parTb.Clear();
            foreach (var x in File.ReadAllLines(ProtectedItems))
            {
                var tmp = x.Trim();
                if (string.IsNullOrWhiteSpace(tmp)) continue;
                tmpItems.Add(tmp);
                parTb.Text += tmp + Environment.NewLine;
            }
            Options.ProtectedItems = tmpItems.ToArray();
        }

        private static void LoadFromXml()
        {
            GetElement("AccountName",
                ref Options.AccountName,
                GuiCore.SettingsForm.tbAccount);

            GetElement("StopOnRare",
                ref Options.StopOnRare,
                GuiCore.SettingsForm.cbStopOnRare);

            GetElement("NotifyOnRare",
                ref Options.NotifyOnRare,
                GuiCore.SettingsForm.cbNotifyRare);

            GetElement("PetFood",
                ref Options.PetFood,
                GuiCore.SettingsForm.tbPetFood);


            GetElement("AccountPassword",
                ref Options.AccountPassword,
                GuiCore.SettingsForm.tbPassword);

            GetElement("CharacterName",
                ref Options.CharacterName,
                GuiCore.SettingsForm.txt_Character);

            GetElement("RestManaAt",
                ref Options.RestManaAt,
                GuiCore.SettingsForm.nudDrinkAt);

            GetElement("Drink",
                ref Options.Drink,
                GuiCore.SettingsForm.tbDrink);

            GetElement("RestHealthAt",
                ref Options.RestHealthAt,
                GuiCore.SettingsForm.nudEatAt);

            GetElement("Food",
                ref Options.Food,
                GuiCore.SettingsForm.tbFood);

            GetElement("MobSearchRange",
                ref Options.MobSearchRange,
                GuiCore.SettingsForm.nudMobSearchRange);

            GetElement("MaxDiffToWp",
                ref Options.MaxDiffToWp,
                GuiCore.SettingsForm.nudRoamFromWp);

            GetElement("CombatDistance",
                ref Options.CombatDistance,
                GuiCore.SettingsForm.nudCombatRange);

            GetElement("MinFreeSlotsBeforeVendor",
                ref Options.MinFreeSlotsBeforeVendor,
                GuiCore.SettingsForm.nudFreeSlots);

            GetElement("KeepItemsFromQuality",
                ref Options.KeepItemsFromQuality,
                GuiCore.SettingsForm.cbKeepQuality);

            GetElement("WaypointModifier",
                ref Options.WaypointModifier,
                GuiCore.SettingsForm.nudWaypointModifier);

            GetElement("BeepOnSay",
                ref Options.BeepOnSay,
                GuiCore.SettingsForm.cbBeepSay);

            GetElement("BeepOnWhisper",
                ref Options.BeepOnWhisper,
                GuiCore.SettingsForm.cbBeepWhisper);

            GetElement("BeepOnName",
                ref Options.BeepOnName,
                GuiCore.SettingsForm.cbBeepName);

            GetElement("BreakFor",
                ref Options.BreakFor,
                GuiCore.SettingsForm.nudBreakFor);

            GetElement("ForceBreakAfter",
                ref Options.ForceBreakAfter,
                GuiCore.SettingsForm.nudForceBreakAfter);

            GetElement("UseIRC",
                ref Options.UseIRC,
                GuiCore.SettingsForm.cbIRCConnect);

            GetElement("IRCBotNickname",
                ref Options.IRCBotNickname,
                GuiCore.SettingsForm.tbIRCBotNickname);

            GetElement("IRCBotChannel",
                ref Options.IRCBotChannel,
                GuiCore.SettingsForm.tbIRCBotChannel);

            GetElement("SkinUnits",
                ref Options.SkinUnits,
                GuiCore.SettingsForm.cbSkinUnits);

            GetElement("NinjaSkin",
                ref Options.NinjaSkin,
                GuiCore.SettingsForm.cbNinjaSkin);

            GetElement("LootUnits",
                ref Options.LootUnits,
                GuiCore.SettingsForm.cbLootUnits);

            GetElement("Herb",
                ref Options.Herb,
                GuiCore.SettingsForm.cbHerb);

            GetElement("Mine",
                ref Options.Mine,
                GuiCore.SettingsForm.cbMine);

            //GetProtectedItems(ref Options.ProtectedItems, Main.MainForm.tbProtectedItems);
        }

        /// <summary>
        ///     Save all settings
        /// </summary>
        internal static void SaveSettings()
        {
            SaveElement("AccountName", Options.AccountName);
            SaveElement("AccountPassword", Options.AccountPassword);
            SaveElement("CharacterName", Options.CharacterName);
            SaveElement("RestManaAt", Options.RestManaAt);
            SaveElement("Drink", Options.Drink);
            SaveElement("RestHealthAt", Options.RestHealthAt);
            SaveElement("Food", Options.Food);
            SaveElement("MobSearchRange", Options.MobSearchRange);
            SaveElement("MaxDiffToWp", Options.MaxDiffToWp);
            SaveElement("CombatDistance", Options.CombatDistance);
            SaveElement("MinFreeSlotsBeforeVendor", Options.MinFreeSlotsBeforeVendor);
            SaveElement("KeepItemsFromQuality", Options.KeepItemsFromQuality);
            SaveElement("WaypointModifier", Options.WaypointModifier);
            SaveElement("PetFood", Options.PetFood);

            SaveElement("BeepOnName", Options.BeepOnName);
            SaveElement("BeepOnSay", Options.BeepOnSay);
            SaveElement("BeepOnWhisper", Options.BeepOnWhisper);

            SaveElement("StopOnRare", Options.StopOnRare);
            SaveElement("NotifyOnRare", Options.NotifyOnRare);

            SaveElement("ForceBreakAfter", Options.ForceBreakAfter);
            SaveElement("BreakFor", Options.BreakFor);

            SaveElement("UseIRC", Options.UseIRC);
            SaveElement("IRCBotNickname", Options.IRCBotNickname);
            SaveElement("IRCBotChannel", Options.IRCBotChannel);

            SaveElement("LootUnits", Options.LootUnits);
            SaveElement("SkinUnits", Options.SkinUnits);
            SaveElement("NinjaSkin", Options.NinjaSkin);
            SaveElement("Herb", Options.Herb);
            SaveElement("Mine", Options.Mine);

            SaveElement("CapFps", Options.CapFpsTo);


            UpdateProtectedItems();
        }

        internal static string LoadZzukLogin()
        {
            return GetEmail() + ";" + GetEmailPassword();
        }

        internal static void SaveZzukLogin(string parEmail, string parPass, bool parSavePw)
        {
            SaveElement("ZzukAccountEmail", parEmail);
            SaveElement("ZzukAccountPassword", parSavePw ? parPass : "");
            SaveElement("ZzukSavePassword", parSavePw);
        }

        private static string GetEmail()
        {
            var element = doc.Element("Settings");
            var tmp = element.Element("ZzukAccountEmail");
            if (tmp == null)
            {
                element.Add(new XElement("ZzukAccountEmail", Options.ZzukAccountMail));
            }

            doc.Save(Paths.Settings);
            return (string) element.Element("ZzukAccountEmail");
        }

        private static string GetEmailPassword()
        {
            var element = doc.Element("Settings");
            var tmp = element.Element("ZzukAccountPassword");
            if (tmp == null)
            {
                element.Add(new XElement("ZzukAccountPassword", Options.ZzukAccountPassword));
            }

            doc.Save(Paths.Settings);
            return (string) element.Element("ZzukAccountPassword");
        }

        /// <summary>
        ///     Get Element with Name, value will be stored in value parameter
        ///     if element doesnt exist create it with value parameter as value
        /// </summary>
        private static void GetElement<T, X>(string Name, ref T Value, X control)
        {
            var element = doc.Element("Settings");
            var tmp = element.Element(Name);
            if (tmp == null)
            {
                element.Add(new XElement(Name, Value));
            }
            Value = (T) Convert.ChangeType(element.Element(Name).Value, typeof (T));

            object o = control;
            var x = (Control) o;
            GuiCore.MainForm.UpdateControl(Value, x);
            doc.Save(Paths.Settings);
        }

        /// <summary>
        ///     Save the element with the value
        ///     Only works if the element exists
        /// </summary>
        private static void SaveElement<T>(string Name, T Value)
        {
            try
            {
                var element = doc.Element("Settings").Element(Name);
                element.Value = Value.ToString();
                doc.Save(Paths.Settings);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        ///     Get all protected items
        /// </summary>
        /// <summary>
        ///     Enums for WoW, no commenting needed
        /// </summary>
        private static void UpdateProtectedItems()
        {
            File.Create(ProtectedItems).Close();
            var tmpText = "";
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (string t in Options.ProtectedItems)
            {
                var tmp = t.Trim();
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    tmpText += tmp + Environment.NewLine;
                }
            }
            File.WriteAllText(ProtectedItems, tmpText);
        }
    }
}