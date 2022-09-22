using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093508_hw7
{
    public partial class Form3 : Form
    {
        private float r = 1, g = 1, b = 1, a = 1;
        public Form3()
        {
            InitializeComponent();
            label5.Text = ((float)trackBar1.Value / 10).ToString();
            label6.Text = ((float)trackBar2.Value / 10).ToString();
            label7.Text = ((float)trackBar3.Value / 10).ToString();
            label8.Text = ((float)trackBar4.Value / 10).ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = ((float)trackBar1.Value / 10).ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = ((float)trackBar2.Value / 10).ToString();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label7.Text = ((float)trackBar3.Value / 10).ToString();
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label8.Text = ((float)trackBar4.Value / 10).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            r = (float)trackBar1.Value / 10;
            g = (float)trackBar2.Value / 10;
            b = (float)trackBar3.Value / 10;
            a = (float)trackBar4.Value / 10;
            Close();
        }
        public float getr()
        {
            return r;
        }
        public float getg()
        {
            return g;
        }
        public float getb()
        {
            return b;
        }
        public float geta()
        {
            return a;
        }
    }
}
