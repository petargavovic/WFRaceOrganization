namespace Client
{
    partial class FrmEntity
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
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblDrzava = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblDatRodj = new System.Windows.Forms.Label();
            this.dtpVozac = new System.Windows.Forms.DateTimePicker();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.lblImeGreska = new System.Windows.Forms.Label();
            this.lblPrezimeGreska = new System.Windows.Forms.Label();
            this.lblDrzavaGreska = new System.Windows.Forms.Label();
            this.panelVozac = new System.Windows.Forms.Panel();
            this.panelVozac1 = new System.Windows.Forms.Panel();
            this.lblDatumGreska = new System.Windows.Forms.Label();
            this.panelDate = new System.Windows.Forms.Panel();
            this.cmbDrzava = new System.Windows.Forms.ComboBox();
            this.lblNemaVozaca = new System.Windows.Forms.Label();
            this.panelTrka = new System.Windows.Forms.Panel();
            this.panelTrka1 = new System.Windows.Forms.Panel();
            this.lblDuzinaStaze = new System.Windows.Forms.Label();
            this.btnGeneratorStaze = new System.Windows.Forms.Button();
            this.lblStazaGreska = new System.Windows.Forms.Label();
            this.lblKategorijaGreska = new System.Windows.Forms.Label();
            this.lblBrojKrugovaGreska = new System.Windows.Forms.Label();
            this.lblNazivGreska = new System.Windows.Forms.Label();
            this.dtpTrka = new System.Windows.Forms.DateTimePicker();
            this.txtBrojKrugova = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblBrojKrugova = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblKategorija = new System.Windows.Forms.Label();
            this.cmbKategorija = new System.Windows.Forms.ComboBox();
            this.panelPrijava = new System.Windows.Forms.Panel();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.dgvVreme = new System.Windows.Forms.DataGridView();
            this.txtPlasman = new System.Windows.Forms.TextBox();
            this.dgvUcinci = new System.Windows.Forms.DataGridView();
            this.cmbStartnaPozicija = new System.Windows.Forms.ComboBox();
            this.lblVremeGreska = new System.Windows.Forms.Label();
            this.lblStartnaPozicijaGreska = new System.Windows.Forms.Label();
            this.lblPlasmanGreska = new System.Windows.Forms.Label();
            this.lblVreme = new System.Windows.Forms.Label();
            this.lblStartnaPozicija = new System.Windows.Forms.Label();
            this.lblVozac = new System.Windows.Forms.Label();
            this.lblPlasman = new System.Windows.Forms.Label();
            this.cmbVozac = new System.Windows.Forms.ComboBox();
            this.btnDizmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.panelVozac.SuspendLayout();
            this.panelVozac1.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelTrka.SuspendLayout();
            this.panelTrka1.SuspendLayout();
            this.panelPrijava.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVreme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcinci)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(64, 43);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(36, 20);
            this.lblIme.TabIndex = 0;
            this.lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.Location = new System.Drawing.Point(64, 96);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(66, 20);
            this.lblPrezime.TabIndex = 1;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblDrzava
            // 
            this.lblDrzava.AutoSize = true;
            this.lblDrzava.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrzava.Location = new System.Drawing.Point(64, 153);
            this.lblDrzava.Name = "lblDrzava";
            this.lblDrzava.Size = new System.Drawing.Size(59, 20);
            this.lblDrzava.TabIndex = 2;
            this.lblDrzava.Text = "Država";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(203, 42);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(225, 20);
            this.txtIme.TabIndex = 0;
            this.txtIme.TextChanged += new System.EventHandler(this.txtIme_TextChanged);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(203, 96);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(225, 20);
            this.txtPrezime.TabIndex = 1;
            this.txtPrezime.TextChanged += new System.EventHandler(this.txtPrezime_TextChanged);
            // 
            // lblDatRodj
            // 
            this.lblDatRodj.AutoSize = true;
            this.lblDatRodj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatRodj.Location = new System.Drawing.Point(64, 204);
            this.lblDatRodj.Name = "lblDatRodj";
            this.lblDatRodj.Size = new System.Drawing.Size(121, 20);
            this.lblDatRodj.TabIndex = 6;
            this.lblDatRodj.Text = "Datum Rođenja";
            // 
            // dtpVozac
            // 
            this.dtpVozac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpVozac.Location = new System.Drawing.Point(2, 2);
            this.dtpVozac.Name = "dtpVozac";
            this.dtpVozac.Size = new System.Drawing.Size(221, 20);
            this.dtpVozac.TabIndex = 2;
            this.dtpVozac.ValueChanged += new System.EventHandler(this.dtpVozac_ValueChanged);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSacuvaj.Location = new System.Drawing.Point(332, 569);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(209, 57);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // lblImeGreska
            // 
            this.lblImeGreska.AutoSize = true;
            this.lblImeGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImeGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblImeGreska.Location = new System.Drawing.Point(209, 70);
            this.lblImeGreska.Name = "lblImeGreska";
            this.lblImeGreska.Size = new System.Drawing.Size(0, 15);
            this.lblImeGreska.TabIndex = 9;
            // 
            // lblPrezimeGreska
            // 
            this.lblPrezimeGreska.AutoSize = true;
            this.lblPrezimeGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezimeGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPrezimeGreska.Location = new System.Drawing.Point(209, 124);
            this.lblPrezimeGreska.Name = "lblPrezimeGreska";
            this.lblPrezimeGreska.Size = new System.Drawing.Size(0, 15);
            this.lblPrezimeGreska.TabIndex = 10;
            // 
            // lblDrzavaGreska
            // 
            this.lblDrzavaGreska.AutoSize = true;
            this.lblDrzavaGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrzavaGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDrzavaGreska.Location = new System.Drawing.Point(209, 176);
            this.lblDrzavaGreska.Name = "lblDrzavaGreska";
            this.lblDrzavaGreska.Size = new System.Drawing.Size(0, 15);
            this.lblDrzavaGreska.TabIndex = 11;
            // 
            // panelVozac
            // 
            this.panelVozac.Controls.Add(this.panelVozac1);
            this.panelVozac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVozac.Location = new System.Drawing.Point(3, 64);
            this.panelVozac.Name = "panelVozac";
            this.panelVozac.Size = new System.Drawing.Size(541, 565);
            this.panelVozac.TabIndex = 12;
            // 
            // panelVozac1
            // 
            this.panelVozac1.Controls.Add(this.lblDatumGreska);
            this.panelVozac1.Controls.Add(this.lblDrzavaGreska);
            this.panelVozac1.Controls.Add(this.lblPrezimeGreska);
            this.panelVozac1.Controls.Add(this.lblImeGreska);
            this.panelVozac1.Controls.Add(this.lblDatRodj);
            this.panelVozac1.Controls.Add(this.txtPrezime);
            this.panelVozac1.Controls.Add(this.txtIme);
            this.panelVozac1.Controls.Add(this.lblDrzava);
            this.panelVozac1.Controls.Add(this.lblPrezime);
            this.panelVozac1.Controls.Add(this.lblIme);
            this.panelVozac1.Controls.Add(this.panelDate);
            this.panelVozac1.Controls.Add(this.cmbDrzava);
            this.panelVozac1.Location = new System.Drawing.Point(0, 3);
            this.panelVozac1.Name = "panelVozac1";
            this.panelVozac1.Size = new System.Drawing.Size(541, 494);
            this.panelVozac1.TabIndex = 15;
            // 
            // lblDatumGreska
            // 
            this.lblDatumGreska.AutoSize = true;
            this.lblDatumGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDatumGreska.Location = new System.Drawing.Point(209, 231);
            this.lblDatumGreska.Name = "lblDatumGreska";
            this.lblDatumGreska.Size = new System.Drawing.Size(0, 15);
            this.lblDatumGreska.TabIndex = 12;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dtpVozac);
            this.panelDate.Location = new System.Drawing.Point(203, 202);
            this.panelDate.Name = "panelDate";
            this.panelDate.Padding = new System.Windows.Forms.Padding(2);
            this.panelDate.Size = new System.Drawing.Size(225, 24);
            this.panelDate.TabIndex = 13;
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.DropDownHeight = 209;
            this.cmbDrzava.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.IntegralHeight = false;
            this.cmbDrzava.Location = new System.Drawing.Point(203, 152);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(225, 21);
            this.cmbDrzava.TabIndex = 14;
            // 
            // lblNemaVozaca
            // 
            this.lblNemaVozaca.AutoSize = true;
            this.lblNemaVozaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNemaVozaca.Location = new System.Drawing.Point(85, 525);
            this.lblNemaVozaca.Name = "lblNemaVozaca";
            this.lblNemaVozaca.Size = new System.Drawing.Size(161, 17);
            this.lblNemaVozaca.TabIndex = 15;
            this.lblNemaVozaca.Text = "U sistemu nema vozača!";
            this.lblNemaVozaca.Visible = false;
            // 
            // panelTrka
            // 
            this.panelTrka.Controls.Add(this.panelTrka1);
            this.panelTrka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrka.Location = new System.Drawing.Point(3, 64);
            this.panelTrka.Name = "panelTrka";
            this.panelTrka.Size = new System.Drawing.Size(541, 565);
            this.panelTrka.TabIndex = 13;
            this.panelTrka.Visible = false;
            // 
            // panelTrka1
            // 
            this.panelTrka1.Controls.Add(this.lblNemaVozaca);
            this.panelTrka1.Controls.Add(this.lblDuzinaStaze);
            this.panelTrka1.Controls.Add(this.btnGeneratorStaze);
            this.panelTrka1.Controls.Add(this.lblStazaGreska);
            this.panelTrka1.Controls.Add(this.lblKategorijaGreska);
            this.panelTrka1.Controls.Add(this.lblBrojKrugovaGreska);
            this.panelTrka1.Controls.Add(this.lblNazivGreska);
            this.panelTrka1.Controls.Add(this.dtpTrka);
            this.panelTrka1.Controls.Add(this.txtBrojKrugova);
            this.panelTrka1.Controls.Add(this.txtNaziv);
            this.panelTrka1.Controls.Add(this.lblDatum);
            this.panelTrka1.Controls.Add(this.lblBrojKrugova);
            this.panelTrka1.Controls.Add(this.lblNaziv);
            this.panelTrka1.Controls.Add(this.lblKategorija);
            this.panelTrka1.Controls.Add(this.cmbKategorija);
            this.panelTrka1.Controls.Add(this.panelPrijava);
            this.panelTrka1.Controls.Add(this.btnDizmeni);
            this.panelTrka1.Controls.Add(this.btnObrisi);
            this.panelTrka1.Location = new System.Drawing.Point(-3, 0);
            this.panelTrka1.Name = "panelTrka1";
            this.panelTrka1.Size = new System.Drawing.Size(547, 565);
            this.panelTrka1.TabIndex = 0;
            // 
            // lblDuzinaStaze
            // 
            this.lblDuzinaStaze.AutoSize = true;
            this.lblDuzinaStaze.Location = new System.Drawing.Point(21, 205);
            this.lblDuzinaStaze.Name = "lblDuzinaStaze";
            this.lblDuzinaStaze.Size = new System.Drawing.Size(0, 13);
            this.lblDuzinaStaze.TabIndex = 18;
            // 
            // btnGeneratorStaze
            // 
            this.btnGeneratorStaze.Location = new System.Drawing.Point(209, 182);
            this.btnGeneratorStaze.Name = "btnGeneratorStaze";
            this.btnGeneratorStaze.Size = new System.Drawing.Size(200, 35);
            this.btnGeneratorStaze.TabIndex = 16;
            this.btnGeneratorStaze.Text = "Generator staze";
            this.btnGeneratorStaze.UseVisualStyleBackColor = true;
            this.btnGeneratorStaze.Visible = false;
            this.btnGeneratorStaze.Click += new System.EventHandler(this.btnGeneratorStaze_Click);
            // 
            // lblStazaGreska
            // 
            this.lblStazaGreska.AutoSize = true;
            this.lblStazaGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStazaGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStazaGreska.Location = new System.Drawing.Point(222, 212);
            this.lblStazaGreska.Name = "lblStazaGreska";
            this.lblStazaGreska.Size = new System.Drawing.Size(0, 15);
            this.lblStazaGreska.TabIndex = 17;
            // 
            // lblKategorijaGreska
            // 
            this.lblKategorijaGreska.AutoSize = true;
            this.lblKategorijaGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKategorijaGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblKategorijaGreska.Location = new System.Drawing.Point(209, 209);
            this.lblKategorijaGreska.Name = "lblKategorijaGreska";
            this.lblKategorijaGreska.Size = new System.Drawing.Size(0, 15);
            this.lblKategorijaGreska.TabIndex = 11;
            // 
            // lblBrojKrugovaGreska
            // 
            this.lblBrojKrugovaGreska.AutoSize = true;
            this.lblBrojKrugovaGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojKrugovaGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBrojKrugovaGreska.Location = new System.Drawing.Point(209, 102);
            this.lblBrojKrugovaGreska.Name = "lblBrojKrugovaGreska";
            this.lblBrojKrugovaGreska.Size = new System.Drawing.Size(0, 15);
            this.lblBrojKrugovaGreska.TabIndex = 10;
            // 
            // lblNazivGreska
            // 
            this.lblNazivGreska.AutoSize = true;
            this.lblNazivGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNazivGreska.Location = new System.Drawing.Point(209, 48);
            this.lblNazivGreska.Name = "lblNazivGreska";
            this.lblNazivGreska.Size = new System.Drawing.Size(0, 15);
            this.lblNazivGreska.TabIndex = 9;
            // 
            // dtpTrka
            // 
            this.dtpTrka.Location = new System.Drawing.Point(203, 131);
            this.dtpTrka.Name = "dtpTrka";
            this.dtpTrka.Size = new System.Drawing.Size(228, 20);
            this.dtpTrka.TabIndex = 2;
            // 
            // txtBrojKrugova
            // 
            this.txtBrojKrugova.Location = new System.Drawing.Point(203, 74);
            this.txtBrojKrugova.Name = "txtBrojKrugova";
            this.txtBrojKrugova.Size = new System.Drawing.Size(228, 20);
            this.txtBrojKrugova.TabIndex = 1;
            this.txtBrojKrugova.TextChanged += new System.EventHandler(this.txtBrojKrugova_TextChanged);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(203, 20);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(228, 20);
            this.txtNaziv.TabIndex = 0;
            this.txtNaziv.TextChanged += new System.EventHandler(this.txtNaziv_TextChanged);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(64, 131);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(57, 20);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            // 
            // lblBrojKrugova
            // 
            this.lblBrojKrugova.AutoSize = true;
            this.lblBrojKrugova.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojKrugova.Location = new System.Drawing.Point(64, 74);
            this.lblBrojKrugova.Name = "lblBrojKrugova";
            this.lblBrojKrugova.Size = new System.Drawing.Size(97, 20);
            this.lblBrojKrugova.TabIndex = 1;
            this.lblBrojKrugova.Text = "Broj krugova";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.Location = new System.Drawing.Point(64, 20);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(47, 20);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv";
            // 
            // lblKategorija
            // 
            this.lblKategorija.AutoSize = true;
            this.lblKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKategorija.Location = new System.Drawing.Point(64, 180);
            this.lblKategorija.Name = "lblKategorija";
            this.lblKategorija.Size = new System.Drawing.Size(80, 20);
            this.lblKategorija.TabIndex = 12;
            this.lblKategorija.Text = "Kategorija";
            // 
            // cmbKategorija
            // 
            this.cmbKategorija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategorija.FormattingEnabled = true;
            this.cmbKategorija.ItemHeight = 13;
            this.cmbKategorija.Location = new System.Drawing.Point(203, 180);
            this.cmbKategorija.Name = "cmbKategorija";
            this.cmbKategorija.Size = new System.Drawing.Size(228, 21);
            this.cmbKategorija.TabIndex = 3;
            // 
            // panelPrijava
            // 
            this.panelPrijava.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPrijava.Controls.Add(this.txtVreme);
            this.panelPrijava.Controls.Add(this.dgvVreme);
            this.panelPrijava.Controls.Add(this.txtPlasman);
            this.panelPrijava.Controls.Add(this.dgvUcinci);
            this.panelPrijava.Controls.Add(this.cmbStartnaPozicija);
            this.panelPrijava.Controls.Add(this.lblVremeGreska);
            this.panelPrijava.Controls.Add(this.lblStartnaPozicijaGreska);
            this.panelPrijava.Controls.Add(this.lblPlasmanGreska);
            this.panelPrijava.Controls.Add(this.lblVreme);
            this.panelPrijava.Controls.Add(this.lblStartnaPozicija);
            this.panelPrijava.Controls.Add(this.lblVozac);
            this.panelPrijava.Controls.Add(this.lblPlasman);
            this.panelPrijava.Controls.Add(this.cmbVozac);
            this.panelPrijava.Location = new System.Drawing.Point(3, 247);
            this.panelPrijava.Name = "panelPrijava";
            this.panelPrijava.Size = new System.Drawing.Size(547, 252);
            this.panelPrijava.TabIndex = 13;
            this.panelPrijava.Visible = false;
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(426, 54);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.ReadOnly = true;
            this.txtVreme.Size = new System.Drawing.Size(46, 20);
            this.txtVreme.TabIndex = 23;
            // 
            // dgvVreme
            // 
            this.dgvVreme.AllowUserToAddRows = false;
            this.dgvVreme.AllowUserToDeleteRows = false;
            this.dgvVreme.AllowUserToResizeColumns = false;
            this.dgvVreme.AllowUserToResizeRows = false;
            this.dgvVreme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVreme.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVreme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVreme.Location = new System.Drawing.Point(350, 87);
            this.dgvVreme.MultiSelect = false;
            this.dgvVreme.Name = "dgvVreme";
            this.dgvVreme.RowHeadersVisible = false;
            this.dgvVreme.RowHeadersWidth = 10;
            this.dgvVreme.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVreme.Size = new System.Drawing.Size(176, 127);
            this.dgvVreme.TabIndex = 22;
            this.dgvVreme.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVreme_CellValidated);
            this.dgvVreme.SelectionChanged += new System.EventHandler(this.dgvVreme_SelectionChanged);
            // 
            // txtPlasman
            // 
            this.txtPlasman.Location = new System.Drawing.Point(422, 220);
            this.txtPlasman.Name = "txtPlasman";
            this.txtPlasman.ReadOnly = true;
            this.txtPlasman.Size = new System.Drawing.Size(21, 20);
            this.txtPlasman.TabIndex = 4;
            // 
            // dgvUcinci
            // 
            this.dgvUcinci.AllowUserToAddRows = false;
            this.dgvUcinci.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUcinci.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUcinci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUcinci.Location = new System.Drawing.Point(35, 52);
            this.dgvUcinci.MultiSelect = false;
            this.dgvUcinci.Name = "dgvUcinci";
            this.dgvUcinci.ReadOnly = true;
            this.dgvUcinci.RowHeadersVisible = false;
            this.dgvUcinci.RowHeadersWidth = 24;
            this.dgvUcinci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUcinci.Size = new System.Drawing.Size(292, 186);
            this.dgvUcinci.TabIndex = 5;
            this.dgvUcinci.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUcinci_CellFormatting);
            this.dgvUcinci.SelectionChanged += new System.EventHandler(this.dgvUcinci_SelectionChanged);
            // 
            // cmbStartnaPozicija
            // 
            this.cmbStartnaPozicija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartnaPozicija.FormattingEnabled = true;
            this.cmbStartnaPozicija.Location = new System.Drawing.Point(426, 8);
            this.cmbStartnaPozicija.Name = "cmbStartnaPozicija";
            this.cmbStartnaPozicija.Size = new System.Drawing.Size(46, 21);
            this.cmbStartnaPozicija.TabIndex = 1;
            // 
            // lblVremeGreska
            // 
            this.lblVremeGreska.AutoSize = true;
            this.lblVremeGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVremeGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVremeGreska.Location = new System.Drawing.Point(357, 100);
            this.lblVremeGreska.Name = "lblVremeGreska";
            this.lblVremeGreska.Size = new System.Drawing.Size(0, 15);
            this.lblVremeGreska.TabIndex = 21;
            // 
            // lblStartnaPozicijaGreska
            // 
            this.lblStartnaPozicijaGreska.AutoSize = true;
            this.lblStartnaPozicijaGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartnaPozicijaGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStartnaPozicijaGreska.Location = new System.Drawing.Point(402, 33);
            this.lblStartnaPozicijaGreska.Name = "lblStartnaPozicijaGreska";
            this.lblStartnaPozicijaGreska.Size = new System.Drawing.Size(0, 15);
            this.lblStartnaPozicijaGreska.TabIndex = 14;
            // 
            // lblPlasmanGreska
            // 
            this.lblPlasmanGreska.AutoSize = true;
            this.lblPlasmanGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlasmanGreska.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPlasmanGreska.Location = new System.Drawing.Point(406, 152);
            this.lblPlasmanGreska.Name = "lblPlasmanGreska";
            this.lblPlasmanGreska.Size = new System.Drawing.Size(0, 15);
            this.lblPlasmanGreska.TabIndex = 19;
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVreme.Location = new System.Drawing.Point(346, 54);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(56, 20);
            this.lblVreme.TabIndex = 17;
            this.lblVreme.Text = "Vreme";
            // 
            // lblStartnaPozicija
            // 
            this.lblStartnaPozicija.AutoSize = true;
            this.lblStartnaPozicija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartnaPozicija.Location = new System.Drawing.Point(298, 9);
            this.lblStartnaPozicija.Name = "lblStartnaPozicija";
            this.lblStartnaPozicija.Size = new System.Drawing.Size(118, 20);
            this.lblStartnaPozicija.TabIndex = 15;
            this.lblStartnaPozicija.Text = "Startna pozicija";
            // 
            // lblVozac
            // 
            this.lblVozac.AutoSize = true;
            this.lblVozac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVozac.Location = new System.Drawing.Point(31, 8);
            this.lblVozac.Name = "lblVozac";
            this.lblVozac.Size = new System.Drawing.Size(54, 20);
            this.lblVozac.TabIndex = 14;
            this.lblVozac.Text = "Vozač";
            // 
            // lblPlasman
            // 
            this.lblPlasman.AutoSize = true;
            this.lblPlasman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlasman.Location = new System.Drawing.Point(346, 220);
            this.lblPlasman.Name = "lblPlasman";
            this.lblPlasman.Size = new System.Drawing.Size(70, 20);
            this.lblPlasman.TabIndex = 16;
            this.lblPlasman.Text = "Plasman";
            // 
            // cmbVozac
            // 
            this.cmbVozac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVozac.FormattingEnabled = true;
            this.cmbVozac.Location = new System.Drawing.Point(95, 7);
            this.cmbVozac.Name = "cmbVozac";
            this.cmbVozac.Size = new System.Drawing.Size(151, 21);
            this.cmbVozac.TabIndex = 0;
            this.cmbVozac.SelectionChangeCommitted += new System.EventHandler(this.cmbVozac_SelectionChangeCommitted);
            this.cmbVozac.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbVozac_MouseDown);
            // 
            // btnDizmeni
            // 
            this.btnDizmeni.Enabled = false;
            this.btnDizmeni.Location = new System.Drawing.Point(38, 505);
            this.btnDizmeni.Name = "btnDizmeni";
            this.btnDizmeni.Size = new System.Drawing.Size(124, 44);
            this.btnDizmeni.TabIndex = 14;
            this.btnDizmeni.Text = "Dodaj učinak";
            this.btnDizmeni.UseVisualStyleBackColor = true;
            this.btnDizmeni.Visible = false;
            this.btnDizmeni.Click += new System.EventHandler(this.btnDizmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Enabled = false;
            this.btnObrisi.Location = new System.Drawing.Point(177, 505);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(124, 44);
            this.btnObrisi.TabIndex = 15;
            this.btnObrisi.Text = "Obriši učinak";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Visible = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // FrmEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 632);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.panelVozac);
            this.Controls.Add(this.panelTrka);
            this.Name = "FrmEntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEntity";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEntity_FormClosed);
            this.Resize += new System.EventHandler(this.FrmVozac_Resize);
            this.panelVozac.ResumeLayout(false);
            this.panelVozac1.ResumeLayout(false);
            this.panelVozac1.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelTrka.ResumeLayout(false);
            this.panelTrka1.ResumeLayout(false);
            this.panelTrka1.PerformLayout();
            this.panelPrijava.ResumeLayout(false);
            this.panelPrijava.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVreme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcinci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblDrzava;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblDatRodj;
        private System.Windows.Forms.DateTimePicker dtpVozac;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label lblImeGreska;
        private System.Windows.Forms.Label lblPrezimeGreska;
        private System.Windows.Forms.Label lblDrzavaGreska;
        private System.Windows.Forms.Panel panelVozac;
        private System.Windows.Forms.Panel panelTrka;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblBrojKrugova;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtBrojKrugova;
        private System.Windows.Forms.DateTimePicker dtpTrka;
        private System.Windows.Forms.Label lblNazivGreska;
        private System.Windows.Forms.Label lblBrojKrugovaGreska;
        private System.Windows.Forms.Label lblKategorijaGreska;
        private System.Windows.Forms.ComboBox cmbKategorija;
        private System.Windows.Forms.Label lblKategorija;
        private System.Windows.Forms.Label lblDatumGreska;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Panel panelPrijava;
        private System.Windows.Forms.Label lblVozac;
        private System.Windows.Forms.ComboBox cmbVozac;
        private System.Windows.Forms.Label lblPlasman;
        private System.Windows.Forms.Label lblStartnaPozicija;
        private System.Windows.Forms.Label lblVreme;
        private System.Windows.Forms.Label lblPlasmanGreska;
        private System.Windows.Forms.Label lblStartnaPozicijaGreska;
        private System.Windows.Forms.Label lblVremeGreska;
        private System.Windows.Forms.ComboBox cmbStartnaPozicija;
        private System.Windows.Forms.ComboBox cmbDrzava;
        private System.Windows.Forms.DataGridView dgvUcinci;
        private System.Windows.Forms.TextBox txtPlasman;
        private System.Windows.Forms.Button btnDizmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Panel panelTrka1;
        private System.Windows.Forms.Panel panelVozac1;
        private System.Windows.Forms.DataGridView dgvVreme;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Button btnGeneratorStaze;
        private System.Windows.Forms.Label lblStazaGreska;
        private System.Windows.Forms.Label lblDuzinaStaze;
        private System.Windows.Forms.Label lblNemaVozaca;
    }
}