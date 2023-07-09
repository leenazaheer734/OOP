using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.DL;
using NewBank.BL;

namespace NewBank.UI
{
    class TransUI
    {
        public static Transaction depositMoney(Client c)
        {
            Console.Write("   Enter amonut you want to deposit : ");
            double tempdeposit = double.Parse(Console.ReadLine());
            //  float depositAmount = BUserUI.BalanceValidity(tempdeposit);

            double finalBalance = c.getAccount().getBalance() + tempdeposit;
            c.getAccount().setBalance(finalBalance);
            DateTime date = DateTime.Now;

            Transaction t = new Transaction(c, tempdeposit, date, "deposit");
            return t;
        }
        public static Transaction withdrawMoney(Client c)
        {
            Console.Write("   Enter amonut you want to withdraw : ");
            double tempwithdraw = double.Parse(Console.ReadLine());
            // float withdrawAmount = BUserUI.BalanceValidity(tempwithdraw);
            double finalBalance = c.getAccount().getBalance() - tempwithdraw;
            c.getAccount().setBalance(finalBalance);
            DateTime date = DateTime.Now;

            Transaction t = new Transaction(c, tempwithdraw , date, "withdraw");
            return t;
        }
        public static void ShowTransDetails()
        {
            Console.WriteLine("    Following  are details of ALL transactions: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t " + "transAmount" + "\t" + "transType" + "\t    " + "Date" + "    " + "time" + "\t" + "Refernce account");
           
            foreach (Transaction t in TransDL.getTransactions())
            {
                if (t.getTypeofTrans() == "deposit")
                {
                    Console.WriteLine("       " + t.getAccountInfo().GetACCnumber() + "\t" + t.getPersonInfo().getName() + "\t  " + t.getAmount() + "\t" + t.getTypeofTrans() + "\t        " + t.getDateTime().ToString() + "\t" + t.getRefAccNo());
                }
                else
                {
                    Console.WriteLine("       " + t.getAccountInfo().GetACCnumber() + "\t" + t.getPersonInfo().getName() + "\t\t" + t.getAmount() + "\t" + t.getTypeofTrans() + "\t" + t.getDateTime().ToString() + "\t" + t.getRefAccNo());
                }
            }
            Console.WriteLine();
        }
        public static void showLastMonthTransactions(Client c)
        {
            if(TransDL.checkOneMonthDateDiff(c).Count > 0 )
            {
                Console.WriteLine("    Following  are details of ALL transactions: ");
                Console.WriteLine("    Accountno" + "\t" + "Name" + "\t " + "transAmount" + "\t" + "transType" + "\t    " + "Date" + "    " + "time"  +"\t" + "Refernce account");

                foreach (Transaction t in TransDL.checkOneMonthDateDiff(c))
                {
                    if (t.getTypeofTrans() == "deposit")
                    {
                        Console.WriteLine("       " + t.getAccountInfo().GetACCnumber() + "\t" + t.getPersonInfo().getName() + "\t  " + t.getAmount() + "\t" + t.getTypeofTrans() + "\t        " + t.getDateTime().ToString() +"\t" + t.getRefAccNo());
                    }
                    else
                    {
                        Console.WriteLine("       " + t.getAccountInfo().GetACCnumber() + "\t" + t.getPersonInfo().getName() + "\t\t" + t.getAmount() + "\t" + t.getTypeofTrans() + "\t" + t.getDateTime().ToString()+ "\t" + t.getRefAccNo());
                    }
                }
            }
        }
        public static void showAccBlockedNessage(string s)
        {
            Console.WriteLine("   You cannot " +s+ " money , your account is blocked");
        }
        public static void showTransMessage(string s)
        {
            Console.WriteLine("    Money has been " + s);
        }
        public static Transaction transferMoney(Client c)
        {
            Console.Write("   Enter name of person to which u want to transfer money: ");
            string someone_name = Console.ReadLine();
            Console.Write("   Enter account number to which you want to transfer money: ");
            int tempaccount = int.Parse(Console.ReadLine());
          //  int someone_account = BUserUI.AccountnumValidity(tempaccount);

            Account a = new Account(tempaccount);
            Person p = new Person(someone_name);
            Client c1 = new Client(p, a);
            c1 = ClientDL.SearchClientAccount(c1);        //checking if recipient's account exists
            if (c1 != null)
            {
                Console.Write("   Enter money you want to transfer: ");
                double transfer_money = float.Parse(Console.ReadLine());
                string transfeeAccount = c1.getAccount().GetACCnumber().ToString();

                TransDL.addMoneyInAccount(transfer_money, c1);     //addming money in recipient's account
                TransDL.minusMoneyFromAccount(transfer_money, c);   //subtracting from sender's account

                Transaction t = new Transaction(c,transfer_money,DateTime.Now,"transfer",transfeeAccount);
                return t;
            }
            else
            {
                Console.WriteLine("   This account number is not valid.");
                return null;
            }
        }

    }
}
 