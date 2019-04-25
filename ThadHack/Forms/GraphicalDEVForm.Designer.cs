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
            this.SuspendLayout();
            // 
            // btn_Skills
            // 
            this.btn_Skills.Location = new System.Drawing.Point(71, 90);
            this.btn_Skills.Name = "btn_Skills";
            this.btn_Skills.Size = new System.Drawing.Size(75, 23);
            this.btn_Skills.TabIndex = 0;
            this.btn_Skills.Text = "Skills";
            this.btn_Skills.UseVisualStyleBackColor = true;
            this.btn_Skills.Click += new System.EventHandler(this.btn_Skills_Click);
            // 
            // GraphicalDEVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Skills);
            this.Name = "GraphicalDEVForm";
            this.Text = "GraphicalDEVForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Skills;
    }
}