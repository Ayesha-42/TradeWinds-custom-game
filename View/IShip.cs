using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program.View
{
    interface IShip
    {
        /// <description>
        ///    to maintain the current ship's update stage
        ///    by the shipyard which works on it, making the update
        ///    and the player which owns the ship, reflecting the update
        /// </description>

        int UpgradeLevel { get; set; }
    }
}
