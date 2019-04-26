using System;
using System.Windows.Forms;
using ZzukBot.Engines;
using ZzukBot.Engines.ProfileCreation;

using ZzukBot.Mem;

namespace ZzukBot.Forms
{
    public partial class GraphicalProfileCreationForm : Form
    {
        private bool _shouldRecord;
        private bool _recordingGrind;
        private bool _recordingGhost;
        private bool _recordingVendor;

        public GraphicalProfileCreationForm()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;

            StopBgWorker();
            EngineManager.StopCurrentEngine();
            this.Close();
        }

        private void GraphicalProfileCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;

            StopBgWorker();
            EngineManager.StopCurrentEngine();
        }


        #region repair
        //NPC
        private void bAddRepair_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddRepair();
        }
        private void bClearRepair_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearRepair();
        }
        #endregion

        #region faction
        //NPC
        private void bAddFaction_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddFaction();
        }
        private void bClearFactions_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearFactions();
        }

        #endregion

        #region restock
        //Restock NPC
        private void bAddRestock_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddRestock();
        }
        private void bClearRestock_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearRestock();
        }
        //Restock Item List
        private void bAddRestockItem_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddRestockItem();
        }
        private void bClearRestockItems_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearRestockItems();
        }
        #endregion

        #region Vendor
        private void bAddVendor_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddVendor();
        }
        private void bClearVendor_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearVendor();
        }


        #endregion

        #region Hotspots
        private void btn_WaypointsAutoRecord_Click(object sender, EventArgs e)
        {
            if(!_recordingGrind)
            {
                Helpers.Logger.Append("Started auto recording grind waypoints");
                _recordingGrind = true;
                RestartRecorder();
            }
            else
            {
                Helpers.Logger.Append("Stopped auto recording grind waypoints");
                _recordingGrind = false;
                SetButtonsCaption();
            }
        }
        private void bAddHotspots_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddWaypoint();
        }
        private void bClearHotspots_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearHotspots();
        }
        #endregion

        #region Vendor Hotspots
        private void btn_VendorAutoRecord_Click(object sender, EventArgs e)
        {
            if (!_recordingVendor)
            {
                Helpers.Logger.Append("Started auto recording vendor waypoints");
                _recordingVendor = true;
                RestartRecorder();
            }
            else
            {
                Helpers.Logger.Append("Stopped auto recording vendor waypoints");
                _recordingVendor = false;
            }
        }
        private void bAddVendorHotspot_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddVendorWaypoint();
        }
        private void bClearVendorHotspots_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearVendorWaypoints();
        }
        #endregion

        #region Ghost Hotspots
        private void btn_GhostAutoRecord_Click(object sender, EventArgs e)
        {
            if (!_recordingGhost)
            {
                Helpers.Logger.Append("Started auto recording ghost waypoints");
                _recordingGhost = true;
                RestartRecorder();
            }
            else
            {
                Helpers.Logger.Append("Stopped auto recording ghost waypoints");
                _recordingGhost = false;
            }
        }
        private void bAddGhostHotspot_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().AddGhostWaypoint();
        }
        private void bClearGhostHotspots_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
            EngineManager.EngineAs<ProfileCreator>().ClearGhostWaypoints();
        }

        #endregion
                
        private void RestartRecorder()
        {
            _shouldRecord = true;
            if (!bgWorker_Recording.IsBusy)
            {
                bgWorker_Recording.DoWork += BgWorker_Recording_DoWork;
                bgWorker_Recording.RunWorkerAsync();
            }
        }

        private bool StopBgWorker()
        {            
            if (bgWorker_Recording != null && !bgWorker_Recording.CancellationPending)
            {
                _shouldRecord = false;
                bgWorker_Recording.CancelAsync();
                bgWorker_Recording.Dispose();

                return true;
            }


            return false;
        }

        private void SetButtonsCaption()
        {
            if(_recordingGrind) { grp_Hotspots.Text = "Grind Hotspots - Auto recording.."; }
            else { grp_Hotspots.Text = "Grind Hotspots"; }

            if (_recordingGhost) { grp_Ghost.Text = "Ghost Waypoints - Auto recording.."; }
            else { grp_Ghost.Text = "Ghost Waypoints"; }

            if (_recordingVendor) { grp_Vendor.Text = "Vendor Waypoints - Auto recording.."; }
            else { grp_Vendor.Text = "Vendor Waypoints"; }
        }

        #region recorder bgworker DoWork
        private void BgWorker_Recording_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var player = ObjectManager.Player;
            Helpers.XYZ lastRecordedWaypoint = null;
            while (_shouldRecord && !bgWorker_Recording.CancellationPending)
            {
                if (lastRecordedWaypoint == null)
                {
                    lastRecordedWaypoint = player.Position;
                }

                Helpers.XYZ currentLocation = player.Position;
                if (Helpers.Calc.Distance3D(lastRecordedWaypoint, currentLocation) > 30)
                {
                    if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;

                    lastRecordedWaypoint = currentLocation;

                    if (_recordingGrind)
                    {
                        EngineManager.EngineAs<ProfileCreator>().AddWaypoint();
                        Helpers.Logger.Append("Added grind waypoint " + currentLocation.X + " :: " + currentLocation.Y + " :: " + currentLocation.Z);
                    }
                    if (_recordingGhost)
                    {
                        EngineManager.EngineAs<ProfileCreator>().AddGhostWaypoint();
                        Helpers.Logger.Append("Added ghost waypoint " + currentLocation.X + " :: " + currentLocation.Y + " :: " + currentLocation.Z);
                    }
                    if (_recordingVendor)
                    {
                        EngineManager.EngineAs<ProfileCreator>().AddVendorWaypoint();
                        Helpers.Logger.Append("Added vendor waypoint " + currentLocation.X + " :: " + currentLocation.Y + " :: " + currentLocation.Z);
                    }
                }

                SetButtonsCaption();
            }
        }
        #endregion
    }
}
