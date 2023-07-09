using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankGUI.BL
{
    class Client
    {
        private Person clientCred;
        private Account account;

        public Client(Person c, Account a)
        {
            this.ClientCred = c;
            this.account = a;
        }

        public Account Account { get => account; set => account = value; }
        internal Person ClientCred { get => clientCred; set => clientCred = value; }
    }
}
