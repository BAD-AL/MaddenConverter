using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MaddenConverter
{
    public partial class MainForm : Form
    {
        //Madden 2016
        string mMadden2016Attributes = "Team,First Name,Last Name,Position,Jersey Number,OVR,Speed,Acceleration,Strength,Agility,Awareness," +
                     "Catching,Carrying,Throw Power,Throw Accuracy Short,Throw Accuracy Mid,Throw Accuracy Deep,Kick Power,"+
                     "Kick Accuracy,Run Block,Pass Block,Tackle,Jumping,Kick Return,Injury,Stamina,Toughness,Trucking,Elusiveness,"+
                     "Ball Carrier Vision,Stiff Arm,Spin Move,Juke Move,Impact Block,Power Moves,Finesse Moves,Block Shedding,Pursuit,"+
                     "Play Recognition,Man Coverage,Zone Coverage,Spectactular Catch,Catch In Traffic,Route Running,Hit Power,Press,"+
                     "Release,Play Action,Throw On The Run,Height,Weight";
        // madden 2017
        string mMadden2017Attributes = "Team,First Name,Last Name,Position,Jersey,Overall,Speed,Stength,Agility,Awareness,Catching,Carrying,Throw Power,"+
                     "Throw Accuracy,Kick Power,Kick Accuracy,Run Block,Pass Block,Tackle,Jumping,Kick Return,Injury,Stamina,Toughness,Age,"+
                     "Years Pro,College,Home State,Hometown,Trucking,Elusiveness,Ball Carrier Vision,Stiff Arm,Spin Move,Juke Move,Impact Block,"+
                     "Run Block Strength,Run Block Footwork,Pass Block Strength,Pass Block Footwork,Power Moves,Finnesse Moves,Block Shedding,Pursuit,"+
                     "Play Recognition,Man Cover,Zone cover,Spectacular Catch,Catch in Traffic,Route Running,Hit Power,Press,Release,Short Throw Accuracy,"+
                     "Medium Throw Accuracy,Deep Throw Accuracy,Playaction,Throw on the Run";/**/

        //Madden 2018
        string mMadden2018Attributes = "Team,First Name,Last Name,Position,Jersey Number,OVR,Speed,Acceleration,Strength,Agility,Awareness," +
                     "Catching,Carrying,Throw Power,Throw Accuracy,Throw Accuracy Short,Throw Accuracy Mid,Throw Accuracy Deep,Kick Power," +
                     "Kick Accuracy,Run Block,Pass Block,Tackle,Jumping,Kick Return,Injury,Stamina,Toughness,Trucking,Elusiveness," +
                     "Ball Carrier Vision,Stiff Arm,Spin Move,Juke Move,Impact Block,Power Moves,Finesse Moves,Block Shedding,Pursuit," +
                     "Play Recognition,Man Coverage,Zone Coverage,Spectactular Catch,Catch In Traffic,Route Running,Hit Power,Press," +
                     "Release,Play Action,Throw On The Run,Height,Weight";

        string[] keys = null;

        PlayerAppearance mPlayerAppearance = null;

        private String NFLPlayers = "";

        StringBuilder ErrorString = new StringBuilder();

        public MainForm()
        {
            InitializeComponent();
            //keys = mMadden2016Attributes.Split(new char[] {','});
            keys = mMadden2018Attributes.Split(new char[] { ',' });
            NFLPlayers = System.IO.File.ReadAllText("NFLPlayers.txt");
            NFLPlayers = NFLPlayers.Replace("\r\n", "\n");
        }

        private string GetAttribute(string attribute, string[] playerData)
        {
            int index = GetAttributeIndex(attribute);
            return playerData[index];
        }

        private int GetIntAttribute(string attribute, string[] playerData)
        {
            string attr = GetAttribute(attribute, playerData);
            return Int32.Parse(attr);
        }

        private int GetAttributeIndex(string attribute)
        {
            int ret = -1;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == attribute)
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }
        
        private void mGoButton_Click(object sender, EventArgs e)
        {
            if (mPlayerAppearance == null)
                mPlayerAppearance = new PlayerAppearance();

            string output = Convert(textBox1.Text);
            textBox2.Text = output;

            if (mPlayerAppearance.MissedPlayers.Length > 0)
            {
                TextDisplay disp = new TextDisplay();
                disp.Text = "Players to Check";
                disp.Content = mPlayerAppearance.MissedPlayers;
                disp.Show();
            }

            TextDisplay disp2 = new TextDisplay();
            disp2.Text = "Missing Players";
            disp2.Content = FindMissingPlayers();
            disp2.Show();
            
        }

        private string FindMissingPlayers()
        {
            StringBuilder builder = new StringBuilder();

            string name ="";
            int index = -1;
            string[] parts = null;
            char[] tab = new char[]{ '\t'};
            char[] space = new char[] { ' '};
            String[] lines = NFLPlayers.Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                parts = line.Split(tab);
                if (parts.Length > 5 && line.IndexOf("\tACT\t") > -1)
                {
                    name = parts[2].Replace(",", "");
                    parts = name.Split(space);
                    name = parts[1] + "," + parts[0];

                    index = textBox2.Text.IndexOf(name);
                    if (index < 0)
                    {
                        builder.Append(line);
                        builder.Append("\r\n");
                    }
                }
            }
            return builder.ToString();
        }

        private string GetLine(String text)
        {
            string ret = "";
            int index = NFLPlayers.IndexOf(text);
            if (index > -1)
            {
                int i, startIndex, endIndex;
                for (i = index; i > 0 && NFLPlayers[i] != '\n'; i--) ;
                startIndex = i;
                for (i = index; i < NFLPlayers.Length && NFLPlayers[i] != '\n'; i++) ;
                endIndex = i;
                ret = NFLPlayers.Substring(startIndex, endIndex - startIndex);
            }

            return ret;
        }

        /// <summary>
        /// Converts from madden ratings to NFL2K ratings
        /// </summary>
        private string Convert(string input)
        {
            int players = 0;
            input = input.Replace("\r\n", "\n");
            string[] lines = input.Split(new char[] { '\n' });
            StringBuilder builder = new StringBuilder(input.Length);
            string team = "";
            string tmpTeam = "";
            mPlayerAppearance.Initialize();
            
            foreach (string line in lines)
            {
                if (line.StartsWith("#") || line.Length < 15) // comment
                {
                    continue; // skip the line
                }
                string[] playerData = line.Split(new char[] { ',' });
                tmpTeam = GetAttribute("Team", playerData);
                if (tmpTeam != team)
                {
                    if (team.Length > 0)
                    {
                        builder.Append("# Team:" + team + " players: " + players + "\r\n");
                    }
                    if (team == "")
                        builder.Append("#");
                    team = tmpTeam;
                    builder.Append("Team = ");
                    builder.Append(team);
                    builder.Append("\r\n");
                    players = 0;
                }
                if (IncludePlayer(playerData))
                {
                    //ConvertPlayerFromMadden2016(playerData, builder);
                    //ConvertPlayerFromMadden2017(playerData, builder);
                    ConvertPlayerFromMadden2018(playerData, builder);
                    players++;
                    builder.Append("\r\n");
                }
            }
            return builder.ToString();
        }

        private bool IncludePlayer(string[] playerData)
        {
            bool ret = false;
            string searchString = GetAttribute("Last Name", playerData) +", " + GetAttribute("First Name", playerData);

            string playerLine = GetLine(searchString);
            if (playerLine.Length > 0)
            {
                if (playerLine.IndexOf("	ACT") > -1)
                    ret = true;
            }
            return ret;
        }

        //To data like:
        // #fname,lname,position,number,Speed,Agility,Strength,Jumping,Coverage,PassRush,RunCoverage,PassBlocking,RunBlocking,
        // Catch,RunRoute,BreakTackle,HoldOnToBall,PowerRunStyle,PassAccuracy,PassArmStrength,PassReadCoverage,Tackle,KickPower,
        // KickAccuracy,Stamana,Durability,Leadership,Scramble,Composure,Consistency,Aggressiveness,College,DOB,Hand,Weight,Height,
        // BodyType,Skin,Face,Dreads,Helmet,FaceMask,FaceShield,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,
        // LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck

        private void ConvertPlayerFromMadden2016(string[] playerData, StringBuilder builder)
        {
            String position = MapPosition( GetAttribute("Position", playerData));
            AddAttribute(GetAttribute("First Name", playerData), builder);
            AddAttribute(GetAttribute("Last Name", playerData), builder);
            AddAttribute(position, builder);
            AddAttribute(GetAttribute("Jersey Number", playerData), builder);
            AddAttribute(GetAttribute("Speed", playerData), builder); // Speed
            AddAttribute(GetAttribute("Agility", playerData), builder); // Agility
            AddAttribute(GetAttribute("Strength", playerData), builder); // Strength
            AddAttribute(GetAttribute("Jumping", playerData), builder); // Jumping
            AddAttribute((GetIntAttribute("Man Coverage", playerData) + GetIntAttribute("Zone Coverage", playerData)) / 2, builder); //Coverage
            AddAttribute(( (GetIntAttribute("Block Shedding", playerData) * 4) +
                           GetIntAttribute("Play Recognition", playerData)) / 5, builder); //PassRush
            AddAttribute(((GetIntAttribute("Block Shedding", playerData)) +
                           GetIntAttribute("Pursuit", playerData)) / 2, builder); //RunCoverage

            AddAttribute(GetAttribute("Pass Block", playerData), builder); // Pass blocking
            AddAttribute(GetAttribute("Run Block", playerData), builder); //Run blocking
            AddAttribute(GetAttribute("Catching", playerData), builder); // Catch
            AddAttribute(GetAttribute("Route Running", playerData), builder); // Run Route
            AddAttribute(GetAttribute("Trucking", playerData), builder); // Break Tackle
            AddAttribute(GetAttribute("Toughness", playerData), builder); // HoldOnToBall
            AddAttribute(GetPowerRunStyle(playerData), builder);// PowerRunStyle (Finesse, Balance, Power)
            AddAttribute((GetIntAttribute("Throw Accuracy Short", playerData) +
                          GetIntAttribute("Throw Accuracy Mid",   playerData)  +
                          GetIntAttribute("Throw Accuracy Deep", playerData)) / 3, builder); //Pass Accuracy

            AddAttribute(GetAttribute("Throw Power", playerData), builder); // PassArm Strength
            AddAttribute(GetPassReadCoverage(playerData), builder); // PassReadCoverage
            AddAttribute(GetAttribute("Tackle", playerData), builder); // Tackle
            AddAttribute(GetAttribute("Kick Power", playerData), builder);// KickPower
            AddAttribute(GetAttribute("Kick Accuracy", playerData), builder); // Kick Accuracy
            AddAttribute(GetAttribute("Stamina", playerData), builder); // Stamina
            AddAttribute(GetAttribute("Injury", playerData), builder); // Durability
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Leadership
            AddAttribute(((GetIntAttribute("Throw On The Run", playerData) +
                           GetIntAttribute("Speed", playerData)) +
                           GetIntAttribute("Throw Accuracy Short", playerData)) / 3, builder); // Scramble
            AddAttribute(GetIntAttribute("Awareness", playerData)-2, builder); // Composure
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Consistency
            AddAttribute(GetAttribute("Hit Power", playerData), builder); // Aggressiveness

            builder.Append(
            mPlayerAppearance.GetAppearance(GetAttribute("First Name", playerData), GetAttribute("Last Name", playerData), position,
                GetAttribute("Height", playerData), GetAttribute("Weight", playerData), GetAttribute("Jersey Number", playerData))
                );
        }

        private void ConvertPlayerFromMadden2017(string[] playerData, StringBuilder builder)
        {
            String position = MapPosition(GetAttribute("Position", playerData));
            AddAttribute(GetAttribute("First Name", playerData), builder);
            AddAttribute(GetAttribute("Last Name", playerData), builder);
            AddAttribute(position, builder);
            AddAttribute(GetAttribute("Jersey", playerData), builder);
            AddAttribute(GetAttribute("Speed", playerData), builder); // Speed
            AddAttribute(GetAttribute("Agility", playerData), builder); // Agility
            AddAttribute(GetAttribute("Strength", playerData), builder); // Strength
            AddAttribute(GetAttribute("Jumping", playerData), builder); // Jumping
            AddAttribute((GetIntAttribute("Man Cover", playerData) + GetIntAttribute("Zone Cover", playerData)) / 2, builder); //Coverage
            AddAttribute(((GetIntAttribute("Block Shedding", playerData) * 4) +
                           GetIntAttribute("Play Recognition", playerData)) / 5, builder); //PassRush
            AddAttribute(((GetIntAttribute("Block Shedding", playerData)) +
                           GetIntAttribute("Pursuit", playerData)) / 2, builder); //RunCoverage

            AddAttribute(GetAttribute("Pass Block", playerData), builder); // Pass blocking
            AddAttribute(GetAttribute("Run Block", playerData), builder); //Run blocking
            AddAttribute(GetAttribute("Catching", playerData), builder); // Catch
            AddAttribute(GetAttribute("Route Running", playerData), builder); // Run Route
            AddAttribute(GetAttribute("Trucking", playerData), builder); // Break Tackle
            AddAttribute(GetAttribute("Toughness", playerData), builder); // HoldOnToBall
            AddAttribute(GetPowerRunStyle(playerData), builder);// PowerRunStyle (Finesse, Balance, Power)
            AddAttribute((GetIntAttribute("Short Throw Accuracy", playerData) +
                          GetIntAttribute("Medium Throw Accuracy", playerData) +
                          GetIntAttribute("Deep Throw Accuracy", playerData)) / 3, builder); //Pass Accuracy

            AddAttribute(GetAttribute("Throw Power", playerData), builder); // PassArm Strength
            AddAttribute(GetPassReadCoverage(playerData), builder); // PassReadCoverage
            AddAttribute(GetAttribute("Tackle", playerData), builder); // Tackle
            AddAttribute(GetAttribute("Kick Power", playerData), builder);// KickPower
            AddAttribute(GetAttribute("Kick Accuracy", playerData), builder); // Kick Accuracy
            AddAttribute(GetAttribute("Stamina", playerData), builder); // Stamina
            AddAttribute(GetAttribute("Injury", playerData), builder); // Durability
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Leadership
            AddAttribute(((GetIntAttribute("Throw On The Run", playerData) +
                           GetIntAttribute("Speed", playerData)) +
                           GetIntAttribute("Short Throw Accuracy", playerData)) / 3, builder); // Scramble
            AddAttribute(GetIntAttribute("Awareness", playerData) - 2, builder); // Composure
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Consistency
            AddAttribute(GetAttribute("Hit Power", playerData), builder); // Aggressiveness

            builder.Append(
            mPlayerAppearance.GetAppearance(GetAttribute("First Name", playerData), GetAttribute("Last Name", playerData), position,
                GetAttribute("Height", playerData), GetAttribute("Weight", playerData), GetAttribute("Jersey", playerData))
                );
        }

        private void ConvertPlayerFromMadden2018(string[] playerData, StringBuilder builder)
        {
            String position = MapPosition(GetAttribute("Position", playerData));
            AddAttribute(GetAttribute("First Name", playerData), builder);
            AddAttribute(GetAttribute("Last Name", playerData), builder);
            AddAttribute(position, builder);
            AddAttribute(GetAttribute("Jersey", playerData), builder);
            AddAttribute(GetAttribute("Speed", playerData), builder); // Speed
            AddAttribute(GetAttribute("Agility", playerData), builder); // Agility
            AddAttribute(GetAttribute("Strength", playerData), builder); // Strength
            AddAttribute(GetAttribute("Jumping", playerData), builder); // Jumping
            AddAttribute((GetIntAttribute("Man Cover", playerData) + GetIntAttribute("Zone Cover", playerData)) / 2, builder); //Coverage
            AddAttribute(((GetIntAttribute("Block Shedding", playerData) * 4) +
                           GetIntAttribute("Play Recognition", playerData)) / 5, builder); //PassRush
            AddAttribute(((GetIntAttribute("Block Shedding", playerData)) +
                           GetIntAttribute("Pursuit", playerData)) / 2, builder); //RunCoverage

            AddAttribute(GetAttribute("Pass Block", playerData), builder); // Pass blocking
            AddAttribute(GetAttribute("Run Block", playerData), builder); //Run blocking
            AddAttribute(GetAttribute("Catching", playerData), builder); // Catch
            AddAttribute(GetAttribute("Route Running", playerData), builder); // Run Route
            AddAttribute(GetAttribute("Trucking", playerData), builder); // Break Tackle
            AddAttribute(GetAttribute("Toughness", playerData), builder); // HoldOnToBall
            AddAttribute(GetPowerRunStyle(playerData), builder);// PowerRunStyle (Finesse, Balance, Power)
            AddAttribute((GetIntAttribute("Short Throw Accuracy", playerData) +
                          GetIntAttribute("Medium Throw Accuracy", playerData) +
                          GetIntAttribute("Deep Throw Accuracy", playerData)) / 3, builder); //Pass Accuracy

            AddAttribute(GetAttribute("Throw Power", playerData), builder); // PassArm Strength
            AddAttribute(GetPassReadCoverage(playerData), builder); // PassReadCoverage
            AddAttribute(GetAttribute("Tackle", playerData), builder); // Tackle
            AddAttribute(GetAttribute("Kick Power", playerData), builder);// KickPower
            AddAttribute(GetAttribute("Kick Accuracy", playerData), builder); // Kick Accuracy
            AddAttribute(GetAttribute("Stamina", playerData), builder); // Stamina
            AddAttribute(GetAttribute("Injury", playerData), builder); // Durability
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Leadership
            AddAttribute(((GetIntAttribute("Throw On The Run", playerData) +
                           GetIntAttribute("Speed", playerData)) +
                           GetIntAttribute("Short Throw Accuracy", playerData)) / 3, builder); // Scramble
            AddAttribute(GetIntAttribute("Awareness", playerData) - 2, builder); // Composure
            AddAttribute(GetAttribute("Awareness", playerData), builder); // Consistency
            AddAttribute(GetAttribute("Hit Power", playerData), builder); // Aggressiveness

            builder.Append(
            mPlayerAppearance.GetAppearance2018(GetAttribute("First Name", playerData), GetAttribute("Last Name", playerData), position,
                GetAttribute("Height", playerData), GetAttribute("Weight", playerData), GetAttribute("Jersey", playerData),
                GetAttribute("yearsPro", playerData), GetAttribute("plyrBirthdate", playerData), GetAttribute("plyrHandedness", playerData), GetAttribute("college", playerData)
                ));
        }

        private string MapPosition(string pos)
        {
            string ret = pos;
            switch (pos)
            {
                case "RG":
                case "LG":
                    ret = "G"; break;
                case "LT":
                case "RT":
                    ret = "T"; break;
                case "MLB":
                    ret = "ILB"; break;
                case "ROLB":
                case "LOLB": 
                    ret = "OLB"; break;
                case "LE":
                case "RE": 
                    ret = "DE"; break;
                case "HB":
                    ret = "RB"; break;
            }
            return ret;
        }


        private string GetPassReadCoverage(string[] playerData)
        {
            string ret = "10";
            string pos = GetAttribute("Position", playerData);
            if (pos == "QB")
            {
                ret = GetAttribute("Awareness", playerData);
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerData"></param>
        /// <returns>(Finesse, Balance, Power)</returns>
        private string GetPowerRunStyle(string[] playerData)
        {
            string ret = "Balanced"; // spin move, Strength
            int spin = GetIntAttribute("Spin Move", playerData);
            int strength = GetIntAttribute("Strength", playerData);
            if (spin > strength)
                ret = "Finesse";
            else if (strength > 84)
                ret = "Power";
            return ret;
        }

        private void AddAttribute(object attr, StringBuilder builder)
        {
            builder.Append(attr.ToString());
            builder.Append(",");
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box != null)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    box.SelectAll();
                }
            }
        }

        private void mAddPlayers_Click(object sender, EventArgs e)
        {
            string missingPlayers = FindMissingPlayers();
            AddPlayerForm form = new AddPlayerForm();
            form.SetInput(missingPlayers);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                form.PlayerAppearance = this.mPlayerAppearance;
                string output = form.AddPlayers(this.textBox2.Text);
                this.textBox2.Text = output;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegexForm r = new RegexForm();
            r.Show();
        }
        
    }

}
