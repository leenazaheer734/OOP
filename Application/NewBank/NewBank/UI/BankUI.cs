using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.DL;

namespace NewBank.UI
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
        public static string FirstInterface()
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
        public static void PrintLoginMenu()
        {
            Console.WriteLine("                              Login Menu                               ");
        }
        public static void PrintLine()
        {
            Console.WriteLine("   ===================================================================");
        }
        public static void UserNotFound()
        {
            Console.WriteLine("    User not found");
            BankUI.GoBack();
        }
        public static void GoBack()
        {
            Console.WriteLine("    Press any key to go back...");
            Console.ReadKey();
        }
        public static void PrintsubMenu(string submenu)
        {
            string message = "Main Menu>" + submenu;
            Console.WriteLine("                   " + message);
            Console.WriteLine("  --------------------------------------------------------------------");
            Console.WriteLine();
        }
        public static string DisplayAdminMenu()
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
            Console.WriteLine("      7. Manage Loan Requests.");
            Console.WriteLine("      8. See loan holders details.");
            Console.WriteLine("      9. Check total money present in bank.");
            Console.WriteLine("     10. See total transactions details.");
            Console.WriteLine("     11. Exit. ");
            Console.WriteLine();
            Console.WriteLine("   -------------------------------------------------------------");
            Console.Write("     Selct an option....");
            Console.Write("   ");
            option = Console.ReadLine();
            return option;
        }
        public static void CalculateTotalMoney()
        {
            Console.WriteLine("  TOtal money present in bank is : " + ClientDL.Totalmoney());
        }
        public static string UpdateMenu()
        {
            string option;
            Console.WriteLine("   what do you want to update: ");
            Console.WriteLine("    1. name:");
            Console.WriteLine("    2. pin: ");
            Console.WriteLine("    3. account type: ");
            Console.WriteLine("    4. balance: ");
            Console.WriteLine("    5. account Status: ");
            Console.WriteLine("    6. phone number: ");
            Console.WriteLine("    7. address: ");
            Console.WriteLine("    8. all of above.");
            option = Console.ReadLine();
            return option;
        }
        public static void showUpdatedMessage()
        {
            Console.WriteLine("   UPdated account details.. ");
        }
        public static bool ValidateName(string name)
        {
            // Name should not be empty
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            // Name should contain only alphabetical characters and spaces
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }

            return true;
        }
        public static string checkNameValidity(string name)
        {
            bool isValid = ValidateName(name);

            if (isValid == false)
            {
                while(isValid != true)
                {
                    Console.Write("   Enter valid name:  ");
                    name = Console.ReadLine();
                    isValid = ValidateName(name);
                }
            }
            return name;
        }
        public static bool ValidatePinLength(string pin)
        {
            // PIN should be exactly 4 characters
            if (pin.Length != 4)
            {
                return false;
            }
            return true;
        }
        public static int checkPinDigits(string num)
        {
            // PIN should contain only numerical digits
            int number;
            while ((int.TryParse(num, out number)) != true)
            {
                Console.WriteLine("    Invalid number!");
                Console.Write("   Enter again: ");
                num = Console.ReadLine();
            }
            return number;
        }
        public static string checkPinLength(string pin)
        {
            bool isValid = ValidatePinLength(pin);

            if (isValid == false)
            {
                while (isValid != true)
                {
                    Console.Write("   Enter 4 digits only:  ");
                    pin = Console.ReadLine();
                    isValid = ValidatePinLength(pin);
                }
            }
            return pin;
        }
        public static double checkBalanceValidity(string tempbalance)
        {
            double balance = 0;
            while ((double.TryParse(tempbalance, out balance)) != true)
            {
                Console.WriteLine("    Balance should only contain numbers!");
                Console.Write("    Enter balance again: ");
                tempbalance = Console.ReadLine();
            }
            return balance;
        }
        public static bool ValidateNumberLength(string number)
        {
            if (number.Length != 11)
            {
                return false;
            }
            return true;
        }
        public static string checkNumberLength(string number)
        {
            bool isValid = ValidateNumberLength(number);

            if (isValid == false)
            {
                while (isValid != true)
                {
                    Console.Write("   Enter 11 digits:  ");
                    number = Console.ReadLine();
                    isValid = ValidatePinLength(number);
                }
            }
            return number;
        }
        public static bool ValidateAddress(string address)
        {
            // Address should not be empty
            if (string.IsNullOrWhiteSpace(address))
            {
                return false;
            }
            return true;
        }
        public static string checkAddress(string address)
        {
            bool isValid = ValidateAddress(address);
            if(isValid == false)
            {
                while(!isValid)
                {
                    Console.Write("  Enter address: ");
                    isValid = ValidateAddress(Console.ReadLine());
                }
            }
            return address;
        }
        public static string checkaccounttype(string accounttype)
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
        public static double Minimum_balance(double balance, string type)
        {
            string tempbalance;
            if (type == "salary" && balance < 500.0)
            {
                while (balance < 500.0) // limiting minimum intial balance of a salary account
                {
                    Console.Write("     Enter starting balance greater then 500: ");
                    tempbalance = Console.ReadLine();
                    balance = checkBalanceValidity(tempbalance);
                }
            }
            else if (type == "current" && balance < 5000.0)
            {
                while (balance < 5000.0) // limiting minimum intial balance of a current account
                {
                    Console.Write("    Enter starting balance greater then 5000: ");
                    tempbalance = Console.ReadLine();
                    balance = checkBalanceValidity(tempbalance);
                }
            }
            return balance;
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

    }
}
