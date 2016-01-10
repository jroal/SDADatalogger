using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SDADatalogger
{
    public partial class DefineMaps : Form
    {
        public string[] chText2 = new string[11]; // engineering units text strings
        public int[] chLength2 = new int[11]; // Length of maps for each channel
        public double[,,] chMap2 = new double[11, 2, 20]; // channel conversion maps       
        public string CHANNEL_DEFS;
        string[] FileContents = new string[300];
        TextBox[] x = new TextBox[20];
        TextBox[] y = new TextBox[20];
        int channel;

        public DefineMaps()
        {
            InitializeComponent();
            for (int i = 0; i < 20; ++i)
            {
                x[i] = new TextBox();
                x[i].Location = new System.Drawing.Point(311, 30 + 20 * i);
                x[i].Width = 100;
                y[i] = new TextBox();
                y[i].Location = new System.Drawing.Point(415, 30 + 20 * i);
                y[i].Width = 100;
                this.Controls.Add(x[i]);
                this.Controls.Add(y[i]);
            }
        }

        private void ChannelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str, str2;
            str2 = Convert.ToString(ChannelBox.SelectedItem);
            channel = Convert.ToUInt16(str2.Substring(str2.LastIndexOf(" ")))-1;
            // clear text boxes
            for (int i = 0; i < 20; ++i)
            {
                x[i].Text = "";
                y[i].Text = "";
            }
            if (chText2[channel] != null)
            {
                MapDataBox.Text = chText2[channel].Trim();
                LengthLabel.Text = "Map Length: " + Convert.ToString(chLength2[channel]);
                // show map values in the text box for editing           
                for (int i = 0; i < chLength2[channel]; ++i)
                {
                    str = Convert.ToString(chMap2[channel, 0, i]) + ", " + Convert.ToString(chMap2[channel, 1, i]);
                    //MapDataBox.AppendText(str + Environment.NewLine);
                    x[i].Text = Convert.ToString(chMap2[channel, 0, i]);
                    y[i].Text = Convert.ToString(chMap2[channel, 1, i]);
                }
            }
            else
            {
                MapDataBox.Text = "";
                LengthLabel.Text = "";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // create a string array of all the lines of data
            int line = 0;
            for (int i = 0; i < 11; ++i)
            {
                if (chLength2[i] > 2)
                {
                    //write channel definition header for this channel
                    FileContents[line] = "Channel " + Convert.ToString(i + 1) + ": " + chText2[i];
                    //FileContents[line] += Environment.NewLine;
                    ++line;
                    for (int k = 0; k < chLength2[i]; ++k)
                    {
                        FileContents[line] = Convert.ToString(chMap2[i, 0, k]);
                        FileContents[line] += ", ";
                        FileContents[line] += Convert.ToString(chMap2[i, 1, k]);
                        //FileContents[line] += Environment.NewLine;
                        ++line;
                    }
                }
            }
            // write the string array to the file
            try
            {
                File.WriteAllLines(CHANNEL_DEFS, FileContents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing channel definition file: " + ex.Message);
            }
            ResponseLabel.Text = "File Saved!";
        }

        private void DefineMaps_Load(object sender, EventArgs e)
        {
            FileLabel.Text = CHANNEL_DEFS;

        }

        private void Store_Click(object sender, EventArgs e)
        {
            int len = 0;
            if (MapDataBox.Text != null)
            {
                for (int i = 0; i < 20; ++i)
                {
                    if (x[i].Text != "" && y[i].Text != "")
                    {
                        try
                        {
                            chMap2[channel, 0, i] = Convert.ToDouble(x[i].Text);
                            if (chMap2[channel, 0, i] < 0 || chMap2[channel, 0, i] > 5)
                            {
                                MessageBox.Show("X value is beyond 0-5V range on row "
                                    + Convert.ToString(i));
                            }
                            chMap2[channel, 1, i] = Convert.ToDouble(y[i].Text);
                            len = i;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error storing map values: " + ex.Message);
                            return;
                        }
                    }
                    else if (x[i].Text == "" ^ y[i].Text == "")
                    {
                        MessageBox.Show("Map data contains a blank X or Y value for row: " +
                            Convert.ToString(i + 1));
                        return;
                    }
                    else
                    {
                        chText2[channel] = MapDataBox.Text.Trim();
                        chLength2[channel] = i; //set the length
                ResponseLabel.Text = "Data Stored - make sure you save file before closing this form";
                        return;
                    }
                }
                chText2[channel] = MapDataBox.Text.Trim();
                chLength2[channel] = len + 1; //set the length
                ResponseLabel.Text = "Data Stored - make sure you save file before closing this form";
            }
            else
            {
                MessageBox.Show("No units entered.  Enter units before storing.");
                return;
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            chText2[channel] = null;
            chLength2[channel] = 0;
            for (int i = 0; i < 20; ++i)
            {
                chMap2[channel, 0, i] = 0;
                chMap2[channel, 1, i] = 0;
                x[i].Text = "";
                y[i].Text = "";
            }
            MapDataBox.Text = "";
            LengthLabel.Text = "";
            ResponseLabel.Text = "Map deleted - make sure you save file before closing this form";
        }

        private void Build_Click(object sender, EventArgs e)
        {
            double slope, offset, xvalue;
            try
            {
                slope = Convert.ToDouble(SlopeBox.Text);
                offset = Convert.ToDouble(OffsetBox.Text);
                for (int i = 0; i < 20; ++i)
                {
                    xvalue = i * 5.0/19;
                    x[i].Text = Convert.ToString(xvalue);
                    y[i].Text = Convert.ToString(xvalue * slope + offset);
                }
                chLength2[channel] = 20;
                LengthLabel.Text = "Map Length: " + Convert.ToString(chLength2[channel]);
                MapDataBox.Text = "Units " + Convert.ToString(channel + 1);
                chText2[channel] = MapDataBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building map: " + ex.Message);
            }
       
        }

        private void ClipButton_Click(object sender, EventArgs e)
        {
            string str = "nothing";
            string[] str2 = new string[100];
            string[] str3 = new string[5];
            char[] charSeparators = new char[] { ',' ,(char)10, (char)13, (char)9};
            int length, l2;

            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                str = Clipboard.GetText(TextDataFormat.Text);
                str2 = str.Split((char)10);
                length = str2.GetLength(0);
                l2 = length - 1;
                if (length > 20) length = 20;
                try
                {
                    for (int i = 0; i < length; ++i)
                    {
                        str3 = str2[i].Split(charSeparators);
                        if (str3.GetLength(0) > 1) // make sure there is a value pair
                        {
                            x[i].Text = str3[0];
                            y[i].Text = str3[1];
                            l2 = i;
                        }
                    }
                    chLength2[channel] = l2 + 1;
                    LengthLabel.Text = "Map Length: " + Convert.ToString(chLength2[channel]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying clipboard map: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Clipboard does not contain data in the required format (Text)");
            }
            //MessageBox.Show(str);
        }


    }
}
