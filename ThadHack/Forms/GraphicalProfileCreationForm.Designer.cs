namespace ZzukBot.Forms
{
    partial class GraphicalProfileCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbIgnoreZ = new System.Windows.Forms.CheckBox();
            this.lAddPointAs = new System.Windows.Forms.Label();
            this.rbWaypoint = new System.Windows.Forms.RadioButton();
            this.rbHotspot = new System.Windows.Forms.RadioButton();
            this.bClearHotspots = new System.Windows.Forms.Button();
            this.tbHotspots = new System.Windows.Forms.TextBox();
            this.lHotspotCount = new System.Windows.Forms.Label();
            this.bAddHotspots = new System.Windows.Forms.Button();
            this.bClearRestockItems = new System.Windows.Forms.Button();
            this.bAddRestockItem = new System.Windows.Forms.Button();
            this.tbRestockItems = new System.Windows.Forms.TextBox();
            this.lRecording = new System.Windows.Forms.Label();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.bClearVendor = new System.Windows.Forms.Button();
            this.bAddVendor = new System.Windows.Forms.Button();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.lVendor = new System.Windows.Forms.Label();
            this.bClearRestock = new System.Windows.Forms.Button();
            this.bAddRestock = new System.Windows.Forms.Button();
            this.bClearRepair = new System.Windows.Forms.Button();
            this.bAddRepair = new System.Windows.Forms.Button();
            this.tbRestock = new System.Windows.Forms.TextBox();
            this.tbRepair = new System.Windows.Forms.TextBox();
            this.lRestock = new System.Windows.Forms.Label();
            this.lRepair = new System.Windows.Forms.Label();
            this.gbFaction = new System.Windows.Forms.GroupBox();
            this.bClearFactions = new System.Windows.Forms.Button();
            this.bAddFaction = new System.Windows.Forms.Button();
            this.tbFactions = new System.Windows.Forms.TextBox();
            this.lFactionCount = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.grp_Hotspots = new System.Windows.Forms.GroupBox();
            this.btn_WaypointsAutoRecord = new System.Windows.Forms.Button();
            this.grp_Ghost = new System.Windows.Forms.GroupBox();
            this.btn_GhostAutoRecord = new System.Windows.Forms.Button();
            this.bClearGhostHotspots = new System.Windows.Forms.Button();
            this.tbGhostHotspots = new System.Windows.Forms.TextBox();
            this.bAddGhostHotspot = new System.Windows.Forms.Button();
            this.lGhostHotspotCount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bgWorker_Recording = new System.ComponentModel.BackgroundWorker();
            this.gbVendor.SuspendLayout();
            this.gbFaction.SuspendLayout();
            this.grp_Hotspots.SuspendLayout();
            this.grp_Ghost.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIgnoreZ
            // 
            this.cbIgnoreZ.AutoSize = true;
            this.cbIgnoreZ.Location = new System.Drawing.Point(63, 377);
            this.cbIgnoreZ.Name = "cbIgnoreZ";
            this.cbIgnoreZ.Size = new System.Drawing.Size(148, 17);
            this.cbIgnoreZ.TabIndex = 29;
            this.cbIgnoreZ.Text = "Ignore Z axis in this profile";
            this.cbIgnoreZ.UseVisualStyleBackColor = true;
            // 
            // lAddPointAs
            // 
            this.lAddPointAs.AutoSize = true;
            this.lAddPointAs.Location = new System.Drawing.Point(23, 129);
            this.lAddPointAs.Name = "lAddPointAs";
            this.lAddPointAs.Size = new System.Drawing.Size(43, 13);
            this.lAddPointAs.TabIndex = 28;
            this.lAddPointAs.Text = "Add as:";
            // 
            // rbWaypoint
            // 
            this.rbWaypoint.AutoSize = true;
            this.rbWaypoint.Location = new System.Drawing.Point(140, 125);
            this.rbWaypoint.Name = "rbWaypoint";
            this.rbWaypoint.Size = new System.Drawing.Size(70, 17);
            this.rbWaypoint.TabIndex = 24;
            this.rbWaypoint.Text = "Waypoint";
            this.rbWaypoint.UseVisualStyleBackColor = true;
            // 
            // rbHotspot
            // 
            this.rbHotspot.AutoSize = true;
            this.rbHotspot.Checked = true;
            this.rbHotspot.Location = new System.Drawing.Point(72, 125);
            this.rbHotspot.Name = "rbHotspot";
            this.rbHotspot.Size = new System.Drawing.Size(62, 17);
            this.rbHotspot.TabIndex = 22;
            this.rbHotspot.TabStop = true;
            this.rbHotspot.Text = "Hotspot";
            this.rbHotspot.UseVisualStyleBackColor = true;
            // 
            // bClearHotspots
            // 
            this.bClearHotspots.Location = new System.Drawing.Point(142, 97);
            this.bClearHotspots.Name = "bClearHotspots";
            this.bClearHotspots.Size = new System.Drawing.Size(44, 20);
            this.bClearHotspots.TabIndex = 1;
            this.bClearHotspots.Text = "Clear";
            this.bClearHotspots.UseVisualStyleBackColor = true;
            this.bClearHotspots.Click += new System.EventHandler(this.bClearHotspots_Click);
            // 
            // tbHotspots
            // 
            this.tbHotspots.Enabled = false;
            this.tbHotspots.Location = new System.Drawing.Point(6, 19);
            this.tbHotspots.Multiline = true;
            this.tbHotspots.Name = "tbHotspots";
            this.tbHotspots.Size = new System.Drawing.Size(243, 72);
            this.tbHotspots.TabIndex = 2;
            // 
            // lHotspotCount
            // 
            this.lHotspotCount.AutoSize = true;
            this.lHotspotCount.Location = new System.Drawing.Point(190, 101);
            this.lHotspotCount.Name = "lHotspotCount";
            this.lHotspotCount.Size = new System.Drawing.Size(38, 13);
            this.lHotspotCount.TabIndex = 2;
            this.lHotspotCount.Text = "Count:";
            // 
            // bAddHotspots
            // 
            this.bAddHotspots.Location = new System.Drawing.Point(92, 97);
            this.bAddHotspots.Name = "bAddHotspots";
            this.bAddHotspots.Size = new System.Drawing.Size(44, 20);
            this.bAddHotspots.TabIndex = 0;
            this.bAddHotspots.Text = "Add";
            this.bAddHotspots.UseVisualStyleBackColor = true;
            this.bAddHotspots.Click += new System.EventHandler(this.bAddHotspots_Click);
            // 
            // bClearRestockItems
            // 
            this.bClearRestockItems.Enabled = false;
            this.bClearRestockItems.Location = new System.Drawing.Point(10, 156);
            this.bClearRestockItems.Name = "bClearRestockItems";
            this.bClearRestockItems.Size = new System.Drawing.Size(119, 20);
            this.bClearRestockItems.TabIndex = 26;
            this.bClearRestockItems.Text = "Clear";
            this.bClearRestockItems.UseVisualStyleBackColor = true;
            this.bClearRestockItems.Click += new System.EventHandler(this.bClearRestockItems_Click);
            // 
            // bAddRestockItem
            // 
            this.bAddRestockItem.Enabled = false;
            this.bAddRestockItem.Location = new System.Drawing.Point(10, 130);
            this.bAddRestockItem.Name = "bAddRestockItem";
            this.bAddRestockItem.Size = new System.Drawing.Size(119, 20);
            this.bAddRestockItem.TabIndex = 25;
            this.bAddRestockItem.Text = "Add";
            this.bAddRestockItem.UseVisualStyleBackColor = true;
            this.bAddRestockItem.Click += new System.EventHandler(this.bAddRestockItem_Click);
            // 
            // tbRestockItems
            // 
            this.tbRestockItems.Enabled = false;
            this.tbRestockItems.Location = new System.Drawing.Point(10, 19);
            this.tbRestockItems.Multiline = true;
            this.tbRestockItems.Name = "tbRestockItems";
            this.tbRestockItems.Size = new System.Drawing.Size(119, 105);
            this.tbRestockItems.TabIndex = 23;
            // 
            // lRecording
            // 
            this.lRecording.AutoSize = true;
            this.lRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRecording.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lRecording.Location = new System.Drawing.Point(123, 139);
            this.lRecording.Name = "lRecording";
            this.lRecording.Size = new System.Drawing.Size(125, 29);
            this.lRecording.TabIndex = 21;
            this.lRecording.Text = "Recording";
            this.lRecording.Visible = false;
            // 
            // gbVendor
            // 
            this.gbVendor.Controls.Add(this.bClearVendor);
            this.gbVendor.Controls.Add(this.bAddVendor);
            this.gbVendor.Controls.Add(this.tbVendor);
            this.gbVendor.Controls.Add(this.lVendor);
            this.gbVendor.Controls.Add(this.bClearRestock);
            this.gbVendor.Controls.Add(this.bAddRestock);
            this.gbVendor.Controls.Add(this.bClearRepair);
            this.gbVendor.Controls.Add(this.bAddRepair);
            this.gbVendor.Controls.Add(this.tbRestock);
            this.gbVendor.Controls.Add(this.tbRepair);
            this.gbVendor.Controls.Add(this.lRestock);
            this.gbVendor.Controls.Add(this.lRepair);
            this.gbVendor.Location = new System.Drawing.Point(116, 12);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(288, 125);
            this.gbVendor.TabIndex = 19;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Vendoring";
            // 
            // bClearVendor
            // 
            this.bClearVendor.Enabled = false;
            this.bClearVendor.Location = new System.Drawing.Point(195, 84);
            this.bClearVendor.Name = "bClearVendor";
            this.bClearVendor.Size = new System.Drawing.Size(83, 20);
            this.bClearVendor.TabIndex = 15;
            this.bClearVendor.Text = "Clear";
            this.bClearVendor.UseVisualStyleBackColor = true;
            this.bClearVendor.Click += new System.EventHandler(this.bClearVendor_Click);
            // 
            // bAddVendor
            // 
            this.bAddVendor.Enabled = false;
            this.bAddVendor.Location = new System.Drawing.Point(195, 58);
            this.bAddVendor.Name = "bAddVendor";
            this.bAddVendor.Size = new System.Drawing.Size(83, 20);
            this.bAddVendor.TabIndex = 14;
            this.bAddVendor.Text = "Add";
            this.bAddVendor.UseVisualStyleBackColor = true;
            this.bAddVendor.Click += new System.EventHandler(this.bAddVendor_Click);
            // 
            // tbVendor
            // 
            this.tbVendor.Enabled = false;
            this.tbVendor.Location = new System.Drawing.Point(195, 32);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.Size = new System.Drawing.Size(82, 20);
            this.tbVendor.TabIndex = 13;
            // 
            // lVendor
            // 
            this.lVendor.AutoSize = true;
            this.lVendor.Enabled = false;
            this.lVendor.Location = new System.Drawing.Point(192, 16);
            this.lVendor.Name = "lVendor";
            this.lVendor.Size = new System.Drawing.Size(41, 13);
            this.lVendor.TabIndex = 12;
            this.lVendor.Text = "Vendor";
            // 
            // bClearRestock
            // 
            this.bClearRestock.Enabled = false;
            this.bClearRestock.Location = new System.Drawing.Point(104, 85);
            this.bClearRestock.Name = "bClearRestock";
            this.bClearRestock.Size = new System.Drawing.Size(83, 20);
            this.bClearRestock.TabIndex = 11;
            this.bClearRestock.Text = "Clear";
            this.bClearRestock.UseVisualStyleBackColor = true;
            this.bClearRestock.Click += new System.EventHandler(this.bClearRestock_Click);
            // 
            // bAddRestock
            // 
            this.bAddRestock.Enabled = false;
            this.bAddRestock.Location = new System.Drawing.Point(104, 59);
            this.bAddRestock.Name = "bAddRestock";
            this.bAddRestock.Size = new System.Drawing.Size(83, 20);
            this.bAddRestock.TabIndex = 10;
            this.bAddRestock.Text = "Add";
            this.bAddRestock.UseVisualStyleBackColor = true;
            this.bAddRestock.Click += new System.EventHandler(this.bAddRestock_Click);
            // 
            // bClearRepair
            // 
            this.bClearRepair.Location = new System.Drawing.Point(12, 85);
            this.bClearRepair.Name = "bClearRepair";
            this.bClearRepair.Size = new System.Drawing.Size(83, 20);
            this.bClearRepair.TabIndex = 9;
            this.bClearRepair.Text = "Clear";
            this.bClearRepair.UseVisualStyleBackColor = true;
            this.bClearRepair.Click += new System.EventHandler(this.bClearRepair_Click);
            // 
            // bAddRepair
            // 
            this.bAddRepair.Location = new System.Drawing.Point(12, 59);
            this.bAddRepair.Name = "bAddRepair";
            this.bAddRepair.Size = new System.Drawing.Size(83, 20);
            this.bAddRepair.TabIndex = 8;
            this.bAddRepair.Text = "Add";
            this.bAddRepair.UseVisualStyleBackColor = true;
            this.bAddRepair.Click += new System.EventHandler(this.bAddRepair_Click);
            // 
            // tbRestock
            // 
            this.tbRestock.Enabled = false;
            this.tbRestock.Location = new System.Drawing.Point(104, 33);
            this.tbRestock.Name = "tbRestock";
            this.tbRestock.Size = new System.Drawing.Size(82, 20);
            this.tbRestock.TabIndex = 3;
            // 
            // tbRepair
            // 
            this.tbRepair.Enabled = false;
            this.tbRepair.Location = new System.Drawing.Point(12, 33);
            this.tbRepair.Name = "tbRepair";
            this.tbRepair.Size = new System.Drawing.Size(83, 20);
            this.tbRepair.TabIndex = 2;
            // 
            // lRestock
            // 
            this.lRestock.AutoSize = true;
            this.lRestock.Enabled = false;
            this.lRestock.Location = new System.Drawing.Point(101, 17);
            this.lRestock.Name = "lRestock";
            this.lRestock.Size = new System.Drawing.Size(47, 13);
            this.lRestock.TabIndex = 1;
            this.lRestock.Text = "Restock";
            // 
            // lRepair
            // 
            this.lRepair.AutoSize = true;
            this.lRepair.Location = new System.Drawing.Point(9, 17);
            this.lRepair.Name = "lRepair";
            this.lRepair.Size = new System.Drawing.Size(38, 13);
            this.lRepair.TabIndex = 0;
            this.lRepair.Text = "Repair";
            // 
            // gbFaction
            // 
            this.gbFaction.Controls.Add(this.bClearFactions);
            this.gbFaction.Controls.Add(this.bAddFaction);
            this.gbFaction.Controls.Add(this.tbFactions);
            this.gbFaction.Controls.Add(this.lFactionCount);
            this.gbFaction.Location = new System.Drawing.Point(12, 12);
            this.gbFaction.Name = "gbFaction";
            this.gbFaction.Size = new System.Drawing.Size(98, 176);
            this.gbFaction.TabIndex = 18;
            this.gbFaction.TabStop = false;
            this.gbFaction.Text = "Factions";
            // 
            // bClearFactions
            // 
            this.bClearFactions.Location = new System.Drawing.Point(9, 146);
            this.bClearFactions.Name = "bClearFactions";
            this.bClearFactions.Size = new System.Drawing.Size(83, 20);
            this.bClearFactions.TabIndex = 8;
            this.bClearFactions.Text = "Clear";
            this.bClearFactions.UseVisualStyleBackColor = true;
            this.bClearFactions.Click += new System.EventHandler(this.bClearFactions_Click);
            // 
            // bAddFaction
            // 
            this.bAddFaction.Location = new System.Drawing.Point(9, 120);
            this.bAddFaction.Name = "bAddFaction";
            this.bAddFaction.Size = new System.Drawing.Size(83, 20);
            this.bAddFaction.TabIndex = 7;
            this.bAddFaction.Text = "Add";
            this.bAddFaction.UseVisualStyleBackColor = true;
            this.bAddFaction.Click += new System.EventHandler(this.bAddFaction_Click);
            // 
            // tbFactions
            // 
            this.tbFactions.Enabled = false;
            this.tbFactions.Location = new System.Drawing.Point(9, 42);
            this.tbFactions.Multiline = true;
            this.tbFactions.Name = "tbFactions";
            this.tbFactions.Size = new System.Drawing.Size(80, 72);
            this.tbFactions.TabIndex = 1;
            // 
            // lFactionCount
            // 
            this.lFactionCount.AutoSize = true;
            this.lFactionCount.Location = new System.Drawing.Point(6, 26);
            this.lFactionCount.Name = "lFactionCount";
            this.lFactionCount.Size = new System.Drawing.Size(38, 13);
            this.lFactionCount.TabIndex = 0;
            this.lFactionCount.Text = "Count:";
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(60, 400);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(115, 32);
            this.bSave.TabIndex = 16;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // grp_Hotspots
            // 
            this.grp_Hotspots.Controls.Add(this.btn_WaypointsAutoRecord);
            this.grp_Hotspots.Controls.Add(this.bClearHotspots);
            this.grp_Hotspots.Controls.Add(this.tbHotspots);
            this.grp_Hotspots.Controls.Add(this.bAddHotspots);
            this.grp_Hotspots.Controls.Add(this.lHotspotCount);
            this.grp_Hotspots.Controls.Add(this.lAddPointAs);
            this.grp_Hotspots.Controls.Add(this.rbHotspot);
            this.grp_Hotspots.Controls.Add(this.rbWaypoint);
            this.grp_Hotspots.Location = new System.Drawing.Point(12, 200);
            this.grp_Hotspots.Name = "grp_Hotspots";
            this.grp_Hotspots.Size = new System.Drawing.Size(256, 151);
            this.grp_Hotspots.TabIndex = 30;
            this.grp_Hotspots.TabStop = false;
            this.grp_Hotspots.Text = "Grind Hotspots";
            // 
            // btn_WaypointsAutoRecord
            // 
            this.btn_WaypointsAutoRecord.Location = new System.Drawing.Point(6, 97);
            this.btn_WaypointsAutoRecord.Name = "btn_WaypointsAutoRecord";
            this.btn_WaypointsAutoRecord.Size = new System.Drawing.Size(78, 20);
            this.btn_WaypointsAutoRecord.TabIndex = 29;
            this.btn_WaypointsAutoRecord.Text = "Auto Record";
            this.btn_WaypointsAutoRecord.UseVisualStyleBackColor = true;
            this.btn_WaypointsAutoRecord.Click += new System.EventHandler(this.btn_WaypointsAutoRecord_Click);
            // 
            // grp_Ghost
            // 
            this.grp_Ghost.Controls.Add(this.btn_GhostAutoRecord);
            this.grp_Ghost.Controls.Add(this.bClearGhostHotspots);
            this.grp_Ghost.Controls.Add(this.tbGhostHotspots);
            this.grp_Ghost.Controls.Add(this.bAddGhostHotspot);
            this.grp_Ghost.Controls.Add(this.lGhostHotspotCount);
            this.grp_Ghost.Location = new System.Drawing.Point(283, 200);
            this.grp_Ghost.Name = "grp_Ghost";
            this.grp_Ghost.Size = new System.Drawing.Size(256, 124);
            this.grp_Ghost.TabIndex = 32;
            this.grp_Ghost.TabStop = false;
            this.grp_Ghost.Text = "Ghost Waypoints";
            // 
            // btn_GhostAutoRecord
            // 
            this.btn_GhostAutoRecord.Location = new System.Drawing.Point(6, 97);
            this.btn_GhostAutoRecord.Name = "btn_GhostAutoRecord";
            this.btn_GhostAutoRecord.Size = new System.Drawing.Size(78, 20);
            this.btn_GhostAutoRecord.TabIndex = 13;
            this.btn_GhostAutoRecord.Text = "Auto Record";
            this.btn_GhostAutoRecord.UseVisualStyleBackColor = true;
            this.btn_GhostAutoRecord.Click += new System.EventHandler(this.btn_GhostAutoRecord_Click);
            // 
            // bClearGhostHotspots
            // 
            this.bClearGhostHotspots.Location = new System.Drawing.Point(142, 97);
            this.bClearGhostHotspots.Name = "bClearGhostHotspots";
            this.bClearGhostHotspots.Size = new System.Drawing.Size(44, 20);
            this.bClearGhostHotspots.TabIndex = 8;
            this.bClearGhostHotspots.Text = "Clear";
            this.bClearGhostHotspots.UseVisualStyleBackColor = true;
            this.bClearGhostHotspots.Click += new System.EventHandler(this.bClearGhostHotspots_Click);
            // 
            // tbGhostHotspots
            // 
            this.tbGhostHotspots.Enabled = false;
            this.tbGhostHotspots.Location = new System.Drawing.Point(6, 19);
            this.tbGhostHotspots.Multiline = true;
            this.tbGhostHotspots.Name = "tbGhostHotspots";
            this.tbGhostHotspots.Size = new System.Drawing.Size(243, 72);
            this.tbGhostHotspots.TabIndex = 9;
            // 
            // bAddGhostHotspot
            // 
            this.bAddGhostHotspot.Location = new System.Drawing.Point(92, 97);
            this.bAddGhostHotspot.Name = "bAddGhostHotspot";
            this.bAddGhostHotspot.Size = new System.Drawing.Size(44, 20);
            this.bAddGhostHotspot.TabIndex = 7;
            this.bAddGhostHotspot.Text = "Add";
            this.bAddGhostHotspot.UseVisualStyleBackColor = true;
            this.bAddGhostHotspot.Click += new System.EventHandler(this.bAddGhostHotspot_Click);
            // 
            // lGhostHotspotCount
            // 
            this.lGhostHotspotCount.AutoSize = true;
            this.lGhostHotspotCount.Location = new System.Drawing.Point(190, 101);
            this.lGhostHotspotCount.Name = "lGhostHotspotCount";
            this.lGhostHotspotCount.Size = new System.Drawing.Size(38, 13);
            this.lGhostHotspotCount.TabIndex = 10;
            this.lGhostHotspotCount.Text = "Count:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbRestockItems);
            this.groupBox4.Controls.Add(this.bAddRestockItem);
            this.groupBox4.Controls.Add(this.bClearRestockItems);
            this.groupBox4.Location = new System.Drawing.Point(410, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(135, 182);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Restock Items";
            // 
            // bgWorker_Recording
            // 
            this.bgWorker_Recording.WorkerSupportsCancellation = true;
            // 
            // GraphicalProfileCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(552, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grp_Ghost);
            this.Controls.Add(this.grp_Hotspots);
            this.Controls.Add(this.cbIgnoreZ);
            this.Controls.Add(this.lRecording);
            this.Controls.Add(this.gbVendor);
            this.Controls.Add(this.gbFaction);
            this.Controls.Add(this.bSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GraphicalProfileCreationForm";
            this.Text = "New Profile - Recording";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicalProfileCreationForm_FormClosing);
            this.gbVendor.ResumeLayout(false);
            this.gbVendor.PerformLayout();
            this.gbFaction.ResumeLayout(false);
            this.gbFaction.PerformLayout();
            this.grp_Hotspots.ResumeLayout(false);
            this.grp_Hotspots.PerformLayout();
            this.grp_Ghost.ResumeLayout(false);
            this.grp_Ghost.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox cbIgnoreZ;
        internal System.Windows.Forms.Label lAddPointAs;
        internal System.Windows.Forms.RadioButton rbWaypoint;
        internal System.Windows.Forms.RadioButton rbHotspot;
        internal System.Windows.Forms.Button bClearHotspots;
        internal System.Windows.Forms.TextBox tbHotspots;
        internal System.Windows.Forms.Label lHotspotCount;
        internal System.Windows.Forms.Button bAddHotspots;
        internal System.Windows.Forms.Button bClearRestockItems;
        internal System.Windows.Forms.Button bAddRestockItem;
        internal System.Windows.Forms.TextBox tbRestockItems;
        internal System.Windows.Forms.Label lRecording;
        internal System.Windows.Forms.GroupBox gbVendor;
        internal System.Windows.Forms.Button bClearVendor;
        internal System.Windows.Forms.Button bAddVendor;
        internal System.Windows.Forms.TextBox tbVendor;
        internal System.Windows.Forms.Label lVendor;
        internal System.Windows.Forms.Button bClearRestock;
        internal System.Windows.Forms.Button bAddRestock;
        internal System.Windows.Forms.Button bClearRepair;
        internal System.Windows.Forms.Button bAddRepair;
        internal System.Windows.Forms.TextBox tbRestock;
        internal System.Windows.Forms.TextBox tbRepair;
        internal System.Windows.Forms.Label lRestock;
        internal System.Windows.Forms.Label lRepair;
        internal System.Windows.Forms.GroupBox gbFaction;
        internal System.Windows.Forms.Button bClearFactions;
        internal System.Windows.Forms.Button bAddFaction;
        internal System.Windows.Forms.TextBox tbFactions;
        internal System.Windows.Forms.Label lFactionCount;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.GroupBox grp_Hotspots;
        private System.Windows.Forms.GroupBox grp_Ghost;
        internal System.Windows.Forms.Button bClearGhostHotspots;
        internal System.Windows.Forms.TextBox tbGhostHotspots;
        internal System.Windows.Forms.Button bAddGhostHotspot;
        internal System.Windows.Forms.Label lGhostHotspotCount;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Button btn_WaypointsAutoRecord;
        internal System.Windows.Forms.Button btn_GhostAutoRecord;
        private System.ComponentModel.BackgroundWorker bgWorker_Recording;
    }
}