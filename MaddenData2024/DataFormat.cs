using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;

namespace MaddenDataScraper_2024
{
	public class DataFormat
	{
		public static readonly List<String> MaddenImportFormat = new List<string> {
		"team",
			"firstName",
			"lastName",
			"position",
			"jerseyNum",
			"overall_rating",
			"speed_rating",
			"acceleration_rating",
			"strength_rating",
			"agility_rating",
			"awareness_rating",
			"catching_rating",
			"carrying_rating",
			"throwPower_rating",
			//"throwAccuracy_rating",
            "throwAccuracyShort_rating","throwAccuracyMid_rating", "throwAccuracyDeep_rating",
			"kickPower_rating",
			"kickAccuracy_rating",
			"runBlock_rating",
			"passBlock_rating",
			"tackle_rating",
			"jumping_rating",
			"kickReturn_rating",
			"injury_rating",
			"stamina_rating",
			"toughness_rating",
			"trucking_rating",
			"finesseMoves_rating",// replaces -> "elusiveness_rating",
			"bCVision_rating",
			"stiffArm_rating",
			"spinMove_rating",
			"jukeMove_rating",
			"impactBlocking_rating",
			"powerMoves_rating",
			//"finesseMoves_rating", // dup
			"blockShedding_rating",
			"pursuit_rating",
			"playRecognition_rating",
			"manCoverage_rating",
			"zoneCoverage_rating",
			"spectacularCatch_rating",
			"catchInTraffic_rating",
			//"routeRunning_rating",
            "mediumRouteRunning_rating", "deepRouteRunning_rating", "shortRouteRunning_rating",
			"hitPower_rating",
			"press_rating",
			"release_rating",
			"playAction_rating",
			"throwOnTheRun_rating",
			"height",
			"weight",

			/* these were not used in 2016
			"age",
			"runBlockStrength_rating",
			"runBlockFootwork_rating",
			"passBlockStrength_rating",
			"passBlockFootwork_rating",*/

			//* these are new for 2018
			"yearsPro",
			//"totalSalary",
			//"signingBonus",
			"plyrBirthdate",
			"plyrHandedness",
			"college"
			};

		public static readonly string[] MaddenExportFormat = {
			"team",
			"firstName",
			"lastName",
			"position",
			"jerseyNum",
			"overall_rating",
			"speed_rating",
			"acceleration_rating",
			"strength_rating",
			"agility_rating",
			"awareness_rating",
			"catching_rating",
			"carrying_rating",
			"throwPower_rating",
			"throwAccuracy_rating",
			"throwAccuracyShort_rating",
			"throwAccuracyMid_rating",
			"throwAccuracyDeep_rating",
			"kickPower_rating",
			"kickAccuracy_rating",
			"runBlock_rating",
			"passBlock_rating",
			"tackle_rating",
			"jumping_rating",
			"kickReturn_rating",
			"injury_rating",
			"stamina_rating",
			"toughness_rating",
			"trucking_rating",
			"finesseMoves_rating",// replaces -> "elusiveness_rating",
			"bCVision_rating",
			"stiffArm_rating",
			"spinMove_rating",
			"jukeMove_rating",
			"impactBlocking_rating",
			"powerMoves_rating",
			"finesseMoves_rating",
			"blockShedding_rating",
			"pursuit_rating",
			"playRecognition_rating",
			"manCoverage_rating",
			"zoneCoverage_rating",
			"spectacularCatch_rating",
			"catchInTraffic_rating",
			"routeRunning_rating",
			"hitPower_rating",
			"press_rating",
			"release_rating",
			"playAction_rating",
			"throwOnTheRun_rating",
			"height",
			"weight",

			/* these were not used in 2016
			"age",
			"runBlockStrength_rating",
			"runBlockFootwork_rating",
			"passBlockStrength_rating",
			"passBlockFootwork_rating",*/

			//* these are new for 2018
			"yearsPro",
			"totalSalary",
			"signingBonus",
			"plyrBirthdate",
			"plyrHandedness",
			"college",
		};
	}

	public class PlayerAppearanceData
	{
		public string Team { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Skin { get; set; }
		public string Position { get; set; }
		public string PhotoPath { get; set; }
		public Image Photo
		{
			get { 
				if(_img == null && !String.IsNullOrEmpty( PhotoPath) )
				{
					_img = Image.FromFile( PhotoPath );
				}
				return _img;
			}
		}

		private Image _img = null;

		public static List<PlayerAppearanceData> GetAppearanceData(List<String> teams)
		{
			List<PlayerAppearanceData> retVal = new List<PlayerAppearanceData>();
			PlayerAppearanceData p;
			string photoPath;
			string teamFileName = "";
			string rawTeamData = "";
			string skin = "";
			string dataDir = "RawTeamData";
			foreach (var team in teams)
			{
				teamFileName = $"{dataDir}\\{team}.raw.json";
				if (File.Exists(teamFileName))
				{
					rawTeamData = File.ReadAllText(teamFileName);
					var players = DataGatherForm.GetImageDownloadData(rawTeamData);
					// keys ["id", "overallRating", "firstName", "lastName", "jerseyNum", "position.id", "avatarUrl" ]
					foreach (var player in players)
					{
						photoPath = $"Photos\\{team}\\{player["firstName"]}_{player["lastName"]}.png";
						skin = SkinMatcher.MatchSkin(photoPath);
						if (!String.IsNullOrEmpty(skin))
						{
							p = new PlayerAppearanceData() { 
								FirstName = player["firstName"], LastName = player["lastName"], PhotoPath= photoPath,
								Team = team, Skin = skin, Position = player["position.id"]
							};
							retVal.Add( p );
						}
					}
				}
				else
				{
					Console.WriteLine($"Error! Could not Find file {teamFileName}; Need to run Gather Data operation? Skipping {team}");
				}
			}
			return retVal;
		}
	}
}
