using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.View;
using Custom_Program.Model;
using System.Windows.Forms;

namespace Custom_Program.Presenter
{
    public class BankPresenter: BuildingPresenter
    {
       
        private Bank _b;

        public BankPresenter(IBuilding view, Buildings building, Character player): base(view, player)
        {
            _b = (Bank)building;
        }

        public override void DisplayScreen()
        {

            display = new Dictionary<int, string[]>();
            string x = _b.Interest + "%";
            display.Add(75, new string[] { x, _playerDetails.CashText, _playerDetails.BankText });     
            display.Add(250,new string[] { "","",_b.Selected });   
            _view.ItemNames = display;

        }
       
        public override void DisplayArrows()
        {
            _view.Arrows(1, 185, "bank");           
        }
        public override void UpdateQuantity(int q, string[] allQ, string[] allP,int change)// string[] deposit, int change)
        {

            int limit = 0;
            if (change == 1) { limit = -1; }
            int num = int.Parse(_b.Selected);
            if (num > limit)
            {
                _b.Selected = (num + (100 * change)).ToString();
            }
            _view.Total = _b.Selected;
            
            DisplayScreen();

        }
        public override void Buy()
        {
            //WITHDRAW
            if (Int32.Parse(_view.Total) > _player.Assets.Bank)
            {
                MessageBox.Show("Not enough money in the bank!");
            }
            else
            {
                _player.Assets.Cash += Int32.Parse(_view.Total);
                _player.Assets.Bank-= Int32.Parse(_view.Total);
                _b.Selected = "0";
            }
           
           _playerDetails.BankText = "" + _player.Assets.Bank;
           _playerDetails.CashText = "" + _player.Assets.Cash;

            DisplayScreen();
           
        }
        public override void Sell()
        {
            //Deposit
            if (Int32.Parse(_view.Total) > _player.Assets.Cash)
            {
                MessageBox.Show("Not enough money in the bank!");
            }
            else
            {
                _player.Assets.Cash -= Int32.Parse(_view.Total);
                _player.Assets.Bank += Int32.Parse(_view.Total);
                _b.Selected = "0";
            }
        
           _playerDetails.BankText = "" + _player.Assets.Bank;
            _playerDetails.CashText = "" + _player.Assets.Cash;
            _player.Assets.BankInterest =Convert.ToDecimal(_b.Interest);
            DisplayScreen();
        }
    }
}
