using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Custom_Program.Model
{
    public class Backend
    {
        public DateTime Dt { get; set; }

        private TimeSpan _ts;

        public Backend()
        {
            Dt = new DateTime(2015, 12, 31);
        }
        public void UpdateDate(string name)  //name of port
        {
            switch (name)
            {
                case "Kingston": _ts = new TimeSpan(2500, 20, 55);
                    break;
                case "Panama":
                    _ts = new TimeSpan(120, 20, 55); break;
                case "Dominican Republic":
                    _ts = new TimeSpan(216, 40, 10); break;
                case "Colombia":
                    _ts = new TimeSpan(150, 35, 0); break;
                case "Trinidad":
                    _ts = new TimeSpan(96, 40, 45); break;

            }
            
            Dt = Dt.Add(_ts);
        }

    }
}
