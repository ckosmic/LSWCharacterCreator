using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public partial class NewCharForm : Form
	{
		public NewCharForm() {
			InitializeComponent();
			textBox1.TextChanged += TextBox1_TextChanged;
		}

		private void TextBox1_TextChanged(object sender, EventArgs e) {
			label2.Text = "CHARS/" + Program.GetRealName(textBox1.Text);
		}

		// Cancel button
		private void button2_Click(object sender, EventArgs e) {
			Close();
		}

		// Create button
		private void button1_Click(object sender, EventArgs e) {
			Program.CreateNewCharacter(textBox1.Text);
			Close();
		}
	}
}
