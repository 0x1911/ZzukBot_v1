using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ZzukBot.Settings
{
    /// <summary>
    ///     Class to manage the options
    /// </summary>
    internal static class SettingsManager
    {
        /// <summary>
        ///     Holding the path to the xml file
        /// </summary>
        private static XDocument doc = new XDocument();

        private static string ProtectedItems => Paths.WorkingDirectory + "\\Settings\\ProtectedItems.ini";
        
        /// <summary>
        ///     Set the path to the xml file and the form
        /// </summary>
        internal static void LoadXmlSettings()
        {
            doc = XDocument.Load(Paths.SettingsFile);
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
            //get the list items from file
            foreach (var x in File.ReadAllLines(ProtectedItems))
            {
                var tmp = x.Trim();
                if (string.IsNullOrWhiteSpace(tmp)) continue;
                tmpItems.Add(tmp);
            }

            // ascending sort
            tmpItems.Sort((a, b) => a.CompareTo(b)); 

            //add to control
            foreach(var listEntry in tmpItems)
            {
                parTb.Text += listEntry + Environment.NewLine;
            }

            Settings.ProtectedItems = tmpItems.ToArray();
        }

        private static void LoadFromXml()
        {
            GetElement("AccountName",
                ref Settings.AccountName,
                GuiCore.SettingsForm.tbAccount);

            GetElement("StopOnRare",
                ref Settings.StopOnRare,
                GuiCore.SettingsForm.cbStopOnRare);

            GetElement("NotifyOnRare",
                ref Settings.NotifyOnRare,
                GuiCore.SettingsForm.cbNotifyRare);

            GetElement("PetFood",
                ref Settings.PetFood,
                GuiCore.SettingsForm.tbPetFood);


            GetElement("AccountPassword",
                ref Settings.AccountPassword,
                GuiCore.SettingsForm.tbPassword);

            GetElement("CharacterName",
                ref Settings.CharacterName,
                GuiCore.SettingsForm.txt_Character);

            GetElement("RestManaAt",
                ref Settings.RestManaAt,
                GuiCore.SettingsForm.nudDrinkAt);

            GetElement("Drink",
                ref Settings.Drink,
                GuiCore.SettingsForm.tbDrink);

            GetElement("RestHealthAt",
                ref Settings.RestHealthAt,
                GuiCore.SettingsForm.nudEatAt);

            GetElement("Food",
                ref Settings.Food,
                GuiCore.SettingsForm.tbFood);

            GetElement("MobSearchRange",
                ref Settings.MobSearchRange,
                GuiCore.SettingsForm.nudMobSearchRange);

            GetElement("MaxDiffToWp",
                ref Settings.MaxDiffToWp,
                GuiCore.SettingsForm.nudRoamFromWp);

            GetElement("CombatDistance",
                ref Settings.CombatDistance,
                GuiCore.SettingsForm.nudCombatRange);

            GetElement("MinFreeSlotsBeforeVendor",
                ref Settings.MinFreeSlotsBeforeVendor,
                GuiCore.SettingsForm.nudFreeSlots);

            GetElement("KeepItemsFromQuality",
                ref Settings.KeepItemsFromQuality,
                GuiCore.SettingsForm.cbKeepQuality);

            GetElement("WaypointModifier",
                ref Settings.WaypointModifier,
                GuiCore.SettingsForm.nudWaypointModifier);

            GetElement("BeepOnSay",
                ref Settings.BeepOnSay,
                GuiCore.SettingsForm.cbBeepSay);

            GetElement("BeepOnWhisper",
                ref Settings.BeepOnWhisper,
                GuiCore.SettingsForm.cbBeepWhisper);

            GetElement("BeepOnName",
                ref Settings.BeepOnName,
                GuiCore.SettingsForm.cbBeepName);

            GetElement("BreakFor",
                ref Settings.BreakFor,
                GuiCore.SettingsForm.nudBreakFor);

            GetElement("ForceBreakAfter",
                ref Settings.ForceBreakAfter,
                GuiCore.SettingsForm.nudForceBreakAfter);

            GetElement("UseIRC",
                ref Settings.UseIRC,
                GuiCore.SettingsForm.cbIRCConnect);

            GetElement("IRCBotNickname",
                ref Settings.IRCBotNickname,
                GuiCore.SettingsForm.tbIRCBotNickname);

            GetElement("IRCBotChannel",
                ref Settings.IRCBotChannel,
                GuiCore.SettingsForm.tbIRCBotChannel);

            GetElement("SkinUnits",
                ref Settings.SkinUnits,
                GuiCore.SettingsForm.cbSkinUnits);

            GetElement("NinjaSkin",
                ref Settings.NinjaSkin,
                GuiCore.SettingsForm.cbNinjaSkin);

            GetElement("LootUnits",
                ref Settings.LootUnits,
                GuiCore.SettingsForm.cbLootUnits);

            GetElement("Herb",
                ref Settings.Herb,
                GuiCore.SettingsForm.cbHerb);

            GetElement("Mine",
                ref Settings.Mine,
                GuiCore.SettingsForm.cbMine);

            GetElement("DoRandomJumps",
               ref Settings.DoRandomJumps,
               GuiCore.SettingsForm.cbRandomJumps);

            GetElement("MinimizeWorldRender",
               ref Settings.MinimizeWorldRender,
               GuiCore.SettingsForm.cbWorldRender);

            GetElement("WowExePath",
               ref Settings.WowExePath,
               GuiCore.SettingsForm.txt_WowPath);

            GetElement("ProfilesDirectory",
               ref Settings.ProfilesDirectory,
               GuiCore.SettingsForm.txt_ProfilesDirectory);

            GetElement("CCDirectory",
               ref Settings.CCDirectory,
               GuiCore.SettingsForm.txt_CCDirectory);

            GetElement("WowExePath",
               ref Settings.WowExePath,
               GuiCore.SettingsForm.txt_WowPath);

            GetElement("WowWindowX",
                ref Settings.WowWindowX,
                GuiCore.SettingsForm.txt_WowWindowX);

            GetElement("WowWindowY",
                ref Settings.WowWindowY,
                GuiCore.SettingsForm.txt_WowWindowY);

            GetElement("WowWindowWidth",
                ref Settings.WowWindowWidth,
                GuiCore.SettingsForm.txt_WowWindowWidth);

            GetElement("WowWindowHeight",
                ref Settings.WowWindowHeight,
                GuiCore.SettingsForm.txt_WowWindowHeigth);

            GetElement("BotWindowX",
                ref Settings.BotWindowX,
                GuiCore.SettingsForm.txt_BotWindowX);

            GetElement("BotWindowY",
                ref Settings.BotWindowY,
                GuiCore.SettingsForm.txt_BotWindowY);


            GetElement("MountName",
                ref Settings.MountName,
                GuiCore.SettingsForm.txt_MountName);
        }
        /// <summary>
        /// First run settings setup
        /// </summary>
        internal static void InitialSetupSettingsFile()
        {
            string tmpSettingsDirectory = "..\\Settings";
            if (!Directory.Exists(tmpSettingsDirectory))
            {
                Directory.CreateDirectory(tmpSettingsDirectory);
            }
            
            string tmpSettingsFilePath = GuiCore.SettingsFilePath;
            if (!File.Exists(tmpSettingsFilePath))
            {
                var tmpXmlDoc = new XmlDocument();
                XmlNode settingsNode = tmpXmlDoc.CreateElement("Settings");
                tmpXmlDoc.AppendChild(settingsNode);

                XmlNode pathNode = tmpXmlDoc.CreateElement("WowExePath");
                pathNode.InnerText = Settings.WowExePath;
                settingsNode.AppendChild(pathNode);

                tmpXmlDoc.Save(tmpSettingsFilePath);
            }
        }
        /// <summary>
        ///     Save all settings
        /// </summary>
        internal static void SaveSettings()
        {
            #region write all the settings to file
            SaveElement("AccountName", Settings.AccountName);
            SaveElement("AccountPassword", Settings.AccountPassword);
            SaveElement("CharacterName", Settings.CharacterName);
            SaveElement("RestManaAt", Settings.RestManaAt);
            SaveElement("Drink", Settings.Drink);
            SaveElement("RestHealthAt", Settings.RestHealthAt);
            SaveElement("Food", Settings.Food);
            SaveElement("MobSearchRange", Settings.MobSearchRange);
            SaveElement("MaxDiffToWp", Settings.MaxDiffToWp);
            SaveElement("CombatDistance", Settings.CombatDistance);
            SaveElement("MinFreeSlotsBeforeVendor", Settings.MinFreeSlotsBeforeVendor);
            SaveElement("KeepItemsFromQuality", Settings.KeepItemsFromQuality);
            SaveElement("WaypointModifier", Settings.WaypointModifier);
            SaveElement("PetFood", Settings.PetFood);

            SaveElement("BeepOnName", Settings.BeepOnName);
            SaveElement("BeepOnSay", Settings.BeepOnSay);
            SaveElement("BeepOnWhisper", Settings.BeepOnWhisper);

            SaveElement("StopOnRare", Settings.StopOnRare);
            SaveElement("NotifyOnRare", Settings.NotifyOnRare);

            SaveElement("ForceBreakAfter", Settings.ForceBreakAfter);
            SaveElement("BreakFor", Settings.BreakFor);

            SaveElement("UseIRC", Settings.UseIRC);
            SaveElement("IRCBotNickname", Settings.IRCBotNickname);
            SaveElement("IRCBotChannel", Settings.IRCBotChannel);

            SaveElement("LootUnits", Settings.LootUnits);
            SaveElement("SkinUnits", Settings.SkinUnits);
            SaveElement("NinjaSkin", Settings.NinjaSkin);
            SaveElement("Herb", Settings.Herb);
            SaveElement("Mine", Settings.Mine);

            SaveElement("DoRandomJumps", Settings.DoRandomJumps);
            SaveElement("MinimizeWorldRender", Settings.MinimizeWorldRender);

            //SaveElement("CapFps", Options.CapFpsTo);


            SaveElement("WowExePath", Settings.WowExePath);
            SaveElement("ProfilesDirectory", Settings.ProfilesDirectory);
            SaveElement("CCDirectory", Settings.CCDirectory);

            SaveElement("WowWindowX", Settings.WowWindowX);
            SaveElement("WowWindowY", Settings.WowWindowY);

            SaveElement("WowWindowWidth", Settings.WowWindowWidth);
            SaveElement("WowWindowHeight", Settings.WowWindowHeight);

            SaveElement("BotWindowX", Settings.BotWindowX);
            SaveElement("BotWindowY", Settings.BotWindowY);

            SaveElement("MountName", Settings.MountName);
            #endregion

            //update our primitive sell protected items list
            UpdateProtectedItems();
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
            doc.Save(Paths.SettingsFile);
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
                doc.Save(Paths.SettingsFile);
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
            foreach (string t in Settings.ProtectedItems)
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