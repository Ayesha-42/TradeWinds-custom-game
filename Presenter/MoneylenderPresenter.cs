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
    public class MoneylenderPresenter : BuildingPresenter
    {        
        private Moneylender _l;

        public MoneylenderPresenter(IBuilding view, Buildings building, Character player): base(view, player)
        {   
            _l = (Moneylender)building;
        }

        public override void DisplayScreen()
        {

            display = new Dictionary<int, string[]>();
            string x = _l.Interest + "%";
            display.Add(75, new string[] { x, _playerDetails.CashText, _playerDetails.DebtText });

            display.Add(250, new string[] { _l.Selected, "", "" });   //quantity in the cargo
            _view.ItemNames = display;

        }

        public override void DisplayArrows()
        {
            _view.Arrows(1, 185, "moneylender");
        }
        public override void UpdateQuantity(int q, string[] allQ, string[] allP, int change)// string[] deposit, int change)
        {

            int limit = 0;
            if (change == 1) { limit = -1; }
            int num = int.Parse(_l.Selected);
            if (num > limit)
            {
                _l.Selected = (num + (100 * change)).ToString();
            }
            _view.Total = _l.Selected;

            DisplayScreen();

        }
        public override void Buy()
        {
           //LOAN
            
            _player.Assets.Cash += Int32.Parse(_view.Total);
            _player.Assets.Debt += Int32.Parse(_view.Total);
            _l.Selected = "0";           
            
            _playerDetails.DebtText = "" + _player.Assets.Debt;
            _playerDetails.CashText = "" + _player.Assets.Cash;

            DisplayScreen();

        }
        public override void Sell()
        {
            //REPAY 
            if (Int32.Parse(_view.Total) > _player.Assets.Cash)
            {
                MessageBox.Show("Not enough money!");
            }
            else if (Int32.Parse(_view.Total) > _player.Assets.Debt)
            {
                MessageBox.Show("But don't have that much Debt!");
            }
            else
            {
                _player.Assets.Cash -= Int32.Parse(_view.Total);
                _player.Assets.Debt -= Int32.Parse(_view.Total);
                _l.Selected = "0";
            }
         
           _playerDetails.DebtText = "" + _player.Assets.Debt;
            _playerDetails.CashText = "" + _player.Assets.Cash;
            _player.Assets.DebtInterest = Convert.ToDecimal(_l.Interest+".00");
            DisplayScreen();
        }
    }
}

