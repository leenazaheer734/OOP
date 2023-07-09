using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;

namespace NewBank.UI
{
    class AccountUI
    {
        public static void showCloseAccount()
        {
            Console.WriteLine();
            Console.WriteLine("   Account succesfully closed! ");
        }
        public static void showBlockedStatus()
        {
            Console.WriteLine();
            Console.WriteLine("                Account is blocked now!");
        }
    }
}
