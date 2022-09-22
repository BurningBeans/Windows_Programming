using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093508_hw5
{
    public partial class Form1 : Form
    {
        enum Fruits
        {
            apple,
            tomato,
            grape,
            cherry,
            orange,
            pineapple,
            watermelon,
            banana
        }
        List<Fruits> brackets = new List<Fruits>();
        List<bool> status = new List<bool>();
        List<Image> img = new List<Image>();
        Image defaultpic = Properties.Resources._8_0;

        Random rnd = new Random();
        int stoppedtime = 0;
        int time = 0;
        Pen blackpen = new Pen(Brushes.Black,3);
        public Form1()
        {
            InitializeComponent();
            label1.Text = time + " seconds";
            for (int i = 0; i < 8; i++)//create bracket first than randomize everytime
            {
                brackets.Add((Fruits)i);
                brackets.Add((Fruits)i);
                status.Add(false);
                status.Add(false);
            }//faster way????

            //start up shuffle
            int n = brackets.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Fruits value = brackets[k];
                brackets[k] = brackets[n];
                brackets[n] = value;
            }
            //end of shuffle
            img.Add(Properties.Resources._8_1);
            img.Add(Properties.Resources._8_2);
            img.Add(Properties.Resources._8_3);
            img.Add(Properties.Resources._8_4);
            img.Add(Properties.Resources._8_5);
            img.Add(Properties.Resources._8_6);
            img.Add(Properties.Resources._8_7);
            img.Add(Properties.Resources._8_8);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            time = 0;
            //Shuffle the list of Fruits
            int n = brackets.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Fruits value = brackets[k];
                brackets[k] = brackets[n];
                brackets[n] = value;
            }
            //end of shuffle
            for (int i = 0; i < status.Count(); i++) //reset status
            {
                status[i] = false;
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(stoppedtime > 0)
            {
                stoppedtime = 0;
            }
            time++;
            label1.Text = time + " seconds";
            int truecount = 0;
            for (int i = 0; i < 16; i++)
            {
                if (status[i])
                    truecount++;
            }
            if (truecount % 2 == 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (status[i])
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if (brackets[i] == brackets[j] && status[i] != status[j])//if filpped value not matching reset the status of both
                            {
                                status[i] = false;
                                status[j] = false;
                                stoppedtime = 1;
                            }
                        }
                    }
                }
            }
            
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(3, 30, 75, 75);
            for (int i = 0, counter = 0; i < 4; i++)
            {
                rec.X = 3;
                for (int j = 0; j < 4; j++,counter++)
                {
                    if(status[counter])
                    {
                        e.Graphics.DrawImage(img[(int)brackets[counter]], rec);
                    }
                    else 
                    {
                        e.Graphics.DrawImage(defaultpic, rec);//draw image first
                    }
                    

                    e.Graphics.DrawRectangle(blackpen, rec);
                    rec.X += 75;
                }
                rec.Y += 75;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(stoppedtime==0)//whatever
            {
                Rectangle rec = new Rectangle(3, 30, 75, 75);
                for (int i = 0, counter = 0; i < 4; i++)
                {
                    rec.X = 3;
                    for (int j = 0; j < 4; j++, counter++)
                    {
                        if (rec.Contains(e.Location))
                        {
                            status[counter] = true;
                        }
                        rec.X += 75;
                    }
                    rec.Y += 75;
                }
                int truecount = 0;
                for (int i = 0; i < 16; i++)
                {
                    if (status[i])
                        truecount++;
                }
                if (truecount == 16)
                    timer1.Stop();
                if (truecount % 2 == 0)
                    stoppedtime = 1;
            }
            Invalidate();
        }
    }
}
