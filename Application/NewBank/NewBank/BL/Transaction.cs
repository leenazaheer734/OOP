using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
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
            t_Client = c;
            this.amount = amount;
            this.date = datetime;
            this.transactionType = tType;
            this.refrenceAccount = "NA";
        }
        public Transaction(Client c, double amount, DateTime datetime, string tType, string accNum)
        {
            t_Client = c;
            this.amount = amount;
            this.date = datetime;
            this.transactionType = tType;
            this.refrenceAccount = accNum;
        }
        public string getRefAccNo()
        {
            return this.refrenceAccount;
        }
        public DateTime getDateTime()
        {
            return this.date;
        }
        public double getAmount()
        {
            return this.amount;
        }
        public string getTypeofTrans()
        {
            return this.transactionType;
        }
        public Client getClientInfo()
        {
            return this.t_Client;
        }
        public Person getPersonInfo()
        {
            return this.t_Client.GetPerson();
        }
        public Account getAccountInfo()
        {
            return this.t_Client.getAccount();
        }
   
    
    }
}
