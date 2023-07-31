using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankGUI.BL
{
    class Account
    {
        private int accountNumber;
        private double balance;
        private string status;
        private string type;

        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public double Balance { get => balance; set => balance = value; }
        public string Status { get => status; set => status = value; }
        public string Type { get => type; set => type = value; }

        public Account(int accountNumber, double balance, string status, string type)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
            this.Status = status;
            this.Type = type;
        }
        public Account(int accountNumber)
        {
            this.AccountNumber = accountNumber;
        }
    }
}
