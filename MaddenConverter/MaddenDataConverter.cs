using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaddenConverter
{
	public class MaddenDataConverter
	{
		public MaddenDataConverter()
		{
			keys = AttributeString.Split(new char[] { ',' });
		}

		string[] keys = null;
		private PlayerAppearance mPlayerAppearance = null;
		//Madden 2018
		string mMadden2018Attributes = "Team,First Name,Last Name,Position,Jersey,OVR,Speed,Acceleration,Strength,Agility,Awareness," +
					 "Catching,Carrying,Throw Power,Throw Accuracy,Throw Accuracy Short,Throw Accuracy Mid,Throw Accuracy Deep,Kick Power," +
					 "Kick Accuracy,Run Block,Pass Block,Tackle,Jumping,Kick Return,Injury,Stamina,Toughness,Trucking,Elusiveness," +
					 "Ball Carrier Vision,Stiff Arm,Spin Move,Juke Move,Impact Block,Power Moves,Finesse Moves,Block Shedding,Pursuit," +
					 "Play Recognition,Man Cover,Zone Cover,Spectactular Catch,Catch In Traffic,Route Running,Hit Power,Press," +
					 "Release,Play Action,Throw On The Run,Height,Weight,yearsPro,totalSalary,signingBonus,plyrBirthdate,plyrHandedness,college";
		private string AttributeString
		{
			get
			{
				return mMadden2018Attributes;
			}
		}

		public String ConvertData(string data)
		{
			mPlayerAppearance = new PlayerAppearance();
			

			string output = Convert(data);
			return output;
		}
		private string GetKey2018()
		{
			return "Key=fname,lname,Position,JerseyNumber,Speed,Agility,Strength,Jumping,Coverage,PassRush,RunCoverage,PassBlocking,RunBlocking,Catch,RunRoute,BreakTackle,HoldOntoBall,PowerRunStyle,PassAccuracy,PassArmStrength,PassReadCoverage,Tackle,KickPower,KickAccuracy,Stamina,Durability,Leadership,Scramble,Composure,Consistency,Aggressiveness,College,DOB,Hand,Weight,Height,BodyType,Skin,Face,Dreads,Helmet,FaceMask,Visor,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck,YearsPro\r\n\r\n";
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

		private string Convert(string input)
		{
			int players = 0;
			input = input.Replace("\r\n", "\n");
			string[] lines = input.Split(new char[] { '\n' });
			StringBuilder builder = new StringBuilder(input.Length);
			string team = "";
			string tmpTeam = "";
			mPlayerAppearance.Initialize();
			builder.Append(GetKey2018());
			string current_line = "";

			try
			{
				foreach (string line in lines)
				{
					current_line = line;
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
						team = tmpTeam;
						builder.Append("Team = ");
						builder.Append(team);
						builder.Append("\r\n");
						players = 0;
					}
					ConvertPlayerFromMadden2018(playerData, builder);
					players++;
					builder.Append("\r\n");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Error with line:\n'" + current_line + "'", "Data not applied", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "";
			}
			builder.Append("AutoUpdateDepthChart\r\n");
			builder.Append("AutoUpdatePBP\r\n");
			builder.Append("AutoUpdatePhoto\r\n");
			builder.Append("AutoUpdateSpecialTeamsDepth \r\n");

			return builder.ToString();
		}

		//Key=fname,lname,Position,JerseyNumber,Speed,Agility,Strength,Jumping,Coverage,PassRush,RunCoverage,PassBlocking,RunBlocking,Catch,RunRoute,BreakTackle,HoldOntoBall,PowerRunStyle,PassAccuracy,PassArmStrength,PassReadCoverage,Tackle,KickPower,KickAccuracy,Stamina,Durability,Leadership,Scramble,Composure,Consistency,Aggressiveness,College,DOB,Hand,Weight,Height,BodyType,Skin,Face,Dreads,Helmet,FaceMask,Visor,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck,YearsPro
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
			AddAttribute((GetIntAttribute("Throw Accuracy Short", playerData) +
						  GetIntAttribute("Throw Accuracy Mid", playerData) +
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
	}
}
