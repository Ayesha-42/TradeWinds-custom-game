using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.Model;
using Custom_Program.View;
using System.Windows.Forms;

namespace Custom_Program.Presenter
{
    public class ShipyardPresenter: BuildingPresenter
    {
       
        private Shipyard _s;

        public ShipyardPresenter(IBuilding view, Buildings building, Character player): base(view, player)
        {           
            _s = (Shipyard)building;          
            _s.UpgradeLevel = player.Ship.UpgradeLevel;
           
        }



        public override void DisplayScreen()
        {
            
            display = new Dictionary<int, string[]>();

            display.Add(75, new string[] { _s.nameGet(),""+ _player.Ship.HullStrength,_s.RepairP, _s.Points}); ;          
            display.Add(200, new string[] { "Canons", ""+_s.Shipnames[_player.Ship.UpgradeLevel+1],"","" });   //cannons and upgrade ship available
                                                                     // display.Add(380, m.qSelected); //selected quantity initial
            display.Add(300, new string[] {  ""+_s.CanonP, ""+_s.ShipP,"" ,""});
            display.Add(350, new string[] {  "" + _player.Ship.CanonQ, "" + _s.nameGet() ,"",""});

            display.Add(450, new string[] {  ""+_s.CanonQselected, ""+_s.ShipQselected,"",""});
            _view.ItemNames = display;

        }

        public override void DisplayArrows()
        {
            _view.Arrows(1, 40, "repair");
            _view.Arrows(2, 400, "shipyard");

        }
        public override void UpdateQuantity(int change, string[] allQ) 
        {

            int limit = 0;
            if (change == 1) { limit = -1; }
            int num = int.Parse(allQ[3]);
            
            if (_player.Ship.TotalLife-_player.Ship.HullStrength>num && num> limit)
            {
                allQ[3] = (num + (1 * change)).ToString();
            }

            _s.Points = allQ[3];
            Total(allQ[3], allQ[2]);
          
            DisplayScreen();
        }
        public override void UpdateQuantity(int q, string[] allQ, string[] allP, int change)// string[] deposit, int change)
        {

            int limit = 0;
            if (change == 1) { limit = -1; }
            int num = Int32.Parse(allQ[q]);
            if (q == 1)
            {
               
             
                if (num > limit && _s.Shipnames.Length > num)
                {
                    allQ[q] = (num + (1 * change)).ToString();
                    _s.ShipQselected = (num + (1 * change));
                }
            }
            else
            {
                if (num > limit && _player.CargoInfo.CargoSpace - Int32.Parse(_player.CargoInfo.CargoTotal()) > num)
                {
                    allQ[q] = (num + (1 * change)).ToString();
                    _s.CanonQselected = num + (1 * change);
                }

            }

            Total(allQ, allP);   
            DisplayScreen();

        }

        public void Total(string q, string p)
        {
          
            _view.CargoTotal = "" + (Int32.Parse(q) * Int32.Parse(p));

        }
        public void Total(string[] q, string[] p)
        {
            _view.Total = "0";
            for (int i = 0; i < 2; i++)
            {
                int num = int.Parse(_view.Total);
                num += (Int32.Parse(q[i]) * Int32.Parse(p[i]));
                _view.Total = "" + num;
            }
        }
        public override void Sell()
        {
            //REPAIR

            _player.Ship.HullStrength += Int32.Parse(_s.Points);
            _player.Assets.Cash -= Int32.Parse(_view.CargoTotal);
           
            _playerDetails.CashText = "" + _player.Assets.Cash;
            _s.Points = "0";
            _view.CargoTotal = "0";

            DisplayScreen();

        }
        public override void Buy()
        {

            // Buy the ship upgrades and canons
            if (Int32.Parse(_view.Total) > _player.Assets.Cash)
            {
                MessageBox.Show("Not enough money!");
            }
            else
            {
                _player.Assets.Cash -= Int32.Parse(_view.Total);
               
                
                
                if (_player.Ship.HullStrength == _player.Ship.TotalLife)
                {
                    //if fully repaired ship the potential upgrade increases hull strength to the new totallife
                    _player.Ship.HullStrength = (_s.ShipQselected * 10) + 30;
                }
              
                    _player.Ship.UpgradeLevel += _s.ShipQselected;
                    _s.UpgradeLevel += _s.ShipQselected;
                    _player.Ship.TotalLife = (_s.ShipQselected * 10) + 30;
                    _player.CargoInfo.CargoSpace= (_s.ShipQselected * 10) + 30;
                    _player.CargoInfo.CanonSpace= _s.CanonQselected;

                   
                    _player.Ship.CanonQ += _s.CanonQselected;
                    _s.CanonQselected = 0;
                    _s.ShipQselected = 0;
                    _view.Total = "0";
            }
            
           
            _playerDetails.CashText = "" + _player.Assets.Cash;
            DisplayScreen();
        }
    }
}
