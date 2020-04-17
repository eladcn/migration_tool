namespace Elad_s_Migration_Tool
{
    partial class FixSceneryForm
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
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel2 = new System.Windows.Forms.Label();
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.descriptionLabel4 = new System.Windows.Forms.Label();
            this.fixSceneryButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.AutoSize = true;
            this.descriptionLabel1.Location = new System.Drawing.Point(12, 9);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(503, 17);
            this.descriptionLabel1.TabIndex = 0;
            this.descriptionLabel1.Text = "If you have a problem with a scenery you migrated (like objects not displaying),";
            // 
            // descriptionLabel2
            // 
            this.descriptionLabel2.AutoSize = true;
            this.descriptionLabel2.Location = new System.Drawing.Point(12, 26);
            this.descriptionLabel2.Name = "descriptionLabel2";
            this.descriptionLabel2.Size = new System.Drawing.Size(255, 17);
            this.descriptionLabel2.TabIndex = 1;
            this.descriptionLabel2.Text = "You can use this tool to fix the scenery.";
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.AutoSize = true;
            this.descriptionLabel3.Location = new System.Drawing.Point(12, 43);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(504, 17);
            this.descriptionLabel3.TabIndex = 2;
            this.descriptionLabel3.Text = "Press the button below and choose the texture folder inside the scenery folder.";
            // 
            // descriptionLabel4
            // 
            this.descriptionLabel4.AutoSize = true;
            this.descriptionLabel4.Location = new System.Drawing.Point(12, 60);
            this.descriptionLabel4.Name = "descriptionLabel4";
            this.descriptionLabel4.Size = new System.Drawing.Size(392, 17);
            this.descriptionLabel4.TabIndex = 3;
            this.descriptionLabel4.Text = "The texture folder is the folder that contains .bmp files inside.";
            // 
            // fixSceneryButton
            // 
            this.fixSceneryButton.Location = new System.Drawing.Point(184, 97);
            this.fixSceneryButton.Name = "fixSceneryButton";
            this.fixSceneryButton.Size = new System.Drawing.Size(103, 35);
            this.fixSceneryButton.TabIndex = 4;
            this.fixSceneryButton.Text = "Fix Scenery";
            this.fixSceneryButton.UseVisualStyleBackColor = true;
            this.fixSceneryButton.Click += new System.EventHandler(this.fixSceneryButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(293, 97);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 35);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FixSceneryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 144);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.fixSceneryButton);
            this.Controls.Add(this.descriptionLabel4);
            this.Controls.Add(this.descriptionLabel3);
            this.Controls.Add(this.descriptionLabel2);
            this.Controls.Add(this.descriptionLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FixSceneryForm";
            this.Text = "Fix Scenery";
            this.Load += new System.EventHandler(this.FixSceneryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label descriptionLabel2;
        private System.Windows.Forms.Label descriptionLabel4;
        private System.Windows.Forms.Button fixSceneryButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label descriptionLabel3;
    }
}