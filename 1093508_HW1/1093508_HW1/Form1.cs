using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093508_HW1
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();//for random color
        private SolidBrush[] rndBrush = new SolidBrush[9];// saving each squares color 
        private bool painted = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] points = new Point[4];//4 points for the squares
            for (int i = 0; i < 4; i++)
            {
                points[i].X = 50 * i;
                points[i].Y = 50 * i;
            }
            //drawing the squares
            int squarecount = 0;
            if (!painted)//assigning color if first time painting 
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));//rand from google
                        rndBrush[squarecount] = new SolidBrush(randomColor);
                        squarecount++;
                    }
                painted = true;//don't rand after first time to avoid repaint with rand colors, move to end of function if needed
                squarecount = 0;//reset for next paint
            }
            
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));//rand from google
                    //rndBrush[squarecount] = new SolidBrush(randomColor);
                    g.FillRectangle(rndBrush[squarecount], points[i].X, points[j].Y, 50, 50);
                    g.DrawRectangle(Pens.Black, points[i].X, points[j].Y, 50, 50);//draw rectangle lines on the top layer after the coloring 
                    squarecount++;
                }

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point[] points = new Point[4];//4 points for the squares
            for (int i = 0; i < 4; i++)
            {
                points[i].X = 50 * i;
                points[i].Y = 50 * i;
            }
            int squarecount = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rec = new Rectangle(points[i].X, points[j].Y, 50, 50);
                    //if(rec[i+j].Contains(e.Location))
                    if (rec.Contains(e.Location))
                    {
                        Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));//rand from google
                        rndBrush[squarecount] = new SolidBrush(randomColor);
                        
                    }
                    squarecount++;
                }
            Invalidate();
            //useless code below
            /*
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rec = new Rectangle(points[i].X, points[j].Y, 50, 50);
                    //if(rec[i+j].Contains(e.Location))
                    if (rec.Contains(e.Location))
                    {
                        Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));//rand from google
                        SolidBrush rndBrush = new SolidBrush(randomColor);
                        g.FillRectangle(rndBrush, rec);
                    }
                    g.DrawRectangle(Pens.Black, points[i].X, points[j].Y, 50, 50);
                }
            */
        }

    }
}
