using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Custom_Program.Model;
using System.Windows.Forms;

namespace Custom_Program.Model
{
    public class Islands
    {

        public Dictionary<Buildings, Point> BuildingsLoc { get; set; }
        private string _name;
        public Islands(string name)
        {
            BuildingsLoc = new Dictionary<Buildings, Point>();
            _name = name;
            AllotBuildings();
        }

        public void AllotBuildings()
        {
            Marketplace m = new Marketplace();
            Bank b = new Bank();
            Moneylender l = new Moneylender();
            Shipyard s = new Shipyard();
            Point pt1 = new Point(327, 250), pt2 = new Point(538, 156), pt3 = new Point(318, 142), pt4 = new Point(677, 346);
            Point pt5 = new Point(645, 300), pt6 = new Point(310, 75), pt7 = new Point(1141, 746), pt8 = new Point(300, 250);             
            Point pt9 = new Point(580, 156), pt10 = new Point(330, 160), pt11 = new Point(600, 310), pt12 = new Point(330, 300);
     
            switch (_name)
            {
                case "Kingston":   //port1
                    BuildingsLoc.Add(m, pt1);
                    BuildingsLoc.Add(b, pt2);
                    BuildingsLoc.Add(l, pt3);
                    BuildingsLoc.Add(s, pt4);
                   
                    break;
                case "Panama":
                        //port2
                    BuildingsLoc.Add(m, pt5);
                    BuildingsLoc.Add(b, pt1);
                    BuildingsLoc.Add(l, pt6);
                    BuildingsLoc.Add(s, pt7);
                    break;
                case "Dominican Republic":  //port3
                    BuildingsLoc.Add(m, pt8);
                    BuildingsLoc.Add(b, pt9);
                    BuildingsLoc.Add(l, pt10);
                    BuildingsLoc.Add(s, pt11);
                    break;
                case "Colombia":    //port 4
                    BuildingsLoc.Add(m, pt5);
                    BuildingsLoc.Add(b, pt3);
                    BuildingsLoc.Add(l, pt6);
                    BuildingsLoc.Add(s, pt12);
                    break;
                case "Trinidad":    //port 5
                    BuildingsLoc.Add(m, pt1);
                    BuildingsLoc.Add(b, pt11);
                    BuildingsLoc.Add(l, pt6);
                    BuildingsLoc.Add(s, pt4);
                    break;
            }
        }

    }
}

