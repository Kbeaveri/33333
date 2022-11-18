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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Zg = new Form2();
            Zg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBoxx Defoult = new PictureBoxx();
            Defoult.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Chart1 = new Form1();
            Chart1.Show();
        }
    }
}
