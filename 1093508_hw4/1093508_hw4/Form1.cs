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

namespace _1093508_hw4
{
    public partial class Form1 : Form
    {
        bool GameOver = false;
        int time = 0;
        SolidBrush RedBrush;
        SolidBrush ballBrush;
        Pen borderPen;
        Rectangle Border = new Rectangle(10, 50, 220, 180);
        Rectangle box;
        Random rnd = new Random();
        Rectangle ball = new Rectangle(105,135,10,10);
        int speedx, speedy;
        
        public Form1()
        {
            InitializeComponent();
            Size = new Size(400, 400);
            toolStripStatusLabel1.Text = time.ToString() + " Playing!";
            borderPen = new Pen(Color.Black);
            RedBrush = new SolidBrush(Color.Red);
            ballBrush = new SolidBrush(Color.Red);
            box = new Rectangle(Border.X, Border.Y+Border.Height, 40, 10);
            ball.X = rnd.Next(Border.X, Border.X + Border.Width);
            ball.Y = rnd.Next(Border.Y, Border.Y + Border.Height-75);
            speedx = rnd.Next(1, 2);
            if (speedx == 2)
                speedx = -1;
            else
                speedx = 1;
            speedy = 1;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 5 == 0 && time != 0)
            {
                if (speedx > 0)
                    speedx++;
                else
                    speedx--;
                if (speedy > 0)
                    speedy++;
                else
                    speedy--;

            }
            if (GameOver) 
            {
                toolStripStatusLabel1.Text = time.ToString() + " GameOver!";
                timer1.Stop();
            }
            else
                toolStripStatusLabel1.Text = time.ToString() + " Playing!";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((ball.Y + ball.Height > Border.Y + Border.Height && ball.X+6 > box.X + box.Width) || (ball.Y + ball.Height > Border.Y + Border.Height && ball.X+5 < box.X))
            {
                GameOver = true;
            }
            if (!GameOver)
            {
                if (ball.X + ball.Width > Border.X + Border.Width || ball.X < Border.X)
                {
                    speedx = 0 - speedx;
                }
                if (ball.Y + ball.Height > Border.Y + Border.Height || ball.Y < Border.Y)
                {
                    speedy = 0 - speedy;
                }
                ball.X = ball.X + speedx;
                ball.Y = ball.Y + speedy;
                Invalidate();
            }
            
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameOver = false;
            speedx = rnd.Next(1, 2);
            if (speedx == 2)
                speedx = -1;
            else
                speedx = 1;
            speedy = 1;
            ball.X = rnd.Next(Border.X, Border.X + Border.Width);
            ball.Y = rnd.Next(Border.Y, Border.Y + Border.Height - 100);
            time = 0;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(borderPen, Border);
            e.Graphics.FillRectangle(RedBrush, box);
            e.Graphics.FillEllipse(ballBrush, ball);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameOver) 
            {
                if (e.X >= Border.X+Border.Width-box.Width)
                    box.X = Border.X + Border.Width - box.Width;
                else if (e.X <= Border.X)
                    box.X = Border.X;
                else
                    box.X = e.X;
            }
            Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ballBrush.Color = Color.Red;
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ballBrush.Color = Color.Green;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
            Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ballBrush.Color = Color.Blue;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
            Invalidate();
        }


    }
}
