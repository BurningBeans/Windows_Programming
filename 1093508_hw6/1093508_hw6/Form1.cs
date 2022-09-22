using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace _1093508_hw6
{
    public partial class Form1 : Form
    {
        int pic;
        int total_time;
        int received;
        Image original;
        Image banana = Properties.Resources.Banana;
        Image strawberry = Properties.Resources.StawBerry;
        Image tomato = Properties.Resources.Tomato;
        Image bowl = Properties.Resources.Bowl;
        Point banana_pos;
        Point strawberry_pos;
        Point tomato_pos;
        Point bowl_pos;
        int bspeed, sspeed, tspeed;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            banana_pos = new Point(rnd.Next(pictureBox1.Width - banana.Width), -50);
            strawberry_pos = new Point(rnd.Next(pictureBox1.Width - strawberry.Width), -50);
            tomato_pos = new Point(rnd.Next(pictureBox1.Width - tomato.Width), -50);
            bowl_pos = new Point(0, 0);
            total_time = 120;
            received = 0;
            original = Properties.Resources.Hydrangeas;
            pic = 0;
            pictureBox1.BackgroundImage = SetAlpha((Bitmap)original, (float)0.5);
            label1.Text = "Time left:" + total_time + " sec";
            label2.Text = "Received: " + received;

            bspeed = rnd.Next(10, 20);//falling speed
            sspeed = rnd.Next(10, 20);
            tspeed = rnd.Next(10, 20);
        }
        static Bitmap SetAlpha(Bitmap bmpIn, float alpha)//make transparent
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, alpha, 0},
            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);
            return bmpOut;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(banana, banana_pos.X, banana_pos.Y, banana.Size.Width, banana.Size.Height);
            e.Graphics.DrawImage(strawberry, strawberry_pos.X, strawberry_pos.Y, strawberry.Width, strawberry.Height);
            e.Graphics.DrawImage(tomato, tomato_pos.X, tomato_pos.Y, tomato.Size.Width, tomato.Size.Height);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bowl, bowl_pos.X, bowl_pos.Y, bowl.Width, bowl.Height);//should update when Invalidate is called
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            bowl_pos.X = e.X;
            Invalidate();//this should update pictureBox2_Paint... but it didn't?
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banana_pos = new Point(rnd.Next(pictureBox1.Width - banana.Width), -50);
            strawberry_pos = new Point(rnd.Next(pictureBox1.Width - strawberry.Width), -50);
            tomato_pos = new Point(rnd.Next(pictureBox1.Width - tomato.Width), -50);
            bowl_pos = new Point(0, 0);
            total_time = 120;
            received = 0;
            original = Properties.Resources.Hydrangeas;
            pic = 0;
            pictureBox1.BackgroundImage = SetAlpha((Bitmap)original, (float)0.5);
            label1.Text = "Time left:" + total_time + " sec";
            label2.Text = "Received: " + received;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            total_time--;//counting down
            if(total_time % 10 == 0)//change background image every 10 sec
            {
                if (pic == 0)//lazy way to switch 3 image
                {
                    pic = 1;
                    original = Properties.Resources.Penguins;
                }

                else if (pic == 1) 
                {
                    pic = 2;
                    original = Properties.Resources.Tulips; 
                }
                else
                {
                    pic = 0;
                    original = Properties.Resources.Hydrangeas;
                }
                pictureBox1.BackgroundImage = SetAlpha((Bitmap)original, (float)0.5);//transparent the image
            }
            label1.Text = "Time left:" + total_time + " sec";//update time left
            label2.Text = "Received: " + received;

            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ////////////////
            //moving fruit here
            ////////////////
            banana_pos.Y+=bspeed;

            if (banana_pos.Y > 290)
            {
                if(bowl_pos.X <= banana_pos.X&&bowl_pos.X+bowl.Width >= banana_pos.X)
                {
                    received++;
                }
                banana_pos.Y = -50;
                banana_pos.X = rnd.Next(pictureBox1.Width - banana.Width);
                bspeed = rnd.Next(10, 20);//set next falling speed
                
            }
                
            strawberry_pos.Y+=sspeed;
            if (strawberry_pos.Y > 290)
            {
                if (bowl_pos.X <= strawberry_pos.X && bowl_pos.X + bowl.Width >= strawberry_pos.X)
                {
                    received++;
                }
                strawberry_pos.Y = -50;
                strawberry_pos.X = rnd.Next(pictureBox1.Width - strawberry.Width);
                sspeed = rnd.Next(10, 20);
                
            }
                
            tomato_pos.Y+=tspeed;
            if (tomato_pos.Y > 290)
            {
                if (bowl_pos.X <= tomato_pos.X && bowl_pos.X + bowl.Width >= tomato_pos.X)
                {
                    received++;
                }
                tomato_pos.Y = -50;
                tomato_pos.X = rnd.Next(pictureBox1.Width-tomato.Width);
                tspeed = rnd.Next(10, 20);
            }
                
            Invalidate();
        }
    }
}
