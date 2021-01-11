namespace LSWCharacterCreator
{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 45);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(223, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "\"Lego Star Wars Saga\" Directory";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(242, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 22);
			this.button1.TabIndex = 2;
			this.button1.Text = "Browse...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(386, 186);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 22);
			this.button2.TabIndex = 3;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Steam",
            "Directly from LEGOStarWarsSaga.exe"});
			this.comboBox1.Location = new System.Drawing.Point(13, 96);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(222, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Executable Opening Method";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(242, 149);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 22);
			this.button3.TabIndex = 8;
			this.button3.Text = "Browse...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Noesis Path";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 150);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(223, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Executable Files|*.exe";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 220);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsForm";
			this.Text = "Options";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}