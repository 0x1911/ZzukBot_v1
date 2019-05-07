using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ZzukBot.Constants;
using ZzukBot.Forms;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Settings;

namespace ZzukBot.Engines.ProfileCreation
{
    internal class ProfileCreator
    {
        Forms.GraphicalProfileCreationForm usedProfileForm;

        private volatile bool boolAddFaction;
        private volatile bool boolAddGhostWaypoint;
        private volatile bool boolAddRepair;
        private volatile bool boolAddRestock;
        private volatile bool boolAddVendor;
        private volatile bool boolAddVendorWaypoint;
        // bools to check if user wants to add something to the profile
        private volatile bool boolAddWaypoint;
        private bool boolIgnoreZAxis => usedProfileForm.cbIgnoreZ.Checked;

        // Are we running the profile creation?
        internal volatile bool IsCreatingProfile = false;
        // list of factions
        private readonly List<int> listFactions = new List<int>();

        private readonly List<Tuple<XYZ, string, Enums.PositionType>> listGhostHotspots =
            new List<Tuple<XYZ, string, Enums.PositionType>>();

        private readonly List<Tuple<XYZ, string, Enums.PositionType>> listHotspots =
            new List<Tuple<XYZ, string, Enums.PositionType>>();

        // List of items to restock
        private readonly List<RestockItem> listRestockItems = new List<RestockItem>();

        private readonly List<Tuple<XYZ, string, Enums.PositionType>> listVendorHotspots =
            new List<Tuple<XYZ, string, Enums.PositionType>>();

        // Profile start
        private string profileStart = "";
        // Repair infos
        private NPC RepairNpc;
        // Restock infos
        private NPC RestockNpc;
        // Vendor infos (coords, name)
        private NPC VendorNpc;

        internal ProfileCreator(Forms.GraphicalProfileCreationForm newProfileForm)
        {
            usedProfileForm = newProfileForm;
            if (DirectX.RunInEndScene(CreateProfile))
            {
                usedProfileForm.lRecording.Text = "Recording";
                usedProfileForm.Text = "Recording new Profile";
                usedProfileForm.lRecording.Visible = true;
            }
        }


        internal bool Dispose()
        {
            var finalRes = true;
            var res = MessageBox.Show("Write profile to disk?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if(WriteToXmlProfile())
                    StopIt();
            }
            else
            {
                StopIt();
            }
            
            return finalRes;
        }

        private void StopIt()
        {
            usedProfileForm.tbHotspots.Text = "";
            usedProfileForm.tbVendorWaypoints.Text = "";
            usedProfileForm.tbGhostHotspots.Text = "";
            usedProfileForm.tbFactions.Text = "";
            usedProfileForm.tbRepair.Text = "";
            usedProfileForm.tbVendor.Text = "";
            usedProfileForm.tbRestock.Text = "";
            usedProfileForm.tbRestockItems.Text = "";
            usedProfileForm.cbIgnoreZ.Checked = false;
            usedProfileForm.lHotspotCount.Text = "Count: ";
            usedProfileForm.lFactionCount.Text = "Count: ";
            usedProfileForm.lGhostHotspotCount.Text = "Count: ";
            usedProfileForm.lbl_VendorWaypointsCount.Text = "Count: ";
            usedProfileForm.lRecording.Visible = false;
            usedProfileForm.Text = "Recording stopped!";
            DirectX.StopRunning();
        }

        internal void ClearVendor()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                usedProfileForm.tbVendor.Text = "";
                VendorNpc = null;
            }));
        }

        internal void ClearRestock()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                usedProfileForm.tbRestock.Text = "";
                RestockNpc = null;
            }));
        }

        internal void ClearRepair()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                usedProfileForm.tbRepair.Text = "";
                RepairNpc = null;
            }));
        }

        internal void ClearFactions()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                listFactions.Clear();
                usedProfileForm.tbFactions.Text = "";
                usedProfileForm.lFactionCount.Text = "Count: ";
            }));
        }

        internal void ClearHotspots()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                listHotspots.Clear();
                usedProfileForm.tbHotspots.Text = "";
                usedProfileForm.lHotspotCount.Text = "Count: ";
            }));
        }

        internal void ClearRestockItems()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                usedProfileForm.tbRestockItems.Text = "";
                listRestockItems.Clear();
            }));
        }
        
        internal void ClearGhostWaypoints()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                listGhostHotspots.Clear();
                usedProfileForm.tbGhostHotspots.Text = "";
                usedProfileForm.lGhostHotspotCount.Text = "Count: ";
            }));
        }

        internal void ClearVendorWaypoints()
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                listGhostHotspots.Clear();
                usedProfileForm.tbVendorWaypoints.Text = "";
                usedProfileForm.lbl_VendorWaypointsCount.Text = "Count: ";
            }));
        }

        internal void AddGhostWaypoint()
        {
            boolAddGhostWaypoint = true;
        }

        internal void AddVendorWaypoint()
        {
            boolAddVendorWaypoint = true;
        }

        internal void AddWaypoint()
        {
            boolAddWaypoint = true;
        }
        
        internal void AddVendor()
        {
            boolAddVendor = true;
        }

        internal void AddRepair()
        {
            boolAddRepair = true;
        }

        internal void AddRestock()
        {
            boolAddRestock = true;
        }

        internal void AddFaction()
        {
            boolAddFaction = true;
        }

        internal void AddRestockItem()
        {
            var tmpForm = new FormRestockItem();
            if (tmpForm.ShowDialog() == DialogResult.OK)
            {
                if (tmpForm.tbItemName.Text.Trim() != "")
                {
                    var tmpItem = new RestockItem(tmpForm.tbItemName.Text,
                        (int) tmpForm.nudRestockUpTo.Value);
                    listRestockItems.Add(tmpItem);
                    usedProfileForm.tbRestockItems.Text += tmpItem.Item + Environment.NewLine;
                }
            }
        }

        private void EndScene_AddWaypoint(HotspotType parType)
        {
            var justPosEncrypted = "justPos".GenLuaVarName();
            var posInfoEncrypted = Strings.GT_PosInfos.GenLuaVarName();
            var tmpVec = ObjectManager.Player.Position;
            Functions.DoString(Strings.PosInfos.Replace("justPos", justPosEncrypted).Replace(Strings.GT_PosInfos, posInfoEncrypted));
            var pos = Functions.GetText(justPosEncrypted);

            Enums.PositionType posType;

            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                posType = usedProfileForm.rbHotspot.Checked ? Enums.PositionType.Hotspot : Enums.PositionType.Waypoint;

                switch (parType)
                {
                    case HotspotType.Hotspot:
                        posType = Enums.PositionType.Hotspot;
                        listHotspots.Add(Tuple.Create(tmpVec, pos, posType));
                        usedProfileForm.tbHotspots.Text += tmpVec + Environment.NewLine;
                        usedProfileForm.lHotspotCount.Text = "Count: " + listHotspots.Count;
                        boolAddWaypoint = false;
                        break;
                        
                    case HotspotType.Ghost:
                        listGhostHotspots.Add(Tuple.Create(tmpVec, pos, posType));
                        usedProfileForm.tbGhostHotspots.Text += tmpVec + Environment.NewLine;
                        usedProfileForm.lGhostHotspotCount.Text = "Count: " + listGhostHotspots.Count;
                        boolAddGhostWaypoint = false;
                        break;

                    case HotspotType.VendorHotspot:
                        listVendorHotspots.Add(Tuple.Create(tmpVec, pos, posType));
                        usedProfileForm.tbVendor.Text += tmpVec + Environment.NewLine;
                        usedProfileForm.lbl_VendorWaypointsCount.Text = "Count: " + listVendorHotspots.Count;
                        boolAddVendorWaypoint = false;
                        break;
                }
            }));
        }

        private void EndScene_AddFaction()
        {
            var tmpUnit =
                ObjectManager.Npcs
                    .FirstOrDefault(i => i.Guid == ObjectManager.Player.TargetGuid);

            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                if (tmpUnit != null)
                {
                    if (!listFactions.Contains(tmpUnit.FactionID))
                    {
                        if (tmpUnit.Reaction != Enums.UnitReaction.Friendly)
                        {
                            listFactions.Add(tmpUnit.FactionID);
                            usedProfileForm.tbFactions.Text += tmpUnit.FactionID + Environment.NewLine;
                            usedProfileForm.lFactionCount.Text = "Count: " + listFactions.Count;
                        }
                    }
                }
                boolAddFaction = false;
            }));
        }

        private void EndScene_AddNpc(NpcType parType)
        {
            var tmpUnit =
                ObjectManager.Npcs
                    .FirstOrDefault(i => i.Guid == ObjectManager.Player.TargetGuid);
            if (tmpUnit == null)
            {
                boolAddRestock = false;
                boolAddVendor = false;
                boolAddRepair = false;
                return;
            }

            var justPosEncrypted = "justPos".GenLuaVarName();
            Functions.DoString(Strings.PosInfos.Replace("justPos", justPosEncrypted));
            var pos = Functions.GetText(justPosEncrypted);

            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                switch (parType)
                {
                    case NpcType.Repair:
                        RepairNpc = new NPC(tmpUnit.Name, tmpUnit.Position,
                            pos);
                        usedProfileForm.tbRepair.Text = tmpUnit.Name;
                        boolAddRepair = false;
                        break;

                    case NpcType.Restock:
                        RestockNpc = new NPC(tmpUnit.Name, tmpUnit.Position, pos);
                        usedProfileForm.tbRestock.Text = tmpUnit.Name;
                        boolAddRestock = false;
                        break;

                    case NpcType.Vendor:
                        VendorNpc = new NPC(tmpUnit.Name, tmpUnit.Position, pos);
                        usedProfileForm.tbVendor.Text = tmpUnit.Name;
                        boolAddVendor = false;
                        break;
                }
            }));
        }

        private void CreateProfile(ref int parFrameCount, bool IsIngame)
        {
            if (parFrameCount%5 == 0)
            {
                if (IsIngame)
                {
                    if (boolAddWaypoint)
                    {
                        EndScene_AddWaypoint(HotspotType.Hotspot);
                    }
                    if (boolAddVendorWaypoint)
                    {
                        EndScene_AddWaypoint(HotspotType.VendorHotspot);
                    }
                    if (boolAddGhostWaypoint)
                    {
                        EndScene_AddWaypoint(HotspotType.Ghost);
                    }
                    if (boolAddFaction)
                    {
                        EndScene_AddFaction();
                    }
                    if (boolAddRepair)
                    {
                        EndScene_AddNpc(NpcType.Repair);
                    }
                    if (boolAddVendor)
                    {
                        EndScene_AddNpc(NpcType.Vendor);
                    }
                    if (boolAddRestock)
                    {
                        EndScene_AddNpc(NpcType.Restock);
                    }
                }
            }
        }

        private bool WriteToXmlProfile()
        {
            if (!Directory.Exists(Paths.ProfileFolder))
                Directory.CreateDirectory(Paths.ProfileFolder);

            var settings = new XmlWriterSettings
            {
                NewLineOnAttributes = true,
                NewLineChars = Environment.NewLine,
                Indent = true,
                IndentChars = "\t"
            };
            var tmpProfilePath = Paths.ProfileFolder + "\\" + DateTime.Now.ToString("MMddHHmmss") + ".xml";
            using (
                var writer = XmlWriter.Create(tmpProfilePath, settings))
            {
                // Start document
                writer.WriteStartDocument();

                // Hotspot Element Start
                writer.WriteComment(" Start: " + profileStart + " ");
                writer.WriteStartElement("Profile");

                if (boolIgnoreZAxis)
                {
                    writer.WriteStartElement("IgnoreZAxis");
                    writer.WriteEndElement();
                }

                writer.WriteStartElement("Hotspots");
                foreach (var vec in listHotspots)
                {
                    writer.WriteStartElement("Hotspot");
                    writer.WriteComment(" Pos: " + vec.Item2 + " ");
                    writer.WriteElementString("X", vec.Item1.X.ToString());
                    writer.WriteElementString("Y", vec.Item1.Y.ToString());
                    writer.WriteElementString("Z", vec.Item1.Z.ToString());
                    writer.WriteElementString("Type", vec.Item3.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                if (listFactions.Count != 0)
                {
                    writer.WriteStartElement("Factions");
                    foreach (var f in listFactions)
                    {
                        writer.WriteElementString("Faction", f.ToString());
                    }
                    writer.WriteEndElement();
                }

                if (VendorNpc != null)
                {
                    writer.WriteStartElement("Vendor");
                    writer.WriteComment(" Pos: " + VendorNpc.MapPosition + " ");
                    writer.WriteStartElement("Position");
                    writer.WriteElementString("X", VendorNpc.Coordinates.X.ToString());
                    writer.WriteElementString("Y", VendorNpc.Coordinates.Y.ToString());
                    writer.WriteElementString("Z", VendorNpc.Coordinates.Z.ToString());
                    writer.WriteEndElement();
                    writer.WriteElementString("Name", VendorNpc.Name);
                    writer.WriteEndElement();
                }

                if (RepairNpc != null)
                {
                    if (listVendorHotspots.Count > 0)
                    {
                        writer.WriteStartElement("VendorHotspots");
                        foreach (var vec in listVendorHotspots)
                        {
                            writer.WriteStartElement("VendorHotspot");
                            writer.WriteComment(" Pos: " + vec.Item2 + " ");
                            writer.WriteElementString("X", vec.Item1.X.ToString());
                            writer.WriteElementString("Y", vec.Item1.Y.ToString());
                            writer.WriteElementString("Z", vec.Item1.Z.ToString());
                            writer.WriteElementString("Type", vec.Item3.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("Repair");
                    writer.WriteComment(" Pos: " + RepairNpc.MapPosition + " ");
                    writer.WriteStartElement("Position");
                    writer.WriteElementString("X", RepairNpc.Coordinates.X.ToString());
                    writer.WriteElementString("Y", RepairNpc.Coordinates.Y.ToString());
                    writer.WriteElementString("Z", RepairNpc.Coordinates.Z.ToString());
                    writer.WriteEndElement();
                    writer.WriteElementString("Name", RepairNpc.Name);
                    writer.WriteEndElement();
                }

                if (listGhostHotspots.Count > 0)
                {
                    writer.WriteStartElement("GhostHotspots");
                    foreach (var vec in listGhostHotspots)
                    {
                        writer.WriteStartElement("GhostHotspot");
                        writer.WriteComment(" Pos: " + vec.Item2 + " ");
                        writer.WriteElementString("X", vec.Item1.X.ToString());
                        writer.WriteElementString("Y", vec.Item1.Y.ToString());
                        writer.WriteElementString("Z", vec.Item1.Z.ToString());
                        writer.WriteElementString("Type", vec.Item3.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                if (listVendorHotspots.Count > 0)
                {
                    writer.WriteStartElement("VendorHotspots");
                    foreach (var vec in listVendorHotspots)
                    {
                        writer.WriteStartElement("VendorHotspot");
                        writer.WriteComment(" Pos: " + vec.Item2 + " ");
                        writer.WriteElementString("X", vec.Item1.X.ToString());
                        writer.WriteElementString("Y", vec.Item1.Y.ToString());
                        writer.WriteElementString("Z", vec.Item1.Z.ToString());
                        writer.WriteElementString("Type", vec.Item3.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                if (RestockNpc != null)
                {
                    if (listRestockItems.Count > 0)
                    {
                        writer.WriteStartElement("Restock");
                        writer.WriteComment(" Pos: " + RestockNpc.MapPosition + " ");
                        writer.WriteStartElement("Position");
                        writer.WriteElementString("X", RestockNpc.Coordinates.X.ToString());
                        writer.WriteElementString("Y", RestockNpc.Coordinates.Y.ToString());
                        writer.WriteElementString("Z", RestockNpc.Coordinates.Z.ToString());
                        writer.WriteEndElement();
                        writer.WriteElementString("Name", RestockNpc.Name);
                        writer.WriteEndElement();

                        writer.WriteStartElement("RestockItems");
                        foreach (var r in listRestockItems)
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteElementString("Name", r.Item);
                            writer.WriteElementString("RestockUpTo", r.RestockUpTo.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                }
                // Hotspot Element End
                writer.WriteEndElement();
                // End document
                writer.WriteEndDocument();

                MessageBox.Show("The profile has been written to: " + tmpProfilePath);
                return true;
            }
        }


        private enum HotspotType
        {
            Hotspot = 1,
            VendorHotspot = 2,
            Ghost = 3
        }

        private enum NpcType
        {
            Repair = 1,
            Vendor = 2,
            Restock = 3
        }
    }
}