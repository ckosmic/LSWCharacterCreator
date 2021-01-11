namespace LSWCharacterCreator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editCharacterFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button8 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button9 = new System.Windows.Forms.Button();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previewInNoesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(538, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCharacterToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newCharacterToolStripMenuItem
			// 
			this.newCharacterToolStripMenuItem.Name = "newCharacterToolStripMenuItem";
			this.newCharacterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newCharacterToolStripMenuItem.Text = "New...";
			this.newCharacterToolStripMenuItem.Click += new System.EventHandler(this.newCharacterToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCharacterFileToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// editCharacterFileToolStripMenuItem
			// 
			this.editCharacterFileToolStripMenuItem.Enabled = false;
			this.editCharacterFileToolStripMenuItem.Name = "editCharacterFileToolStripMenuItem";
			this.editCharacterFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editCharacterFileToolStripMenuItem.Text = "Edit Character File...";
			this.editCharacterFileToolStripMenuItem.Click += new System.EventHandler(this.editCharacterFileToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.optionsToolStripMenuItem.Text = "Options...";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button9);
			this.panel1.Controls.Add(this.button8);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(539, 424);
			this.panel1.TabIndex = 1;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(17, 389);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(240, 23);
			this.button8.TabIndex = 14;
			this.button8.Text = "Errors: 0";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(153, 178);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(246, 39);
			this.label4.TabIndex = 13;
			this.label4.Text = "Welcome to LSW Character Creator!\r\nSelect \"File > New...\" to create a new charact" +
    "er or\r\n\"File > Open...\" to open an existing character.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(210, 14);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(47, 23);
			this.button7.TabIndex = 12;
			this.button7.Text = "Done";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Visible = false;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(17, 14);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(186, 20);
			this.textBox1.TabIndex = 11;
			this.textBox1.Visible = false;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(210, 13);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(47, 23);
			this.button6.TabIndex = 10;
			this.button6.Text = "Edit...";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(16, 123);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(241, 23);
			this.button5.TabIndex = 9;
			this.button5.Text = "Sound Properties...";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(16, 181);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(241, 23);
			this.button4.TabIndex = 8;
			this.button4.Text = "Character Textures...";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 152);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(241, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Character Icon...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 94);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(241, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Animation Properties...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(270, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Properties";
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(273, 30);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(248, 381);
			this.panel2.TabIndex = 4;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(489, 398);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(47, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Add...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Base .GHG file";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(17, 66);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(239, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "CHARNAME_LONGNAME";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(17, 360);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(240, 23);
			this.button9.TabIndex = 15;
			this.button9.Text = "Open LEGO Star Wars";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewInNoesisToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// previewInNoesisToolStripMenuItem
			// 
			this.previewInNoesisToolStripMenuItem.Enabled = false;
			this.previewInNoesisToolStripMenuItem.Name = "previewInNoesisToolStripMenuItem";
			this.previewInNoesisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.previewInNoesisToolStripMenuItem.Text = "Preview in Noesis...";
			this.previewInNoesisToolStripMenuItem.Click += new System.EventHandler(this.previewInNoesisToolStripMenuItem_Click);
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.FileName = "openFileDialog2";
			this.openFileDialog2.Filter = "Executable Files|*.exe";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(538, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "LSW Character Creator";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripMenuItem editCharacterFileToolStripMenuItem;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.Button button8;
		public System.Windows.Forms.Button button9;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previewInNoesisToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
	}
}

