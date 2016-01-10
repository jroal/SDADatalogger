namespace SDADatalogger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ComPortSelect = new System.Windows.Forms.ComboBox();
            this.responsebox = new System.Windows.Forms.TextBox();
            this.GetDigital = new System.Windows.Forms.Button();
            this.DigitalResponse = new System.Windows.Forms.TextBox();
            this.digI1 = new System.Windows.Forms.TextBox();
            this.digI2 = new System.Windows.Forms.TextBox();
            this.digI3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AnalogButton = new System.Windows.Forms.Button();
            this.AnalogChannelsSelect = new System.Windows.Forms.ComboBox();
            this.RelistPorts = new System.Windows.Forms.Button();
            this.digO1 = new System.Windows.Forms.TextBox();
            this.digO2 = new System.Windows.Forms.TextBox();
            this.digO3 = new System.Windows.Forms.TextBox();
            this.dout1 = new System.Windows.Forms.CheckBox();
            this.dout2 = new System.Windows.Forms.CheckBox();
            this.dout3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Close_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RunBox = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.RateBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dcountLabel = new System.Windows.Forms.Label();
            this.acountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxD = new System.Windows.Forms.CheckBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FileButton = new System.Windows.Forms.Button();
            this.SaveDataCheckbox = new System.Windows.Forms.CheckBox();
            this.countsLabel = new System.Windows.Forms.Label();
            this.VoltsLabel = new System.Windows.Forms.Label();
            this.LogVolts = new System.Windows.Forms.RadioButton();
            this.LogCounts = new System.Windows.Forms.RadioButton();
            this.PowerPortBox = new System.Windows.Forms.CheckBox();
            this.ScopeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.LogEUnits = new System.Windows.Forms.RadioButton();
            this.DefMaps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DtrEnable = true;
            this.serialPort1.ReadBufferSize = 8;
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.ReceivedBytesThreshold = 22;
            this.serialPort1.RtsEnable = true;
            this.serialPort1.WriteBufferSize = 4;
            this.serialPort1.WriteTimeout = 500;
            // 
            // ComPortSelect
            // 
            this.ComPortSelect.FormattingEnabled = true;
            this.ComPortSelect.Items.AddRange(new object[] {
            "none",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.ComPortSelect.Location = new System.Drawing.Point(12, 12);
            this.ComPortSelect.Name = "ComPortSelect";
            this.ComPortSelect.Size = new System.Drawing.Size(121, 21);
            this.ComPortSelect.TabIndex = 0;
            this.ComPortSelect.SelectedIndexChanged += new System.EventHandler(this.ComPortSelect_SelectedIndexChanged);
            // 
            // responsebox
            // 
            this.responsebox.Location = new System.Drawing.Point(12, 39);
            this.responsebox.Name = "responsebox";
            this.responsebox.Size = new System.Drawing.Size(75, 20);
            this.responsebox.TabIndex = 1;
            // 
            // GetDigital
            // 
            this.GetDigital.Location = new System.Drawing.Point(12, 66);
            this.GetDigital.Name = "GetDigital";
            this.GetDigital.Size = new System.Drawing.Size(104, 23);
            this.GetDigital.TabIndex = 2;
            this.GetDigital.Text = "Get Digital Sample";
            this.GetDigital.UseVisualStyleBackColor = true;
            this.GetDigital.Click += new System.EventHandler(this.GetDigital_Click);
            // 
            // DigitalResponse
            // 
            this.DigitalResponse.Location = new System.Drawing.Point(12, 95);
            this.DigitalResponse.Name = "DigitalResponse";
            this.DigitalResponse.Size = new System.Drawing.Size(48, 20);
            this.DigitalResponse.TabIndex = 3;
            // 
            // digI1
            // 
            this.digI1.Location = new System.Drawing.Point(180, 103);
            this.digI1.Name = "digI1";
            this.digI1.Size = new System.Drawing.Size(100, 20);
            this.digI1.TabIndex = 4;
            // 
            // digI2
            // 
            this.digI2.Location = new System.Drawing.Point(180, 129);
            this.digI2.Name = "digI2";
            this.digI2.Size = new System.Drawing.Size(100, 20);
            this.digI2.TabIndex = 5;
            // 
            // digI3
            // 
            this.digI3.Location = new System.Drawing.Point(180, 155);
            this.digI3.Name = "digI3";
            this.digI3.Size = new System.Drawing.Size(100, 20);
            this.digI3.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(433, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 20);
            this.textBox1.TabIndex = 7;
            // 
            // AnalogButton
            // 
            this.AnalogButton.Location = new System.Drawing.Point(12, 221);
            this.AnalogButton.Name = "AnalogButton";
            this.AnalogButton.Size = new System.Drawing.Size(121, 25);
            this.AnalogButton.TabIndex = 8;
            this.AnalogButton.Text = "Get Analog Sample";
            this.AnalogButton.UseVisualStyleBackColor = true;
            this.AnalogButton.Click += new System.EventHandler(this.AnalogButton_Click);
            // 
            // AnalogChannelsSelect
            // 
            this.AnalogChannelsSelect.DropDownHeight = 150;
            this.AnalogChannelsSelect.FormattingEnabled = true;
            this.AnalogChannelsSelect.IntegralHeight = false;
            this.AnalogChannelsSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.AnalogChannelsSelect.Location = new System.Drawing.Point(12, 270);
            this.AnalogChannelsSelect.Name = "AnalogChannelsSelect";
            this.AnalogChannelsSelect.Size = new System.Drawing.Size(73, 21);
            this.AnalogChannelsSelect.TabIndex = 9;
            this.AnalogChannelsSelect.SelectedIndexChanged += new System.EventHandler(this.AnalogChannelsSelect_SelectedIndexChanged);
            // 
            // RelistPorts
            // 
            this.RelistPorts.Location = new System.Drawing.Point(139, 12);
            this.RelistPorts.Name = "RelistPorts";
            this.RelistPorts.Size = new System.Drawing.Size(69, 23);
            this.RelistPorts.TabIndex = 14;
            this.RelistPorts.Text = "Relist Ports";
            this.RelistPorts.UseVisualStyleBackColor = true;
            this.RelistPorts.Click += new System.EventHandler(this.RelistPorts_Click);
            // 
            // digO1
            // 
            this.digO1.Location = new System.Drawing.Point(286, 104);
            this.digO1.Name = "digO1";
            this.digO1.Size = new System.Drawing.Size(92, 20);
            this.digO1.TabIndex = 15;
            // 
            // digO2
            // 
            this.digO2.Location = new System.Drawing.Point(286, 130);
            this.digO2.Name = "digO2";
            this.digO2.Size = new System.Drawing.Size(92, 20);
            this.digO2.TabIndex = 16;
            // 
            // digO3
            // 
            this.digO3.Location = new System.Drawing.Point(286, 156);
            this.digO3.Name = "digO3";
            this.digO3.Size = new System.Drawing.Size(92, 20);
            this.digO3.TabIndex = 17;
            // 
            // dout1
            // 
            this.dout1.AutoSize = true;
            this.dout1.Location = new System.Drawing.Point(384, 107);
            this.dout1.Name = "dout1";
            this.dout1.Size = new System.Drawing.Size(63, 17);
            this.dout1.TabIndex = 18;
            this.dout1.Text = "DOUT1";
            this.dout1.UseVisualStyleBackColor = true;
            this.dout1.CheckedChanged += new System.EventHandler(this.dout1_CheckedChanged);
            // 
            // dout2
            // 
            this.dout2.AutoSize = true;
            this.dout2.Location = new System.Drawing.Point(384, 134);
            this.dout2.Name = "dout2";
            this.dout2.Size = new System.Drawing.Size(63, 17);
            this.dout2.TabIndex = 19;
            this.dout2.Text = "DOUT2";
            this.dout2.UseVisualStyleBackColor = true;
            this.dout2.CheckedChanged += new System.EventHandler(this.dout2_CheckedChanged);
            // 
            // dout3
            // 
            this.dout3.AutoSize = true;
            this.dout3.Location = new System.Drawing.Point(384, 161);
            this.dout3.Name = "dout3";
            this.dout3.Size = new System.Drawing.Size(63, 17);
            this.dout3.TabIndex = 20;
            this.dout3.Text = "DOUT3";
            this.dout3.UseVisualStyleBackColor = true;
            this.dout3.CheckedChanged += new System.EventHandler(this.dout3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 22);
            this.button1.TabIndex = 22;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Close_button
            // 
            this.Close_button.Location = new System.Drawing.Point(606, 12);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(44, 22);
            this.Close_button.TabIndex = 23;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RunBox
            // 
            this.RunBox.AutoSize = true;
            this.RunBox.Location = new System.Drawing.Point(369, 16);
            this.RunBox.Name = "RunBox";
            this.RunBox.Size = new System.Drawing.Size(101, 17);
            this.RunBox.TabIndex = 24;
            this.RunBox.Text = "Run at rate (ms)";
            this.RunBox.UseVisualStyleBackColor = true;
            this.RunBox.CheckedChanged += new System.EventHandler(this.RunBox_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // RateBox
            // 
            this.RateBox.Location = new System.Drawing.Point(466, 14);
            this.RateBox.Name = "RateBox";
            this.RateBox.Size = new System.Drawing.Size(79, 20);
            this.RateBox.TabIndex = 25;
            this.RateBox.TextChanged += new System.EventHandler(this.RateBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Sample Count";
            // 
            // dcountLabel
            // 
            this.dcountLabel.AutoSize = true;
            this.dcountLabel.Location = new System.Drawing.Point(13, 146);
            this.dcountLabel.Name = "dcountLabel";
            this.dcountLabel.Size = new System.Drawing.Size(13, 13);
            this.dcountLabel.TabIndex = 33;
            this.dcountLabel.Text = "0";
            // 
            // acountLabel
            // 
            this.acountLabel.AutoSize = true;
            this.acountLabel.Location = new System.Drawing.Point(10, 356);
            this.acountLabel.Name = "acountLabel";
            this.acountLabel.Size = new System.Drawing.Size(13, 13);
            this.acountLabel.TabIndex = 35;
            this.acountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Sample Count";
            // 
            // checkBoxD
            // 
            this.checkBoxD.AutoSize = true;
            this.checkBoxD.Checked = true;
            this.checkBoxD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxD.Location = new System.Drawing.Point(17, 163);
            this.checkBoxD.Name = "checkBoxD";
            this.checkBoxD.Size = new System.Drawing.Size(76, 17);
            this.checkBoxD.TabIndex = 36;
            this.checkBoxD.TabStop = false;
            this.checkBoxD.Text = "Log Digital";
            this.checkBoxD.UseVisualStyleBackColor = true;
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Checked = true;
            this.checkBoxA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxA.Location = new System.Drawing.Point(12, 372);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(80, 17);
            this.checkBoxA.TabIndex = 37;
            this.checkBoxA.Text = "Log Analog";
            this.checkBoxA.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "Data";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(12, 192);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(639, 23);
            this.FileButton.TabIndex = 38;
            this.FileButton.Text = "File";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // SaveDataCheckbox
            // 
            this.SaveDataCheckbox.AutoSize = true;
            this.SaveDataCheckbox.Location = new System.Drawing.Point(496, 108);
            this.SaveDataCheckbox.Name = "SaveDataCheckbox";
            this.SaveDataCheckbox.Size = new System.Drawing.Size(86, 17);
            this.SaveDataCheckbox.TabIndex = 39;
            this.SaveDataCheckbox.Text = "Save To File";
            this.SaveDataCheckbox.UseVisualStyleBackColor = true;
            this.SaveDataCheckbox.CheckedChanged += new System.EventHandler(this.SaveDataCheckbox_CheckedChanged);
            // 
            // countsLabel
            // 
            this.countsLabel.AutoSize = true;
            this.countsLabel.Location = new System.Drawing.Point(183, 237);
            this.countsLabel.Name = "countsLabel";
            this.countsLabel.Size = new System.Drawing.Size(40, 13);
            this.countsLabel.TabIndex = 51;
            this.countsLabel.Text = "Counts";
            // 
            // VoltsLabel
            // 
            this.VoltsLabel.AutoSize = true;
            this.VoltsLabel.Location = new System.Drawing.Point(253, 237);
            this.VoltsLabel.Name = "VoltsLabel";
            this.VoltsLabel.Size = new System.Drawing.Size(30, 13);
            this.VoltsLabel.TabIndex = 52;
            this.VoltsLabel.Text = "Volts";
            // 
            // LogVolts
            // 
            this.LogVolts.AutoSize = true;
            this.LogVolts.Checked = true;
            this.LogVolts.Location = new System.Drawing.Point(496, 128);
            this.LogVolts.Name = "LogVolts";
            this.LogVolts.Size = new System.Drawing.Size(69, 17);
            this.LogVolts.TabIndex = 53;
            this.LogVolts.TabStop = true;
            this.LogVolts.Text = "Log Volts";
            this.LogVolts.UseVisualStyleBackColor = true;
            // 
            // LogCounts
            // 
            this.LogCounts.AutoSize = true;
            this.LogCounts.Location = new System.Drawing.Point(496, 146);
            this.LogCounts.Name = "LogCounts";
            this.LogCounts.Size = new System.Drawing.Size(79, 17);
            this.LogCounts.TabIndex = 54;
            this.LogCounts.Text = "Log Counts";
            this.LogCounts.UseVisualStyleBackColor = true;
            // 
            // PowerPortBox
            // 
            this.PowerPortBox.AutoSize = true;
            this.PowerPortBox.Location = new System.Drawing.Point(214, 16);
            this.PowerPortBox.Name = "PowerPortBox";
            this.PowerPortBox.Size = new System.Drawing.Size(139, 17);
            this.PowerPortBox.TabIndex = 55;
            this.PowerPortBox.Text = "Power Module from Port";
            this.PowerPortBox.UseVisualStyleBackColor = true;
            this.PowerPortBox.CheckedChanged += new System.EventHandler(this.PowerPortBox_CheckedChanged);
            // 
            // ScopeButton
            // 
            this.ScopeButton.Location = new System.Drawing.Point(10, 401);
            this.ScopeButton.Name = "ScopeButton";
            this.ScopeButton.Size = new System.Drawing.Size(75, 23);
            this.ScopeButton.TabIndex = 67;
            this.ScopeButton.Text = "Scope";
            this.ScopeButton.UseVisualStyleBackColor = true;
            this.ScopeButton.Click += new System.EventHandler(this.ScopeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Digital Input";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Digital Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Channel 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Channel 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Channel 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Channel 3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(118, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Channel 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Channel 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(118, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Channel 6";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Channel 5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(118, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 76;
            this.label13.Text = "Channel 4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(118, 464);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 81;
            this.label14.Text = "Channel 9";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(118, 438);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "Channel 8";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(118, 412);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 79;
            this.label16.Text = "Channel 7";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(118, 516);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 83;
            this.label18.Text = "Channel 11";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(118, 490);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 82;
            this.label19.Text = "Channel 10";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(92, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 84;
            this.label17.Text = "Bytes Recieved";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(430, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 85;
            this.label20.Text = "Module Response";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(66, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 13);
            this.label21.TabIndex = 86;
            this.label21.Text = "Data";
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(606, 37);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(44, 22);
            this.AboutButton.TabIndex = 87;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(555, 37);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(44, 22);
            this.Savebutton.TabIndex = 88;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 254);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 13);
            this.label22.TabIndex = 89;
            this.label22.Text = "# Analog Channels";
            // 
            // LogEUnits
            // 
            this.LogEUnits.AutoSize = true;
            this.LogEUnits.Location = new System.Drawing.Point(496, 163);
            this.LogEUnits.Name = "LogEUnits";
            this.LogEUnits.Size = new System.Drawing.Size(129, 17);
            this.LogEUnits.TabIndex = 101;
            this.LogEUnits.Text = "Log Engineering Units";
            this.LogEUnits.UseVisualStyleBackColor = true;
            // 
            // DefMaps
            // 
            this.DefMaps.Location = new System.Drawing.Point(10, 430);
            this.DefMaps.Name = "DefMaps";
            this.DefMaps.Size = new System.Drawing.Size(75, 23);
            this.DefMaps.TabIndex = 113;
            this.DefMaps.Text = "Define Maps";
            this.DefMaps.UseVisualStyleBackColor = true;
            this.DefMaps.Click += new System.EventHandler(this.DefMaps_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 544);
            this.Controls.Add(this.DefMaps);
            this.Controls.Add(this.LogEUnits);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ScopeButton);
            this.Controls.Add(this.PowerPortBox);
            this.Controls.Add(this.LogCounts);
            this.Controls.Add(this.LogVolts);
            this.Controls.Add(this.VoltsLabel);
            this.Controls.Add(this.countsLabel);
            this.Controls.Add(this.SaveDataCheckbox);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.checkBoxA);
            this.Controls.Add(this.checkBoxD);
            this.Controls.Add(this.acountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dcountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RateBox);
            this.Controls.Add(this.RunBox);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dout3);
            this.Controls.Add(this.dout2);
            this.Controls.Add(this.dout1);
            this.Controls.Add(this.digO3);
            this.Controls.Add(this.digO2);
            this.Controls.Add(this.digO1);
            this.Controls.Add(this.RelistPorts);
            this.Controls.Add(this.AnalogChannelsSelect);
            this.Controls.Add(this.AnalogButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.digI3);
            this.Controls.Add(this.digI2);
            this.Controls.Add(this.digI1);
            this.Controls.Add(this.DigitalResponse);
            this.Controls.Add(this.GetDigital);
            this.Controls.Add(this.responsebox);
            this.Controls.Add(this.ComPortSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RS232 Data Logger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComPortSelect;
        private System.Windows.Forms.TextBox responsebox;
        private System.Windows.Forms.Button GetDigital;
        private System.Windows.Forms.TextBox DigitalResponse;
        private System.Windows.Forms.TextBox digI1;
        private System.Windows.Forms.TextBox digI2;
        private System.Windows.Forms.TextBox digI3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AnalogButton;
        private System.Windows.Forms.ComboBox AnalogChannelsSelect;
        private System.Windows.Forms.Button RelistPorts;
        private System.Windows.Forms.TextBox digO1;
        private System.Windows.Forms.TextBox digO2;
        private System.Windows.Forms.TextBox digO3;
        private System.Windows.Forms.CheckBox dout1;
        private System.Windows.Forms.CheckBox dout2;
        private System.Windows.Forms.CheckBox dout3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox RunBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox RateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dcountLabel;
        private System.Windows.Forms.Label acountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxD;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.CheckBox SaveDataCheckbox;
        private System.Windows.Forms.Label countsLabel;
        private System.Windows.Forms.Label VoltsLabel;
        private System.Windows.Forms.RadioButton LogCounts;
        private System.Windows.Forms.CheckBox PowerPortBox;
        private System.Windows.Forms.Button ScopeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton LogEUnits;
        private System.Windows.Forms.Button DefMaps;
        public System.Windows.Forms.RadioButton LogVolts;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

