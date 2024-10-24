namespace Client
{
    partial class FrmEntities
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntities));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort1 = new System.Windows.Forms.ComboBox();
            this.tbAscDesc1 = new System.Windows.Forms.TrackBar();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSimulacija = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.chTrka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartnaPozicija = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPlasman = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVreme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panelSort = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAscDesc2 = new System.Windows.Forms.TrackBar();
            this.cmbSort2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRezultat = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.cmbPretraga = new System.Windows.Forms.ComboBox();
            this.lblPretraga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAscDesc1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAscDesc2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(440, 277);
            this.dgv.TabIndex = 1;
            this.dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(741, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 363);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.PowderBlue;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lblSort);
            this.panel5.Controls.Add(this.cmbSort1);
            this.panel5.Controls.Add(this.tbAscDesc1);
            this.panel5.Controls.Add(this.btnDodaj);
            this.panel5.Controls.Add(this.btnIzmeni);
            this.panel5.Controls.Add(this.btnObrisi);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 363);
            this.panel5.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ASC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DESC";
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(14, 300);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(74, 13);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "Sortiraj prema:";
            // 
            // cmbSort1
            // 
            this.cmbSort1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbSort1.FormattingEnabled = true;
            this.cmbSort1.Location = new System.Drawing.Point(17, 322);
            this.cmbSort1.Name = "cmbSort1";
            this.cmbSort1.Size = new System.Drawing.Size(97, 20);
            this.cmbSort1.TabIndex = 1;
            this.cmbSort1.SelectionChangeCommitted += new System.EventHandler(this.cmbSort_SelectionChangeCommitted);
            // 
            // tbAscDesc1
            // 
            this.tbAscDesc1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.tbAscDesc1.Location = new System.Drawing.Point(123, 294);
            this.tbAscDesc1.Maximum = 1;
            this.tbAscDesc1.Name = "tbAscDesc1";
            this.tbAscDesc1.Size = new System.Drawing.Size(61, 45);
            this.tbAscDesc1.TabIndex = 2;
            this.tbAscDesc1.ValueChanged += new System.EventHandler(this.tbAscDesc_ValueChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodaj.Location = new System.Drawing.Point(39, 17);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(122, 75);
            this.btnDodaj.TabIndex = 5;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzmeni.Location = new System.Drawing.Point(39, 108);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(122, 71);
            this.btnIzmeni.TabIndex = 6;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObrisi.Enabled = false;
            this.btnObrisi.Location = new System.Drawing.Point(39, 197);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(122, 71);
            this.btnObrisi.TabIndex = 8;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 363);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnSimulacija);
            this.panel3.Controls.Add(this.listView);
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 277);
            this.panel3.TabIndex = 11;
            // 
            // btnSimulacija
            // 
            this.btnSimulacija.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSimulacija.Location = new System.Drawing.Point(440, 236);
            this.btnSimulacija.Name = "btnSimulacija";
            this.btnSimulacija.Size = new System.Drawing.Size(298, 41);
            this.btnSimulacija.TabIndex = 11;
            this.btnSimulacija.Text = "Simuliraj trku";
            this.btnSimulacija.UseVisualStyleBackColor = true;
            this.btnSimulacija.Visible = false;
            this.btnSimulacija.Click += new System.EventHandler(this.btnSimulacija_Click);
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTrka,
            this.chStartnaPozicija,
            this.chPlasman,
            this.chVreme});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(440, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(298, 277);
            this.listView.TabIndex = 10;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // chTrka
            // 
            this.chTrka.Text = "Trka";
            // 
            // chStartnaPozicija
            // 
            this.chStartnaPozicija.Text = "Startna pozicija";
            this.chStartnaPozicija.Width = 89;
            // 
            // chPlasman
            // 
            this.chPlasman.Text = "Plasman";
            // 
            // chVreme
            // 
            this.chVreme.Text = "Vremena";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.lblUsername);
            this.panel4.Controls.Add(this.panelSort);
            this.panel4.Controls.Add(this.btnRezultat);
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Controls.Add(this.btnPretraga);
            this.panel4.Controls.Add(this.txtPretraga);
            this.panel4.Controls.Add(this.cmbPretraga);
            this.panel4.Controls.Add(this.lblPretraga);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(738, 86);
            this.panel4.TabIndex = 12;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(155, 4);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "username";
            // 
            // panelSort
            // 
            this.panelSort.Controls.Add(this.label3);
            this.panelSort.Controls.Add(this.label4);
            this.panelSort.Controls.Add(this.tbAscDesc2);
            this.panelSort.Controls.Add(this.cmbSort2);
            this.panelSort.Controls.Add(this.label5);
            this.panelSort.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSort.Location = new System.Drawing.Point(372, 25);
            this.panelSort.Name = "panelSort";
            this.panelSort.Size = new System.Drawing.Size(217, 61);
            this.panelSort.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ASC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "DESC";
            // 
            // tbAscDesc2
            // 
            this.tbAscDesc2.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.tbAscDesc2.Location = new System.Drawing.Point(135, 6);
            this.tbAscDesc2.Maximum = 1;
            this.tbAscDesc2.Name = "tbAscDesc2";
            this.tbAscDesc2.Size = new System.Drawing.Size(67, 45);
            this.tbAscDesc2.TabIndex = 11;
            this.tbAscDesc2.ValueChanged += new System.EventHandler(this.tbAscDesc2_ValueChanged);
            // 
            // cmbSort2
            // 
            this.cmbSort2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort2.FormattingEnabled = true;
            this.cmbSort2.Location = new System.Drawing.Point(6, 30);
            this.cmbSort2.Name = "cmbSort2";
            this.cmbSort2.Size = new System.Drawing.Size(119, 21);
            this.cmbSort2.TabIndex = 10;
            this.cmbSort2.SelectionChangeCommitted += new System.EventHandler(this.cmbSort2_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sortiraj prema:";
            // 
            // btnRezultat
            // 
            this.btnRezultat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRezultat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRezultat.Enabled = false;
            this.btnRezultat.Location = new System.Drawing.Point(589, 25);
            this.btnRezultat.Name = "btnRezultat";
            this.btnRezultat.Size = new System.Drawing.Size(149, 61);
            this.btnRezultat.TabIndex = 9;
            this.btnRezultat.Text = "Unesi rezultate trke";
            this.btnRezultat.UseVisualStyleBackColor = true;
            this.btnRezultat.Click += new System.EventHandler(this.btnRezultat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(738, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "Vozači";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "Trke";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton3.Text = "Rang liste";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton4.Text = "Odjavi se";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton5.Text = "Promeni temu";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretraga.BackgroundImage")));
            this.btnPretraga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPretraga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPretraga.FlatAppearance.BorderSize = 0;
            this.btnPretraga.Location = new System.Drawing.Point(491, 38);
            this.btnPretraga.Margin = new System.Windows.Forms.Padding(0);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(26, 26);
            this.btnPretraga.TabIndex = 2;
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(240, 39);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(246, 20);
            this.txtPretraga.TabIndex = 3;
            this.txtPretraga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPretraga_KeyDown);
            // 
            // cmbPretraga
            // 
            this.cmbPretraga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPretraga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPretraga.FormattingEnabled = true;
            this.cmbPretraga.Location = new System.Drawing.Point(115, 39);
            this.cmbPretraga.Name = "cmbPretraga";
            this.cmbPretraga.Size = new System.Drawing.Size(119, 21);
            this.cmbPretraga.TabIndex = 9;
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(10, 42);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.Size = new System.Drawing.Size(77, 13);
            this.lblPretraga.TabIndex = 9;
            this.lblPretraga.Text = "Pretraži prema:";
            // 
            // FrmEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 430);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEntities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEntities";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEntities_FormClosed);
            this.Load += new System.EventHandler(this.FrmEntities_Load);
            this.Resize += new System.EventHandler(this.FrmEntities_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAscDesc1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelSort.ResumeLayout(false);
            this.panelSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAscDesc2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort1;
        private System.Windows.Forms.TrackBar tbAscDesc1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Label lblPretraga;
        private System.Windows.Forms.ComboBox cmbPretraga;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader chTrka;
        private System.Windows.Forms.ColumnHeader chStartnaPozicija;
        private System.Windows.Forms.ColumnHeader chPlasman;
        private System.Windows.Forms.ColumnHeader chVreme;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Button btnRezultat;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Panel panelSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbAscDesc2;
        private System.Windows.Forms.ComboBox cmbSort2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        public System.Windows.Forms.Button btnSimulacija;
    }
}