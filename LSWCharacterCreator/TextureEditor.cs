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

namespace LSWCharacterCreator
{
	public partial class TextureEditor : Form
	{
		public GHGParameters ghg;
		public int selected = -1;
		public string currentGhgPath;

		public TextureEditor() {
			InitializeComponent();

			pictureBox1.BackColor = Color.Black;
			label3.Text = "Please select a texture from the list.";
			PopulateModelDropdown();
		}

		private void PopulateModelDropdown() {
			comboBox1.Items.Add(Path.GetFileNameWithoutExtension(Program.ghgFile));
			comboBox1.Items.Add(Path.GetFileNameWithoutExtension(Program.ghgLrFile));
			comboBox1.SelectedIndex = 0;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			LoadTexturesFromGhg(comboBox1.SelectedIndex == 0 ? Program.ghgFile : Program.ghgLrFile);
			label3.Text = "Please select a texture from the list.";
			pictureBox1.Image = null;
			selected = -1;
		}

		public void LoadTexturesFromGhg(string path) {
			currentGhgPath = path;
			GhgManager.LoadModel(path, out ghg);
			panel1.Controls.Clear();
			for (int i = 0; i < ghg.texCount; i++) {
				using (Stream s = new MemoryStream(ghg.texData[i])) {
					using (Pfim.IImage img = Pfim.Pfim.FromStream(s)) {
						GCHandle handle = GCHandle.Alloc(img.Data, GCHandleType.Pinned);
						IntPtr data = Marshal.UnsafeAddrOfPinnedArrayElement(img.Data, 0);
						Bitmap bitmap = null;
						if(img.Format == Pfim.ImageFormat.Rgb24)
							bitmap = new Bitmap(img.Width, img.Height, img.Stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, data);
						else if (img.Format == Pfim.ImageFormat.Rgba32)
							bitmap = new Bitmap(img.Width, img.Height, img.Stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, data);

						ImagePanelWithDetails imgPanel = new ImagePanelWithDetails();

						imgPanel.pictureBox.Image = bitmap;
						imgPanel.label.Text = "Texture #" + i + "\nDimensions: " + ghg.texWidths[i] + "x" + ghg.texHeights[i];
						imgPanel.label.MouseClick += Details_MouseClick;
						imgPanel.pictureBox.MouseClick += Details_MouseClick;
						imgPanel.Location = new Point(4, 4 + i * 65);
						imgPanel.MouseClick += ImgPanel_MouseClick;

						panel1.Controls.Add(imgPanel);

						handle.Free();
					}
				}
			}
			imgDetailsPanel.Hide();
		}

		private void Details_MouseClick(object sender, MouseEventArgs e) {
			ImgPanel_MouseClick(((Control)sender).Parent, e);
		}

		private void ImgPanel_MouseClick(object sender, MouseEventArgs e) {
			ImagePanelWithDetails selectedPanel = ((ImagePanelWithDetails)sender);
			foreach (ImagePanelWithDetails imgPanel in panel1.Controls.OfType<ImagePanelWithDetails>()) {
				imgPanel.SetSelected(false);
			}
			pictureBox1.Image = selectedPanel.pictureBox.Image;
			selectedPanel.SetSelected(true);
			selected = panel1.Controls.GetChildIndex(selectedPanel);
			label3.Text = "Texture Index: " + selected + "\nDimensions: " + ghg.texWidths[selected] + "x" + ghg.texHeights[selected] + "\nDDS file size: " + ghg.texSizes[selected] + " bytes (" + ghg.texSizes[selected] / 1024 + " KB)";
		}

		// Done button
		private void button3_Click(object sender, EventArgs e) {
			Close();
		}

		// Extract button
		private void button1_Click(object sender, EventArgs e) {
			saveFileDialog1.InitialDirectory = Properties.Settings.Default.texExportPath;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				File.WriteAllBytes(saveFileDialog1.FileName, ghg.texData[selected]);
				Properties.Settings.Default.texExportPath = Path.GetDirectoryName(saveFileDialog1.FileName);
				Properties.Settings.Default.Save();
				MessageBox.Show("Successfully exported texture!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Replace button
		private void button2_Click(object sender, EventArgs e) {
			openFileDialog1.InitialDirectory = Properties.Settings.Default.texLoadPath;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				Properties.Settings.Default.texLoadPath = Path.GetDirectoryName(openFileDialog1.FileName);
				Properties.Settings.Default.Save();
				bool result = GhgManager.OverwriteTexture(selected, ghg, currentGhgPath, openFileDialog1.FileName);
				if (result) {
					MessageBox.Show("Successfully replaced texture!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				} else {
					MessageBox.Show("Failed to replace texture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			LoadTexturesFromGhg(currentGhgPath);
			int i = 0;
			foreach (ImagePanelWithDetails imgPanel in panel1.Controls.OfType<ImagePanelWithDetails>()) {
				if (i == selected) {
					imgPanel.SetSelected(true);
					pictureBox1.Image = imgPanel.pictureBox.Image;
				}
				i++;
			}
		}
	}
}
