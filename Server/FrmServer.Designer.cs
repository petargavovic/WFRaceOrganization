namespace Server
{
    partial class FrmServer
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
            this.btnPokreni = new System.Windows.Forms.Button();
            this.btnZaustavi = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPokreni
            // 
            this.btnPokreni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokreni.Location = new System.Drawing.Point(45, 65);
            this.btnPokreni.Name = "btnPokreni";
            this.btnPokreni.Size = new System.Drawing.Size(150, 150);
            this.btnPokreni.TabIndex = 0;
            this.btnPokreni.Text = "Pokreni server";
            this.btnPokreni.UseVisualStyleBackColor = true;
            this.btnPokreni.Click += new System.EventHandler(this.btnPokreni_Click);
            // 
            // btnZaustavi
            // 
            this.btnZaustavi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaustavi.Location = new System.Drawing.Point(238, 65);
            this.btnZaustavi.Name = "btnZaustavi";
            this.btnZaustavi.Size = new System.Drawing.Size(150, 150);
            this.btnZaustavi.TabIndex = 1;
            this.btnZaustavi.Text = "Zaustavi server";
            this.btnZaustavi.UseVisualStyleBackColor = true;
            this.btnZaustavi.Click += new System.EventHandler(this.btnZaustavi_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(170, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(90, 24);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "OFFLINE";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnPokreni);
            this.panel.Controls.Add(this.btnZaustavi);
            this.panel.Controls.Add(this.lblStatus);
            this.panel.Location = new System.Drawing.Point(3, 64);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(430, 257);
            this.panel.TabIndex = 3;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 324);
            this.Controls.Add(this.panel);
            this.Name = "FrmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmServer_FormClosed);
            this.Resize += new System.EventHandler(this.FrmServer_Resize);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPokreni;
        private System.Windows.Forms.Button btnZaustavi;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel;
    }
}

