using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BL
{
    class Account
    {
        private int accountNumber;
        private double balance;
        private string status;
        private string type;
        public Account(int accountNumber, double balance, string status, string type)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.status = status;
            this.type = type;
        }
        public int GetACCnumber()
        {
            return this.accountNumber;
        }
        public double getBalance()
        {
            return this.balance;
        }
        public string getStatus()
        {
            return this.status;
        }
        public string getType()
        {
            return this.type;
        }

        public void setACCnumber(int accnumber)
        {
            this.accountNumber = accnumber;
        }
        public void setBalance(double balance)
        {
            this.balance = balance;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }
        public void setType(string type)
        {
            this.type = type;
        }
    }
}
