using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.View;


namespace Custom_Program.Model
{
    public class Ship: IShip
    {
        
        public int HullStrength { get; set; }
        public int TotalLife { get; set; }
        public int CanonQ { get; set; }
        public int UpgradeLevel { get; set; }


        public Ship()
        {
            
            HullStrength = 30;
            TotalLife = 30;
            CanonQ = 0;
            UpgradeLevel = 0;

        }

   
    }
}
