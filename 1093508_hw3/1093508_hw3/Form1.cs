using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace _1093508_hw3
{
    public partial class Form1 : Form
    {
        List<Point> startPt = new List<Point>();
        List<Point> endPt = new List<Point>();
        Point p1;
        List<Color> Colors = new List<Color>();
        List<float> PenWidth = new List<float>();
        List<int> Styles = new List<int>();
        Pen aPen;
        public Form1()
        {
            InitializeComponent();
            aPen = new Pen(Color.Red, 3);//defualt pen
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = saveFileDialog1.FileName;
                BinaryWriter outFile = new BinaryWriter(File.Open(s, FileMode.Create));
                outFile.Write(endPt.Count());
                for (int i = 0; i < endPt.Count(); i++)
                {
                    outFile.Write(startPt[i].X);
                    outFile.Write(startPt[i].Y);
                    outFile.Write(endPt[i].X);
                    outFile.Write(endPt[i].Y);
                    outFile.Write(Colors[i].ToArgb());
                    outFile.Write(Styles[i]);
                    outFile.Write(PenWidth[i]);
                    
                }
                outFile.Close();
            }

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = openFileDialog1.FileName;
                if (!File.Exists(s)) return;
                BinaryReader inFile = new BinaryReader(File.Open(s, FileMode.Open));
                startPt.Clear();
                endPt.Clear();
                //
                Colors.Clear();
                Styles.Clear();
                PenWidth.Clear();
                //
                int n = inFile.ReadInt32();
                for (int i = 0; i < n; i++)
                {
                    startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                    endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                    //
                    Colors.Add(Color.FromArgb(inFile.ReadInt32()));

                    Styles.Add(inFile.ReadInt32());
                  
                    PenWidth.Add(inFile.ReadSingle());//ReadSingle because of float
                    //
                }
                Invalidate();
                inFile.Close();
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startPt.Clear();
            endPt.Clear();
            Colors.Clear();
            Styles.Clear();
            PenWidth.Clear();
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";
            saveFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            startPt.Add(p1);
            endPt.Add(e.Location);
            Colors.Add(aPen.Color);
            Styles.Add((int)aPen.DashStyle);
            PenWidth.Add(aPen.Width);
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < endPt.Count(); i++)
            {
                aPen.Color = Colors[i];
                aPen.Width = PenWidth[i];
                aPen.DashStyle = (DashStyle)Styles[i];
                e.Graphics.DrawLine(aPen, startPt[i].X, startPt[i].Y, endPt[i].X, endPt[i].Y);
            }
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aPen.Color = Color.Red;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aPen.Color = Color.Green;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aPen.Color = Color.Blue;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aPen.DashStyle = DashStyle.Solid;
            solidToolStripMenuItem.Checked = true;
            dashToolStripMenuItem.Checked = false;
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aPen.DashStyle = DashStyle.Dash;
            solidToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            aPen.Width = 1;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            aPen.Width = 2;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            aPen.Width = 3;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            aPen.Width = 4;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem6.Checked = false;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            aPen.Width = 5;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true;
        }
    }
}
