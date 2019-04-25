namespace ZzukBot.Forms
{
    partial class GraphicalSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicalSettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.cbNinjaSkin = new System.Windows.Forms.CheckBox();
            this.cbLootUnits = new System.Windows.Forms.CheckBox();
            this.cbMine = new System.Windows.Forms.CheckBox();
            this.cbHerb = new System.Windows.Forms.CheckBox();
            this.cbSkinUnits = new System.Windows.Forms.CheckBox();
            this.cbNotifyRare = new System.Windows.Forms.CheckBox();
            this.cbStopOnRare = new System.Windows.Forms.CheckBox();
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.cbBeepName = new System.Windows.Forms.CheckBox();
            this.cbBeepSay = new System.Windows.Forms.CheckBox();
            this.cbBeepWhisper = new System.Windows.Forms.CheckBox();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.nudBreakFor = new System.Windows.Forms.NumericUpDown();
            this.lBreakFor = new System.Windows.Forms.Label();
            this.nudForceBreakAfter = new System.Windows.Forms.NumericUpDown();
            this.lForceBreak = new System.Windows.Forms.Label();
            this.nudWaypointModifier = new System.Windows.Forms.NumericUpDown();
            this.lWaypointModifier = new System.Windows.Forms.Label();
            this.tbProtectedItems = new System.Windows.Forms.TextBox();
            this.lProtectedItems = new System.Windows.Forms.Label();
            this.gbVendoring = new System.Windows.Forms.GroupBox();
            this.cbKeepQuality = new System.Windows.Forms.ComboBox();
            this.nudFreeSlots = new System.Windows.Forms.NumericUpDown();
            this.lKeepQuality = new System.Windows.Forms.Label();
            this.lFreeSlots = new System.Windows.Forms.Label();
            this.gbDistances = new System.Windows.Forms.GroupBox();
            this.nudRoamFromWp = new System.Windows.Forms.NumericUpDown();
            this.lRoamFromWp = new System.Windows.Forms.Label();
            this.nudCombatRange = new System.Windows.Forms.NumericUpDown();
            this.nudMobSearchRange = new System.Windows.Forms.NumericUpDown();
            this.lCombatRange = new System.Windows.Forms.Label();
            this.lMobSearchRange = new System.Windows.Forms.Label();
            this.gbRest = new System.Windows.Forms.GroupBox();
            this.tbPetFood = new System.Windows.Forms.TextBox();
            this.lPetFood = new System.Windows.Forms.Label();
            this.nudEatAt = new System.Windows.Forms.NumericUpDown();
            this.nudDrinkAt = new System.Windows.Forms.NumericUpDown();
            this.lEatAt = new System.Windows.Forms.Label();
            this.lDrinkAt = new System.Windows.Forms.Label();
            this.tbFood = new System.Windows.Forms.TextBox();
            this.lFood = new System.Windows.Forms.Label();
            this.tbDrink = new System.Windows.Forms.TextBox();
            this.lDrink = new System.Windows.Forms.Label();
            this.gbRelog = new System.Windows.Forms.GroupBox();
            this.txt_Character = new System.Windows.Forms.TextBox();
            this.lbl_desc3489 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.lAccount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lIRCDescription = new System.Windows.Forms.Label();
            this.tbIRCBotChannel = new System.Windows.Forms.TextBox();
            this.tbIRCBotNickname = new System.Windows.Forms.TextBox();
            this.cbIRCConnect = new System.Windows.Forms.CheckBox();
            this.lIrcBotname = new System.Windows.Forms.Label();
            this.lIrcChannel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbMisc.SuspendLayout();
            this.gbChat.SuspendLayout();
            this.gbOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreakFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBreakAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaypointModifier)).BeginInit();
            this.gbVendoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreeSlots)).BeginInit();
            this.gbDistances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoamFromWp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCombatRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMobSearchRange)).BeginInit();
            this.gbRest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEatAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrinkAt)).BeginInit();
            this.gbRelog.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 386);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gbMisc);
            this.tabPage1.Controls.Add(this.gbChat);
            this.tabPage1.Controls.Add(this.gbOther);
            this.tabPage1.Controls.Add(this.tbProtectedItems);
            this.tabPage1.Controls.Add(this.lProtectedItems);
            this.tabPage1.Controls.Add(this.gbVendoring);
            this.tabPage1.Controls.Add(this.gbDistances);
            this.tabPage1.Controls.Add(this.gbRest);
            this.tabPage1.Controls.Add(this.gbRelog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // gbMisc
            // 
            this.gbMisc.Controls.Add(this.cbNinjaSkin);
            this.gbMisc.Controls.Add(this.cbLootUnits);
            this.gbMisc.Controls.Add(this.cbMine);
            this.gbMisc.Controls.Add(this.cbHerb);
            this.gbMisc.Controls.Add(this.cbSkinUnits);
            this.gbMisc.Controls.Add(this.cbNotifyRare);
            this.gbMisc.Controls.Add(this.cbStopOnRare);
            this.gbMisc.Location = new System.Drawing.Point(478, 133);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(110, 220);
            this.gbMisc.TabIndex = 25;
            this.gbMisc.TabStop = false;
            this.gbMisc.Text = "Misc";
            // 
            // cbNinjaSkin
            // 
            this.cbNinjaSkin.AutoSize = true;
            this.cbNinjaSkin.Location = new System.Drawing.Point(4, 89);
            this.cbNinjaSkin.Name = "cbNinjaSkin";
            this.cbNinjaSkin.Size = new System.Drawing.Size(74, 17);
            this.cbNinjaSkin.TabIndex = 6;
            this.cbNinjaSkin.Text = "Ninja Skin";
            this.cbNinjaSkin.UseVisualStyleBackColor = true;
            // 
            // cbLootUnits
            // 
            this.cbLootUnits.AutoSize = true;
            this.cbLootUnits.Checked = true;
            this.cbLootUnits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLootUnits.Location = new System.Drawing.Point(4, 158);
            this.cbLootUnits.Name = "cbLootUnits";
            this.cbLootUnits.Size = new System.Drawing.Size(74, 17);
            this.cbLootUnits.TabIndex = 5;
            this.cbLootUnits.Text = "Loot Units";
            this.cbLootUnits.UseVisualStyleBackColor = true;
            // 
            // cbMine
            // 
            this.cbMine.AutoSize = true;
            this.cbMine.Location = new System.Drawing.Point(4, 135);
            this.cbMine.Name = "cbMine";
            this.cbMine.Size = new System.Drawing.Size(49, 17);
            this.cbMine.TabIndex = 4;
            this.cbMine.Text = "Mine";
            this.cbMine.UseVisualStyleBackColor = true;
            // 
            // cbHerb
            // 
            this.cbHerb.AutoSize = true;
            this.cbHerb.Location = new System.Drawing.Point(4, 112);
            this.cbHerb.Name = "cbHerb";
            this.cbHerb.Size = new System.Drawing.Size(49, 17);
            this.cbHerb.TabIndex = 3;
            this.cbHerb.Text = "Herb";
            this.cbHerb.UseVisualStyleBackColor = true;
            // 
            // cbSkinUnits
            // 
            this.cbSkinUnits.AutoSize = true;
            this.cbSkinUnits.Location = new System.Drawing.Point(4, 66);
            this.cbSkinUnits.Name = "cbSkinUnits";
            this.cbSkinUnits.Size = new System.Drawing.Size(74, 17);
            this.cbSkinUnits.TabIndex = 2;
            this.cbSkinUnits.Text = "Skin Units";
            this.cbSkinUnits.UseVisualStyleBackColor = true;
            // 
            // cbNotifyRare
            // 
            this.cbNotifyRare.AutoSize = true;
            this.cbNotifyRare.Location = new System.Drawing.Point(4, 43);
            this.cbNotifyRare.Name = "cbNotifyRare";
            this.cbNotifyRare.Size = new System.Drawing.Size(89, 17);
            this.cbNotifyRare.TabIndex = 1;
            this.cbNotifyRare.Text = "Notify on rare";
            this.cbNotifyRare.UseVisualStyleBackColor = true;
            // 
            // cbStopOnRare
            // 
            this.cbStopOnRare.AutoSize = true;
            this.cbStopOnRare.Location = new System.Drawing.Point(4, 20);
            this.cbStopOnRare.Name = "cbStopOnRare";
            this.cbStopOnRare.Size = new System.Drawing.Size(84, 17);
            this.cbStopOnRare.TabIndex = 0;
            this.cbStopOnRare.Text = "Stop on rare";
            this.cbStopOnRare.UseVisualStyleBackColor = true;
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.cbBeepName);
            this.gbChat.Controls.Add(this.cbBeepSay);
            this.gbChat.Controls.Add(this.cbBeepWhisper);
            this.gbChat.Location = new System.Drawing.Point(475, 16);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(110, 111);
            this.gbChat.TabIndex = 24;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "Chat";
            // 
            // cbBeepName
            // 
            this.cbBeepName.AutoSize = true;
            this.cbBeepName.Location = new System.Drawing.Point(4, 64);
            this.cbBeepName.Name = "cbBeepName";
            this.cbBeepName.Size = new System.Drawing.Size(95, 17);
            this.cbBeepName.TabIndex = 2;
            this.cbBeepName.Text = "Beep on name";
            this.cbBeepName.UseVisualStyleBackColor = true;
            // 
            // cbBeepSay
            // 
            this.cbBeepSay.AutoSize = true;
            this.cbBeepSay.Location = new System.Drawing.Point(4, 42);
            this.cbBeepSay.Name = "cbBeepSay";
            this.cbBeepSay.Size = new System.Drawing.Size(85, 17);
            this.cbBeepSay.TabIndex = 1;
            this.cbBeepSay.Text = "Beep on say";
            this.cbBeepSay.UseVisualStyleBackColor = true;
            // 
            // cbBeepWhisper
            // 
            this.cbBeepWhisper.AutoSize = true;
            this.cbBeepWhisper.Location = new System.Drawing.Point(4, 20);
            this.cbBeepWhisper.Name = "cbBeepWhisper";
            this.cbBeepWhisper.Size = new System.Drawing.Size(105, 17);
            this.cbBeepWhisper.TabIndex = 0;
            this.cbBeepWhisper.Text = "Beep on whisper";
            this.cbBeepWhisper.UseVisualStyleBackColor = true;
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.nudBreakFor);
            this.gbOther.Controls.Add(this.lBreakFor);
            this.gbOther.Controls.Add(this.nudForceBreakAfter);
            this.gbOther.Controls.Add(this.lForceBreak);
            this.gbOther.Controls.Add(this.nudWaypointModifier);
            this.gbOther.Controls.Add(this.lWaypointModifier);
            this.gbOther.Location = new System.Drawing.Point(228, 194);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(187, 119);
            this.gbOther.TabIndex = 22;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other";
            // 
            // nudBreakFor
            // 
            this.nudBreakFor.Location = new System.Drawing.Point(102, 70);
            this.nudBreakFor.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudBreakFor.Name = "nudBreakFor";
            this.nudBreakFor.Size = new System.Drawing.Size(71, 20);
            this.nudBreakFor.TabIndex = 15;
            // 
            // lBreakFor
            // 
            this.lBreakFor.AutoSize = true;
            this.lBreakFor.Location = new System.Drawing.Point(4, 72);
            this.lBreakFor.Name = "lBreakFor";
            this.lBreakFor.Size = new System.Drawing.Size(50, 13);
            this.lBreakFor.TabIndex = 14;
            this.lBreakFor.Text = "Break for";
            // 
            // nudForceBreakAfter
            // 
            this.nudForceBreakAfter.Location = new System.Drawing.Point(102, 44);
            this.nudForceBreakAfter.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudForceBreakAfter.Name = "nudForceBreakAfter";
            this.nudForceBreakAfter.Size = new System.Drawing.Size(71, 20);
            this.nudForceBreakAfter.TabIndex = 13;
            // 
            // lForceBreak
            // 
            this.lForceBreak.AutoSize = true;
            this.lForceBreak.Location = new System.Drawing.Point(4, 46);
            this.lForceBreak.Name = "lForceBreak";
            this.lForceBreak.Size = new System.Drawing.Size(89, 13);
            this.lForceBreak.TabIndex = 12;
            this.lForceBreak.Text = "Force Break after";
            // 
            // nudWaypointModifier
            // 
            this.nudWaypointModifier.DecimalPlaces = 1;
            this.nudWaypointModifier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWaypointModifier.Location = new System.Drawing.Point(102, 18);
            this.nudWaypointModifier.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudWaypointModifier.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.nudWaypointModifier.Name = "nudWaypointModifier";
            this.nudWaypointModifier.Size = new System.Drawing.Size(71, 20);
            this.nudWaypointModifier.TabIndex = 11;
            // 
            // lWaypointModifier
            // 
            this.lWaypointModifier.AutoSize = true;
            this.lWaypointModifier.Location = new System.Drawing.Point(4, 20);
            this.lWaypointModifier.Name = "lWaypointModifier";
            this.lWaypointModifier.Size = new System.Drawing.Size(92, 13);
            this.lWaypointModifier.TabIndex = 1;
            this.lWaypointModifier.Text = "Waypoint Modifier";
            // 
            // tbProtectedItems
            // 
            this.tbProtectedItems.Location = new System.Drawing.Point(9, 132);
            this.tbProtectedItems.Multiline = true;
            this.tbProtectedItems.Name = "tbProtectedItems";
            this.tbProtectedItems.Size = new System.Drawing.Size(136, 108);
            this.tbProtectedItems.TabIndex = 20;
            // 
            // lProtectedItems
            // 
            this.lProtectedItems.AutoSize = true;
            this.lProtectedItems.Location = new System.Drawing.Point(21, 109);
            this.lProtectedItems.Name = "lProtectedItems";
            this.lProtectedItems.Size = new System.Drawing.Size(81, 13);
            this.lProtectedItems.TabIndex = 19;
            this.lProtectedItems.Text = "Protected Items";
            // 
            // gbVendoring
            // 
            this.gbVendoring.Controls.Add(this.cbKeepQuality);
            this.gbVendoring.Controls.Add(this.nudFreeSlots);
            this.gbVendoring.Controls.Add(this.lKeepQuality);
            this.gbVendoring.Controls.Add(this.lFreeSlots);
            this.gbVendoring.Location = new System.Drawing.Point(6, 246);
            this.gbVendoring.Name = "gbVendoring";
            this.gbVendoring.Size = new System.Drawing.Size(167, 88);
            this.gbVendoring.TabIndex = 18;
            this.gbVendoring.TabStop = false;
            this.gbVendoring.Text = "Vendoring";
            // 
            // cbKeepQuality
            // 
            this.cbKeepQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeepQuality.FormattingEnabled = true;
            this.cbKeepQuality.Items.AddRange(new object[] {
            "White",
            "Green",
            "Blue",
            "Epic"});
            this.cbKeepQuality.Location = new System.Drawing.Point(65, 51);
            this.cbKeepQuality.Name = "cbKeepQuality";
            this.cbKeepQuality.Size = new System.Drawing.Size(73, 21);
            this.cbKeepQuality.TabIndex = 7;
            // 
            // nudFreeSlots
            // 
            this.nudFreeSlots.Location = new System.Drawing.Point(65, 26);
            this.nudFreeSlots.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudFreeSlots.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFreeSlots.Name = "nudFreeSlots";
            this.nudFreeSlots.Size = new System.Drawing.Size(71, 20);
            this.nudFreeSlots.TabIndex = 6;
            this.nudFreeSlots.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lKeepQuality
            // 
            this.lKeepQuality.AutoSize = true;
            this.lKeepQuality.Location = new System.Drawing.Point(4, 54);
            this.lKeepQuality.Name = "lKeepQuality";
            this.lKeepQuality.Size = new System.Drawing.Size(55, 13);
            this.lKeepQuality.TabIndex = 5;
            this.lKeepQuality.Text = "Keep from";
            // 
            // lFreeSlots
            // 
            this.lFreeSlots.AutoSize = true;
            this.lFreeSlots.Location = new System.Drawing.Point(4, 28);
            this.lFreeSlots.Name = "lFreeSlots";
            this.lFreeSlots.Size = new System.Drawing.Size(54, 13);
            this.lFreeSlots.TabIndex = 4;
            this.lFreeSlots.Text = "Free Slots";
            // 
            // gbDistances
            // 
            this.gbDistances.Controls.Add(this.nudRoamFromWp);
            this.gbDistances.Controls.Add(this.lRoamFromWp);
            this.gbDistances.Controls.Add(this.nudCombatRange);
            this.gbDistances.Controls.Add(this.nudMobSearchRange);
            this.gbDistances.Controls.Add(this.lCombatRange);
            this.gbDistances.Controls.Add(this.lMobSearchRange);
            this.gbDistances.Location = new System.Drawing.Point(333, 11);
            this.gbDistances.Name = "gbDistances";
            this.gbDistances.Size = new System.Drawing.Size(136, 152);
            this.gbDistances.TabIndex = 17;
            this.gbDistances.TabStop = false;
            this.gbDistances.Text = "Distances";
            // 
            // nudRoamFromWp
            // 
            this.nudRoamFromWp.Location = new System.Drawing.Point(7, 119);
            this.nudRoamFromWp.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudRoamFromWp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoamFromWp.Name = "nudRoamFromWp";
            this.nudRoamFromWp.Size = new System.Drawing.Size(71, 20);
            this.nudRoamFromWp.TabIndex = 10;
            this.nudRoamFromWp.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lRoamFromWp
            // 
            this.lRoamFromWp.AutoSize = true;
            this.lRoamFromWp.Location = new System.Drawing.Point(4, 103);
            this.lRoamFromWp.Name = "lRoamFromWp";
            this.lRoamFromWp.Size = new System.Drawing.Size(109, 13);
            this.lRoamFromWp.TabIndex = 9;
            this.lRoamFromWp.Text = "Roam From Waypoint";
            // 
            // nudCombatRange
            // 
            this.nudCombatRange.Location = new System.Drawing.Point(7, 78);
            this.nudCombatRange.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudCombatRange.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCombatRange.Name = "nudCombatRange";
            this.nudCombatRange.Size = new System.Drawing.Size(71, 20);
            this.nudCombatRange.TabIndex = 8;
            this.nudCombatRange.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudMobSearchRange
            // 
            this.nudMobSearchRange.Location = new System.Drawing.Point(7, 36);
            this.nudMobSearchRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMobSearchRange.Name = "nudMobSearchRange";
            this.nudMobSearchRange.Size = new System.Drawing.Size(71, 20);
            this.nudMobSearchRange.TabIndex = 7;
            this.nudMobSearchRange.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lCombatRange
            // 
            this.lCombatRange.AutoSize = true;
            this.lCombatRange.Location = new System.Drawing.Point(4, 62);
            this.lCombatRange.Name = "lCombatRange";
            this.lCombatRange.Size = new System.Drawing.Size(78, 13);
            this.lCombatRange.TabIndex = 3;
            this.lCombatRange.Text = "Combat Range";
            // 
            // lMobSearchRange
            // 
            this.lMobSearchRange.AutoSize = true;
            this.lMobSearchRange.Location = new System.Drawing.Point(4, 20);
            this.lMobSearchRange.Name = "lMobSearchRange";
            this.lMobSearchRange.Size = new System.Drawing.Size(99, 13);
            this.lMobSearchRange.TabIndex = 1;
            this.lMobSearchRange.Text = "Search mob Range";
            // 
            // gbRest
            // 
            this.gbRest.Controls.Add(this.tbPetFood);
            this.gbRest.Controls.Add(this.lPetFood);
            this.gbRest.Controls.Add(this.nudEatAt);
            this.gbRest.Controls.Add(this.nudDrinkAt);
            this.gbRest.Controls.Add(this.lEatAt);
            this.gbRest.Controls.Add(this.lDrinkAt);
            this.gbRest.Controls.Add(this.tbFood);
            this.gbRest.Controls.Add(this.lFood);
            this.gbRest.Controls.Add(this.tbDrink);
            this.gbRest.Controls.Add(this.lDrink);
            this.gbRest.Location = new System.Drawing.Point(160, 6);
            this.gbRest.Name = "gbRest";
            this.gbRest.Size = new System.Drawing.Size(167, 157);
            this.gbRest.TabIndex = 16;
            this.gbRest.TabStop = false;
            this.gbRest.Text = "Rest";
            // 
            // tbPetFood
            // 
            this.tbPetFood.Location = new System.Drawing.Point(65, 122);
            this.tbPetFood.Name = "tbPetFood";
            this.tbPetFood.Size = new System.Drawing.Size(71, 20);
            this.tbPetFood.TabIndex = 8;
            // 
            // lPetFood
            // 
            this.lPetFood.AutoSize = true;
            this.lPetFood.Location = new System.Drawing.Point(4, 125);
            this.lPetFood.Name = "lPetFood";
            this.lPetFood.Size = new System.Drawing.Size(50, 13);
            this.lPetFood.TabIndex = 9;
            this.lPetFood.Text = "Pet Food";
            // 
            // nudEatAt
            // 
            this.nudEatAt.Location = new System.Drawing.Point(65, 43);
            this.nudEatAt.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudEatAt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEatAt.Name = "nudEatAt";
            this.nudEatAt.Size = new System.Drawing.Size(71, 20);
            this.nudEatAt.TabIndex = 7;
            this.nudEatAt.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudDrinkAt
            // 
            this.nudDrinkAt.Location = new System.Drawing.Point(65, 17);
            this.nudDrinkAt.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudDrinkAt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDrinkAt.Name = "nudDrinkAt";
            this.nudDrinkAt.Size = new System.Drawing.Size(71, 20);
            this.nudDrinkAt.TabIndex = 6;
            this.nudDrinkAt.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // lEatAt
            // 
            this.lEatAt.AutoSize = true;
            this.lEatAt.Location = new System.Drawing.Point(4, 42);
            this.lEatAt.Name = "lEatAt";
            this.lEatAt.Size = new System.Drawing.Size(46, 13);
            this.lEatAt.TabIndex = 5;
            this.lEatAt.Text = "Eat at %";
            // 
            // lDrinkAt
            // 
            this.lDrinkAt.AutoSize = true;
            this.lDrinkAt.Location = new System.Drawing.Point(4, 20);
            this.lDrinkAt.Name = "lDrinkAt";
            this.lDrinkAt.Size = new System.Drawing.Size(55, 13);
            this.lDrinkAt.TabIndex = 4;
            this.lDrinkAt.Text = "Drink at %";
            // 
            // tbFood
            // 
            this.tbFood.Location = new System.Drawing.Point(65, 95);
            this.tbFood.Name = "tbFood";
            this.tbFood.Size = new System.Drawing.Size(71, 20);
            this.tbFood.TabIndex = 2;
            // 
            // lFood
            // 
            this.lFood.AutoSize = true;
            this.lFood.Location = new System.Drawing.Point(4, 98);
            this.lFood.Name = "lFood";
            this.lFood.Size = new System.Drawing.Size(31, 13);
            this.lFood.TabIndex = 3;
            this.lFood.Text = "Food";
            // 
            // tbDrink
            // 
            this.tbDrink.Location = new System.Drawing.Point(65, 69);
            this.tbDrink.Name = "tbDrink";
            this.tbDrink.Size = new System.Drawing.Size(71, 20);
            this.tbDrink.TabIndex = 0;
            // 
            // lDrink
            // 
            this.lDrink.AutoSize = true;
            this.lDrink.Location = new System.Drawing.Point(4, 69);
            this.lDrink.Name = "lDrink";
            this.lDrink.Size = new System.Drawing.Size(32, 13);
            this.lDrink.TabIndex = 1;
            this.lDrink.Text = "Drink";
            // 
            // gbRelog
            // 
            this.gbRelog.Controls.Add(this.txt_Character);
            this.gbRelog.Controls.Add(this.lbl_desc3489);
            this.gbRelog.Controls.Add(this.tbPassword);
            this.gbRelog.Controls.Add(this.lPassword);
            this.gbRelog.Controls.Add(this.tbAccount);
            this.gbRelog.Controls.Add(this.lAccount);
            this.gbRelog.Location = new System.Drawing.Point(17, 6);
            this.gbRelog.Name = "gbRelog";
            this.gbRelog.Size = new System.Drawing.Size(136, 100);
            this.gbRelog.TabIndex = 14;
            this.gbRelog.TabStop = false;
            this.gbRelog.Text = "Relog";
            // 
            // txt_Character
            // 
            this.txt_Character.Location = new System.Drawing.Point(57, 69);
            this.txt_Character.Name = "txt_Character";
            this.txt_Character.Size = new System.Drawing.Size(71, 20);
            this.txt_Character.TabIndex = 5;
            // 
            // lbl_desc3489
            // 
            this.lbl_desc3489.AutoSize = true;
            this.lbl_desc3489.Location = new System.Drawing.Point(4, 72);
            this.lbl_desc3489.Name = "lbl_desc3489";
            this.lbl_desc3489.Size = new System.Drawing.Size(53, 13);
            this.lbl_desc3489.TabIndex = 4;
            this.lbl_desc3489.Text = "Character";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(57, 43);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(71, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(4, 46);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(53, 13);
            this.lPassword.TabIndex = 3;
            this.lPassword.Text = "Password";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(57, 17);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(71, 20);
            this.tbAccount.TabIndex = 0;
            // 
            // lAccount
            // 
            this.lAccount.AutoSize = true;
            this.lAccount.Location = new System.Drawing.Point(4, 20);
            this.lAccount.Name = "lAccount";
            this.lAccount.Size = new System.Drawing.Size(47, 13);
            this.lAccount.TabIndex = 1;
            this.lAccount.Text = "Account";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lIRCDescription);
            this.tabPage2.Controls.Add(this.tbIRCBotChannel);
            this.tabPage2.Controls.Add(this.tbIRCBotNickname);
            this.tabPage2.Controls.Add(this.cbIRCConnect);
            this.tabPage2.Controls.Add(this.lIrcBotname);
            this.tabPage2.Controls.Add(this.lIrcChannel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IRC";
            // 
            // lIRCDescription
            // 
            this.lIRCDescription.AutoSize = true;
            this.lIRCDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIRCDescription.Location = new System.Drawing.Point(8, 114);
            this.lIRCDescription.Name = "lIRCDescription";
            this.lIRCDescription.Size = new System.Drawing.Size(409, 208);
            this.lIRCDescription.TabIndex = 11;
            this.lIRCDescription.Text = resources.GetString("lIRCDescription.Text");
            // 
            // tbIRCBotChannel
            // 
            this.tbIRCBotChannel.Location = new System.Drawing.Point(103, 35);
            this.tbIRCBotChannel.Name = "tbIRCBotChannel";
            this.tbIRCBotChannel.Size = new System.Drawing.Size(114, 20);
            this.tbIRCBotChannel.TabIndex = 10;
            // 
            // tbIRCBotNickname
            // 
            this.tbIRCBotNickname.Location = new System.Drawing.Point(103, 9);
            this.tbIRCBotNickname.Name = "tbIRCBotNickname";
            this.tbIRCBotNickname.Size = new System.Drawing.Size(114, 20);
            this.tbIRCBotNickname.TabIndex = 9;
            // 
            // cbIRCConnect
            // 
            this.cbIRCConnect.AutoCheck = false;
            this.cbIRCConnect.AutoSize = true;
            this.cbIRCConnect.Location = new System.Drawing.Point(8, 64);
            this.cbIRCConnect.Name = "cbIRCConnect";
            this.cbIRCConnect.Size = new System.Drawing.Size(99, 17);
            this.cbIRCConnect.TabIndex = 8;
            this.cbIRCConnect.Text = "Connect to IRC";
            this.cbIRCConnect.UseVisualStyleBackColor = true;
            // 
            // lIrcBotname
            // 
            this.lIrcBotname.AutoSize = true;
            this.lIrcBotname.Location = new System.Drawing.Point(8, 12);
            this.lIrcBotname.Name = "lIrcBotname";
            this.lIrcBotname.Size = new System.Drawing.Size(89, 13);
            this.lIrcBotname.TabIndex = 7;
            this.lIrcBotname.Text = "Nickname of Bot:";
            // 
            // lIrcChannel
            // 
            this.lIrcChannel.AutoSize = true;
            this.lIrcChannel.Location = new System.Drawing.Point(8, 38);
            this.lIrcChannel.Name = "lIrcChannel";
            this.lIrcChannel.Size = new System.Drawing.Size(49, 13);
            this.lIrcChannel.TabIndex = 6;
            this.lIrcChannel.Text = "Channel:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 416);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.newProfileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // newProfileToolStripMenuItem
            // 
            this.newProfileToolStripMenuItem.Name = "newProfileToolStripMenuItem";
            this.newProfileToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.newProfileToolStripMenuItem.Text = "New Profile";
            this.newProfileToolStripMenuItem.Click += new System.EventHandler(this.newProfileToolStripMenuItem_Click);
            // 
            // GraphicalSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 416);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphicalSettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicalSettingsForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbMisc.ResumeLayout(false);
            this.gbMisc.PerformLayout();
            this.gbChat.ResumeLayout(false);
            this.gbChat.PerformLayout();
            this.gbOther.ResumeLayout(false);
            this.gbOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreakFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBreakAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaypointModifier)).EndInit();
            this.gbVendoring.ResumeLayout(false);
            this.gbVendoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreeSlots)).EndInit();
            this.gbDistances.ResumeLayout(false);
            this.gbDistances.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoamFromWp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCombatRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMobSearchRange)).EndInit();
            this.gbRest.ResumeLayout(false);
            this.gbRest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEatAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrinkAt)).EndInit();
            this.gbRelog.ResumeLayout(false);
            this.gbRelog.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lIRCDescription;
        internal System.Windows.Forms.TextBox tbIRCBotChannel;
        internal System.Windows.Forms.TextBox tbIRCBotNickname;
        internal System.Windows.Forms.CheckBox cbIRCConnect;
        private System.Windows.Forms.Label lIrcBotname;
        private System.Windows.Forms.Label lIrcChannel;
        private System.Windows.Forms.GroupBox gbMisc;
        internal System.Windows.Forms.CheckBox cbNinjaSkin;
        internal System.Windows.Forms.CheckBox cbLootUnits;
        internal System.Windows.Forms.CheckBox cbMine;
        internal System.Windows.Forms.CheckBox cbHerb;
        internal System.Windows.Forms.CheckBox cbSkinUnits;
        internal System.Windows.Forms.CheckBox cbNotifyRare;
        internal System.Windows.Forms.CheckBox cbStopOnRare;
        private System.Windows.Forms.GroupBox gbChat;
        internal System.Windows.Forms.CheckBox cbBeepName;
        internal System.Windows.Forms.CheckBox cbBeepSay;
        internal System.Windows.Forms.CheckBox cbBeepWhisper;
        private System.Windows.Forms.GroupBox gbOther;
        internal System.Windows.Forms.NumericUpDown nudBreakFor;
        private System.Windows.Forms.Label lBreakFor;
        internal System.Windows.Forms.NumericUpDown nudForceBreakAfter;
        private System.Windows.Forms.Label lForceBreak;
        internal System.Windows.Forms.NumericUpDown nudWaypointModifier;
        private System.Windows.Forms.Label lWaypointModifier;
        internal System.Windows.Forms.TextBox tbProtectedItems;
        private System.Windows.Forms.Label lProtectedItems;
        private System.Windows.Forms.GroupBox gbVendoring;
        internal System.Windows.Forms.ComboBox cbKeepQuality;
        internal System.Windows.Forms.NumericUpDown nudFreeSlots;
        private System.Windows.Forms.Label lKeepQuality;
        private System.Windows.Forms.Label lFreeSlots;
        private System.Windows.Forms.GroupBox gbDistances;
        internal System.Windows.Forms.NumericUpDown nudRoamFromWp;
        private System.Windows.Forms.Label lRoamFromWp;
        internal System.Windows.Forms.NumericUpDown nudCombatRange;
        internal System.Windows.Forms.NumericUpDown nudMobSearchRange;
        private System.Windows.Forms.Label lCombatRange;
        private System.Windows.Forms.Label lMobSearchRange;
        private System.Windows.Forms.GroupBox gbRest;
        internal System.Windows.Forms.TextBox tbPetFood;
        private System.Windows.Forms.Label lPetFood;
        internal System.Windows.Forms.NumericUpDown nudEatAt;
        internal System.Windows.Forms.NumericUpDown nudDrinkAt;
        private System.Windows.Forms.Label lEatAt;
        private System.Windows.Forms.Label lDrinkAt;
        internal System.Windows.Forms.TextBox tbFood;
        private System.Windows.Forms.Label lFood;
        internal System.Windows.Forms.TextBox tbDrink;
        private System.Windows.Forms.Label lDrink;
        private System.Windows.Forms.GroupBox gbRelog;
        internal System.Windows.Forms.TextBox txt_Character;
        private System.Windows.Forms.Label lbl_desc3489;
        internal System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
        internal System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label lAccount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProfileToolStripMenuItem;
    }
}