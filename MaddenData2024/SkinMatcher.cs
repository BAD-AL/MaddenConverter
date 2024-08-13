using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaddenDataScraper_2024
{
	public class SkinMatcher
	{

		public static string MatchSkin(Image faceImage)
		{
			string retVal = null;
			if (faceImage != null)
			{
				int width = 10;
				int height = 10;
				int x = faceImage.Width / 2 + width;
				int y = faceImage.Height / 2;
				Rectangle srcRect = new Rectangle(x, y, width, height);
				Rectangle destRect = new Rectangle(0, 0, 50, 50);
				//e.Graphics.DrawImage(faceImage, destRect, srcRect, GraphicsUnit.Pixel);
				Bitmap bitmap = new Bitmap(width, height);
				Graphics g = Graphics.FromImage(bitmap);
				g.DrawImage(faceImage, destRect, srcRect, GraphicsUnit.Pixel);
				Color aveColor = CalculateAverageColor(bitmap);
				retVal = FindClosestColor(aveColor).Value;
				g.Dispose();
				bitmap.Dispose();
			}
			return retVal;
		}

		public static string MatchSkin(string filePath)
		{
			if (File.Exists(filePath))
			{
				Image img = Image.FromFile(filePath);
				string retVal = MatchSkin(img);
				img.Dispose();
				return retVal;
			}
			return null;
		}

		public static Color CalculateAverageColor(Bitmap bitmap)
		{
			long sumR = 0;
			long sumG = 0;
			long sumB = 0;
			int pixelCount = 0;

			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					Color pixelColor = bitmap.GetPixel(x, y);

					sumR += pixelColor.R;
					sumG += pixelColor.G;
					sumB += pixelColor.B;

					pixelCount++;
				}
			}

			int avgR = (int)(sumR / pixelCount);
			int avgG = (int)(sumG / pixelCount);
			int avgB = (int)(sumB / pixelCount);

			return Color.FromArgb(avgR, avgG, avgB);
		}

		public static KeyValuePair<uint,string> FindClosestColor(Color targetColor)
		{
			Color closestColor = Color.Empty;
			double minDistance = double.MaxValue;
			KeyValuePair<uint,string> retVal = new KeyValuePair<uint, string>();

			//foreach (Color color in colors)
			foreach (var kvp in skinMap)
			{
				Color color = Color.FromArgb((int)kvp.Key);
				double distance = GetColorDistance(targetColor, color);
				if (distance < minDistance)
				{
					minDistance = distance;
					closestColor = color;
					retVal = kvp;
				}
			}
			return retVal;
		}

		private static double GetColorDistance(Color color1, Color color2)
		{
			int rDifference = color1.R - color2.R;
			int gDifference = color1.G - color2.G;
			int bDifference = color1.B - color2.B;

			return Math.Sqrt(rDifference * rDifference + gDifference * gDifference + bDifference * bDifference);
		}

		public static Color GetColorForSkin(string skinName)
		{
			foreach(var kvp in skinMap)
			{
				if(kvp.Value.Equals(skinName))
					return Color.FromArgb((int)kvp.Key);
			}
			return Color.Empty;
		}

		public static List<String> GetSkinChoices()
		{
			var choices = new List<String>();
			choices.AddRange(skinMap.Values);
			return choices;
		}


		private static Dictionary<uint, String> skinMap = new Dictionary<uint, String> {
			//{ 0xFFA56238,"Skin1"},
			//{ 0xFFA75F43,"Skin1"},
			//{ 0xFFAB8264,"Skin1"},
			//{ 0xFF9F4E2A,"Skin1"},
			//{ 0xFF8D623A, "Skin1"},
			{ 0xFFF3BCA7, "Skin1" },
			{ 0xFFA57956, "Skin2"},
			{ 0xFFC8855A, "Skin3"},
			//{ 0xFFD6A88E, "Skin3"},

			{ 0xFF944A21, "Skin4"},
			{ 0xFF9F5A37, "Skin5"},
			{ 0xFF975C3B, "Skin6"}, //disqualify?
			//{ 0xFFB97B5E, "Skin9"},
			//{ 0xFFC48866, "Skin10"},
			{ 0xFF9C6C4B, "Skin11"},
			{ 0xFFB06E45, "Skin12"},
			{ 0xFF94421E, "Skin13"},
			{ 0xFF793823, "Skin14"},
			//{ 0xFFAD8561, "Skin17"},
			//{ 0xFFBE8F71, "Skin19"},
			//{ 0xFF83583D, "Skin19"},
			{ 0xFF843814, "Skin20"},
			{ 0xFF994629, "Skin21"},
			{ 0xFF93592D, "Skin22"}
			};
	}
}
