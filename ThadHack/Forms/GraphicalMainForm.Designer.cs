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
            this.tcMain.Location = new System.Drawing.Point(3, 27);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(478, 479);
            this.tcMain.TabIndex = 0;
            // 
            // tpGrind
            // 
            this.tpGrind.BackColor = System.Drawing.SystemColors.Control;
            this.tpGrind.Controls.Add(this.tableLayoutPanel2);
            this.tpGrind.Location = new System.Drawing.Point(4, 22);
            this.tpGrind.Name = "tpGrind";
            this.tpGrind.Padding = new System.Windows.Forms.Padding(10);
            this.tpGrind.Size = new System.Drawing.Size(470, 453);
            this.tpGrind.TabIndex = 0;
            this.tpGrind.Text = "Main";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tC_Log, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 433);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lGrindLoadProfile);
            this.panel1.Controls.Add(this.cbLoadLastProfile);
            this.panel1.Controls.Add(this.lGrindState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 210);
            this.panel1.TabIndex = 1;
            // 
            // lGrindLoadProfile
            // 
            this.lGrindLoadProfile.AutoSize = true;
            this.lGrindLoadProfile.Location = new System.Drawing.Point(4, 11);
            this.lGrindLoadProfile.Name = "lGrindLoadProfile";
            this.lGrindLoadProfile.Size = new System.Drawing.Size(39, 13);
            this.lGrindLoadProfile.TabIndex = 5;
            this.lGrindLoadProfile.Text = "Profile:";
            // 
            // cbLoadLastProfile
            // 
            this.cbLoadLastProfile.AutoSize = true;
            this.cbLoadLastProfile.Location = new System.Drawing.Point(3, 180);
            this.cbLoadLastProfile.Name = "cbLoadLastProfile";
            this.cbLoadLastProfile.Size = new System.Drawing.Size(100, 17);
            this.cbLoadLastProfile.TabIndex = 7;
            this.cbLoadLastProfile.Text = "Load last profile";
            this.cbLoadLastProfile.UseVisualStyleBackColor = true;
            // 
            // lGrindState
            // 
            this.lGrindState.AutoSize = true;
            this.lGrindState.Location = new System.Drawing.Point(4, 30);
            this.lGrindState.Name = "lGrindState";
            this.lGrindState.Size = new System.Drawing.Size(38, 13);
            this.lGrindState.TabIndex = 6;
            this.lGrindState.Text = "State: ";
            // 
            // tC_Log
            // 
            this.tC_Log.Controls.Add(this.tabPage1);
            this.tC_Log.Controls.Add(this.tabPage2);
            this.tC_Log.Controls.Add(this.tabPage3);
            this.tC_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Log.Location = new System.Drawing.Point(3, 219);
            this.tC_Log.Name = "tC_Log";
            this.tC_Log.SelectedIndex = 0;
            this.tC_Log.Size = new System.Drawing.Size(444, 211);
            this.tC_Log.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(436, 185);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(436, 185);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(436, 185);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Exception";
            // 
            // tp_InGameChat
            // 
            this.tp_InGameChat.BackColor = System.Drawing.SystemColors.Control;
            this.tp_InGameChat.Controls.Add(this.groupBox1);
            this.tp_InGameChat.Controls.Add(this.bClearChatLog);
            this.tp_InGameChat.Location = new System.Drawing.Point(4, 22);
            this.tp_InGameChat.Name = "tp_InGameChat";
            this.tp_InGameChat.Size = new System.Drawing.Size(470, 453);
            this.tp_InGameChat.TabIndex = 7;
            this.tp_InGameChat.Text = "Chat";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgChat);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 293);
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
            this.dgChat.Location = new System.Drawing.Point(3, 16);
            this.dgChat.MultiSelect = false;
            this.dgChat.Name = "dgChat";
            this.dgChat.ReadOnly = true;
            this.dgChat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgChat.RowHeadersVisible = false;
            this.dgChat.Size = new System.Drawing.Size(444, 274);
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
            this.bClearChatLog.Location = new System.Drawing.Point(10, 304);
            this.bClearChatLog.Name = "bClearChatLog";
            this.bClearChatLog.Size = new System.Drawing.Size(83, 20);
            this.bClearChatLog.TabIndex = 9;
            this.bClearChatLog.Text = "Clear Log";
            this.bClearChatLog.UseVisualStyleBackColor = true;
            this.bClearChatLog.Visible = false;
            // 
            // tpNotifications
            // 
            this.tpNotifications.BackColor = System.Drawing.SystemColors.Control;
            this.tpNotifications.Controls.Add(this.dgNotifications);
            this.tpNotifications.Location = new System.Drawing.Point(4, 22);
            this.tpNotifications.Name = "tpNotifications";
            this.tpNotifications.Size = new System.Drawing.Size(470, 453);
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
            this.dgNotifications.MultiSelect = false;
            this.dgNotifications.Name = "dgNotifications";
            this.dgNotifications.ReadOnly = true;
            this.dgNotifications.Size = new System.Drawing.Size(470, 453);
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 533);
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
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // GraphicalMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GraphicalMainForm";
            this.Text = "ZzukBot";
            this.tcMain.ResumeLayout(false);
            this.tpGrind.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbLoadLastProfile;
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
    }
}

