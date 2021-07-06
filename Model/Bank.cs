using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.Model;

namespace Custom_Program.Model
{
    public class Bank : Buildings
    {
        public string Selected { get; set; }
      
        public string Interest { get; set; }

        public Bank() : base()
        {
            // _interest= Random between 2 - 5%;
            Random rand = new Random();
            Interest = ""+rand.Next(1, 4);
            Selected = "0";

        }

    }
}
