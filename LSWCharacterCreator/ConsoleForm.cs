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
	public partial class ConsoleForm : Form
	{
		public ConsoleForm() {
			InitializeComponent();
			PopulateConsole();
		}

		public void PopulateConsole() {
			panel1.Controls.Clear();

			List<LSWCCLog> logs = LSWConsole.GetAllLogs();
			for (int i = 0; i < logs.Count; i++) {
				Panel panel = new Panel();
				panel.Parent = panel1;
				panel.Size = new Size(panel1.Size.Width - 20, 32);
				panel.Location = new Point(10, i * 40 + 10);

				PictureBox pb = new PictureBox();
				pb.Size = new Size(32, 32);
				pb.Location = new Point(0, 0);
				switch(logs[i].type) {
					case LSWCCLogType.Error:
						pb.Image = Bitmap.FromHicon(SystemIcons.Error.Handle);
						break;
					case LSWCCLogType.Warning:
						pb.Image = Bitmap.FromHicon(SystemIcons.Warning.Handle);
						break;
					case LSWCCLogType.Debug:
						pb.Image = Bitmap.FromHicon(SystemIcons.Information.Handle);
						break;
				}

				Label l = new Label();
				l.Location = new Point(40, 8);
				l.Size = new Size(panel1.Size.Width - 60, 32);
				l.Text = logs[i].message;

				panel.Controls.Add(pb);
				panel.Controls.Add(l);
				panel1.Controls.Add(panel);
			}
		}
	}
}
