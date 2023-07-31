using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using BankwithClasses.DL;

namespace BankwithClasses.UI
{
    class LoanUI
    {
        public static void Requestloan(Client u)
        {

            Console.Write("    Enter your account number: ");
            string tempaccnumber = Console.ReadLine(); ;
            int accountnumber = BUserUI.AccountnumValidity(tempaccnumber);
            Console.Write("    Re-Enter your account pin: ");
            string pin = Console.ReadLine();
            pin = BUserUI.Pindigitscheck(pin);
            bool presence = ClientDL.checkaccountPresence(accountnumber, pin);
            if (presence == true)
            {
                Console.Write("    Do you want to request loan(y for yes /n for no): ");
                char confirm = char.Parse(Console.ReadLine());
                if (confirm == 'y')
                {
                    ClientDL.reQuestLoan(u);
                }
                else
                {
                    BankUI.GoBack();
                }
            }
            else
            {
                Console.WriteLine("    USer not found!");
                BankUI.GoBack();
            }
        }
        /*void displayLoanDetails()
        {
            Console.WriteLine("   Your loan details are given below: ");
            Console.WriteLine("   Amount"+ "\t"  + "Time" );
            for (int index = 0; index < loan_count; index++)
            {
                if (loanholders[index] == loginusername && loanholderaccounts[index] == loginaccountnumber)
                {
                    // displaying loan details
                    Console.WriteLine("   " << givenloanamounts[index] << "\t\t" << loantime[index]);
                    break;
                }
            }
        }*/
        public static void showLoanRequests()
        {
            Console.WriteLine("    Folloing are the people who requested for loan: ");
            Console.WriteLine("    Accountno"+ "\t"+ "Name"+ "\t"+ " Amount");
            LoanDL.finadloareq();
        }
        public static void showloan(Loan l)
        {
            Console.WriteLine("     " + l.loanreq.accountnumbers + "\t\t"+ l.loanreq.credentials.username  + "\t" + l.loanamount);
        }
        public static void giveLoan()
        {
            Console.WriteLine();
            Console.Write("    Enter account name whom you want to give loan: ");
            string name = Console.ReadLine();
            name = BUserUI.NamelettersValidity(name);
            Console.Write("    Enter client's account number: ");
            string tempaccnumber= Console.ReadLine();
            int loanholderaccount = BUserUI.AccountnumValidity(tempaccnumber);

            ClientDL.approveLoan(name,loanholderaccount);
        }
        public static void viewloanholders()
        {
            Console.WriteLine("    Following are loan holders details.." );
            Console.WriteLine();
            Console.WriteLine("   Account" + "\t" + "Names" + "\t" + "amount"  + "\t" + "time");
            // all people who have taken loan
            LoanDL.viewloanp();
        }
        public static void showloanperson(Loan l)
        {
            Console.WriteLine("     " + l.loanreq.accountnumbers + "\t\t" + l.loanreq.credentials.username + "\t" + l.loanamount+"\t"+ l.loanTime );
        }
        public static void displayLoanDetails(Client u)
        {
            Console.WriteLine("   Your loan details are given below: ");
            Console.WriteLine("   Amount"+ "\t"+ "TimeLeft" );
            LoanDL.findloan(u);
        }
        public static void yourloan(Loan l)
        {
            Console.WriteLine("   " + l.loanamount + "\t\t" + l.loanTime );
        }


    }
}
