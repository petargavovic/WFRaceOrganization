using Common;
using Common.Domen;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class FrmSimulacija : MaterialForm
    {
        Random random = new Random();
        GraphicsPath trenutniPut;
        GraphicsPath originalniPut;
        Timer timer;
        float duzinaPuta;
        readonly float originalnaDuzina;
        readonly int brojKrugova;

        SpeedyStopwatch varijablinaStoperica;

        readonly List<Tacka> tacke = new List<Tacka>();
        readonly BindingList<Ucinak> ucinci;
        DateTime prethodnoVreme;
        float brzinaVremena = 1;
        float scale = 1;
        float[] trackBarVrednosti;
        bool simulacijaPokrenuta = false;
        bool simulacijaPauzirana = false;
        Tacka poslednjaTacka;
        Font boldFont;
        FrmEntities frmEntities;

        private Size prvobitnaVelcinaForme;

        public FrmSimulacija(Trka trka, BindingList<Ucinak> ucinci, FrmEntities frmEntities)
        {
            InitializeComponent();
            Text = "Simulacija trke " + trka.Naziv;

            trenutniPut = FrmEntity.DeserializujPut(trka.Staza);
            duzinaPuta = PonasanjeForme.DuzinaPuta(trenutniPut);
            originalnaDuzina = duzinaPuta;
            PonasanjeForme.CentrirajPut(trenutniPut, 250, 323.53f);
            originalniPut = FrmEntity.DeserializujPut(trka.Staza);

            prvobitnaVelcinaForme = this.ClientSize;

            this.ucinci = ucinci;
            this.frmEntities = frmEntities;

            trackBarVrednosti = new float[] { 0.25f, 0.5f, 0.75f, 1f, 1.5f, 2f, 3f, 5f, 10f };

            tacke = new List<Tacka>();

            brojKrugova = trka.BrojKrugova;

            lblDuzina.Text = $"Dužina staze: {(int)Math.Round((PonasanjeForme.DuzinaPuta(trenutniPut) - 500) * 4 + 1000)}m";

            boldFont = new Font(this.Font, FontStyle.Bold);


            List<Color> colors = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Brown, Color.Black };
            List<Color> boje = Extensions.DeepCopy(colors);
            foreach (Ucinak ucinak in this.ucinci)
            {
                if (boje.Count == 0)
                    boje = Extensions.DeepCopy(colors);
                int randomBroj = random.Next(0, boje.Count);
                Tacka dot = new Tacka
                {
                    Pozicija = 0,
                    Boja = boje.ElementAt(randomBroj),
                    StartnaPozicija = ucinak.StartnaPozicija.ToString(),
                    Vremena = new int[brojKrugova],
                    ImePrezime = ucinak.Vozac.ToString(),
                    Plasman = ucinak.Plasman
                };
                boje.RemoveAt(randomBroj);
                string[] krugovi = ucinak.Vremena.Split(';');
                for (int k = 0; k < krugovi.Length; k++)
                {
                    string[] minsek = krugovi[k].Split(':');
                    int vreme = int.Parse(minsek[0]) * 60 + int.Parse(minsek[1]);
                    dot.Vremena[k] = vreme;
                }
                dot.Brzina = duzinaPuta / dot.Vremena[0];
                tacke.Add(dot);
            }
            poslednjaTacka = tacke.Find(x => x.Plasman == tacke.Count);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime trenutnoVreme = DateTime.Now;
            float tickRazlika = (float)(trenutnoVreme - prethodnoVreme).TotalSeconds;
            prethodnoVreme = trenutnoVreme;

            foreach (Tacka dot in tacke)
            {
                if (!simulacijaPauzirana)
                    dot.Pozicija += dot.Brzina * tickRazlika * brzinaVremena * scale;

                if (dot.Pozicija > duzinaPuta)
                {
                    if (dot.Krug < brojKrugova - 1)
                    {
                        dot.Pozicija = 0;
                        dot.Krug++;
                        dot.Brzina = originalnaDuzina / dot.Vremena[dot.Krug];
                    }
                    else
                    {
                        dot.Brzina = 0;
                        dot.Pozicija = duzinaPuta;
                    }
                }
            }
            if (poslednjaTacka.Brzina == 0)
                varijablinaStoperica.Stop();
            lblTimer.Text = $"Vreme: " + TimeSpan.FromSeconds(varijablinaStoperica.Elapsed.TotalSeconds).ToString(@"mm\:ss\:f");
            this.Invalidate();
        }

        private void IspisiUcesnike(Graphics g)
        {
            int x = 20;
            int y = 120;
            int visinaTeksta = 20;
            int rank = 1;

            foreach (Tacka dot in tacke.OrderByDescending(d => d.Krug).ThenByDescending(d => d.Pozicija).ThenBy(d => d.Plasman))
            {
                using (Brush brush = new SolidBrush(dot.Boja))
                {
                    string text = $"{rank}. {dot.ImePrezime}: Krug: {dot.Krug + 1}. {(int)((dot.Pozicija + (dot.Krug * duzinaPuta)) / (duzinaPuta * brojKrugova) * 100)}%";
                    if (dot.Boja != Color.Yellow)
                        g.DrawString(text, boldFont, brush, x, y);
                    else
                        DrawStrokedText(g, text, boldFont, dot.Boja, x, y);
                    y += visinaTeksta;
                    if (rank < 4)
                        dot.Velicina = 10.25f + ((4 - rank) * 1.5f);
                    else
                        dot.Velicina = 10;
                }
                rank++;
            }
        }

        private void DrawStrokedText(Graphics g, string text, Font font, Color textColor, float x, float y)
        {
            using (Brush textBrush = new SolidBrush(textColor))
            using (Brush strokeBrush = new SolidBrush(Color.Black))
            {
                float strokeOffset = 1.0f;

                g.DrawString(text, font, strokeBrush, x - strokeOffset, y - strokeOffset);
                g.DrawString(text, font, strokeBrush, x + strokeOffset, y - strokeOffset);
                g.DrawString(text, font, strokeBrush, x - strokeOffset, y + strokeOffset);
                g.DrawString(text, font, strokeBrush, x + strokeOffset, y + strokeOffset);

                g.DrawString(text, font, textBrush, x, y);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Black, 4))
                g.DrawPath(pen, trenutniPut);

            PonasanjeForme.NacrtajStartnuLiniju(trenutniPut, g);

            foreach (Tacka dot in tacke)
            {
                PointF dotPosition = UzmiTackuNaDistanci(dot.Pozicija);

                float dotRadius = dot.Velicina / 2;
                RectangleF dotRect = new RectangleF(dotPosition.X - dotRadius, dotPosition.Y - dotRadius, dot.Velicina, dot.Velicina);
                g.FillEllipse(new SolidBrush(dot.Boja), dotRect);
                if (simulacijaPokrenuta)
                    g.DrawString(dot.StartnaPozicija.ToString() + " : " + dot.ImePrezime, this.Font, Brushes.Black, dotPosition.X + dotRadius, dotPosition.Y - dotRadius);
            }
            IspisiUcesnike(g);
        }

        private PointF UzmiTackuNaDistanci(float distanca)
        {
            float akumuliranaDistanca = 0f;
            PointF[] temena = trenutniPut.PathPoints;

            for (int i = 0; i < temena.Length - 1; i++)
            {
                float duzinaSegmenta = PonasanjeForme.Distance(temena[i], temena[i + 1]);
                if (akumuliranaDistanca + duzinaSegmenta >= distanca)
                {
                    float preostalaDistanca = distanca - akumuliranaDistanca;
                    float t = preostalaDistanca / duzinaSegmenta;
                    float x = temena[i].X + t * (temena[i + 1].X - temena[i].X);
                    float y = temena[i].Y + t * (temena[i + 1].Y - temena[i].Y);
                    return new PointF(x, y);
                }
                akumuliranaDistanca += duzinaSegmenta;
            }

            return temena[temena.Length - 1];  // Vrati poslednju tacku ako distanca prelazi duzinu staze
        }

        private void SkalirajStazu()
        {
            if (prvobitnaVelcinaForme.Width == 0 || prvobitnaVelcinaForme.Height == 0)
                return;

            float scaleX = (float)this.ClientSize.Width / prvobitnaVelcinaForme.Width;
            float scaleY = (float)this.ClientSize.Height / prvobitnaVelcinaForme.Height;

            scale = Math.Min(scaleX, scaleY);

            Matrix matricaTransformacije = new Matrix();
            matricaTransformacije.Scale(scale, scale);

            trenutniPut.Reset();
            trenutniPut.AddPath(originalniPut, false);
            trenutniPut.Transform(matricaTransformacije);
            PonasanjeForme.CentrirajPut(trenutniPut, this.ClientSize.Width / 2, this.ClientSize.Height / 1.7f);

            float novaDuzinaPuta = PonasanjeForme.DuzinaPuta(trenutniPut);

            foreach (var dot in tacke)
                dot.Pozicija = dot.Pozicija / duzinaPuta * novaDuzinaPuta;

            duzinaPuta = novaDuzinaPuta;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            if (!simulacijaPokrenuta)
            {
                prethodnoVreme = DateTime.Now;

                timer = new Timer
                {
                    Interval = (int)(50 / brzinaVremena)
                };
                timer.Tick += Timer_Tick;
                timer.Start();

                varijablinaStoperica = new SpeedyStopwatch();
            }
            if (simulacijaPauzirana || !simulacijaPokrenuta)
            {
                varijablinaStoperica.Start();
                varijablinaStoperica.SpeedFactor = brzinaVremena;
                simulacijaPokrenuta = true;
                simulacijaPauzirana = false;
                btnPokreni.Text = "Pauziraj";
            }
            else if (!simulacijaPauzirana)
            {
                varijablinaStoperica.Stop();
                simulacijaPauzirana = true;
                btnPokreni.Text = "Pokreni";
            }
        }

        private void btnPauziraj_Click(object sender, EventArgs e)
        {
            varijablinaStoperica.Stop();
            simulacijaPauzirana = true;
        }

        private void btnResetuj_Click(object sender, EventArgs e)
        {
            foreach (Tacka tacka in tacke)
            {
                tacka.Pozicija = 0;
                tacka.Krug = 0;
                if (tacka.Brzina == 0)
                    tacka.Brzina = duzinaPuta / tacka.Vremena[0];
            }
            varijablinaStoperica.Reset();
            simulacijaPauzirana = true;
            simulacijaPokrenuta = false;
            btnPokreni.Text = "Pokreni";
        }

        private void tbBrzina_ValueChanged(object sender, EventArgs e)
        {
            brzinaVremena = trackBarVrednosti[tbBrzina.Value];
            lblBrzina.Text = trackBarVrednosti[tbBrzina.Value].ToString();
            if (varijablinaStoperica != null)
                varijablinaStoperica.SpeedFactor = brzinaVremena;
        }

        private void FrmSimulacija_Resize(object sender, EventArgs e)
        {
            SkalirajStazu();
            this.Invalidate();
        }

        private void FrmSimulacija_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEntities.Show();
        }
    }


    public class Tacka
    {
        public float Pozicija { get; set; }
        public float Brzina { get; set; }
        public float Velicina { get; set; } = 10f;
        public Color Boja { get; set; }
        public int Krug { get; set; }
        public string StartnaPozicija { get; set; }
        public string ImePrezime { get; set; }
        public int[] Vremena { get; set; }
        public int Plasman { get; set; }
    }

    public class SpeedyStopwatch
    {
        private Stopwatch stopwatch;
        private double speedFactor = 1.0;
        private TimeSpan adjustedElapsed;
        private TimeSpan lastTimeSpan;
        private TimeSpan addedTimeSpan;

        public SpeedyStopwatch()
        {
            stopwatch = new Stopwatch();
            adjustedElapsed = TimeSpan.Zero;
            lastTimeSpan = TimeSpan.Zero;
            addedTimeSpan = TimeSpan.Zero;
        }

        public double SpeedFactor
        {
            get => speedFactor;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(SpeedFactor), "Speed factor must be greater than zero.");

                if (stopwatch.IsRunning)
                {
                    adjustedElapsed += TimeSpan.FromTicks((long)(stopwatch.Elapsed.Ticks * speedFactor));
                    stopwatch.Restart();
                }

                speedFactor = value;
            }
        }

        public void Start()
        {
            stopwatch.Start();
            TimeSpan ae = TimeSpan.FromSeconds(lastTimeSpan.TotalSeconds + (addedTimeSpan.TotalSeconds));
            adjustedElapsed = TimeSpan.FromSeconds(ae.TotalSeconds - (Elapsed.TotalSeconds - ae.TotalSeconds));
        }

        public void Stop()
        {
            if (stopwatch.IsRunning)
            {
                lastTimeSpan = adjustedElapsed;
                addedTimeSpan = TimeSpan.FromTicks((long)(stopwatch.Elapsed.Ticks * speedFactor));
                adjustedElapsed += addedTimeSpan;
                stopwatch.Stop();
            }
        }

        public void Restart()
        {
            adjustedElapsed = TimeSpan.Zero;
            stopwatch.Restart();
        }

        public void Reset()
        {
            adjustedElapsed = TimeSpan.Zero;
            stopwatch.Reset();
        }

        public TimeSpan Elapsed
        {
            get
            {
                if (stopwatch.IsRunning)
                {
                    return adjustedElapsed + TimeSpan.FromTicks((long)(stopwatch.Elapsed.Ticks * speedFactor));
                }
                else
                {
                    return adjustedElapsed;
                }
            }
        }
    }
}