using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Custom_Program.Presenter;

namespace Custom_Program.View
{
    public interface IBuilding
    {
        // the display features of the UI Target forms which are worked upon by the Presenters
        Dictionary<int, string[]> ItemNames { set; } // to set the fixed items for sale
        void Arrows(int x, int y, string type);   //2 for each item to increase and decrease

        string Total { get; set; }
        string CargoTotal { set; get; }

    }
}
