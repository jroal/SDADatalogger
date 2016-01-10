using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SDADatalogger
{


    public partial class Scope : Form
    {
        Point[] plot1 = new Point[600];
        Point[] plot1old = new Point[600];
        Point[] plot2 = new Point[600];
        Point[] plot2old = new Point[600];
        Point[] plot3 = new Point[600];
        Point[] plot3old = new Point[600];
        Point[] plot4 = new Point[600];
        Point[] plot4old = new Point[600];
        Point[] plot5 = new Point[600];
        Point[] plot5old = new Point[600];
        Point[] plot6 = new Point[600];
        Point[] plot6old = new Point[600];
        Point[] plot7 = new Point[600];
        Point[] plot7old = new Point[600];
        Point[] plot8 = new Point[600];
        Point[] plot8old = new Point[600];
        Point[] plot9 = new Point[600];
        Point[] plot9old = new Point[600];
        Point[] plot10 = new Point[600];
        Point[] plot10old = new Point[600];
        Point[] plot11 = new Point[600];
        Point[] plot11old = new Point[600];
        int ticks = 0;
        int ch = 0;
        public bool run = true;
        public int type;
        public Label[] ScaleMax = new Label[11];
        public Label[] ScaleMin = new Label[11];

        public Scope()
        {
            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                ScaleMax[i] = new Label();
                ScaleMax[i].Location = new System.Drawing.Point(125 + 60 * i, 6);
                ScaleMax[i].Width = 50;
                ScaleMax[i].Height = 17;
                ScaleMax[i].Text = "Max " + Convert.ToString(i + 1);
                ScaleMin[i] = new Label();
                ScaleMin[i].Location = new System.Drawing.Point(125 + 60 * i, 382);
                ScaleMin[i].Width = 50;
                ScaleMin[i].Height = 17;
                ScaleMin[i].Text = "Min " + Convert.ToString(i + 1);
                this.Controls.Add(ScaleMax[i]);
                this.Controls.Add(ScaleMin[i]);
            }
            ScaleMax[0].BackColor = System.Drawing.Color.Black ;
            ScaleMax[0].ForeColor = System.Drawing.Color.White;
            ScaleMin[0].BackColor = System.Drawing.Color.Black;
            ScaleMin[0].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[1].BackColor = System.Drawing.Color.DarkBlue;
            ScaleMax[1].ForeColor = System.Drawing.Color.White;
            ScaleMin[1].BackColor = System.Drawing.Color.DarkBlue;
            ScaleMin[1].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[2].BackColor = System.Drawing.Color.DarkCyan;
            ScaleMax[2].ForeColor = System.Drawing.Color.White;
            ScaleMin[2].BackColor = System.Drawing.Color.DarkCyan;
            ScaleMin[2].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[3].BackColor = System.Drawing.Color.DarkGreen;
            ScaleMax[3].ForeColor = System.Drawing.Color.White;
            ScaleMin[3].BackColor = System.Drawing.Color.DarkGreen;
            ScaleMin[3].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[4].BackColor = System.Drawing.Color.Red;
            ScaleMax[4].ForeColor = System.Drawing.Color.White;
            ScaleMin[4].BackColor = System.Drawing.Color.Red;
            ScaleMin[4].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[5].BackColor = System.Drawing.Color.DarkRed;
            ScaleMax[5].ForeColor = System.Drawing.Color.White;
            ScaleMin[5].BackColor = System.Drawing.Color.DarkRed;
            ScaleMin[5].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[6].BackColor = System.Drawing.Color.DarkViolet;
            ScaleMax[6].ForeColor = System.Drawing.Color.White;
            ScaleMin[6].BackColor = System.Drawing.Color.DarkViolet;
            ScaleMin[6].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[7].BackColor = System.Drawing.Color.Fuchsia;
            ScaleMax[7].ForeColor = System.Drawing.Color.White;
            ScaleMin[7].BackColor = System.Drawing.Color.Fuchsia;
            ScaleMin[7].ForeColor = System.Drawing.Color.White;
            
            ScaleMax[8].BackColor = System.Drawing.Color.Gold;
            ScaleMax[8].ForeColor = System.Drawing.Color.Black;
            ScaleMin[8].BackColor = System.Drawing.Color.Gold;
            ScaleMin[8].ForeColor = System.Drawing.Color.Black;
            
            ScaleMax[9].BackColor = System.Drawing.Color.Chartreuse;
            ScaleMax[9].ForeColor = System.Drawing.Color.Black;
            ScaleMin[9].BackColor = System.Drawing.Color.Chartreuse;
            ScaleMin[9].ForeColor = System.Drawing.Color.Black;
            
            ScaleMax[10].BackColor = System.Drawing.Color.Chocolate;
            ScaleMax[10].ForeColor = System.Drawing.Color.Black;
            ScaleMin[10].BackColor = System.Drawing.Color.Chocolate;
            ScaleMin[10].ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

                string name = this.Name;
                Pen pen1 = new Pen(Brushes.Black);
                pen1.Width = 2;
                Pen pen2 = new Pen(Brushes.DarkBlue);
                pen2.Width = 2;
                Pen pen3 = new Pen(Brushes.DarkCyan);
                pen3.Width = 2;
                Pen pen4 = new Pen(Brushes.DarkGreen);
                pen4.Width = 2;
                Pen pen5 = new Pen(Brushes.Red);
                pen5.Width = 2;
                Pen pen6 = new Pen(Brushes.DarkRed);
                pen6.Width = 2;
                Pen pen7 = new Pen(Brushes.DarkViolet);
                pen7.Width = 2;
                Pen pen8 = new Pen(Brushes.Fuchsia);
                pen8.Width = 2;
                Pen pen9 = new Pen(Brushes.Gold);
                pen9.Width = 2;
                Pen pen10 = new Pen(Brushes.Chartreuse);
                pen10.Width = 2;
                Pen pen11 = new Pen(Brushes.Chocolate);
                pen11.Width = 2;

                Pen gridpen = new Pen(Brushes.LightGray);
                gridpen.Width = 1;

                // Create a local version of the graphics object for the PictureBox.
                Graphics g = e.Graphics;
                if (ch >= 1 && checkBox1.Checked) { g.DrawLines(pen1, plot1); }
                if (ch >= 2 && checkBox2.Checked) { g.DrawLines(pen2, plot2); }
                if (ch >= 3 && checkBox3.Checked) { g.DrawLines(pen3, plot3); }
                if (ch >= 4 && checkBox4.Checked) { g.DrawLines(pen4, plot4); }
                if (ch >= 5 && checkBox5.Checked) { g.DrawLines(pen5, plot5); }
                if (ch >= 6 && checkBox6.Checked) { g.DrawLines(pen6, plot6); }
                if (ch >= 7 && checkBox7.Checked) { g.DrawLines(pen7, plot7); }
                if (ch >= 8 && checkBox8.Checked) { g.DrawLines(pen8, plot8); }
                if (ch >= 9 && checkBox9.Checked) { g.DrawLines(pen9, plot9); }
                if (ch >= 10 && checkBox10.Checked) { g.DrawLines(pen10, plot10); }
                if (ch >= 11 && checkBox11.Checked) { g.DrawLines(pen11, plot11); }
                    

                    //make grid lines
                g.DrawLine(gridpen, 0, 306, 600, 306);
                g.DrawLine(gridpen, 0, 262, 600, 262);
                g.DrawLine(gridpen, 0, 219, 600, 219);
                g.DrawLine(gridpen, 0, 175, 600, 175);
                g.DrawLine(gridpen, 0, 131, 600, 131);
                g.DrawLine(gridpen, 0, 88, 600, 88);
                g.DrawLine(gridpen, 0, 44, 600, 44);
        }


        private void Scope_Load(object sender, EventArgs e)
        {
            pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (run)
            {
                run = false;
                label1.Text = "Click trace to resume";
            }
            else
            {
                run = true;
                label1.Text = "Click trace to pause";
            }
        }


        public void test(int channels)
        {
            double value1 = 0, value2 = 0, value3 = 0, value4 = 0, value5 = 0, value6 = 0, 
                value7 = 0, value8 = 0, value9 = 0, value10 = 0, value11 = 0, min, max;
            if (ch != channels) { ticks = 0; }// clear everything if channel number has changed
            ch = channels;
            if (type == 1)
            {
                if (channels >= 1) { value1 = 4096 - Convert.ToDouble(textBox1.Text); }
                if (channels >= 2) { value2 = 4096 - Convert.ToDouble(textBox2.Text); }
                if (channels >= 3) { value3 = 4096 - Convert.ToDouble(textBox3.Text); }
                if (channels >= 4) { value4 = 4096 - Convert.ToDouble(textBox4.Text); }
                if (channels >= 5) { value5 = 4096 - Convert.ToDouble(textBox5.Text); }
                if (channels >= 6) { value6 = 4096 - Convert.ToDouble(textBox6.Text); }
                if (channels >= 7) { value7 = 4096 - Convert.ToDouble(textBox7.Text); }
                if (channels >= 8) { value8 = 4096 - Convert.ToDouble(textBox8.Text); }
                if (channels >= 9) { value9 = 4096 - Convert.ToDouble(textBox9.Text); }
                if (channels >= 10) { value10 = 4096 - Convert.ToDouble(textBox10.Text); }
                if (channels >= 11) { value11 = 4096 - Convert.ToDouble(textBox11.Text); }
            }
            else if (type == 2)
            {
                try
                {
                    if (channels >= 1)
                    {
                        min = Convert.ToDouble(ScaleMin[0].Text);
                        max = Convert.ToDouble(ScaleMax[0].Text);
                        value1 = 4096 - ((Convert.ToDouble(textBox1.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 2)
                    {
                        min = Convert.ToDouble(ScaleMin[1].Text);
                        max = Convert.ToDouble(ScaleMax[1].Text);
                        value2 = 4096 - ((Convert.ToDouble(textBox2.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 3)
                    {
                        min = Convert.ToDouble(ScaleMin[2].Text);
                        max = Convert.ToDouble(ScaleMax[2].Text);
                        value3 = 4096 - ((Convert.ToDouble(textBox3.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 4)
                    {
                        min = Convert.ToDouble(ScaleMin[3].Text);
                        max = Convert.ToDouble(ScaleMax[3].Text);
                        value4 = 4096 - ((Convert.ToDouble(textBox4.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 5)
                    {
                        min = Convert.ToDouble(ScaleMin[4].Text);
                        max = Convert.ToDouble(ScaleMax[4].Text);
                        value5 = 4096 - ((Convert.ToDouble(textBox5.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 6)
                    {
                        min = Convert.ToDouble(ScaleMin[5].Text);
                        max = Convert.ToDouble(ScaleMax[5].Text);
                        value6 = 4096 - ((Convert.ToDouble(textBox6.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 7)
                    {
                        min = Convert.ToDouble(ScaleMin[6].Text);
                        max = Convert.ToDouble(ScaleMax[6].Text);
                        value7 = 4096 - ((Convert.ToDouble(textBox7.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 8)
                    {
                        min = Convert.ToDouble(ScaleMin[7].Text);
                        max = Convert.ToDouble(ScaleMax[7].Text);
                        value8 = 4096 - ((Convert.ToDouble(textBox8.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 9)
                    {
                        min = Convert.ToDouble(ScaleMin[8].Text);
                        max = Convert.ToDouble(ScaleMax[8].Text);
                        value9 = 4096 - ((Convert.ToDouble(textBox9.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 10)
                    {
                        min = Convert.ToDouble(ScaleMin[9].Text);
                        max = Convert.ToDouble(ScaleMax[9].Text);
                        value10 = 4096 - ((Convert.ToDouble(textBox10.Text) - min) * 4096) / (max - min);
                    }
                    if (channels >= 11)
                    {
                        min = Convert.ToDouble(ScaleMin[10].Text);
                        max = Convert.ToDouble(ScaleMax[10].Text);
                        value11 = 4096 - ((Convert.ToDouble(textBox11.Text) - min) * 4096) / (max - min);
                    }
                }
                catch //(Exception ex)
                {
                    run = false;
                    MessageBox.Show("Missing scaling for engineering units on one or more channels");
                    
                }
            }
            else
            {
                min = 0.0;
                max = 5.0;
                if (channels >= 1) { value1 = 4096 - ((Convert.ToDouble(textBox1.Text) - min) * 4096) / (max - min); }
                if (channels >= 2) { value2 = 4096 - ((Convert.ToDouble(textBox2.Text) - min) * 4096) / (max - min); }
                if (channels >= 3) { value3 = 4096 - ((Convert.ToDouble(textBox3.Text) - min) * 4096) / (max - min); }
                if (channels >= 4) { value4 = 4096 - ((Convert.ToDouble(textBox4.Text) - min) * 4096) / (max - min); }
                if (channels >= 5) { value5 = 4096 - ((Convert.ToDouble(textBox5.Text) - min) * 4096) / (max - min); }
                if (channels >= 6) { value6 = 4096 - ((Convert.ToDouble(textBox6.Text) - min) * 4096) / (max - min); }
                if (channels >= 7) { value7 = 4096 - ((Convert.ToDouble(textBox7.Text) - min) * 4096) / (max - min); }
                if (channels >= 8) { value8 = 4096 - ((Convert.ToDouble(textBox8.Text) - min) * 4096) / (max - min); }
                if (channels >= 9) { value9 = 4096 - ((Convert.ToDouble(textBox9.Text) - min) * 4096) / (max - min); }
                if (channels >= 10) { value10 = 4096 - ((Convert.ToDouble(textBox10.Text) - min) * 4096) / (max - min); }
                if (channels >= 11) { value11 = 4096 - ((Convert.ToDouble(textBox11.Text) - min) * 4096) / (max - min); }
            }
            if (run)
            {
                if (channels <= 0) { ticks = 0; }//clear everything if no analog channels
                if (ticks < 600)
                {
                    if (channels >= 1)
                    {
                        plot1[ticks].X = ticks;
                        plot1[ticks].Y = Convert.ToInt16(value1 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot1[p].Y = Convert.ToInt16(value1 * (pictureBox2.Height / 4096.0));
                            plot1[p].X = ticks;
                        }
                    }
                    if (channels >= 2)
                    {
                        plot2[ticks].X = ticks;
                        plot2[ticks].Y = Convert.ToInt16(value2 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot2[p].Y = Convert.ToInt16(value2 * (pictureBox2.Height / 4096.0));
                            plot2[p].X = ticks;
                        }
                    }
                    if (channels >= 3)
                    {
                        plot3[ticks].X = ticks;
                        plot3[ticks].Y = Convert.ToInt16(value3 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot3[p].Y = Convert.ToInt16(value3 * (pictureBox2.Height / 4096.0));
                            plot3[p].X = ticks;
                        }
                    }
                    if (channels >= 4)
                    {
                        plot4[ticks].X = ticks;
                        plot4[ticks].Y = Convert.ToInt16(value4 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot4[p].Y = Convert.ToInt16(value4 * (pictureBox2.Height / 4096.0));
                            plot4[p].X = ticks;
                        }
                    }
                    if (channels >= 5)
                    {
                        plot5[ticks].X = ticks;
                        plot5[ticks].Y = Convert.ToInt16(value5 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot5[p].Y = Convert.ToInt16(value5 * (pictureBox2.Height / 4096.0));
                            plot5[p].X = ticks;
                        }
                    }
                    if (channels >= 6)
                    {
                        plot6[ticks].X = ticks;
                        plot6[ticks].Y = Convert.ToInt16(value6 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot6[p].Y = Convert.ToInt16(value6 * (pictureBox2.Height / 4096.0));
                            plot6[p].X = ticks;
                        }
                    }
                    if (channels >= 7)
                    {
                        plot7[ticks].X = ticks;
                        plot7[ticks].Y = Convert.ToInt16(value7 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot7[p].Y = Convert.ToInt16(value7 * (pictureBox2.Height / 4096.0));
                            plot7[p].X = ticks;
                        }
                    }
                    if (channels >= 8)
                    {
                        plot8[ticks].X = ticks;
                        plot8[ticks].Y = Convert.ToInt16(value8 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot8[p].Y = Convert.ToInt16(value8 * (pictureBox2.Height / 4096.0));
                            plot8[p].X = ticks;
                        }
                    }
                    if (channels >= 9)
                    {
                        plot9[ticks].X = ticks;
                        plot9[ticks].Y = Convert.ToInt16(value9 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot9[p].Y = Convert.ToInt16(value9 * (pictureBox2.Height / 4096.0));
                            plot9[p].X = ticks;
                        }
                    }
                    if (channels >= 10)
                    {
                        plot10[ticks].X = ticks;
                        plot10[ticks].Y = Convert.ToInt16(value10 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot10[p].Y = Convert.ToInt16(value10 * (pictureBox2.Height / 4096.0));
                            plot10[p].X = ticks;
                        }
                    }
                    if (channels >= 11)
                    {
                        plot11[ticks].X = ticks;
                        plot11[ticks].Y = Convert.ToInt16(value11 * (pictureBox2.Height / 4096.0));
                        for (int p = ticks; p < 600; p++)
                        {
                            plot11[p].Y = Convert.ToInt16(value11 * (pictureBox2.Height / 4096.0));
                            plot11[p].X = ticks;
                        }
                    }
                }
                else
                {
                    if (channels >= 1)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot1old[p] = plot1[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot1[p - 1].Y = plot1old[p].Y; //shift Y down array 1
                        }
                        plot1[599].X = 600;
                        plot1[599].Y = Convert.ToInt16(value1 * (350.0 / 4096.0));
                    }
                    if (channels >= 2)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot2old[p] = plot2[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot2[p - 1].Y = plot2old[p].Y; //shift Y down array 1
                        }
                        plot2[599].X = 600;
                        plot2[599].Y = Convert.ToInt16(value2 * (350.0 / 4096.0));
                    }
                    if (channels >= 3)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot3old[p] = plot3[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot3[p - 1].Y = plot3old[p].Y; //shift Y down array 1
                        }
                        plot3[599].X = 600;
                        plot3[599].Y = Convert.ToInt16(value3 * (350.0 / 4096.0));
                    }
                    if (channels >= 4)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot4old[p] = plot4[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot4[p - 1].Y = plot4old[p].Y; //shift Y down array 1
                        }
                        plot4[599].X = 600;
                        plot4[599].Y = Convert.ToInt16(value4 * (350.0 / 4096.0));
                    }
                    if (channels >= 5)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot5old[p] = plot5[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot5[p - 1].Y = plot5old[p].Y; //shift Y down array 1
                        }
                        plot5[599].X = 600;
                        plot5[599].Y = Convert.ToInt16(value5 * (350.0 / 4096.0));
                    }
                    if (channels >= 6)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot6old[p] = plot6[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot6[p - 1].Y = plot6old[p].Y; //shift Y down array 1
                        }
                        plot6[599].X = 600;
                        plot6[599].Y = Convert.ToInt16(value6 * (350.0 / 4096.0));
                    }
                    if (channels >= 7)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot7old[p] = plot7[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot7[p - 1].Y = plot7old[p].Y; //shift Y down array 1
                        }
                        plot7[599].X = 600;
                        plot7[599].Y = Convert.ToInt16(value7 * (350.0 / 4096.0));
                    }
                    if (channels >= 8)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot8old[p] = plot8[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot8[p - 1].Y = plot8old[p].Y; //shift Y down array 1
                        }
                        plot8[599].X = 600;
                        plot8[599].Y = Convert.ToInt16(value8 * (350.0 / 4096.0));
                    }
                    if (channels >= 9)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot9old[p] = plot9[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot9[p - 1].Y = plot9old[p].Y; //shift Y down array 1
                        }
                        plot9[599].X = 600;
                        plot9[599].Y = Convert.ToInt16(value9 * (350.0 / 4096.0));
                    }
                    if (channels >= 10)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot10old[p] = plot10[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot10[p - 1].Y = plot10old[p].Y; //shift Y down array 1
                        }
                        plot10[599].X = 600;
                        plot10[599].Y = Convert.ToInt16(value10 * (350.0 / 4096.0));
                    }
                    if (channels >= 11)
                    {
                        for (int p = 0; p < 600; p++)
                        {
                            plot11old[p] = plot11[p]; // copy array
                        }
                        for (int p = 1; p < 600; p++)
                        {
                            plot11[p - 1].Y = plot11old[p].Y; //shift Y down array 1
                        }
                        plot11[599].X = 600;
                        plot11[599].Y = Convert.ToInt16(value11 * (350.0 / 4096.0));
                    }
                }
            ticks++;
            }
            pictureBox2.Refresh();
 
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


    }
}
