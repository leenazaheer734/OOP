using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankwithClasses.BL;
using BankwithClasses.UI;


namespace BankwithClasses.DL
{
    class ClientDL
    {
        public static List<Client> clients = new List<Client>();
        public static void LoadDatafromFile1(ref int accountnum)
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
                        BUser nu = new BUser(name, password, role);
                        BUserDL.storeuserinlist(nu);
                        Client info = new Client(nu, accounttype, balance, phonenumber, accountnumber, status);
                        clients.Add(info);
                    }
                }
                myFile.Close();
                accountnum = CheckNewAccountnumber() + 1;
            }
        }
        public static int CheckNewAccountnumber()
        {
            int largest = clients[0].accountnumbers;
            for (int index = 1; index < clients.Count; index++)
            {
                if (largest < clients[index].accountnumbers)
                {
                    largest = clients[index].accountnumbers;
                }
            }
            return largest;
        }
        public static void AddClientinList(Client nperson)
        {
            clients.Add(nperson);
        }
        public static void StoreinFile1(Client info)
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(info.accountnumbers + "," + info.credentials.username + "," + info.credentials.password + "," + "client" + "," + info.accounttypes + "," + info.balances + "," + info.phonenumbers + "," + "running");
            myFile.Flush();
            myFile.Close();
        }
        public static void Updatedatainfile1()
        {
            string path = "D:\\OOP\\people.txt";
            StreamWriter myFile = new StreamWriter(path);

            myFile.WriteLine(clients[0].accountnumbers + "," + clients[0].credentials.username + "," + clients[0].credentials.password + "," + clients[0].credentials.role + "," + clients[0].accounttypes + "," + clients[0].balances + "," + clients[0].phonenumbers + "," + clients[0].statuses);
            for (int idx = 1; idx < clients.Count; idx++)
            {
                myFile.WriteLine(clients[idx].accountnumbers + "," + clients[idx].credentials.username + "," + clients[idx].credentials.password + "," + clients[idx].credentials.role + "," + clients[idx].accounttypes + "," + clients[idx].balances + "," + clients[idx].phonenumbers + "," + clients[idx].statuses);
            }
            myFile.Close();
        }
        public static string Nametakenvalidity(string name)
        {
            bool flag = AlreadyTakenName(name);
            if (flag == true)
            {
                Console.WriteLine("    This name is already Taken!");
                while (flag != false)
                {
                    Console.Write("    Enter Name again: ");
                    name = Console.ReadLine();
                    flag = AlreadyTakenName(name);
                }
            }
            return name;
        }
        public static bool AlreadyTakenName(string name)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool AlreadyTakenPin(string pin)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.password == pin)
                {
                    return true;
                }
            }
            return false;
        }
        public static void showallclients()
        {
            for (int idx = 1; idx < clients.Count; idx++)
            {
                BUserUI.getallClients(clients[idx]);
            }
        }
        public static bool Checkuserexistance(Client n)
        {
            foreach (Client temp in clients)
            {
                if (temp.credentials.username == n.credentials.username && n.credentials.password == temp.credentials.password && n.accountnumbers == temp.accountnumbers)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkaccountPresence(int accountnumber, string pin)
        {
            bool isPresent = false;
            for (int idx = 0; idx < clients.Count; idx++) // finding user account exits from account number and pin
            {
                if (clients[idx].accountnumbers == accountnumber && clients[idx].credentials.password == pin)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
        public static void Account_close(Client n)
        {
            for (int index = 1; index < clients.Count; index++)
            {
               if (clients[index].credentials.username == n.credentials.username && clients[index].credentials.password == n.credentials.password && clients[index].accountnumbers == n.accountnumbers)
                {
                    clients.RemoveAt(index);         // finding index where data of user is stored in list
                }
            }
        }
        public static bool Freeze_account(Client del)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].accountnumbers == del.accountnumbers && clients[idx].credentials.password == del.credentials.password)
                {
                    clients[idx].statuses = "freeze";
                    return true;
                }
            }
            return false;
        }
        public static Client Search_account(Client s)
        {
            for (int idx = 1; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == s.credentials.username && clients[idx].accountnumbers == s.accountnumbers)
                {
                    return  clients[idx];
                }
            }
            return null;
        }
        public static float Totalmoney()
        {
            float total = 0;
            for (int index = 1; index < clients.Count; index++)
            {
                total = total + clients[index].balances; // adding money present in bank
            }
            return total;
        }
        public static void UpdateName(string newname, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].credentials.username = newname;
                    break;
                }
            }
        }
        public static void UpdatePin(string newpass, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].credentials.password = newpass;
                    break;
                }
            }
        }
        public static void Updatetype(string newtype, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].accounttypes = newtype;
                    break;
                }
            }
        }
        public static void Updatestatus(string newstatus, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].statuses = newstatus;
                    break;
                }
            }
        }
        public static void Updatephonenumber(string newnumber, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].phonenumbers = newnumber;
                    break;
                }
            }
        }
        public static void Updatebalance(float newbalance, Client c)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == c.credentials.username && clients[idx].accountnumbers == c.accountnumbers)
                {
                    clients[idx].balances = newbalance;
                    break;
                }
            }
        }
        public static void Updatinguserinfo(Client update, Client old)
        {
            for (int idx = 1; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == old.credentials.username && clients[idx].accountnumbers == old.accountnumbers)
                {
                    clients[idx].credentials = update.credentials;
                    clients[idx].balances = update.balances;
                    clients[idx].accounttypes = update.accounttypes;
                    clients[idx].statuses = update.statuses;
                    clients[idx].phonenumbers = update.phonenumbers;
                    break;
                }
            }
        }
        public static void TaxonSpec(int percentofTax, Client c)
        {
            for (int indx = 1; indx < clients.Count; indx++)
            {
                if (clients[indx].credentials.username == c.credentials.username && clients[indx].accountnumbers == c.accountnumbers)  // implementing tax on specific account
                {
                    clients[indx].balances = clients[indx].balances - (clients[indx].balances * percentofTax / 100);
                    break;
                }
            }
        }
        public static void TaxonAll(int percentofTax)
        {
            for (int indx = 1; indx < clients.Count; indx++)     // implementing tax on all accounts
            {
                clients[indx].balances = clients[indx].balances - (clients[indx].balances * percentofTax / 100);
            }
        }
        public static float getbalance(Client d)
        {
            float balance = 0F;
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].accountnumbers == d.accountnumbers && clients[idx].credentials.password == d.credentials.password)
                {
                    balance = clients[idx].balances;
                }
            }
            return balance;
        }
        public static Client loginperson(BUser u)
        {
            for (int idx = 1; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == u.username && clients[idx].credentials.password == u.password)
                {
                    return clients[idx];
                }
            }
            return null;
        }
        public static bool checkstatus(Client d)
        {
            bool statusFlag = false;
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].credentials.username == d.credentials.username && clients[i].accountnumbers == d.accountnumbers)
                {
                    if (clients[i].statuses == "running")
                    {
                        statusFlag = true;
                    }
                    else if (clients[i].statuses == "freeze")
                    {
                        statusFlag = false;
                    }
                    break;
                }
            }
            return statusFlag;
        }
        public static void addmoneyinaccount(float depositAmount, Client s)
        {
            for (int index = 0; index < clients.Count; index++)
            {
                // depositing money in bank
                if (clients[index].credentials.username == s.credentials.username && clients[index].credentials.password == s.credentials.password)
                {
                    clients[index].balances = clients[index].balances + depositAmount;
                    break;
                }
            }
        }
        public static void cutmoneyfromaccount(float withdrawAmount, Client s)
        {
            for (int index = 0; index < clients.Count; index++)
            {
                // depositing money in bank
                if (clients[index].credentials.username == s.credentials.username && clients[index].credentials.password == s.credentials.password)
                {
                    clients[index].balances = clients[index].balances - withdrawAmount;
                    break;
                }
            }
        }
        public static bool findAccount(string name, int accnum)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].credentials.username == name && clients[idx].accountnumbers == accnum)
                {
                    return true;
                }
            }
            return false;
        }

        public static void moneyTransfertoSomeone(int someone_account, float transfer_money,float cbalance, int cAccount)
        {
            for (int index = 0; index < clients.Count; index++) // finding index of someones account
            {
                if (clients[index].accountnumbers == someone_account)
                {
                    // checking if balance is sufficent
                    if (transfer_money > cbalance)
                    {
                        Console.WriteLine("   Low  account balance!!money cannot be transfered!!");
                        break;
                    }
                    else
                    {
                        moneytransferfromClient(transfer_money,cAccount); // transferring money
                        clients[index].balances = clients[index].balances + transfer_money;
                        ClientDL.Updatedatainfile1();
                        Console.WriteLine("    MOney has been transfered " );
                        break;
                    }
                }
            }
        }
        public static void moneytransferfromClient(float transfer_money, int cAccount)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                // finding index where user name is stored
                if (clients[idx].accountnumbers == cAccount )
                {
                    // deducting money from user's account
                    clients[idx].balances = clients[idx].balances - transfer_money;
                }
            }
        }
        public static void payBills(int recp_accnumber, float bill, int accnum)
        {
            for (int index = 0; index < clients.Count; index++)
            {
                // finding account number of recepient
                if (clients[index].accountnumbers == recp_accnumber)
                {
                    for (int idx = 0; idx < clients.Count; idx++)
                    {
                        if (clients[idx].accountnumbers == accnum)
                        {
                            // checking if users balance is sufficient to pay bill
                            if (bill > clients[index].balances)
                            {
                                Console.WriteLine("   Insufficient account balance!!");
                            }
                            else
                            {
                                // paying bill
                                clients[idx].balances = clients[idx].balances - bill;
                                clients[index].balances = clients[index].balances + bill;
                                Updatedatainfile1();
                                Console.WriteLine("    Transferred!!");
                            }
                            break;
                        }
                    }
                }
            }
        }
        public static void reQuestLoan(Client u)
        {
            bool valid = LoanDL.checkvalidityofrequestloan(u.accountnumbers);
            bool check = LoanDL.checkpreviousloanrequest(u.accountnumbers);
            if (check == false && valid == false)
            {
                for (int index = 0; index < clients.Count; index++)
                {
                    if (clients[index].accountnumbers == u.accountnumbers && clients[index].credentials.password == u.credentials.password)
                    {
                        if (clients[index].accounttypes == "salary")
                        {
                            Console.WriteLine("    you cannot request loan as you have salary account!");
                        }
                        else if (clients[index].accounttypes == "current")
                        {
                            // requesting loan
                            Console.WriteLine("    Enter amount of loan you want to take: ");
                            string tempamount = Console.ReadLine();
                            float loan_amount = BUserUI.BalanceValidity(tempamount);
                            Loan l = new Loan(u, loan_amount);
                            LoanDL.storeloandetailsinfile(l);
                            LoanDL.addrequest(l);
                            Console.WriteLine("    YOUR request has beeb submitted" );
                        }
                        BankUI.GoBack();
                    }
                }
            }
            if (check == true || valid == true)
            {
                Console.WriteLine("   You cannot request loan!" );
                BankUI.GoBack();
            }
        }
        public static void approveLoan(string name, int holdersaccount)
        {
            bool valid1 = LoanDL.checkagaingvingofloan(name, holdersaccount);
            bool valid2 = LoanDL.checkgivingtorequests(name, holdersaccount);

            if (valid2 == true && valid1 == false)
            {
                float loanAmount = LoanDL.findrequestedloan(name, holdersaccount);
                Console.Write("    Enter time for which you are giving loan: ");
                string days = Console.ReadLine();

                for (int index = 0; index < clients.Count; index++)
                {
                    // giving loan to a specfic account
                    if (clients[index].credentials.username == name && clients[index].accountnumbers == holdersaccount)
                    {
                        clients[index].balances = clients[index].balances + loanAmount;

                        Loan l = new Loan(clients[index], loanAmount,days);
                        LoanDL.addloandetail(l);

                        LoanDL.deleteloanrequest(l);

                        LoanDL.Updatedatainfile3();
                        LoanDL.storedatainfile4(l);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("    You cannot give loan to this user!");
            }
        }
    }
}
