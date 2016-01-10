namespace SDADatalogger
{
    partial class DefineMaps
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
            this.ChannelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MapDataBox = new System.Windows.Forms.TextBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FileLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Store = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SlopeBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Build = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OffsetBox = new System.Windows.Forms.TextBox();
            this.ClipButton = new System.Windows.Forms.Button();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelBox
            // 
            this.ChannelBox.FormattingEnabled = true;
            this.ChannelBox.Items.AddRange(new object[] {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 10",
            "Channel 11"});
            this.ChannelBox.Location = new System.Drawing.Point(3, 50);
            this.ChannelBox.MaxDropDownItems = 11;
            this.ChannelBox.Name = "ChannelBox";
            this.ChannelBox.Size = new System.Drawing.Size(121, 21);
            this.ChannelBox.TabIndex = 0;
            this.ChannelBox.SelectedIndexChanged += new System.EventHandler(this.ChannelBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Channel to Define";
            // 
            // MapDataBox
            // 
            this.MapDataBox.Location = new System.Drawing.Point(142, 50);
            this.MapDataBox.Multiline = true;
            this.MapDataBox.Name = "MapDataBox";
            this.MapDataBox.Size = new System.Drawing.Size(158, 21);
            this.MapDataBox.TabIndex = 3;
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(3, 78);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(40, 13);
            this.LengthLabel.TabIndex = 4;
            this.LengthLabel.Text = "Length";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 382);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(118, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save Map File";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Location = new System.Drawing.Point(3, 0);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(23, 13);
            this.FileLabel.TabIndex = 6;
            this.FileLabel.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Units";
            // 
            // Store
            // 
            this.Store.Location = new System.Drawing.Point(3, 353);
            this.Store.Name = "Store";
            this.Store.Size = new System.Drawing.Size(118, 23);
            this.Store.TabIndex = 8;
            this.Store.Text = "Store Data";
            this.Store.UseVisualStyleBackColor = true;
            this.Store.Click += new System.EventHandler(this.Store_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(3, 324);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(118, 23);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete Map";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // SlopeBox
            // 
            this.SlopeBox.Location = new System.Drawing.Point(2, 34);
            this.SlopeBox.Name = "SlopeBox";
            this.SlopeBox.Size = new System.Drawing.Size(100, 20);
            this.SlopeBox.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Controls.Add(this.Build);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.OffsetBox);
            this.groupBox1.Controls.Add(this.SlopeBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 130);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Builder";
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(9, 99);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(75, 23);
            this.Build.TabIndex = 14;
            this.Build.Text = "Build";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Slope";
            // 
            // OffsetBox
            // 
            this.OffsetBox.Location = new System.Drawing.Point(2, 72);
            this.OffsetBox.Name = "OffsetBox";
            this.OffsetBox.Size = new System.Drawing.Size(100, 20);
            this.OffsetBox.TabIndex = 12;
            // 
            // ClipButton
            // 
            this.ClipButton.Location = new System.Drawing.Point(3, 295);
            this.ClipButton.Name = "ClipButton";
            this.ClipButton.Size = new System.Drawing.Size(118, 23);
            this.ClipButton.TabIndex = 12;
            this.ClipButton.Text = "Paste From Clipboard";
            this.ClipButton.UseVisualStyleBackColor = true;
            this.ClipButton.Click += new System.EventHandler(this.ClipButton_Click);
            // 
            // ResponseLabel
            // 
            this.ResponseLabel.AutoSize = true;
            this.ResponseLabel.Location = new System.Drawing.Point(4, 412);
            this.ResponseLabel.Name = "ResponseLabel";
            this.ResponseLabel.Size = new System.Drawing.Size(0, 13);
            this.ResponseLabel.TabIndex = 13;
            // 
            // DefineMaps
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 433);
            this.Controls.Add(this.ResponseLabel);
            this.Controls.Add(this.ClipButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Store);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.MapDataBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChannelBox);
            this.Name = "DefineMaps";
            this.Text = "DefineMaps";
            this.Load += new System.EventHandler(this.DefineMaps_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ChannelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MapDataBox;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Store;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox SlopeBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OffsetBox;
        private System.Windows.Forms.Button ClipButton;
        private System.Windows.Forms.Label ResponseLabel;
    }
}