using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public class ImagePanelWithDetails : Panel
	{
		public PictureBox pictureBox;
		public Label label;
		public Panel selectionPanel;
		public bool selected;

		public ImagePanelWithDetails() {
			BorderStyle = BorderStyle.FixedSingle;
			Size = new System.Drawing.Size(250, 61);

			selectionPanel = new Panel();
			selectionPanel.Location = new System.Drawing.Point(-4, -4);
			selectionPanel.Size = new System.Drawing.Size(258, 69);
			selectionPanel.BackColor = Color.DodgerBlue;

			pictureBox = new PictureBox();
			pictureBox.Location = new System.Drawing.Point(4, 4);
			pictureBox.Size = new System.Drawing.Size(50, 50);
			pictureBox.BorderStyle = BorderStyle.FixedSingle;
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox.BackColor = Color.Black;

			label = new Label();
			label.Location = new System.Drawing.Point(61, 15);
			label.Size = new System.Drawing.Size(180, 26);

			Controls.Add(selectionPanel);
			Controls.Add(pictureBox);
			Controls.Add(label);

			Controls.SetChildIndex(selectionPanel, 100);

			SetSelected(false);
		}

		public void SetSelected(bool sel) {
			selected = sel;
			if (sel) {
				selectionPanel.Show();
			} else {
				selectionPanel.Hide();
			}
		}
	}
}
