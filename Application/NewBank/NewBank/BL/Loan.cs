using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Loan
    {
        private Client loanclient;
        private DateTime reqDate;
        private DateTime approvalDate;
        private DateTime returningDate;
        private double reqAmount;
        private double givenAmount;
        private double interest = 10;
        private int loanStatus;
        private string purpose;
        private Item pledgeItem;


        public Loan(Client c, DateTime rd, DateTime ad, DateTime retd, double requestAmount, string purpose, Item pItem, double gAmount,double i, int status)
        {
            this.Loanclient = c;
            this.ReqDate = rd;
            this.ApprovalDate = ad;
            this.ReturningDate = retd;
            this.ReqAmount = requestAmount;
            this.GivenAmount = gAmount;
            this.interest = i;
            this.loanStatus = status;
            this.purpose = purpose;
            this.pledgeItem = pItem;
        }
        public Loan(Client c, DateTime rd,double requestAmount, string purpose, Item pItem)
        {
            this.Loanclient = c;
            this.ReqDate = rd;
            this.ApprovalDate = DateTime.MinValue;
            this.ReturningDate = DateTime.MaxValue;
            this.ReqAmount = requestAmount;
            this.GivenAmount = 0;
            this.interest = 0;
            this.loanStatus = 1;
            this.purpose = purpose;
            this.pledgeItem = pItem;
        }

        
        public DateTime ReqDate
 { get => reqDate; set => reqDate = value;}
        public DateTime ApprovalDate { get => approvalDate; set => approvalDate = value; }
        public double Interset { get => interest; set => interest = value; }
        public int LoanStatus { get => loanStatus; set => loanStatus = value; }
        public string Purpose { get => purpose; set => purpose = value; }
        public Item PledgeItem { get => pledgeItem; set => pledgeItem = value; }
        public DateTime ReturningDate { get => returningDate; set => returningDate = value; }
        public double ReqAmount { get => reqAmount; set => reqAmount = value; }
        public double GivenAmount { get => givenAmount; set => givenAmount = value; }
        internal Client Loanclient { get => loanclient; set => loanclient = value; }

        internal Client Client
        {
            get => default;
            set
            {
            }
        }
    }
}
