using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public partial class SettingsForm : Form
	{
		public SettingsForm() {
			InitializeComponent();
			textBox1.Text = Properties.Settings.Default.lswDir;
			textBox2.Text = Properties.Settings.Default.noesisExePath;
			if (Properties.Settings.Default.exeMethod == "steam")
				comboBox1.SelectedIndex = 0;
			else if (Properties.Settings.Default.exeMethod == "direct")
				comboBox1.SelectedIndex = 1;
		}

		// Browse for LSW directory button
		private void button1_Click(object sender, EventArgs e) {
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
				textBox1.Text = folderBrowserDialog1.SelectedPath;
				Properties.Settings.Default.lswDir = folderBrowserDialog1.SelectedPath;
				Properties.Settings.Default.Save();
			}
		}

		// Done button
		private void button2_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			Properties.Settings.Default.lswDir = textBox1.Text;
			Properties.Settings.Default.Save();
			Program.mainForm.Initialize();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox1.SelectedIndex == 0) {
				Properties.Settings.Default.exeMethod = "steam";
			} else if (comboBox1.SelectedIndex == 1) {
				Properties.Settings.Default.exeMethod = "direct";
			}
			Properties.Settings.Default.Save();
		}

		private void button3_Click(object sender, EventArgs e) {
			openFileDialog1.InitialDirectory = Properties.Settings.Default.noesisPath;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				textBox2.Text = folderBrowserDialog1.SelectedPath;
				Properties.Settings.Default.noesisPath = Path.GetDirectoryName(openFileDialog1.FileName);
				Properties.Settings.Default.noesisExePath = openFileDialog1.FileName;
				Properties.Settings.Default.Save();
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e) {
			Properties.Settings.Default.noesisPath = Path.GetDirectoryName(textBox1.Text);
			Properties.Settings.Default.noesisExePath = textBox2.Text;
			Properties.Settings.Default.Save();
		}
	}
}
