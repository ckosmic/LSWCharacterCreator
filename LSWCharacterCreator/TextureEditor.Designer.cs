namespace LSWCharacterCreator
{
	partial class TextureEditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureEditor));
			this.panel1 = new System.Windows.Forms.Panel();
			this.imgDetailsPanel = new System.Windows.Forms.Panel();
			this.imgDetails = new System.Windows.Forms.Label();
			this.texImg = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.imgDetailsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.texImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.imgDetailsPanel);
			this.panel1.Location = new System.Drawing.Point(15, 101);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 256);
			this.panel1.TabIndex = 0;
			// 
			// imgDetailsPanel
			// 
			this.imgDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgDetailsPanel.Controls.Add(this.imgDetails);
			this.imgDetailsPanel.Controls.Add(this.texImg);
			this.imgDetailsPanel.Location = new System.Drawing.Point(4, 4);
			this.imgDetailsPanel.Name = "imgDetailsPanel";
			this.imgDetailsPanel.Size = new System.Drawing.Size(250, 61);
			this.imgDetailsPanel.TabIndex = 0;
			// 
			// imgDetails
			// 
			this.imgDetails.AutoSize = true;
			this.imgDetails.Location = new System.Drawing.Point(61, 15);
			this.imgDetails.Name = "imgDetails";
			this.imgDetails.Size = new System.Drawing.Size(108, 26);
			this.imgDetails.TabIndex = 1;
			this.imgDetails.Text = "Texture 0\r\nDimensions: 256x256";
			// 
			// texImg
			// 
			this.texImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.texImg.Location = new System.Drawing.Point(4, 4);
			this.texImg.Name = "texImg";
			this.texImg.Size = new System.Drawing.Size(50, 50);
			this.texImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.texImg.TabIndex = 0;
			this.texImg.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Character Textures";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(315, 101);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 256);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(312, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Preview";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(586, 246);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(147, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Extract .DDS File...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(749, 246);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(147, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Replace .DDS File...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(587, 101);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(309, 77);
			this.panel2.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(227, 52);
			this.label3.TabIndex = 1;
			this.label3.Text = "File name: ICON____________ICON_PC.GSC\r\nDimensions: 256x256\r\nDDS file size: 86KB\r" +
    "\nMipmap count: 8";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(584, 82);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Texture Information";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(600, 198);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(283, 39);
			this.label5.TabIndex = 9;
			this.label5.Text = "Note: When replacing a .DDS file, please keep in mind the\r\ntexture\'s format, dime" +
    "nsions, mipmaps, and filesize. They\r\nshould remain the same as the original.\r\n";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(821, 338);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 0;
			this.button3.Text = "Done";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "DirectDraw Surface Files|*.dds";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "DirectDraw Surface Files|*.dds";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(15, 39);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(175, 21);
			this.comboBox1.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Selected Model";
			// 
			// TextureEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 373);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TextureEditor";
			this.Text = "Texture Editor";
			this.panel1.ResumeLayout(false);
			this.imgDetailsPanel.ResumeLayout(false);
			this.imgDetailsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.texImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel imgDetailsPanel;
		private System.Windows.Forms.Label imgDetails;
		private System.Windows.Forms.PictureBox texImg;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label6;
	}
}