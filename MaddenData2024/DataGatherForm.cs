using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using MaddenConverter;
using System.Xml.Xsl;

namespace MaddenDataScraper_2024
{

	public partial class DataGatherForm : Form
	{
		public DataGatherForm()
		{
			InitializeComponent();
			comboTeams.Items.Add("AllTeams");
			comboTeams.Items.AddRange(Program.GetTeams().ToArray());
			comboTeams.SelectedIndex = 0;

			comboTeamsPhoto.Items.AddRange(Program.GetTeams().ToArray());
			comboTeamsPhoto.Items.Insert(0,"All Teams");
			comboTeamsPhoto.SelectedIndex = 0;
			SetToolTips();
			PopulateAppearanceGrid();
			labStatus.Text = "Loaded";
		}

		private void PopulateAppearanceGrid()
		{
			var photoColumn = new DataGridViewImageColumn() { 
				Width = 50, HeaderText = "Photo", DataPropertyName = "Photo", ImageLayout = DataGridViewImageCellLayout.Stretch,
				
			};
			photoColumn.DefaultCellStyle.NullValue = Program.GetEmbeddedImage("GreyBox.png");

			dataGridAppearance.Columns.Add(new DataGridViewTextBoxColumn() { Width = 50, HeaderText = "Team", DataPropertyName = "Team" });
			dataGridAppearance.Columns.Add(photoColumn);
			dataGridAppearance.Columns.Add(new DataGridViewTextBoxColumn() { Width = 50, HeaderText = "Position", DataPropertyName = "Position" });
			dataGridAppearance.Columns.Add(new DataGridViewTextBoxColumn() { Width = 60, HeaderText = "First Name", DataPropertyName = "FirstName" });
			dataGridAppearance.Columns.Add(new DataGridViewTextBoxColumn() { Width = 60, HeaderText = "Last Name", DataPropertyName = "LastName" });
			dataGridAppearance.Columns.Add(new DataGridViewTextBoxColumn() { Width = 50, HeaderText = "Skin", DataPropertyName = "Skin" });
			/*var skinColumn = new DataGridViewComboBoxColumn() { 
				Width = 50, HeaderText = "Skin", DataPropertyName = "Skin"
			};
			skinColumn.Items.AddRange(SkinMatcher.GetSkinChoices());
			dataGridAppearance.Columns.Add(skinColumn);*/

			dataGridAppearance.AutoGenerateColumns = false;
			dataGridAppearance.CellFormatting += DataGridAppearance_CellFormatting;
			dataGridAppearance.EditingControlShowing += DataGridAppearance_EditingControlShowing;
		}

		private AutoCompleteStringCollection skinChoices = null;

		private void DataGridAppearance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dataGridAppearance.CurrentCell.ColumnIndex == 5)
			{
				TextBox txtBox = e.Control as TextBox;
				txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; //AutoCompleteStringCollection
				txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
				if (skinChoices == null)
				{
					skinChoices = new AutoCompleteStringCollection();
					skinChoices.AddRange(SkinMatcher.GetSkinChoices().ToArray());
				}
				txtBox.AutoCompleteCustomSource = skinChoices;
			}
		}

		private void DataGridAppearance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				var dude = dataGridAppearance.Rows[e.RowIndex].DataBoundItem as PlayerAppearanceData;
				if (dude != null)
				{
					Color c = SkinMatcher.GetColorForSkin(dude.Skin);
					dataGridAppearance.Rows[e.RowIndex].DefaultCellStyle.BackColor = c;
				}
			}
		}

		private void dataGridAppearance_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				PlayerAppearanceData p = dataGridAppearance.Rows[e.RowIndex].DataBoundItem as PlayerAppearanceData;
				if (p != null)
				{
					pictureBoxPlayer.Image = p.Photo;
				}
			}
		}

		private void SetToolTips()
		{
			var tip = new System.Windows.Forms.ToolTip();
			tip.SetToolTip(panel2K5Data, "Auto Populated after using the 'Team Trimmer'");
			tip.SetToolTip(listEquipmentFiles, "Auto Populated with 'EquipmentData' files");
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			txtBaseUrl.Text = Program.BaseUrl;
		}

		private void listTeamPageUrlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			List<String> teams = Program.GetTeams();
			foreach (String team in teams)
			{
				sb.Append(Program.GetTeamPageUrl(team));
				sb.Append(Environment.NewLine);
			}
			txtJsonData.Text = sb.ToString();
		}

		private void listTeamDataUrlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			List<String> teams = Program.GetTeams();
			foreach (String team in teams)
			{
				sb.Append(Program.GetTeamDataUrl(team));
				sb.Append(Environment.NewLine);
			}
			txtJsonData.Text = sb.ToString();
		}

		private void getSelectedTeamDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (comboTeams.SelectedItem != null)
			{
				string team = comboTeams.SelectedItem.ToString();
				string rawTeamData = "";
				string dataDir = "RawTeamData";
				if(!Directory.Exists(dataDir))
				{
					Directory.CreateDirectory(dataDir);
				}

				string teamFileName = $"{dataDir}\\{team}.raw.json";
				if (File.Exists(teamFileName))
				{
					rawTeamData = File.ReadAllText(teamFileName);
					UpdateStatus($"Read from file {teamFileName}");
				}
				else
				{
					var teamUrl = Program.GetTeamDataUrl(team);
					UpdateStatus($"Requesting Team Data for '{team}'");
					rawTeamData = Program.GetWebData(teamUrl);
					if(rawTeamData != null && !rawTeamData.StartsWith("error") )
					{
						File.WriteAllText(teamFileName, rawTeamData);
						UpdateStatus($"Saved Team Data to '{teamFileName}'");
					}
					else
						UpdateStatus($"Error requesting Team Data for '{team}'");
				}
				txtJsonData.Text = rawTeamData;
			}
		}

		Thread thread = null;
		private void btnGo_Click(object sender, EventArgs e)
		{
			if(thread!=null && thread.IsAlive )
			{
				DialogResult result = 
					MessageBox.Show("Currently Running Data Gather Operation; Stop Process?",
									"Kill Operation?", 
									MessageBoxButtons.YesNoCancel
					);
				if (result == DialogResult.Yes)
				{
					try { thread.Abort(); }
					catch (Exception ex) { }
					return;
				}
				else
					return;
			}
			if (comboTeams.Text == "All Teams")
				teamsToGet = Program.GetTeams();
			else
				teamsToGet = new List<string>() { comboTeams.Text};

			thread = new Thread(new ThreadStart(GetData));
			thread.Start();
		}

		private void UpdateStatus(String s)
		{
			if (InvokeRequired)
				BeginInvoke(new Action<string>(UpdateStatus), s);
			else
				labStatus.Text = s;
		}

		private List<string> teamsToGet = new List<string>();

		private void GetData()
		{
			StringBuilder sb = new StringBuilder();
			var teams = teamsToGet; // Program.GetTeams();
			string teamFileName = "";
			string rawTeamData = "";
			string dataDir = "RawTeamData";
			if (!Directory.Exists(dataDir))
			{
				Directory.CreateDirectory(dataDir);
			}
			foreach (var team in teams)
			{
				teamFileName = $"{dataDir}\\{team}.raw.json";
				if (File.Exists(teamFileName))
				{ 
					rawTeamData = File.ReadAllText( teamFileName);
					UpdateStatus($"Read from file {teamFileName}");
				}
				else
				{
					var teamUrl = Program.GetTeamDataUrl(team);
					UpdateStatus($"Requesting Team Data for '{team}'");
					rawTeamData = Program.GetWebData(teamUrl);
					if (rawTeamData != null && !rawTeamData.StartsWith("error"))
					{
						File.WriteAllText(teamFileName, rawTeamData);
						UpdateStatus($"Saving Team data to '{teamFileName}'");
					}
				}
				if (rawTeamData.StartsWith("error"))
					Console.WriteLine($"Error getting taem data for '{team}'");
			}
			string allData = sb.ToString();
			txtMaddenData.Text = allData;
		}

		private void saveMaddenDataAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Madden Data (for processing in MaddenJSONData html page)";
			saveFileDialog.FileName =  "result.js";
			saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(saveFileDialog.FileName, txtMaddenData.Text);
				labStatus.Text = $"Saved to {saveFileDialog.FileName}";
			}
			saveFileDialog.Dispose();
		}

		private void txtBaseUrl_TextChanged(object sender, EventArgs e)
		{
			Program.BaseUrl = txtBaseUrl.Text;
			Console.WriteLine($"BaseUrl changed to '{Program.BaseUrl}'");
		}

		private void aboutBaseUrlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			String msg = "The Base url can change. Goto the a Team Madden ratings page;\r\nopen the Inspector Tools to find the Base Url (type= fetch).";
			MessageBox.Show(msg);
		}

		private void btnTranslateAllData_Click(object sender, EventArgs e)
		{
			TranslateData();
		}

		private void TranslateData()
		{
			tabControl1.SelectedIndex = 1;
			StringBuilder sb = new StringBuilder();
			var teams = Program.GetTeams();
			string teamFileName = "";
			string rawTeamData = "";
			string dataDir = "RawTeamData";
			sb.Append("var  allTeams2020 = [ \r\n");
			foreach (var team in teams)
			{
				teamFileName = $"{dataDir}\\{team}.raw.json";
				if (File.Exists(teamFileName))
				{
					rawTeamData = File.ReadAllText(teamFileName);
					UpdateStatus($"Read from file {teamFileName}");
					var teamPlayerData = Program.GetPlayerData(rawTeamData);
					Program.TranslateToOldFormat(teamPlayerData, team, sb);
				}
				else
				{
					Console.WriteLine($"Error! Could not Find file {teamFileName}; Need to run Gather Data operation? Skipping {team}");
				}
			}
			sb.Append("], injuredReserveList = [ ]; \n");
			string allData = sb.ToString();
			txtMaddenData.Text = allData;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void teamTrimmerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TeamTrimmer tt = new TeamTrimmer();
			tt.Icon =this.Icon;
			tt.LoadData(txtMaddenData.Text);
			if(tt.ShowDialog() == DialogResult.OK)
			{
				richTextBoxMaddenConverter.Text = tt.GetCsvData();
				MaddenDataConverter conv = new MaddenDataConverter();
				richTextBox2K5Data.Text = conv.ConvertData(richTextBoxMaddenConverter.Text);
				tabControl1.SelectedIndex = 3;
				labStatus.Text = "Translated to 2K5Tool data";
			}
			tt.Dispose();
		}

		private void label2_Click(object sender, EventArgs e)
		{
			string[] files = Directory.GetFiles(".", "index.html", SearchOption.AllDirectories);
			if (files.Length > 0)
			{
				Process.Start(files[0]);
			}
		}

		private void gatherPhotosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (thread != null && thread.IsAlive)
			{
				DialogResult result =
					MessageBox.Show("Currently Running Data Gather Operation; Stop Process?",
									"Kill Operation?",
									MessageBoxButtons.YesNoCancel
					);
				if (result == DialogResult.Yes)
				{
					try { thread.Abort(); }
					catch (Exception ex) { }
					return;
				}
				else
					return;
			}
			thread = new Thread(new ThreadStart(DownloadPhotos));
			thread.Start();
		}

		private void btnCreatePhotoDownloadCurlScript_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			List<string> teams = new List<string>();
			if (comboTeamsPhoto.SelectedIndex == 0) // all teams
				teams = Program.GetTeams();
			else
				teams.Add(comboTeamsPhoto.Text);

			string teamFileName = "";
			string rawTeamData = "";
			string dataDir = "RawTeamData";
			string url;
			foreach (var team in teams)
			{
				teamFileName = $"{dataDir}\\{team}.raw.json";
				UpdateStatus($"Downloading photos for {team}");
				if (File.Exists(teamFileName))
				{
					rawTeamData = File.ReadAllText(teamFileName);
					var players = GetImageDownloadData(rawTeamData);
					sb.Append($"\r\n::Download Photos for {team}\r\n");
					sb.Append($"mkdir Photos\\{team}\r\n");
					foreach (var player in players)
					{
						//curl -o image.png https://example.com/image.png
						string saveTo = $"Photos\\{team}\\{player["firstName"]}_{player["lastName"]}.png";
						url = player["avatarUrl"];
						int index = url.IndexOf('?');
						if (index > 0)
							url = url.Substring(0, index);

						sb.Append($"curl -o \"{saveTo}\" {url}\r\n");
					}
				}
				else
				{
					Console.WriteLine($"Error! Could not Find file {teamFileName}; Need to run Gather Data operation? Skipping {team}");
				}
			}
			TextForm textForm = new TextForm();
			textForm.Icon = this.Icon;
			textForm.Text = "Photo Download Batch File";
			textForm.TextContent = sb.ToString();
			textForm.FilenameHint = $"PhotoDownload_{comboTeamsPhoto.Text}.bat";
			textForm.Show();
		}

		private void DownloadPhotos()
		{
			List<string> teams = new List<string>();
			if(comboTeamsPhoto.SelectedIndex == 0 ) // all teams
				teams = Program.GetTeams();
			else
				teams.Add(comboTeamsPhoto.Text);

			string teamFileName = "";
			string rawTeamData = "";
			string dataDir = "RawTeamData";
			foreach (var team in teams)
			{
				teamFileName = $"{dataDir}\\{team}.raw.json";
				UpdateStatus($"Downloading photos for {team}");
				if (File.Exists(teamFileName))
				{
					rawTeamData = File.ReadAllText(teamFileName);
					//UpdateStatus($"Read from file {teamFileName}");
					var players = GetImageDownloadData(rawTeamData);
					foreach(var player in players)
					{
						try
						{
							UpdateStatus($"{team} {player["firstName"]}_{player["lastName"]}.png");
							DownloadPhoto(team, player);
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Error Downloading Photo for {player["firstName"]} {player["lastName"]}");
						}
					}
				}
				else
				{
					Console.WriteLine($"Error! Could not Find file {teamFileName}; Need to run Gather Data operation? Skipping {team}");
				}
			}
			UpdateStatus($"Completed Requested Download Photo Operation for {teams.Count} team(s)");
		}
		
		private void DownloadPhoto(string team, Dictionary<string, string> player)
		{
			// can also use:
			// curl -o image.png https://example.com/image.png

			string folder = $"Photos\\{team}";
			if(!Directory.Exists(folder))
			{
				Directory.CreateDirectory(folder);
			}
			string saveTo = $"{folder}\\{player["firstName"]}_{player["lastName"]}.png";
			if(File.Exists(saveTo))
				return;
			string url = player["avatarUrl"];
			int index = url.IndexOf('?');
			if(index > 0)
			{
				url = url.Substring(0, index);
			}
			var photoWebClient = new WebClient();
			photoWebClient.DownloadFile(url, saveTo);
			photoWebClient.Dispose();
		}

		// Expects data from team.raw.json files
		// Goes through and returns relavent data for downloading Player photo
		public static List<Dictionary<string, string>> GetImageDownloadData(string jsonData)
		{
			List<Dictionary<String, string>> retVal = new List<Dictionary<String, string>>();
			string[] playerAttrs = {
				"id",
				"overallRating",
				"firstName",
				"lastName",
				"jerseyNum",
				"position.id",
				"avatarUrl"
			};
			JObject obj = JObject.Parse(jsonData);
			JArray items = obj.SelectToken("pageProps.ratingsEntries.items").ToObject<JArray>();
			//Console.WriteLine($"GetImageDownloadData Tolal Players: {items.Count}");
			foreach (JObject item in items)
			{
				Dictionary<string, string> player = new Dictionary<string, string>();
				foreach (string attr in playerAttrs)
				{
					player.Add(attr, item.SelectToken(attr).ToString());
				}
				retVal.Add(player);
			}
			return retVal;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(tabControl1.SelectedIndex == 2)
			{
				PopulatePhotoData();
			}
			else if(tabControl1.SelectedIndex == 3)
			{
				CheckAppearanceData();
			}
		}

		private void CheckAppearanceData()
		{
			PlayerAppearance.EquipmentFiles = new List<string>(Directory.GetFiles(".","*EquipmentData*", SearchOption.AllDirectories));
			if (txtSkinFileLocation.Text.Length == 0)
			{
				var skinMaps = Directory.GetFiles(".", "SkinMap.txt", SearchOption.AllDirectories);
				if (skinMaps.Length > 0)
				{
					txtSkinFileLocation.Text = skinMaps[0];
				}
			}
			int lines = 0;
			listEquipmentFiles.Items.Clear();
			listEquipmentFiles.Items.AddRange(PlayerAppearance.EquipmentFiles.ToArray());
			foreach(string file in PlayerAppearance.EquipmentFiles)
			{
				lines += File.ReadAllLines(file).Length;
			}
			if (lines > 0)
			{
				labelEquipmentData.Text = $"{labelEquipmentData.Tag.ToString()} ({lines.ToString("N0")} Total lines)";
			}
			if(File.Exists(txtSkinFileLocation.Text) )
			{
				lines = File.ReadAllText(txtSkinFileLocation.Text).Length;
				labelSkinMapFile.Text = $"{labelSkinMapFile.Tag.ToString()} ({lines.ToString("N0")} lines)";
			}
			Color niceColor = Color.PaleGreen;
			//Celadon - #AFE1AF
			niceColor = Color.FromArgb(0xAF, 0xE1, 0xAF);
			string errorMsg = "";
			if (listEquipmentFiles.Items.Count == 0)
			{
				listEquipmentFiles.BackColor = Color.LightCoral;
				errorMsg += "No EquipmentData files found!\r\n";
			}
			else
				listEquipmentFiles.BackColor = niceColor;

			if (txtSkinFileLocation.Text.Length == 0)
			{
				txtSkinFileLocation.BackColor = Color.LightCoral;
				errorMsg += "No SkinMap files found!";
			}
			else
				txtSkinFileLocation.BackColor = niceColor;
			if(errorMsg.Length > 0)
			{
				lab2K5DataError.Text = errorMsg;
				lab2K5DataError.Visible = true;
			}
			else
			{
				lab2K5DataError.Text = "";
				lab2K5DataError.Visible=false;
			}
		}

		private void PopulatePhotoData()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Team Photo Count\r\n");
			var items = Program.GetTeams();
			int cols = 6;
			//while (items.Count % cols != 0)
			//	items.Add(" ");
			for (int i = 0; i < items.Count; i++)
			{
				if (i > 0 && i % cols == 0)
					sb.Append("\r\n");
				string folder = $"Photos\\{items[i]}";
				DirectoryInfo di = new DirectoryInfo(folder);
				int numPhotos = 0;
				if (di.Exists)
				{
					numPhotos = di.GetFiles("*.png").Length;
				}
				sb.Append(String.Format("{0, -12} {1, -4}", items[i], numPhotos));
			}
			richTextBoxPhotoData.Text = sb.ToString();
			Program.Colorize(new Regex("[0-9]+"), Color.Red, richTextBoxPhotoData);
			Program.Colorize(new Regex("[A-Za-z]+"), Color.RoyalBlue, richTextBoxPhotoData);
			Program.Colorize(new Regex("49ers"), Color.RoyalBlue, richTextBoxPhotoData);

		}

		private void btnDownloadPhotos_Click(object sender, EventArgs e)
		{
			DownloadPhotos();
		}

		private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string helpMsg =
@"This Program Has Several functions:
Madden Data 2024 Dialog:
   1. [Gather all team data] Download JSON Data from EA's website 
   2. [Translate All team data] Translate the 'new' JSON format to the 'old' JSON format so that the current tools can consume it. 
   3. [Photos Tab -> Download Photos] Download Photos from EA's website
   4. [File -> Team Trimmer] Open the Team Trimmer dialog.
   5. [NFL2K5 Data Tab] Contains the Madden Converter logic. Auto populated once the Team Trimmer is closed.

Team Trimmer Dialog:
   1. [File-> Load Data] Load a .js file in the 'old' format (the format consumed by the old html file)
      Note: If the 'Madden Data 2024' Dialog has (Translated) data loaded, 'Data Trimmer' dialog is auto polulated with that data.
   2. [File -> Save Data csv] Save data to be consumed by the 'Madden Converter' program.
   3. [File -> Show Data csv] Show data to be consumed by the 'Madden Converter' program (easier to copy/paste).
   4. [Auto Trim] Menu items to 'auto trim' the roster (teams & Free Agents).
   5. [Manual Trim Positions -> Trim Now] Manually trim selected positions for all teams.
   6. [Free Agent Control] When auto trimming Free agents specify max free agents to keep and option to first cut players who have overall worse rating less than the specified number.

Expected Workflow:
   1. Gather all the team data from EA's Madden Site (data is cached to disk)
   2. Press Translate Data (still works if data was cached previously)
   3. File -> Team Trimmer ; Trim the teams how you like
   4. NFL2K5 Data is populated, copy/paste into NFL2K5Tool.
";
			TextForm tf = new TextForm();
			tf.Icon = this.Icon;
			tf.Text = "How To use this program";
			tf.TextContent = helpMsg;
			tf.Show();
		}

		private void btnConvertTo2K5Data_Click(object sender, EventArgs e)
		{
			MaddenDataConverter converter = new MaddenDataConverter();
			richTextBox2K5Data.Text = converter.ConvertData(richTextBoxMaddenConverter.Text);
		}

		private void txtSkinFileLocation_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void txtSkinFileLocation_DragDrop(object sender, DragEventArgs e)
		{
			Control tb = sender as Control;
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files != null && files.Length == 1 && tb != null)
			{
				tb.Text = files[0];
			}
		}

		private void txtSkinFileLocation_TextChanged(object sender, EventArgs e)
		{
			if(File.Exists(txtSkinFileLocation.Text))
			{
				PlayerAppearance.SkinMapFile = txtSkinFileLocation.Text;
			}
		}

		private void photoTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FaceForm ff = new FaceForm();
			ff.Icon = this.Icon;
			ff.Show();
		}

		private void btnCreateSkinMap_Click(object sender, EventArgs e)
		{
			CreateSkinMap();
		}

		private void CreateSkinMap()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("#Key=fname,lname,Position,Skin\r\n");
			BindingList< PlayerAppearanceData > players = dataGridAppearance.DataSource as BindingList<PlayerAppearanceData>;
			if(players == null || players.Count == 0)
				return; // early return

			foreach (var player in players)
			{
				sb.Append($"{player.FirstName},{player.LastName},{player.Position},{player.Skin}\r\n");
			}
			TextForm textForm = new TextForm();
			textForm.Icon = this.Icon;
			textForm.Text = "SkinMap.txt; Save As to keep";
			textForm.FilenameHint = "SkinMap.txt";
			textForm.TextContent = sb.ToString();
			textForm.Show();
		}

		private List<PlayerAppearanceData> playerAppearanceDataList = null;

		private void populateSkinStuffToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> teams = new List<string>();
			if (comboTeamsPhoto.SelectedIndex == 0) // all teams
				teams = Program.GetTeams();
			else
				teams.Add(comboTeamsPhoto.Text);
			playerAppearanceDataList = PlayerAppearanceData.GetAppearanceData(teams);
			dataGridAppearance.DataSource = new BindingList<PlayerAppearanceData>(playerAppearanceDataList);
		}

		private void textApperanceFilter_TextChanged(object sender, EventArgs e)
		{
			//var dataList = dataGridAppearance.DataSource as BindingList<PlayerAppearanceData>;
			List<PlayerAppearanceData> pd = new List<PlayerAppearanceData>();

			string filterCol = comboApperanceFilter.Text;
			string filterText = textApperanceFilter.Text.Trim();
			foreach (PlayerAppearanceData data in playerAppearanceDataList)
			{
				switch (filterCol)
				{
					case "Skin":
						if(data.Skin.Contains(filterText))
							pd.Add(data);
						break;
					case "Team":
						if (data.Team.Contains(filterText))
							pd.Add(data);
						break;
					case "Position":
						if (data.Position.Contains(filterText))
							pd.Add(data);
						break;
					case "First Name":
						if (data.FirstName.Contains(filterText))
							pd.Add(data);
						break;
					case "Last Name":
						if (data.LastName.Contains(filterText))
							pd.Add(data);
						break;
				}
			}
			dataGridAppearance.DataSource = new BindingList<PlayerAppearanceData>(pd);
		}

	}
}
