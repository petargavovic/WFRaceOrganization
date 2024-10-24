namespace Client
{
    partial class FrmStart
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
            this.btnLevi = new System.Windows.Forms.Button();
            this.btnDesni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLevi
            // 
            this.btnLevi.AutoSize = true;
            this.btnLevi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLevi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLevi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLevi.Location = new System.Drawing.Point(1, 64);
            this.btnLevi.Margin = new System.Windows.Forms.Padding(0);
            this.btnLevi.Name = "btnLevi";
            this.btnLevi.Size = new System.Drawing.Size(404, 403);
            this.btnLevi.TabIndex = 0;
            this.btnLevi.Text = "button1";
            this.btnLevi.UseVisualStyleBackColor = true;
            this.btnLevi.Click += new System.EventHandler(this.btnLevi_Click);
            // 
            // btnDesni
            // 
            this.btnDesni.AutoSize = true;
            this.btnDesni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesni.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDesni.Location = new System.Drawing.Point(404, 64);
            this.btnDesni.Margin = new System.Windows.Forms.Padding(0);
            this.btnDesni.Name = "btnDesni";
            this.btnDesni.Size = new System.Drawing.Size(404, 403);
            this.btnDesni.TabIndex = 1;
            this.btnDesni.Text = "button2";
            this.btnDesni.UseVisualStyleBackColor = true;
            this.btnDesni.Click += new System.EventHandler(this.btnDesni_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(809, 468);
            this.Controls.Add(this.btnDesni);
            this.Controls.Add(this.btnLevi);
            this.Name = "FrmStart";
            this.Padding = new System.Windows.Forms.Padding(1, 64, 1, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odabir profila";
            this.Load += new System.EventHandler(this.FrmStart_Load);
            this.Resize += new System.EventHandler(this.FrmStart_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLevi;
        private System.Windows.Forms.Button btnDesni;
    }
}