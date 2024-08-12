using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace MaddenDataScraper_2024
{
	internal static class Program
	{
		public static string BaseUrl = "https://www.ea.com/_next/data/dp0I8oiML_mo9EUuT_Jyd/en/games/madden-nfl/ratings/teams-ratings";

		static Dictionary<String, String> team_Urls = null;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			InitializeTeamData();
			/*List<String> teams = GetTeams();
			foreach (String team in teams) {
				Console.WriteLine(GetTeamDataUrl(team));
			}*/
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DataGatherForm());
		}

		public static void Colorize(Regex reg, Color color, RichTextBox textBox)
		{
			textBox.Visible = false;
			textBox.SelectionLength = 0;
			MatchCollection mc = reg.Matches(textBox.Text);
			foreach (Match m in mc)
			{
				textBox.SelectionStart = m.Index;
				textBox.SelectionLength = m.Length;// -1;
				textBox.SelectionColor = color;
			}
			textBox.Visible = true;
		}

		public static List<String> GetTeams()
		{
			List<String> teams = new List<String>();
			foreach (var kvp in team_Urls)
			{
				teams.Add(kvp.Key);
			}
			return teams;
		}

		private static void InitializeTeamData()
		{
			team_Urls = new Dictionary<String,String>();
			team_Urls.Add("Bears",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/chicago-bears/1");
			team_Urls.Add("Bengals",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/cincinnati-bengals/2");
			team_Urls.Add("Bills",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/buffalo-bills/3");
			team_Urls.Add("Broncos",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/denver-broncos/4");
			team_Urls.Add("Browns",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/cleveland-browns/5");
			team_Urls.Add("Buccaneers", "https://www.ea.com/games/madden-nfl/ratings/teams-ratings/tampa-bay-buccaneers/6");
			team_Urls.Add("Cardinals",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/arizona-cardinals/7");
			team_Urls.Add("Chargers",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/los-angeles-chargers/8");
			team_Urls.Add("Chiefs",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/kansas-city-chiefs/9");
			team_Urls.Add("Colts",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/indianapolis-colts/10");
			team_Urls.Add("Cowboys",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/dallas-cowboys/11");
			team_Urls.Add("Dolphins",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/miami-dolphins/12");
			team_Urls.Add("Eagles",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/philadelphia-eagles/13");
			team_Urls.Add("Falcons",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/atlanta-falcons/14");
			team_Urls.Add("49ers",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/san-francisco-49ers/15");
			team_Urls.Add("Giants",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/n-y-giants/16");
			team_Urls.Add("Jaguars",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/jacksonville-jaguars/17");
			team_Urls.Add("Jets",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/n-y-jets/18");
			team_Urls.Add("Lions",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/detroit-lions/19");
			team_Urls.Add("Packers",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/green-bay-packers/20");
			team_Urls.Add("Panthers",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/carolina-panthers/21");
			team_Urls.Add("Patriots",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/new-england-patriots/22");
			team_Urls.Add("Raiders",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/las-vegas-raiders/23");
			team_Urls.Add("Rams",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/los-angeles-rams/24");
			team_Urls.Add("Ravens",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/baltimore-ravens/25");
			team_Urls.Add("Redskins",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/washington-commanders/26");
			team_Urls.Add("Saints",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/new-orleans-saints/27");
			team_Urls.Add("Seahawks",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/seattle-seahawks/28");
			team_Urls.Add("Steelers",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/pittsburgh-steelers/29");
			team_Urls.Add("Titans",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/tennessee-titans/30");
			team_Urls.Add("Vikings",	"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/minnesota-vikings/31");
			team_Urls.Add("Texans",		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/houston-texans/32");
		}

		static Regex reg1 = new Regex("teams-ratings/(a-z49-)+/(0-9)+");

		/// <summary>
		/// Turn 
		///		"https://www.ea.com/games/madden-nfl/ratings/teams-ratings/indianapolis-colts/10"
		/// into 
		///		"https://www.ea.com/_next/data/dp0I8oiML_mo9EUuT_Jyd/en/games/madden-nfl/ratings/teams-ratings/kansas-city-chiefs/9.json?franchiseSlug=madden-nfl&pageType=teams-ratings&id=kansas-city-chiefs&id=9"
		/// </summary>
		/// <param name="team"></param>
		/// <returns></returns>
		public static string GetTeamDataUrl(string team)
		{
			string base_url = team_Urls[team];
			int lastSlash = base_url.LastIndexOf('/');
			int teamSlash = lastSlash - 1;
			while (base_url[teamSlash] != '/') teamSlash--;
			string teamIdName = team_Urls[team].Substring(teamSlash + 1, lastSlash-teamSlash-1);
			string id = team_Urls[team].Substring(lastSlash + 1);
			String retVal = $"{BaseUrl}/{teamIdName}/{id}.json?franchiseSlug=madden-nfl&pageType=teams-ratings&id={teamIdName}&id={id}";
			return retVal;
		}

		public static string GetTeamPageUrl(String team)
		{
			return team_Urls[team] ;
		}

		public static string GetWebData(string url)
		{
			Console.WriteLine($"Requesting '{url}'");
			try
			{
				// Create a request for the URL.
				WebRequest request = WebRequest.Create(url);

				// If required by the server, set the credentials.
				request.Credentials = CredentialCache.DefaultCredentials;

				// Get the response.
				using (WebResponse response = request.GetResponse())
				{
					// Get the stream containing content returned by the server.
					using (Stream dataStream = response.GetResponseStream())
					{
						// Open the stream using a StreamReader for easy access.
						using (StreamReader reader = new StreamReader(dataStream))
						{
							// Read the content.
							string responseFromServer = reader.ReadToEnd();

							// Return the content.
							return responseFromServer;
						}
					}
				}
			}
			catch (Exception e)
			{
				// Handle any errors that may have occurred.
				string error = $"Error: {e.Message} when requesting '{url}'";
				Console.WriteLine(error);
				return error;
			}
		}

		/*public static List<string> GetPlayerJsonStrings(string jsonData)
		{
			//using System.Text.Json;
			// { pageProps { ratingsEntries { items [
			JsonDocument document = JsonDocument.Parse(jsonData);
			JsonElement root = document.RootElement;
			JsonElement pageProps, ratingsEntries, items;
			if (root.TryGetProperty("pageProps", out pageProps) && 
				pageProps.TryGetProperty("ratingsEntries", out ratingsEntries) &&
				ratingsEntries.TryGetProperty("items", out items))
			{
				items.
			}

		}*/

		public static Dictionary<string, string> To_OldFormatTranslationTable = new Dictionary<string, string> {
			{"team" ,""},
			{"firstName",""},
			{"lastName",""},
			{"position","position.id"},
			{"jerseyNum",""},
			{"height",""},
			{"weight",""},
			{"yearsPro",""},
			//{"totalSalary",""},
			//{"signingBonus",""},
			{"plyrBirthdate","birthdate"},
			{"plyrHandedness","handedness"},
			{"college",""},
			{"overall_rating","overallRating"},
			{"speed_rating","stats.speed.value"},
			{"acceleration_rating","stats.acceleration.value"},
			{"strength_rating","stats.strength.value"},
			{"agility_rating","stats.agility.value"},
			{"awareness_rating","stats.awareness.value"},
			{"catching_rating","stats.catching.value"},
			{"carrying_rating","stats.carrying.value"},
			{"throwPower_rating","stats.throwPower.value"},
			{"throwAccuracy_rating","stats.throwAccuracyMid.value"},  // use throwAccuracyMid
			{"throwAccuracyShort_rating","stats.throwAccuracyShort.value"},
			{"throwAccuracyMid_rating","stats.throwAccuracyMid.value"},
			{"throwAccuracyDeep_rating","stats.throwAccuracyDeep.value"},
			{"kickPower_rating","stats.kickPower.value"},
			{"kickAccuracy_rating","stats.kickAccuracy.value"},
			{"runBlock_rating","stats.runBlock.value"},
			{"passBlock_rating","stats.passBlock.value"},
			{"tackle_rating","stats.tackle.value"},
			{"jumping_rating","stats.jumping.value"},
			{"kickReturn_rating","stats.kickReturn.value"},
			{"injury_rating","stats.injury.value"},
			{"stamina_rating","stats.stamina.value"},
			{"toughness_rating","stats.toughness.value"},
			{"trucking_rating","stats.trucking.value"},
			{"bCVision_rating","stats.bCVision.value"},
			{"stiffArm_rating","stats.stiffArm.value"},
			{"spinMove_rating","stats.spinMove.value"},
			{"jukeMove_rating","stats.jukeMove.value"},
			{"impactBlocking_rating","stats.impactBlocking.value"},
			{"powerMoves_rating","stats.powerMoves.value"},
			{"finesseMoves_rating","stats.finesseMoves.value"},
			{"blockShedding_rating","stats.blockShedding.value"},
			{"pursuit_rating","stats.pursuit.value"},
			{"playRecognition_rating","stats.playRecognition.value"},
			{"manCoverage_rating","stats.manCoverage.value"},
			{"zoneCoverage_rating","stats.zoneCoverage.value"},
			{"spectacularCatch_rating","stats.spectacularCatch.value"},
			{"catchInTraffic_rating","stats.catchInTraffic.value"},
			//{"routeRunning_rating","stats.mediumRouteRunning.value"}, // use mediumRouteRunning for now
			{"mediumRouteRunning_rating","stats.mediumRouteRunning.value"},
			{"deepRouteRunning_rating","stats.deepRouteRunning.value"},
			{"shortRouteRunning_rating","stats.shortRouteRunning.value"},
			{"hitPower_rating","stats.hitPower.value"},
			{"press_rating","stats.press.value"},
			{"release_rating","stats.release.value"},
			{"playAction_rating","stats.playAction.value"},
			{"throwOnTheRun_rating","stats.throwOnTheRun.value"}
		};

		static string[] playerAttrs = {
				"id",
				"overallRating",
				"firstName",
				"lastName",
				"birthdate",
				"height",
				"weight",
				"college",
				"handedness",
				"age",
				"jerseyNum",
				"yearsPro",
				"position.id",
				"stats.acceleration.value",
				"stats.agility.value",
				"stats.jumping.value",
				"stats.stamina.value",
				"stats.strength.value",
				"stats.awareness.value",
				"stats.bCVision.value",
				"stats.blockShedding.value",
				"stats.breakSack.value",
				"stats.breakTackle.value",
				"stats.carrying.value",
				"stats.catchInTraffic.value",
				"stats.catching.value",
				"stats.changeOfDirection.value",
				"stats.deepRouteRunning.value",
				"stats.finesseMoves.value",
				"stats.hitPower.value",
				"stats.impactBlocking.value",
				"stats.injury.value",
				"stats.jukeMove.value",
				"stats.kickAccuracy.value",
				"stats.kickPower.value",
				"stats.kickReturn.value",
				"stats.leadBlock.value",
				"stats.manCoverage.value",
				"stats.mediumRouteRunning.value",
				"stats.overall.value",
				"stats.passBlock.value",
				"stats.passBlockFinesse.value",
				"stats.passBlockPower.value",
				"stats.playAction.value",
				"stats.playRecognition.value",
				"stats.powerMoves.value",
				"stats.press.value",
				"stats.pursuit.value",
				"stats.release.value",
				"stats.runBlock.value",
				"stats.runBlockFinesse.value",
				"stats.runBlockPower.value",
				"stats.runningStyle.value",
				"stats.shortRouteRunning.value",
				"stats.spectacularCatch.value",
				"stats.speed.value",
				"stats.spinMove.value",
				"stats.stiffArm.value",
				"stats.tackle.value",
				"stats.throwAccuracyDeep.value",
				"stats.throwAccuracyMid.value",
				"stats.throwAccuracyShort.value",
				"stats.throwOnTheRun.value",
				"stats.throwPower.value",
				"stats.throwUnderPressure.value",
				"stats.toughness.value",
				"stats.trucking.value",
				"stats.zoneCoverage.value"
		};

		public static List<Dictionary<string,string>> GetPlayerData(string jsonData)
		{
			List<Dictionary<String,string>> retVal = new List<Dictionary<String,string>>();

			JObject obj = JObject.Parse(jsonData);
			JArray items = obj.SelectToken("pageProps.ratingsEntries.items").ToObject<JArray>();
			Console.WriteLine($"Tolal Players: {items.Count}");
			foreach (JObject item in items)
			{
				Dictionary<string, string> player = new Dictionary<string, string>();
				foreach(string attr in playerAttrs)
				{
					player.Add(attr, item.SelectToken(attr).ToString());
				}
				retVal.Add(player);
			}
			return retVal;
		}

		public static void TranslateToOldFormat(List<Dictionary<string, string>> playerData, string team, StringBuilder sb)
		{
			sb.Append($"{{\"count\":{playerData.Count}, \"docs\":[ ");
			foreach(var player in playerData)
			{
				TranslatePlayerToOldFormat(player,team, sb);
			}
			sb.Append("] },\n");
		}

		private static void TranslatePlayerToOldFormat(Dictionary<string, string> player, string team, StringBuilder sb)
		{
			sb.Append('{');
			string key = "";
			string data = "";
			if( !player.ContainsKey("team"))
			{
				player.Add("team", team);
			}
			foreach(var kvp in To_OldFormatTranslationTable)
			{
				key = kvp.Value;
				if (kvp.Value.Length == 0)
					key = kvp.Key;
				if (!player.ContainsKey(key))
				{
					Console.WriteLine($"key not found: {key}");
					sb.Append($"\"{kvp.Key}\":\"???\",");
				}
				else
				{
					data = player[key];
					if(kvp.Key == "plyrHandedness")//0 - Left, 1 - Right
					{
						if (data == "0") data = "Left";
						else data = "Right";
					}
					if(Int32.TryParse(data, out var value))
						data = $"{value}";
					else
						data = $"\"{data}\"";
					sb.Append($"\"{kvp.Key}\":{data},");
				}
			}
			sb.Remove(sb.Length - 1,1); // remove last comma
			sb.Append("},");
		}



		public static string getKey(string key)
		{
			string retVal = key;
			int lastDot = key.LastIndexOf('.');
			int firstDot = key.IndexOf('.');
			if (key == "position.id")
				retVal = "position";
			else if (firstDot != -1 && lastDot != -1)
			{
				retVal = key.Substring(firstDot + 1, lastDot - firstDot - 1);
			}
			return retVal;
		}

		public static int StringBuilderIndexOf(StringBuilder sb, string target, int startIndex)
		{
			if (sb == null || target == null) throw new ArgumentNullException();
			if (startIndex < 0 || startIndex > sb.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));
			if (target.Length == 0) return -1;
			if (target.Length > sb.Length - startIndex) return -1;
			int limit = sb.Length - target.Length-1;
			for (int i = startIndex; i < limit; i++)
			{
				int j;
				for (j = 0; j < target.Length; j++)
				{
					if (sb[i + j] != target[j])
						break;
				}
				if (j == target.Length)
					return i;
			}
			return -1;
		}


		public static int StringBuilderLastIndexOf(StringBuilder sb, string target, int startIndex)
		{
			if (sb == null || target == null) throw new ArgumentNullException();
			if (startIndex < 0 || startIndex >= sb.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));
			if (target.Length == 0) return -1;
			if (target.Length > startIndex + 1) return -1;

			for (int i = startIndex - target.Length + 1; i > -1; i--)
			{
				int j;
				for (j = 0; j < target.Length; j++)
				{
					if (sb[i + j] != target[j])
						break;
				}
				if (j == target.Length)
					return i;
			}
			return -1;
		}

	}
}
