using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankGUI.BL
{
    class Transaction
    {
        private Client t_Client;
        private DateTime date;
        private double amount;
        private string transactionType;
        private string refrenceAccount;

        public Transaction(Client c, double amount, DateTime datetime, string tType)
        {
            T_Client = c;
            this.Amount = amount;
            this.Date = datetime;
            this.TransactionType = tType;
            this.RefrenceAccount = "NA";
        }
        public Transaction(Client c, double amount, DateTime datetime, string tType, string accNum)
        {
            T_Client = c;
            this.Amount = amount;
            this.Date = datetime;
            this.TransactionType = tType;
            this.RefrenceAccount = accNum;
        }

        public DateTime Date { get => date; set => date = value; }
        public double Amount { get => amount; set => amount = value; }
        public string TransactionType { get => transactionType; set => transactionType = value; }
        public string RefrenceAccount { get => refrenceAccount; set => refrenceAccount = value; }
        internal Client T_Client { get => t_Client; set => t_Client = value; }
    }
}
