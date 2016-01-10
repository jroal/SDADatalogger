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
    public partial class Graph : Form
    {
        int cntmin = 4096, cntmax = 0, adc = 0;
        public struct NeedleEnd
        {
            public int x, y;
            public NeedleEnd(int counts, int r)
            {
                double theta = Math.PI - (counts / 4096.0) * Math.PI;
                x = Convert.ToInt16( Math.Cos(theta) * r);
                y = Convert.ToInt16( Math.Sin(theta) * r );
            }
        }
        public Graph()
        {
            InitializeComponent();
            try
            {
                adc = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                adc = 0;
            }
        }
        private PictureBox pictureBox1 = new PictureBox();
        private void Graph_Load_1(object sender, System.EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            string name = "Gauge";
            int middle = (pictureBox1.Right + pictureBox1.Left) / 2 ;
           
            NeedleEnd ne = new NeedleEnd(adc , middle - 5);
            NeedleEnd nemin = new NeedleEnd(cntmin, middle - 5);
            NeedleEnd nemax = new NeedleEnd(cntmax, middle - 5);
           
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            Pen gagepen = new Pen(Brushes.Black);
            gagepen.Width = 4;
            Pen gagepenmin = new Pen(Brushes.Blue);
            gagepenmin.Width = 2;
            Pen gagepenmax = new Pen(Brushes.Red);
            gagepenmax.Width = 2;
            // Draw a string on the PictureBox.
            g.DrawString(name,
                new Font("Arial", 20), System.Drawing.Brushes.Blue,
                new Point(middle - name.Length * 10, pictureBox1.Bottom - 40));
            // Draw a line in the PictureBox.

            g.DrawLine(gagepen, middle + ne.x, (pictureBox1.Bottom - 50) - ne.y,
                middle, pictureBox1.Bottom -50);
            g.DrawLine(gagepenmin, middle + nemin.x, (pictureBox1.Bottom - 50) - nemin.y,
                middle, pictureBox1.Bottom - 50);
            g.DrawLine(gagepenmax, middle + nemax.x, (pictureBox1.Bottom - 50) - nemax.y,
                middle, pictureBox1.Bottom - 50);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            adc = Convert.ToInt16(textBox1.Text);
            if (adc > cntmax)
            {
                cntmax = adc;
            }
            if (adc < cntmin)
            {
                cntmin = adc;
            }

            pictureBox1.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            cntmax = 0;
            cntmin = 4096;
        }


    }
}
