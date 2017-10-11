using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MaddenConverter
{
    public partial class TextDisplay : Form
    {
        public TextDisplay()
        {
            InitializeComponent();
        }

        public string Content
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}
