using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankwithClasses.BL
{
    class Transaction
    {
        public Client transPerson;
        public float transAmount;
        public string transType;
        public string transTime;
        public Transaction(Client Person , float transAmount, string transType, string transTime)
        {
            transPerson = Person;
            this.transAmount = transAmount;
            this.transType = transType;
            this.transTime = transTime;
        }
    }
}
