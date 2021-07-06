using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.View;
using Custom_Program.Model;
using System.Windows.Forms;
using System.Drawing;

namespace Custom_Program.Presenter
{
    public class MarketPlacePresenter: BuildingPresenter
    {
        
        private Marketplace _m;

        public MarketPlacePresenter(IBuilding view, Buildings building, Character player): base(view, player)
        {           
            _m = (Marketplace)building; 
        }

        public override Color Profit(int i)
        {
            if (_player.CargoInfo.CP[i] == 0 || _player.CargoInfo.CP[i] == _m.Prices[i] || _player.CargoInfo.Quantity[i]=="0")
            {
                return Color.Black;
            }
            else if(_player.CargoInfo.CP[i]> _m.Prices[i])
            {
                return Color.Red;
            }
            else
            {
                return Color.Blue;
            }
        }

        public override void DisplayScreen()
        {
            
            display = new Dictionary<int, string[]>();
            display.Add(75, _m.Goods);
            display.Add(170, Array.ConvertAll(_m.Prices, ele => ele.ToString()));    //prices of the goods
           
            display.Add(270, _player.CargoInfo.Quantity);   //quantity in the cargo
            display.Add(380, _m.Qselected); //selected quantity initial

            _view.ItemNames = display;
            _view.CargoTotal = _player.CargoInfo.CargoTotal();
            
        }
        public override void UpdateQuantity(int q, string[] allQ, string[] allP, int change)
        {

            int limit = 0;
            if (change == 1) { limit = -1; }
            int num = int.Parse(allQ[q]);
            if (num > limit)
            {
                allQ[q] = (num + (1*change)).ToString();
            }
            
            _m.Qselected[q] = allQ[q];
            Total(allQ, allP);
            DisplayScreen();
          
        }
      
    
        public override void DisplayArrows()
        {
            _view.Arrows(5, 350, "market");
        }

        public void Total(string[] q, string[] p)
        {
            _view.Total = "0";
            for(int i=0; i < 5; i++)
            {
                int num = int.Parse(_view.Total);
                num+=(Int32.Parse(q[i]) * Int32.Parse(p[i]));
                _view.Total = ""+num;
            }
        }
        public override void Buy()
        {
            if (Int32.Parse(_view.Total) > _player.Assets.Cash)
            {
                MessageBox.Show("Not enough money!");
            }
            else if (Int32.Parse(_player.CargoInfo.CargoTotal()) >= _player.CargoInfo.CargoSpace)
            {
                MessageBox.Show("Not enough space in cargo!");
            }
            else
            {
               
                _player.Assets.Cash -= Int32.Parse(_view.Total);
                for (int i = 0; i < _player.CargoInfo.Quantity.Length; i++)
                {
                    int temp = Int32.Parse(_player.CargoInfo.Quantity[i]);
                    temp += Int32.Parse(_m.Qselected[i]);
                    _player.CargoInfo.Quantity[i] = "" + temp + "";
                    _player.CargoInfo.CP[i] = _m.Prices[i];
                }
               _m.Qselected = new string[]{ "0","0","0","0","0"};

                _view.CargoTotal= _player.CargoInfo.CargoTotal();
                _view.Total = "0";
               
                    _playerDetails.CashText = "" + _player.Assets.Cash;
                DisplayScreen();
            }
        }
        public override void Sell()
        {
                _player.Assets.Cash += Int32.Parse(_view.Total);
                for (int i = 0; i < _player.CargoInfo.Quantity.Length; i++)
                {
                    //int temp = Int32.Parse(m.CargoInfo.Quantity[i]);
                    if(Int32.Parse(_player.CargoInfo.Quantity[i]) < Int32.Parse(_m.Qselected[i]))
                    {
                        MessageBox.Show("Not enough goods in Cargo");
                    }
                else
                {
                    int temp = Int32.Parse(_player.CargoInfo.Quantity[i]);
                    temp -= Int32.Parse(_m.Qselected[i]);
                    _player.CargoInfo.Quantity[i] = "" + temp + "";
                }
                

                }
                _m.Qselected = new string[] { "0", "0", "0", "0", "0" };
                _view.CargoTotal = _player.CargoInfo.CargoTotal();
                _view.Total = "0";
                _playerDetails.CashText = "" + _player.Assets.Cash;
                DisplayScreen();
            }
        }
    }


