using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.View;

namespace Custom_Program.Model
{
    public class Shipyard : Buildings, IShip
    {
        public string[] Shipnames { get; }
        public int CanonP { get; set; }
        public int ShipP { get; set; }
        private int upgrade;
        public int UpgradeLevel { get { return upgrade; } set { upgrade = value; } }
        
        public int CanonQselected { get; set;}
        public int ShipQselected { get; set; }
        public string RepairP { get; set; }
        public string Points { get; set; }

        public Shipyard() : base()
        {
            Random rand = new Random();
            CanonP = rand.Next(5, 12) * 100;
            ShipP = rand.Next(upgrade+1, upgrade + 5) * 1000;

            Shipnames = new string[] { "Caravel", "Barque", "Corvette", "BattleShip" ,""};
            
            CanonQselected = 0;
            ShipQselected = 0;
            RepairP = ""+rand.Next(8) * 50;
            Points = "0";
        }

       public string nameGet()
        {
            return Shipnames[UpgradeLevel];
        }
        

    }
}
