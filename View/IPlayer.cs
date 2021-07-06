using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program.View
{
    public interface IPlayer
    {
        // all display labels to be set with the player and port details when a port is reached
        string NameText { set; }
        string CashText { get; set; }
        string BankText { get; set; }
        string DebtText { get; set; }

        string RankText { set; }    //allocate rank function
       
        string PortText { set; }
        string DateText { set; }
    }
}
