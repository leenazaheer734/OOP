using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin.BL
{
    class Blogin
    {
        public string loginusername = "";
        public string loginpassword = "";
        public string loginrole = "";
        public int loginaccountnumber;
        public float loginaccountbalance;
    }
    class Credentials
    {
        public string usernames;
        public string passwords;
        public string roles;
        public string accounttypes;
        public float balances;
        public string phonenumbers;
        public string statuses;
        public int accountnumbers;
    }
    class Reqloan
    {
        public string requestloanpoeple;
        public float requestloanamounts;
        public int requestloanaccounts;
    }
   
}
