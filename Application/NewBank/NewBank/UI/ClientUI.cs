using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.DL;

namespace NewBank.UI
{
    class ClientUI
    {
        public static string DisplayClientMenu()
        {
            string option;
            Console.WriteLine("                  Welcome as client !");
            Console.WriteLine("    ------------------------------------------------------------");
            Console.WriteLine("    What do you want to do as client? ");
            Console.WriteLine();
            Console.WriteLine("    1. View your account balance.");
            Console.WriteLine("    2. Deposit cash.");
            Console.WriteLine("    3. Transfer cash to someone from your account.");
            Console.WriteLine("    4. Withdraw cash from your account.");
            Console.WriteLine("    5. Request loan.");
            Console.WriteLine("    6. Veiw your loan if any.");
            Console.WriteLine("    7. Return loan.");
            Console.WriteLine("    8. View Last Month Transactions.");
            Console.WriteLine("    9. Exit.");
            Console.WriteLine();
            Console.WriteLine("    ------------------------------------------------------------");
            Console.Write("    Selct an option....");
            Console.Write("   ");
            option = Console.ReadLine();
            return option;
        }
        public static Client TakeInputWithRole(int accountnum)
        {
            Console.Write("    Enter name of client: ");
            string name = Console.ReadLine();
            name = BankUI.checkNameValidity(name);                                 // checking if name has only alphabets
            name = BankUI.Nametakenvalidity(name);                                 // checking if name is already taken

            Console.Write("    Enter 4-digit pin for account: ");
            string password = Console.ReadLine();
            password = BankUI.checkPinLength(password);                      // checing 4digits of password
            password = BankUI.checkPinDigits(password).ToString(); 
            password = BankUI.CheckpinValidity(password);                         // checking if passwords is alreadytaken


            Console.Write("    Enter type of account (salary/current) : ");
            string accounttype = Console.ReadLine(); ;
            accounttype = BankUI.checkaccounttype(accounttype);                     // checking if account type is only salary or current

            Console.Write("    Enter starting balance of account: ");
            string tempbalance = Console.ReadLine();
            double balance = BankUI.checkBalanceValidity(tempbalance);         // chceking if balance enetered contains only numbers
            balance = BankUI.Minimum_balance(balance, accounttype);

            Console.Write("    Enter phonenumber(without dashes): ");
            string phone = Console.ReadLine();
            phone = BankUI.checkNumberLength(phone);                            // getting 11 digit phone number
            phone = BankUI.checkPinDigits(phone).ToString();                    // checking if phonenumber contains only numbers

            Console.Write("    Enter Address: ");
            string address = Console.ReadLine();
            address = BankUI.checkAddress(address);

            Console.WriteLine();
            Console.WriteLine("    Account number " + accountnum + " successfully created! ");
            Person nu = new Person(name, password, "client", phone,address);
            Account acc = new Account(accountnum, balance, "running", accounttype);
            Client info = new Client(nu, acc);
            accountnum++;


            return info;
        }
        public static Client TakeInputOfClient()
        {
            Console.Write("   Enter name of client: ");
            string name = Console.ReadLine();
            name = BankUI.checkNameValidity(name);                                 // checking if name has only alphabets

            Console.Write("   Enter account number: ");
            string tempaccountnumber = Console.ReadLine();                         // checkng if account number contains only numbers
            int accountnumber = BankUI.checkPinDigits(tempaccountnumber);
           
            Person p = new Person(name);
            Account a = new Account(accountnumber);
            Client c = new Client(p, a);
            return c;
        }
        public static void ViewAllUsers()
        {
            Console.WriteLine("    Following  are details of ALL clients: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber"+ "\t" + "Address" + "\t" + "Status" + "\t");
            
            for (int idx = 0; idx < ClientDL.getClientList().Count; idx++)
            {
                Client c = ClientDL.getClientList()[idx];
                Console.WriteLine("     " + c.getAccount().GetACCnumber() + "\t\t" + c.GetPerson().getName() + "\t\t" + c.GetPerson().getPassword() + "\t" + c.getAccount().getType() + "\t\t" + c.getAccount().getBalance() + "\t" + c.GetPerson().getNumber() +"\t" + c.GetPerson().getAddress() + "\t" + c.getAccount().getStatus());
            }

            Console.WriteLine();
        }
        public static bool findSpecificClient(Client s)
        {
            s = ClientDL.SearchClientAccount(s);
            if (s != null)
            {
                Console.WriteLine();
                Console.WriteLine("    Following are details of " + s.GetPerson().getName() + ": ");
                Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Address" + "\t" + "Status" + "\t");
                Console.WriteLine("     " + s.getAccount().GetACCnumber() + "\t\t" + s.GetPerson().getName() + "\t\t" + s.GetPerson().getPassword() + "\t" + s.getAccount().getType() + "\t\t" + s.getAccount().getBalance() + "\t" + s.GetPerson().getNumber() + "\t" + s.GetPerson().getAddress() + "\t" + s.getAccount().getStatus());
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string inputNewName()
        {
            Console.Write("   Enter new name: ");
            string newname = Console.ReadLine();
            newname = BankUI.checkNameValidity(newname);                  // checking if name has only alphabets
            newname = BankUI.Nametakenvalidity(newname);                  // checking if name is already taken
            return newname;
        }
        public static string inputNewPin()
        {
            Console.Write("   Enter new pin: ");
            string newpass = Console.ReadLine();
            newpass = BankUI.checkPinLength(newpass);                          // checking 4-digits of pin
            newpass = BankUI.checkPinDigits(newpass).ToString();
            return newpass;
        }
        public static string inputNewType()
        {
            Console.Write("   Enter new account type: ");
            string newacctype = Console.ReadLine();
            newacctype = BankUI.checkaccounttype(newacctype);
            return newacctype;
        }
        public static double inputNewBalance()
        {
            Console.Write("   Enter new balance: ");
            string tempaccbalance = Console.ReadLine();
            double newbalance = BankUI.checkBalanceValidity(tempaccbalance);
            return newbalance;
        }
        public static string inputNewstatus()
        {
            Console.Write("   Enter new status(freeze/running): ");
            string newstatus = Console.ReadLine();
            return newstatus;
        }
        public static string inputNewPhoneno()
        {
            Console.Write("   Enter new phonenumber: ");
            string newnumber = Console.ReadLine();
            newnumber = BankUI.checkNumberLength(newnumber);                  // getting 11 digit phone number
            newnumber = BankUI.CheckpinValidity(newnumber);                   // checking if phonenumber contains only numbers
            return newnumber;
        }
        public static string inputNewAddress()
        {
            Console.Write("   Enter new address: ");
            string newaddress = Console.ReadLine();
            newaddress = BankUI.checkAddress(newaddress);
            return newaddress;

        }
        public static void updateAll(Client c)
        {
            string newname = ClientUI.inputNewName();
            string newpin = ClientUI.inputNewPin();
            string accounttype = ClientUI.inputNewType();
            double balance = ClientUI.inputNewBalance();
            string status = ClientUI.inputNewstatus();
            string phonenumber = ClientUI.inputNewPhoneno();
            string address = ClientUI.inputNewAddress();
            c.GetPerson().setName(newname);
            c.GetPerson().setPassword(newpin);
            c.getAccount().setType(accounttype);
            c.getAccount().setBalance(balance);
            c.getAccount().setStatus(status);
            c.GetPerson().setNumber(phonenumber);
            c.GetPerson().setAddress(address);
        }
        public static void ShowClientAccountBalance(Client d)
        {
            Console.WriteLine("    Your current account balance is: " + d.getAccount().getBalance());
            BankUI.GoBack();
        }
       


    }

}
