namespace Client
{
    partial class FrmSimulacija
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
            this.lblTimer = new System.Windows.Forms.Label();
            this.tbBrzina = new System.Windows.Forms.TrackBar();
            this.lblBrzina = new System.Windows.Forms.Label();
            this.lblVreme025 = new System.Windows.Forms.Label();
            this.lvlVreme1 = new System.Windows.Forms.Label();
            this.lblVreme10 = new System.Windows.Forms.Label();
            this.lblDuzina = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.btnPokreni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrzina)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(19, 77);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(79, 13);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "Vreme: 00:00.0";
            // 
            // tbBrzina
            // 
            this.tbBrzina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBrzina.BackColor = System.Drawing.SystemColors.Control;
            this.tbBrzina.Location = new System.Drawing.Point(306, 76);
            this.tbBrzina.Maximum = 8;
            this.tbBrzina.Name = "tbBrzina";
            this.tbBrzina.Size = new System.Drawing.Size(168, 45);
            this.tbBrzina.TabIndex = 1;
            this.tbBrzina.Value = 3;
            this.tbBrzina.ValueChanged += new System.EventHandler(this.tbBrzina_ValueChanged);
            // 
            // lblBrzina
            // 
            this.lblBrzina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrzina.AutoSize = true;
            this.lblBrzina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrzina.Location = new System.Drawing.Point(471, 77);
            this.lblBrzina.Name = "lblBrzina";
            this.lblBrzina.Size = new System.Drawing.Size(14, 15);
            this.lblBrzina.TabIndex = 2;
            this.lblBrzina.Text = "1";
            // 
            // lblVreme025
            // 
            this.lblVreme025.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVreme025.AutoSize = true;
            this.lblVreme025.Location = new System.Drawing.Point(303, 108);
            this.lblVreme025.Name = "lblVreme025";
            this.lblVreme025.Size = new System.Drawing.Size(28, 13);
            this.lblVreme025.TabIndex = 3;
            this.lblVreme025.Text = "0.25";
            // 
            // lvlVreme1
            // 
            this.lvlVreme1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvlVreme1.AutoSize = true;
            this.lvlVreme1.Location = new System.Drawing.Point(365, 108);
            this.lvlVreme1.Name = "lvlVreme1";
            this.lvlVreme1.Size = new System.Drawing.Size(13, 13);
            this.lvlVreme1.TabIndex = 4;
            this.lvlVreme1.Text = "1";
            // 
            // lblVreme10
            // 
            this.lblVreme10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVreme10.AutoSize = true;
            this.lblVreme10.Location = new System.Drawing.Point(455, 108);
            this.lblVreme10.Name = "lblVreme10";
            this.lblVreme10.Size = new System.Drawing.Size(19, 13);
            this.lblVreme10.TabIndex = 5;
            this.lblVreme10.Text = "10";
            // 
            // lblDuzina
            // 
            this.lblDuzina.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDuzina.AutoSize = true;
            this.lblDuzina.Location = new System.Drawing.Point(200, 77);
            this.lblDuzina.Name = "lblDuzina";
            this.lblDuzina.Size = new System.Drawing.Size(100, 13);
            this.lblDuzina.TabIndex = 6;
            this.lblDuzina.Text = "Duzina staze: 000m";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Brzina simulacije";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPokreni);
            this.panel1.Controls.Add(this.btnResetuj);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 40);
            this.panel1.TabIndex = 8;
            // 
            // btnResetuj
            // 
            this.btnResetuj.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResetuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetuj.Location = new System.Drawing.Point(297, 0);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(197, 40);
            this.btnResetuj.TabIndex = 1;
            this.btnResetuj.Text = "Resetuj";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // btnPokreni
            // 
            this.btnPokreni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPokreni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokreni.Location = new System.Drawing.Point(0, 0);
            this.btnPokreni.Name = "btnPokreni";
            this.btnPokreni.Size = new System.Drawing.Size(297, 40);
            this.btnPokreni.TabIndex = 0;
            this.btnPokreni.Text = "Pokreni";
            this.btnPokreni.UseVisualStyleBackColor = true;
            this.btnPokreni.Click += new System.EventHandler(this.btnPokreni_Click);
            // 
            // FrmSimulacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDuzina);
            this.Controls.Add(this.lblVreme10);
            this.Controls.Add(this.lvlVreme1);
            this.Controls.Add(this.lblVreme025);
            this.Controls.Add(this.lblBrzina);
            this.Controls.Add(this.tbBrzina);
            this.Controls.Add(this.lblTimer);
            this.Name = "FrmSimulacija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulacija trke";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSimulacija_FormClosed);
            this.Resize += new System.EventHandler(this.FrmSimulacija_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tbBrzina)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TrackBar tbBrzina;
        private System.Windows.Forms.Label lblBrzina;
        private System.Windows.Forms.Label lblVreme025;
        private System.Windows.Forms.Label lvlVreme1;
        private System.Windows.Forms.Label lblVreme10;
        private System.Windows.Forms.Label lblDuzina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.Button btnPokreni;
    }
}