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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaddenDataScraper_2024
{
	public partial class FaceForm : Form
	{
		public FaceForm()
		{
			InitializeComponent();
			listPhotos.SelectedValueChanged += ListPhotos_SelectedValueChanged;
			panelChunk.Paint += PanelChunk_Paint;
			pictureBoxFace.Paint += PictureBoxFace_Paint;
		}

		private void PictureBoxFace_Paint(object sender, PaintEventArgs e)
		{
			panelChunk.Invalidate();
		}

		private void PanelChunk_Paint(object sender, PaintEventArgs e)
		{
			if (pictureBoxFace.Image != null)
			{
				int width = 10;
				int height = 10;
				int x = pictureBoxFace.Image.Width / 2 + width;
				int y = pictureBoxFace.Image.Height / 2;
				Rectangle srcRect = new Rectangle(x, y, width, height);
				Rectangle destRect = new Rectangle(0, 0, 50, 50);
				e.Graphics.DrawImage(pictureBoxFace.Image, destRect, srcRect, GraphicsUnit.Pixel);
				Bitmap bitmap = new Bitmap(width, height);
				Graphics g = Graphics.FromImage(bitmap);
				g.DrawImage(pictureBoxFace.Image, destRect, srcRect, GraphicsUnit.Pixel);
				
				var averageColor = SkinMatcher.CalculateAverageColor(bitmap);
				// update Average color data
				label1.BackColor = averageColor;
				var closestColor = SkinMatcher.FindClosestColor(label1.BackColor);
				label1.Text = String.Format(" 0x{0:X}\r\n{1}",label1.BackColor.ToArgb(), closestColor.Value);

				// update best match color data
				label2.BackColor = Color.FromArgb( (int)closestColor.Key);
				label2.Text = String.Format("0x{0:X}\r\n{1}", closestColor.Key, closestColor.Value);

				g.Dispose();
				bitmap.Dispose();
			}
		}

		private void ListPhotos_SelectedValueChanged(object sender, EventArgs e)
		{
			if (listPhotos.SelectedIndex > -1)
			{
				FileInfo fi = listPhotos.Items[listPhotos.SelectedIndex] as FileInfo;
				pictureBoxFace.ImageLocation = fi.FullName;
				pictureBoxFace.Refresh();
			}
		}

		List<FileInfo> files = null;
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			DirectoryInfo di = new DirectoryInfo(".");
			files = new List<FileInfo>( di.GetFiles("*.png", SearchOption.AllDirectories));
			files.AddRange(di.GetFiles("*.jpg", SearchOption.AllDirectories));
			listPhotos.Items.AddRange(files.ToArray());
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			listPhotos.Items.Clear();
			foreach (FileInfo file in files)
			{
				if(file.Name.Contains(txtFilter.Text))
				{
					listPhotos.Items.Add(file);
				}
				if(listPhotos.Items.Count == 1)
				{
					listPhotos.SelectedIndex = 0;
				}
			}
		}

		private void label1_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(label1.Text);
		}
	}
}
