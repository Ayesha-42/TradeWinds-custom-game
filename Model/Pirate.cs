using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Program.Model
{
    public class Pirate
    {

        public bool Looted { get; set; }
        public bool Sink { get; set; }

        public Pirate()
        {
            Looted = false;
            Sink = false;
        }
        public int Damages { get; set; }

        public bool BattleSequence(DateTime current, Character player)
        {
            Random rand = new Random();
            
            DateTime begin = new DateTime(2015, 12, 31);
            TimeSpan GameTime = current.Subtract(begin);
            int temp = Convert.ToInt32(GameTime.TotalDays);
            if (temp > 6)
            {
                int tester = rand.Next(0, 2000);
                if (tester < 200)
                {
                    
                    int x = player.Ship.HullStrength;
                    do
                    {
                        player.Ship.HullStrength = x;
                        player.Ship.HullStrength -= rand.Next(0, temp / 3);
                        player.Ship.HullStrength += player.Ship.CanonQ * (rand.Next(1, 3));
                        player.Ship.HullStrength += player.Ship.UpgradeLevel * (rand.Next(1, 3));
                        Damages = player.Ship.TotalLife - player.Ship.HullStrength;

                    } while ( Damages <= 0);


                    if (player.Ship.HullStrength <= 0)
                    {
                        Sink = true;
                    }
                    if (tester < 10)
                    {
                        Looted = true;
                        player.CargoInfo.Quantity = new string[] { "0", "0", "0", "0", "0" };
                    }
                    return true;
                }
                else { return false; }
            }
            
            else { return false; }
        }
    }
}
