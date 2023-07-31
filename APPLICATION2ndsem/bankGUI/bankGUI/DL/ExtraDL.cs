using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankGUI.BL;

namespace bankGUI.DL
{
    class ExtraDL
    {
        private static Client currentClient;

        internal static Client CurrentClient { get => currentClient; set => currentClient = value; }

    }
}
