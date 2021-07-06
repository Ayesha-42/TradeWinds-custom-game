using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Custom_Program.Model;

namespace Custom_Program.View
{
    public interface IPort
    {
        //to set up the building labels on the screen according to Port
        List<Point> Locs { set; }

        ///<returns>
        ///the Building subclass type to be worked on
        ///till the time the player is in the Port
        ///</returns>
        Buildings chosen(Label labelSelected);

    }
}
