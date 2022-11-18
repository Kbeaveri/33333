using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33333
{
    public partial class PictureBoxx : Form
    {
        public PictureBoxx()
        {
            InitializeComponent();
        }
        private double f1(float x)
        {
            return (Math.Pow(x, 2) * Math.Sqrt(Math.Pow(x, 2) - 1)) / (2 * Math.Pow(x, 2) - 1);
        }
        private double f2(double x)
        {
            return ((Math.Pow(x, 5)) - (3 * Math.Pow(x, 3)) + (2 * x)) / (Math.Sqrt((Math.Pow(x, 2)) - 1) * (Math.Pow((2 * Math.Pow(x, 2)) - 1, 2)));
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            float W = this.pictureBox1.Width;
            float H = this.pictureBox1.Height;
            float W2 = W / 2;
            float H2 = H / 2;
            float xmin = -10;
            float xmax = 10;
            float ymax = 10;
            float ymin = -10;
            float xbreak1 = -1;
            float xbreak2 = 1;
            float h = 0.01f;
            float dx = W / (xmax - xmin);
            float dy = H / (ymax - ymin);
            e.Graphics.DrawLine(Pens.Black, W2, 0, W2, H);
            e.Graphics.DrawLine(Pens.Black, 0, H2, W, H2);
            Font Fon = new Font("Arial", 9, FontStyle.Regular);
            Brush Br = Brushes.Black;
            e.Graphics.DrawString("X", Fon, Br, W - 15, H2 + 10);
            e.Graphics.DrawString("Y", Fon, Br, W2 - 20, 10);
            Font Fon1 = new Font("Arial", 6, FontStyle.Regular);
            for (int i = (int)ymin; i < ymax; i++)
            {
                e.Graphics.DrawLine(Pens.Black, W2 - 1, H2 + dy * i, W2 + 1, H2 + dy * i);
                e.Graphics.DrawString((-(float)(i)).ToString(), Fon1, Br, W2 - 15, H2 + dy * i);
            }
            for (int i = (int)xmin; i < xmax; i++)
            {
                e.Graphics.DrawLine(Pens.Black, W2 + dx * i, H2 + 1, W2 + dx * i, H2 - 1);
                if (i != 0)
                    e.Graphics.DrawString(i.ToString(), Fon1, Br, W2 + dx * i - 10, H2 + 10);
            }
            float Prewx = xmin;
            float Prewy = (float)f1(Prewx);
            for (float i = xmin; i < -1; i += h)
            {
                e.Graphics.DrawLine(Pens.Black, W2 - Prewx*dx, H2 - Prewy*dy, W2 - i*dx, H2 - (float)f1(i)*dy);
                Prewx = i;
                Prewy = (float)f1(Prewx);
            }
             Prewx = 1.01f;
             Prewy = (float)f1(Prewx);
            for (float i = 1.01f;i < xmax; i+=h)
            {
                e.Graphics.DrawLine(Pens.Black, W2 - Prewx * dx, H2 - Prewy * dy, W2 - i * dx, H2 - (float)f1(i) * dy);
                Prewx = i;
                Prewy = (float)f1(Prewx);
            }
            Prewx = xmin;
            Prewy = (float)f2(Prewx);
            for (float i = xmin; i < -1; i += h)
            {
                e.Graphics.DrawLine(Pens.Red, W2 - Prewx * dx, H2 - Prewy * dy, W2 - i * dx, H2 - (float)f2(i) * dy);
                Prewx = i;
                Prewy = (float)f2(Prewx);
            }
            Prewx = 1.01f;
            Prewy = (float)f2(Prewx);
            for (float i = 1.01f; i < xmax; i += h)
            {
                e.Graphics.DrawLine(Pens.Red, W2 - Prewx * dx, H2 - Prewy * dy, W2 - i * dx, H2 - (float)f2(i) * dy);
                Prewx = i;
                Prewy = (float)f2(Prewx);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            float W = this.pictureBox1.Width;
            float H = this.pictureBox1.Height;
            float W2 = W / 2;
            float H2 = H / 2;
            float xmin = -10;
            float xmax = 10;
            float ymax = 10;
            float ymin = -10;
            float xbreak1 = -1;
            float xbreak2 = 1;
            float h = 0.01f;
            float dx = W / (xmax - xmin);
            float dy = H / (ymax - ymin);
            double x = (e.X - W2) / dx;
            double y = (H2 - e.Y) / dy;
            string text = string.Format("X: {0};    Y: {1}", x, y);
            label1.Text = text;
        }
    }
}
