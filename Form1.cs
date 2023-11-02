using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progetto_di_un_orologio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int secondi = DateTime.Now.Second;
        int minuti = DateTime.Now.Minute;
        int ora = DateTime.Now.Hour;
        Pen penNera = new Pen(Color.Black, 7);
        Pen penNeraPic = new Pen(Color.Black, 5);
        Pen penRossa = new Pen(Color.Red, 5);
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        
        private void Ts_Tick(object sender, EventArgs e)
        {
            Graphics g=this.CreateGraphics();
            g.Clear(Color.White);
            ScheletroOrologio();
            secondi =DateTime.Now.Second;
            minuti=DateTime.Now.Minute;
            ora=DateTime.Now.Hour;
            int xc = Width / 2;
            int yc = Height / 2;
            int xsec = (int)PosizioneXMinSec(secondi,xc,185);
            int ysec = (int)PosizioneYMinSec(secondi,yc,185);
            int xmin = (int)PosizioneXMinSec(minuti,xc,160);
            int ymin = (int)PosizioneYMinSec(minuti,yc,160);
            int xora = (int)PosizioneXore(ora,xc,130);
            int yora = (int)PosizioneYore(ora,yc,130);
            g.DrawLine(penRossa, xc, yc, xsec, ysec);
            g.DrawLine(penNeraPic, xc, yc, xmin, ymin);
            g.DrawLine(penNeraPic, xc, yc, xora, yora);
        }
        private float PosizioneXMinSec(int minsec, int xy, int lunghezzaLancetta)
        {
            double AngoloRad = (minsec*360/60) * Math.PI / 180;
            return (float)(xy+lunghezzaLancetta*Math.Sin(AngoloRad));
        }
        private float PosizioneYMinSec(int minsec, int xy, int lunghezzaLancetta)
        {
            double AngoloRad = (minsec*360/60) * Math.PI / 180;
            return (float)(xy - lunghezzaLancetta * Math.Cos(AngoloRad));
        }
        //360 gradi/60 secondi o minuti
        private float PosizioneXore(int ore, int xy, int lunghezzaLancetta)
        {
            double AngoloRad = (ore*360/12) * Math.PI / 180;
            return (float)(xy + lunghezzaLancetta * Math.Sin(AngoloRad));
        }
        private float PosizioneYore(int ore, int xy, int lunghezzaLancetta)
        {
            double AngoloRad = (ore*360/12) * Math.PI / 180;
            return (float)(xy - lunghezzaLancetta * Math.Cos(AngoloRad));
        }
        //360 gradi/12 ore
        private void ScheletroOrologio()
        {
            int xc = Width / 2;
            int yc = Height / 2;
            Graphics g=this.CreateGraphics();
            g.DrawEllipse(penNera, xc - 200, yc - 200, 400, 400);
            int angolo = 30;
            for(int i = 1; i < 13; i++)
            {
                string n = i.ToString();
                double angoloRad = angolo * Math.PI / 180;
                int x = (int)(xc + 240 * Math.Sin(angoloRad));
                int y = (int)(yc - 240 * Math.Cos(angoloRad));
                switch (i)
                {
                    case 1:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 25, y +5);
                        break;
                    case 2:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 30, y-5);
                        break;
                    case 3:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, x - 40, y-15);
                        break;
                    case 4:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 35, y - 25);
                        break;
                    case 5:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 25, y -30);
                        break;
                    case 6:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, x - 15, y -35);
                        break;
                    case 7:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x, y - 30);
                        break;
                    case 8:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x +10, y - 25);
                        break;
                    case 9:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, x+5 , y - 15);
                        break;
                    case 10:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 5, y - 5);
                        break;
                    case 11:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 10, y+5);
                        break;
                    case 12:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, x - 25, y -5);
                        break;
                }
                angolo += 30;
            }
            for(int i = 30; i <= 360; i += 30)
            {
                double angoloRad = i * Math.PI / 180;
                int x = (int)(xc + 200 * Math.Sin(angoloRad));
                int y = (int)(yc - 200 * Math.Cos(angoloRad));
                int x1 = (int)(xc + 180 * Math.Sin(angoloRad));
                int y1 = (int)(yc - 180 * Math.Cos(angoloRad));
                g.DrawLine(penNera, x, y, x1, y1);
            }
            for (int i = 6; i <= 360; i += 6)
            {
                double angoloRad = i * Math.PI / 180;
                int x = (int)(xc + 200 * Math.Sin(angoloRad));
                int y = (int)(yc - 200 * Math.Cos(angoloRad));
                int x1 = (int)(xc + 190 * Math.Sin(angoloRad));
                int y1 = (int)(yc - 190 * Math.Cos(angoloRad));
                g.DrawLine(penNeraPic, x, y, x1, y1);
            }


        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
