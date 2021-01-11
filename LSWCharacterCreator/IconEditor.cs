using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pfim.dds;

namespace LSWCharacterCreator
{
	public partial class IconEditor : Form
	{
		public GHGParameters ghg;
		public string currentIconPath;

		public IconEditor() {
			InitializeComponent();

			pictureBox2.Controls.Add(pictureBox1);
			pictureBox1.Location = new Point(0, 0);
			pictureBox1.BackColor = Color.Transparent;

			PopulateIconsDropdown();
		}

		private void PopulateIconsDropdown() {
			string root = Program.paths.PATH_STUFF + @"\ICONS";
			string[] iconFiles = Directory.GetFiles(root, "*.GSC");
			for (int i = 0; i < iconFiles.Length; i++) {
				string nameWithoutExtension = Path.GetFileNameWithoutExtension(iconFiles[i]);
				if(nameWithoutExtension != "STARWARS_ICONS_ALL_PC")
					comboBox1.Items.Add(nameWithoutExtension);
			}
		}

		public void LoadIconFromGsc(string path) {
			currentIconPath = path;
			GhgManager.LoadModel(path, out ghg);
			using (Stream s = new MemoryStream(ghg.texData[0])) {
				using (Pfim.IImage img = Pfim.Pfim.FromStream(s)) {
					GCHandle handle = GCHandle.Alloc(img.Data, GCHandleType.Pinned);
					IntPtr data = Marshal.UnsafeAddrOfPinnedArrayElement(img.Data, 0);
					Bitmap bitmap = new Bitmap(img.Width, img.Height, img.Stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, data);
					pictureBox1.Image = bitmap;
					pictureBox3.Image = bitmap;

					label3.Text = "File name: " + Path.GetFileName(path) + "\nDimensions: " + img.Width + "x" + img.Height + "\nDDS file size: " + ghg.texSizes[0] + " bytes (" + ghg.texSizes[0]/1024 + " KB)\nMipmap count: " + img.MipMaps.Length;

					handle.Free();
				}
			}
		}
		
		// Extract button
		private void button1_Click(object sender, EventArgs e) {
			saveFileDialog1.InitialDirectory = Properties.Settings.Default.iconExportPath;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				File.WriteAllBytes(saveFileDialog1.FileName, ghg.texData[0]);
				Properties.Settings.Default.iconExportPath = Path.GetDirectoryName(saveFileDialog1.FileName);
				Properties.Settings.Default.Save();
				MessageBox.Show("Successfully exported texture!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Replace button
		private void button2_Click(object sender, EventArgs e) {
			openFileDialog1.InitialDirectory = Properties.Settings.Default.iconLoadPath;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				Properties.Settings.Default.iconLoadPath = Path.GetDirectoryName(openFileDialog1.FileName);
				Properties.Settings.Default.Save();
				bool result = GhgManager.OverwriteTexture(0, ghg, currentIconPath, openFileDialog1.FileName);
				if (result) {
					MessageBox.Show("Successfully replaced texture!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				} else {
					MessageBox.Show("Failed to replace texture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				LoadIconFromGsc(currentIconPath);
			}
		}

		// Done
		private void button3_Click(object sender, EventArgs e) {
			Close();
		}

		// Apply other character copy
		private void button4_Click(object sender, EventArgs e) {
			GHGParameters l_ghg;
			GhgManager.LoadModel(Program.paths.PATH_STUFF + @"\ICONS\" + comboBox1.Text + ".GSC", out l_ghg);
			bool result = GhgManager.OverwriteTextureData(0, ghg, currentIconPath, l_ghg.texData[0]);
			if (result) {
				MessageBox.Show("Successfully replaced texture!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else {
				MessageBox.Show("Failed to replace texture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadIconFromGsc(currentIconPath);
		}
	}
}
