using Common.Communication;
using Common.Domen;
using MaterialSkin;
using MaterialSkin.Controls;
using Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using static Client.FrmEntities;

namespace Client
{
    public partial class FrmLogin : MaterialForm
    {
        private bool admin;
        private FrmStart frmStart;

        public FrmLogin(bool admin, FrmStart frmStart)
        {
            InitializeComponent();
            MaterialSkinSetTheme.SetTheme(this);

            this.admin = admin;
            this.frmStart = frmStart;
            if (!admin)
            {
                lblUsername.Text = "Ime";
                lblPassword.Text = "Prezime";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                try
                {
                    Communication.Instance.Connect();
                }
                catch (SocketException)
                {
                    MessageBox.Show("Server nije pronađen!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool result = false;
                if (admin)
                {
                    Korisnik user = new Korisnik()
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    };
                    object o = Communication.Instance.GetAll(user, user.Where(user.Username, user.Password));
                    if (o != null && (bool)o == true)
                        result = true;
                }
                else
                {
                    Vozac vozac = new Vozac();
                    List<Vozac> l = (List<Vozac>)Communication.Instance.GetAll(vozac, vozac.Where(txtUsername.Text, txtPassword.Text));
                    if (l.Count > 0)
                        result = true;
                }
                if (result)
                {
                    MessageBox.Show($"Dobrodošao {txtUsername.Text}!", "Prijava uspešna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmEntities fm = new FrmEntities(Entity.Vozac, admin, txtUsername.Text + (!admin ? " " + txtPassword.Text : ""));
                    fm.Show();
                    Hide();
                    frmStart.Hide();
                }
                else
                    MessageBox.Show("Korisnikčko ime ili lozinka nisu ispravni", "Prijava neuspešna", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Polje ne sme biti prazno!", "Prijava neuspešna", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(ClientSize.Width / 2 - panel1.Size.Width / 2, ClientSize.Height / 2 - panel1.Size.Height / 2);
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStart.Show();
        }
    }
}