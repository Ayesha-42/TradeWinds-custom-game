using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using game;
using Custom_Program.Model;
using Custom_Program.Presenter;
using Custom_Program.View;

namespace Custom_Program
{
    /// <summary>
    /// This form screen displays the selected Port habour.
    /// It gives access to the port's buildings and its services
    /// It works with the View interfaces to implement the Presenter classes
    /// This is where the player can trade and make investments
    /// OOP and design pattern interactions and functioning is included 
    /// </summary>
    public partial class Port : Form, IBuilding, IPort, IPlayer
    {
        private Character _player;
        private Dictionary<int, string[]> _display;
        private PortPresenter _presenter;
        private BuildingPresenter _presenter2;


        /*implementation of the property in IBuilding interface 
         * draws the labels in a column-wise manner 
         * according to what the specific building presenter 
         * wants to display in its service window
         * */
        public Dictionary<int, string[]> ItemNames
        {
            set
            {
                Label[] items= new Label[value[75].Length*value.Count];
                int j = 0;
                foreach (KeyValuePair<int, string[]> x in value)
                    {
                        for (int i=0; i < value[75].Length; i++)
                        {
                            items[i+j] = new Label();
                            items[i+j].Location = new Point(x.Key, 70 + (i * 45));
                            groupBox1.Controls.Add(items[i+j]);
                            items[i+j].Text = "" + x.Value[i] + "";
                            items[i+j].Size = new Size(60, 25);
                            items[i+j].Font = new System.Drawing.Font("Segoe Print", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            items[i + j].BringToFront();
                            if (x.Key == 170)
                            {
                                items[i + j].ForeColor = _presenter2.Profit(i);
                            }

                        }
                        j += value[75].Length;
                    }
                _display = value;    // to pass it and work on it later in the class
            } 
        }

        /*implementation of the property in IPort interface 
         * draws the labels according to their building  
         * location in the specific port 
         * */
        public List<Point> Locs
        {
            set
            {
                Label[] buildings = new Label[4] { label6, label9, label10,  label7 };
                for (int i = 0; i < 4; i++)
                {
                    this.Controls.Add(buildings[i]);
                    buildings[i].Location = value[i];
                    buildings[i].BringToFront();
                }
            }
        }

        /*  To draw the two complementary buttons
         *  to change the quanity or money amounts 
         *  in each building
         * */
        public void Arrows(int x, int y, string type)
        {
           
                Button[] buttons = new Button[x];
                Button[] buttons2 = new Button[x];

                for (int i = 0; i < x; i++)
                {
                    buttons[i] = new Button();
                    buttons2[i] = new Button();
                if (x == 1)
                {
                    buttons[i].Location = new Point(y, 280);
                    buttons2[i].Location = new Point(y + 100, 280);
                }
                else
                {
                    buttons[i].Location = new Point(y, 70 + (i * 45));
                    buttons2[i].Location = new Point(y + 100, 70 + (i * 45));
                }
                    
                    buttons[i].Size = new Size(30, 20);
                    buttons2[i].Size = new Size(30, 20);
                buttons[i].Text = "<";
                buttons2[i].Text = ">";
                    groupBox1.Controls.Add(buttons[i]);
                    groupBox1.Controls.Add(buttons2[i]);
                    int j = i;
                    buttons[i].Click += (s, EventArgs) => { ButtonAction(-1, j, type); };
                    buttons2[i].Click += (s, EventArgs) => { ButtonAction(1, j, type); };
                    
                }
        }
     
        public void ButtonAction(int i , int j, string type)
        {
            switch (type)
            {
                case "market":
                    _presenter2.UpdateQuantity(j, _display[380], _display[170], i);
                    break;
                case "bank":
                    _presenter2.UpdateQuantity(0, null, null,i);
                    
                    break;
                case "moneylender":
                    _presenter2.UpdateQuantity(0,null,null,i);
                    break;
                case "repair":
                    _presenter2.UpdateQuantity(i, _display[75]);
                    break;
                case "shipyard":
                    _presenter2.UpdateQuantity(j, _display[450], _display[300], i);
                    break;
            }
        }

        /*  To separate and accessible labels for
         *  displaying the total amounts
         *  and getting the total amounts 
         *  for methods in the Presenter to work on
         * */
        public string Total {
            set { label12.Text = value; }
            get { return label12.Text; }
                }

        public string CargoTotal { set { label13.Text = value; } get { return label13.Text; } }
        
        //to work on the same building created when a new port is reached
        public Buildings chosen(Label labelSelected) 
            { 
                foreach (KeyValuePair<Buildings, Point> x in _presenter.Port.BuildingsLoc)
                {
                    if (x.Value == labelSelected.Location) {  return x.Key; }
                
                }
                return null;
            }
                
         
        //to display the information of the port and the player implementing the IPlayer interface
        public string PortText { set { label4.Text = value; } }
        public string NameText { set { label5.Text = value; } }
        public string CashText { get { return label1.Text; } set { label1.Text = value; } }
        public string BankText { get { return label2.Text; } set { label2.Text = value; } }
        public string DebtText { get { return label3.Text; } set { label3.Text = value; } }
        public string RankText { set { label11.Text = value; } }
        public string DateText { set { label14.Text = "" + _player.TravelDate.Dt; } }
        
        
        //class Contructor
        public Port(string name, Character player)
        {
            InitializeComponent();
            _player = player;
            player.TravelDate.UpdateDate(name); //calculating the travel time
            
            
            switch (name)                       //setting the port screen visual
            {
                case "Kingston": 
                    this.BackgroundImage = Properties.Resources.port1; break;
                case "Panama":
                    this.BackgroundImage = Properties.Resources.port2; break;
                case "Dominican Republic":
                    this.BackgroundImage = Properties.Resources.port3; break;
                case "Colombia":
                    this.BackgroundImage = Properties.Resources.port4; break;
                case "Trinidad":
                    this.BackgroundImage = Properties.Resources.port5; break;
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;
            _presenter = new PortPresenter(this, name);
            object O = Properties.Resources.ResourceManager.GetObject(player.Pfp); //Return an object from the image chan1.png in the project
            pictureBox1.Image = (Image)O;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(button1);
            button1.BackColor = Color.Transparent;

            PortText = name;
            _presenter.DisplayScreen(player);
            
            groupBox1.Visible = false;

           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Exit the Port screen, return to the Map
            _player.UpdateInterest();
            Map screen2 = new Map(_player);
            this.Hide();
            screen2.ShowDialog();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            //Marketplace display window
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label13);
         
            _presenter2 = new MarketPlacePresenter(this, chosen(label6), _player);
            groupBox1.Visible = true;
            groupBox1.BackgroundImage = Properties.Resources.marketplace;

            Point hide = new Point(1141, 746);
            Point show = new Point(500, 90);
            Locs = new List<Point>{show, hide, hide, hide}; //or pass in nulls
            _presenter2.DisplayScreen();
            _presenter2.DisplayArrows();
            
            button2.Click += (s, EventArgs) => { _presenter2.Buy(); };
            button3.Click += (s, EventArgs) => { _presenter2.Sell(); };//, marketplace[380], marketplace[170], -1); };
            label6.Location = new Point(100, 40);

        }


        private void button4_Click(object sender, EventArgs e)
        { 
            //when the building window is exited
            groupBox1.Visible = false;
            _presenter.DisplayScreen(_player);
        }


        private void Port_Load(object sender, EventArgs e)
        {
            pictureBox2.Controls.Add(label1);
            pictureBox2.Controls.Add(label2);
            pictureBox2.Controls.Add(label3);
            pictureBox2.Controls.Add(label11);
            pictureBox2.Controls.Add(label5);
            pictureBox2.Controls.Add(button11);
            pictureBox2.Controls.Add(label14);
            pictureBox2.Controls.Add(label15);
            pictureBox2.Controls.Add(pictureBox1);


        }

        private void label9_Click(object sender, EventArgs e)
        {
            //BANK
           
            groupBox1.Controls.Clear();
            
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            
            _presenter2 = new BankPresenter(this, chosen(label9), _player);
            groupBox1.Visible = true;
            groupBox1.BackgroundImage = Properties.Resources.bank;
            Point hide = new Point(1141, 746);
            Point show = new Point(380, 70);
            Locs = new List<Point> { hide, show, hide, hide }; //window title
            
            _presenter2.DisplayScreen();
            _presenter2.DisplayArrows();
            button5.Click += (s, EventArgs) => { _presenter2.Buy(); };      //Withdrawing from the bank
            button6.Click += (s, EventArgs) => { _presenter2.Sell(); };     //Depositing in the bank
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //MONEYLENDER
            groupBox1.Controls.Clear();

            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button4);
            _presenter2 = new MoneylenderPresenter(this, chosen(label10), _player);
            groupBox1.Visible = true;
            groupBox1.BackgroundImage = Properties.Resources.bank;
            Point hide = new Point(1141, 746);
            Point show = new Point(380, 70);
            Locs = new List<Point> { hide, hide, show, hide }; //or pass in nulls
            
            _presenter2.DisplayScreen();
            _presenter2.DisplayArrows();
            button7.Click += (s, EventArgs) => { _presenter2.Buy(); };  //Loan money from the moneylender
            button8.Click += (s, EventArgs) => { _presenter2.Sell(); }; // Repay your debt to the moneylender

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //SHIPYARD 

            groupBox1.Controls.Clear();

            groupBox1.Controls.Add(button9);    //repair
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label13);
            _presenter2 = new ShipyardPresenter(this, chosen(label7), _player);
            groupBox1.Visible = true;
            groupBox1.BackgroundImage = Properties.Resources.shipyardFinal;
            Point hide = new Point(1141, 746);
            Point show = new Point(380, 70);
            Locs = new List<Point> { hide, hide, hide, show }; //or pass in nulls

            _presenter2.DisplayScreen();
            _presenter2.DisplayArrows();
            button9.Click += (s, EventArgs) => { _presenter2.Sell(); };  //Repair
            button2.Click += (s, EventArgs) => { _presenter2.Buy(); }; // Buy Ship upgrade or install canons

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // To view the cargo capacity in use by the player
            trackBar1.Visible = true;
            trackBar1.Maximum = _player.CargoInfo.CargoSpace;
            trackBar1.Value = Int32.Parse(_player.CargoInfo.CargoTotal());
            label15.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
           }
        }
    }
}
