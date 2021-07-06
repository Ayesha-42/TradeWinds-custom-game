using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom_Program.Model;
using Custom_Program.Presenter;
using System.Media;

namespace Custom_Program
{
    /// <summary>
    /// This form screen displays the starting Game screen.
    /// It gives the player choice to start the game, reload a previously saved game or exit
    /// Welcome to 'TradeWinds'! Enjoy.
    /// </summary>
    public partial class LandingScreen : Form
    {
      
        public LandingScreen()
        {
            InitializeComponent();
            this.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(button1);
            button1.BackColor = Color.Transparent;
                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //START button
            MessageBox.Show("Let's Start the Game!");
            this.Hide();
            CharacterChoice screen1 = new CharacterChoice();
            screen1.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Reloads the one previous game settings
            Backend temp = new Backend();
            Character player = XmlSerialization.ReadFromXmlFile<Character>("SavedGame.txt");
            this.Hide();
            Map screen2 = new Map(player);
            screen2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Exit
            this.Close();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
