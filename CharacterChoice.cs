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
using Custom_Program.Model;

namespace Custom_Program
{
    public partial class CharacterChoice : Form
    {
        /// <summary>
        /// This form screen displays the selection of Character.
        /// This adds a personalized aspect to the game
        /// Basic file parsing is included
        /// </summary>
        private List<String> _lines;
        public CharacterChoice()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("desc.txt");
            //Read the first line of text
           _lines = new List<String>();
            String temp = sr.ReadLine();
            //Continue to read until you reach end of file
            while (temp != ".")
            {             
                _lines.Add(temp);                
                temp = sr.ReadLine();
            }
            sr.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeChar("Blackbeard", "char1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeChar("Kassey Boon", "char2");

        }

        private void button3_Click(object sender, EventArgs e)
        {
           InitializeChar("Barbossa","char3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeChar("Penelope", "char4");
        }

        private void CharacterChoice_Load(object sender, EventArgs e)
        {
           
        }

        public void InitializeChar(string name, string pic)
        {
            //create a new character and pass its name
            Character player = new Character();
            player.Name = name;
            player.Pfp = pic;
            this.Hide();
            Map screen2 = new Map(player);
            screen2.ShowDialog();
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            label1.Text = _lines.ElementAt<String>(3);
            button4.BackColor = Color.Gold;
            button4.MouseLeave += (s, EventArgs) => { HoverLeave(button4); };
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label1.Text = _lines.ElementAt<String>(2);
            button3.BackColor = Color.Gold;
            button3.MouseLeave += (s, EventArgs) => { HoverLeave(button3); };
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label1.Text = _lines.ElementAt<String>(1);
            button2.BackColor = Color.Gold;
            button2.MouseLeave += (s, EventArgs) => { HoverLeave(button2); };
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = _lines.ElementAt<String>(0);
            button1.BackColor = Color.Gold;
            button1.MouseLeave += (s, EventArgs) => { HoverLeave(button1); };
        }

        private void HoverLeave(Button b)
        {
            b.BackColor = Color.Azure;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingScreen screen1 = new LandingScreen();
            screen1.ShowDialog();
        }
    }
}
