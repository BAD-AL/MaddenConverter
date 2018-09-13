using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace MaddenConverter
{
    // fname,lname,position,number,Speed,Agility,Strength,Jumping,Coverage,PassRush,RunCoverage,PassBlocking,
    // RunBlocking,Catch,RunRoute,BreakTackle,HoldOnToBall,PowerRunStyle,PassAccuracy,PassArmStrength,PassReadCoverage,
    // Tackle,KickPower,KickAccuracy,Stamana,Durability,Leadership,Scramble,Composure,Consistency,Aggressiveness,
    /* Appearance*/
    // College,DOB,Hand,Weight,Height,BodyType,Skin,Face,Dreads,Helmet,FaceMask,FaceShield,EyeBlack,MouthPiece,
    // LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck

    public class PlayerAppearance
    {
        //#fname,lanme,Position,Number,College,DOB,Hand,Weight,Height,BodyType,Skin,Face,Dreads,Helmet,
        //FaceMask,FaceShield,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,
        //RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck

        string attrs = "First Name,Last Name,Position,Number,College,DOB,Hand,Weight,Height,BodyType,Skin,Face,Dreads,Helmet,FaceMask,FaceShield,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck";
        string[] mKeys = null;

        Dictionary<string, string> mPlayerMap = null;

        private StringBuilder mPlayersToCheck = new StringBuilder();

        public string MissedPlayers { get { return mPlayersToCheck.ToString(); } }

        // Call if re-using
        public void Initialize() { mPlayersToCheck.Length = 0; }


        public PlayerAppearance()
        {
            mKeys = attrs.Split(new char[] { ',' });
            string data = System.IO.File.ReadAllText("NFL2K5_EquipmentData_2014.csv");
            data = data.Replace("\r\n", "\n");
            string[] lines = data.Split(new char[] { '\n' });
            int index = 0;
            string key = "";
            string val = "";
            mPlayerMap = new Dictionary<string, string>(lines.Length);

            foreach (string line in lines)
            {
                if (line.StartsWith("#") || line.Length < 20 || line.StartsWith("Team "))
                    continue;
                index = 0;
                for (int i = 0; i < 3; i++) // advance to 3rd comma
                    index = line.IndexOf(',', index+1);
                key = line.Substring(0, index);
                index = line.IndexOf(',', index + 1); // get past jersey #
                val = line.Substring(index + 1);
                if (!mPlayerMap.ContainsKey(key))
                    mPlayerMap.Add(key, val);
                else
                    Console.WriteLine(key + "is already in the map");
            }
        }

        // 15 faces
        // Skin,Face,Dreads,Helmet,FaceMask,Visor,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck 
        //string mStandardAppearance = "Skin 6,Face 5,No,Standard,Type 7,Clear,Yes,No,Team 3,Team 3,None,None,None,None,None,Style 3,Style 3,None,None";
        string mStandardAppearance = "Skin 6,Face 5,No,Standard,FaceMask7,Clear,Yes,No,Team3,Team3,None,None,None,None,None,Shoe3,Shoe3,None,None";
        Random mRandom = new Random();

        public string GetAppearance(string firstName, string lastName, string position, string height, string weight, string number)
        {
            string retVal = "";
            string key = string.Format("{0},{1},{2}", firstName, lastName, position);
            if (mPlayerMap.ContainsKey(key))
            {
                retVal = mPlayerMap[key];
            }
            else
            {
                mPlayersToCheck.Append(firstName+"," + lastName +": "+ position + "\r\n");
                string face = "Face " + mRandom.Next(1, 15);
                height = height.Replace("\"", "");
                height = height.Replace("'", "' ") +"\"";
                //College,DOB,Hand,Weight,Height,BodyType + stdAppearance
                retVal = "?,?,Right," + weight + "," + height + "," + GetBodyType(height, weight) + "," + mStandardAppearance.Replace("Face5", face);
                switch (position)
                {
                    case "QB":
                    case "P":
                    case "K":
                        retVal = retVal.Replace("Skin 6", "Skin 1");
                        break;
                }
            }
            return retVal + ',';
        }

        string mSkinMap = null;

        private string SkinMap
        {
            get
            {
                if (mSkinMap == null)
                {
                    string fileName = "SkinMap.txt";
                    if (System.IO.File.Exists(fileName))
                        mSkinMap = System.IO.File.ReadAllText(fileName);
                    else
                        mSkinMap = "";
                }
                return mSkinMap;
            }
        }

        Regex skinRegex = new Regex("Skin[0-9+]");

        private string GetSkin(string firstName, string lastName, string position)
        {
            string retVal = "Skin ";
            string pattern = string.Format("{0},{1},{2},Skin", firstName, lastName, position);
            int index = SkinMap.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase);
            if (index > -1)
            {
                retVal += SkinMap[index + pattern.Length ];
            }
            else
            {
                switch (position)
                {
                    case "QB":
                    case "P":
                    case "K":
                        retVal += "1";
                        break;
                    default:
                        retVal += "6";
                        break;
                }
            }
            return retVal;
        }

        //// Skin,Face,Dreads,Helmet,FaceMask,Visor,EyeBlack,MouthPiece,LeftGlove,RightGlove,LeftWrist,RightWrist,LeftElbow,RightElbow,Sleeves,LeftShoe,RightShoe,NeckRoll,Turtleneck,YearsPro
        public string GetAppearance2018(string firstName, string lastName, string position, string height, string weight, string number, 
            string yearsPro, string plyrBirthdate, string plyrHandedness, string college)
        {
            string retVal = "";
            string key = string.Format("{0},{1},{2}", firstName, lastName, position);
            if (mPlayerMap.ContainsKey(key))
            {
                retVal = mPlayerMap[key];
            }
            else
            {
                string skin = GetSkin(firstName, lastName, position);
                mPlayersToCheck.Append(firstName + "," + lastName + ": " + position + "\r\n");
                string face = "Face " + mRandom.Next(1, 15);
                string height2 = height.Replace("\"", "");
                height2 = height2.Replace("'", "' ") + "\"";
                //College,DOB,Hand,Weight,Height,BodyType + stdAppearance
                //retVal = "?,?,Right," + weight + "," + height + "," + GetBodyType(height, weight) + "," + mStandardAppearance.Replace("Face5", face);
                retVal = String.Format("{0},{1},{2},",college, plyrBirthdate,plyrHandedness) + weight + "," + height2 + "," + GetBodyType(height, weight) + "," + mStandardAppearance.Replace("Face5", face);

                retVal = retVal.Replace("Skin 6", skin);
            }
            retVal += "," + yearsPro;
            return retVal;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns>(Extra Large, Large,Normal,Skinny)</returns>
        private string GetBodyType(string height, string weight)
        {
            string ret = "Normal";
            int w = Int32.Parse(weight);

            int feet = height[0] - 48;
            int inches = 0;
            if (height.IndexOf('\'') == -1)
            {
                inches = Int32.Parse(height.Replace("\"", ""));
            }
            else
            {
                inches = (height.IndexOf('"') > -1) ? Int32.Parse(height.Replace("\"", "").Substring(2)) : Int32.Parse(height);
                inches += (feet * 12);
            }
            #region big switch
            switch (inches)
            {
                //5'3" - 5'8"
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                    if (w > 200)
                        ret = "Large";
                    else if (w < 170)
                        ret = "Skinny";
                    break;
                case 70: //5'10
                case 71:
                case 72:
                case 73:
                case 74: //6'2
                  if (w > 280)
                        ret = "Extra Large";
                  else if (w > 220)
                        ret = "Large";
                    else if (w < 182)
                        ret = "Skinny";
                    break;
                case 75: //6'3
                case 76:
                case 77:
                    if (w > 300)
                        ret = "Extra Large";
                    else if (w > 230)
                        ret = "Large";
                    else if (w < 185)
                        ret = "Skinny";
                    break;
                case 78: //6'6
                case 79:
                case 80:
                case 81:
                case 82:
                    if (w > 320)
                        ret = "Extra Large";
                    else if (w > 250)
                        ret = "Large";
                    else if (w < 215)
                        ret = "Skinny";
                    break;
            }
            #endregion

            return ret;
        }

    }
}
