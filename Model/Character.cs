using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Custom_Program.Model
{
    public class Character
    {
        public string Name { get; set; } //name of the character chosen on CharacterChoice Screen
        public string Pfp { get; set; }
        public Directory Assets { get; set; }
        public Cargo CargoInfo { get; set; }
        public Point Location { get; set; }    // of the ship on the map

        public Ship Ship { get; set; }
        public Backend TravelDate {get; set;}


        public Character()
        {
            Random rand = new Random();
            this.Location = new Point(646, 292);
            CargoInfo = new Cargo();
            Ship = new Ship();
            Assets = new Directory();
            Assets.Cash = rand.Next(1, 6) * 1000;
            Assets.Bank = rand.Next(3) * 1000;
            Assets.Debt = rand.Next(5) * 1000;
            TravelDate = new Backend();
        
        }


        public void UpdateInterest()
        {
            DateTime begin = new DateTime(2015, 12, 31);
            TimeSpan GameTime = TravelDate.Dt.Subtract(begin);
            decimal temp=Convert.ToDecimal(GameTime.TotalDays / 365);
            Assets.Bank += Convert.ToInt32((Assets.BankInterest / 100) * Convert.ToDecimal(Assets.Bank)*temp);
            Assets.Debt += Convert.ToInt32((Assets.DebtInterest / 100) * Convert.ToDecimal(Assets.Debt)*temp);
        }


    }
}

