﻿namespace ZzukBot.Forms
{
    partial class GraphicalDEVForm
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
            this.btn_Skills = new System.Windows.Forms.Button();
            this.btn_travelToVendor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Inventory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Party = new System.Windows.Forms.Button();
            this.btn_Talents = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_FishingTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Skills
            // 
            this.btn_Skills.Location = new System.Drawing.Point(9, 19);
            this.btn_Skills.Name = "btn_Skills";
            this.btn_Skills.Size = new System.Drawing.Size(75, 23);
            this.btn_Skills.TabIndex = 0;
            this.btn_Skills.Text = "Skills";
            this.btn_Skills.UseVisualStyleBackColor = true;
            this.btn_Skills.Click += new System.EventHandler(this.btn_Skills_Click);
            // 
            // btn_travelToVendor
            // 
            this.btn_travelToVendor.Location = new System.Drawing.Point(6, 19);
            this.btn_travelToVendor.Name = "btn_travelToVendor";
            this.btn_travelToVendor.Size = new System.Drawing.Size(153, 23);
            this.btn_travelToVendor.TabIndex = 1;
            this.btn_travelToVendor.Text = "Toggle \'Travel to Vendor\'";
            this.btn_travelToVendor.UseVisualStyleBackColor = true;
            this.btn_travelToVendor.Click += new System.EventHandler(this.btn_travelToVendor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_FishingTest);
            this.groupBox1.Controls.Add(this.btn_travelToVendor);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 222);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logic Actions";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Enter World";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Inventory
            // 
            this.btn_Inventory.Location = new System.Drawing.Point(9, 48);
            this.btn_Inventory.Name = "btn_Inventory";
            this.btn_Inventory.Size = new System.Drawing.Size(75, 23);
            this.btn_Inventory.TabIndex = 4;
            this.btn_Inventory.Text = "Inventory";
            this.btn_Inventory.UseVisualStyleBackColor = true;
            this.btn_Inventory.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Party);
            this.groupBox2.Controls.Add(this.btn_Talents);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btn_Skills);
            this.groupBox2.Controls.Add(this.btn_Inventory);
            this.groupBox2.Location = new System.Drawing.Point(204, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(97, 222);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print to Console";
            // 
            // btn_Party
            // 
            this.btn_Party.Location = new System.Drawing.Point(9, 106);
            this.btn_Party.Name = "btn_Party";
            this.btn_Party.Size = new System.Drawing.Size(75, 23);
            this.btn_Party.TabIndex = 9;
            this.btn_Party.Text = "party details";
            this.btn_Party.UseVisualStyleBackColor = true;
            this.btn_Party.Click += new System.EventHandler(this.btn_Party_Click);
            // 
            // btn_Talents
            // 
            this.btn_Talents.Location = new System.Drawing.Point(9, 77);
            this.btn_Talents.Name = "btn_Talents";
            this.btn_Talents.Size = new System.Drawing.Size(75, 23);
            this.btn_Talents.TabIndex = 8;
            this.btn_Talents.Text = "Talents";
            this.btn_Talents.UseVisualStyleBackColor = true;
            this.btn_Talents.Click += new System.EventHandler(this.btn_Talents_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "test action";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_FishingTest
            // 
            this.btn_FishingTest.Location = new System.Drawing.Point(11, 100);
            this.btn_FishingTest.Name = "btn_FishingTest";
            this.btn_FishingTest.Size = new System.Drawing.Size(153, 23);
            this.btn_FishingTest.TabIndex = 7;
            this.btn_FishingTest.Text = "Fishing Test";
            this.btn_FishingTest.UseVisualStyleBackColor = true;
            this.btn_FishingTest.Click += new System.EventHandler(this.btn_FishingTest_Click);
            // 
            // GraphicalDEVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GraphicalDEVForm";
            this.Text = "GraphicalDEVForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Skills;
        private System.Windows.Forms.Button btn_travelToVendor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Inventory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Talents;
        private System.Windows.Forms.Button btn_Party;
        private System.Windows.Forms.Button btn_FishingTest;
    }
}