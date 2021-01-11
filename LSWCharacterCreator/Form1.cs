using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public partial class Form1 : Form
	{
		private List<string> ghgFiles;
		private AnimationEditor animEditor;
		private IconEditor iconEditor;
		private TextureEditor texEditor;
		private SoundEditor soundEditor;
		private ConsoleForm consoleForm;

		public Form1() {
			InitializeComponent();
			Initialize();
			AddEvents();
		}

		public void Initialize() {
			Program.Initialize();

			if (Properties.Settings.Default.lswDir.Length > 0) {
				InitializeGhgDropdown();
			}
			InitializePropertiesPanel();
			panel1.Hide();

			if (Properties.Settings.Default.lswDir.Length == 0) {
				SettingsForm settingsForm = new SettingsForm();
				settingsForm.Show();
			}

			KeyPreview = true;
			label4.Parent = this;

			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			StartPosition = FormStartPosition.CenterScreen;

			editCharacterFileToolStripMenuItem.Enabled = false;
			previewInNoesisToolStripMenuItem.Enabled = false;


			/*string[] txtFiles = Directory.GetFiles(Program.paths.PATH_CHAR, "*.TXT", SearchOption.AllDirectories);
			string output = "";
			for (int i = 0; i < txtFiles.Length; i++) {
				using (StreamReader sr = new StreamReader(txtFiles[i])) {
					string line = "";
					while ((line = sr.ReadLine()) != null) {
						string[] parts = line.Split('=');
						if (parts[0] == "variant") {
							output += parts[1] + "\n";
						}
					}
				}
			}

			File.WriteAllText(@"C:\Users\ckosmic\Desktop\variants.txt", output);*/
		}

		public void AddEvents() {
			KeyDown += Form1_KeyDown;

			FormClosing += Form1_FormClosing;
			DoubleClick += Form1_DoubleClick;

			textBox1.KeyPress += TextBox1_KeyPress;
		}

		private void Form1_DoubleClick(object sender, EventArgs e) {
			openToolStripMenuItem_Click(sender, null);
		}

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Return) {
				button7_Click(button7, null);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			if (Program.dirty) {
				DialogResult result = MessageBox.Show("Are you sure you want to exit? All unsaved changes will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.No) {
					e.Cancel = true;
				}
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.S) {
				e.SuppressKeyPress = true;
				Program.SaveCharacter();
			}
		}

		private void InitializePropertiesPanel() {
			string allProps = Properties.Resources.AllProperties;
			using (StringReader sr = new StringReader(allProps)) {
				string line;
				int y = 10;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0 && line.Substring(0, 2) != "//") {
						string[] parts = line.Split('|');
						switch (parts[2]) {
							case "bool":
								CheckBox cb = new CheckBox();
								cb.Text = parts[1];
								cb.Name = parts[0];
								cb.Location = new Point(10, y);
								cb.Size = new Size(200, cb.Size.Height);
								cb.CheckedChanged += Cb_CheckedChanged;

								panel2.Controls.Add(cb);
								y += 30;
								break;
							case "string":
								Label tl = new Label();
								tl.Text = parts[1];
								tl.Location = new Point(10, y);
								tl.Size = new Size(200, 20);

								TextBox tb = new TextBox();
								tb.Name = parts[0];
								tb.Location = new Point(10, y + 20);
								tb.Size = new Size(200, tb.Size.Height);
								tb.KeyPress += Tb_KeyPress;
								tb.LostFocus += Tb_LostFocus;
								tb.GotFocus += Tb_GotFocus;

								panel2.Controls.Add(tl);
								panel2.Controls.Add(tb);
								y += 50;
								break;
							case "dropdown":
								Label dl = new Label();
								dl.Text = parts[1];
								dl.Location = new Point(10, y);
								dl.Size = new Size(200, 20);

								ComboBox dd = new ComboBox();
								dd.Name = parts[0];
								dd.Location = new Point(10, y + 20);
								dd.Size = new Size(200, dd.Size.Height);
								dd.Items.Add("[Unassigned]");
								string[] itemNames = parts[3].Split(',');
								for (int i = 0; i < itemNames.Length; i++) {
									dd.Items.Add(itemNames[i]);
								}
								dd.SelectedIndex = 0;
								dd.DropDownStyle = ComboBoxStyle.DropDownList;
								dd.SelectedIndexChanged += Dd_SelectedIndexChanged;

								panel2.Controls.Add(dl);
								panel2.Controls.Add(dd);
								y += 50;
								break;
						}
					}
				}
			}
		}

		private void Tb_GotFocus(object sender, EventArgs e) {
			TextBox tb = (TextBox)sender;
			tb.Tag = tb.Text;
		}

		private void Dd_SelectedIndexChanged(object sender, EventArgs e) {
			ComboBox dd = (ComboBox)sender;
			Program.character.SetStringProperty(dd.Name, ((string)dd.SelectedItem) == "[Unassigned]" ? "" : ((string)dd.SelectedItem));
			Program.SetDirty(true);
		}

		private void Tb_LostFocus(object sender, EventArgs e) {
			TextBox tb = (TextBox)sender;

			if (tb.Text != (string)tb.Tag) {
				if (tb.Name == "name_id" && tb.Text.Length > 0) {
					Program.formalName = Program.GetFormalNameById(int.Parse(tb.Text));
					if (Program.formalName.Length == 0) {
						label1.Text = "INVALID NAME!";
						MessageBox.Show("The name ID you specified is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else {
						label1.Text = Program.formalName;
					}
				}

				Program.character.SetStringProperty(tb.Name, tb.Text);
				Program.SetDirty(true);
			}
		}

		private void Tb_KeyPress(object sender, KeyPressEventArgs e) {
			TextBox tb = (TextBox)sender;
			if (e.KeyChar == (char)Keys.Return) {
				Tb_LostFocus(sender, null);
			}
		}

		private void Cb_CheckedChanged(object sender, EventArgs e) {
			CheckBox cb = (CheckBox)sender;
			Program.character.SetBoolProperty(cb.Name, cb.Checked);
			Program.SetDirty(true);
		}

		private void GetAllGhgFiles() {
			ghgFiles = new List<string>();
			string lswDir = Properties.Settings.Default.lswDir;
			string charDir = Path.Combine(lswDir, "CHARS");
			ghgFiles = Directory.GetFiles(charDir, "*PC.GHG", SearchOption.AllDirectories).ToList();
			for (int i = 0; i < ghgFiles.Count; i++) {
				if (Path.GetFileName(ghgFiles[i]).Contains("LR_PC.GHG"))
					ghgFiles.RemoveAt(i);
			}
		}

		private void InitializeGhgDropdown() {
			GetAllGhgFiles();
			comboBox1.Items.Clear();
			for (int i = 0; i < ghgFiles.Count; i++) {
				comboBox1.Items.Add(Path.GetFileName(ghgFiles[i]));
			}
		}

		public void PopulateInformation() {
			label1.Text = Program.formalName;
			Text = "LSW Character Creator - " + Program.formalName;
			foreach (Control c in panel2.Controls) {
				if (Program.character.Contains(c.Name)) {
					if (c.GetType() == typeof(CheckBox)) {
						((CheckBox)c).Checked = Program.character.GetBoolProperty(c.Name);
					} else if (c.GetType() == typeof(TextBox)) {
						((TextBox)c).Text = Program.character.GetStringProperty(c.Name);
					} else if (c.GetType() == typeof(ComboBox)) {
						ComboBox c2 = ((ComboBox)c);
						c2.SelectedIndex = c2.Items.IndexOf(Program.character.GetStringProperty(c.Name));
						if (c2.SelectedIndex < 0) c2.SelectedIndex = 0;
					}
				}
			}
			if (Program.ghgFile != "undefined") {
				int ddIndex = ghgFiles.IndexOf(Program.ghgFile);
				comboBox1.SelectedIndex = ddIndex;
			}
			panel1.Show();
			label4.Hide();
			editCharacterFileToolStripMenuItem.Enabled = true;
			previewInNoesisToolStripMenuItem.Enabled = true;
		}

		

		private void newCharacterToolStripMenuItem_Click(object sender, EventArgs e) {
			NewCharForm newCharForm = new NewCharForm();
			newCharForm.Show();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = ".TXT Files|*.txt";
			openFileDialog1.InitialDirectory = Properties.Settings.Default.openPath;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				Program.LoadCharacterFull(openFileDialog1.FileName);
				PopulateInformation();
				Properties.Settings.Default.openPath = Program.paths.PATH_CHARACTER;
				Properties.Settings.Default.Save();
				Program.SetDirty(false);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			Program.SaveCharacter();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.Show();
		}

		// Add .ghg button
		private void button1_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = ".GHG Files|*.ghg";
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				Program.AssignGhgFile(openFileDialog1.FileName, Program.ghgFile);
				InitializeGhgDropdown();
				PopulateInformation();
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			int index = comboBox1.SelectedIndex;
			if (Program.ghgFile != ghgFiles[index]) {
				DialogResult result = MessageBox.Show("Are you sure you want to change this value? The previous .GHG file will be overwritten.", "Confirm .GHG Change", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (result == DialogResult.Yes) {
					Program.AssignGhgFile(ghgFiles[index], Program.ghgFile);
					//MessageBox.Show("The previous .GHG file has successfully been replaced with the new one!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				} else if (result == DialogResult.No) {
					// TODO: revert combobox index
				}
			}
		}

		// Animation properties button
		private void button2_Click(object sender, EventArgs e) {
			animEditor = new AnimationEditor();
			animEditor.Show();
		}

		// Icon properties button
		private void button3_Click(object sender, EventArgs e) {
			iconEditor = new IconEditor();
			iconEditor.Show();
			string iconName = Program.character.GetStringProperty("icon");
			iconName = iconName.Substring(1, iconName.Length - 2).ToUpper();
			iconEditor.LoadIconFromGsc(Program.paths.PATH_STUFF + @"\ICONS\" + iconName + "_PC.GSC");
		}

		// Texture properties button
		private void button4_Click(object sender, EventArgs e) {
			texEditor = new TextureEditor();
			texEditor.Show();
			texEditor.LoadTexturesFromGhg(Program.ghgFile);
		}

		// Sound properties button
		private void button5_Click(object sender, EventArgs e) {
			soundEditor = new SoundEditor();
			soundEditor.Show();
		}

		// Edit name button
		private void button6_Click(object sender, EventArgs e) {
			textBox1.Text = Program.formalName;
			textBox1.Show();
			button7.Show();
			label1.Hide();
			button6.Hide();
		}

		// Done editing name button
		private void button7_Click(object sender, EventArgs e) {
			int nameId = int.Parse(Program.character.GetStringProperty("name_id"));
			Program.SetFormalNameById(nameId, textBox1.Text);
			Program.formalName = Program.GetFormalNameById(nameId);
			Program.SetDirty(true);
			label1.Text = Program.formalName;
			textBox1.Hide();
			button7.Hide();
			label1.Show();
			button6.Show();
		}

		private void editCharacterFileToolStripMenuItem_Click(object sender, EventArgs e) {
			Process.Start(Program.paths.PATH_CHARACTER_TXT);
		}

		// Errors button
		private void button8_Click(object sender, EventArgs e) {
			Program.CheckForErrors();
			consoleForm = new ConsoleForm();
			consoleForm.Show();
		}

		private void button9_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.exeMethod == "steam")
				Process.Start("steam://rungameid/32440");
			else if(Properties.Settings.Default.exeMethod == "direct")
				Process.Start(Properties.Settings.Default.lswDir + @"\LEGOStarWarsSaga.exe");
		}

		private void previewInNoesisToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!File.Exists(Properties.Settings.Default.noesisExePath)) {
				openFileDialog2.InitialDirectory = Properties.Settings.Default.noesisPath;
				openFileDialog2.Title = "Open Noesis.exe";
				if (openFileDialog2.ShowDialog() == DialogResult.OK) {
					Properties.Settings.Default.noesisPath = Path.GetDirectoryName(openFileDialog2.FileName);
					Properties.Settings.Default.noesisExePath = openFileDialog2.FileName;
					Properties.Settings.Default.Save();
				}
			}
			Process proc = new Process();
			proc.StartInfo.FileName = Properties.Settings.Default.noesisExePath;
			proc.StartInfo.Arguments = "\"" + Program.ghgFile + "\"";
			proc.Start();
		}
	}
}
