using MaddenConverter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaddenDataScraper_2024
{
	public partial class TeamTrimmer : Form
	{
		public TeamTrimmer()
		{
			InitializeComponent();
			dataGridView.AutoGenerateColumns = false; // Prevents auto-creation of columns
			//dataGridView.DataSource = people;

			// Add visible columns
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Team", DataPropertyName = "Team" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Rating", DataPropertyName = "Rating" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Position", DataPropertyName = "Position" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "First Name", DataPropertyName = "FirstName" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Last Name", DataPropertyName = "LastName" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Speed", DataPropertyName = "Speed" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Catching", DataPropertyName = "Catching" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "Accuracy", DataPropertyName = "Accuracy" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "PassBlock", DataPropertyName = "PassBlock" });
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {Width=50, HeaderText = "ManCoverage", DataPropertyName = "ManCoverage" });

			dataGridView.Columns.Add(CreateRemoveButtonColumn());
			foreach(var kvp in freeAgentSetup)
			{
				comboManualTrimPositions.Items.Add(kvp.Key);
			}
			comboManualTrimPositions.SelectedIndex = 0;
		}

		private void UpdateTeamCounts()
		{
			List<string> teamCounts = GetTeamCounts();
			string txt = BuildTable(teamCounts);
			richTextBox1.Text = txt;
			Program.Colorize(new Regex("[0-9]+"), Color.Red, richTextBox1);
			Program.Colorize(new Regex("[A-Za-z]+"), Color.RoyalBlue, richTextBox1);
			Program.Colorize(new Regex("49ers"), Color.RoyalBlue, richTextBox1);
		}

		private List<string> GetTeamCounts()
		{
			string currentTeam = "";
			string previousTeam = "";
			int count = 0;
			List<String> teamCounts = new List<String>();

			BindingList<PlayerData> data = dataGridView.DataSource as BindingList<PlayerData>;
			if (data != null)
			{
				for (int i = 0; i < data.Count; i++)
				{
					currentTeam = data[i].Team;
					if (currentTeam != previousTeam)
					{
						if (previousTeam.Length > 0)
						{
							teamCounts.Add(previousTeam);
							teamCounts.Add(count.ToString());
						}
						count = 1;
					}
					else
						count++;
					previousTeam = currentTeam;
				}
			}
			if (teamCounts.Count > 2 && teamCounts[teamCounts.Count - 2] != currentTeam)
			{
				teamCounts.Add(currentTeam);
				teamCounts.Add(count.ToString());
			}

			return teamCounts;
		}

		private List<string> GetPositionCounts(ICollection<PlayerData> data)
		{
			List<String> positionCounts = new List<String>();
			string[] positions = new string[] 
				{ "QB", "HB", "FB", "WR", "TE", "LT", "LG", "C", "RG", "RT", "LE", "RE", "DT", "LOLB", "ROLB", "MLB", "CB", "SS", "FS", "K", "P" };
			var team = data.FirstOrDefault().Team;
			foreach (string position in positions)
			{
				positionCounts.Add(position);
				positionCounts.Add(CountPlayers(team, data, position).ToString());
			}
			//CountPlayers
			return positionCounts;
		}

		private DataGridViewButtonColumn CreateRemoveButtonColumn()
		{
			DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
			buttonColumn.HeaderText = "Remove";
			buttonColumn.Text = "Remove";
			buttonColumn.UseColumnTextForButtonValue = true;  // This means the button will display "Remove"
			
			return buttonColumn;
		}

		private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Directory.GetCurrentDirectory();
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				string jsonData = File.ReadAllText(ofd.FileName);
				LoadData(jsonData);
			}
			ofd.Dispose();
		}

		public void LoadData(string jsonData)
		{
			if(String.IsNullOrEmpty(jsonData)) return;

			int beginningPos = 0;
			int endPos = 0;
			if (jsonData.StartsWith("var "))
			{
				beginningPos = jsonData.IndexOf('[');
				endPos = jsonData.LastIndexOf("],") + 1;
				string newData = jsonData.Substring(beginningPos, endPos - beginningPos);
				//string newData = String.Format("{{ 'teams':{0} }}", jsonData.Substring(beginningPos, endPos - beginningPos));
				jsonData = String.Format("{{ 'teams':{0} }}", newData);
			}
			JObject obj = JObject.Parse(jsonData.ToString());
			JArray teams = obj.SelectToken("teams").ToObject<JArray>();

			BindingList<PlayerData> dataModel = new BindingList<PlayerData>();
			foreach (JObject team in teams)
			{
				JArray players = team.SelectToken("docs").ToObject<JArray>();
				foreach (JObject joPlayer in players)
				{
					Dictionary<string, string> player = new Dictionary<string, string>();
					//foreach (string attr in PlayerData.playerAttrs)
					foreach(string attr in DataFormat.MaddenImportFormat)
					{
						player.Add(attr, joPlayer.SelectToken(attr).ToString());
					}
					dataModel.Add(new PlayerData(player));
				}
			}
			dataGridView.DataSource = dataModel;
			UpdateTeamCounts();
			ShowTeamPlayerAmounts("");
		}

		public static string BuildTable(List<string> items)
		{
			int cols = 6;
			while (items.Count % cols != 0)
				items.Add(" ");
			StringBuilder sb = new StringBuilder();
			for(int i =0; i < items.Count; i++)
			{
				if( i > 0 && i % cols == 0)
					sb.Append("\r\n");
				if(i %2 == 0)
					sb.Append(String.Format("{0,-12}", items[i]));
				else 
					sb.Append(String.Format("{0,-5}" , items[i]));
				//sb.Append($"{items[i]}\t");
			}
			return sb.ToString();
		}

		private void formatRTFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateTeamCounts();
		}

		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Assuming "Remove" is the name or index of your button column
			int removeButtonColumnIndex = 10;
			if (e.ColumnIndex == removeButtonColumnIndex && e.RowIndex >= 0)
			{
				//dataGridView.Rows.RemoveAt(e.RowIndex);
				BindingList<PlayerData> list = dataGridView.DataSource as  BindingList<PlayerData>;
				PlayerData playerData = list[e.RowIndex];
				list.RemoveAt(e.RowIndex);
				if(playerData.Team != "FreeAgents"  )
				{
					playerData.Team = "FreeAgents";
					list.Add(playerData);
				}
				UpdateTeamCounts();
			}
		}

		private void richTextBox1_DoubleClick(object sender, EventArgs e)
		{
			string highlightedText = richTextBox1.SelectedText.Trim();
			Console.WriteLine($"selected text:  {highlightedText}");
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Team == highlightedText)
				{
					dataGridView.FirstDisplayedScrollingRowIndex = i;
					break;
				}
			}
			ShowTeamPlayerAmounts(highlightedText);
		}

		private void ShowTeamPlayerAmounts(string teamName)
		{
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			if (string.IsNullOrEmpty(teamName))
			{
				teamName = "Bears";
				if (richTextBoxPositions.Text.Length > 3)
					teamName = richTextBoxPositions.Lines[0].Trim();
			}
			List<PlayerData> teamPlayers = GetCurrentTeam(teamName, list);
			if (teamPlayers.Count > 0)
			{
				List<string> teamCounts = GetPositionCounts(teamPlayers);
				string txt = BuildTable(teamCounts);
				richTextBoxPositions.Text = $"{teamName}\n" + txt;
				Program.Colorize(new Regex("[0-9]+"), Color.Red, richTextBoxPositions);
				Program.Colorize(new Regex("[A-Za-z]+"), Color.RoyalBlue, richTextBoxPositions);
				Program.Colorize(new Regex("49ers"), Color.RoyalBlue, richTextBoxPositions);
			}
		}

		private void AutoTrimTeams()
		{
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			if(list != null)
			{
				List<string> teamCounts = GetTeamCounts();
				string team = "";
				
				for(int i = teamCounts.Count-2; i > -1; i-=2){
					team = teamCounts[i];
					List<PlayerData> teamPlayers = GetCurrentTeam(team, list);
					Dictionary<String, int> idealRoster = GetIdealRoster(team, teamPlayers);
					TrimTeam(team, teamPlayers, idealRoster);
				}
			}
			UpdateTeamCounts();
			ShowTeamPlayerAmounts("");
		}

		private void TrimTeam(string team, List<PlayerData> teamPlayers, Dictionary<String, int> idealRoster)
		{
			List<PlayerData> cutPlayers = new List<PlayerData>();
			
			PlayerData player = null;
			int posCount = 0;
			for(int i = teamPlayers.Count-1; i > 0; i--)
			{
				if(teamPlayers.Count < 54) break;
				player = teamPlayers[i];
				posCount = CountPlayers(team, teamPlayers, player.Position);
				if(idealRoster.ContainsKey(player.Position) && posCount > idealRoster[player.Position])
				{
					cutPlayers.Add(player);
					teamPlayers.RemoveAt(i);
				}
			}
			foreach(PlayerData pd in cutPlayers)
			{
				CutPlayer(pd);
			}
		}

		private static Dictionary<string, int> freeAgentSetup = new Dictionary<string, int>() {
			{"QB",14}, {"HB",15}, {"FB", 4}, {"TE",16}, {"WR",21}, {"C",6}, {"RG",6}, {"LG",6}, {"RT",7}, {"LT",6 },
			 {"LE", 10 },{"RE",11}, {"DT", 17}, {"MLB",16}, {"LOLB",12}, {"ROLB",12}, {"CB",25},{"FS",13}, {"SS",13},
			 {"P",6}, {"K",6}
		};

		// Free Agents 241 by default;
		// C:4; CB:25; DE:21; DT: 17; FB: 16; FS: 13; G:7; ILB:14; K:16; OLB:25; P:13;
		// QB:7; RB:8; SS:10; T:11; TE:13; WR:21
		private void AutoTrimFreeAgents()
		{
			PlayerData player = null;
			List<PlayerData> cutPlayers = new List<PlayerData>();
			Dictionary<String, int> idealRoster = freeAgentSetup;
			var freeAgents = GetCurrentTeam("FreeAgents", dataGridView.DataSource as BindingList<PlayerData>);
			int autoCut = (int)spinAutoCut.Value;

			freeAgents.Sort(new PlayerComparer());
			int maxCount = (int)spinFreeAgentCount.Value +1;
			for (int i = freeAgents.Count - 1; i > 0; i--) // get rid of really bad players
			{
				if (freeAgents.Count < maxCount) break;
				player = freeAgents[i];
				if (player.Rating < autoCut)
				{
					cutPlayers.Add(player);
					freeAgents.RemoveAt(i);
				}
			}
				
			int posCount = 0;
			for (int i = freeAgents.Count - 1; i > 0; i--)
			{
				if (freeAgents.Count < maxCount) break;
				player = freeAgents[i];
				posCount = CountPlayers("FreeAgents", freeAgents, player.Position);
				if (posCount > idealRoster[player.Position])
				{
					cutPlayers.Add(player);
					freeAgents.RemoveAt(i);
				}
			}
			foreach (PlayerData pd in cutPlayers)
			{
				DeletePlayerFromLeague(pd);
			}
			UpdateTeamCounts();
			ShowTeamPlayerAmounts("FreeAgents");
		}

		private void DeletePlayerFromLeague(PlayerData pd)
		{
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			PlayerData player = null;
			for (int i = list.Count - 1; i > 0; i--)
			{
				player = list[i];
				if (player.PlayerId == pd.PlayerId)
				{
					list.RemoveAt(i);
					break;
				}
			}
		}
		// cut a player from a team, move to FreeAgents
		private void CutPlayer(PlayerData pd)
		{
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			//check fast case; PlayerId is his index in the list (default)
			if (list.Count > pd.PlayerId && list[pd.PlayerId] == pd)
			{
				pd.Team = "FreeAgents";
				list.RemoveAt(pd.PlayerId);
				list.Add(pd);
				return;
			}
			PlayerData player = null;
			for(int i = list.Count-1; i > 0; i--)
			{
				player = list[i];
				if(player.PlayerId == pd.PlayerId)
				{
					player.Team = "FreeAgents";
					list.RemoveAt(i);
					list.Add(player);
					break;
				}
			}
		}

		private Dictionary<string, int> GetIdealRoster(string team, List<PlayerData> players)
		{
			Dictionary<String, int> idealRoster = new Dictionary<string, int>() {
				{"QB", 3}, {"HB", 3}, {"FB", 1}, {"WR", 6},   {"TE", 3},   {"LT", 2},  {"LG", 2}, {"C", 1},  {"RG", 2}, 
				{"LE", 2}, {"RE", 3}, {"DT", 4}, {"LOLB", 2}, {"ROLB", 2}, {"MLB", 4}, {"CB", 5}, {"SS", 2}, {"FS", 2},
				{"K", 1},  {"P", 1},  {"RT", 2}
			};

			//Check roster for Fullbacks, add either WR or TE (whichever has more than usual)
			int numFullbacks = CountPlayers(team, players, "FB");
			if(numFullbacks < 1)
			{
				Console.WriteLine($"Team '{team}'; no FB");
				int numTE = CountPlayers(team, players, "TE");
				if (numTE > 3)
				{
					idealRoster["TE"] = 4;
					Console.WriteLine($"Team '{team}'; Set TE = 4");
				}
				else
				{
					int numWR = CountPlayers(team, players, "WR");
					if (numWR > 6)
					{
						idealRoster["WR"] = 7;
						Console.WriteLine($"Team '{team}'; Set WR = 7");
					}
				}
			}
			return idealRoster;
		}

		private List<PlayerData> GetCurrentTeam(string team, ICollection<PlayerData> allPlayers)
		{
			List<PlayerData> retVal = new List<PlayerData> ();
			foreach(PlayerData player in allPlayers)
			{
				if (player.Team == team)
				{
					retVal.Add(player);
				}
			}
			return retVal;
		}

		int CountPlayers(string team, ICollection<PlayerData> players, string position)
		{
			int count = 0;
			foreach(PlayerData playerData in players)
			{
				if (position == null)
				{
					if (playerData.Team == team)
						count++;
				}
				else
				{
					if(playerData.Team == team && playerData.Position == position)
						count++;
				}
			}
			return count;
		}

		private void autoTrimTeamsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AutoTrimTeams();
		}

		private void autoTrimFreeAgentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AutoTrimFreeAgents();
		}

		private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = Directory.GetCurrentDirectory();
			dlg.FileName = "result.js";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SaveJsonData(dlg.FileName);
			}
			dlg.Dispose();			
		}

		private void SaveJsonData(string filename)
		{
			StringBuilder sb = new StringBuilder(5000);
			BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
			string currentTeam, previousTeam = "";
			sb.Append("var  allTeams2020 = [ ");

			foreach (PlayerData playerData in list)
			{
				currentTeam = playerData.Team;
				if (currentTeam != previousTeam && previousTeam != "")
				{
					sb.Append("]},\n");
					Console.WriteLine($"Finish team {previousTeam}");
				}
				if (currentTeam != previousTeam)
				{
					Console.WriteLine($"Start team {currentTeam}");
					sb.Append("{\"count\":53, \"docs\":[");
				}
				playerData.ToJson(sb);
				sb.Append(",");				
				previousTeam = currentTeam;
			}
			sb.Append("]},\n");
			Console.WriteLine($"Finish team {previousTeam}");
			sb.Append("], injuredReserveList = [ ];\n");
			File.WriteAllText(filename, sb.ToString());
		}

		private void SaveCsvData(string filename)
		{
			string data = GetCsvData();
			File.WriteAllText(filename, data);
		}

		/// <summary>
		/// Needs to be sorted by Team, Position, PlayerRating
		/// </summary>
		/// <returns></returns>
		public string GetCsvData()
		{
			StringBuilder sb = new StringBuilder(5000);
			sb.Append('#');
			List<PlayerData> list = new List<PlayerData>( dataGridView.DataSource as IList<PlayerData>);
			//foreach (string attf in PlayerData.playerAttrs) // append header row
			foreach(string attf in DataFormat.MaddenExportFormat)
			{
				sb.Append(attf.Replace("_rating",""));
				sb.Append(",");
			}
			sb.Append("\r\n");
			NFL2K5PlayerComparer nFL2K5PlayerComparer = new NFL2K5PlayerComparer();
			list.Sort(nFL2K5PlayerComparer);
			foreach (PlayerData playerData in list)
			{
				playerData.ToCsv(sb);
				sb.Append("\r\n");
			}
			string data = sb.ToString();
			return data;
		}

		private void saveDatacsvToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = Directory.GetCurrentDirectory();
			dlg.FileName = "MaddenData.csv";
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				SaveCsvData(dlg.FileName);
			}
			dlg.Dispose();
		}

		private void showDataCSVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextForm tf = new TextForm();
			tf.Icon = this.Icon;
			tf.TextContent = GetCsvData();
			tf.Text = ".CSV data";
			tf.FilenameHint = "MaddenConverterData.csv";
			tf.Show();
		}

		public string NFL2K5Data
		{
			get
			{
				string maddenConverterInput = GetCsvData();
				MaddenDataConverter converter = new MaddenDataConverter();
				string retVal = converter.ConvertData( maddenConverterInput );
				return retVal;
			}
		}

		private void hTMLToolToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] files = Directory.GetFiles(".", "index.html", SearchOption.AllDirectories);
			if(files.Length > 0 )
			{
				Process.Start(files[0]);
			}
		}

		private void btnTrimNow_Click(object sender, EventArgs e)
		{
			int trimAmount = (int)spinManualTrim.Value;
			string pos = comboManualTrimPositions.Text;
			if(trimAmount > 0)
			{
				BindingList<PlayerData> list = dataGridView.DataSource as BindingList<PlayerData>;
				if (list != null)
				{
					List<string> teamCounts = GetTeamCounts();
					string team = "";
					for (int i = teamCounts.Count - 2; i > -1; i -= 2)
					{
						team = teamCounts[i];
						List<PlayerData> teamPlayers = GetCurrentTeam(team, list);
						Dictionary<String, int> trimPlayers = new Dictionary<String, int>() { { pos, trimAmount } };
						TrimTeam(team, teamPlayers, trimPlayers);
					}
				}
				UpdateTeamCounts();
				ShowTeamPlayerAmounts("");
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(this.Modal)
				this.DialogResult = DialogResult.OK;
			else
				this.Close();
		}
	}

	public class PlayerData
	{
		static int PlayerCount = 0;
		
		private Dictionary<string, string> mData;
		public PlayerData(Dictionary<string, string> data)
		{
			mData = data;
			PlayerId = PlayerCount++;
			int r = -1;
			Int32.TryParse(mData["overall_rating"], out r);
			this.Rating = r;
		}

		public string Team      { get { return mData["team"]; }  set { mData["team"] = value; } }
		//public string Rating    { get { return mData["overall_rating"]; } }
		public String FirstName { get { return mData["firstName"]; } }
		public String LastName  { get { return mData["lastName"]; } }
		public string Position  { get { return mData["position"]; } }
		public string Speed     { get { return mData["speed_rating"]; } }
		public string Catching  { get { return mData["catching_rating"]; } }
		public int Accuracy  { get { return (GetIntAttribute("throwAccuracyShort_rating") + GetIntAttribute("throwAccuracyMid_rating") + GetIntAttribute("throwAccuracyDeep_rating")) / 3; } }
		public string PassBlock { get { return mData["passBlock_rating"]; } }
		public string ManCoverage { get { return mData["manCoverage_rating"]; } }
		public int PlayerId { get; private set; }
		public int Rating { get; private set; }

		public string GetAttribute(string name)
		{
			if (mData.ContainsKey(name))
				return mData[name];
			else return null;
		}

		public int GetIntAttribute(string name) 
		{
			int retVal = -1;
			if (mData.ContainsKey(name))
				Int32.TryParse(mData[name], out retVal);
			return retVal;
		}
		public void ToJson(StringBuilder sb)
		{
			sb.Append("{");
			int intValue = -1;
			foreach (var item in mData)
			{
				//sb.Append($"\"{item.Key}:{item.Value},");
				sb.Append('"');
				sb.Append(item.Key);
				intValue = GetIntAttribute(item.Key);
				if(intValue > 0)
					sb.Append($"\":{item.Value},");
				else
					sb.Append($"\":\"{item.Value}\",");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append("}");
		}

		public void ToCsv(StringBuilder sb)
		{
			int val;
			foreach( var key in DataFormat.MaddenExportFormat)
			{
				if (key == "routeRunning_rating") {
					val = (GetIntAttribute("mediumRouteRunning_rating") + GetIntAttribute("deepRouteRunning_rating") + GetIntAttribute("shortRouteRunning_rating")) / 3;
					sb.Append( val.ToString());
				}
				else if (key == "throwAccuracy_rating") {
					sb.Append(Accuracy);
				}
				else if ("plyrBirthdate" == key) {
					sb.Append(formatDOB(mData["plyrBirthdate"]));
				}
				else if( key == "totalSalary" || key == "signingBonus")
					sb.Append('0');
				else
					sb.Append(mData[key]);
				sb.Append(",");
			}
		}

		private static readonly char[] slash = { '/' };

		private string formatDOB(string playerDOB)
		{
			// "11/2/1991"
			String retVal = playerDOB;
			var parts = playerDOB.Split(slash);
			// month, day, year 
			if (parts != null && parts.Length > 2 && parts[2].Length == 2)
			{
				var year = Int32.Parse(parts[2]);
				if (year > 60)
					year += 1900;
				else
					year += 2000;
				retVal = parts[0] + "/" + parts[1] + "/" + year;
			}
			else if(playerDOB.IndexOf('-') > 0)
			{
				parts = playerDOB.Split( new char[] {'-'});
				retVal = $"{parts[1]}/{parts[2]}/{parts[0]}";
			}
			return retVal;
		}
	}

	public class PlayerComparer : IComparer<PlayerData>
	{
		public int Compare(PlayerData x, PlayerData y)
		{
			if(x.Position == y.Position)
				return x.Rating.CompareTo(y.Rating);
			else 
				return x.Position.CompareTo(y.Position);
		}
	}

	public class NFL2K5PlayerComparer : IComparer<PlayerData>
	{
		private static readonly List<string> positionOrder = new List<String>( new string[]{
			"QB", "HB", "FB", "WR", "TE", "LT", "RT", "LG", "RG", "C",
			"LE", "RE", "NT", "DT", "OLB", "LOLB", "ROLB", "LILB", "RILB", "MLB", "CB", "SS", "FS", "K", "P"
		});
		private static readonly List<string> teamOrder = new List<String>(new string[]{
			"49ers", "Bears", "Bengals", "Bills", "Broncos", "Browns", "Buccaneers", "Cardinals",
			"Chargers", "Chiefs", "Colts", "Cowboys", "Dolphins", "Eagles", "Falcons", "Giants", "Jaguars",
			"Jets", "Lions", "Packers", "Panthers", "Patriots", "Raiders", "Rams", "Ravens", "Redskins", "Football Team",
			"Saints", "Seahawks", "Steelers", "Texans", "Titans", "Vikings","FreeAgents" 
		});

		public int Compare(PlayerData a, PlayerData b)
		{
			if (a.Team != b.Team)
			{
				if (teamOrder.IndexOf((a.Team)) < teamOrder.IndexOf((b.Team)))
					return -1;
				if (teamOrder.IndexOf((a.Team)) > teamOrder.IndexOf((b.Team)))
					return 1;
				return 0;
			}
			if (a.Position == b.Position)
			{
				if (a.Rating < b.Rating)
					return 1;
				if (a.Rating > b.Rating)
					return -1;
			}
			else
			{
				if (positionOrder.IndexOf(a.Position) < positionOrder.IndexOf(b.Position))
					return -1;
				if (positionOrder.IndexOf(a.Position) > positionOrder.IndexOf(b.Position))
					return 1;
			}
			return 0;
		}
	}
}
