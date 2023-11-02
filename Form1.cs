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
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        
        private void Ts_Tick(object sender, EventArgs e)
        {
            Graphics g=this.CreateGraphics();
            g.Clear(Color.White);
            ScheletroOrologio();
            secondi=DateTime.Now.Second;
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
            g.DrawLine(Pens.Red, xc, yc, xsec, ysec);
            g.DrawLine(Pens.Black, xc, yc, xmin, ymin);
            g.DrawLine(Pens.Black, xc, yc, xora, yora);
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
            g.DrawEllipse(Pens.Black, xc - 200, yc - 200, 400, 400);
            int angolo = 30;
            for(int i = 1; i < 13; i++)
            {
                string n = i.ToString();
                double angoloRad = angolo * Math.PI / 180;
                int x = (int)(xc + 220 * Math.Sin(angoloRad));
                int y = (int)(yc- 220 * Math.Cos(angoloRad));
                g.DrawString(n, this.Font, Brushes.Black, x-5, y-5);
                angolo += 30;
            }
            
            
        }
    }
}
