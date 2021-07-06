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
using System.Xml.Serialization;
using Custom_Program.Presenter;
using Custom_Program.Model;
using System.Media;


namespace Custom_Program
{
    /// <summary>
    /// This form screen displays the map.
    /// It gives the player choice to move to various ports
    /// It allows the player to exit and/or save the game
    /// This is where the player can encounter pirates
    /// Basic animation and sound effects are included 
    /// </summary>
    public partial class Map : Form
    {

        private Character _player;
        private Pirate _attack;    
                
        public Map(Character player)
        {
           
            InitializeComponent();
            
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(pictureBox3);
            pictureBox1.Controls.Add(label1);
            pictureBox1.Controls.Add(label2);
            pictureBox1.Controls.Add(label3);
            pictureBox1.Controls.Add(label4);
            pictureBox1.Controls.Add(label5);
            pictureBox1.Controls.Add(label6);
            pictureBox1.Controls.Add(label7);
         

            //draws the ship of current location, get from character
            pictureBox2.Location = player.Location;

            _attack = new Pirate();           
            _player = player;
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoadPort(label1);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            LoadPort(label4);
        }
    

        private void label3_Click(object sender, EventArgs e)
        {
            LoadPort(label3);
        }
       

        private void label2_Click(object sender, EventArgs e)
        {
            LoadPort(label2);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            LoadPort(label5);
        }

        public void LoadPort(Label x)
        {
           // first checks if the player has lost the game or not
            if(_player.Assets.Rank == "Bankrupt")
            {
                MessageBox.Show("You've lost all your money! \n Better luck next time.");
            }
            
            // sets up the movement on the map
            _player.Location = x.Location;

            //sets the hypotenus along which the ship would move
            int DiffX = _player.Location.X - pictureBox2.Location.X;
            int DiffY = _player.Location.Y - pictureBox2.Location.Y;

            int[] _speed = new int[] { DiffX, DiffY, 15 };
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "gameAudio.wav"; //loads the mini-audio clip

            player.Play();
            int i = 1;
            while (i<16)
            {
                // the animation of the image moving between ports on the map
                pictureBox2.Location = new Point(pictureBox2.Location.X + (_speed[0] / _speed[2]), pictureBox2.Location.Y + (_speed[1] / _speed[2]));
               
                var t = Task.Delay(500); 
                t.Wait();

                //checks for pirate attacks inroute
                
                bool encounter = _attack.BattleSequence(_player.TravelDate.Dt, _player);
                if (encounter)
                {
                    label7.Text = "Oh No! a Pirate attack";
                    pictureBox3.Visible = true;
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show("Damages incurred: \t" + (_attack.Damages + "\n"), "Your Ship was attacked by Pirates!", button, MessageBoxIcon.Exclamation);
                   
                    
                    if (_attack.Looted)
                    {
                        MessageBox.Show("Unfortunately the pirates looted all your Cargo");
                    }
                    if (_attack.Sink)
                    {
                        MessageBox.Show("Your ship has sinked!" + "\n better Luck next time");
                        this.Close();
                    }
                }
                i += 1;
            }
           player.Stop();

            //shifts to the port screen as requested
            this.Hide();
            Port screen3 = new Port(x.Text, _player);
            screen3.ShowDialog();
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }

        protected override CreateParams CreateParams
        {
            //removes generation and delete of new controls glitch
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //EXIT 
            //gives the option of saving
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you want to save your game?", "Request to Exit Game", buttons);
            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                //save record in an xml file
              
                XmlSerialization.WriteToXmlFile<Character>("SavedGame.txt", _player);
                //To store multiple entries- XmlSerialization.WriteToXmlFile<List<Character>>("C:\savedgames.txt", List<Characters>);
                this.Close();
            }
        }

       
    }
}
