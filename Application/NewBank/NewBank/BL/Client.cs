using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Client
    {
        private Person client;
        private Account account;

        public Client(Person c, Account a)
        {
            this.client = c;
            this.account = a;
        }

        internal Person Person
        {
            get => default;
            set
            {
            }
        }

        internal Account Account
        {
            get => default;
            set
            {
            }
        }

        internal Transaction Transaction
        {
            get => default;
            set
            {
            }
        }

        public Person GetPerson()
        {
            return client;
        }
        public Account getAccount()
        {
            return account;
        }


        public void setClient(Person c)
        {
            this.client = c;
        }
        public void setAccount(Account a)
        {
            this.account = a;
        }

    }
}
