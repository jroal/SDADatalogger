namespace SDADatalogger
{
    partial class Gauge
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.sizer = new System.Windows.Forms.Button();
            this.ticksBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinReadLabel = new System.Windows.Forms.Label();
            this.MaxReadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(55, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(40, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(5, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(44, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // sizer
            // 
            this.sizer.Location = new System.Drawing.Point(343, 2);
            this.sizer.Name = "sizer";
            this.sizer.Size = new System.Drawing.Size(44, 23);
            this.sizer.TabIndex = 3;
            this.sizer.Text = "Small";
            this.sizer.UseVisualStyleBackColor = true;
            this.sizer.Click += new System.EventHandler(this.sizer_Click);
            // 
            // ticksBox
            // 
            this.ticksBox.Location = new System.Drawing.Point(5, 32);
            this.ticksBox.Name = "ticksBox";
            this.ticksBox.Size = new System.Drawing.Size(28, 20);
            this.ticksBox.TabIndex = 4;
            this.ticksBox.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(5, 255);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(24, 13);
            this.MinLabel.TabIndex = 6;
            this.MinLabel.Text = "Min";
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(327, 255);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(27, 13);
            this.MaxLabel.TabIndex = 7;
            this.MaxLabel.Text = "Max";
            // 
            // MinReadLabel
            // 
            this.MinReadLabel.AutoSize = true;
            this.MinReadLabel.Location = new System.Drawing.Point(122, 133);
            this.MinReadLabel.Name = "MinReadLabel";
            this.MinReadLabel.Size = new System.Drawing.Size(50, 13);
            this.MinReadLabel.TabIndex = 8;
            this.MinReadLabel.Text = "MinRead";
            // 
            // MaxReadLabel
            // 
            this.MaxReadLabel.AutoSize = true;
            this.MaxReadLabel.Location = new System.Drawing.Point(122, 156);
            this.MaxReadLabel.Name = "MaxReadLabel";
            this.MaxReadLabel.Size = new System.Drawing.Size(53, 13);
            this.MaxReadLabel.TabIndex = 9;
            this.MaxReadLabel.Text = "MaxRead";
            // 
            // Gauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.ControlBox = false;
            this.Controls.Add(this.MaxReadLabel);
            this.Controls.Add(this.MinReadLabel);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ticksBox);
            this.Controls.Add(this.sizer);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 190);
            this.Name = "Gauge";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Graph_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button sizer;
        private System.Windows.Forms.TextBox ticksBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label MinLabel;
        public System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinReadLabel;
        private System.Windows.Forms.Label MaxReadLabel;



    }
}