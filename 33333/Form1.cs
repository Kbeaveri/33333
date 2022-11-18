using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33333
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            double a = -10;
            double b = 10;
            double x1 = a;
            double h = 0.01;
            this.chart1.Series[0].Points.Clear();   
            this.chart1.Series[1].Points.Clear();   
            this.chart1.Series[2].Points.Clear();   
            this.chart1.Series[3].Points.Clear();
            this.chart1.Series[1].Color = Color.Aquamarine;
            this.chart1.Series[0].Color = Color.Aquamarine; 
            this.chart1.Series[2].Color = Color.Red;
            this.chart1.Series[3].Color = Color.Red;
            while (x1 <=-1)
            {
                if (2*Math.Pow(x1,2)-1!= 0 && Math.Sqrt(Math.Pow(x1, 2) - 1) > 0)
                {
                    double y1 = (Math.Pow(x1, 2) * Math.Sqrt(Math.Pow(x1, 2) - 1)) / (2 * Math.Pow(x1, 2) - 1);
                    this.chart1.Series[0].Points.AddXY(x1, y1);
                }
                x1 += h;
            }
            x1 = 1.00001;
            while (x1 <= 10)
            {
                if (2 * Math.Pow(x1, 2) - 1 != 0 && Math.Sqrt(Math.Pow(x1, 2) - 1) > 0)
                {
                    double y1 = (Math.Pow(x1, 2) * Math.Sqrt(Math.Pow(x1, 2) - 1)) / (2 * Math.Pow(x1, 2) - 1);
                    this.chart1.Series[1].Points.AddXY(x1, y1);
                }
                x1 += h;
            }
            x1 = a;
            while (x1 <= -1)
            {
                double y1 = ((Math.Pow(x1, 5)) - (3 * Math.Pow(x1, 3)) + (2 * x1)) / (Math.Sqrt((Math.Pow(x1, 2)) - 1) * (Math.Pow((2 * Math.Pow(x1, 2)) - 1, 2)));
                this.chart1.Series[2].Points.AddXY(x1, y1);
                x1 += h;
            }
            x1 = 1;
            while (x1 < b)
            {
                double y1 = (Math.Pow(x1, 5) - 3 * Math.Pow(x1, 3) + 2 * x1) / (Math.Sqrt(Math.Pow(x1, 2) - 1) * Math.Pow(2 * Math.Pow(x1, 2) - 1, 2));
                this.chart1.Series[3].Points.AddXY(x1, y1);
                x1 += h;
            }

        }
    }
}
