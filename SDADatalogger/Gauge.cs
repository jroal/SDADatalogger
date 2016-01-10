using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace SDADatalogger
{
    public partial class Gauge : Form
    {
        int cntmin = 4096, cntmax = 0, adc = 0, size = 0;
        double emin, emax, eunits;
        public double gmin, gmax;
        public bool engineering = false;
        struct NeedleEnd
        {
            public int x, y;
            public NeedleEnd(int counts, int r, bool eng, double units, double min, double max)
            {
                double theta;
                if (eng)
                {
                   theta = Math.PI - ((units - min) / (max - min)) * Math.PI;
                }
                else
                {
                   theta = Math.PI - (counts / 4096.0) * Math.PI;
                }
                x = Convert.ToInt16(Math.Cos(theta) * r);
                y = Convert.ToInt16( Math.Sin(theta) * r );
            }
        }

        public struct NeedleTicks
        {
            public int x1, y1, x2, y2;
            public NeedleTicks(int r, int tick, int total)
            {
                double theta;
                double r2 = Convert.ToDouble(r);
                theta = Math.PI - (tick / Convert.ToDouble(total))*Math.PI;
                x1 = Convert.ToInt16(Math.Cos(theta) * r2);
                y1 = Convert.ToInt16(Math.Sin(theta) * r2);
                x2 = Convert.ToInt16(Math.Cos(theta) * (r2 - 20.0));
                y2 = Convert.ToInt16(Math.Sin(theta) * (r2 - 20.0));
            }
        }
        public Gauge()
        {
            InitializeComponent();

        }
        public string dformat(double var)
        { // this function formats the display of double values based on size
            if (var > 100) return "F1";
            else if (var <= 100 && var > 1) return "F4";
            else if (var <= 1 && var > 0.001) return "F6";
            else return "F8";
        }        
        private PictureBox pictureBox1 = new PictureBox();
        private void Graph_Load_1(object sender, System.EventArgs e)
        {
            try
            {
                adc = Convert.ToInt16(textBox1.Text);
                eunits = Convert.ToDouble(label1.Text);
            }
            catch
            {
                adc = 0;
                eunits = emin;
            }            
            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);
            emin = gmax;
            emax = gmin;

        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            string name = this.Name ;
            int middle = (pictureBox1.Right + pictureBox1.Left) / 2 ;
            int fs, bl, pb;
            NeedleEnd ne = new NeedleEnd(adc, middle - 5, engineering, eunits, gmin,gmax);
            NeedleEnd nemin = new NeedleEnd(cntmin, middle - 5, engineering, emin, gmin, gmax);
            NeedleEnd nemax = new NeedleEnd(cntmax, middle - 5, engineering, emax, gmin, gmax);
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            Pen gagepen = new Pen(Brushes.Black);
            gagepen.Width = 4;
            Pen gagepenmin = new Pen(Brushes.Blue);
            gagepenmin.Width = 2;
            Pen gagepenmax = new Pen(Brushes.Red);
            gagepenmax.Width = 2;
            Pen gageback = new Pen(Brushes.DarkSlateBlue);
            gageback.Width = 1;
            Pen majortick = new Pen(Brushes.DarkBlue);
            majortick.Width = 3;

            int tickmax = 20; // read the number of ticks from the input box
            try
            {
                tickmax = Convert.ToInt16(ticksBox.Text);
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Tick max: " + ex.Message);
                tickmax = 20;
            }

            if (size <= 0) // scale things for the gauge size
            {
                fs = 20;
                bl = 50;
                pb = 40;
            }
            else
            {
                fs = 10;
                bl = 25;
                pb = 42;
            }

            // draw gauge background 
            g.DrawPie(gageback, 15, pb, middle*2-30, middle*2-30, -180.0F, 180.0F);
            //draw the gauge ticks
            for (int i = 0; i <= tickmax; i++)
            {
                NeedleTicks nt = new NeedleTicks(middle-5, i, tickmax);
                if (tickmax / 2 == i || tickmax / 4 == i || 3*tickmax / 4 == i)
                {
                    g.DrawLine(majortick, middle + nt.x1, (pictureBox1.Bottom - bl) - nt.y1,
                        middle + nt.x2, (pictureBox1.Bottom - bl) - nt.y2);
                }
                else
                {
                    g.DrawLine(gageback, middle + nt.x1, (pictureBox1.Bottom - bl) - nt.y1,
                        middle + nt.x2, (pictureBox1.Bottom - bl) - nt.y2);
                }
            }
            // Draw a gauge name on the PictureBox.
            g.DrawString(name,
                new Font("Arial", fs), System.Drawing.Brushes.Blue,
                new Point(middle - name.Length * fs/2, pictureBox1.Bottom - (bl-5)));
            
            // Draw a gauge needles in the PictureBox.
            g.DrawLine(gagepen, middle + ne.x, (pictureBox1.Bottom - bl) - ne.y,
                middle, pictureBox1.Bottom -bl);
            g.DrawLine(gagepenmin, middle + nemin.x, (pictureBox1.Bottom - bl) - nemin.y,
                middle, pictureBox1.Bottom - bl);
            g.DrawLine(gagepenmax, middle + nemax.x, (pictureBox1.Bottom - bl) - nemax.y,
                middle, pictureBox1.Bottom - bl);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adc = Convert.ToInt16(textBox1.Text);
                eunits = Convert.ToDouble(label1.Text);
                if (adc > cntmax)
                {
                    cntmax = adc;
                }
                if (adc < cntmin)
                {
                    cntmin = adc;
                }
                if (eunits > emax)
                {
                    emax = eunits;
                    MaxReadLabel.Text = "Max: " + emax.ToString(dformat(emax));
                }
                if (eunits < emin)
                {
                    emin = eunits;
                    MinReadLabel.Text = "Min: " + emin.ToString(dformat(emin));
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Min/Max: " + ex.Message);
                adc = 0;
                eunits = emin;
            }
            pictureBox1.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            cntmax = 0;
            cntmin = 4096;
            emin = gmax;
            emax = gmin;
            pictureBox1.Refresh();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void sizer_Click(object sender, EventArgs e)
        {
            if (size <= 0)
            {
                this.Width = 222;
                this.Height = 166;
                sizer.Text = "Big";
                size = 1;
                sizer.Left = 165;
                textBox1.Left = 107;
                sizer.Top = 2;
                pictureBox1.Refresh();
            }
            else
            {
                this.Width = 400;
                this.Height = 300;
                sizer.Text = "Small";
                size = 0;
                sizer.Left = 343;
                textBox1.Left = 285;
                sizer.Top = 2;
                pictureBox1.Refresh();
            }
        }


    }
}
