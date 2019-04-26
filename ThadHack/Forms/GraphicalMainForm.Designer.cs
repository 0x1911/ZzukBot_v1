namespace ZzukBot.Forms
{
    partial class GraphicalMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicalMainForm));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGrind = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pBar_targetHealth = new ZzukBot.Helpers.NewProgressBar();
            this.lbl_targetId = new System.Windows.Forms.Label();
            this.lbl_targetFaction = new System.Windows.Forms.Label();
            this.lbl_targetZ = new System.Windows.Forms.Label();
            this.lbl_targetY = new System.Windows.Forms.Label();
            this.lbl_targetX = new System.Windows.Forms.Label();
            this.lbl_targetName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pBar_playerExperience = new ZzukBot.Helpers.NewProgressBar();
            this.pBar_playerMana = new ZzukBot.Helpers.NewProgressBar();
            this.pBar_playerHealth = new ZzukBot.Helpers.NewProgressBar();
            this.lbl_playerSubZone = new System.Windows.Forms.Label();
            this.lbl_playerZone = new System.Windows.Forms.Label();
            this.lbl_playerAccountName = new System.Windows.Forms.Label();
            this.lbl_playerRealm = new System.Windows.Forms.Label();
            this.lbl_playerNickName = new System.Windows.Forms.Label();
            this.lbl_playerZ = new System.Windows.Forms.Label();
            this.lbl_playerY = new System.Windows.Forms.Label();
            this.lbl_playerX = new System.Windows.Forms.Label();
            this.lGrindLoadProfile = new System.Windows.Forms.Label();
            this.cbLoadLastProfile = new System.Windows.Forms.CheckBox();
            this.lGrindState = new System.Windows.Forms.Label();
            this.tC_Log = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tp_InGameChat = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgChat = new System.Windows.Forms.DataGridView();
            this.dType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bClearChatLog = new System.Windows.Forms.Button();
            this.tpNotifications = new System.Windows.Forms.TabPage();
            this.dgNotifications = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dEVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tcMain.SuspendLayout();
            this.tpGrind.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tC_Log.SuspendLayout();
            this.tp_InGameChat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChat)).BeginInit();
            this.tpNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNotifications)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGrind);
            this.tcMain.Controls.Add(this.tp_InGameChat);
            this.tcMain.Controls.Add(this.tpNotifications);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(4, 34);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(382, 491);
            this.tcMain.TabIndex = 0;
            // 
            // tpGrind
            // 
            this.tpGrind.BackColor = System.Drawing.SystemColors.Control;
            this.tpGrind.Controls.Add(this.tableLayoutPanel2);
            this.tpGrind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpGrind.Location = new System.Drawing.Point(4, 25);
            this.tpGrind.Margin = new System.Windows.Forms.Padding(4);
            this.tpGrind.Name = "tpGrind";
            this.tpGrind.Padding = new System.Windows.Forms.Padding(1);
            this.tpGrind.Size = new System.Drawing.Size(374, 462);
            this.tpGrind.TabIndex = 0;
            this.tpGrind.Text = "Overview";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tC_Log, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(372, 460);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.lGrindLoadProfile);
            this.panel1.Controls.Add(this.cbLoadLastProfile);
            this.panel1.Controls.Add(this.lGrindState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 314);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pBar_targetHealth);
            this.groupBox3.Controls.Add(this.lbl_targetId);
            this.groupBox3.Controls.Add(this.lbl_targetFaction);
            this.groupBox3.Controls.Add(this.lbl_targetZ);
            this.groupBox3.Controls.Add(this.lbl_targetY);
            this.groupBox3.Controls.Add(this.lbl_targetX);
            this.groupBox3.Controls.Add(this.lbl_targetName);
            this.groupBox3.Location = new System.Drawing.Point(183, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(170, 241);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target";
            // 
            // pBar_targetHealth
            // 
            this.pBar_targetHealth.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_targetHealth.ForeColor = System.Drawing.Color.Green;
            this.pBar_targetHealth.Location = new System.Drawing.Point(11, 82);
            this.pBar_targetHealth.Name = "pBar_targetHealth";
            this.pBar_targetHealth.Size = new System.Drawing.Size(146, 14);
            this.pBar_targetHealth.TabIndex = 19;
            // 
            // lbl_targetId
            // 
            this.lbl_targetId.AutoSize = true;
            this.lbl_targetId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetId.Location = new System.Drawing.Point(8, 112);
            this.lbl_targetId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetId.Name = "lbl_targetId";
            this.lbl_targetId.Size = new System.Drawing.Size(28, 13);
            this.lbl_targetId.TabIndex = 18;
            this.lbl_targetId.Text = "Id: 0";
            // 
            // lbl_targetFaction
            // 
            this.lbl_targetFaction.AutoSize = true;
            this.lbl_targetFaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetFaction.Location = new System.Drawing.Point(8, 96);
            this.lbl_targetFaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetFaction.Name = "lbl_targetFaction";
            this.lbl_targetFaction.Size = new System.Drawing.Size(54, 13);
            this.lbl_targetFaction.TabIndex = 17;
            this.lbl_targetFaction.Text = "Faction: 0";
            // 
            // lbl_targetZ
            // 
            this.lbl_targetZ.AutoSize = true;
            this.lbl_targetZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetZ.Location = new System.Drawing.Point(8, 52);
            this.lbl_targetZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetZ.Name = "lbl_targetZ";
            this.lbl_targetZ.Size = new System.Drawing.Size(26, 13);
            this.lbl_targetZ.TabIndex = 16;
            this.lbl_targetZ.Text = "Z: 0";
            // 
            // lbl_targetY
            // 
            this.lbl_targetY.AutoSize = true;
            this.lbl_targetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetY.Location = new System.Drawing.Point(8, 36);
            this.lbl_targetY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetY.Name = "lbl_targetY";
            this.lbl_targetY.Size = new System.Drawing.Size(26, 13);
            this.lbl_targetY.TabIndex = 15;
            this.lbl_targetY.Text = "Y: 0";
            // 
            // lbl_targetX
            // 
            this.lbl_targetX.AutoSize = true;
            this.lbl_targetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetX.Location = new System.Drawing.Point(8, 20);
            this.lbl_targetX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetX.Name = "lbl_targetX";
            this.lbl_targetX.Size = new System.Drawing.Size(26, 13);
            this.lbl_targetX.TabIndex = 14;
            this.lbl_targetX.Text = "X: 0";
            // 
            // lbl_targetName
            // 
            this.lbl_targetName.AutoSize = true;
            this.lbl_targetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetName.Location = new System.Drawing.Point(8, 156);
            this.lbl_targetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_targetName.Name = "lbl_targetName";
            this.lbl_targetName.Size = new System.Drawing.Size(85, 13);
            this.lbl_targetName.TabIndex = 12;
            this.lbl_targetName.Text = "Name: unknown";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pBar_playerExperience);
            this.groupBox2.Controls.Add(this.pBar_playerMana);
            this.groupBox2.Controls.Add(this.pBar_playerHealth);
            this.groupBox2.Controls.Add(this.lbl_playerSubZone);
            this.groupBox2.Controls.Add(this.lbl_playerZone);
            this.groupBox2.Controls.Add(this.lbl_playerAccountName);
            this.groupBox2.Controls.Add(this.lbl_playerRealm);
            this.groupBox2.Controls.Add(this.lbl_playerNickName);
            this.groupBox2.Controls.Add(this.lbl_playerZ);
            this.groupBox2.Controls.Add(this.lbl_playerY);
            this.groupBox2.Controls.Add(this.lbl_playerX);
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(170, 241);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player";
            // 
            // pBar_playerExperience
            // 
            this.pBar_playerExperience.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_playerExperience.ForeColor = System.Drawing.Color.Yellow;
            this.pBar_playerExperience.Location = new System.Drawing.Point(11, 114);
            this.pBar_playerExperience.Name = "pBar_playerExperience";
            this.pBar_playerExperience.Size = new System.Drawing.Size(146, 14);
            this.pBar_playerExperience.TabIndex = 18;
            // 
            // pBar_playerMana
            // 
            this.pBar_playerMana.Location = new System.Drawing.Point(11, 98);
            this.pBar_playerMana.Name = "pBar_playerMana";
            this.pBar_playerMana.Size = new System.Drawing.Size(146, 14);
            this.pBar_playerMana.TabIndex = 17;
            // 
            // pBar_playerHealth
            // 
            this.pBar_playerHealth.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_playerHealth.ForeColor = System.Drawing.Color.Green;
            this.pBar_playerHealth.Location = new System.Drawing.Point(11, 82);
            this.pBar_playerHealth.Name = "pBar_playerHealth";
            this.pBar_playerHealth.Size = new System.Drawing.Size(146, 14);
            this.pBar_playerHealth.TabIndex = 16;
            // 
            // lbl_playerSubZone
            // 
            this.lbl_playerSubZone.AutoSize = true;
            this.lbl_playerSubZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerSubZone.Location = new System.Drawing.Point(8, 214);
            this.lbl_playerSubZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerSubZone.Name = "lbl_playerSubZone";
            this.lbl_playerSubZone.Size = new System.Drawing.Size(106, 13);
            this.lbl_playerSubZone.TabIndex = 15;
            this.lbl_playerSubZone.Text = "Sub-Zone: Unknown";
            // 
            // lbl_playerZone
            // 
            this.lbl_playerZone.AutoSize = true;
            this.lbl_playerZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerZone.Location = new System.Drawing.Point(8, 198);
            this.lbl_playerZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerZone.Name = "lbl_playerZone";
            this.lbl_playerZone.Size = new System.Drawing.Size(84, 13);
            this.lbl_playerZone.TabIndex = 14;
            this.lbl_playerZone.Text = "Zone: Unknown";
            // 
            // lbl_playerAccountName
            // 
            this.lbl_playerAccountName.AutoSize = true;
            this.lbl_playerAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerAccountName.Location = new System.Drawing.Point(8, 166);
            this.lbl_playerAccountName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerAccountName.Name = "lbl_playerAccountName";
            this.lbl_playerAccountName.Size = new System.Drawing.Size(97, 13);
            this.lbl_playerAccountName.TabIndex = 13;
            this.lbl_playerAccountName.Text = "Account: unknown";
            // 
            // lbl_playerRealm
            // 
            this.lbl_playerRealm.AutoSize = true;
            this.lbl_playerRealm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerRealm.Location = new System.Drawing.Point(8, 150);
            this.lbl_playerRealm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerRealm.Name = "lbl_playerRealm";
            this.lbl_playerRealm.Size = new System.Drawing.Size(87, 13);
            this.lbl_playerRealm.TabIndex = 12;
            this.lbl_playerRealm.Text = "Realm: unknown";
            // 
            // lbl_playerNickName
            // 
            this.lbl_playerNickName.AutoSize = true;
            this.lbl_playerNickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerNickName.Location = new System.Drawing.Point(8, 134);
            this.lbl_playerNickName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerNickName.Name = "lbl_playerNickName";
            this.lbl_playerNickName.Size = new System.Drawing.Size(85, 13);
            this.lbl_playerNickName.TabIndex = 11;
            this.lbl_playerNickName.Text = "Name: unknown";
            // 
            // lbl_playerZ
            // 
            this.lbl_playerZ.AutoSize = true;
            this.lbl_playerZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerZ.Location = new System.Drawing.Point(8, 52);
            this.lbl_playerZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerZ.Name = "lbl_playerZ";
            this.lbl_playerZ.Size = new System.Drawing.Size(26, 13);
            this.lbl_playerZ.TabIndex = 8;
            this.lbl_playerZ.Text = "Z: 0";
            // 
            // lbl_playerY
            // 
            this.lbl_playerY.AutoSize = true;
            this.lbl_playerY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerY.Location = new System.Drawing.Point(8, 36);
            this.lbl_playerY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerY.Name = "lbl_playerY";
            this.lbl_playerY.Size = new System.Drawing.Size(26, 13);
            this.lbl_playerY.TabIndex = 7;
            this.lbl_playerY.Text = "Y: 0";
            // 
            // lbl_playerX
            // 
            this.lbl_playerX.AutoSize = true;
            this.lbl_playerX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerX.Location = new System.Drawing.Point(8, 20);
            this.lbl_playerX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_playerX.Name = "lbl_playerX";
            this.lbl_playerX.Size = new System.Drawing.Size(26, 13);
            this.lbl_playerX.TabIndex = 6;
            this.lbl_playerX.Text = "X: 0";
            // 
            // lGrindLoadProfile
            // 
            this.lGrindLoadProfile.AutoSize = true;
            this.lGrindLoadProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGrindLoadProfile.Location = new System.Drawing.Point(8, 252);
            this.lGrindLoadProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGrindLoadProfile.Name = "lGrindLoadProfile";
            this.lGrindLoadProfile.Size = new System.Drawing.Size(39, 13);
            this.lGrindLoadProfile.TabIndex = 5;
            this.lGrindLoadProfile.Text = "Profile:";
            // 
            // cbLoadLastProfile
            // 
            this.cbLoadLastProfile.AutoSize = true;
            this.cbLoadLastProfile.Location = new System.Drawing.Point(217, 290);
            this.cbLoadLastProfile.Margin = new System.Windows.Forms.Padding(4);
            this.cbLoadLastProfile.Name = "cbLoadLastProfile";
            this.cbLoadLastProfile.Size = new System.Drawing.Size(122, 20);
            this.cbLoadLastProfile.TabIndex = 7;
            this.cbLoadLastProfile.Text = "Load last profile";
            this.cbLoadLastProfile.UseVisualStyleBackColor = true;
            // 
            // lGrindState
            // 
            this.lGrindState.AutoSize = true;
            this.lGrindState.Location = new System.Drawing.Point(8, 268);
            this.lGrindState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGrindState.Name = "lGrindState";
            this.lGrindState.Size = new System.Drawing.Size(45, 16);
            this.lGrindState.TabIndex = 6;
            this.lGrindState.Text = "State: ";
            // 
            // tC_Log
            // 
            this.tC_Log.Controls.Add(this.tabPage1);
            this.tC_Log.Controls.Add(this.tabPage2);
            this.tC_Log.Controls.Add(this.tabPage3);
            this.tC_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Log.Location = new System.Drawing.Point(4, 326);
            this.tC_Log.Margin = new System.Windows.Forms.Padding(4);
            this.tC_Log.Name = "tC_Log";
            this.tC_Log.SelectedIndex = 0;
            this.tC_Log.Size = new System.Drawing.Size(364, 130);
            this.tC_Log.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(356, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(356, 101);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(356, 101);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Exception";
            // 
            // tp_InGameChat
            // 
            this.tp_InGameChat.BackColor = System.Drawing.SystemColors.Control;
            this.tp_InGameChat.Controls.Add(this.groupBox1);
            this.tp_InGameChat.Controls.Add(this.bClearChatLog);
            this.tp_InGameChat.Location = new System.Drawing.Point(4, 25);
            this.tp_InGameChat.Margin = new System.Windows.Forms.Padding(4);
            this.tp_InGameChat.Name = "tp_InGameChat";
            this.tp_InGameChat.Size = new System.Drawing.Size(374, 462);
            this.tp_InGameChat.TabIndex = 7;
            this.tp_InGameChat.Text = "Chat";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgChat);
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(365, 419);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "InGame Chat";
            // 
            // dgChat
            // 
            this.dgChat.AllowUserToAddRows = false;
            this.dgChat.AllowUserToDeleteRows = false;
            this.dgChat.AllowUserToResizeColumns = false;
            this.dgChat.AllowUserToResizeRows = false;
            this.dgChat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dType,
            this.dTime,
            this.dSender,
            this.dMessage});
            this.dgChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgChat.Location = new System.Drawing.Point(4, 19);
            this.dgChat.Margin = new System.Windows.Forms.Padding(4);
            this.dgChat.MultiSelect = false;
            this.dgChat.Name = "dgChat";
            this.dgChat.ReadOnly = true;
            this.dgChat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgChat.RowHeadersVisible = false;
            this.dgChat.Size = new System.Drawing.Size(357, 396);
            this.dgChat.TabIndex = 6;
            // 
            // dType
            // 
            this.dType.HeaderText = "Type";
            this.dType.Name = "dType";
            this.dType.ReadOnly = true;
            this.dType.Width = 50;
            // 
            // dTime
            // 
            this.dTime.HeaderText = "Time";
            this.dTime.Name = "dTime";
            this.dTime.ReadOnly = true;
            this.dTime.Width = 35;
            // 
            // dSender
            // 
            this.dSender.HeaderText = "Sender";
            this.dSender.Name = "dSender";
            this.dSender.ReadOnly = true;
            this.dSender.Width = 75;
            // 
            // dMessage
            // 
            this.dMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dMessage.HeaderText = "Message";
            this.dMessage.Name = "dMessage";
            this.dMessage.ReadOnly = true;
            // 
            // bClearChatLog
            // 
            this.bClearChatLog.Location = new System.Drawing.Point(8, 433);
            this.bClearChatLog.Margin = new System.Windows.Forms.Padding(4);
            this.bClearChatLog.Name = "bClearChatLog";
            this.bClearChatLog.Size = new System.Drawing.Size(111, 25);
            this.bClearChatLog.TabIndex = 9;
            this.bClearChatLog.Text = "Clear Log";
            this.bClearChatLog.UseVisualStyleBackColor = true;
            this.bClearChatLog.Click += new System.EventHandler(this.bClearChatLog_Click);
            // 
            // tpNotifications
            // 
            this.tpNotifications.BackColor = System.Drawing.SystemColors.Control;
            this.tpNotifications.Controls.Add(this.dgNotifications);
            this.tpNotifications.Location = new System.Drawing.Point(4, 25);
            this.tpNotifications.Margin = new System.Windows.Forms.Padding(4);
            this.tpNotifications.Name = "tpNotifications";
            this.tpNotifications.Size = new System.Drawing.Size(374, 462);
            this.tpNotifications.TabIndex = 3;
            this.tpNotifications.Text = "Notifications";
            // 
            // dgNotifications
            // 
            this.dgNotifications.AllowUserToAddRows = false;
            this.dgNotifications.AllowUserToDeleteRows = false;
            this.dgNotifications.AllowUserToResizeColumns = false;
            this.dgNotifications.AllowUserToResizeRows = false;
            this.dgNotifications.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgNotifications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNotifications.Location = new System.Drawing.Point(0, 0);
            this.dgNotifications.Margin = new System.Windows.Forms.Padding(4);
            this.dgNotifications.MultiSelect = false;
            this.dgNotifications.Name = "dgNotifications";
            this.dgNotifications.ReadOnly = true;
            this.dgNotifications.RowHeadersVisible = false;
            this.dgNotifications.Size = new System.Drawing.Size(374, 462);
            this.dgNotifications.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 35;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Message";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tcMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 559);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.dEVToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newsToolStripMenuItem.Text = "News";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem2.Text = "?";
            // 
            // dEVToolStripMenuItem
            // 
            this.dEVToolStripMenuItem.Name = "dEVToolStripMenuItem";
            this.dEVToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.dEVToolStripMenuItem.Text = "DEV";
            this.dEVToolStripMenuItem.Click += new System.EventHandler(this.dEVToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(390, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // GraphicalMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GraphicalMainForm";
            this.Text = "ZzukBot";
            this.tcMain.ResumeLayout(false);
            this.tpGrind.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tC_Log.ResumeLayout(false);
            this.tp_InGameChat.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChat)).EndInit();
            this.tpNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNotifications)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpGrind;
        private System.Windows.Forms.TabPage tpNotifications;
        private System.Windows.Forms.DataGridView dgNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.TabPage tp_InGameChat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMessage;
        private System.Windows.Forms.Button bClearChatLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lGrindLoadProfile;
        internal System.Windows.Forms.Label lGrindState;
        private System.Windows.Forms.TabControl tC_Log;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dEVToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label lbl_targetId;
        internal System.Windows.Forms.Label lbl_targetFaction;
        internal System.Windows.Forms.Label lbl_targetZ;
        internal System.Windows.Forms.Label lbl_targetY;
        internal System.Windows.Forms.Label lbl_targetX;
        internal System.Windows.Forms.Label lbl_targetName;
        internal System.Windows.Forms.Label lbl_playerSubZone;
        internal System.Windows.Forms.Label lbl_playerZone;
        internal System.Windows.Forms.Label lbl_playerAccountName;
        internal System.Windows.Forms.Label lbl_playerRealm;
        internal System.Windows.Forms.Label lbl_playerNickName;
        internal System.Windows.Forms.Label lbl_playerZ;
        internal System.Windows.Forms.Label lbl_playerY;
        internal System.Windows.Forms.Label lbl_playerX;
        internal Helpers.NewProgressBar pBar_playerMana;
        internal Helpers.NewProgressBar pBar_playerHealth;
        internal Helpers.NewProgressBar pBar_targetHealth;
        internal Helpers.NewProgressBar pBar_playerExperience;
        internal System.Windows.Forms.CheckBox cbLoadLastProfile;
    }
}

