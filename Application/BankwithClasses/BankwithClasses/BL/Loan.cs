using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankwithClasses.BL
{
    class Loan
    {
        public Client loanreq;
        public float loanamount;
        public string loanTime;
        public Loan(Client loanreq, float loanamount)
        {
            this.loanreq = loanreq;
            this.loanamount = loanamount;
        }
        public Loan(Client loanreq, float loanamount, string loanTime)
        {
            this.loanreq = loanreq;
            this.loanamount = loanamount;
            this.loanTime = loanTime;
        }
    }
}
