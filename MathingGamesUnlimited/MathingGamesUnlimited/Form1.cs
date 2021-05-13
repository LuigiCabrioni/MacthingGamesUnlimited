using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathingGamesUnlimited
{
  
    public partial class Form1 : Form
    {
        Label firstClicked = null;

        Label secondClicked = null;
        
        // Use this Random object to choose random icons for the squares
     Random random = new Random();

            // Each of these letters is an interesting icon
            // in the Webdings font,
            // and each icon appears twice in this list
       List<string> icons = new List<string>()
       {
         "!", "!", "N", "N", "L", "L", "k", "k",
         "x", "x", "a", "a", "f", "f", "e", "e"
       };

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            
                return;
            
            
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                if (secondClicked == null)
                {
                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;
                    return;
                }
            }                
               
            
           CheckForWinner();

           if(firstClicked.Text == secondClicked.Text)
           {
                firstClicked = null;
                secondClicked = null;
                return;
           }

            timer1.Start();
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
           MessageBox.Show("You matched all the icons!", "Well Done!");
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
