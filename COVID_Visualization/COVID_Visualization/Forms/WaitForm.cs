using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COVID_Visualization.Forms
{
    public partial class WaitForm : Form
    {
        public WaitForm(string inputText)
        {
            InitializeComponent();

            // Main text label text
            mainTextLabel.Text = inputText;

            // Get gif image
            string hey = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string imageFilePath = Directory.GetCurrentDirectory();
            mainPictureBox.Image = Image.FromFile(Path.Combine(imageFilePath, @"..\..\Resources\coronavirus_gif.gif"));
        }
    }
}
