using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using MaterialSkin;
using Client;
using Common;
using System.IO;

namespace StazeZaTrke
{
    public partial class FrmGeneratorStaze : MaterialForm
    {
        Random random = new Random();
        GraphicsPath trenutniPut;

        int brojTemena = 3;
        int duzinaPuta;
        readonly FrmEntity frmEntity;

        public FrmGeneratorStaze(FrmEntity frmEntity, GraphicsPath put)
        {
            InitializeComponent();
            MaterialSkinSetTheme.SetTheme(this);

            this.DoubleBuffered = true;

            this.frmEntity = frmEntity;
            trenutniPut = put;
            if (put.PointCount != 0)
            {
                PonasanjeForme.CentrirajPut(trenutniPut, 250, 360);
                duzinaPuta = frmEntity.duzinaStaze;
                sliderDuzina.Value = duzinaPuta - 1000;
                lblSliderValue.Text = duzinaPuta + "m";
            }
            else
                btnSacuvajStazu.Enabled = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Black, 4))
                g.DrawPath(pen, trenutniPut);

            PonasanjeForme.NacrtajStartnuLiniju(trenutniPut, g);
        }


        private GraphicsPath KreirajPut(Rectangle granice)
        {
            GraphicsPath put;
            PointF[] temena;
            do
            {
                temena = GenerisiTacke(granice, brojTemena);
                put = KreirajPutOdTemena(temena);
            }
            while (SePreseca(put));

            float trenutnaDuzina = PonasanjeForme.DuzinaPuta(put);

            float faktorSkaliranja = (sliderDuzina.Value/2 + 1000)/2f / trenutnaDuzina;
            put = frmEntity.SkalirajPut(put, faktorSkaliranja);

            PonasanjeForme.CentrirajPut(put, ClientSize.Width / 2, ClientSize.Height / 1.67f);
            return put;
        }

        private PointF[] GenerisiTacke(Rectangle granice, int brojTemena)
        {
            PointF[] temena = new PointF[brojTemena];

            for (int i = 0; i < brojTemena; i++)
            {
                PointF novoTeme;
                bool sePreseca;

                do
                {
                    novoTeme = new PointF(
                        random.Next(granice.Left, granice.Right),
                        random.Next(granice.Top, granice.Bottom)
                    );

                    sePreseca = false;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            if (SePresecajuLinije(temena[j], temena[j + 1], temena[i - 1], novoTeme))
                            {
                                sePreseca = true;
                                break;
                            }
                        }
                    }

                } while (sePreseca);

                temena[i] = novoTeme;
            }

            return temena;
        }

        private GraphicsPath KreirajPutOdTemena(PointF[] temena)
        {
            GraphicsPath put = new GraphicsPath();
            put.StartFigure();

            PointF[] splinePoints = UzmiTemenaKrivina(temena);

            put.AddLines(splinePoints);

            put.CloseFigure();
            return put;
        }

        private PointF[] UzmiTemenaKrivina(PointF[] temena)
        {
            List<PointF> temenaKrivina = new List<PointF>(); //splines
            float tenzija = 0.5f;

            for (int i = 0; i < temena.Length; i++)
            {
                PointF p0 = temena[(i - 1 + temena.Length) % temena.Length];
                PointF p1 = temena[i];
                PointF p2 = temena[(i + 1) % temena.Length];
                PointF p3 = temena[(i + 2) % temena.Length];

                for (float t = 0; t <= 1; t += 0.1f)
                {
                    float t2 = t * t;
                    float t3 = t2 * t;

                    float b0 = 0.5f * ((-tenzija * t3) + (2 * tenzija * t2) - (tenzija * t));
                    float b1 = 0.5f * ((2 - tenzija) * t3 + (tenzija - 3) * t2 + 1);
                    float b2 = 0.5f * ((tenzija - 2) * t3 + (3 - 2 * tenzija) * t2 + (tenzija * t));
                    float b3 = 0.5f * (tenzija * t3 - tenzija * t2);

                    float x = b0 * p0.X + b1 * p1.X + b2 * p2.X + b3 * p3.X;
                    float y = b0 * p0.Y + b1 * p1.Y + b2 * p2.Y + b3 * p3.Y;

                    temenaKrivina.Add(new PointF(x, y));
                }
            }

            return temenaKrivina.ToArray();
        }

        private bool SePreseca(GraphicsPath put)
        {
            PointF[] temena = put.PathPoints;
            for (int i = 0; i < temena.Length - 1; i++)
            {
                for (int j = i + 1; j < temena.Length - 1; j++)
                {
                    if (SePresecajuLinije(temena[i], temena[i + 1], temena[j], temena[j + 1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SePresecajuLinije(PointF a1, PointF a2, PointF b1, PointF b2)
        {
            float brojilac = ((a2.X - a1.X) * (b2.Y - b1.Y)) - ((a2.Y - a1.Y) * (b2.X - b1.X));
            if (brojilac == 0)
                return false;

            float imenilac1 = ((a1.Y - b1.Y) * (b2.X - b1.X)) - ((a1.X - b1.X) * (b2.Y - b1.Y));
            float imenilac2 = ((a1.Y - b1.Y) * (a2.X - a1.X)) - ((a1.X - b1.X) * (a2.Y - a1.Y));

            if (imenilac1 == 0 || imenilac2 == 0)
                return false;

            float r = imenilac1 / brojilac;
            float s = imenilac2 / brojilac;

            return (r > 0 && r < 1) && (s > 0 && s < 1);
        }


        private void btnGenerisi_Click(object sender, EventArgs e)
        {
            trenutniPut = KreirajPut(new Rectangle(50, 50, 700, 500));
            duzinaPuta = sliderDuzina.Value + 1000;
            btnSacuvajStazu.Enabled = true;
            this.Invalidate();
        }

        private void btnSmanji_Click(object sender, EventArgs e)
        {
            if (brojTemena > 3)
            {
                if (brojTemena == 12)
                    btnPovecaj.Enabled = true;
                else if (brojTemena == 4)
                    btnSmanji.Enabled = false;
                brojTemena--;
                pointsLabel.Text = $"Kompleksnost staze: {brojTemena}";
            }
        }

        private void btnPovecaj_Click(object sender, EventArgs e)
        {
            if (brojTemena < 12)
            {
                if (brojTemena == 3)
                    btnSmanji.Enabled = true;
                else if (brojTemena == 11)
                    btnPovecaj.Enabled = false;
                brojTemena++;
                pointsLabel.Text = $"Kompleksnost staze: {brojTemena}";
            }
        }

        private void sliderDuzina_onValueChanged(object sender, int newValue)
        {
            lblSliderValue.Text = (sliderDuzina.Value + 1000).ToString() + "m";
        }

        private void btnSacuvajStazu_Click(object sender, EventArgs e)
        {
            frmEntity.SavePath(trenutniPut, duzinaPuta);
            frmEntity.Invalidate();
            this.Close();
        }

        private void FrmGeneratorStaze_Resize(object sender, EventArgs e)
        {
            PonasanjeForme.CentrirajPut(trenutniPut, ClientSize.Width / 2, ClientSize.Height / 1.67f);
        }

        private void FrmGeneratorStaze_FormClosed(object sender, FormClosedEventArgs e)
        {
            PonasanjeForme.CentrirajPut(frmEntity.trenutniPut, 270, 405);
            frmEntity.Invalidate();
            frmEntity.Show();
        }
    }
}
