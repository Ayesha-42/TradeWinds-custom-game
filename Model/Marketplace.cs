using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Program.Model
{
    public class Marketplace : Buildings
    {

        public int[] Prices { get; set; }
        public string[] Goods { get; set; }
        
        public string[] Qselected { get; set; }

        public Marketplace() : base()
        {
            Goods = new string[] { "Fish", "Cotton", "Arms", "Silk", "Gunpowder" };
            Random rand = new Random();
            Prices = new int[5] { rand.Next(5, 60), rand.Next(20, 100), rand.Next(80, 200), rand.Next(160, 500), rand.Next(400, 2000) };

            Qselected = new string[] { "0", "0", "0", "0", "0" };
       
        }
        

    }
}
