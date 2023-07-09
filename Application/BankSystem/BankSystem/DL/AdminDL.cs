using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BL;

namespace BankSystem.DL
{
    class AdminDL
    {
        private static Admin onlyAdmin;
       
        
        public static Admin getAdminInfo()
        {
            return onlyAdmin;
        }

    }
}
