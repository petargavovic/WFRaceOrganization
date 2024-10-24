using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Domen;
using static Client.FrmEntities;
using System.Diagnostics;
using Common.Communication;
using System.Globalization;
using MaterialSkin.Controls;
using MaterialSkin;
using static System.Resources.ResXFileRef;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using StazeZaTrke;
using System.Drawing.Drawing2D;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Net;

namespace Client
{
    public enum FormMode
    {
        Add,
        Details,
        Edit,
        Delete
    }

    public partial class FrmEntity : MaterialForm
    {
        FormMode mode;
        IEntity odabraniEntity;
        IEntity entity;
        List<Ucinak> ucinciPre;
        FrmEntities frmEntities;
        bool[] valid = new bool[4];
        string[] validationStrings;
        string[] originalValues = new string[5];
        List<string> paramNames;
        bool izmenaUcinka;
        bool yes = false;
        bool dodat = false;
        Ucinak odabraniUcinak;
        IOrderedEnumerable<Ucinak> ucinakOrdered;
        BindingList<Vozac> ucinciTrke;
        int heightOffset = 0;
        List<int> osam = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        BindingList<int> startnePozicije = new BindingList<int>();
        int plasman;
        int proslaVrednostVremena;
        int cmbRowIndex = -1;
        int pozicijaTrenutnog = 0;
        public string stazaJSON;
        public GraphicsPath trenutniPut = new GraphicsPath();
        public int duzinaStaze;

        public FrmEntity(FormMode mode = FormMode.Add)
        {
            InitializeComponent();
            this.mode = mode;
            PrepareForm(mode);
        }
        public FrmEntity(FormMode mode, FrmEntities frmEntities)
        {
            InitializeComponent();
            MaterialSkinSetTheme.SetTheme(this);
            entity = odabraniEntity = frmEntities.odabraniEntity;
            this.frmEntities = frmEntities;
            this.mode = mode;
            if (frmEntities.entityType == Entity.Vozac)
            {
                paramNames = new List<string> { "Ime", "Prezime", "Drzava", "DatumRodjenja" };
                List<string> countryList = new List<string>();
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo culture in cultures)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);
                    if (!(countryList.Contains(region.EnglishName)))
                        countryList.Add(region.EnglishName);
                }
                countryList = countryList.OrderBy(x => x).ToList();
                cmbDrzava.DataSource = countryList;
                Text = "Vozač";
                valid[3] = true;
            }
            else
            {
                panelTrka.Visible = true;
                panelVozac.Visible = false;
                if (mode != FormMode.Details)
                    paramNames = new List<string> { "Naziv", "BrojKrugova", "DatumTrke", "Kategorija", "Staza" };
                else
                {
                    paramNames = new List<string> { "Vozac", "Trka", "StartnaPozicija", "Plasman", "Vremena" };
                    dgvUcinci.DataSource = frmEntities.entityList2;
                    dgvUcinci.Columns["UcinakID"].Visible = dgvUcinci.Columns["Trka"].Visible = false;
                    for (int i = 6; i < dgvUcinci.Columns.Count; i++)
                        dgvUcinci.Columns[i].Visible = false;
                    ucinakOrdered = frmEntities.entityList2.ToList().OrderBy(x => x.Plasman);
                    ucinciPre = Extensions.DeepCopy(ucinakOrdered.ToList());
                    Vozac v = new Vozac();
                    ucinciTrke = new BindingList<Vozac>((List<Vozac>)Communication.Instance.GetAll(v));
                    dgvUcinci.Columns["Vozac"].HeaderText = "Vozač";
                    dgvUcinci.Columns["StartnaPozicija"].HeaderText = "Start";
                    dgvUcinci.Columns["Vremena"].HeaderText = "Vreme";
                    dgvUcinci.Columns["Vozac"].Width = 124;
                    dgvUcinci.Columns["StartnaPozicija"].Width = 55;
                    dgvUcinci.Columns["Plasman"].Width = 55;
                    dgvUcinci.Columns["Vremena"].Width = 55;
                    dgvUcinci.Columns["Plasman"].HeaderCell.Style.Font = new Font(dgvUcinci.Font.FontFamily, 8);
                }
                cmbKategorija.DataSource = new BindingList<Kategorija>((List<Kategorija>)Communication.Instance.GetAll(new Kategorija()));
                valid[2] = true;
                Text = "Trka";
                panelTrka1.Paint += new PaintEventHandler(panel_paint);
            }
            PrepareForm(mode);
        }

        private void PrepareForm(FormMode mode)
        {
            switch (mode)
            {
                case FormMode.Add:
                    if (frmEntities.entityType == Entity.Vozac)
                    {
                        this.Size = new Size(547, 362);
                        heightOffset = 170;
                    }
                    else
                    {
                        this.Size = new Size(547, 700);
                        heightOffset = -40;
                        btnGeneratorStaze.Visible = true;
                        btnGeneratorStaze.Location = new Point(202, 220);
                        lblStazaGreska.Location = new Point(202, 260);
                        lblDuzinaStaze.Location = new Point(25, 230);
                    }
                    FrmVozac_Resize(null, null);
                    break;
                case FormMode.Details:
                    SetDetails();
                    valid[0] = true;
                    valid[2] = true;
                    valid[3] = true;
                    if (frmEntities.entityType != Entity.Vozac)
                    {
                        txtNaziv.Enabled = false;
                        txtBrojKrugova.Enabled = false;
                        dtpTrka.Enabled = false;
                        cmbKategorija.Enabled = false;
                        panelPrijava.Visible = true;
                        btnDizmeni.Visible = true;
                        btnObrisi.Visible = true;
                        cmbVozac.DataSource = ucinciTrke;
                        if (ucinciTrke.Count == 0)
                        {
                            btnDizmeni.Visible = btnObrisi.Visible = false;
                            lblNemaVozaca.Visible = true;
                            btnSacuvaj.Text = "Izlaz";
                        }
                        if (frmEntities.entityList2.Count > 0)
                            startnePozicije =  new BindingList<int>(osam.Except(frmEntities.entityList2.Select(i => i.StartnaPozicija)).ToList());
                        else
                            startnePozicije = new BindingList<int>(osam);
                        cmbStartnaPozicija.DataSource = startnePozicije;
                        if (startnePozicije.Count == 8)
                            btnDizmeni.Text = "Prvo unesi sva vremena!";
                        else
                            btnDizmeni.Enabled = true;
                        entity = new Ucinak();
                        dgvVreme.ColumnCount = 3;
                        dgvVreme.Columns[0].Name = "Krug";
                        dgvVreme.Columns[1].Name = "min";
                        dgvVreme.Columns[2].Name = "sec";
                        dgvVreme.Columns[0].ReadOnly = true;
                        for (int i = 1; i <= ((Trka)odabraniEntity).BrojKrugova; i++)
                            dgvVreme.Rows.Add(i.ToString(), "", "");
                        lblNaziv.Location = new Point(34, 19);
                        lblBrojKrugova.Location = new Point(34, 69);
                        lblDatum.Location = new Point(34, 119);
                        lblKategorija.Location = new Point(34, 169);
                        txtNaziv.Location = new Point(38, 42);
                        txtBrojKrugova.Location = new Point(38, 92);
                        dtpTrka.Location = new Point(38, 142);
                        cmbKategorija.Location = new Point(38, 192);
                        lblDuzinaStaze.Location = new Point(350, 20);
                        if (duzinaStaze > 600 & trenutniPut.PointCount > 5)
                            trenutniPut = SkalirajPut(trenutniPut, 0.4f);
                        else
                            trenutniPut = SkalirajPut(trenutniPut, 0.6f);
                        PonasanjeForme.CentrirajPut(trenutniPut, 405, 130);
                        if (frmEntities.entityList2.Count == 0)
                            btnSacuvaj.Enabled = false;
                    }
                    break;
                case FormMode.Edit:
                    valid[3] = true;
                    if (frmEntities.entityType == Entity.Vozac)
                    {
                        this.Size = new Size(547, 362);
                        heightOffset = 170;
                    }
                    else
                    {
                        this.Size = new Size(547, 700);
                        heightOffset = -40;
                        btnGeneratorStaze.Visible = true;
                        btnGeneratorStaze.Location = new Point(202, 220);
                        btnGeneratorStaze.Text = "Promeni stazu";
                        lblDuzinaStaze.Location = new Point(54, 240);
                    }
                    FrmVozac_Resize(null, null);
                    SetDetails();
                    break;
            }
        }

        private void SetDetails()
        {
            if (frmEntities.entityType == Entity.Vozac)
            {
                originalValues[0] = txtIme.Text = (string)odabraniEntity.GetProperty("Ime");
                originalValues[1] = txtPrezime.Text = (string)odabraniEntity.GetProperty("Prezime");
                originalValues[2] = cmbDrzava.Text = (string)odabraniEntity.GetProperty("Drzava");
                dtpVozac.Value = (DateTime)odabraniEntity.GetProperty("DatumRodjenja");
                originalValues[3] = dtpVozac.Value.ToString();
            }
            else
            {
                originalValues[0] = txtNaziv.Text = odabraniEntity.GetProperty("Naziv").ToString();
                originalValues[1] = txtBrojKrugova.Text = odabraniEntity.GetProperty("BrojKrugova").ToString();
                dtpTrka.Value = (DateTime)odabraniEntity.GetProperty("DatumTrke");
                originalValues[2] = dtpTrka.Value.ToString();
                originalValues[3] = cmbKategorija.Text = odabraniEntity.GetProperty("Kategorija").ToString();
                stazaJSON = odabraniEntity.GetProperty("Staza").ToString();
                originalValues[4] = stazaJSON;
                LoadPath(stazaJSON);
            }
        }

        private bool IsChanged()
        {
            if (frmEntities.entityType == Entity.Vozac)
            {
                if (originalValues[0] != txtIme.Text)
                    return true;
                if (originalValues[1] != txtPrezime.Text)
                    return true;
                if (originalValues[2] != cmbDrzava.Text)
                    return true;
                if (originalValues[3] != dtpVozac.Value.ToString())
                    return true;
            }
            else
            {
                if (mode == FormMode.Details)
                    return true;
                if (originalValues[0] != txtNaziv.Text)
                    return true;
                if (originalValues[1] != txtBrojKrugova.Text)
                    return true;
                if (originalValues[2] != dtpTrka.Value.ToString())
                    return true;
                if (originalValues[3] != cmbKategorija.Text)
                    return true;
                if (originalValues[4] != stazaJSON)
                    return true;
            }
            return false;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (mode == FormMode.Details && ucinciTrke.Count == 0)
            {
                Close();
                return;
            }
            if (IsChanged())
            {
                string entityName = frmEntities.names[((int)frmEntities.entityType) * 3 + 1];
                if (IsValid())
                {
                    List<object> param;
                    if (frmEntities.entityType == Entity.Vozac)
                        param = new List<object> { txtIme.Text, txtPrezime.Text, cmbDrzava.Text, dtpVozac.Value };
                    else
                    {
                        if (mode != FormMode.Details)
                            param = new List<object> { txtNaziv.Text, int.Parse(txtBrojKrugova.Text), dtpTrka.Value.Date, cmbKategorija.SelectedItem, stazaJSON };
                        else
                        {
                            Ucinak u = frmEntities.entityList2.Last();
                            param = new List<object> { u.Vozac, odabraniEntity, u.StartnaPozicija, u.Plasman, u.Vremena };
                        }
                    }
                    IEntity entity = GetEntity(param, paramNames);
                    if (mode == FormMode.Add)
                    {
                        DialogResult dialogResult = MessageBox.Show($"Da li ste sigurni da želite da dodate {entityName}?",
                            $"Dodavanje {frmEntities.names[((int)frmEntities.entityType) * 3 + 2]}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            entity.Status = Status.Added;
                            Response response = Communication.Instance.SaveEntity(entity);
                            if (frmEntities.entityType == Entity.Trka)
                                ((Trka)entity).TrkaID = (int)response.Result;
                            else
                                ((Vozac)entity).VozacID = (int)response.Result;
                            frmEntities.entityList.Add(entity);
                            yes = true;
                            MessageBox.Show($"Sistem je zapamtio {entityName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (mode == FormMode.Edit)
                    {
                        DialogResult dialogResult = MessageBox.Show($"Da li ste sigurni da želite da izmenite {entityName}?",
                            $"Izmena {frmEntities.names[((int)frmEntities.entityType) * 3 + 2]}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string id = odabraniEntity.TableName + "ID";
                            IEntity entityIzListe = frmEntities.entityList.Where(v => (int)v.GetProperty(id) == (int)odabraniEntity.GetProperty(id)).First();
                            entityIzListe.SetAll(param, paramNames);
                            if (entityIzListe.Status != Status.Modified && entityIzListe.Status != Status.Added)
                            {
                                entityIzListe.Status = Status.Modified;
                                Response response = Communication.Instance.SaveEntity(entityIzListe);
                            }
                            MessageBox.Show($"Sistem je zapamtio {entityName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            yes = true;
                        }
                    }
                    else if (mode == FormMode.Details)
                    {
                        DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da izmenite rezultate trke?", "Izmena rezultata trke",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            entity.Status = Status.Added;
                            Ucinak granicnik = new Ucinak { UcinakID = -1, Trka = (Trka)odabraniEntity };
                            frmEntities.entityList2.Add(granicnik);
                            Response response = Communication.Instance.SaveEntities(new List<IEntity>(frmEntities.entityList2.Concat(ucinciPre).ToList()), Operation.SaveRezultati);
                            frmEntities.entityList2.Remove(granicnik);
                            if (response.Exception != null)
                                MessageBox.Show($"Sistem ne može da zapamti rezultate trke.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                frmEntities.listView.Items.Clear();
                                foreach (Ucinak ucinak in frmEntities.entityList2)
                                {
                                    if(ucinak.Status != Status.Deleted)
                                        frmEntities.AddListItem(ucinak);
                                }
                                frmEntities.btnSimulacija.Visible = frmEntities.listView.Items.Count > 0;
                                MessageBox.Show("Sistem je zapamtio rezultate trke.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                yes = true;
                            }
                        }
                    }
                    if (yes)
                    {
                        Dispose();
                        if (mode != FormMode.Details)
                        {
                            frmEntities.izmenjeno = true;
                            frmEntities.Sort(frmEntities.entityList);
                            frmEntities.dgv.Refresh();
                        }
                    }
                }
                else
                {
                    Object[] fields;
                    Label[] labels;
                    if (frmEntities.entityType == Entity.Vozac)
                    {
                        fields = new Object[] { txtIme, txtPrezime, dtpVozac };
                        labels = new Label[] { lblImeGreska, lblPrezimeGreska, lblDatumGreska };
                        for (int i = 0; i < fields.Length; i++)
                            RealtimeValidation(fields[i], labels[i]);
                    }
                    else
                    {
                        if (mode != FormMode.Details)
                        {
                            fields = new Object[] { txtNaziv, txtBrojKrugova };
                            labels = new Label[] { lblNazivGreska, lblBrojKrugovaGreska };
                            for (int i = 0; i < fields.Length; i++)
                                RealtimeValidation(fields[i], labels[i]);
                            if (!valid[3])
                            {
                                lblStazaGreska.Text = "Staza mora biti generisana!";
                                btnGeneratorStaze.BackColor = Color.Coral;
                            }
                        }
                    }
                    MessageBox.Show($"Sistem ne može da zapamti {entityName}.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Dispose();
                MessageBox.Show("Nema promena.", "Nije sačuvano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private IEntity GetEntity(List<object> param, List<string> paramNames)
        {
            IEntity entity = this.entity.VratiPrazan();
            entity.SetAll(param, paramNames);
            return entity;
        }

        #region validacija
        private bool IsValid()
        {
            foreach (bool v in valid)
                if (!v)
                    return false;
            return true;
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            RealtimeValidation(txtIme, lblImeGreska);
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            RealtimeValidation(txtPrezime, lblPrezimeGreska);
        }

        private void dtpVozac_ValueChanged(object sender, EventArgs e)
        {
            RealtimeValidation(dtpVozac, lblDatumGreska);
        }

        private void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            RealtimeValidation(txtNaziv, lblNazivGreska);
        }

        private void txtBrojKrugova_TextChanged(object sender, EventArgs e)
        {
            RealtimeValidation(txtBrojKrugova, lblBrojKrugovaGreska);
        }

        private void ChangetxtPlasman()
        {
            List<int> listVreme = frmEntities.entityList2.Where(i => i.Status != Status.Deleted).Select(i => i.VratiVremeUSekundama()).ToList();
            if (izmenaUcinka)
                listVreme.Remove(odabraniUcinak.VratiVremeUSekundama());
            IOrderedEnumerable<int> listVremeOrdered = listVreme.OrderBy(i => i);
            listVreme = listVremeOrdered.ToList();
            int insertedElement = listVreme.InsertElementAscending(VratiVremeIzTabele());
            plasman = listVreme.FindLastIndex(e => e == insertedElement) + 1;
            txtPlasman.Text = plasman.ToString();
        }

        public bool RealtimeValidation(Object field, Label lblGreska)
        {
            bool[] uslovi = ReturnConditions(field);
            bool svi = true;
            foreach (bool v in uslovi)
                if (!v)
                {
                    svi = false;
                    break;
                }
            if (!svi)
            {
                SetFieldValid(field, Color.Coral, false);
                if (!uslovi[0])
                    lblGreska.Text = validationStrings[0];
                else
                {
                    if (uslovi[1] && uslovi[2])
                        lblGreska.Text = "";
                    else if (!uslovi[1] && !uslovi[2])
                        lblGreska.Text = validationStrings[1];
                    else if (!uslovi[1] && uslovi[2])
                        lblGreska.Text = validationStrings[2];
                    else
                        lblGreska.Text = validationStrings[3];
                }
                return false;
            }
            else
            {
                lblGreska.Text = "";
                SetFieldValid(field, Color.White, true);
                return true;
            }
        }
        public bool[] ReturnConditions(Object field)
        {
            int n = 0;
            if (frmEntities.entityType == Entity.Vozac)
            {
                if (field.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)field;
                    validationStrings = new string[] { "Polje ne sme biti prazno!", "Sme sadržati samo slova i mora biti kraće od 32 karaktera!",
                        "Sme sadržati samo slova!" , "Mora biti kraće od 32 karaktera!" };
                    return new bool[] { !string.IsNullOrEmpty(txtBox.Text), txtBox.Text.All(char.IsLetter), txtBox.Text.Length <= 32 };
                }
                else
                {
                    validationStrings = new string[] { "Datum mora biti u prošlosti!", "", "", "" };
                    return new bool[] { ((DateTimePicker)field).Value < DateTime.Today, true, true };
                }
            }
            else
            {
                field.ToString();
                TextBox txtBox = (TextBox)field;
                if (txtBox.TabIndex == 0)
                {
                    validationStrings = new string[] { "Polje ne sme biti prazno!", "Mora biti kraće od 32 karaktera!",
                        "" , "Mora biti kraće od 32 karaktera!" };
                    return new bool[] { !string.IsNullOrEmpty(txtBox.Text), true, txtBox.Text.Length <= 32 };
                }
                else
                {
                    validationStrings = new string[] { "Polje ne sme biti prazno!", "Mora biti broj!", "Mora biti broj!", "Broj mora biti veći od nule!" };
                    return new bool[] { !string.IsNullOrEmpty(txtBox.Text), int.TryParse(txtBox.Text, out n), n > 0 };
                }
            }
        }

        private void SetFieldValid(Object txtBox, Color c, bool b)
        {
            if (txtBox.GetType() == typeof(TextBox))
            {
                ((TextBox)txtBox).BackColor = c;
                valid[((TextBox)txtBox).TabIndex] = b;
            }
            else
            {
                panelDate.BackColor = c;
                valid[((DateTimePicker)txtBox).TabIndex] = b;
            }
        }
        #endregion

        private void FrmVozac_Resize(object sender, EventArgs e)
        {
            if (frmEntities.entityType == Entity.Vozac)
                panelVozac1.Location = new Point((ClientSize.Width - 6) / 2 - panelVozac1.Size.Width / 2, (ClientSize.Height - 67 + heightOffset) / 2 - panelVozac1.Size.Height / 2);
            else
                panelTrka1.Location = new Point((ClientSize.Width - 6) / 2 - panelTrka1.Size.Width / 2, (ClientSize.Height - 67 + heightOffset) / 2 - panelTrka1.Size.Height / 2);
        }

        private void dgvUcinci_SelectionChanged(object sender, EventArgs e)
        {
            if (frmEntities.entityList2.Any())
            {
                btnObrisi.Enabled = true;
                if (cmbRowIndex == -1)
                    odabraniUcinak = (Ucinak)dgvUcinci.CurrentRow.DataBoundItem;
                else
                {
                    odabraniUcinak = (Ucinak)dgvUcinci.Rows[cmbRowIndex].DataBoundItem;
                    cmbRowIndex = -1;
                }
                if (!dodat)
                {
                    cmbVozac.Text = odabraniUcinak.Vozac.ToString();
                    if (!startnePozicije.Contains(odabraniUcinak.StartnaPozicija))
                        startnePozicije.InsertElementAscending(odabraniUcinak.StartnaPozicija);

                    if (pozicijaTrenutnog != odabraniUcinak.StartnaPozicija)
                        startnePozicije.Remove(pozicijaTrenutnog);
                }
                cmbStartnaPozicija.SelectedItem = odabraniUcinak.StartnaPozicija;
                pozicijaTrenutnog = odabraniUcinak.StartnaPozicija;

                txtPlasman.Text = odabraniUcinak.Plasman.ToString();
                txtVreme.Text = TimeSpan.FromSeconds(odabraniUcinak.VratiVremeUSekundama()).ToString(@"mm\:ss");
                btnDizmeni.Text = "Izmeni učinak";
                btnDizmeni.Enabled = true;
                izmenaUcinka = true;
                dgvVreme.Rows.Clear();
                string vremena = odabraniUcinak.Vremena;
                string[] krugovi = vremena.Split(';');
                int redniBr = 1;
                foreach (string krug in krugovi)
                {
                    string[] minsek = krug.Split(':');
                    dgvVreme.Rows.Add(redniBr.ToString(), minsek[0], minsek[1]);
                    redniBr++;
                }
                dgvVreme.ClearSelection();
            }
        }
        private void dgvUcinci_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUcinci.Columns[e.ColumnIndex].Name == "Vremena")
            {
                if (e.Value != null)
                {
                    e.Value = TimeSpan.FromSeconds(((Ucinak)dgvUcinci.Rows[e.RowIndex].DataBoundItem).VratiVremeUSekundama()).ToString(@"mm\:ss");
                    e.FormattingApplied = true;
                }
            }
        }

        private void cmbVozac_MouseDown(object sender, MouseEventArgs e)
        {
            izmenaUcinka = false;
        }

        private void cmbVozac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUcinci.Rows)
                if (((Ucinak)row.DataBoundItem).Vozac.VozacID == ((Vozac)cmbVozac.SelectedItem).VozacID)
                {
                    cmbRowIndex = row.Index;
                    dgvUcinci.CurrentCell = dgvUcinci.Rows[((Ucinak)row.DataBoundItem).Plasman - 1].Cells[dgvUcinci.Columns["Vozac"].Index];
                    return;
                }
            if(odabraniUcinak != null)
                startnePozicije.Remove(odabraniUcinak.StartnaPozicija);
            lblVremeGreska.Text = "";
            txtPlasman.Text = "";
            txtVreme.Text = "";
            if (frmEntities.entityList2.Count != 8)
                btnDizmeni.Text = "Prvo unesi sva vremena!";
            else
                btnDizmeni.Text = "Trka ima max broj vozača!";
            btnDizmeni.Enabled = false;
            dgvVreme.Rows.Clear();
            for (int i = 1; i <= ((Trka)odabraniEntity).BrojKrugova; i++)
                dgvVreme.Rows.Add(i.ToString(), "", "");
            dgvVreme.ClearSelection();
        }

        private void btnDizmeni_Click(object sender, EventArgs e)
        {
            if (!izmenaUcinka)
            {
                dodat = true;
                IEntity entity = GetEntity(new List<object>
            { cmbVozac.SelectedItem, odabraniEntity, cmbStartnaPozicija.Text, txtPlasman.Text, VratiStringIzTabele() }, paramNames);
                entity.Status = Status.Added;
                frmEntities.entityList2.Add((Ucinak)entity);
                int plasman = this.plasman;
                SrediObrisane(false);
                if (!btnSacuvaj.Enabled)
                    btnSacuvaj.Enabled = true;

                PonasanjeForme.PaintRows(dgvUcinci);
                dgvUcinci.ClearSelection();

                dgvUcinci.CurrentCell = dgvUcinci.Rows[plasman - 1].Cells[3];
                dgvUcinci.CurrentCell = dgvUcinci.Rows[plasman - 1].Cells[dgvUcinci.Columns["Vozac"].Index];
                dodat = false;
            }
            else
            {
                int currentRow = dgvUcinci.CurrentCell.RowIndex;
                Ucinak ucinak = frmEntities.entityList2.ElementAt(currentRow);
                ucinak.StartnaPozicija = int.Parse(cmbStartnaPozicija.Text);
                cmbStartnaPozicija.SelectedItem = ucinak.StartnaPozicija;
                ucinak.Vremena = VratiStringIzTabele();
                int plasmanStari = ucinak.Plasman;
                int plasmanNovi = plasman;
                ucinak.Plasman = plasmanNovi;

                Status statusPre = ucinak.Status;
                if (statusPre != Status.Added)
                {
                    if (ucinciPre.Count - 1 >= currentRow && (ucinak.Values != ucinak.Values))
                    {
                        if (statusPre != Status.Added)
                            ucinak.Status = Status.Modified;
                    }
                    else
                        if ((statusPre == Status.Deleted || statusPre == Status.Modified) && ucinciPre.Find(u => u.UpdateValues == ucinak.UpdateValues) != null)
                        ucinak.Status = Status.Unchanged;
                    else
                        ucinak.Status = Status.Modified;
                }
                if (plasmanStari != plasmanNovi || statusPre == Status.Deleted)
                    SrediObrisane(true);
                else
                    dgvUcinci.Refresh();
                PonasanjeForme.PaintRows(dgvUcinci);
                txtPlasman.Text = odabraniUcinak.Plasman.ToString();
            }
            btnDizmeni.Text = "Izmeni učinak";
            izmenaUcinka = true;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            int currentRow = dgvUcinci.CurrentCell.RowIndex;
            frmEntities.entityList2.ElementAt(currentRow).Status = Status.Deleted;
            SrediObrisane(false);
            PonasanjeForme.PaintRows(dgvUcinci);
        }
        private void SrediObrisane(bool plasmanPromenjenIliObrisan)
        {
            Dictionary<int, Ucinak> zaBrisanje = new Dictionary<int, Ucinak>();
            for (int i = 0; i < frmEntities.entityList2.Count(); i++)
                if (frmEntities.entityList2.ElementAt(i).Status == Status.Deleted)
                    zaBrisanje.Add(i, frmEntities.entityList2.ElementAt(i));

            int brObrisanih = 0;
            foreach (int i in zaBrisanje.Keys)
            {
                frmEntities.entityList2.RemoveAt(i - brObrisanih);
                brObrisanih++;
            }

            frmEntities.entityList2 = new BindingList<Ucinak> (frmEntities.entityList2.OrderBy(x => x.VratiVremeUSekundama()).ToList());
            dgvUcinci.DataSource = frmEntities.entityList2;

            for (int i = 0; i < frmEntities.entityList2.ToList().Count; i++)
            {
                if (frmEntities.entityList2.ElementAt(i).Plasman != i + 1)
                {
                    frmEntities.entityList2.ElementAt(i).Plasman = i + 1;
                    Status status = frmEntities.entityList2.ElementAt(i).Status;
                    if (status != Status.Added)
                    {
                        if (!plasmanPromenjenIliObrisan)
                            frmEntities.entityList2.ElementAt(i).Status = Status.Modified;
                        else
                        {
                            if (ucinciPre.ElementAt(i) == null || ucinciPre.ElementAt(i).Values != frmEntities.entityList2.ElementAt(i).Values)
                                frmEntities.entityList2.ElementAt(i).Status = Status.Modified;
                            else
                                frmEntities.entityList2.ElementAt(i).Status = Status.Unchanged;
                        }
                    }
                }
            }
            for (int i = 0; i < zaBrisanje.Count; i++)
                frmEntities.entityList2.Insert(zaBrisanje.Keys.ElementAt(i), zaBrisanje.Values.ElementAt(i));
        }

        private void dgvVreme_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                int newInteger, min, sek;
                if (dgvVreme[2, e.RowIndex].Value == null)
                    dgvVreme[2, e.RowIndex].Value = proslaVrednostVremena;
                if (!int.TryParse(dgvVreme[2, e.RowIndex].Value.ToString(), out sek))
                    sek = -1;
                if (dgvVreme[1, e.RowIndex].Value == null)
                    dgvVreme[1, e.RowIndex].Value = proslaVrednostVremena;
                if (!int.TryParse(dgvVreme[1, e.RowIndex].Value.ToString(), out min))
                    min = -1;
                if (!int.TryParse(dgvVreme[e.ColumnIndex, e.RowIndex].Value.ToString(), out newInteger) ||
                    (e.ColumnIndex == 1 & (!(newInteger >= 0 & newInteger <= 59) || (newInteger == 0 & sek == 0))) ||
                    (e.ColumnIndex == 2 & (!(newInteger >= 0 & newInteger <= 59) || (newInteger == 0 & min == 0))))
                {
                    int donjaGranica = 0;
                    if ((min == 0 & (newInteger <= 0 || newInteger >= 60)) || (newInteger <= 0 & sek == 0))
                        donjaGranica = 1;
                    dgvVreme.Rows[e.RowIndex].ErrorText = $"Broj mora biti između {donjaGranica}-59";
                    MessageBox.Show($"Mora biti ceo broj između {donjaGranica}-59", "Neispravan unos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvVreme[e.ColumnIndex, e.RowIndex].Value = proslaVrednostVremena;
                }
                else
                {
                    int time = VratiVremeIzTabele();
                    TimeSpan timespan = TimeSpan.FromSeconds(time);
                    txtVreme.Text = timespan.ToString(@"mm\:ss");
                    bool valid = true;
                    foreach (DataGridViewRow row in dgvVreme.Rows)
                        if (!(int.TryParse(row.Cells[1].Value.ToString(), out _) & int.TryParse(row.Cells[2].Value.ToString(), out _)))
                        {
                            valid = false;
                            break;
                        }
                    if (valid)
                    {
                        ChangetxtPlasman();
                        if (frmEntities.entityList2.Count != 8)
                        {
                            if (!izmenaUcinka)
                            {
                                btnDizmeni.Enabled = true;
                                btnDizmeni.Text = "Dodaj učinak";
                            }
                        }
                    }
                }
            }
        }

        private int VratiVremeIzTabele()
        {
            int time = 0;
            foreach (DataGridViewRow row in dgvVreme.Rows)
            {
                if (int.TryParse(row.Cells[1].Value.ToString(), out _))
                    time += Convert.ToInt32(row.Cells[1].Value) * 60;
                if (int.TryParse(row.Cells[2].Value.ToString(), out _))
                    time += Convert.ToInt32(row.Cells[2].Value);
            }
            return time;
        }

        private string VratiStringIzTabele()
        {
            string vremena = "";
            foreach (DataGridViewRow row in dgvVreme.Rows)
                if (int.TryParse(row.Cells[1].Value.ToString(), out _) & int.TryParse(row.Cells[2].Value.ToString(), out _))
                {
                    vremena += row.Cells[1].Value.ToString() + ":" + row.Cells[2].Value.ToString();
                    if (row.Index != dgvVreme.RowCount - 1)
                        vremena += ";";
                }
            return vremena;
        }

        private void dgvVreme_SelectionChanged(object sender, EventArgs e)
        {
            int value;
            if (dgvVreme.SelectedCells.Count == 1)
            {
                if (int.TryParse(dgvVreme.SelectedCells[0].Value.ToString(), out value))
                {
                    proslaVrednostVremena = value;
                }
            }
        }

        private void btnGeneratorStaze_Click(object sender, EventArgs e)
        {
            FrmGeneratorStaze generatorStaze = new FrmGeneratorStaze(this, trenutniPut);
            generatorStaze.Show();
            this.Hide();
        }

        private string SerializePath(GraphicsPath path)
        {
            PointF[] points = path.PathPoints;
            return JsonSerializer.Serialize(points.Select(p => new { p.X, p.Y }).ToList());
        }

        public static GraphicsPath DeserializujPut(string json)
        {
            List<PointF> pointsList = JsonSerializer.Deserialize<List<PointF>>(json);
            GraphicsPath path = new GraphicsPath();
            path.AddLines(pointsList.ToArray());
            path.CloseFigure();
            return path;
        }

        public void SavePath(GraphicsPath currentPath, int duzinaStaze)
        {
            stazaJSON = SerializePath(currentPath);
            this.trenutniPut = currentPath;
            this.duzinaStaze = duzinaStaze;
            valid[3] = true;
            lblStazaGreska.Text = "";
            lblDuzinaStaze.Text = "Dužina staze: " + duzinaStaze + "m";
        }

        private void LoadPath(string json)
        {
            trenutniPut = DeserializujPut(json);
            duzinaStaze = (int)Math.Round((PonasanjeForme.DuzinaPuta(trenutniPut) - 500) * 4 + 1000);
            lblDuzinaStaze.Text = "Dužina staze: " + duzinaStaze + "m";
            PonasanjeForme.CentrirajPut(trenutniPut, 270, 405);
            this.Invalidate();
        }

        public GraphicsPath SkalirajPut(GraphicsPath put, float faktorSkaliranja)
        {
            GraphicsPath skaliranPut = new GraphicsPath();
            Matrix matricaSkaliranja = new Matrix();
            matricaSkaliranja.Scale(faktorSkaliranja, faktorSkaliranja, MatrixOrder.Append);

            PointF[] tackePuta = put.PathPoints;
            for (int i = 0; i < tackePuta.Length; i++)
            {
                tackePuta[i] = new PointF(
                    tackePuta[i].X * faktorSkaliranja,
                    tackePuta[i].Y * faktorSkaliranja
                );
            }

            skaliranPut.AddLines(tackePuta);
            skaliranPut.CloseFigure();

            return skaliranPut;
        }

        protected void panel_paint(object sender, PaintEventArgs e)
        {
            if (trenutniPut != null)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.Black, 4))
                    g.DrawPath(pen, trenutniPut);

                PonasanjeForme.NacrtajStartnuLiniju(trenutniPut, g);
            }
        }

        private void FrmEntity_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mode == FormMode.Details && !yes)
                frmEntities.entityList2 = new BindingList<Ucinak>(ucinciPre);
        }
    }

    public static class Extensions
    {
        public static int InsertElementAscending(this List<int> source,
                int element)
        {
            int index = source.FindLastIndex(e => e < element);
            if (index == -1)
            {
                source.Insert(0, element);
                return element;
            }
            source.Insert(index + 1, element);
            return element;
        }
        public static int InsertElementAscending(this BindingList<int> source,
                int element)
        {
            int index = source.ToList().FindLastIndex(e => e < element);
            if (index == -1)
            {
                source.Insert(0, element);
                return element;
            }
            source.Insert(index + 1, element);
            return element;
        }

        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
