using System.Drawing;
using System.Windows.Forms;

namespace StazeZaTrke
{
    partial class FrmGeneratorStaze
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
            this.pointsLabel = new System.Windows.Forms.Label();
            this.btnSmanji = new System.Windows.Forms.Button();
            this.btnPovecaj = new System.Windows.Forms.Button();
            this.btnGenerisi = new System.Windows.Forms.Button();
            this.sliderDuzina = new MaterialSkin.Controls.MaterialSlider();
            this.btnSacuvajStazu = new System.Windows.Forms.Button();
            this.lblSliderValue = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.Location = new System.Drawing.Point(175, 110);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(150, 17);
            this.pointsLabel.TabIndex = 0;
            this.pointsLabel.Text = "Kompleksnost staze: 3";
            // 
            // btnSmanji
            // 
            this.btnSmanji.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSmanji.Enabled = false;
            this.btnSmanji.Location = new System.Drawing.Point(152, 130);
            this.btnSmanji.Name = "btnSmanji";
            this.btnSmanji.Size = new System.Drawing.Size(90, 25);
            this.btnSmanji.TabIndex = 1;
            this.btnSmanji.Text = "<";
            this.btnSmanji.Click += new System.EventHandler(this.btnSmanji_Click);
            // 
            // btnPovecaj
            // 
            this.btnPovecaj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPovecaj.Location = new System.Drawing.Point(248, 130);
            this.btnPovecaj.Name = "btnPovecaj";
            this.btnPovecaj.Size = new System.Drawing.Size(90, 25);
            this.btnPovecaj.TabIndex = 2;
            this.btnPovecaj.Text = ">";
            this.btnPovecaj.Click += new System.EventHandler(this.btnPovecaj_Click);
            // 
            // btnGenerisi
            // 
            this.btnGenerisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerisi.Location = new System.Drawing.Point(201, 161);
            this.btnGenerisi.Name = "btnGenerisi";
            this.btnGenerisi.Size = new System.Drawing.Size(92, 30);
            this.btnGenerisi.TabIndex = 0;
            this.btnGenerisi.Text = "Generiši";
            this.btnGenerisi.Click += new System.EventHandler(this.btnGenerisi_Click);
            // 
            // sliderDuzina
            // 
            this.sliderDuzina.Depth = 0;
            this.sliderDuzina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderDuzina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sliderDuzina.Location = new System.Drawing.Point(0, 0);
            this.sliderDuzina.MouseState = MaterialSkin.MouseState.HOVER;
            this.sliderDuzina.Name = "sliderDuzina";
            this.sliderDuzina.RangeMax = 2000;
            this.sliderDuzina.ShowValue = false;
            this.sliderDuzina.Size = new System.Drawing.Size(399, 40);
            this.sliderDuzina.TabIndex = 3;
            this.sliderDuzina.Text = "Dužina staze";
            this.sliderDuzina.Value = 1000;
            this.sliderDuzina.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.sliderDuzina_onValueChanged);
            // 
            // btnSacuvajStazu
            // 
            this.btnSacuvajStazu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSacuvajStazu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajStazu.Location = new System.Drawing.Point(3, 540);
            this.btnSacuvajStazu.Name = "btnSacuvajStazu";
            this.btnSacuvajStazu.Size = new System.Drawing.Size(494, 57);
            this.btnSacuvajStazu.TabIndex = 5;
            this.btnSacuvajStazu.Text = "Sačuvaj stazu";
            this.btnSacuvajStazu.UseVisualStyleBackColor = true;
            this.btnSacuvajStazu.Click += new System.EventHandler(this.btnSacuvajStazu_Click);
            // 
            // lblSliderValue
            // 
            this.lblSliderValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSliderValue.AutoSize = true;
            this.lblSliderValue.Depth = 0;
            this.lblSliderValue.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSliderValue.Location = new System.Drawing.Point(3, 12);
            this.lblSliderValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSliderValue.Name = "lblSliderValue";
            this.lblSliderValue.Size = new System.Drawing.Size(51, 19);
            this.lblSliderValue.TabIndex = 6;
            this.lblSliderValue.Text = "2000m";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 43);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 43);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSliderValue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(424, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(70, 43);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.sliderDuzina);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(25, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(399, 43);
            this.panel4.TabIndex = 2;
            // 
            // FrmGeneratorStaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSacuvajStazu);
            this.Controls.Add(this.btnGenerisi);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.btnSmanji);
            this.Controls.Add(this.btnPovecaj);
            this.Name = "FrmGeneratorStaze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeneratorStaze";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGeneratorStaze_FormClosed);
            this.Resize += new System.EventHandler(this.FrmGeneratorStaze_Resize);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Button btnSmanji;
        private System.Windows.Forms.Button btnPovecaj;
        private System.Windows.Forms.Button btnGenerisi;
        #endregion

        private MaterialSkin.Controls.MaterialSlider sliderDuzina;
        private Button btnSacuvajStazu;
        private MaterialSkin.Controls.MaterialLabel lblSliderValue;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
    }
}

