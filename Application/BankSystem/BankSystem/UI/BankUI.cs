using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BL;
using BankSystem.DL;

namespace BankSystem.UI
{
    class BankUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("   ____             _      __  __                                                   _     ____            _                   ");
            Console.WriteLine("  | __ ) __ _ _ __ | | __ |  \\/  | __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_  / ___| _   _ ___| |_ ___ _ __ ___ ");
            Console.WriteLine("  |  _ \\/ _` | '_ \\| |/ / | |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '_ ` _ \\ / _ \\ '_ \\| __| \\___ \\| | | / __| __/ _ \\ '_ ` _ \\ ");
            Console.WriteLine("  | |_) |(_| | | | | | <  | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_   ___) | |_| \\__ \\  || __/| | | | |");
            Console.WriteLine("  |____/\\_,|_|_| |_| |\\_\\ |_|  |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_| |_| |_|\\___|_| |_|\\__| |____/ \\__, |___/\\__\\__|_| |_| |_|");
            Console.WriteLine("                                                    |___/                                       |___/                     ");
            Console.WriteLine();
            Console.WriteLine("      <><><>----<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>---<>----<>---<><><>");
            Console.WriteLine("       <><><>---<>---<>---<>---<>---<>---<>---<< BANK MANAGEMENT SYSTEM >>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine();
        }
        public static void PrintsubMenu(string submenu)
        {
            string message = "Main Menu>" + submenu;
            Console.WriteLine("                   " + message);
            Console.WriteLine("  --------------------------------------------------------------------");
            Console.WriteLine();
        }
        public static string Firstinterface()
        {
            string option;
            Console.WriteLine("                             Welcome!!                               ");
            Console.WriteLine(" ====================================================================");
            Console.WriteLine("   1. Sign In");
            Console.WriteLine("   2. Exit");
            Console.Write("  PLease enter a choice: ");
            option = Console.ReadLine();
            return option;
        }
        public static string AdminMenu()
        {
            string option;
            Console.WriteLine("     Welcome as an Admin!");
            Console.WriteLine("   -------------------------------------------------------------");
            Console.WriteLine("     What do you want to do as admin? ");
            Console.WriteLine();
            Console.WriteLine("      1. Create a user account.");
            Console.WriteLine("      2. Close an existing user account.");
            Console.WriteLine("      3. Temporarily freeze a user's account");
            Console.WriteLine("      4. Search a specific user's info.");
            Console.WriteLine("      5. Update a specific user's info.");
            Console.WriteLine("      6. View all users personal info. ");
            Console.WriteLine("      7. Give loan to a user.");
            Console.WriteLine("      8. See loan holders details.");
            Console.WriteLine("      9. Check total money present in bank.");
            Console.WriteLine("     10. Implement tax on user's account.");
            Console.WriteLine("     11. See total transactions details.");
            Console.WriteLine("     12. Exit. ");
            Console.WriteLine();
            Console.WriteLine("   -------------------------------------------------------------");
            Console.Write("     Selct an option....");
            Console.Write("   ");
            option = Console.ReadLine();
            return option;
        }
        public static string ClientMenu()
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
            Console.WriteLine("    7. Return loan. ");
            Console.WriteLine("    8. Pay bills.");
            Console.WriteLine("    9. Exit. ");
            Console.WriteLine();
            Console.WriteLine("    ------------------------------------------------------------");
            Console.Write("    Selct an option....");
            Console.Write("   ");
            option = Console.ReadLine();
            return option;
        }
        public static void PrintLoginMenu()
        {
            Console.WriteLine("                              Login Menu                               ");
        }
        public static Admin SignUPasAdmin()
        {
            Console.WriteLine("   First Sign Up as Admin");
            Console.Write("    Enter name:  ");
            string name = Console.ReadLine();
            // name = NamelettersValidity(name);
            Console.Write("    Enter your 4-digit security pin: ");
            string password = Console.ReadLine();
            // password = Pindigitscheck(password);
            Console.Write("    Enter your contact number: ");
            string phonenumber = Console.ReadLine();
            Console.Write("    Enter your address: ");
            string address = Console.ReadLine();


            Person p1 = new Person(name, password, "admin",phonenumber,address);
            Admin ad1 = new Admin(p1);
            return ad1;
        }
        public static void PrintLine()
        {
            Console.WriteLine("   ===================================================================");
        }
        public static Person Takeinputwithoutrole()
        {
            Console.Write("    Enter your name:  ");
            string loginusername = Console.ReadLine();
           // loginusername = NamelettersValidity(loginusername);
            Console.Write("    Enter your 4-digit security pin: ");
            string loginpassword = Console.ReadLine();
           // loginpassword = Pindigitscheck(loginpassword);

            if(loginusername != null && loginpassword != null)
            {
                Person user = new Person(loginusername, loginpassword);
                return user;
            }
            return null;
        }
        public static Client Takeinputwithrole(int accountnum)
        {
            Console.Write("    Enter name of client: ");
            string name = Console.ReadLine();
            /*name = NamelettersValidity(name);                         // checking if name has only alphabets
            name = Nametakenvalidity(name); */                          // checking if name is already taken

            Console.Write("    Enter 4-digit pin for account: ");
            string password = Console.ReadLine();
           /* password = Pindigitscheck(password);                                        // checing 4digits of password
            password = CheckpinValidity(password);     */                                 // checking if passwords is alreadytaken

            Console.Write("    Enter type of account (salary/current) : ");
            string accounttype = Console.ReadLine(); ;
           /* accounttype = Checkaccounttype(accounttype);    */                 // checking if account type is only salary or current

            Console.Write("    Enter starting balance of account: ");
            double tempbalance = double.Parse(Console.ReadLine());
           /* float balance = BalanceValidity(tempbalance);                    // chceking if balance enetered contains only numbers
            balance = Minimum_balance(balance, accounttype);*/

            Console.Write("    Enter phonenumber(without dashes): ");
            string tempphone = Console.ReadLine();
            /*string phonenumber = Phone_numberLength(tempphone);                  // getting 11 digit phone number
            phonenumber = PhonenumberValidity(tempphone);  */              // checking if phonenumber contains only numbers
            Console.Write("    Address: ");
            string address = Console.ReadLine();
            accountnum++;
            Console.WriteLine();
            Console.WriteLine("    Account number " + accountnum + " successfully created! ");
            Person nu = new Person(name, password, "client");
            PersonDL.storeuserinlist(nu);
            Account acc = new Account(accountnum, tempbalance, "running", accounttype);
            Client info = new Client(nu, acc, tempphone, address);

            return info;
        }

        public static void GoBack()
        {
            Console.WriteLine("    Press any key to go back...");
            Console.ReadKey();
        }

    }
}
