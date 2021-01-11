namespace LSWCharacterCreator
{
	partial class SoundEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundEditor));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(13, 13);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(328, 455);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(366, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(422, 91);
			this.panel1.TabIndex = 1;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(18, 50);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(383, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "Preview";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(247, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name: Ana_Hurt3\r\nPath: AUDIO\\_SOUNDFX\\ANAKIN\\ANA_HURT3";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(363, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Sound Information";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Saber Sound",
            "Chatter Sound",
            "Footstep Sound",
            "Grunt Sound",
            "Hurt Sound",
            "Death Sound",
            "Shoot Sound",
            "Misc Sound 1",
            "Misc Sound 2",
            "Misc Sound 3",
            "Misc Sound 4",
            "Misc Sound 5",
            "Misc Sound 6",
            "Misc Sound 7",
            "Misc Sound 8"});
			this.comboBox1.Location = new System.Drawing.Point(366, 381);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(589, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Replace Sound";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(366, 146);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(422, 228);
			this.panel2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 195);
			this.label3.TabIndex = 0;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(363, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Character Sound Effects";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(714, 445);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(589, 409);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(200, 23);
			this.button4.TabIndex = 2;
			this.button4.Text = "Preview";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(552, 445);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "Apply";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(633, 445);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 8;
			this.button6.Text = "Save";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// SoundEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 480);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.treeView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SoundEditor";
			this.Text = "Sound Properties";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
	}
}