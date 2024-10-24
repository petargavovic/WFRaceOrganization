using Common;
using Common.Communication;
using Common.Domen;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    public partial class FrmEntities : MaterialForm
    {
        public List<IEntity> entityList;
        public BindingList<Ucinak> entityList2;
        public IEntity odabraniEntity;
        public Entity entityType;
        List<IEntity> pretrazeniEntity;
        IOrderedEnumerable<IEntity> sortiranUpit = null;
        List<Plasman> plasmanList;
        public bool izmenjeno;
        public bool pretrazeno;
        bool admin;
        bool itemSortAsc;
        bool uPretrazi;
        List<string> listaAtributa;
        public string[] names = { "Vozači", "vozača", "vozača", "Trke", "trku", "trke", "Rang Liste", "rang listu", "rang liste" };
        string[] strings;
        string prop;
        Converter<IEntity, Vozac> converterV;
        Converter<IEntity, Trka> converterT;
        Converter<IEntity, RangLista> converterRG;
        Converter<IEntity, Ucinak> converterU;
        Converter<Ucinak, IEntity> converterE;
        Rectangle dgvOriginalRectangle;
        Rectangle originalFormSize;
        public ComboBox cmbSort;
        public TrackBar tbAscDesc;
        readonly Image img1, img2, img3, img4, img5;

        public enum Entity
        {
            Vozac,
            Trka,
            RangLista
        }

        public FrmEntities(Entity entityType, bool admin, string username)
        {
            InitializeComponent();
            MaterialSkinSetTheme.SetTheme(this);
            this.admin = admin;
            lblUsername.Text = username;
            img1 = toolStripButton1.Image;
            img2 = toolStripButton2.Image;
            img3 = toolStripButton3.Image;
            img4 = toolStripButton4.Image;
            img5 = btnPretraga.BackgroundImage;
            SetForEntity(entityType);
        }

        private void SetForEntity(Entity entityType)
        {
            this.entityType = entityType;
            strings = new string[]{ "Trka", "Startni broj", "Plasman", "Vremena", "Vozač", "Startni broj", "Plasman", "Vremena", "Vozač", "Redni broj", "Broj poena", "" };
            int strPos = ((int)entityType) * 4;
            for (int i = 0; i < listView.Columns.Count; i++)
                listView.Columns[i].Text = strings[i + strPos];
            strings[strPos] = new string(strings[strPos].Select(c => c == 'č' ? 'c' : c).ToArray());
            prop = strings[strPos];
            cmbSort = cmbSort2;
            tbAscDesc = tbAscDesc2;
            converterU = Ucinak.EntityToUcinak;
            converterE = Ucinak.UcinakToEntity;
            if (entityType != Entity.RangLista)
            {
                if (entityType == Entity.Vozac)
                {
                    odabraniEntity = new Vozac();
                    converterV = Vozac.EntityToVozac;
                    btnRezultat.Visible = false;
                    toolStripButton1.Enabled = false;
                    entityList = new List<IEntity>((List<Vozac>)Communication.Instance.GetAll(odabraniEntity));
                }
                else if (entityType == Entity.Trka)
                {
                    odabraniEntity = new Trka();
                    converterT = Trka.EntityToTrka;
                    toolStripButton2.Enabled = false;
                    btnRezultat.Visible = admin;
                    entityList = new List<IEntity>((List<Trka>)Communication.Instance.GetAll(odabraniEntity, odabraniEntity.Where()));
                }
                if (listView.Columns.Count != 4)
                {
                    listView.Columns.Add("Vremena");
                    listView.Columns[1].DisplayIndex = 1;
                }
                panel1.Visible = admin;
                if (admin)
                {
                    cmbSort = cmbSort1;
                    tbAscDesc = tbAscDesc1;
                }
                panelSort.Visible = !admin;
            }
            else
            {
                odabraniEntity = new RangLista();
                converterRG = RangLista.EntityToRangLista;
                btnRezultat.Visible = false;
                if (listView.Columns.Count == 4)
                    listView.Columns[3].Dispose();
                listView.Columns[1].DisplayIndex = 0;
                toolStripButton3.Enabled = false;
                panel1.Visible = false;
                panelSort.Visible = true;
                entityList = new List<IEntity>((List<RangLista>)Communication.Instance.GetAll(odabraniEntity, odabraniEntity.Where()));
            }
            this.Text = names[(int)entityType * 3];
            SetDataSource(entityList);
            listaAtributa = new List<string>();
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (i < dgv.ColumnCount - 8 && i != 0)
                    listaAtributa.Add(dgv.Columns[i].HeaderText);
                else
                    dgv.Columns[i].Visible = false;
            }
            if (entityType == Entity.Trka)
                listaAtributa.RemoveAt(listaAtributa.Count - 1);
            cmbSort.DataSource = listaAtributa;
            List<string> listaPretraga = listaAtributa.ToList();
            if (entityType == Entity.Vozac)
            {
                listaPretraga.RemoveRange(0, 2);
                listaPretraga.Insert(0, "Ime i prezime");
            }
            listaPretraga.Insert(0, "Sve");
            cmbPretraga.DataSource = listaPretraga;
        }

        private List<IEntity> VratiRangListe(string where)
        {
            List<IEntity> responseList = (List<IEntity>)Communication.Instance.GetAll(odabraniEntity, where);
            bool rangListe = true;
            List<IEntity> lista = new List<IEntity>();
            plasmanList = new List<Plasman>();
            foreach (IEntity entity in responseList)
            {
                if (rangListe)
                {
                    if (entity.Id == "-1")
                    {
                        rangListe = false;
                        continue;
                    }
                    lista.Add(entity);
                }
                else
                    plasmanList.Add((Plasman)entity);
            }
            return lista;
        }

        private void cmbSort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SortOnValueChanged();
        }

        private void tbAscDesc_ValueChanged(object sender, EventArgs e)
        {
            SortOnValueChanged();
        }

        private void cmbSort2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SortOnValueChanged();
        }

        private void tbAscDesc2_ValueChanged(object sender, EventArgs e)
        {
            SortOnValueChanged();
        }

        public void SortOnValueChanged()
        {
            if (!pretrazeno)
                Sort(entityList);
            else
                Sort(pretrazeniEntity);
        }

        public void Sort(List<IEntity> entities)
        {
            bool asc = true && tbAscDesc.Value == 0;
            string name = dgv.Columns[cmbSort.SelectedIndex + 1].Name;
            if (asc)
                sortiranUpit = (name != "Kategorija") ? entities.OrderBy(x => x.GetProperty(name))
                : entities.OrderBy(x => (Kategorija)x.GetProperty(name));
            else
                sortiranUpit = (name != "Kategorija") ? entities.OrderByDescending(x => x.GetProperty(name))
                : entities.OrderByDescending(x => (Kategorija)x.GetProperty(name));

            SetDataSource(sortiranUpit.ToList());

            if (izmenjeno)
                PonasanjeForme.PaintRows(dgv);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmEntity frm = new FrmEntity(FormMode.Add, this);
            frm.Show();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Response response = Communication.Instance.LoadOne((IEntity)dgv.CurrentRow.DataBoundItem);
            if (response.Exception != null)
            {
                MessageBox.Show($"Sistem ne može da učita {names[(int)entityType * 3 + 1]}.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.WriteLine(response.Exception.Message);
            }
            else
            {
                FrmEntity frm = new FrmEntity(FormMode.Edit, this);
                frm.Show();
                if (entityType == Entity.Vozac)
                    odabraniEntity = (Vozac)response.Result;
                else
                {
                    List<IEntity> odgovor = (List<IEntity>)response.Result;
                    odabraniEntity = (Trka)odgovor.First();
                    odgovor.RemoveAt(0);
                    entityList2 = new BindingList<Ucinak>(odgovor.ConvertAll(converterU));
                    entityList2.Reverse();
                }
                MessageBox.Show($"Sistem je učitao {names[(int)entityType * 3 + 1]}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRezultat_Click(object sender, EventArgs e)
        {
            Response response = Communication.Instance.LoadOne((IEntity)dgv.CurrentRow.DataBoundItem);
            if (response.Exception != null)
            {
                MessageBox.Show($"Sistem ne može da učita trku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.WriteLine(response.Exception.Message);
            }
            else
            {
                List<IEntity> odgovor = (List<IEntity>)response.Result;
                odabraniEntity = (Trka)odgovor.First();
                odgovor.RemoveAt(0);
                List<Ucinak> ucinci = odgovor.ConvertAll(converterU);
                entityList2 = new BindingList<Ucinak>(odgovor.ConvertAll(converterU));
                FrmEntity frm = new FrmEntity(FormMode.Details, this);
                frm.Show();
                MessageBox.Show("Sistem je učitao trku.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Da li ste sigurni da želite da obrišete {names[((int)entityType) * 3 + 1]}?",
                            $"Brisanje {names[((int)entityType) * 3 + 2]}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                odabraniEntity = (IEntity)dgv.CurrentRow.DataBoundItem;
                odabraniEntity.Status = Status.Deleted;
                Response response = Communication.Instance.SaveEntity(odabraniEntity);
                izmenjeno = true;
                Sort(entityList);
            }
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            uPretrazi = true;
            string vrednost = txtPretraga.Text;
            int parametar = cmbPretraga.SelectedIndex+1;
            SetDataSource(entityList);

            if (!string.IsNullOrEmpty(vrednost))
            {
                List<Kategorija> kategorije = (List<Kategorija>)Communication.Instance.GetAll(new Kategorija());
                string kat = "";
                foreach (Kategorija k in kategorije)
                    kat += k.KategorijaID + "=" + k.NazivKategorije + ";";
                kat += "$";
                switch (entityType)
                {
                    case Entity.Vozac:
                        pretrazeniEntity = new List<IEntity>((List<Vozac>)Communication.Instance.GetAll(odabraniEntity, odabraniEntity.Where("$" + dgv.Columns[parametar].Name, vrednost)));
                        break;
                    case Entity.Trka:
                        pretrazeniEntity = new List<IEntity>((List<Trka>)Communication.Instance.GetAll(odabraniEntity, odabraniEntity.Where(kat + dgv.Columns[parametar-1].Name, vrednost)));
                        break;
                    case Entity.RangLista:
                        pretrazeniEntity = new List<IEntity>((List<RangLista>)Communication.Instance.GetAll(odabraniEntity, odabraniEntity.Where(kat + dgv.Columns[parametar-1].Name, vrednost)));
                        break;
                }
                pretrazeno = true;

                SetDataSource(pretrazeniEntity);
                dgv.Columns[0].Visible = false;
                Sort(pretrazeniEntity);


                if (pretrazeniEntity.Count != 0)
                {
                    MessageBox.Show($"Sistem je našao {names[(int)entityType * 3 + 2]} po zadatoj vrednosti.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(entityType == Entity.RangLista)
                        MessageBox.Show($"Sistem je učitao {names[(int)entityType * 3 + 1]}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnIzmeni.Enabled = false;
                    btnRezultat.Enabled = false;
                    MessageBox.Show($"Sistem ne može da nađe {names[(int)entityType * 3 + 2]} po zadatoj vrednosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                pretrazeno = false;
                Sort(entityList);
                if(entityList.Count != 0)
                    MessageBox.Show($"Sistem je učitao {names[(int)entityType * 3 + 1]}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            uPretrazi = false;
        }

        private void txtPretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPretraga_Click(null, null);
        }

        private void SetDataSource(List<IEntity> entityList)
        {
            if (entityType == Entity.Vozac)
                dgv.DataSource = new BindingList<Vozac>(entityList.ConvertAll(converterV));
            else if (entityType == Entity.Trka)
                dgv.DataSource = new BindingList<Trka>(entityList.ConvertAll(converterT));
            else
                dgv.DataSource = new BindingList<RangLista>(entityList.ConvertAll(converterRG));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToolStripClick(Entity.Vozac, false, true, true);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ToolStripClick(Entity.Trka, true, false, true);
            dgv.Columns["Naziv"].DisplayIndex = 0;
            dgv.Columns["Kategorija"].DisplayIndex = 1;
            dgv.Columns["BrojKrugova"].DisplayIndex = 2;
            dgv.Columns["Staza"].Visible = false;
            btnObrisi.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dgv.SelectionChanged -= dgv_SelectionChanged;
            ToolStripClick(Entity.RangLista, true, true, false);
            dgv.SelectionChanged += dgv_SelectionChanged;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Communication.Instance.Exit();
            FrmStart frm = new FrmStart();
            frm.Show();
            Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (MaterialSkinSetTheme.theme == MaterialSkinManager.Themes.DARK)
            {
                MaterialSkinSetTheme.theme = MaterialSkinManager.Themes.LIGHT;
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                toolStripButton1.Image = img1;
                toolStripButton2.Image = img2;
                toolStripButton3.Image = img3;
                toolStripButton4.Image = img4;
                btnPretraga.BackgroundImage = img5;
            }
            else
            {
                MaterialSkinSetTheme.theme = MaterialSkinManager.Themes.DARK;
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(255, 50, 50, 50);
                string[] s = { "\\bin" };
                toolStripButton1.Image = Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\steering_wheel_white.png");
                toolStripButton2.Image = Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\flag_white.png");
                toolStripButton3.Image = Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\leaderboard_white.png");
                toolStripButton4.Image = Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\log-out_white.png");
                btnPretraga.BackgroundImage = Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\search_white.png");
            }
            MaterialSkinSetTheme.SetTheme(this);
        }

        private async void ToolStripClick(Entity e, bool one, bool two, bool three)
        {
            SetForEntity(e);
            listView.Items.Clear();
            btnIzmeni.Enabled = btnRezultat.Enabled = btnSimulacija.Visible = false;
            await Task.Delay(1);
            PonasanjeForme.ResizeListViewColumns(listView);
            toolStripButton1.Enabled = one;
            toolStripButton2.Enabled = two;
            toolStripButton3.Enabled = three;
            itemSortAsc = false;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            listView.Items.Clear();
            if (dgv.SelectedCells.Count > 0 && dgv.SelectedCells[0].Value != null)
            {
                btnIzmeni.Enabled = btnRezultat.Enabled = true;
                odabraniEntity = (IEntity)dgv.CurrentRow.DataBoundItem;
                bool ucitaoMsg = false;
                Ucinak u = null;
                if (entityType == Entity.Vozac)
                    u = new Ucinak { Vozac = (Vozac)odabraniEntity };
                else if (entityType == Entity.Trka)
                    u = new Ucinak { Trka = (Trka)odabraniEntity };
                List<IEntity> plasmani;
                if (u != null)
                {
                    entityList2 = new BindingList<Ucinak>((List<Ucinak>)Communication.Instance.GetAll(u, u.Where(odabraniEntity.Id, odabraniEntity.TableName)));
                    btnObrisi.Enabled = !entityList2.Any();
                    foreach (IEntity entity in entityList2)
                        AddListItem(entity);
                    if (entityType == Entity.Trka)
                    {
                        if (btnObrisi.Enabled)
                            btnRezultat.Text = "Unesi rezultate trke";
                        else
                            btnRezultat.Text = "Izmeni rezultate trke";
                    }
                    else
                        btnRezultat.Text = "Unesi rezultate trke";
                }
                else
                {
                    Response response = Communication.Instance.LoadOne((IEntity)dgv.CurrentRow.DataBoundItem);
                    if (response.Exception != null)
                    {
                        MessageBox.Show($"Sistem ne može da učita {names[(int)entityType * 3 + 1]}.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Debug.WriteLine(response.Exception.Message);
                        return;
                    }
                    else
                    {
                        List<IEntity> odgovor = (List<IEntity>)response.Result;
                        entityList[dgv.CurrentRow.Index] = (RangLista)odgovor.First();
                        odgovor.RemoveAt(0);
                        odgovor.Reverse();
                        plasmani = odgovor;
                        ucitaoMsg = true;
                        foreach (IEntity entity in plasmani)
                            AddListItem(entity);
                    }
                }
                
                if ((PonasanjeForme.GetWindowLong(listView.Handle, -16) & 0x00200000) != 0)
                    listView.Columns[1].Width = listView.Width / listView.Columns.Count - SystemInformation.VerticalScrollBarWidth;
                else
                    listView.Columns[1].Width = listView.Width / listView.Columns.Count;
                if (entityType == Entity.Trka)
                {
                    if (entityList2.Count > 0)
                        btnSimulacija.Visible = true;
                    else
                        btnSimulacija.Visible = false;
                }
                else if (u == null)
                    for (int i = 0; i < listView.Items.Count; i++)
                        listView.Items[i].SubItems[1].Text = (i + 1).ToString();
                itemSortAsc = false;
                if (!uPretrazi && ucitaoMsg)
                    MessageBox.Show($"Sistem je učitao {names[(int)entityType * 3 + 1]}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSimulacija_Click(object sender, EventArgs e)
        {
            FrmSimulacija frmSim = new FrmSimulacija((Trka)odabraniEntity, entityList2, this);
            frmSim.Show();
            this.Hide();
        }

        public void AddListItem(IEntity entity)
        {
            ListViewItem item = new ListViewItem(entity.GetProperty(prop).ToString());
            item.SubItems.Add(entity.GetType().GetProperties()[3].GetValue(entity).ToString());
            item.SubItems.Add(entity.GetType().GetProperties()[4].GetValue(entity).ToString());
            if (entityType != Entity.RangLista)
                item.SubItems.Add(TimeSpan.FromSeconds(((Ucinak)entity).VratiVremeUSekundama()).ToString(@"mm\:ss"));
            listView.Items.Add(item);
        }

        private void FrmEntities_Resize(object sender, EventArgs e)
        {
            PonasanjeForme.ResizeControl(dgvOriginalRectangle, dgv, originalFormSize, Width, Height);
            PonasanjeForme.ResizeListViewColumns(listView, 1);
        }

        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cmbSort.SelectedIndex != e.ColumnIndex - 1)
            {
                tbAscDesc.Value = 0;
                cmbSort.SelectedIndex = e.ColumnIndex - 1;
                SortOnValueChanged();
            }
            else
                tbAscDesc.Value = tbAscDesc.Value == 0 ? 1 : 0;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (dgv.SelectedCells.Count != 0)
            {
                if (entityType != Entity.RangLista)
                {
                    List<Ucinak> sortedEntityList = entityList2.ToList();
                    string property = strings[e.Column + ((int)entityType) * 4];
                    if (property.Contains(" "))
                        property = "StartnaPozicija";
                    if (property == "Vremena")
                    {
                        if (itemSortAsc)
                            sortedEntityList = sortedEntityList.OrderBy(x => x.VratiVremeUSekundama()).ToList();
                        else
                            sortedEntityList = sortedEntityList.OrderByDescending(x => x.VratiVremeUSekundama()).ToList();
                    }
                    else
                    {
                        if (itemSortAsc)
                            sortedEntityList = sortedEntityList.OrderBy(x => x.GetProperty(property)).ToList();
                        else
                            sortedEntityList = sortedEntityList.OrderByDescending(x => x.GetProperty(property)).ToList();
                    }
                    itemSortAsc = !itemSortAsc;
                    listView.Items.Clear();
                    foreach (IEntity entity in sortedEntityList)
                        AddListItem(entity);
                }
                else
                {
                    List<ListViewItem> stavkeListe = new List<ListViewItem>();
                    foreach (ListViewItem item in listView.Items)
                        stavkeListe.Add(item);
                    if (itemSortAsc)
                        stavkeListe = (int.TryParse(listView.Items[0].SubItems[e.Column].Text, out _)) ? stavkeListe.OrderBy(x => int.Parse(x.SubItems[e.Column].Text)).ToList() :
                        stavkeListe.OrderBy(x => x.SubItems[e.Column].Text).ToList();
                    else
                        stavkeListe = (int.TryParse(listView.Items[0].SubItems[e.Column].Text, out _)) ? stavkeListe.OrderByDescending(x => int.Parse(x.SubItems[e.Column].Text)).ToList() :
                        stavkeListe.OrderByDescending(x => x.SubItems[e.Column].Text).ToList();
                    itemSortAsc = !itemSortAsc;
                    listView.Items.Clear();
                    foreach (ListViewItem item in stavkeListe)
                        listView.Items.Add(item);
                }
            }
        }

        private void FrmEntities_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(Location.X, Location.Y, Width
                , Height);
            dgvOriginalRectangle = new Rectangle(dgv.Location.X, dgv.Location.Y, dgv.Width
                , dgv.Height);
            if (admin)
                PonasanjeForme.ResizeListViewColumns(listView);
            else
                PonasanjeForme.ResizeListViewColumns(listView, 494);
        }

        private void FrmEntities_FormClosed(object sender, FormClosedEventArgs e)
        {
            Communication.Instance.Exit();
            Environment.Exit(0);
        }
    }
}
