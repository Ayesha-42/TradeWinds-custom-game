using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program.Model
{
    public class Cargo
    {

        public string[] Quantity { get; set; }
        public int[] CP { get; set; }
        public int CargoSpace { get; set; }
        private int canonSpace;
        public int CanonSpace { set { canonSpace += value; } }
        
        public Cargo()
        {
            Quantity = new string[] { "0", "0", "0", "0", "0" };
            CP = new int[] { 0, 0, 0, 0, 0 };
            CargoSpace = 30;
            canonSpace = 0;
        }
        public string CargoTotal()
        {
            int total = 0;
            foreach (string x in Quantity)
            {
                int num = int.Parse(x);

                total += num;
            }
            total -= canonSpace;
            return total.ToString();
        }

    }
}

