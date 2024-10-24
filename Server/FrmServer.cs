using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : MaterialForm
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            btnPokreni.Enabled = false;
            btnZaustavi.Enabled = true;
            lblStatus.Text = "ONLINE";
            lblStatus.ForeColor = Color.Green;
            server = new Server();
            server.Start();
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblStatus.Text = "OFFLINE";
            lblStatus.ForeColor = Color.Gray;
            server.Stop();
        }

        private void FrmServer_Resize(object sender, EventArgs e)
        {
            panel.Location = new Point(ClientSize.Width / 2 - panel.Size.Width / 2, ClientSize.Height / 2 - panel.Size.Height / 2 + 30);
            if (ClientSize.Height < 324)
                panel.Dock = DockStyle.Fill;
            else
                panel.Dock = DockStyle.None;
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
