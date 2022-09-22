using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _1093508_hw2
{
    public partial class Form1 : Form
    {
        private Rectangle[] rec = new Rectangle[9];
        private int[] status = new int[9];//status of the square
        private bool finished = false;//state of the game
        private Random rnd = new Random();
        private Pen redPen = new Pen(Color.Red);
        private Pen blackPen = new Pen(Color.Black);
        private Pen bluePen = new Pen(Color.Blue);
        public Form1()
        {
            InitializeComponent();
            int counter = 0;
            
            int y = 25;
            for (int i = 0; i < 3; i++)
            {
                int x = 0;
                for (int j = 0; j < 3; j++, counter++)
                {
                    rec[counter] = new Rectangle(x, y, 60, 60);
                    x += 60;
                    status[counter] = 0;
                }
                y += 60;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangles(blackPen, rec);

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(finished)//if game is finished don't proceed
            {
                return;
            }
            for (int i = 0; i < 9; i++)
            {
                if(rec[i].Contains(e.Location)&&status[i]==0)//check if square is played or not
                {
                    status[i] = 1;
                }
            }
            //---------------------------------------------
            if (checkwinner() == 0)//Bot play
            {
                int play = rnd.Next(8);
            }
            else if(checkwinner() == 1)
            {
                label1.Text = ("Player won!");
                finished = true;
            }
            else if(checkwinner()== -1)
            {
                label1.Text = ("Bot won!");
                finished = true;
            }
            else
            {
                label1.Text = ("Draw!");
                finished = true;
            }
            //repaint after click
            Invalidate();
        }
        public void checkwinner()//check winner 1 or -1 
        {
            if (status[0] == status[1] && status[1] == status[2] && status[0] != 0)
                return status[0];
            else if (status[3] == status[4] && status[4] == status[5] && status[3] != 0)
                return status[3];
            else if (status[6] == status[7] && status[7] == status[8] && status[6] != 0)
                return status[6];
            else if (status[0] == status[3] && status[3] == status[6] && status[0] != 0)
                return status[0];
            else if (status[1] == status[4] && status[4] == status[7] && status[1] != 0)
                return status[1];
            else if (status[2] == status[5] && status[5] == status[8] && status[2] != 0)
                return status[2];
            else if (status[0] == status[4] && status[4] == status[8] && status[0] != 0)
                return status[0];
            else if (status[2] == status[4] && status[4] == status[6] && status[2] != 0)
                return status[2];
            else
            {
                bool full = true;
                for (int i = 0; i < 9; i++)
                    if(status[i]==0)
                        full = false;

                if(full)
                    return 2;// 2 means full
                return 0;//keep playing
            }
        }
    }
}
