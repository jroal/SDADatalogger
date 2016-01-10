using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;


// This program was developed for the B&B Electronics 232SDA12 data acquisition module.  It
// may work on other B&B mudules as well but it was only tested on the 232SDA12.  The program
// was written by Jim Roal http://jimroal.com

public struct digital_data  // this structure converts the bits in the digital data returned
{         
   public bool din1, din2, din3, dout1, dout2, dout3;
    public digital_data(int din)        
    {
            BitVector32 digitalout_b = new BitVector32(din);
            // Creates masks to isolate each of the first 6 bit flags.
            int myBit1 = BitVector32.CreateMask();
            int myBit2 = BitVector32.CreateMask(myBit1);
            int myBit3 = BitVector32.CreateMask(myBit2);
            int myBit4 = BitVector32.CreateMask(myBit3);
            int myBit5 = BitVector32.CreateMask(myBit4);
            int myBit6 = BitVector32.CreateMask(myBit5);

            //digitalout_b = din;
            dout1 = digitalout_b[myBit1];
            dout2 = digitalout_b[myBit2];
            dout3 = digitalout_b[myBit3];
            din1 = digitalout_b[myBit4];
            din2 = digitalout_b[myBit5];
            din3 = digitalout_b[myBit6];
    }
}


namespace SDADatalogger
{
    public partial class Form1 : Form
    {
        int bytesrecieved = 0, bytesexpected = 0;
        int analogchannels = 1;
        int dcount = 0, acount = 0;
        int[] analogData = new int[27];
        int[] dData = new int[2];
        double[] volts = new double[11]; // voltage readings for the channels
        bool expectD = false, recievedD = false, expectA = false, recievedA = false;
        bool sw = true; // just a switch for swapping between analog and digital collection
        DateTime datatime;  // variable to capture when data was collected
        DateTime starttime; // valibale to capture the starting time of the timer
        StreamWriter datast = null;  // define file stream variable
        bool fopen = false, failstop = false; // file opne flag and a failstop variable
        private string CONFIG_FILE = Directory.GetCurrentDirectory() + @"\" + "232config.ini";
        string CHANNEL_DEFS = Directory.GetCurrentDirectory() + @"\" + "232channels.txt";
        string[] chText = new string[11]; // engineering units text strings
        int[] chLength = new int[11]; // Length of maps for each channel
        double[,,] chMap = new double[11,2,20]; // channel conversion maps   
        double[] chMin = new double[11]; // Minimum for the channels
        double[] chMax = new double[11]; // Minimum for the channels
        AboutBox1 about = new AboutBox1();
        public TextBox[] analog = new TextBox[11]; // analog channel counts text boxes
        TextBox[] voltstb = new TextBox[11]; // analog channels in volts
        public TextBox[] EUnits = new TextBox[11]; // analog channels in engineering units 
        public Label[] unitslabels = new Label[11]; //Labels for the analog units
        // each analog channel has a gauge initialized
        Gauge[] frm = new Gauge[11]; // gauge array
        Button[] GButton = new Button[11];// Buttons to launch gauges
        Scope scope1 = new Scope();

        string file1;
        public string dformat(double var)
        { // this function formats the display of double values based on size
            if (var > 100) return "F1";
            else if (var <= 100 && var > 1) return "F4";
            else if (var <= 1 && var > 0.001) return "F6";
            else return "F8";
        }
        public Form1()
        {
            string[] config = new string[10];
            InitializeComponent();
            list_comm_ports();

            // read the config file
            if (File.Exists(CONFIG_FILE))
            {
                int i = 0;
                int index;
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(CONFIG_FILE))
                    {
                        string line;
                        // Read lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            config[i] = line;
                            ++i;
                        }
                        sr.Close();
                        sr.Dispose();
                    }
                    index = ComPortSelect.FindString(config[0]);
                    ComPortSelect.SelectedIndex = index; // select com port
                    RateBox.Text = config[1]; // set sample rate
                    checkBoxD.Checked = Convert.ToBoolean(config[2]);
                    checkBoxA.Checked = Convert.ToBoolean(config[3]);
                    PowerPortBox.Checked = Convert.ToBoolean(config[4]);
                    file1 = config[5];
                    if (file1 != null)
                    {
                        for (int j = 0; File.Exists(file1); j++)
                        {
                            FileInfo oldfile = new FileInfo(config[5]);
                            file1 = oldfile.FullName.Insert(oldfile.FullName.Length - 4,
                                Convert.ToString(j));
                        }
                        FileButton.Text = file1;
                        SaveDataCheckbox.Enabled = true;
                    }
                    else
                    {
                        SaveDataCheckbox.Enabled = false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading ini file: " + e.Message);
                }

            }
            else
            {
                config[1] = "20";//prevent a null for timer interval
            }
            

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            SaveDataCheckbox.Checked = false;
            AnalogChannelsSelect.SelectedItem = "1";
            
            // create and draw all the analog channel boxxes, labels, and gauge buttons
            for (int i = 0; i < 11; ++i)
            {
                analog[i] = new TextBox();
                analog[i].Location = new System.Drawing.Point(179, 253 + 26 * i);
                analog[i].Width = 48;
                voltstb[i] = new TextBox();
                voltstb[i].Location = new System.Drawing.Point(233, 253 + 26 * i);
                voltstb[i].Width = 69;
                EUnits[i] = new TextBox();
                EUnits[i].Location = new System.Drawing.Point(369, 253 + 26 * i);
                EUnits[i].Width = 69;
                unitslabels[i] = new Label();
                unitslabels[i].Location = new System.Drawing.Point(444, 256 + 26 * i);
                frm[i] = new Gauge();
                GButton[i] = new Button();
                GButton[i].Text = "Gauge " + Convert.ToString(i);
                GButton[i].Location = new System.Drawing.Point(309, 253 + 26 * i);
                GButton[i].Width = 53;
                GButton[i].Name = Convert.ToString(i);
                GButton[i].Click += new EventHandler(Graph1_Click );
                this.Controls.Add(GButton[i]);
                this.Controls.Add(analog[i]);
                this.Controls.Add(voltstb[i]);
                this.Controls.Add(EUnits[i]);
                this.Controls.Add(unitslabels[i]);
            }
            ReadChDefs();  // see if a channel defs file exists and read it in
            scope1 = new Scope();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(ComPortSelect.SelectedItem) + Environment.NewLine// save com port selection
            + RateBox.Text + Environment.NewLine //save sample rate
            + Convert.ToString(checkBoxD.Checked) + Environment.NewLine //save get data checked state
            + Convert.ToString(checkBoxA.Checked) + Environment.NewLine // save get analog checked state
            + Convert.ToString(PowerPortBox.Checked) + Environment.NewLine; // save power port checked state
            try
            {
                File.WriteAllText(CONFIG_FILE, str);
                if (datast != null && FileButton.Text != "File") // see if a data file is writeable
                {
                    File.AppendAllText(CONFIG_FILE, file1, Encoding.ASCII); // save log file path
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing ini file: " + ex.Message);
            }

        }
        private void refresh_form()
        {
            getData();
        }
        private void ComPortSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
            {
                textBox1.Text = Convert.ToString( this.ComPortSelect.SelectedItem);
                serialPort1.Dispose();
                serialPort1.PortName = Convert.ToString( this.ComPortSelect.SelectedItem);
                serialPort1.ReadBufferSize = 24;
                serialPort1.Close();
                serialPort1.Open();
                textBox1.Text = Convert.ToString(serialPort1.BaudRate) + " " + 
                    Convert.ToString(serialPort1.PortName);
                serialPort1.ReadTimeout = 200;
                serialPort1.ReceivedBytesThreshold = 1;
                serialPort1.DiscardInBuffer();
                serialPort1.DtrEnable = false;  // this depowers the module
                serialPort1.RtsEnable = false;
            }
            catch (Exception ex)
            {
                RunBox.Checked = false;
                MessageBox.Show("Com port: " + ex.Message);
            }
           // set the response delay rate (fastest is actually 8.333ms)
            timer2.Interval = set_time();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool ok = false ;
            try
            {
                bytesrecieved = serialPort1.BytesToRead;
                responsebox.Text = Convert.ToString(bytesrecieved);
                if (bytesrecieved != bytesexpected)
                {
                    RateBox.Text = Convert.ToString(Convert.ToInt16(RateBox.Text) + 1);
                    ok = false;
                    serialPort1.DiscardInBuffer();
                }
                else
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                RunBox.Checked = false;
                timer2.Stop();
                timer1.Stop();
                ok = false;
                recievedA = false;
                recievedD = false;
                failstop = true;
                 MessageBox.Show("Read data: " + ex.Message);
           }
            if (ok)
            {
                try
                {
                    if (expectA)
                    {
                        for (int i = bytesrecieved - 1; i >= 0; i--)
                        {
                            analogData[i] = Convert.ToInt16(serialPort1.ReadByte());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < bytesrecieved; i++)
                        {
                            dData[i] = Convert.ToInt16(serialPort1.ReadByte());
                        }
                    }
                    serialPort1.DiscardInBuffer();
                    if (expectA)
                    {
                        recievedA = true;
                        acount++;
                        acountLabel.Text = Convert.ToString(acount);
                    }
                    if (expectD)
                    {
                        recievedD = true;
                        dcount++;
                        dcountLabel.Text = Convert.ToString(dcount);
                    }
                }
                catch (Exception ex)
                {
                    RunBox.Checked = false;
                    timer2.Stop();
                    timer1.Stop();
                    failstop = true;
                    MessageBox.Show("Timer2_tick Load array: " + ex.Message);
                }
            }
            else
            {
                recievedA = false;
                recievedD = false;
            }
            timer2.Stop();
            if (recievedD) { recieved_d(); recievedD = false; }
            if (recievedA) { recieved_a(); recievedA = false; }

        }

        private void getData()
        {
            timer2.Start(); // wait timer time to read buffer
            datatime = DateTime.Now;  // capture data time stamp
        }
        private void recieved_d()
        {
            digital_data x = new digital_data(dData[0]);
            DigitalResponse.Text = Convert.ToString(dData[0]);
            if (x.din1) {digI1.Text = "ON";} else {digI1.Text = "OFF";}
            if (x.din2) {digI2.Text = "ON";} else {digI2.Text = "OFF";}
            if (x.din3) {digI3.Text = "ON";} else {digI3.Text = "OFF";}
            if (x.dout1) {digO1.Text = "ON";} else {digO1.Text = "OFF";}
            if (x.dout2) {digO2.Text = "ON";} else {digO2.Text = "OFF";}
            if (x.dout3) {digO3.Text = "ON";} else {digO3.Text = "OFF";}
            write_data();
            recievedD = false;
        }
        private void recieved_a()
        {
            // clear all the data currently in the boxes
            for (int i = 0; i < 11; ++i)
            {
                analog[i].Text = "";
                voltstb[i].Text = "";
                EUnits[i].Text = "";
            }

            if (bytesrecieved >= 1)
            {
                for (int i = 0; i < analogchannels; ++i)
                {
                    analog[i].Text = Convert.ToString(analogData[i*2+1] * 256 + analogData[i*2]);
                    volts[i] = 5.0 * (analogData[i * 2 + 1] * 256 + analogData[i * 2]) / 4096;
                    voltstb[i].Text = Convert.ToString(volts[i]);
                    if (chLength[i] > 1)
                    {
                        EUnits[i].Text = GetEngUnits(i).ToString(dformat(GetEngUnits(i)));
                    }
                    frm[i].textBox1.Text = analog[i].Text;
                    frm[i].label1.Text = EUnits[i].Text;
                }
            }
            write_data(); // store to data file

            if (LogCounts.Checked)
            {
                scope1.type = 1; // counts type
                for (int i = 0; i < 11; i++)
                {
                    scope1.ScaleMax[i].Text = "4096";
                    scope1.ScaleMin[i].Text = "0";
                }
                scope1.textBox1.Text = analog[0].Text;
                scope1.textBox2.Text = analog[1].Text;
                scope1.textBox3.Text = analog[2].Text;
                scope1.textBox4.Text = analog[3].Text;
                scope1.textBox5.Text = analog[4].Text;
                scope1.textBox6.Text = analog[5].Text;
                scope1.textBox7.Text = analog[6].Text;
                scope1.textBox8.Text = analog[7].Text;
                scope1.textBox9.Text = analog[8].Text;
                scope1.textBox10.Text = analog[9].Text;
                scope1.textBox11.Text = analog[10].Text;
                scope1.test(analogchannels); // update scope
                }
            else if (LogEUnits.Checked)
            {
                if (!scope1.run) // in case someone did not define scaling on a selected channel
                {
                    LogEUnits.Checked = false;
                    LogVolts.Checked = true;
                    RunBox.Checked = false;
                }
                scope1.type = 2;  // engineering units type
                for (int i = 0; i < 11; i++)
                {
                    scope1.ScaleMax[i].Text = Convert.ToString(chMax[i]);
                    scope1.ScaleMin[i].Text = Convert.ToString(chMin[i]);
                }
                scope1.textBox1.Text = EUnits[0].Text;
                scope1.textBox2.Text = EUnits[1].Text;
                scope1.textBox3.Text = EUnits[2].Text;
                scope1.textBox4.Text = EUnits[3].Text;
                scope1.textBox5.Text = EUnits[4].Text;
                scope1.textBox6.Text = EUnits[5].Text;
                scope1.textBox7.Text = EUnits[6].Text;
                scope1.textBox8.Text = EUnits[7].Text;
                scope1.textBox9.Text = EUnits[8].Text;
                scope1.textBox10.Text = EUnits[9].Text;
                scope1.textBox11.Text = EUnits[10].Text;
                scope1.test(analogchannels); // update scope            
            }
            else
            {
                scope1.type = 3; // volts type
                for (int i = 0; i < 11; i++)
                {
                    scope1.ScaleMax[i].Text = "5.0";
                    scope1.ScaleMin[i].Text = "0.0";
                }
                scope1.textBox1.Text = voltstb[0].Text;
                scope1.textBox2.Text = voltstb[1].Text;
                scope1.textBox3.Text = voltstb[2].Text;
                scope1.textBox4.Text = voltstb[3].Text;
                scope1.textBox5.Text = voltstb[4].Text;
                scope1.textBox6.Text = voltstb[5].Text;
                scope1.textBox7.Text = voltstb[6].Text;
                scope1.textBox8.Text = voltstb[7].Text;
                scope1.textBox9.Text = voltstb[8].Text;
                scope1.textBox10.Text = voltstb[9].Text;
                scope1.textBox11.Text = voltstb[10].Text;
                scope1.test(analogchannels); // update scope            
            }

            recievedA = false;
        }

        private void GetDigital_Click(object sender, EventArgs e)
        {
            askd();
        }
        private void askd()
        {
            if (!failstop)
            {
                try
                {
                    serialPort1.ReceivedBytesThreshold = 1;
                    serialPort1.WriteLine("!0RD"); // ask for digital data
                    expectD = true;
                    expectA = false;
                    bytesexpected = 1;
                    textBox1.Text = ("!0RD");
                    refresh_form();
                }
                catch (Exception ex)
                {
                    RunBox.Checked = false;
                    timer1.Stop();
                    timer2.Stop();
                    failstop = true;
                    MessageBox.Show("Request digital: " + ex.Message);
                }
            }
        }
        private void AnalogButton_Click(object sender, EventArgs e)
        {
            aska();
        }
        private void aska()
        {
            string str;
            int ch = (analogchannels - 1);
            str = "!0RA" + (char)ch;
            if (!failstop)
            {
                try
                {
                    serialPort1.ReceivedBytesThreshold = analogchannels * 2;
                    serialPort1.WriteLine(str); // ask for analog data
                    textBox1.Text = (str);
                    expectA = true;
                    expectD = false;
                    bytesexpected = analogchannels * 2;
                    refresh_form();
                }
                catch (Exception ex)
                {
                    RunBox.Checked = false;
                    timer1.Stop();
                    timer2.Stop();
                    failstop = true;
                    MessageBox.Show("Request analog: " + ex.Message);
                }
            }
        }

        private void AnalogChannelsSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            analogchannels = Convert.ToInt16(this.AnalogChannelsSelect.SelectedItem);
            //adjust sample rate for more channels and baud rate
            timer2.Interval = set_time() ; 
        }
        private int set_time()
        {
            //adjust response delay for more channels and baud rate
            if (serialPort1.BaudRate > 9600) { serialPort1.BaudRate = 9600; }
            return (15 + 4 * analogchannels); 
        }

        private int list_comm_ports()
        {
            int portnum = -1;
            try
            {
                string[] ports = SerialPort.GetPortNames();
                this.ComPortSelect.Items.Clear();
                portnum = 0;
                foreach (string port in ports)
                {
                    this.ComPortSelect.Items.Add(port);
                    ++portnum;
                }
                this.ComPortSelect.Sorted = true;
                this.ComPortSelect.SelectedItem = ports[0];
                return portnum;
            }
            catch (Exception ex)
            {
                MessageBox.Show("List ports: " + ex.Message);
                RunBox.Checked = false;
                return -1;
            }
        }



        private void RelistPorts_Click(object sender, EventArgs e)
        {
            responsebox.Text = Convert.ToString(list_comm_ports());
        }

        private void set_dout()
        {
             char i;
             int dd;
            BitVector32 d = new BitVector32(0);
            // Creates masks to isolate each of the first 6 bit flags.
            int myBit1 = BitVector32.CreateMask();
            int myBit2 = BitVector32.CreateMask(myBit1);
            int myBit3 = BitVector32.CreateMask(myBit2);

            if (dout1.Checked) { d[myBit1] = true; } else { d[myBit1] = false; }
            if (dout2.Checked) { d[myBit2] = true; } else { d[myBit2] = false; }
            if (dout3.Checked) { d[myBit3] = true; } else { d[myBit3] = false; }
            dd = d.Data;
            i = Convert.ToChar( dd);
            //MessageBox.Show( "result:"  + Convert.ToString(dd) + " = " + i);
            try
            {
                serialPort1.WriteLine("!0SO" + i); // set digital states
            }
            catch (Exception ex)
            {
                responsebox.Text = "error";
                RunBox.Checked = false;
                timer1.Stop();
                failstop = true;
                MessageBox.Show("Set DOUT: " + ex.Message);
            }
        }

        private void dout1_CheckedChanged(object sender, EventArgs e)
        {
            set_dout();
        }
        private void dout2_CheckedChanged(object sender, EventArgs e)
        {
            set_dout();

        }

        private void dout3_CheckedChanged(object sender, EventArgs e)
        {
            set_dout();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            acount = 0;
            dcount = 0;
            acountLabel.Text = Convert.ToString(acount);
            dcountLabel.Text = Convert.ToString(dcount);
            failstop = false;
            set_dout();
            file1 = "File";
            FileButton.Text = file1;
            SaveDataCheckbox.Enabled = false;
            
            if (fopen)
            {
                try
                {
                    datast.Close();
                    datast.Dispose();
                    fopen = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Closing File: " + ex.Message);
                }
            }

        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Closing Port: " + ex.Message);
            }
            if (fopen)
            {
                try
                {
                    datast.Close();
                    datast.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Closing File: " + ex.Message);
                }
            }
            this.Close();
        }

        private void RunBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RunBox.Checked)
            {
                timer1.Start();
                starttime = DateTime.Now;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!failstop)
            {
                if (checkBoxA.Checked && checkBoxD.Checked)
                {
                    if (sw)
                    {
                        aska();
                        sw = false;
                    }
                    else
                    {
                        askd();
                        sw = true;
                    }
                }
                else if (checkBoxD.Checked)
                {
                    askd();
                }
                else
                {
                    aska();
                }

                refresh_form();
            }
        }

        private void RateBox_TextChanged(object sender, EventArgs e)
        {
           int value = timer1.Interval;
           try
           {
               value = Convert.ToInt16(RateBox.Text);
               timer1.Interval = value;
           }
           catch
           {
            if (value < 10) 
                { 
                value = 10;
                RateBox.Text = "10";
                }
           }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileButton.Text = saveFileDialog1.FileName;
            file1 = saveFileDialog1.FileName;
            SaveDataCheckbox.Enabled = true;
            if (fopen)
            {
                datast.Close();
                fopen = false;
            }
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog() ;
        }

        private void SaveDataCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveDataCheckbox.Checked && !fopen)
            {
                // Create file
                string str;
                try
                {
                    datast = new StreamWriter(FileButton.Text);
                    fopen = true;
                    // Build header row
                    if (LogEUnits.Checked)  // if engineering units add these in the header
                    {
                        str = "Date, Hour, Min, Sec, ms, msTicks,";
                        if (chLength[0] > 1) { str += chText[0] + ","; } else { str += "A1,"; }
                        if (chLength[1] > 1) { str += chText[1] + ","; } else { str += "A2,"; }
                        if (chLength[2] > 1) { str += chText[2] + ","; } else { str += "A3,"; }
                        if (chLength[3] > 1) { str += chText[3] + ","; } else { str += "A4,"; }
                        if (chLength[4] > 1) { str += chText[4] + ","; } else { str += "A5,"; }
                        if (chLength[5] > 1) { str += chText[5] + ","; } else { str += "A6,"; }
                        if (chLength[6] > 1) { str += chText[6] + ","; } else { str += "A7,"; }
                        if (chLength[7] > 1) { str += chText[7] + ","; } else { str += "A8,"; }
                        if (chLength[8] > 1) { str += chText[8] + ","; } else { str += "A9,"; }
                        if (chLength[9] > 1) { str += chText[9] + ","; } else { str += "A10,"; }
                        if (chLength[10] > 1) { str += chText[10] + ","; } else { str += "A11,"; }

                        str = str + "ACount, DI1, DI2, DI3, DO1, DO2, DO3, DCount";
                        datast.WriteLine( str);
                    }
                    else
                    {
                        datast.WriteLine("Date, Hour, Min, Sec, ms, msTicks, A1, A2, A3, A4, A5, A6, A7, A8" +
                               ", A9, A10, A11, ACount, DI1, DI2, DI3, DO1, DO2, DO3, DCount");
                    }
                }
                catch (Exception ex)
                {
                    responsebox.Text = "error";
                    MessageBox.Show("Open File: " + ex.Message);
                    RunBox.Checked = false;
                    SaveDataCheckbox.Checked = false;
                    fopen = false;
                }
            }
            else
            {
                //if (fopen) { datast.Close(); }
                //fopen = false;
            }
        }
        private void write_data()
        {
            string str;
            if (SaveDataCheckbox.Checked)
            {
                try
                {
                    str = Convert.ToString(datatime.Date) + "," +
                        Convert.ToString(datatime.Hour) + "," +
                        Convert.ToString(datatime.Minute) + "," +
                        Convert.ToString(datatime.Second) + "," +
                        Convert.ToString(datatime.Millisecond) + "," +
                        Convert.ToString(0.0001*(datatime.Ticks - starttime.Ticks)) + ",";
                    if (recievedA)
                    {
                        if (LogCounts.Checked)
                        {
                            for (int i = 0; i < 11; ++i)
                            {
                                str += analog[i].Text + ",";
                            }
                        }
                        else if (LogEUnits.Checked)
                        {
                            for (int i = 0; i < 11; ++i)
                            {
                                str += EUnits[i].Text + ",";
                            } 
                        }
                        else
                        {
                            for (int i = 0; i < 11; ++i)
                            {
                                str += voltstb[i].Text + ",";
                            } 
                        }
                        str += acountLabel.Text + ",,,,,,,";
                    }
                    else
                    {
                        str += ",,,,,,,,,,,," + digI1.Text + "," +
                            digI2.Text + "," +
                            digI3.Text + "," +
                            digO1.Text + "," +
                            digO2.Text + "," +
                            digO3.Text;
                        str += "," + dcountLabel.Text;
                    }
                    datast.WriteLine(str);
                }
                catch (Exception ex)
                {
                    responsebox.Text = "error";
                    MessageBox.Show("Write File: " + ex.Message);
                    RunBox.Checked = false;
                    failstop = true;
                }
            }
        }

        private void PowerPortBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PowerPortBox.Checked)
            {
                serialPort1.DtrEnable = true;  // this powers the module
                serialPort1.RtsEnable = true;
            }
            else
            {
                serialPort1.DtrEnable = false;  // this depowers the module
                serialPort1.RtsEnable = false;
            }

        }


        private void Graph1_Click(object sender, EventArgs e)
        {
            double min = 9999999, max = -9999999;
            string str = sender.ToString();
            int index = Convert.ToUInt16(str.Substring(str.LastIndexOf(" ")));
            frm[index].textBox1.Text = analog[index].Text;
            if (chText[index] == null)
            {
                frm[index].Name = "Gauge " + Convert.ToString(index + 1);
                frm[index].MinLabel.Text = "";
                frm[index].MaxLabel.Text = "";
            }
            else
            {
                frm[index].Name = chText[index];
                frm[index].engineering = true;
                min = chMin[index];
                max = chMax[index];
                frm[index].MinLabel.Text = Convert.ToString(min);
                frm[index].MaxLabel.Text = Convert.ToString(max);
                frm[index].gmin = min;
                frm[index].gmax = max;
            }
            frm[index].Show();
        }

        private void ScopeButton_Click(object sender, EventArgs e)
        {
            scope1.Show();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }

        private bool ReadChDefs()
        {
            if (File.Exists(CHANNEL_DEFS))
            {
                int i = 0, j = 0, k = 0, chpos = -1, mapnum, comma, colon;
                bool done = false;
                string s;
                string[] str = new string[300];
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(CHANNEL_DEFS))
                    {
                        string line;
                        // Read lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null && i < 300)
                        {
                            str[i] = line;
                            ++i;
                        }
                        sr.Close();
                        sr.Dispose();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading channel defs file: " + e.Message);
                    return false;
                }

                do
                {   
                    chpos = str[j].IndexOf("Channel");
                    if (chpos == 0) // it found a channel definition line
                    {
                        // determine which channel to read the map for
                        colon = str[j].IndexOf(":"); // find the colon
                        s = str[j].Substring(7, colon - 7);
                        mapnum = Convert.ToInt16(s) - 1;
                        if (mapnum < 11) // make sure this is a valid map
                        {
                        // read in the units name
                        chText[mapnum] = str[j].Substring(colon + 1, str[j].Length - colon - 1);
                        chText[mapnum] = chText[mapnum].Trim();
                        chMax[mapnum] = -9999999;
                        chMin[mapnum] = 9999999;
                        unitslabels[mapnum].Text = chText[mapnum];
                        k = 0;
                            do
                            {
                                j++;
                                try
                                {
                                    comma = str[j].IndexOf(',');
                                    if (comma > 0)
                                    {
                                        s = str[j].Substring(0, comma);
                                        chMap[mapnum, 0, k] = Convert.ToDouble(s);
                                        s = str[j].Substring(comma + 1, str[j].Length - (comma + 1));
                                        chMap[mapnum, 1, k] = Convert.ToDouble(s);
                                        if (chMap[mapnum, 1, k] > chMax[mapnum]) { chMax[mapnum] = chMap[mapnum, 1, k]; }
                                        if (chMap[mapnum, 1, k] < chMin[mapnum]) { chMin[mapnum] = chMap[mapnum, 1, k]; }
                                         k++;
                                   }
                                    else
                                    {
                                        done = true;
                                        if (k > 20) k = 20;
                                        chLength[mapnum] = k;
                                    }
                                }
                                catch //(Exception e)
                                {
                                    //MessageBox.Show("Error reading channel defs file: " + e.Message);
                                    done = true;
                                    chLength[mapnum] = k;
                                }
                            } while (!done);
                        }
                        done = false;
                    }
                    else
                    {
                        j++;
                    }
                }
                while (j < i);
                return true;
            }
            else
            {
                return false;
            }
        }
        private double GetEngUnits(int channel) // interpolate to get the engineering units for the current value
        {
            double x1, x2, y1, y2;
            int index, direction;
            bool done = false;

            if (chLength[channel] > 3)
            {
                index = chLength[channel] / 2 - 1; // pick a spot in the middle of the map
            }
            else
            {
                index = chLength[channel] - 1;
            }
                direction = index + 1;
            
            do
            {
                if (index < 0)
                {
                    return chMap[channel, 1, 0];
                }
                if (index > chLength[channel] - 1)
                {
                    return chMap[channel, 1, chLength[channel] - 1];
                }
                x1 = chMap[channel, 0, index]; // find a starting x value
                x2 = chMap[channel, 0, direction]; // find a starting x value
                if (x1 > volts[channel] && x2 > volts[channel])
                {
                    direction = index;
                    index--;
                }
                else if (x1 < volts[channel] && x2 < volts[channel])
                {
                    direction = index;
                    index++;
                }
                else 
                {
                    y1 = chMap[channel, 1, index];
                    y2 = chMap[channel, 1, direction];
                    return y1 + ((y2 - y1) / (x2 - x1)) * (volts[channel] - x1);
                }
            } while (!done);
            return 0; // if you get here, something went wrong
        }

        private void DefMaps_Click(object sender, EventArgs e)
        {
            DefineMaps def = new DefineMaps();
            def.CHANNEL_DEFS = CHANNEL_DEFS;
            def.chText2 = chText;
            def.chLength2 = chLength;
            def.chMap2 = chMap;
            def.ShowDialog() ;
            for (int i = 0; i < 11; ++i) // clear labels
            {
                unitslabels[i].Text = "";
            }
            ReadChDefs();  // see if a channel defs file exists and read it in

        }

    }
}