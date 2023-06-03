using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD3.BL;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int accountnum = 0;

            List<Credentials> users = new List<Credentials>();
            string choice = "", adminChoice = "", clientChoice = "";
            LoadDatafromFile1(users, ref accountnum);
            while (choice != "2")
            {
                Header();
                choice = Firstinterface();
                if (choice == "1")
                {
                    Header();
                    Console.WriteLine("                              Login Menu                               ");
                    Console.WriteLine("    ===================================================================");
                    Credentials user = Takeinputwithoutrole();

                    if (user != null)
                    {
                        user = SignIn(user, users);
                        if (user == null)
                        {
                            Console.WriteLine("User not found");
                            GoBack();
                        }
                        else if (user.isAdmin())
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

                                    Credentials admin = Takeinputwithrole(accountnum, users);
                                    Console.WriteLine();
                                    Console.WriteLine("    Account number " + accountnum + " successfully created! ");
                                    users.Add(admin);
                                    StoreinFile1(admin);        // storing data in people file
                                    accountnum++;
                                }
                                else if (adminChoice == "2")
                                {
                                    Header();
                                    Console.WriteLine();
                                    string submenu = "Delete Client Account";
                                    PrintsubMenu(submenu);

                                    Credentials d = Takeinput();
                                    bool check = d.Checkuserexistance(users);
                                    if (check == true)
                                    {
                                        d.Account_close(users);
                                        Updatedatainfile1(users);
                                        Console.WriteLine();
                                        Console.WriteLine("   Account succesfully closed! ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("   User does not exists! ");
                                    }
                                }
                                else if (adminChoice == "3")
                                {
                                    Header();
                                    string submenu = "Freeze Client Account";
                                    PrintsubMenu(submenu);
                                    Credentials f = Takeinput();
                                    bool flag = f.Freeze_account(users);
                                    if (flag == true)
                                    {
                                        Updatedatainfile1(users);
                                        Console.Write("    Account is blocked now!");
                                    }
                                    else if (flag == false)
                                    {
                                        Console.Write("    Account does not exists..");
                                    }
                                }
                                else if (adminChoice == "4")
                                {
                                    Header();
                                    string submenu = "Search Client Account";
                                    PrintsubMenu(submenu);

                                    Credentials d = Takeinput();
                                    bool flag = d.Search_account(users);   // searching a user's details
                                    if (flag == false)
                                    {
                                        Console.Write("    Account  not  found!");
                                    }
                                }
                                else if (adminChoice == "5")
                                {
                                    Header();
                                    string submenu = "Updating Client's Record";
                                    PrintsubMenu(submenu);
                                    Credentials updt = Takeinput();

                                    updt = SignIn(updt, users);
                                    if (updt != null)
                                    {
                                        string option = UpdateMenu();   // updating a user's deatils
                                        if (option == "1")
                                        {
                                            Console.Write("   Enter new name: ");
                                            string newname = Console.ReadLine();
                                            newname = NamelettersValidity(newname);                  // checking if name has only alphabets
                                            newname = Nametakenvalidity(newname, users); // checking if name is already taken
                                            updt.UpdateName(newname, users);
                                        }
                                        else if (option == "2")
                                        {
                                            Console.Write("   Enter new pin: ");
                                            string newpass = Console.ReadLine();
                                            newpass = Pindigitscheck(newpass); // checking 4-digits of pin
                                            newpass = CheckpinValidity(newpass, users);
                                            updt.UpdatePin(newpass, users);
                                        }
                                        else if (option == "3")
                                        {
                                            Console.Write("   Enter new account type: ");
                                            string newacctype = Console.ReadLine();
                                            newacctype = Checkaccounttype(newacctype);
                                            updt.Updatetype(newacctype, users);
                                        }
                                        else if (option == "4")
                                        {
                                            Console.Write("   Enter new balance: ");
                                            string tempaccbalance = Console.ReadLine();
                                            float newbalance = BalanceValidity(tempaccbalance);
                                            updt.Updatebalance(newbalance, users);
                                        }
                                        else if (option == "5")
                                        {
                                            Console.Write("   Enter new status(freeze/running): ");
                                            string newstatus = Console.ReadLine();
                                            updt.Updatestatus(newstatus, users);
                                        }
                                        else if (option == "6")
                                        {
                                            Console.Write("   Enter new phonenumber: ");
                                            string newnumber = Console.ReadLine();
                                            newnumber = Phone_numberLength(newnumber);  // getting 11 digit phone number
                                            newnumber = PhonenumberValidity(newnumber); // checking if phonenumber contains only numbers
                                            updt.Updatephonenumber(newnumber, users);
                                        }
                                        else if (option == "7")
                                        {
                                            Credentials update = new Credentials();
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
                                            string tempaccbalance = Console.ReadLine();
                                            update.balances = BalanceValidity(tempaccbalance);
                                            Console.Write("    Enter new status(freeze/running): ");
                                            update.statuses = Console.ReadLine();
                                            Console.Write("   Enter new phonenumber: ");
                                            update.phonenumbers = Console.ReadLine();
                                            update.phonenumbers = Phone_numberLength(update.phonenumbers);  // getting 11 digit phone number
                                            update.phonenumbers = PhonenumberValidity(update.phonenumbers); // checking if phonenumber contains only numbers

                                            updt.Updatinguserinfo(update, users);
                                        }
                                        Updatedatainfile1(users);
                                        Console.WriteLine("   UPdated account details.. ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("  Account doesnot exists!");
                                    }
                                }
                                else if (adminChoice == "6")
                                {
                                    Header();
                                    string submenu = "View Clients personal info";
                                    PrintsubMenu(submenu);
                                    Credentials view = new Credentials();
                                    view.ViewAllusers(users);
                                }
                                else if (adminChoice == "7")
                                {
                                    Header();
                                    string submenu = "Give loan";
                                    PrintsubMenu(submenu);
                                    char answer;
                                    //ShowLoanRequests(reqLoan);
                                    Console.WriteLine("    Do you want to give loan?(y/n) ");
                                    answer = char.Parse(Console.ReadLine());
                                    if (answer == 'y')
                                    {
                                        //giveLoan();
                                    }
                                }
                                else if (adminChoice == "8")
                                {
                                    Header();
                                    string submenu = "View loan holders";
                                    PrintsubMenu(submenu);
                                    //Viewloanholders(loan_count, loanholders, givenloanamounts, givenloandays, loantime);
                                }
                                else if (adminChoice == "9")
                                {
                                    Header();
                                    string submenu = "View total money";
                                    PrintsubMenu(submenu);
                                    Credentials view = new Credentials();
                                    Console.WriteLine("  TOtal money present in bank is : " + view.Totalmoney(users));
                                }
                                else if (adminChoice == "10")
                                {
                                    Header();
                                    string submenu = "Apply tax";
                                    PrintsubMenu(submenu);
                                    string option = TaxMenu();
                                    if (option == "1")
                                    {
                                        Credentials d = Takeinput();
                                        bool check = d.Search_account(users);
                                        if (check == true)
                                        {
                                            Console.Write("   Enter percentage of tax to implement: ");
                                            string tpercent = Console.ReadLine();
                                            int percentofTax = CheckPercentage(tpercent);
                                            d.TaxonSpecific(percentofTax, users);
                                            Updatedatainfile1(users);
                                            Console.WriteLine("   TAx has been deducted!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("   Invalid account!");
                                        }
                                    }
                                    else if (option == "2")
                                    {
                                        Header();
                                        submenu = "tax on all clients";
                                        PrintsubMenu(submenu);
                                        Console.Write("    Enter percentage of tax to implement: ");
                                        string tempnumber = Console.ReadLine();
                                        int percentofTax = int.Parse(PhonenumberValidity(tempnumber));
                                        Credentials tax = new Credentials();
                                        tax.TaxonAll(percentofTax, users);
                                        Updatedatainfile1(users);
                                        Console.WriteLine("    TAx hasbeen deducted!");
                                    }
                                }
                                else if (adminChoice == "11")
                                {
                                    Header();
                                    string submenu = "Transaction details";
                                    PrintsubMenu(submenu);
                                    // ViewAlltransactions(trans_count, transactionaccounts, transactionamounts, transactiontypes, transactiontimes);
                                }
                                GoBack();
                            }
                        }
                        else
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
                                    Console.WriteLine("  Your current account balance is: " + user.balances);
                                    GoBack();
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
                        string[] filedata = line.Split(',');
                        int accountnumber = int.Parse(filedata[0]);
                        string name = filedata[1];
                        string password = filedata[2];
                        string role = filedata[3];
                        string accounttype = filedata[4];
                        float balance = float.Parse(filedata[5]);
                        string phonenumber = filedata[6];
                        string status = filedata[7];

                        Credentials info = new Credentials(name, password, accounttype, balance, phonenumber, accountnumber, status, role);
                        users.Add(info);
                    }
                }
                myFile.Close();
                accountnum = CheckNewAccountnumber(users) + 1;
            }
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
        static Credentials Takeinputwithoutrole()
        {
            Console.Write("    Enter your name:  ");
            string loginusername = Console.ReadLine();
            loginusername = NamelettersValidity(loginusername);
            Console.Write("    Enter your 4-digit security pin: ");
            string loginpassword = Console.ReadLine();
            loginpassword = Pindigitscheck(loginpassword);

            if (loginusername != null && loginpassword != null)
            {
                Credentials user = new Credentials(loginusername, loginpassword);
                return user;
            }
            return null;
        }
        static Credentials SignIn(Credentials user, List<Credentials> users)
        {
            foreach (Credentials storedUser in users)
            {
                if (user.usernames == storedUser.usernames && user.passwords == storedUser.passwords)
                {
                    return storedUser;
                }
            }
            return null;
        }
        static Credentials Takeinputwithrole(int accountnum, List<Credentials> users)
        {
            Console.Write("    Enter name of client: ");
            string name = Console.ReadLine();
            name = NamelettersValidity(name);                         // checking if name has only alphabets
            name = Nametakenvalidity(name, users);                  // checking if name is already taken

            Console.Write("    Enter 4-digit pin for account: ");
            string password = Console.ReadLine();
            password = Pindigitscheck(password);                                        // checing 4digits of password
            password = CheckpinValidity(password, users);                             // checking if passwords is alreadytaken

            Console.Write("    Enter type of account (salary/current) : ");
            string accounttype = Console.ReadLine(); ;
            accounttype = Checkaccounttype(accounttype);                // checking if account type is only salary or current

            Console.Write("    Enter starting balance of account: ");
            string tempbalance = Console.ReadLine();
            float balance = BalanceValidity(tempbalance);                    // chceking if balance enetered contains only numbers
            balance = Minimum_balance(balance, accounttype);

            Console.Write("    Enter phonenumber(without dashes): ");
            string tempphone = Console.ReadLine();
            string phonenumber = Phone_numberLength(tempphone);                  // getting 11 digit phone number
            phonenumber = PhonenumberValidity(tempphone);                // checking if phonenumber contains only numbers
            int accountnumber = accountnum;

            Credentials info = new Credentials(name, password, accounttype, balance, phonenumber, accountnumber,"running","client");
            return info;
        }
        static Credentials Takeinput()
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

            Credentials d = new Credentials(name, pin, accountnumber);
            return d;
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
                    Console.Write("    Enter 11-digit number: ");
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
        static void StoreinFile1(Credentials info)
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(info.accountnumbers + "," + info.usernames + "," + info.passwords + "," + "client" + "," + info.accounttypes + "," + info.balances + "," + info.phonenumbers + "," + "running");
            myFile.Flush();
            myFile.Close();
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
        static string TaxMenu()
        {
            string option;
            Console.WriteLine("  Do you want to implement tax on : ");
            Console.WriteLine("   1. specific user.");
            Console.WriteLine("   2. All users.");
            option = Console.ReadLine();
            return option;
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