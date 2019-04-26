namespace ZzukBot.Forms
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Skills
            // 
            this.btn_Skills.Location = new System.Drawing.Point(33, 35);
            this.btn_Skills.Name = "btn_Skills";
            this.btn_Skills.Size = new System.Drawing.Size(94, 23);
            this.btn_Skills.TabIndex = 0;
            this.btn_Skills.Text = "Print Skills";
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
            this.groupBox1.Controls.Add(this.btn_travelToVendor);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 222);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logic Actions";
            // 
            // GraphicalDEVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Skills);
            this.Name = "GraphicalDEVForm";
            this.Text = "GraphicalDEVForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Skills;
        private System.Windows.Forms.Button btn_travelToVendor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}