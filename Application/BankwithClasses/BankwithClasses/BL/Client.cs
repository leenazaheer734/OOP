using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankwithClasses.BL
{
    class Client
    {
        public BUser credentials;
        public string accounttypes;
        public float balances;
        public string phonenumbers;
        public string statuses;
        public int accountnumbers;
        
        public Client(BUser nu,string accounttype,float balance,string phonenumber,int accountnumber,string status)
        {
            credentials = nu;
            this.accounttypes = accounttype;
            this.balances = balance;
            this.phonenumbers = phonenumber;
            this.accountnumbers = accountnumber;
            this.statuses = status;
        }
        public Client()
        { }
        public Client(BUser d,  int accountnumber)
        {
            this.accountnumbers = accountnumber;
            credentials = d;
        }
    }
}
