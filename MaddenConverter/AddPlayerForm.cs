using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace MaddenConverter
{
    public partial class AddPlayerForm : Form
    {
        private Dictionary<string, string> mTeamMap = new Dictionary<string, string>();

        public AddPlayerForm()
        {
            InitializeComponent();
            string[] stuff = {
                "SF", "49ers", "BAL", "Ravens", "CIN", "Bengals", "IND", "Colts",  "CLE", "Browns", "PIT", "Steelers", "HOU", "Texans",
                "JAC", "Jaguars", "TEN", "Titans", "BUF", "Bills", "MIA", "Dolphins", "NE", "Patriots", "NYJ", "Jets", "DEN", "Broncos",
                "KC", "Chiefs", "OAK", "Raiders", "SD", "Chargers", "CHI", "Bears", "DET", "Lions", "GB", "Packers", "MIN", "Vikings",
                "ATL", "Falcons", "CAR", "Panthers", "NO", "Saints", "TB", "Buccaneers", "DAL", "Cowboys", "NYG", "Giants", "PHI", "Eagles",
                "WAS", "Redskins", "ARI", "Cardinals", "SEA", "Seahawks", "STL", "Rams" 
              };
            for (int i = 0; i < stuff.Length; i += 2)
            {
                mTeamMap.Add(stuff[i], stuff[i + 1]);
            }
        }

        public PlayerAppearance PlayerAppearance;

        private DataGridViewRow GetRow()
        {
            return (DataGridViewRow)dataGridView1.Rows[0].Clone();
        }

        /// <summary>
        /// Takes in the NFL2K player text
        /// Adds the players in this form
        /// Increments the players on the teams
        /// </summary>
        /// <param name="seasonData"></param>
        /// <returns></returns>
        public string AddPlayers(string seasonData)
        {
            string player, team;
            // first format the player, then find the proper place to add him, increment the team number
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++ )
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    team = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (mTeamMap.ContainsKey(team))
                        team = mTeamMap[team];

                    player = GetPlayer(i);
                    seasonData = InsertPlayer(player, team, seasonData);
                }
            }
            return seasonData;
        }

        /// <summary>
        /// iniserts the player to the end of the team list, increments the team player count in the text
        /// </summary>
        /// <param name="player"></param>
        /// <param name="team"></param>
        /// <param name="seasonData"></param>
        /// <returns></returns>
        private string InsertPlayer(string player, string team, string seasonData)
        {
            string retVal = seasonData;
            //# Team:Buccaneers  players: xx
            Regex reg = new Regex("# Team:" + team + "  players: ([0-9]+)");
            Match m = reg.Match(seasonData);
            if (m != Match.Empty)
            {
                int newNumber = Int32.Parse(m.Groups[1].ToString()) + 1;
                if (newNumber > 54)
                    return retVal;

                StringBuilder builder = new StringBuilder(seasonData.Substring(0, m.Index));
                builder.Append(player);
                
                builder.Append("\r\n# Team:");
                builder.Append(team);
                builder.Append("  players: ");
                builder.Append(newNumber);
                builder.Append(seasonData.Substring(m.Index+ m.Groups[0].Length));
                retVal = builder.ToString();
            }
            return retVal;
        }

        public string GetPlayer(int rowNumber)
        {
            StringBuilder builder = new StringBuilder();
            DataGridViewRow row = this.dataGridView1.Rows[rowNumber];

            builder.Append(row.Cells[2].Value); builder.Append(",");// fname 
            builder.Append(row.Cells[3].Value); builder.Append(",");//lname
            builder.Append(row.Cells[4].Value); builder.Append(",");//pos
            builder.Append(row.Cells[1].Value); builder.Append(",");//jersey #

            for (int i = 5; i < 31; i++)
            {
                builder.Append(row.Cells[i].Value);
                builder.Append(",");
            }
            //builder.Remove(builder.Length - 1, 1);// remove last comma

            string pos = GetPosition(row.Cells[4].Value.ToString());
            builder.Append( this.PlayerAppearance.GetAppearance(row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), pos, GetHeight(pos), GetWeight(pos), row.Cells[1].Value.ToString()));
            return builder.ToString();
        }

        private string GetHeight(string pos)
        {
            string retVal = "6'0\"";
            switch (pos)
            {
                case "DT":
                case "G":
                case "T":
                case "C":
                    retVal = "6'5\"";
                    break;
                case "TE":
                    retVal = "6'4\"";
                    break;
                case "QB":
                    retVal = "6'3\"";
                    break;
            }

            return retVal;
        }

        private string GetPosition(string p)
        {
            string retVal = p;
            switch (p)
            {
                case "MLB": retVal = "ILB"; break;
                case "LB": retVal = "OLB"; break;
                case "OT": retVal = "T"; break;
                case "OG": retVal = "G"; break;
                case "NT": retVal = "DT"; break;
                case "DB": retVal = "CB"; break;
            }
            return retVal;
        }

        private string GetWeight(string pos)
        {
            string retVal = "200";
            switch (pos)
            {
                case "FB":
                case "ILB":
                case "OLB":
                    retVal = "234";
                    break;
                case "DT":
                case "G":
                case "T":
                case "C":
                    retVal = "300";
                    break;
                case "TE":
                    retVal = "260";
                    break;
            }

            return retVal;
        }

        public string Output
        {
            get
            {
                StringBuilder builder = new StringBuilder(10000);
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < 31; i++)
                    {
                        builder.Append(row.Cells[i].Value);
                        builder.Append(",");
                    }
                    builder.Remove(builder.Length - 1, 1);// remove last comma
                    builder.Append("\r\n");
                }
                return builder.ToString();
            }
        }

        public void SetInput(string input)
        {
            int index = 0;
            string team = "";
            string position = "";
            string number = "";
            string firstName = "";
            string lastName = "";

            char[] tab = new char[] { '\t' };
            char[] comma = new char[] {','};

            string[] parts;
            //this.dataGridView1
            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            String[] lines = input.Replace("\r\n", "\n").Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                parts = line.Split(tab);
                if (parts.Length > 4)
                {
                    index = line.LastIndexOf('\t');
                    team = line.Substring(index + 1).Trim();
                    position = GetPosition( parts[0]);
                    number = parts[1];
                    firstName = parts[2].Replace(" ", "").Split(comma)[1];
                    lastName = parts[2].Replace(" ", "").Split(comma)[0];
                    DataGridViewRow row = GetRow();
                    row.Cells[2].Value = firstName;
                    row.Cells[3].Value = lastName;
                    row.Cells[0].Value = team;
                    row.Cells[4].Value = position;
                    row.Cells[1].Value = number;

                    object[] attrs = GetDefaultAttributes(position);
                    for(int i = 0; i < attrs.Length; i++)
                        row.Cells[i+5].Value = attrs[i];

                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private object[] GetDefaultAttributes(string pos)
        {
            object[] retVal = null;
            switch (pos)
            {
                case "QB": retVal = new object[] { 72, 64, 57, 72, 17, 23, 27, 15, 20, 35, 10, 43, 85, "Balanced", 73, 83, 54, 30, 25, 25, 92, 94, 54, 78, 52, 54};break;
                case "RB": retVal = new object[] { 83, 79, 69, 84, 12, 10, 20, 55, 45, 71, 49, 84, 80, "Balanced", 23, 25, 10, 29, 21, 20, 80, 77, 55, 42, 53, 55}; break;
                case "FB": retVal = new object[] { 89,76,78,66,82,17,27,37,71,85,78,65,64,79,"Power",10,19,10,39,19,19,85,93,74,30,72,74 };break;
                case "WR": retVal = new object[] { 89,84,68,88,18,53,54,45,47,74,57,70,75,"Finesse",10,30,10,52,25,20,84,73,65,38,63,65}; break;
                case "TE": retVal = new object[] { 85, 83, 67, 90, 16, 37, 35, 54, 68, 72, 58, 67, 72, "Finesse", 10, 35, 10, 39, 30, 30, 85, 77, 52, 36, 50, 52 }; break;
                case "T":
                case "G":
                case "C": retVal = new object[] { 62, 69, 87, 44, 10, 16, 17, 80, 82, 16, 20, 10, 85, "Power", 6, 33, 10, 22, 33, 36, 87, 80, 86, 24, 84, 86 }; break;

                case "P":
                case "K": retVal = new object[] { 69, 55, 40, 25, 14, 28, 30, 17, 16, 23, 15, 10, 70, "Balanced", 15, 40, 10, 29, 88, 93, 75, 84, 74, 33, 72, 74 }; break;

                case "DT":
                case "DE": retVal = new object[] { 65, 67, 83, 77, 32, 80, 79, 45, 45, 35, 10, 55, 72, "Balanced", 10, 35, 10, 79, 30, 30, 78, 91, 75, 28, 73, 75}; break;
                case "ILB":
                case "OLB": retVal = new object[] { 75, 81, 65, 67, 74, 69, 78, 45, 45, 65, 15, 45, 87, "Balanced", 6, 25, 10, 84, 20, 20, 91, 87, 80, 30, 78, 80}; break;
                case "CB":
                case "SS":
                case "FS": retVal = new object[] { 88, 89, 73, 93, 71, 56, 64, 45, 45, 62, 20, 56, 75, "Balanced", 11, 30, 10, 66, 25, 25, 85, 88, 40, 39, 38, 40 }; break;
            }
            return retVal;
        }
    }
}
