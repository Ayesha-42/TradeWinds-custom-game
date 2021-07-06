using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.Model;
using Custom_Program.View;
using System.Drawing;
using System.Windows.Forms;

namespace Custom_Program.Presenter
{
    public class PortPresenter
    {
        private IPort _names;
        private IPlayer _leftPanel;
        private Islands _port;


        public PortPresenter(IPort view, string name)
        {
            _names = view;
            _port = new Islands(name);
            _leftPanel = (IPlayer)view;
        }

        public Islands Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public void DisplayScreen(Character player)
        {
            List<Point> temp = new List<Point>();
            foreach (KeyValuePair<Buildings, Point> x in _port.BuildingsLoc)
            {
                temp.Add(x.Value);
               
            }

            _names.Locs = temp;

            _leftPanel.NameText = player.Name;
            _leftPanel.BankText = ""+player.Assets.Bank;
            _leftPanel.DebtText = ""+player.Assets.Debt;
            _leftPanel.CashText = ""+player.Assets.Cash;
            _leftPanel.RankText = player.Assets.AllotRank();
            _leftPanel.DateText = "" + player.TravelDate;
        }
    }
}
