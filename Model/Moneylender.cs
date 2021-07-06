using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.Model;

namespace Custom_Program.Model
{
    public class Moneylender: Buildings
    {

        // in order to avoid deep inheritance heirarchy
        public string Selected { get; set; }

        public string Interest { get; set; }

        public Moneylender() : base()
        {
            //nterest is random number between 4-9
            Random rand = new Random();
            Interest = ""+rand.Next(4, 9);
            Selected = "0";
        }

    }
}
