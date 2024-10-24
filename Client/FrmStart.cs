using Common;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client.FrmEntities;

namespace Client
{
    public partial class FrmStart : MaterialForm
    {
        private Rectangle buttonOriginalRectangleL;
        private Rectangle buttonOriginalRectangleD;
        private Rectangle originalFormSize;

        public FrmStart()
        {
            InitializeComponent();

            MaterialSkinSetTheme.SetTheme(this);
            string[] s = { "\\bin" };

            PonasanjeForme.ButtonImageInit(new Button[] { btnDesni }, new Image[] { Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\staza.jpg") });
            PonasanjeForme.ButtonImageInit(new Button[] { btnLevi }, new Image[] { Image.FromFile(
                Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\img\\vozac.jpg") });
        }

        private void FrmStart_Resize(object sender, EventArgs e)
        {
            if (buttonOriginalRectangleL.Width != 0)
                PonasanjeForme.ResizeControl(buttonOriginalRectangleL, btnLevi, originalFormSize, Width, Height);
            if (buttonOriginalRectangleD.Width != 0)
                PonasanjeForme.ResizeControl(buttonOriginalRectangleD, btnDesni, originalFormSize, Width, Height);
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(Location.X, Location.Y, Width
                , Height);
            buttonOriginalRectangleL = new Rectangle(btnLevi.Location.X, btnLevi.Location.Y, btnLevi.Width
                , btnLevi.Height);
            buttonOriginalRectangleD = new Rectangle(btnDesni.Location.X, btnDesni.Location.Y, btnDesni.Width
                , btnDesni.Height);
        }

        private void btnLevi_Click(object sender, EventArgs e)
        {
            FrmLogin fl = new FrmLogin(false, this);
            fl.Show();
            Hide();
        }

        private void btnDesni_Click(object sender, EventArgs e)
        {
//            Communication.Instance.Connect();
//            FrmEntities fm = new FrmEntities(Entity.Vozac, true, "PETARG5");
//            fm.Show();
            FrmLogin fl = new FrmLogin(true, this);
            fl.Show();
            Hide();
        }
    }
}
