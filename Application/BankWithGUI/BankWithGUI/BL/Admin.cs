using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWithGUI.BL
{
    class Admin
    {
        private Person adminCred;
        public Admin(Person a)
        {
            this.adminCred = a;
        }

        public Person getAdmin()
        {
            return adminCred;
        }
    }
}
