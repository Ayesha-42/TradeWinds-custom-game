using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Program.Model;
using Custom_Program.View;
using Custom_Program.Presenter;
using System.Drawing;

namespace Custom_Program.Presenter
{
    public abstract class BuildingPresenter
    {
        //only to be accessed and modified by this class in the assembly and the derived classes
        private protected IBuilding _view;
        private protected IPlayer _playerDetails;
        private protected Dictionary<int, string[]> display;
        private protected Character _player;
        public BuildingPresenter(IBuilding view, Character player)
        {
            _view = view;
            _playerDetails = (IPlayer)view;
            _player = player;
        }

        public abstract void DisplayScreen();

        public abstract void DisplayArrows();

   
        public abstract void UpdateQuantity(int q, string[] allQ, string[] allP, int change);
        public abstract void Buy();
        public abstract void Sell();
        public virtual Color Profit(int i)
        {
            return Color.Black;
        }
        public virtual void UpdateQuantity(int change, string[] allQ)
        {

        }
    }
}
