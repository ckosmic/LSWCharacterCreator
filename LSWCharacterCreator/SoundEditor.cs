using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public partial class SoundEditor : Form
	{

		private List<Sound> sounds;
		private string[] categories = {
			"sfx_sabre",
			"sfx_chatter",
			"sfx_footstep",
			"sfx_grunt",
			"sfx_hurt",
			"sfx_die",
			"sfx_shoot",
			"sfx_misc0",
			"sfx_misc1",
			"sfx_misc2",
			"sfx_misc3",
			"sfx_misc4",
			"sfx_misc5",
			"sfx_misc6",
			"sfx_misc7",
		};
		private string[] replacedSounds;
		private Sound selectedSound;

		public SoundEditor() {
			InitializeComponent();

			ParseAudioConfig();
			PopulateTreeView();
			PopulateCharacterSfxInfo();
			replacedSounds = new string[categories.Length];
		}

		public void PopulateCharacterSfxInfo() {
			label3.Text = "Death Sound: " + Program.sounds.GetStringProperty("sfx_die").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nHurt Sound: " + Program.sounds.GetStringProperty("sfx_hurt").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nSaber Sound: " + Program.sounds.GetStringProperty("sfx_sabre").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nChatter Sound: " + Program.sounds.GetStringProperty("sfx_chatter").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nFootstep Sound: " + Program.sounds.GetStringProperty("sfx_footstep").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nGrunt Sound: " + Program.sounds.GetStringProperty("sfx_grunt").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nShoot Sound: " + Program.sounds.GetStringProperty("sfx_shoot").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 1: " + Program.sounds.GetStringProperty("sfx_misc0").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 2: " + Program.sounds.GetStringProperty("sfx_misc1").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 3: " + Program.sounds.GetStringProperty("sfx_misc2").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 4: " + Program.sounds.GetStringProperty("sfx_misc3").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 5: " + Program.sounds.GetStringProperty("sfx_misc4").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 6: " + Program.sounds.GetStringProperty("sfx_misc5").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 7: " + Program.sounds.GetStringProperty("sfx_misc6").Replace("_lswccUnassigned", "[Unassigned]") +
				"\nMisc Sound 8: " + Program.sounds.GetStringProperty("sfx_misc7").Replace("_lswccUnassigned", "[Unassigned]");
		}

		public void PopulateTreeView() {
			string root = Program.paths.PATH_AUDIO;
			treeView1.Nodes.Clear();
			DirectoryInfo info = new DirectoryInfo(root);
			treeView1.Nodes.Add(CreateTreeNode(info));
			treeView1.Nodes[0].Expand();
		}

		private TreeNode CreateTreeNode(DirectoryInfo info) {
			TreeNode node = new TreeNode(info.Name);
			foreach (DirectoryInfo dir in info.GetDirectories()) {
				if(dir.Name.ToUpper() != "_MUSIC" && dir.Name.ToUpper() != "_CUTSCENES")
					node.Nodes.Add(CreateTreeNode(dir));
			}
			foreach (FileInfo file in info.GetFiles()) {
				string path = file.FullName.Remove(file.FullName.IndexOf(Properties.Settings.Default.lswDir), Properties.Settings.Default.lswDir.Length);
				path = path.Substring(1, path.Length - 1);
				path = path.Replace(".WAV", "");
				if (GetSoundFromPath(path) != null)
					node.Nodes.Add(file.Name);
			}
			return node;
		}

		private string GetSelectedTreeNodePath() {
			return Path.GetDirectoryName(Program.paths.PATH_AUDIO) + @"\" + treeView1.SelectedNode.FullPath;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			string filePath = GetSelectedTreeNodePath();
			if (filePath != null && filePath.Length > 0) {
				if (Path.GetExtension(filePath) == ".WAV") {
					selectedSound = GetSoundFromPath(treeView1.SelectedNode.FullPath.Replace(".WAV", ""));
					if (selectedSound != null) {
						label2.Text = "Name: " + selectedSound.name + "\nPath: " + selectedSound.fname;


						SoundPlayer player = new SoundPlayer(filePath);
						player.Play();
					}
				}
			}
		}

		private void ParseAudioConfig() {
			sounds = new List<Sound>();
			using (StreamReader sr = new StreamReader(Program.paths.PATH_AUDIO + @"\AUDIO.CFG")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					string[] parts = line.Split(null);
					if (line.Length > 0 && line[0] != ';') {
						if (parts[0] == "Sample") {
							Sound sound = new Sound();
							sound.name = parts[Array.IndexOf(parts, "name") + 1];
							sound.fname = parts[Array.IndexOf(parts, "fname") + 1];
							if (sound.name.Length > 2 && sound.fname.Length > 2) {
								sound.name = sound.name.Replace("\"", "");
								sound.fname = sound.fname.Replace("\"", "");
								sounds.Add(sound);
							}
						}
					}
				}
			}
		}

		public Sound GetSound(string name) {
			return sounds.FirstOrDefault(o => o.name.ToUpper() == name.ToUpper());
		}

		public Sound GetSoundFromPath(string fname) {
			return sounds.FirstOrDefault(o => o.fname.ToUpper() == fname.ToUpper());
		}

		private void SaveSoundChanges() {
			for (int i = 0; i < categories.Length; i++) {
				if (replacedSounds[i] != null && replacedSounds[i].Length > 0) {
					Program.sounds.SetStringProperty(categories[i], replacedSounds[i].ToLower());
				}
			}
		}

		// Done button
		private void button2_Click(object sender, EventArgs e) {
			Close();
		}

		// Preview selected sound button
		private void button3_Click(object sender, EventArgs e) {
			string filePath = GetSelectedTreeNodePath();
			if (filePath != null && filePath.Length > 0) {
				if (Path.GetExtension(filePath) == ".WAV") {
					SoundPlayer player = new SoundPlayer(filePath);
					player.Play();
				}
			}
		}

		// Preview existing character sound button
		private void button4_Click(object sender, EventArgs e) {
			string soundName = Program.sounds.GetStringProperty(categories[comboBox1.SelectedIndex]);
			if (soundName == "_lswccUnassigned") {
				MessageBox.Show("Character does not have a " + comboBox1.SelectedItem.ToString().ToLower() + " assigned!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				Sound sound = GetSound(soundName);
				string filePath = Properties.Settings.Default.lswDir + @"\" + sound.fname + ".WAV";
				if (filePath != null && filePath.Length > 0) {
					if (Path.GetExtension(filePath) == ".WAV") {
						SoundPlayer player = new SoundPlayer(filePath);
						player.Play();
					}
				}
			}
		}

		// Replace sound button
		private void button1_Click(object sender, EventArgs e) {
			replacedSounds[comboBox1.SelectedIndex] = selectedSound.name;
		}

		// Apply button
		private void button5_Click(object sender, EventArgs e) {
			SaveSoundChanges();
			Program.SaveCharacter();
			PopulateCharacterSfxInfo();
		}

		// Save button
		private void button6_Click(object sender, EventArgs e) {
			SaveSoundChanges();
			Program.SaveCharacter();
			PopulateCharacterSfxInfo();
			Close();
		}
	}
}
