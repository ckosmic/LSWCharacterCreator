namespace LSWCharacterCreator
{
	partial class IconEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconEditor));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 42);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 256);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Image = global::LSWCharacterCreator.Properties.Resources.ring;
			this.pictureBox2.Location = new System.Drawing.Point(12, 42);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(256, 256);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox3.Location = new System.Drawing.Point(225, 25);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(64, 64);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Character Icon";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(306, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Icon Properties";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(309, 42);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(404, 82);
			this.panel1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(227, 52);
			this.label3.TabIndex = 0;
			this.label3.Text = "File name: ICON____________ICON_PC.GSC\r\nDimensions: 256x256\r\nDDS file size: 86KB\r" +
    "\nMipmap count: 8";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(308, 189);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(193, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Extract .DDS File...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(521, 189);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(193, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Replace .DDS File...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(322, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(379, 26);
			this.label4.TabIndex = 8;
			this.label4.Text = "Note: When replacing a .DDS file, please keep in mind the texture\'s format,\r\ndime" +
    "nsions, mipmaps, and filesize. They should remain the same as the original.\r\n";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(638, 277);
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
			this.comboBox1.Location = new System.Drawing.Point(522, 220);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(110, 21);
			this.comboBox1.TabIndex = 9;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(638, 219);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(76, 23);
			this.button4.TabIndex = 10;
			this.button4.Text = "Apply";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(373, 223);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(143, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Copy from existing character:";
			// 
			// IconEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 312);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "IconEditor";
			this.Text = "Icon Editor";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label5;
	}
}