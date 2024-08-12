using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MaddenConverter
{
    static class Program
    {
		public static bool AutoUpdateDepthChart = true;
		public static bool AutoUpdatePBP = true;
		public static bool AutoUpdatePhoto = false;
		public static bool AutoUpdateSpecialTeamsDepth = true;
		private const string sIniFile = "MaddenConverter.ini";

		public static void SaveIniOptions()
		{
			String content = String.Format(
				"[General]\r\\nAutoUpdateDepthChart={0}\r\nAutoUpdatePBP={1}\r\nAutoUpdatePhoto={2}\r\n",
					AutoUpdateDepthChart.ToString(),
					AutoUpdatePBP.ToString(),
					AutoUpdatePhoto.ToString());
			File.WriteAllText(sIniFile, content);
		}

		private static void LoadIniOptions()
		{
			if (File.Exists(sIniFile))
			{
				string setting = "";

				var lines = File.ReadAllLines(sIniFile);
				foreach (string line in lines)
				{
					if (line.Trim().StartsWith("AutoUpdateDepthChart"))
					{
						setting = GetIniSetting(line, AutoUpdateDepthChart.ToString());
						bool.TryParse(setting, out AutoUpdateDepthChart);
					}
					else if (line.Trim().StartsWith("AutoUpdatePBP"))
					{
						setting = GetIniSetting(line, AutoUpdatePBP.ToString());
						bool.TryParse(setting, out AutoUpdatePBP);
					}
					else if (line.Trim().StartsWith("AutoUpdatePhoto"))
					{
						setting = GetIniSetting(line, AutoUpdatePhoto.ToString());
						bool.TryParse(setting, out AutoUpdatePhoto);
					}
					else if (line.Trim().StartsWith("AutoUpdateSpecialTeamsDepth"))
					{
						setting = GetIniSetting(line, AutoUpdateSpecialTeamsDepth.ToString());
						bool.TryParse(setting, out AutoUpdateSpecialTeamsDepth);
					}
				}
			}
		}
		private static string GetIniSetting(string line, string defaultOption)
		{
			string retVal = defaultOption;
			int index = line.IndexOf("=");
			if (index > 1)
			{
				retVal = line.Substring(index + 1).Trim();
			}
			return retVal;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			LoadIniOptions();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
