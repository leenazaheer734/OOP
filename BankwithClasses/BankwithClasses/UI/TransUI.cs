using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using BankwithClasses.DL;

namespace BankwithClasses.UI
{
    class TransUI
    {
        public static void depositMoney(Client c)
        {
            Console.Write( "   Enter amonut you want to deposit : ");
            string tempdeposit = Console.ReadLine();
            float depositAmount = BUserUI.BalanceValidity(tempdeposit);

            ClientDL.addmoneyinaccount(depositAmount,c);
            string cDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Transaction t = new Transaction(c, depositAmount, "deposit", cDateTime);
            TransactionDL.doTransaction(t);
            ClientDL.Updatedatainfile1();
            TransactionDL.storeDatainfile2(t);
        }
        public static void headofdata()
        {
            Console.WriteLine("    Following  are details of ALL transactions: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t " + "transAmount" + "\t" + "transType" + "\t    " + "Date" + "    " + "time");
            TransactionDL.ViewAlltransactions();
            Console.WriteLine();
        }
        public static void viewdata(Transaction t)
        {
            if(t.transType == "deposit")
            {
                Console.WriteLine("       " + t.transPerson.accountnumbers + "\t" + t.transPerson.credentials.username + "\t\t" + t.transAmount + "\t" + t.transType + "\t        " + t.transTime);
            }
            else
            {
                Console.WriteLine("       " + t.transPerson.accountnumbers + "\t" + t.transPerson.credentials.username + "\t\t" + t.transAmount + "\t" + t.transType + "\t" + t.transTime);
            }
        }
        public static void withdrawMoney(Client c)
        {
            Console.Write("   Enter amonut you want to withdraw : ");
            string tempwithdraw = Console.ReadLine();
            float withdrawAmount = BUserUI.BalanceValidity(tempwithdraw);

            ClientDL.cutmoneyfromaccount(withdrawAmount, c);
            string cDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Transaction t = new Transaction(c, withdrawAmount, "withdraw", cDateTime);
            TransactionDL.doTransaction(t);
            ClientDL.Updatedatainfile1();
            TransactionDL.storeDatainfile2(t);
            Console.WriteLine("    Money has been withdrawn");
        }
        public static void transfermoney(Client c)
        {
            Console.Write("   Enter name of person to which u want to transfer money: ");
            string someone_name = Console.ReadLine();
            Console.Write("   Enter account number to which you want to transfer money: ");
            string tempaccount = Console.ReadLine();

            int someone_account = BUserUI.AccountnumValidity(tempaccount);
            bool isvalid = ClientDL.findAccount(someone_name, someone_account);
            if (isvalid == true)
            {
                Console.Write("   Enter money you want to transfer: ");
                float transfer_money = float.Parse(Console.ReadLine());
                ClientDL.moneyTransfertoSomeone(someone_account, transfer_money,c.balances,c.accountnumbers);
            }
            else
            {
                Console.WriteLine("   This account number is not valid.");
            }
        }
        public static void payBills(int accnum)
        {
            Console.Write("    Enter amount of bill: ");
            string temp_bill = Console.ReadLine();
            float bill = BUserUI.BalanceValidity(temp_bill);
            Console.Write("    ENter recepient account number: ");
            string temp_accnumber = Console.ReadLine();
            int recp_accnumber = BUserUI.AccountnumValidity(temp_accnumber);
            ClientDL.payBills(recp_accnumber, bill, accnum);
        }
        
    }
}
