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

namespace MaddenDataScraper_2024
{
	public partial class TextForm : Form
	{
		public TextForm()
		{
			InitializeComponent();
		}

		public String FilenameHint = "";

		public String TextContent
		{
			get { return richTextBox1.Text; }
			set { richTextBox1.Text = value; }
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"  ;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
			if(!String.IsNullOrEmpty( FilenameHint) )
				saveFileDialog.FileName = FilenameHint;
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(saveFileDialog.FileName, TextContent);
			}
			saveFileDialog.Dispose();
		}
	}
}
