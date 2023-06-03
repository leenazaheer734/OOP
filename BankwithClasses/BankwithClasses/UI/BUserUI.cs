using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using BankwithClasses.DL;

namespace BankwithClasses.UI
{
    class BUserUI
    {
        public static BUser Takeinputwithoutrole()
        {
            Console.Write("    Enter your name:  ");
            string loginusername = Console.ReadLine();
            loginusername = NamelettersValidity(loginusername);
            Console.Write("    Enter your 4-digit security pin: ");
            string loginpassword = Console.ReadLine();
            loginpassword = Pindigitscheck(loginpassword);

            if (loginusername != null && loginpassword != null)
            {
                BUser user = new BUser(loginusername, loginpassword);
                return user;
            }
            return null;
        }
        public static string NamelettersValidity(string name)
        {
            bool alphabets = BUserDL.CheckalphabetsinName(name);
            if (alphabets == false)
            {
                while (alphabets != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("    Invalid name! Name should only contain alphabets!!");
                    Console.Write("    Enter Name again: ");
                    name = Console.ReadLine();
                    alphabets = BUserDL.CheckalphabetsinName(name);
                }
            }
            return name;
        }
        public static string Pindigitscheck(string password)
        {
            int check = password.Length;
            if (check != 4) // taking 4 digit pin as input from user
            {
                while (check != 4)
                {
                    Console.WriteLine("    Invalid pin!");
                    Console.Write("    Enter 4-didgit pin again: ");
                    password = Console.ReadLine();
                    check = password.Length;
                }
            }
            return password;
        }
        public static string Nametakenvalidity(string name)
        {
            bool flag = ClientDL.AlreadyTakenName(name);
            if (flag == true)
            {
                Console.WriteLine("    This name is already Taken!");
                while (flag != false)
                {
                    Console.Write("    Enter Name again: ");
                    name = Console.ReadLine();
                    flag = ClientDL.AlreadyTakenName(name);
                }
            }
            return name;
        }
        public static string CheckpinValidity(string pin)
        {
            bool flag = ClientDL.AlreadyTakenPin(pin);
            if (flag == true)
            {
                Console.Write("    This pin is already taken.");
                while (flag != false)
                {
                    Console.Write("    Enter pin again: ");
                    pin = Console.ReadLine();
                    flag = ClientDL.AlreadyTakenPin(pin);
                }
            }
            return pin;
        }
        public static string Checkaccounttype(string accounttype)
        {
            if (accounttype != "current" && accounttype != "salary") // checking if account type entered by is valid or not
            {
                while (accounttype != "current" && accounttype != "salary") // getting input until user enters a valid account type
                {
                    Console.Write("    Enter valid type: ");
                    accounttype = Console.ReadLine();
                }
            }
            return accounttype;
        }
        public static float BalanceValidity(string tempbalance)
        {
            float balance = 0;
            while ((float.TryParse(tempbalance, out balance)) != true)
            {
                Console.WriteLine("    Balance should only contain numbers!");
                Console.Write("    Enter balance again: ");
                tempbalance = Console.ReadLine();
            }
            return balance;
        }
        public static float Minimum_balance(float balance, string type)
        {
            string tempbalance;
            if (type == "salary" && balance < 500.0)
            {
                while (balance < 500.0) // limiting minimum intial balance of a salary account
                {
                    Console.Write("     Enter starting balance greater then 500: ");
                    tempbalance = Console.ReadLine();
                    balance = BalanceValidity(tempbalance);
                }
            }
            else if (type == "current" && balance < 5000.0)
            {
                while (balance < 5000.0) // limiting minimum intial balance of a current account
                {
                    Console.Write("    Enter starting balance greater then 5000: ");
                    tempbalance = Console.ReadLine();
                    balance = BalanceValidity(tempbalance);
                }
            }
            return balance;
        }
        public static string Phone_numberLength(string number)
        {
            int phone = number.Length;
            if (phone != 11)
            {
                while (phone != 11)            // checking if phone number is 11 digits
                {
                    Console.Write("    Enter 11-digit number: ");
                    number = Console.ReadLine();
                    phone = number.Length;
                }
            }
            return number;
        }
        public static string PhonenumberValidity(string tempphone)
        {
            bool validnumber = CheckonlyNumbers(tempphone);
            if (validnumber == false)
            {
                Console.WriteLine("    Invalid number!");
                while (validnumber != true) // taking input until user enters a valid number
                {
                    Console.Write("    Enter number again: ");
                    tempphone = Console.ReadLine();
                    validnumber = CheckonlyNumbers(tempphone);
                }
            }
            return tempphone;
        }
        public static bool CheckonlyNumbers(string tempnumber)
        {
            bool ifvalid = true;
            int check = tempnumber.Length;
            for (int i = 0; i < check; i++) // checking strings for only numbers
            {
                if (tempnumber[i] != '0' && tempnumber[i] != '1' && tempnumber[i] != '2' && tempnumber[i] != '3' && tempnumber[i] != '4' && tempnumber[i] != '5' && tempnumber[i] != '6' && tempnumber[i] != '7' && tempnumber[i] != '8' && tempnumber[i] != '9')
                {
                    ifvalid = false;
                    break;
                }
            }
            return ifvalid;
        }
        public static int AccountnumValidity(string accnumber)
        {
            int number;
            while ((int.TryParse(accnumber, out number)) != true)
            {
                Console.WriteLine("    INvalid Phonenumber!");
                Console.Write("    Enter Phone number again: ");
                accnumber = Console.ReadLine();
            }
            return number;
        }
        static int CheckPercentage(string tpercent)
        {
            int percentage = 0;
            if (int.TryParse(tpercent, out percentage) != true)
            {
                while (int.TryParse(tpercent, out percentage) != true)
                {
                    Console.Write("   INvalid Percentage! Enter again: ");
                    tpercent = Console.ReadLine();
                }
            }
            else
            {
                percentage = int.Parse(tpercent);
            }
            return percentage;
        }

        public static Client Takeinputwithrole(int accountnum)
        {
            Console.Write("    Enter name of client: ");
            string name = Console.ReadLine();
            name = NamelettersValidity(name);                         // checking if name has only alphabets
            name = Nametakenvalidity(name);                           // checking if name is already taken

            Console.Write("    Enter 4-digit pin for account: ");
            string password = Console.ReadLine();
            password = Pindigitscheck(password);                                        // checing 4digits of password
            password = CheckpinValidity(password);                                      // checking if passwords is alreadytaken

            Console.Write("    Enter type of account (salary/current) : ");
            string accounttype = Console.ReadLine(); ;
            accounttype = Checkaccounttype(accounttype);                     // checking if account type is only salary or current

            Console.Write("    Enter starting balance of account: ");
            string tempbalance = Console.ReadLine();
            float balance = BalanceValidity(tempbalance);                    // chceking if balance enetered contains only numbers
            balance = Minimum_balance(balance, accounttype);

            Console.Write("    Enter phonenumber(without dashes): ");
            string tempphone = Console.ReadLine();
            string phonenumber = Phone_numberLength(tempphone);                  // getting 11 digit phone number
            phonenumber = PhonenumberValidity(tempphone);                // checking if phonenumber contains only numbers
            int accountnumber = accountnum;

            BUser nu = new BUser(name, password, "client");
            Client info = new Client(nu, accounttype, balance, phonenumber, accountnumber, "running");

            return info;
        }
        public static void ViewAllusers()
        {
            Console.WriteLine("    Following  are details of ALL clients: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
            ClientDL.showallclients();
            Console.WriteLine();
        }
        public static void getallClients(Client c)
        {
            Console.WriteLine("     " + c.accountnumbers + "\t\t" + c.credentials.username + "\t\t" + c.credentials.password + "\t" + c.accounttypes + "\t\t" + c.balances + "\t" + c.phonenumbers + "\t" + c.statuses);
        }
        public static Client Takeinput()
        {
            Console.Write("   Enter name of client: ");
            string name = Console.ReadLine();
            name = NamelettersValidity(name); // checking if name has only alphabets

            Console.Write("   Enter pin: ");
            string pin = Console.ReadLine();
            pin = Pindigitscheck(pin);

            Console.Write("   Enter account number: ");
            string tempaccountnumber = Console.ReadLine();         // checkng if account number contains only numbers
            int accountnumber = AccountnumValidity(tempaccountnumber);
            BUser t =new BUser(name, pin);
            Client d = new Client(t, accountnumber);
            return d;
        }
        public static bool findspecificperson(Client s)
        {
            s = ClientDL.Search_account(s);
            if (s != null)
            {
                Console.WriteLine();
                Console.WriteLine("    Following are details of " + s.credentials.username + ": ");
                Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
                Console.WriteLine("     " + s.accountnumbers + "\t\t" + s.credentials.username + "\t\t" + s.credentials.password + "\t" + s.accounttypes + "\t\t" + s.balances + "\t" + s.phonenumbers + "\t" + s.statuses);
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string inputName()
        {
            Console.Write("   Enter new name: ");
            string newname = Console.ReadLine();
            newname = NamelettersValidity(newname);                  // checking if name has only alphabets
            newname = Nametakenvalidity(newname); // checking if name is already taken
            return newname;
        }
        public static string inputPin()
        {
            Console.Write("   Enter new pin: ");
            string newpass = Console.ReadLine();
            newpass = Pindigitscheck(newpass); // checking 4-digits of pin
            newpass = CheckpinValidity(newpass);
            return newpass;
        }
        public static string inputType()
        {
            Console.Write("   Enter new account type: ");
            string newacctype = Console.ReadLine();
            newacctype = Checkaccounttype(newacctype);
            return newacctype;
        }
        public static float inputBalance()
        {
            Console.Write("   Enter new balance: ");
            string tempaccbalance = Console.ReadLine();
            float newbalance = BalanceValidity(tempaccbalance);
            return newbalance;
        }
        public static string inputstatus()
        {
            Console.Write("   Enter new status(freeze/running): ");
            string newstatus = Console.ReadLine();
            return newstatus;
        }
        public static string inputPhoneno()
        {
            Console.Write("   Enter new phonenumber: ");
            string newnumber = Console.ReadLine();
            newnumber = Phone_numberLength(newnumber);  // getting 11 digit phone number
            newnumber = PhonenumberValidity(newnumber); // checking if phonenumber contains only numbers
            return newnumber;
        }
        public static Client updateAll(int accNum)
        {
            string newname = BUserUI.inputName();
            string newpin = BUserUI.inputPin();
            BUser n = new BUser(newname, newpin, "client");
            string accounttype = BUserUI.inputType();
            float balance = BUserUI.inputBalance();
            string status = BUserUI.inputstatus();
            string phonenumber = BUserUI.inputPhoneno();
            Client update = new Client(n, accounttype, balance, phonenumber, accNum, status);
            return update;
        }
        public static int TaxPercent()
        {
            Console.Write("   Enter percentage of tax to implement: ");
            string tpercent = Console.ReadLine();
            int percentofTax = CheckPercentage(tpercent);
            return percentofTax;
        }
        public static  void showbalance(Client d)
        {
            Console.WriteLine("    Your current account balance is: " + ClientDL.getbalance(d));
            BankUI.GoBack();
        }
    }
}
