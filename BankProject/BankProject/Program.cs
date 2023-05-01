using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int userCount = 0;
            int accountnum = 0;
            string loginusername = "", loginpassword = "", loginrole = "";
            int loginaccountnumber;
            float loginaccountbalance;

            string[] usernames = new string[100];
            string[] passwords = new string[100];
            string[] roles = new string[100];
            string[] accounttypes = new string[100];
            float[] balances = new float[100];
            string[] phonenumbers = new string[100];
            string[] statuses = new string[100];
            int[] accountnumbers = new int[100];

            float[] transactionamounts = new float[100];
            string[] transactionaccounts = new string[100];
            string[] transactiontypes = new string[100];
            string[] transactiontimes = new string[100];
            string[] requestloanpoeple = new string[100];
            float[] requestloanamounts = new float[100];
            int[] requestloanaccounts = new int[100];
            int[] loanholderaccounts = new int[100];
            string[] loanholders = new string[100];
            float[] givenloanamounts = new float[100];
            int[] givenloandays = new int[100];
            string[] loantime = new string[100];
            int trans_count = 0;
            int loan_req = 0;
            int loan_count = 0;

            string choice = "", adminChoice = "", clientChoice = "";
            bool validuser;

            LoadDatafromFile1(ref userCount, ref accountnum, ref accountnumbers, ref balances, ref usernames, ref passwords, ref roles, ref accounttypes, ref phonenumbers, ref statuses);
            {
                while (choice != "2")
                {
                    Header();
                    choice = Firstinterface();
                    if (choice == "1")
                    {
                        Header();
                        SigninMenu(ref loginusername, ref loginpassword);
                        validuser = CheckUserExistance(loginusername, loginpassword, userCount, usernames, passwords);
                        if (validuser == true)
                        {
                            loginrole = CheckRole(loginusername, loginpassword, usernames, passwords);
                            if (loginrole == "admin")
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
                                        CreateAccount(ref userCount, usernames, ref accountnum, passwords, accountnumbers, balances, roles, accounttypes, phonenumbers, statuses);
                                        GoBack();
                                    }
                                    else if(adminChoice == "2")
                                    {
                                        Header();
                                        Console.WriteLine();
                                        string submenu = "Delete Client Account";
                                        PrintsubMenu(submenu);
                                        DeleteAccount(ref userCount, ref usernames, ref passwords, ref accountnumbers, ref  balances, ref  roles, ref accounttypes, ref phonenumbers, ref statuses);
                                        GoBack();
                                    }
                                    else if (adminChoice == "3")
                                    {
                                        Header();
                                        string submenu = "Freeze Client Account";
                                        PrintsubMenu(submenu);
                                        FreezingAccount(ref  usernames, ref  statuses, passwords,  accountnumbers, userCount, ref balances, ref roles, ref accounttypes, ref phonenumbers);
                                        GoBack();
                                    }
                                    else if (adminChoice == "4")
                                    {
                                        Header();
                                        string submenu = "Search Client Account";
                                        PrintsubMenu(submenu);
                                        SearchUserDetails(userCount,accountnumbers,usernames, passwords, accounttypes,balances, phonenumbers,statuses);
                                        GoBack();
                                    }
                                    else if (adminChoice == "5")
                                    {
                                        Header();
                                        string submenu = "Updating Client's Record";
                                        PrintsubMenu(submenu);
                                        UpdateInfo(userCount, usernames, accounttypes, passwords, accountnumbers, balances, roles, phonenumbers, statuses);
                                        GoBack();
                                    }
                                    else if (adminChoice == "6")
                                    {
                                        Header();
                                        string submenu = "View Clients personal info";
                                        PrintsubMenu(submenu);
                                        ViewAllusers(userCount, accountnumbers,  usernames, passwords, accounttypes, balances, phonenumbers,statuses);
                                        GoBack();
                                    }
                                    else if (adminChoice == "7")
                                    {
                                        Header();
                                        string submenu = "Give loan";
                                        PrintsubMenu(submenu);
                                        char answer;
                                        ShowLoanRequests(loan_req, requestloanaccounts, requestloanpoeple, requestloanamounts);
                                        Console.WriteLine( "    Do you want to give loan?(y/n) ");
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
                                        Viewloanholders(loan_count, loanholders,givenloanamounts, givenloandays, loantime);
                                        GoBack();
                                    }
                                    else if (adminChoice == "9")
                                    {
                                        Header();
                                        string submenu = "View total money";
                                        PrintsubMenu(submenu);
                                        Totalmoney(userCount, balances);
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
                                            TaxonSpecific(userCount, usernames, passwords,accountnumbers, balances, roles, accounttypes,phonenumbers, statuses);
                                        }
                                        else if (option == "2")
                                        {
                                            TaxonAll(userCount, usernames, passwords, accountnumbers, balances, roles, accounttypes, phonenumbers, statuses);
                                        }
                                        GoBack();
                                    }
                                    else if (adminChoice == "11")
                                    {
                                        Header();
                                        string submenu = "Transaction details";
                                        PrintsubMenu(submenu);
                                        ViewAlltransactions(trans_count, transactionaccounts, transactionamounts, transactiontypes, transactiontimes);
                                        GoBack();
                                    }
                                }
                            }
                            else if(loginrole == "client")
                            {
                                loginaccountnumber = Checkloginpersonaccountnumber(userCount, usernames, passwords, accountnumbers, loginusername, loginpassword);
                                loginaccountbalance = CheckloginaccountBalance(userCount,usernames,accountnumbers,balances,loginusername,loginaccountnumber);
                                while(clientChoice != "9")
                                {
                                    Header();
                                    clientChoice = ClientMenu();
                                    if(clientChoice == "1")
                                    {
                                        Header();
                                        string submenu = "View Balance";
                                        PrintsubMenu(submenu);
                                        float current_balance = ClientcurrentBalance(userCount,usernames,passwords,balances,loginusername,loginpassword);
                                        Console.WriteLine("  Your current account balance is: " + current_balance );
                                        GoBack();
                                    }
                                    else if(clientChoice == "2")
                                    {
                                        Header();
                                        string submenu = "Deposit Moeny";
                                        PrintsubMenu(submenu);
                                        bool flag = Checkstatus(loginusername, loginaccountnumber, userCount,usernames, accountnumbers, statuses);
                                        if (flag == true)
                                        {
                                            //DepositMoney();
                                            Console.WriteLine("   Money has been deposited");
                                        }
                                        else if (flag == false)
                                        {
                                            Console.WriteLine("   You cannot deposit money, your account is blocked" );
                                        }
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
            Console.WriteLine("      <><><>----<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>---<>----<>---<><><>");
            Console.WriteLine("       <><><>---<>---<>---<>---<>---<>---<>---<< BANK MANAGEMENT SYSTEM >>---<>---<>---<>---<>---<>---<>---<><><>");       
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine();
        }
        static void PrintsubMenu(string submenu)
        {
            string message = "Main Menu>" + submenu;
            Console.WriteLine( "                   " + message );
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
            Console.WriteLine( "    Press any key to go back...");
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

        static void SigninMenu(ref string loginusername, ref string loginpassword)
        {
            Header();
            Console.WriteLine("                              Login Menu                               ");
            Console.WriteLine("    ===================================================================");
            Console.Write("    Enter your name:  ");
            loginusername = Console.ReadLine();
            loginusername = NamelettersValidity(loginusername);
            Console.Write("    Enter your 4-digit security pin: ");
            loginpassword = Console.ReadLine();
            loginpassword = Pindigitscheck(loginpassword);
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
                    name =  Console.ReadLine();
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

        static bool CheckUserExistance(string name, string password, int userCount, string[] usernames, string[] passwords)
        {
            bool isPresent = false;
            for (int idx = 0; idx < userCount; idx++) // checking if user exits in record
            {
                if (usernames[idx] == name && passwords[idx] == password)
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

        static string CheckRole(string name, string password, string[] usernames, string[] passwords)
        {
            string person = "client"; // finding role of user
            if (usernames[0] == name && passwords[0] == password)
            {
                   person = "admin";
            }
            return person;
        }

        static int CheckNewAccountnumber(int[] accountnumbers, int userCount)
        {
           int largest = accountnumbers[0];
            for (int index = 1; index < userCount; index++)
            {
                if (largest < accountnumbers[index])
                {
                    largest = accountnumbers[index];
                }
            }
            return largest;
        }

        static void LoadDatafromFile1(ref int userCount, ref int accountnum, ref int[] accountnumbers, ref float[] balances, ref string[] usernames, ref string[] passwords, ref string[] roles, ref string[] accounttypes, ref string[] phonenumbers, ref string[] statuses)
        {
            string line, path = "D:\\OOP\\people.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');
                        accountnumbers[userCount] = int.Parse(filedata[0]);
                        usernames[userCount] = filedata[1];
                        passwords[userCount] = filedata[2];
                        roles[userCount] = filedata[3];
                        accounttypes[userCount] = filedata[4];
                        balances[userCount] = float.Parse(filedata[5]);
                        phonenumbers[userCount] = filedata[6];
                        statuses[userCount] = filedata[7];
                        userCount++;
                    }
                }
                myFile.Close();
                accountnum = CheckNewAccountnumber(accountnumbers, userCount) + 1;
            }
        }
        
        static int Checkloginpersonaccountnumber(int userCount,string[] usernames,string[] passwords,int[] accountnumbers,string loginusername,string loginpassword)
        {
            int number = 1;
            for (int i = 0; i < userCount; i++)
            {
                if (usernames[i] == loginusername && passwords[i] == loginpassword)
                {
                    number = accountnumbers[i];
                }
            }
            return number;
        }
        
        static float CheckloginaccountBalance(int userCount,string[] usernames,int[] accountnumbers,float[] balances,string loginusername,int loginaccountnumber)
        {
            float balance = 0;
            for (int idx = 0; idx < userCount; idx++)
            {
                if (usernames[idx] == loginusername && accountnumbers[idx] == loginaccountnumber)
                {
                    balance = balances[idx];
                }
            }
            return balance;
        }

        static float ClientcurrentBalance(int userCount, string[] usernames, string[] passwords, float[] balances, string loginusername, string loginpassword)
        {
            float present = 0.0F;
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == loginusername && passwords[index] == loginpassword)
                {
                    present = balances[index]; // find current account balance of client
                }
            }
            return present;
        }

        static bool Checkstatus(string name, int accountnumber, int userCount, string[] usernames, int[] accountnumbers, string[]statuses)
        {
            bool statusFlag = true;
            for (int i = 0; i < userCount; i++)
            {
                if (usernames[i] == name && accountnumbers[i] == accountnumber)
                {
                    if (statuses[i] == "running")
                    {
                        statusFlag = true;
                    }
                    else if (statuses[i] == "freeze")
                    {
                        statusFlag = false;
                    }
                }
            }
            return statusFlag;
        }

        static string Nametakenvalidity(string name, int userCount, string[] usernames)
        {
            bool flag = AlreadyTakenName(name,userCount,usernames);
            if (flag == true)
            {
                Console.WriteLine("    This name is already Taken!" );
                while (flag != false)
                {
                    Console.Write("    Enter Name again: ");
                    name= Console.ReadLine();
                    flag = AlreadyTakenName(name, userCount, usernames);
                }
            }
            return name;
        }
        static bool AlreadyTakenName(string name, int userCount, string[] usernames)
        {
            for (int idx = 0; idx < userCount; idx++)
            {
                if (usernames[idx] == name)
                {
                    return true;
                }
            }
            return false;
        }
        static string CheckpinValidity(string pin, int userCount, string[] passwords)
        {
            bool flag = AlreadyTakenPin(pin, userCount,passwords);
            if (flag == true)
            {
                Console.Write("    This pin is already taken.");
                while (flag != false)
                {
                    Console.Write( "    Enter pin again: ");
                    pin = Console.ReadLine();
                    flag = AlreadyTakenPin(pin, userCount, passwords);
                }
            }
            return pin;
        }
        static bool AlreadyTakenPin(string pin, int userCount, string[] passwords)
        {
            for (int idx = 0; idx < userCount; idx++)
            {
                if (passwords[idx] == pin)
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
                    Console.Write( "    Enter 10-digit number: ");
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
            while( (float.TryParse(tempbalance, out balance)) != true)
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
        static bool FindAccount(string name, int accountnumber, int userCount, int[] accountnumbers, string[] usernames)
        {
            for (int idx = 0; idx < userCount; idx++)
            {
                if (usernames[idx] == name && accountnumbers[idx] == accountnumber)
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
            Console.WriteLine("    2. pin: " );
            Console.WriteLine("    3. account type: ");
            Console.WriteLine("    4. balance: ");
            Console.WriteLine("    5. account Status: " );
            Console.WriteLine("    6. phone number: " );
            Console.WriteLine("    7. all of above." );
            option = Console.ReadLine();
            return option;
        }
        static void UpdateName(string name, int accountnumber, string newname, int userCount, string[] usernames, int[] accountnumbers)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    usernames[index] = newname;
                    break;
                }
            }
        }
        static void UpdatePin(string name, int accountnumber, string newpin, int userCount, string[] usernames, int[] accountnumbers, string[] passwords)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    passwords[index] = newpin;
                    break;
                }
            }
        }
        static void Updatetype(string name, int accountnumber, string newtype, int userCount, string[] usernames, int[] accountnumbers, string[] accounttypes)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    accounttypes[index] = newtype;
                    break;
                }
            }
        }
        static void Updatebalance(string name, int accountnumber, float newbalance, int userCount, string[] usernames, int[] accountnumbers, float[] balances)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    balances[index] = newbalance;
                    break;
                }
            }
        }
        static void Updatestatus(string name, int accountnumber, string newstatus, int userCount, string[] usernames, int[] accountnumbers, string[] statuses)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    statuses[index] = newstatus;
                    break;
                }
            }
        }
        static void Updatephonenumber(string name, int accountnumber, string newnumber, int userCount, string[] usernames, int[] accountnumbers, string[] phonenumbers)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    phonenumbers[index] = newnumber;
                    break;
                }
            }
        }
        static void Updatinguserinfo(string name, int accountnumber, string newname, string newpin, float newbalance, string newtype, string newstatus, string newnumber,int userCount, string[] usernames, int[] accountnumbers, string[] passwords, float[] balances, string[] accounttypes, string[] phonenumbers, string[] statuses)
        {
            for (int index = 0; index < userCount; index++)
            {
                if (usernames[index] == name && accountnumbers[index] == accountnumber)
                {
                    usernames[index] = newname;
                    passwords[index] = newpin;
                    balances[index] = newbalance;
                    accounttypes[index] = newtype;
                    statuses[index] = newstatus;
                    phonenumbers[index] = newnumber;
                    break;
                }
            }
        }


        static void StoreDatainArray(int accountnum, string name, string pin, string acctype, float balance, string phone, string[] usernames, string[] passwords, int[] accountnumbers, float[] balances, int userCount, string[] roles, string[] accounttypes, string[] phonenumbers, string[] statuses)
        {
            usernames[userCount] = name;
            passwords[userCount] = pin;
            accounttypes[userCount] = acctype;
            balances[userCount] = balance;
            phonenumbers[userCount] = phone;
            statuses[userCount] = "running";
            roles[userCount] = "client";
            accountnumbers[userCount] = accountnum;
        }
        static void StoreinFile1(int accountnum, string name, string pin, string acctype, float balance, string phone)
        {
            string path =  "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            
            myFile.WriteLine(accountnum + "," + name + "," + pin + ","+ "client"+ "," + acctype + "," + balance + "," + phone +","+ "running");
            myFile.Flush();
            myFile.Close();
        }
        static void Account_close(int accountnumber, string name, string pin, ref int userCount, ref string[] usernames, ref string[] passwords, ref int[] accountnumbers, ref float[] balances, ref string[] roles, ref string[] accounttypes, ref string[] phonenumbers, ref string[] statuses)
        {
            for (int index = 1; index < userCount; index++)
            {
                // finding index where data of user is stored in array
                if (usernames[index] == name && passwords[index] == pin && accountnumbers[index] == accountnumber)
                {
                    userCount = userCount - 1;
                    for (int idx = index; idx <= userCount; idx++)
                    {
                        // deleting a user' record
                        usernames[idx] = usernames[idx + 1];
                        passwords[idx] = passwords[idx + 1];
                        accounttypes[idx] = accounttypes[idx + 1];
                        roles[idx] = roles[idx + 1];
                        balances[idx] = balances[idx + 1];
                        statuses[idx] = statuses[idx + 1];
                        phonenumbers[idx] = phonenumbers[idx + 1];
                        accountnumbers[idx] = accountnumbers[idx + 1];
                    }
                }
            }
        }
        static bool Freeze_account(int accountnumber,string pin, ref string[] usernames, ref string[] statuses, string[] passwords, int[] accountnumbers, int userCount, ref float[] balances, ref string[] roles, ref string[] accounttypes, ref string[] phonenumbers)
        {
            for (int idx = 0; idx < userCount; idx++)
            {
                if (accountnumbers[idx] == accountnumber && passwords[idx] == pin)
                {
                    statuses[idx] = "freeze";
                    Updatedatainfile1(userCount, usernames, passwords, accountnumbers, balances, roles, accounttypes, phonenumbers, statuses);
                    return true;
                }
            }
            return false;
        }
        static bool Search_account(string name, int accountnumber, int userCount, int[] accountnumbers,string[] usernames, string[] passwords, string[] accounttypes, float[] balances, string[] phonenumbers, string[] statuses)
        {
            for (int idx = 0; idx < userCount; idx++)
            {
                if (usernames[idx] == name && accountnumbers[idx] == accountnumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("    Following are details of "+ name +": ");
                    Console.WriteLine("    Accountno" + "\t"+"Name"+"\t\t"+"Pin"+"\t"+"AccountType"+ "\t"+ "Balance"+ "\t"+ "Phonenumber"+ "\t"+ "Status"+ "\t" );
                     Console.WriteLine( "     " + accountnumbers[idx] + "\t\t" + usernames[idx] + "\t" + passwords[idx] + "\t" + accounttypes[idx] + "\t\t" + balances[idx] +"\t" + phonenumbers[idx] +"\t"+ statuses[idx] );
                    return true;
                }
            }
            return false;
        }
        static void Updatedatainfile1(int userCount, string[] usernames,string[] passwords, int[] accountnumbers, float[] balances, string[] roles, string[] accounttypes, string[] phonenumbers, string[] statuses)
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path);

            myFile.WriteLine(accountnumbers[0] + "," + usernames[0] + "," + passwords[0] + "," + roles[0] + "," + accounttypes[0] + "," + balances[0] + "," + phonenumbers[0] + "," + statuses[0]);
            for (int idx = 1; idx < userCount; idx++)
            {
                myFile.WriteLine(accountnumbers[idx] + "," + usernames[idx] + "," + passwords[idx] + "," + roles[idx] + "," + accounttypes[idx] + "," + balances[idx] + "," + phonenumbers[idx] + "," + statuses[idx]);
            }
                myFile.Close();
        }
        
        
        static void CreateAccount(ref int userCount, string[] usernames,ref int accountnum, string[] passwords ,int[] accountnumbers,float[] balances, string[] roles, string[] accounttypes, string[] phonenumbers,string[] statuses)
        {
            string name, pin, accounttype, phone, tempphone, tempbalance;
            float balance = 0;
            Console.Write("    Enter name of client: ");
            name  = Console.ReadLine();
            name = NamelettersValidity(name);                         // checking if name has only alphabets
            name = Nametakenvalidity(name, userCount, usernames);    // checking if name is already taken

            Console.Write("    Enter 4-digit pin for account: ");
            pin = Console.ReadLine();
            pin = Pindigitscheck(pin);                                        // checing 4digits of password
            pin = CheckpinValidity(pin, userCount, passwords);               // checking if passwords is alreadytaken

            Console.Write("    Enter type of account (salary/current) : ");
            accounttype = Console.ReadLine(); ;
            accounttype = Checkaccounttype(accounttype);                // checking if account type is only salary or current

            Console.Write("    Enter starting balance of account: ");
            tempbalance = Console.ReadLine();
            balance = BalanceValidity(tempbalance);                    // chceking if balance enetered contains only numbers
            balance = Minimum_balance(balance, accounttype);

            Console.Write("    Enter phonenumber(without dashes): ");
            tempphone = Console.ReadLine();
            phone = Phone_numberLength(tempphone);                  // getting 11 digit phone number
            phone = PhonenumberValidity(tempphone);                // checking if phonenumber contains only numbers

            StoreDatainArray(accountnum, name, pin, accounttype, balance, phone, usernames, passwords, accountnumbers,  balances, userCount, roles,  accounttypes,  phonenumbers,  statuses); // storing data in array and creating a client's account
            StoreinFile1(accountnum, name, pin, accounttype, balance, phone);     // storing data in people file
            userCount++;

            Console.WriteLine();
            Console.WriteLine(phone);
            Console.WriteLine("    Account number " + accountnum + " successfully created! ");
            accountnum++;
        }
        static void DeleteAccount(ref int userCount, ref string[] usernames, ref string[] passwords, ref int[] accountnumbers, ref float[] balances, ref string[] roles, ref string[] accounttypes, ref string[] phonenumbers, ref string[] statuses)
        {
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
            bool check = CheckUserExistance(name, pin, userCount, usernames, passwords);
            if (check == true)
            {
                Account_close(accountnumber, name, pin, ref userCount, ref usernames, ref  passwords, ref accountnumbers, ref  balances, ref roles, ref accounttypes, ref  phonenumbers, ref  statuses);
                Updatedatainfile1(userCount,usernames,passwords,accountnumbers,balances,roles,accounttypes, phonenumbers,statuses);
                Console.WriteLine();
                Console.WriteLine("   Account succesfully closed! ");
            }
            else
            {
                Console.WriteLine("   User does not exists! ");
            }
        }
        static void FreezingAccount(ref string[] usernames, ref string[] statuses, string[] passwords, int[] accountnumbers, int userCount, ref float[] balances, ref string[] roles, ref string[] accounttypes, ref string[] phonenumbers)
        {
            string tempaccnumber,pin;
            int accountnumber;

            Console.Write("    Enter account number you want to freeze: ");
            tempaccnumber = Console.ReadLine(); // checkng if account number contains only numbers
            accountnumber = AccountnumValidity(tempaccnumber);
            Console.Write("    Enter account pin: ");
            pin  = Console.ReadLine();
            pin = Pindigitscheck(pin); // check 4-digits of passwords

            bool flag = Freeze_account(accountnumber, pin, ref usernames, ref statuses, passwords, accountnumbers, userCount, ref balances, ref  roles, ref accounttypes, ref phonenumbers);
            if (flag == true)
            {
                Console.Write("    Account is blocked now!");
            }
            else if (flag == false)
            {
                Console.Write("    Account does not exists..");
            }
        }
        static void SearchUserDetails(int userCount, int[] accountnumbers, string[] usernames, string[] passwords, string[] accounttypes, float[] balances, string[] phonenumbers, string[] statuses)
        {
            string name, tempaccnumber;
            int accountnumber;

            Console.Write("    Enter name:  ");
            name = Console.ReadLine();
            name = NamelettersValidity(name);           // checking if name has only alphabets
            Console.Write("    Enter account number: ");
            tempaccnumber = Console.ReadLine();         // checkng if account number contains only numbers
            accountnumber = AccountnumValidity(tempaccnumber);

            // searching a user's details
            bool flag = Search_account(name, accountnumber, userCount, accountnumbers, usernames, passwords, accounttypes, balances, phonenumbers, statuses);
            if (flag == false)
            {
                Console.Write("    Account  not  found!");
            }
        }
        static void ViewAllusers(int userCount, int[] accountnumbers, string[] usernames, string[] passwords, string[] accounttypes, float[] balances, string[] phonenumbers, string[] statuses)
        {
            Console.WriteLine("    Following  are details of ALL clients: " );
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
            for (int idx = 1; idx < userCount; idx++)
            {
                {
                    Console.WriteLine("     " + accountnumbers[idx] + "\t\t" + usernames[idx] + "\t" + passwords[idx] + "\t" + accounttypes[idx] + "\t\t" + balances[idx] + "\t" + phonenumbers[idx] + "\t" + statuses[idx]);
                }
            }
            Console.WriteLine();
        }
        static void Totalmoney(int userCount, float[] balances)
        {
            float total = 0;
            for (int index = 1; index < userCount; index++)
            {
                total = total + balances[index]; // adding money present in bank
            }
            Console.WriteLine("  TOtal money present in bank is : " + total);
        }
        static void Viewloanholders(int loan_count, string[] loanholders, float[] givenloanamounts, int[] givenloandays, string[] loantime)
        {
            Console.WriteLine( "    Following are loan holders details.." );
            Console.WriteLine();
            Console.WriteLine("    Names"+ "\t"+ "amount"+ "\t" + "totaltime(days)"+  "\t"+ "granting time" );
            // all people who have taken loan
            for (int index = 0; index < loan_count; index++)
            {
                Console.WriteLine("    " + loanholders[index] + "\t" + givenloanamounts[index] + "\t" + givenloandays[index] + "\t" + loantime[index] );
            }
        }
        static void ViewAlltransactions(int trans_count, string[] transactionaccounts, float[] transactionamounts, string[] transactiontypes , string[] transactiontimes)
        {
            Console.WriteLine("    Following are transaction  details..");
            Console.WriteLine(" " + "Account"+ "\t"+ "Amount"+"\t"+ "type"+"\t\t"+"time" );
            for (int indx = 0; indx < trans_count; indx++)
            {
                Console.WriteLine("  "+ transactionaccounts[indx] + "\t"+ transactionamounts[indx] + "\t" + transactiontypes[indx] + "\t" + transactiontimes[indx] );
            }
        }
        static string TaxMenu()
        {
            string option;

            Console.WriteLine("  Do you want to implement tax on : " );
            Console.WriteLine( "   1. specific user.");
            Console.WriteLine( "   2. All users.");
            option = Console.ReadLine();
            return option;
        }
        static void TaxonSpecific(int userCount, string[] usernames, string[] passwords, int[] accountnumbers, float[] balances, string[] roles, string[] accounttypes, string[] phonenumbers, string[] statuses)
        {
            string name, tempaccountnum, tpercent;
            int accountnumber, percentofTax;
            Console.Write("    Enter name of user on which you want to implement tax: ");
            name = Console.ReadLine();
            name = NamelettersValidity(name); // checking if name contains only alphabet
            Console.Write("    Enter account number: ");
            tempaccountnum = Console.ReadLine(); ;
            accountnumber = AccountnumValidity(tempaccountnum);
            bool check = Search_account(name, accountnumber, userCount, accountnumbers, usernames, passwords, accounttypes, balances, phonenumbers, statuses);
            if (check == true)
            {
                Console.Write("   Enter percentage of tax to implement: ");
                tpercent = Console.ReadLine();
                percentofTax = CheckPercentage(tpercent);
                for (int indx = 0; indx < userCount; indx++)
                {
                    // implementing tax on specific account
                    if (usernames[indx] == name && accountnumbers[indx] == accountnumber)
                    {
                        balances[indx] = (balances[indx]) - ((balances[indx] * percentofTax) / 100);
                        break;
                    }
                }
                Updatedatainfile1(userCount,usernames, passwords, accountnumbers,  balances,  roles, accounttypes,  phonenumbers,  statuses);
                Console.WriteLine( "   TAx hasbeen deducted!");
            }
            else
            {
                Console.WriteLine("   Invalid account number!");
            }
        }
        static void TaxonAll(int userCount, string[] usernames, string[] passwords, int[] accountnumbers, float[] balances, string[] roles, string[] accounttypes, string[] phonenumbers, string[] statuses)
        {
                string tempnumber;
                int percentoftax;
                Header();
                string submenu = "tax on all clients";
                PrintsubMenu(submenu);
                Console.Write("    Enter percentage of tax to implement: ");
                tempnumber = Console.ReadLine();
                percentoftax = int.Parse(PhonenumberValidity(tempnumber));
                for (int indx = 1; indx < userCount; indx++)
                {
                    // implementing tax on all accounts
                    balances[indx] = balances[indx] - (balances[indx] * percentoftax / 100);
                }
                Updatedatainfile1(userCount, usernames, passwords, accountnumbers, balances, roles, accounttypes, phonenumbers, statuses);
                Console.WriteLine( "    TAx hasbeen deducted!");
        }
        static void ShowLoanRequests(int loan_req, int[] requestloanaccounts, string[] requestloanpoeple, float[] requestloanamounts)
        {
            Console.WriteLine( "    Folloing are the people who requested for loan: " );
            Console.WriteLine( "    Accountno"+ "\t"+ "Name"+ "\t" + " Amount" );
            for (int index = 0; index < loan_req; index++)
            {
                Console.WriteLine("     " + requestloanaccounts[index] + "\t\t" + requestloanpoeple[index] + "\t" + requestloanamounts[index] );
            }
        }
        static void UpdateInfo(int userCount, string[] usernames, string[] accounttypes, string[] passwords, int[] accountnumbers, float[] balances, string[] roles, string[] phonenumbers, string[] statuses)
        {
            int accountnum;
            string option, name, newname, newpin, newtype, newstatus, newnumber;
            float newbalance;
            string tempaccnumber, tempaccbalance;

            Console.Write( "    Enter client name:  ");
            name = Console.ReadLine();
            name = NamelettersValidity(name);
            Console.Write("    Enter client account number: ");
            tempaccnumber  = Console.ReadLine();
            accountnum = AccountnumValidity(tempaccnumber);

            bool flag = FindAccount(name, accountnum,  userCount, accountnumbers,usernames);
            if (flag == true)
            {
                // updating a user's deatils
                option = UpdateMenu();
                if (option == "1")
                {
                    Console.Write("   Enter new name: ");
                    newname = Console.ReadLine();
                    newname = NamelettersValidity(newname); // checking if name has only alphabets
                    newname = Nametakenvalidity(newname, userCount, usernames);    // checking if name is already taken
                    UpdateName(name, accountnum, newname, userCount, usernames, accountnumbers);
                }
                else if (option == "2")
                {
                    Console.Write("   Enter new pin: ");
                    newpin = Console.ReadLine();
                    newpin = Pindigitscheck(newpin);
                    newpin = CheckpinValidity(newpin,userCount, passwords);
                    UpdatePin(name, accountnum, newpin, userCount,usernames,accountnumbers,passwords);
                }
                else if (option == "3")
                {
                    Console.Write("   Enter new account type: ");
                    newtype = Console.ReadLine();
                    newtype = Checkaccounttype(newtype);
                    Updatetype(name, accountnum, newtype, userCount, usernames, accountnumbers, accounttypes);
                }
                else if (option == "4")
                {
                    Console.Write("   Enter new balance: ");
                    tempaccbalance = Console.ReadLine();
                    newbalance = BalanceValidity(tempaccbalance);
                    Updatebalance(name, accountnum, newbalance, userCount, usernames, accountnumbers,balances);
                }
                else if (option == "5")
                {
                    Console.Write("    Enter new status(freeze/running): ");
                    newstatus = Console.ReadLine();
                    Updatestatus(name, accountnum, newstatus, userCount, usernames, accountnumbers, statuses);
                }
                else if (option == "6")
                {
                    Console.Write("   Enter new phonenumber: ");
                    newnumber = Console.ReadLine();
                    newnumber = PhonenumberValidity(newnumber);
                    newnumber = Phone_numberLength(newnumber);
                    Updatephonenumber(name, accountnum, newnumber, userCount, usernames, accountnumbers, phonenumbers);
                }
                else if (option == "7")
                {
                    Console.Write("   Enter new name: ");
                    newname = Console.ReadLine();
                    newname = NamelettersValidity(newname);                  // checking if name has only alphabets
                    newname = Nametakenvalidity(newname, userCount, usernames); // checking if name is already taken
                    Console.Write("   Enter new pin: ");
                    newpin = Console.ReadLine();
                    newpin = Pindigitscheck(newpin); // checking 4-digits of pin
                    newpin = CheckpinValidity(newpin, userCount, passwords);
                    Console.Write("   Enter new account type: ");
                    newtype = Console.ReadLine();
                    newtype = Checkaccounttype(newtype);
                    Console.Write("   Enter new balance: ");
                    tempaccbalance = Console.ReadLine();
                    newbalance = BalanceValidity(tempaccbalance);
                    Console.Write("    Enter new status(freeze/running): ");
                    newstatus = Console.ReadLine();
                    Console.Write("   Enter new phonenumber: ");
                    newnumber = Console.ReadLine();
                    newnumber = Phone_numberLength(newnumber);  // getting 11 digit phone number
                    newnumber = PhonenumberValidity(newnumber); // checking if phonenumber contains only numbers
                    Updatinguserinfo(name, accountnum, newname, newpin, newbalance, newtype, newstatus, newnumber,userCount, usernames, accountnumbers, passwords, balances, accounttypes,  phonenumbers, statuses);
                }
                Updatedatainfile1(userCount, usernames, passwords, accountnumbers, balances, roles, accounttypes, phonenumbers, statuses);
                Console.WriteLine ("   UPdated account details.. ");
            }
            else
            {
                Console.WriteLine("  Account doesnot exists!");
            }
        }


    }
}                               