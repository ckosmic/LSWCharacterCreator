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
	public partial class AnimationEditor : Form
	{
		private List<string> charNames;
		private List<string> charAnimations;
		private List<string> charAnimPaths;

		public AnimationEditor() {
			InitializeComponent();
		}

		private void PopulateCharacterDropdown() {
			charNames = new List<string>();
			string lswDir = Properties.Settings.Default.lswDir;
			string charDir = Path.Combine(lswDir, "CHARS");
			charNames = Directory.GetFiles(charDir, "*.TXT", SearchOption.AllDirectories).ToList();
			comboBox1.Items.Clear();
			string[] blacklist = { 
				"CHARS",
				"COLLECTION",
				"CUSTOMISER",
				"GHG",
				"HGO",
				"LRGHG",
				"SPECIALMOVES"
			};
			int removed = 0;
			//Dictionary<string, string> tmp = new Dictionary<string, string>();
			//string tmp2 = "";
			for (int i = 0; i < charNames.Count; i++) {
				string txtName = Path.GetFileNameWithoutExtension(charNames[i]);
				if (blacklist.Contains(txtName)) {
					charNames.RemoveAt(i);
					removed++;
					i--;
				} else {
					using (StreamReader sr = new StreamReader(charNames[i])) {
						string line;
						bool containsAnimations = false;
						while ((line = sr.ReadLine()) != null) {
							if (line.Length > 0) {
								string[] parts = line.Split('=');
								if (parts[0] == "anim_start") {
									containsAnimations = true;
									break;
								}
								/*if (!tmp.ContainsKey(parts[0])) {
									tmp.Add(parts[0], "");
									tmp2 += line + "\n";
								}*/
							}
						}
						if (!containsAnimations) {
							charNames.RemoveAt(i);
							removed++;
							i--;
							Console.WriteLine(txtName + " does not have animations!");
						}
					}
				}
			}
			//File.WriteAllText(@"C:\Users\ckosmic\Desktop\outptptpt.txt", tmp2);
			for (int i = 0; i < charNames.Count; i++) {
				string txtName = Path.GetFileNameWithoutExtension(charNames[i]);
				comboBox1.Items.Add(txtName);
			}
		}

		private void PopulateAnimationsDropdown() {
			charAnimations = new List<string>();
			charAnimPaths = new List<string>();
			comboBox2.Items.Clear();
			string charFile = charNames[comboBox1.SelectedIndex];

			Console.WriteLine(charFile);
			using (StreamReader sr = new StreamReader(charFile)) {
				string line;
				string animationBlock = "";
				bool isAnimation = false;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0) {
						string[] parts = line.Split('=');
						if (parts[0] == "anim_start") {
							isAnimation = true;
							comboBox2.Items.Add(parts[1].Substring(1, parts[1].Length - 2));
						}
						if (isAnimation) {
							animationBlock += line + "\r\n";
						}
						if (parts[0] == "anim_end") {
							isAnimation = false;
							charAnimations.Add(animationBlock);
							animationBlock = "";
						}
					}
				}
				if (comboBox2.Items.Count == 0) {
					MessageBox.Show("Character does not contain any animations!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			comboBox2.SelectedIndex = 0;

			charAnimPaths = Directory.GetFiles(Path.GetDirectoryName(charFile), "*.AN3").ToList();
		}

		private void AnimationEditor_Shown(object sender, EventArgs e) {
			textBox1.Text = Program.animations;
			PopulateCharacterDropdown();
		}

		// Save button
		private void button2_Click(object sender, EventArgs e) {
			Program.animations = textBox1.Text;
			Program.SaveCharacter();
			Close();
		}

		// Cancel button
		private void button3_Click(object sender, EventArgs e) {
			Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			PopulateAnimationsDropdown();
		}

		// Add Animation button
		private void button1_Click(object sender, EventArgs e) {
			textBox1.Text += "\r\n" + charAnimations[comboBox2.SelectedIndex];
			string newPath = Program.paths.PATH_CHARACTER + @"\" + ((string)comboBox2.SelectedItem).ToUpper() + ".AN3";
			Program.CopyAnimation(Path.GetDirectoryName(charNames[comboBox1.SelectedIndex]), (string)comboBox2.SelectedItem, newPath);
		}

		// Add All Animations button
		private void button4_Click(object sender, EventArgs e) {
			textBox1.Text += "\r\n" + string.Join("\r\n", charAnimations);
			for (int i = 0; i < comboBox2.Items.Count; i++) {
				string newPath = Program.paths.PATH_CHARACTER + @"\" + ((string)comboBox2.Items[i]).ToUpper() + ".AN3";
				Program.CopyAnimation(Path.GetDirectoryName(charNames[comboBox1.SelectedIndex]), (string)comboBox2.Items[i], newPath);
			}
		}

		private string[] ParseAnimNamesFromAnimProperties() {
			List<string> animNames = new List<string>();
			using (StringReader sr = new StringReader(textBox1.Text)) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					string[] parts = line.Split('=');
					if (parts[0] == "anim_start") {
						animNames.Add(parts[1].Substring(1, parts[1].Length - 2).ToUpper());
					}
				}
			}
			return animNames.ToArray();
		}

		// Delete unused animations button
		private void button5_Click(object sender, EventArgs e) {
			string[] animFiles = Directory.GetFiles(Program.paths.PATH_CHARACTER, "*.AN3");
			string[] bsaFiles = Directory.GetFiles(Program.paths.PATH_CHARACTER, "*.BSA");
			string[] animPropertiesNames = ParseAnimNamesFromAnimProperties();
			int animsDeleted = 0;
			int bsaDeleted = 0;
			for (int i = 0; i < animFiles.Length; i++) {
				if (!animPropertiesNames.Contains(Path.GetFileNameWithoutExtension(animFiles[i]).ToUpper())) {
					File.Delete(animFiles[i]);
					animsDeleted++;
				}
			}
			for (int i = 0; i < bsaFiles.Length; i++) {
				if (!animPropertiesNames.Contains(Path.GetFileNameWithoutExtension(bsaFiles[i]).ToUpper())) {
					File.Delete(bsaFiles[i]);
					bsaDeleted++;
				}
			}
			if (animsDeleted == 0 && bsaDeleted == 0) {
				MessageBox.Show("No leftover files to delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else {
				MessageBox.Show("Successfully cleaned up " + animsDeleted + " .AN3 file(s) and " + bsaDeleted + " .BSA file(s)!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Apply button
		private void button6_Click(object sender, EventArgs e) {
			Program.animations = textBox1.Text;
			Program.SaveCharacter();
		}
	}
}
