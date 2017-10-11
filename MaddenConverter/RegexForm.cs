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
    public partial class RegexForm : Form
    {
        public RegexForm()
        {
            InitializeComponent();
        }

        private void mNameToolButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string lastName, firstName, newName, fullName;
            Regex nameRegex = new Regex("([A-Za-z.'-]+), ([A-Za-z.'-]+)");

            MatchCollection mc = nameRegex.Matches(text);
            foreach (Match m in mc)
            {
                fullName = m.Groups[0].Value;
                lastName = m.Groups[1].Value;
                firstName = m.Groups[2].Value;

                if (firstName == firstName.ToUpper())
                {
                    firstName = firstName[0] +   firstName.Substring(1).ToLower();
                    lastName = lastName[0] + lastName.Substring(1).ToLower();
                }
                newName = firstName + " " + lastName;
                text = text.Replace(fullName, newName);
            }
            textBox1.Text = text;
        }

        //Regex mPlayerNameRegex = new Regex("^[ ]?[0-9]+ [A-z\-\.]+ [A-z\-\.]+");

        private static bool OnTeam(string playerName, string team, string allText)
        {
            bool retVal = false;
            int teamStart = allText.IndexOf(team);
            int teamEnd = allText.IndexOf("AFC East BUF MIA NE NYJ North BAL", teamStart + 10);
            int playerLocation = allText.IndexOf(playerName, teamStart, teamEnd - teamStart);
            if (playerLocation > 0)
                retVal = true;
            return retVal;
        }
    }
}
