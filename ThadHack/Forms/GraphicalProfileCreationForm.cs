using System;
using System.Windows.Forms;
using ZzukBot.Engines;
using ZzukBot.Engines.ProfileCreation;

namespace ZzukBot.Forms
{
    public partial class GraphicalProfileCreationForm : Form
    {
        public GraphicalProfileCreationForm()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.ProfileCreation) return;
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

    }
}
