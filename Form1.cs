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
        Pen Bianca = new Pen(Color.White, 5);
        Pen Verde = new Pen(Color.Lime, 5);
        Pen penRed = new Pen(Color.Red, 5);
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
            int xora = (int)PosizioneXore(ora,xc,110);
            int yora = (int)PosizioneYore(ora,yc,110);
            g.DrawLine(penRed, xc, yc, xsec, ysec);
            g.DrawLine(Bianca, xc, yc, xmin, ymin);
            g.DrawLine(Bianca, xc, yc, xora, yora);
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
            double AngoloRad = ((ore*360/12)+(minuti*30/60)) * Math.PI / 180;
            return (float)(xy + lunghezzaLancetta * Math.Sin(AngoloRad));
        }
        private float PosizioneYore(int ore, int xy, int lunghezzaLancetta)
        {
            double AngoloRad = ((ore*360/12)+(minuti*30/60)) * Math.PI / 180;
            return (float)(xy - lunghezzaLancetta * Math.Cos(AngoloRad));
        }
        //360 gradi/12 ore
        private void ScheletroOrologio()
        {
            int xc = Width / 2;
            int yc = Height / 2;
            Graphics g=this.CreateGraphics();
            g.FillEllipse(Brushes.Black, xc - 200, yc - 200, 400, 400);
            int angolo = 30;
            for(int i = 1; i < 13; i++)//si posizionano i numeri all'esterno dell'orologio
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
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Red, x - 40, y-15);
                        break;
                    case 4:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 35, y - 25);
                        break;
                    case 5:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 25, y -30);
                        break;
                    case 6:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Red, x - 15, y -35);
                        break;
                    case 7:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x, y - 30);
                        break;
                    case 8:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x +10, y - 25);
                        break;
                    case 9:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Red, x+5 , y - 15);
                        break;
                    case 10:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 5, y - 5);
                        break;
                    case 11:
                        g.DrawString(n, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, x - 10, y+5);
                        break;
                    case 12:
                        g.DrawString(n, new Font("Arial", 28, FontStyle.Bold), Brushes.Red, x - 25, y -5);
                        break;
                }
                angolo += 30;
            }
            for (int i = 6; i <= 360; i += 6)//si creano le tacchette più piccole 
            {
                if(i==30 || i==60 || i==90|| i==120|| i==150 || i==180 || i==210|| i==240 || i==270 || i==300 || i==330||  i == 360)
                {

                }
                else
                {
                    double angoloRad = i * Math.PI / 180;
                    int x = (int)(xc + 200 * Math.Sin(angoloRad)); //x e y stanno sul bordo del cerchio
                    int y = (int)(yc - 200 * Math.Cos(angoloRad));// x1 e y1 stanno dentro al cerchio
                    int x1 = (int)(xc + 190 * Math.Sin(angoloRad));
                    int y1 = (int)(yc - 190 * Math.Cos(angoloRad));
                    g.DrawLine(Pens.White, x, y, x1, y1);
                }
            
            }
            for (int i = 30; i <= 360; i += 30)//si creacno le tacchette in 12, 3 , 6 e 9
            {
                double angoloRad = i * Math.PI / 180;
                int x = (int)(xc + 200 * Math.Sin(angoloRad));
                int y = (int)(yc - 200 * Math.Cos(angoloRad));
                int x1 = (int)(xc + 180 * Math.Sin(angoloRad));
                int y1 = (int)(yc - 180 * Math.Cos(angoloRad));
                g.DrawLine(Verde, x, y, x1, y1);
            }
            DateTime h = DateTime.Now;
            string GiornoSet;
            string nMese = h.Day.ToString();
            string mese;
            switch (h.Month)
            {
                case 1:
                    mese = "Jan";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 2:
                    mese = "Feb";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 3:
                    mese = "Mar";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc - 15);
                    break;
                case 4:
                    mese = "Apr";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc - 15);
                    break;
                case 5:
                    mese = "May";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc - 15);
                    break;
                case 6:
                    mese = "Jun";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 7:
                    mese = "Jul";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 8:
                    mese = "Aug";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 9:
                    mese = "Sep";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 10:
                    mese = "Oct";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 11:
                    mese = "Nov";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
                case 12:
                    mese = "Dec";
                    g.DrawString(mese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 65, yc-15);
                    break;
            }
            switch (h.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    GiornoSet = "Mon";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Tuesday:
                    GiornoSet = "Tue";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Wednesday:
                    GiornoSet = "Wed";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Thursday:
                    GiornoSet = "Thu";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Friday:
                    GiornoSet = "Fri";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Saturday:
                    GiornoSet = "Sat";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc-15);
                    break;
                case DayOfWeek.Sunday:
                    GiornoSet = "Sun";
                    g.DrawString(GiornoSet, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 125, yc - 15);
                    break;
            }
            g.DrawString(nMese, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc + 130, yc - 15);
            string ora = h.Hour.ToString();
            string minuti = h.Minute.ToString();
            g.DrawString(ora, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 40, yc + 85);
            g.DrawString(":", new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc - 10, yc + 85);
            g.DrawString(minuti, new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, xc, yc + 85);


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
