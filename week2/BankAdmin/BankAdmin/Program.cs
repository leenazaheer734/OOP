using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAdmin.BL;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int accountnum = 0;

            List<Credentials> users = new List<Credentials>();
            List<Blogin> loginInfo = new List<Blogin>();
            List<Reqloan> reqLoan = new List<Reqloan>();
            string choice = "", adminChoice = "", clientChoice = "";
            bool validuser;

            LoadDatafromFile1(users, ref accountnum);
            {
                while (choice != "2")
                {
                    Header();
                    choice = Firstinterface();
                    if (choice == "1")
                    {
                        Header();
                        Console.WriteLine("                              Login Menu                               ");
                        Console.WriteLine("    ===================================================================");
                        string loginusername, loginpassword;

                        Console.Write("    Enter your name:  ");
                        loginusername = Console.ReadLine();
                        loginusername = NamelettersValidity(loginusername);
                        Console.Write("    Enter your 4-digit security pin: ");
                        loginpassword = Console.ReadLine();
                        loginpassword = Pindigitscheck(loginpassword);

                        validuser = CheckUserExistance(loginusername, loginpassword, users);
                        if (validuser == true)
                        {
                            Blogin plogin = new Blogin();
                            plogin.loginusername = loginusername;
                            plogin.loginpassword = loginpassword;
                            plogin.loginrole = CheckRole(loginusername, loginpassword, users);
                            plogin.loginaccountnumber = Checkloginpersonaccountnumber(users, loginusername, plogin.loginpassword);
                            plogin.loginaccountbalance = CheckloginaccountBalance(users, loginusername, plogin.loginaccountnumber);
                            loginInfo.Add(plogin);
                            if (plogin.loginrole == "admin")
                            { 
                                while (adminChoice != "12")
                                {
                                    Header();
                                    adminChoice = AdminMenu();
                                    if (adminChoice == "1")
                                    {
                                        Header();
                                        string submenu = "Create Client Account";
                                        PrintsubMenu(submenu);
                                        Credentials info = new Credentials();
                                        string tempphone, tempbalance;

                                        Console.Write("    Enter name of client: ");
                                        info.usernames = Console.ReadLine();
                                        info.usernames = NamelettersValidity(info.usernames);                         // checking if name has only alphabets
                                        info.usernames = Nametakenvalidity(info.usernames, users);                  // checking if name is already taken

                                        Console.Write("    Enter 4-digit pin for account: ");
                                        info.passwords = Console.ReadLine();
                                        info.passwords = Pindigitscheck(info.passwords);                                        // checing 4digits of password
                                        info.passwords = CheckpinValidity(info.passwords, users);                             // checking if passwords is alreadytaken

                                        Console.Write("    Enter type of account (salary/current) : ");
                                        info.accounttypes = Console.ReadLine(); ;
                                        info.accounttypes = Checkaccounttype(info.accounttypes);                // checking if account type is only salary or current

                                        Console.Write("    Enter starting balance of account: ");
                                        tempbalance = Console.ReadLine();
                                        info.balances = BalanceValidity(tempbalance);                    // chceking if balance enetered contains only numbers
                                        info.balances = Minimum_balance(info.balances, info.accounttypes);

                                        Console.Write("    Enter phonenumber(without dashes): ");
                                        tempphone = Console.ReadLine();
                                        info.phonenumbers = Phone_numberLength(tempphone);                  // getting 11 digit phone number
                                        info.phonenumbers = PhonenumberValidity(tempphone);                // checking if phonenumber contains only numbers
                                        info.accountnumbers = accountnum;

                                        Console.WriteLine();
                                        Console.WriteLine("    Account number " + accountnum + " successfully created! ");
                                        users.Add(info);
                                        StoreinFile1(ref accountnum, users);        // storing data in people file
                                        accountnum++;
                                        
                                        GoBack();
                                    }
                                    else if (adminChoice == "2")
                                    {
                                        Header();
                                        Console.WriteLine();
                                        string submenu = "Delete Client Account";
                                        PrintsubMenu(submenu);

                                        string name, pin, tempaccountnumber;
                                        int accountnumber;

                                        Console.Write("   Enter name of client: ");
                                        name = Console.ReadLine();
                                        name = NamelettersValidity(name); // checking if name has only alphabets
                                        Console.Write("  Enter pin: ");
                                        pin = Console.ReadLine();
                                        pin = Pindigitscheck(pin);
                                        Console.Write("  Enter account number: ");
                                        tempaccountnumber = Console.ReadLine();         // checkng if account number contains only numbers
                                        accountnumber = AccountnumValidity(tempaccountnumber);
                                        // closing an account
                                        bool check = CheckUserExistance(name, pin, users);
                                        if (check == true)
                                        {
                                            Account_close(accountnumber, name, pin, users);
                                            Updatedatainfile1(users);
                                            Console.WriteLine();
                                            Console.WriteLine("   Account succesfully closed! ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("   User does not exists! ");
                                        }
                                        GoBack();
                                    }
                                    else if (adminChoice == "3")
                                    {
                                        Header();
                                        string submenu = "Freeze Client Account";
                                        PrintsubMenu(submenu);
                                        string tempaccnumber, pin;
                                        int accountnumber;

                                        Console.Write("    Enter account number you want to freeze: ");
                                        tempaccnumber = Console.ReadLine(); // checkng if account number contains only numbers
                                        accountnumber = AccountnumValidity(tempaccnumber);
                                        Console.Write("    Enter account pin: ");
                                        pin = Console.ReadLine();
                                        pin = Pindigitscheck(pin); // check 4-digits of passwords

                                        bool flag = Freeze_account(accountnumber, pin, users);
                                        if (flag == true)
                                        {
                                            Console.Write("    Account is blocked now!");
                                        }
                                        else if (flag == false)
                                        {
                                            Console.Write("    Account does not exists..");
                                        }
                                        GoBack();
                                    }
                                    else if (adminChoice == "4")
                                    {
                                        Header();
                                        string submenu = "Search Client Account";
                                        PrintsubMenu(submenu);
                                        string name, tempaccnumber;
                                        int accountnumber;

                                        Console.Write("    Enter name:  ");
                                        name = Console.ReadLine();
                                        name = NamelettersValidity(name);           // checking if name has only alphabets

                                        Console.Write("    Enter account number: ");
                                        tempaccnumber = Console.ReadLine();         // checkng if account number contains only numbers
                                        accountnumber = AccountnumValidity(tempaccnumber);

                                        // searching a user's details
                                        bool flag = Search_account(name, accountnumber, users);
                                        if (flag == false)
                                        {
                                            Console.Write("    Account  not  found!");
                                        }
                                        GoBack();
                                    }
                                    else if (adminChoice == "5")
                                    {
                                        Header();
                                        string submenu = "Updating Client's Record";
                                        PrintsubMenu(submenu);

                                        string option, name;
                                        string tempaccnumber, tempaccbalance;

                                        Console.Write("    Enter client name:  ");
                                        name = Console.ReadLine();
                                        name = NamelettersValidity(name);
                                        Console.Write("    Enter client account number: ");
                                        tempaccnumber = Console.ReadLine();
                                        accountnum = AccountnumValidity(tempaccnumber);

                                        bool flag = FindAccount(name, accountnum, users);
                                        if (flag == true)
                                        {
                                            Credentials update = new Credentials();
                                            // updating a user's deatils
                                            option = UpdateMenu();
                                            if (option == "1")
                                            {
                                                 Console.Write("   Enter new name: ");
                                                update.usernames = Console.ReadLine();
                                                update.usernames = NamelettersValidity(update.usernames);                  // checking if name has only alphabets
                                                update.usernames = Nametakenvalidity(update.usernames, users); // checking if name is already taken
                                                UpdateName(name, accountnum, update, users);
                                            }
                                            else if (option == "2")
                                            {
                                                Console.Write("   Enter new pin: ");
                                                update.passwords = Console.ReadLine();
                                                update.passwords = Pindigitscheck(update.passwords); // checking 4-digits of pin
                                                update.passwords = CheckpinValidity(update.passwords, users);
                                                UpdatePin(name, accountnum, update, users);
                                            }
                                            else if (option == "3")
                                            {
                                                Console.Write("   Enter new account type: ");
                                                update.accounttypes = Console.ReadLine();
                                                update.accounttypes = Checkaccounttype(update.accounttypes);
                                                Updatetype(name, accountnum, update, users);
                                            }
                                            else if (option == "4")
                                            {
                                                 Console.Write("   Enter new balance: ");
                                                tempaccbalance = Console.ReadLine();
                                                update.balances = BalanceValidity(tempaccbalance);
                                                Updatebalance(name, accountnum, update, users);
                                            }
                                            else if (option == "5")
                                            {
                                                 Console.Write("    Enter new status(freeze/running): ");
                                                update.statuses = Console.ReadLine();
                                                Updatestatus(name, accountnum, update, users);
                                            }
                                            else if (option == "6")
                                            {
                                                Console.Write("   Enter new phonenumber: ");
                                                update.phonenumbers = Console.ReadLine();
                                                update.phonenumbers = Phone_numberLength(update.phonenumbers);  // getting 11 digit phone number
                                                update.phonenumbers = PhonenumberValidity(update.phonenumbers); // checking if phonenumber contains only numbers
                                                Updatephonenumber(name, accountnum, update, users);
                                            }
                                            else if (option == "7")
                                            {

                                                Console.Write("   Enter new name: ");
                                                update.usernames = Console.ReadLine();
                                                update.usernames = NamelettersValidity(update.usernames);                  // checking if name has only alphabets
                                                update.usernames = Nametakenvalidity(update.usernames, users); // checking if name is already taken
                                                Console.Write("   Enter new pin: ");
                                                update.passwords = Console.ReadLine();
                                                update.passwords = Pindigitscheck(update.passwords); // checking 4-digits of pin
                                                update.passwords = CheckpinValidity(update.passwords, users);
                                                Console.Write("   Enter new account type: ");
                                                update.accounttypes = Console.ReadLine();
                                                update.accounttypes = Checkaccounttype(update.accounttypes);
                                                Console.Write("   Enter new balance: ");
                                                tempaccbalance = Console.ReadLine();
                                                update.balances = BalanceValidity(tempaccbalance);
                                                Console.Write("    Enter new status(freeze/running): ");
                                                update.statuses = Console.ReadLine();
                                                Console.Write("   Enter new phonenumber: ");
                                                update.phonenumbers = Console.ReadLine();
                                                update.phonenumbers = Phone_numberLength(update.phonenumbers);  // getting 11 digit phone number
                                                update.phonenumbers = PhonenumberValidity(update.phonenumbers); // checking if phonenumber contains only numbers
                                                Updatinguserinfo(update, users, name, accountnum);
                                        }
                                         Updatedatainfile1(users);
                                            Console.WriteLine("   UPdated account details.. ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("  Account doesnot exists!");
                                        }
    
                                        GoBack();
                                    }
                                    else if (adminChoice == "6")
                                    {
                                        Header();
                                        string submenu = "View Clients personal info";
                                        PrintsubMenu(submenu);
                                        ViewAllusers(users);
                                        GoBack();
                                    }
                                    else if (adminChoice == "7")
                                    {
                                        Header();
                                        string submenu = "Give loan";
                                        PrintsubMenu(submenu);
                                        char answer;
                                        ShowLoanRequests(reqLoan);
                                        Console.WriteLine("    Do you want to give loan?(y/n) ");
                                        answer = char.Parse(Console.ReadLine());
                                        if (answer == 'y')
                                        {
                                            //giveLoan();
                                            GoBack();
                                        }
                                        else
                                        {
                                            GoBack();
                                        }
                                    }
                                    else if (adminChoice == "8")
                                    {
                                        Header();
                                        string submenu = "View loan holders";
                                        PrintsubMenu(submenu);
                                        //Viewloanholders(loan_count, loanholders, givenloanamounts, givenloandays, loantime);
                                        GoBack();
                                    }
                                    else if (adminChoice == "9")
                                    {
                                        Header();
                                        string submenu = "View total money";
                                        PrintsubMenu(submenu);
                                        Totalmoney(users);
                                        GoBack();
                                    }
                                    else if (adminChoice == "10")
                                    {
                                        Header();
                                        string submenu = "Apply tax";
                                        PrintsubMenu(submenu);
                                        string option = TaxMenu();
                                        if (option == "1")
                                        {
                                            TaxonSpecific(users);
                                        }
                                        else if (option == "2")
                                        {
                                            TaxonAll(users);
                                        }
                                        GoBack();
                                    }
                                    else if (adminChoice == "11")
                                    {
                                        Header();
                                        string submenu = "Transaction details";
                                        PrintsubMenu(submenu);
                                       // ViewAlltransactions(trans_count, transactionaccounts, transactionamounts, transactiontypes, transactiontimes);
                                        GoBack();
                                    }
                                }
                            }
                            else if (plogin.loginrole == "client")
                            {
                                while (clientChoice != "9")
                                {
                                    Header();
                                    clientChoice = ClientMenu();
                                    if (clientChoice == "1")
                                    {
                                        Header();
                                        string submenu = "View Balance";
                                        PrintsubMenu(submenu);
                                        float current_balance = ClientcurrentBalance(users, loginInfo);
                                        Console.WriteLine("  Your current account balance is: " + current_balance);
                                        GoBack();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Header()
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
        static void PrintsubMenu(string submenu)
        {
            string message = "Main Menu>" + submenu;
            Console.WriteLine("                   " + message);
            Console.WriteLine("  --------------------------------------------------------------------");
            Console.WriteLine();
        }
        static string Firstinterface()
        {
            string option;
            Console.WriteLine("  Welcome!!");
            Console.WriteLine(" ====================================================================");
            Console.WriteLine("   1. Sign In");
            Console.WriteLine("   2. Exit");
            Console.WriteLine("  PLease enter a choice: ");
            option = Console.ReadLine();
            return option;
        }
        static string AdminMenu()
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
        static string ClientMenu()
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
            Console.WriteLine("    6. Veiw your previous loan.");
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

        static void InValidChoice()
        {
            Console.WriteLine("Invalid choice!");
            Console.WriteLine("   Press any key to enter choice again..");
            Console.ReadLine();
        }
        static void GoBack()
        {
            Console.WriteLine("    Press any key to go back...");
            Console.ReadKey();
        }
        static string Pindigitscheck(string password)
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
        static string NamelettersValidity(string name)
        {
            bool alphabets = CheckalphabetsinName(name);
            if (alphabets == false)
            {
                while (alphabets != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("    Invalid name! Name should only contain alphabets!!");
                    Console.Write("    Enter Name again: ");
                    name = Console.ReadLine();
                    alphabets = CheckalphabetsinName(name);
                }
            }
            return name;
        }
        static bool CheckalphabetsinName(string name)
        {
            bool flag = false;
            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static bool CheckUserExistance(string name, string password, List<Credentials> users)
        {
            bool isPresent = false;
            for (int idx = 0; idx < users.Count; idx++) // checking if user exits in record
            {
                Credentials c = new Credentials();
                c.usernames = users[idx].usernames;
                c.passwords = users[idx].passwords;
                if (c.usernames == name && c.passwords == password)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
        static bool CheckaccountPresence(int accountnumber, string pin, int userCount, string[] usernames, string[] passwords, int[] accountnumbers)
        {
            bool isPresent = false;
            for (int idx = 0; idx < userCount; idx++) // finding user account exits from account number and pin
            {
                if (accountnumbers[idx] == accountnumber && passwords[idx] == pin)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        static string CheckRole(string name, string password, List<Credentials> users)
        {
            string person = "client"; // finding role of user
            if (users[0].usernames == name && users[0].passwords == password)
            {
                person = "admin";
            }
            return person;
        }
        static int CheckNewAccountnumber(List<Credentials> users)
        {
            int largest = users[0].accountnumbers;
            for (int index = 1; index < users.Count; index++)
            {
                if (largest < users[index].accountnumbers)
                {
                    largest = users[index].accountnumbers;
                }
            }
            return largest;
        }
        static void LoadDatafromFile1(List<Credentials> users, ref int accountnum)
        {
            string line, path = "D:\\OOP\\people.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        Credentials info = new Credentials();
                        string[] filedata = line.Split(',');
                        info.accountnumbers = int.Parse(filedata[0]);
                        info.usernames = filedata[1];
                        info.passwords = filedata[2];
                        info.roles = filedata[3];
                        info.accounttypes = filedata[4];
                        info.balances = float.Parse(filedata[5]);
                        info.phonenumbers = filedata[6];
                        info.statuses = filedata[7];
                        users.Add(info);
                    }
                }
                myFile.Close();
                accountnum = CheckNewAccountnumber(users) + 1;
            }
        }

        static int Checkloginpersonaccountnumber(List<Credentials> users, string loginusername, string loginpassword)
        {
            int number = 1;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].usernames == loginusername && users[i].passwords == loginpassword)
                {
                    number = users[i].accountnumbers;
                }
            }
            return number;
        }
        static float CheckloginaccountBalance(List<Credentials> users, string loginusername, int loginaccountnumber)
        {
            float balance = 0;
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].usernames == loginusername && users[idx].accountnumbers == loginaccountnumber)
                {
                   balance = users[idx].balances;
                }
            }
            return balance;
        }
        static float ClientcurrentBalance(List<Credentials> users, List<Blogin> loginInfo)
        {
            float present = 0.0F;
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == loginInfo[loginInfo.Count-1].loginusername && users[index].passwords == loginInfo[loginInfo.Count-1].loginpassword)
                {
                    present = users[index].balances; // find current account balance of client
                }
            }
            return present;
        }

        static string Nametakenvalidity(string name, List<Credentials> users)
        {
            bool flag = AlreadyTakenName(name, users);
            if (flag == true)
            {
                Console.WriteLine("    This name is already Taken!");
                while (flag != false)
                {
                    Console.Write("    Enter Name again: ");
                    name = Console.ReadLine();
                    flag = AlreadyTakenName(name, users);
                }
            }
            return name;
        }
        static bool AlreadyTakenName(string name, List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].usernames == name)
                {
                    return true;
                }
            }
            return false;
        }
        static string CheckpinValidity(string pin, List<Credentials> users)
        {
            bool flag = AlreadyTakenPin(pin, users);
            if (flag == true)
            {
                Console.Write("    This pin is already taken.");
                while (flag != false)
                {
                    Console.Write("    Enter pin again: ");
                    pin = Console.ReadLine();
                    flag = AlreadyTakenPin(pin, users);
                }
            }
            return pin;
        }
        static bool AlreadyTakenPin(string pin, List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].passwords == pin)
                {
                    return true;
                }
            }
            return false;
        }
        static string Checkaccounttype(string accounttype)
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
        static string Phone_numberLength(string number)
        {
            int phone = number.Length;
            if (phone != 11)
            {
                while (phone != 11)            // checking if phone number is 11 digits
                {
                    Console.Write("    Enter 10-digit number: ");
                    number = Console.ReadLine();
                    phone = number.Length;
                }
            }
            return number;
        }
        static bool CheckonlyNumbers(string tempnumber)
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
        static string PhonenumberValidity(string tempphone)
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
        static int AccountnumValidity(string accnumber)
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
        static float Minimum_balance(float balance, string type)
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
        static float BalanceValidity(string tempbalance)
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
        static bool FindAccount(string name, int accountnumber, List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].usernames == name && users[idx].accountnumbers == accountnumber)
                {
                    return true;
                }
            }
            return false;
        }
        static string UpdateMenu()
        {
            string option;
            Console.WriteLine("   what do you want to update: ");
            Console.WriteLine("    1. name:");
            Console.WriteLine("    2. pin: ");
            Console.WriteLine("    3. account type: ");
            Console.WriteLine("    4. balance: ");
            Console.WriteLine("    5. account Status: ");
            Console.WriteLine("    6. phone number: ");
            Console.WriteLine("    7. all of above.");
            option = Console.ReadLine();
            return option;
        }
        static void UpdateName(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].usernames = update.usernames;
                    break;
                }
            }
        }
        static void UpdatePin(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].passwords = update.passwords;
                    break;
                }
            }
        }
        static void Updatetype(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].accounttypes = update.accounttypes;
                    break;
                }
            }
        }
        static void Updatebalance(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].balances = update.balances;
                    break;
                }
            }
        }
        static void Updatestatus(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].statuses = update.statuses;
                    break;
                }
            }
        }
        static void Updatephonenumber(string name, int accountnumber, Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].phonenumbers = update.phonenumbers;
                    break;
                }
            }
        }
        static void Updatinguserinfo(Credentials update, List<Credentials> users, string name, int accountnumber)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].accountnumbers == accountnumber)
                {
                    users[index].usernames = update.usernames;
                    users[index].passwords = update.passwords;
                    users[index].balances = update.balances;
                    users[index].accounttypes = update.accounttypes;
                    users[index].statuses = update.statuses;
                    users[index].phonenumbers = update.phonenumbers;
                    break;
                }
            }
        }

        static void StoreinFile1(ref int accountnumber, List<Credentials> users)
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(accountnumber + "," + users[users.Count-1].usernames + "," + users[users.Count-1].passwords + "," + "client" + "," + users[users.Count-1].accounttypes + "," + users[users.Count-1].balances+ "," + users[users.Count-1].phonenumbers + "," + "running");
            myFile.Flush();
            myFile.Close();
        }
        static void Account_close(int accountnumber, string name, string pin,List<Credentials> users)
        {
            for (int index = 1; index < users.Count; index++)
            {
                if (users[index].usernames == name && users[index].passwords == pin && users[index].accountnumbers == accountnumber)
                {
                    users.RemoveAt(index);              // finding index where data of user is stored in array
                }
            }
        }
        static bool Freeze_account(int accountnumber, string pin, List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].accountnumbers == accountnumber && users[idx].passwords == pin)
                {
                    users[idx].statuses = "freeze";
                    Updatedatainfile1(users);
                    return true;
                }
            }
            return false;
        }
        static bool Search_account(string name, int accountnumber, List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].usernames == name &&  users[idx].accountnumbers == accountnumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("    Following are details of " + name + ": ");
                    Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
                    Console.WriteLine("     " + users[idx].accountnumbers + "\t\t" + users[idx].usernames + "\t" + users[idx].passwords + "\t" + users[idx].accounttypes + "\t\t" + users[idx].balances + "\t" + users[idx].phonenumbers + "\t" + users[idx].statuses);
                    return true;
                }
            }
            return false;
        }
        static void Updatedatainfile1(List<Credentials> users)
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path);

            myFile.WriteLine(users[0].accountnumbers + "," + users[0].usernames + "," + users[0].passwords + "," + users[0].roles + "," + users[0].accounttypes + "," + users[0].balances + "," + users[0].phonenumbers + "," + users[0].statuses);
            for (int idx = 1; idx < users.Count; idx++)
            {
                myFile.WriteLine(users[idx].accountnumbers + "," + users[idx].usernames + "," + users[idx].passwords + "," + users[idx].roles + "," + users[idx].accounttypes + "," + users[idx].balances + "," + users[idx].phonenumbers + "," + users[idx].statuses);
            }
            myFile.Close();
        }

        static void ViewAllusers(List<Credentials> users)
        {
            Console.WriteLine("    Following  are details of ALL clients: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
            for (int idx = 1; idx < users.Count; idx++)
            {
                {
                    Console.WriteLine("     " + users[idx].accountnumbers + "\t\t" + users[idx].usernames + "\t" + users[idx].passwords + "\t" + users[idx].accounttypes + "\t\t" + users[idx].balances + "\t" + users[idx].phonenumbers + "\t" + users[idx].statuses);
                }
            }
            Console.WriteLine();
        }
        static void Totalmoney(List<Credentials> users)
        {
            float total = 0;
            for (int index = 1; index < users.Count; index++)
            {
                total = total + users[index].balances; // adding money present in bank
            }
            Console.WriteLine("  TOtal money present in bank is : " + total);
        }
        /*static void Viewloanholders(int loan_count, string[] loanholders, float[] givenloanamounts, int[] givenloandays, string[] loantime)
        {
            Console.WriteLine("    Following are loan holders details..");
            Console.WriteLine();
            Console.WriteLine("    Names" + "\t" + "amount" + "\t" + "totaltime(days)" + "\t" + "granting time");
            // all people who have taken loan
            for (int index = 0; index < loan_count; index++)
            {
                Console.WriteLine("    " + loanholders[index] + "\t" + givenloanamounts[index] + "\t" + givenloandays[index] + "\t" + loantime[index]);
            }
        }*/
        static string TaxMenu()
        {
            string option;

            Console.WriteLine("  Do you want to implement tax on : ");
            Console.WriteLine("   1. specific user.");
            Console.WriteLine("   2. All users.");
            option = Console.ReadLine();
            return option;
        }
        static void TaxonSpecific(List<Credentials> users)
        {
            string name, tempaccountnum, tpercent;
            int accountnumber, percentofTax;
            Console.Write("    Enter name of user on which you want to implement tax: ");
            name = Console.ReadLine();
            name = NamelettersValidity(name); // checking if name contains only alphabet
            Console.Write("    Enter account number: ");
            tempaccountnum = Console.ReadLine(); ;
            accountnumber = AccountnumValidity(tempaccountnum);

            bool check = Search_account(name, accountnumber, users);
            if (check == true)
            {
                Console.Write("   Enter percentage of tax to implement: ");
                tpercent = Console.ReadLine();
                percentofTax = CheckPercentage(tpercent);
                for (int indx = 1; indx < users.Count; indx++)
                {
                    // implementing tax on specific account
                    if (users[indx].usernames == name && users[indx].accountnumbers == accountnumber)
                    {
                        users[indx].balances = users[indx].balances - (users[indx].balances * percentofTax / 100);
                        break;
                    }
                }
                Updatedatainfile1(users);
                Console.WriteLine("   TAx hasbeen deducted!");
            }
            else
            {
                Console.WriteLine("   Invalid account number!");
            }
        }
        static void TaxonAll(List<Credentials> users)
        {
            string tempnumber;
            int percentoftax;
            Header();
            string submenu = "tax on all clients";
            PrintsubMenu(submenu);
            Console.Write("    Enter percentage of tax to implement: ");
            tempnumber = Console.ReadLine();
            percentoftax = int.Parse(PhonenumberValidity(tempnumber));


            for (int indx = 1; indx < users.Count; indx++)
            {
                // implementing tax on all accounts
                users[indx].balances = users[indx].balances - (users[indx].balances * percentoftax / 100);
            }
            Updatedatainfile1(users);
            Console.WriteLine("    TAx hasbeen deducted!");
        }
        static void ShowLoanRequests(List<Reqloan> reqLoan)
        {
            Console.WriteLine("    Folloing are the people who requested for loan: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t" + " Amount");
            for (int index = 0; index < reqLoan.Count; index++)
            {
                Console.WriteLine("     " + reqLoan[index].requestloanaccounts + "\t\t" + reqLoan[index].requestloanpoeple + "\t" + reqLoan[index].requestloanamounts);
            }
        }
    }
}