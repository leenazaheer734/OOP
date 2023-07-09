using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BL
{
    class Client
    {
        private Person client;
        private Account account;

        public Client(Person p, Account acc)
        {
            client = p;
            account = acc;
        }
        public Person getClient()
        {
            return client;
        }
        public Account getAccount()
        {
            return account;
        }

    }
}
