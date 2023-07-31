using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.DL;
using NewBank.UI;
using iTextSharp;

namespace NewBank
{
    class Program
    { 
        static int accountnum = 1;
        static void Main(string[] args)
        {
            AdminDL.LoadAdminDataFromFile();
            ClientDL.LoadClientDataFromFile(ref accountnum);
            TransDL.LoadTransactionDataFromFile();
            LoanDL.LoadLoanDataFromFile();

            bool isAdminPresent = AdminDL.CheckAdminPresence();    //checking if admin is intially present
            if(isAdminPresent == false)
            {
                //admin signUp
                BankUI.Header();
                Admin a = AdminUI.SignUpAdmin();

                AdminDL.StoreAdminInList(a);
                AdminDL.StoreAdminDatainFile(a);
                AdminUI.ShowAdminIsAdded();                                   //displaying message that admin is added
            }

            string choice = "";
            do
            {
                BankUI.Header();
                choice = BankUI.FirstInterface();

                if(choice == "1")
                {
                    BankUI.Header();
                    BankUI.PrintLoginMenu();
                    BankUI.PrintLine();
                    Person user = PersonUI.TakeInputWithoutRole();    //signing in the user

                    if(user != null)
                    {
                        Client c1 = ClientDL.checkPersonIsClient(user);
                        Admin a1 = AdminDL.checkAdmin(user);

                        if(a1 == null && c1 == null)
                        {
                            BankUI.UserNotFound();
                        }
                        else if(c1 == null && a1 != null)
                        {
                            //admin menu
                            string adminChoice = "";
                            while(adminChoice != "11")
                            {
                                BankUI.Header();
                                adminChoice = BankUI.DisplayAdminMenu();

                                if (adminChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "Create Client Account";
                                    BankUI.PrintsubMenu(submenu);
                                    

                                    Client nperson = ClientUI.TakeInputWithRole(accountnum);
                                    ClientDL.AddClientinList(nperson);
                                    ClientDL.StoreClientInFile(nperson);        // storing data of user file
                                    BankUI.GoBack();
                                }
                                else if(adminChoice == "2")
                                {
                                    BankUI.Header();
                                    string submenu = "Delete Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = ClientUI.TakeInputOfClient();
                                    bool check = ClientDL.CheckifClientExixts(d);
                                    if(check == true)
                                    {
                                        ClientDL.Account_close(d);
                                        ClientDL.UpdateClientDataInFile();
                                        AccountUI.showCloseAccount();
                                        BankUI.GoBack();
                                    }
                                    else
                                    {
                                        BankUI.UserNotFound();
                                    }
                                }
                                else if(adminChoice == "3")
                                {
                                    BankUI.Header();
                                    string submenu = "Freeze Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = ClientUI.TakeInputOfClient();
                                    bool flag = ClientDL.Freeze_Account(d);
                                    if (flag == true)
                                    {
                                        ClientDL.UpdateClientDataInFile();
                                        AccountUI.showBlockedStatus();
                                        BankUI.GoBack();
                                    }
                                    else if (flag == false)
                                    {
                                        BankUI.UserNotFound();
                                    }
                                    
                                }
                                else if(adminChoice == "4")
                                {
                                    BankUI.Header();
                                    string submenu = "Search Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = ClientUI.TakeInputOfClient();
                                    bool flag = ClientUI.findSpecificClient(d);   // searching a user's details
                                    if (flag == false)
                                    {
                                        BankUI.UserNotFound();
                                    }
                                    else
                                    BankUI.GoBack();
                                }
                                else if(adminChoice == "5")
                                {
                                    BankUI.Header();
                                    string submenu = "Updating Client's Record";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = ClientUI.TakeInputOfClient();
                                    d = ClientDL.SearchClientAccount(d);   // searching a user's details
                                    if ( d != null)
                                    {
                                        string option = BankUI.UpdateMenu();   // updating a user's deatils
                                        if (option == "1")
                                        {
                                            string newname = ClientUI.inputNewName();
                                            d.GetPerson().setName(newname);
                                        }
                                        else if (option == "2")
                                        {
                                            string newpin = ClientUI.inputNewPin();
                                            d.GetPerson().setPassword(newpin);

                                        }
                                        else if (option == "3")
                                        {
                                            string newaccType = ClientUI.inputNewType();
                                            d.getAccount().setType(newaccType);
                                        }
                                        else if (option == "4")
                                        {
                                            double newbalance = ClientUI.inputNewBalance();
                                            d.getAccount().setBalance(newbalance);
                                        }
                                        else if (option == "5")
                                        {
                                            string newstatus = ClientUI.inputNewstatus();
                                            d.getAccount().setStatus(newstatus);
                                        }
                                        else if (option == "6")
                                        {
                                            string newnumber = ClientUI.inputNewPhoneno();
                                            d.GetPerson().setNumber(newnumber);
                                        }
                                        else if(option == "7")
                                        {
                                            string newaddress = ClientUI.inputNewAddress();
                                            d.GetPerson().getAddress();
                                        }
                                        else if (option == "8")
                                        {
                                            ClientUI.updateAll(d);

                                        }
                                        
                                        ClientDL.UpdateClientDataInFile();
                                        BankUI.showUpdatedMessage();
                                        BankUI.GoBack();
                                    }
                                    else
                                    {
                                        BankUI.UserNotFound();
                                    }
                                }
                                else if (adminChoice == "6")
                                {
                                    BankUI.Header();
                                    string submenu = "View Clients personal info";
                                    BankUI.PrintsubMenu(submenu);

                                    ClientUI.ViewAllUsers();
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "7")
                                {
                                    BankUI.Header();
                                    string submenu = "Manage loan Requests";
                                    BankUI.PrintsubMenu(submenu);

                                    LoanUI.showLoanRequests();
                                    string opt = LoanUI.approveORrejectRequests();
                                    Client c2 = ClientDL.SearchClientAccount(ClientUI.TakeInputOfClient());
                                    if (opt == "1" && c2 != null)
                                    {
                                        LoanUI.giveLoanToClient(c2);
                                    }
                                    else if(opt == "2"&& c2 != null)
                                    {
                                        LoanDL.deleteLoanReq(c2);
                                    }
                                    else
                                    {
                                        BankUI.GoBack();
                                    }
                                    LoanDL.storeLoanInFile();
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "8")
                                {
                                    BankUI.Header();
                                    string submenu = "View loan holders";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.viewApprovedLoans();
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "9")
                                {
                                    BankUI.Header();
                                    string submenu = "View total money";
                                    BankUI.PrintsubMenu(submenu);
                                    BankUI.CalculateTotalMoney();
                                    BankUI.GoBack();
                                }
                                else if(adminChoice == "10")
                                {
                                    BankUI.Header();
                                    string submenu = "Transaction details";
                                    BankUI.PrintsubMenu(submenu);
                                    TransUI.ShowTransDetails();
                                    BankUI.GoBack();
                                }
                            
                            } 
                            
                        }
                        else
                        {
                            //clientMenu
                            string clientChoice = "";
                            while (clientChoice != "9")
                            {
                                BankUI.Header();
                                clientChoice = ClientUI.DisplayClientMenu();

                                if (clientChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "View Balance";
                                    BankUI.PrintsubMenu(submenu);

                                    ClientUI.ShowClientAccountBalance(c1);
                                }
                                else if(clientChoice == "2")
                                {
                                    BankUI.Header();
                                    string submenu = "Deposit Moeny";
                                    BankUI.PrintsubMenu(submenu);

                                    if (TransDL.checkStatusOfAccount(c1))
                                    {
                                        Transaction t = TransUI.depositMoney(c1);
                                        TransDL.AddTransactionInList(t);
                                        ClientDL.UpdateClientDataInFile();
                                        TransDL.StoreTransactionInFile(t);
                                        TransUI.showTransMessage("deposited");
                                    }
                                    else
                                    {
                                        TransUI.showAccBlockedNessage("deposit");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "3")
                                {
                                    BankUI.Header();
                                    string submenu = "TRansfer Money";
                                    BankUI.PrintsubMenu(submenu);

                                    if(TransDL.checkStatusOfAccount(c1))
                                    {
                                        Transaction t = TransUI.transferMoney(c1);
                                        if(t != null)
                                        {
                                            TransDL.AddTransactionInList(t);
                                            ClientDL.UpdateClientDataInFile();
                                            TransDL.StoreTransactionInFile(t);
                                            TransUI.showTransMessage("transferred");
                                        }
                                    }
                                    else
                                    { 
                                        TransUI.showAccBlockedNessage("transfer");
                                    }
                                        
                                    BankUI.GoBack();
                                }
                                else if(clientChoice == "4")
                                {
                                    BankUI.Header();
                                    string submenu = "Withdraw Money";
                                    BankUI.PrintsubMenu(submenu);

                                    if (TransDL.checkStatusOfAccount(c1))
                                    {
                                        Transaction t = TransUI.withdrawMoney(c1);
                                        TransDL.AddTransactionInList(t);
                                        ClientDL.UpdateClientDataInFile();
                                        TransDL.StoreTransactionInFile(t);
                                        TransUI.showTransMessage("withdrawn");
                                    }
                                    else
                                    {
                                        TransUI.showAccBlockedNessage("withdraw");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "5")
                                {
                                    BankUI.Header();
                                    string submenu = "Request Loan";
                                    BankUI.PrintsubMenu(submenu);

                                    Loan l = LoanUI.requestLoan(c1);
                                    if(l != null)
                                    {
                                        LoanDL.storeLoanInList(l);
                                        LoanDL.storeLoanInFile();
                                        LoanUI.reqSubmitted();
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "6")
                                {
                                    BankUI.Header();
                                    string submenu = "Loan info";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.displayLoanDetails(c1);
                                    BankUI.GoBack();
                                }
                                else if(clientChoice == "7")
                                {
                                    BankUI.Header();
                                    string submenu = "REturn LoAn";
                                    BankUI.PrintsubMenu(submenu);

                                    LoanUI.returnLoan(c1);
                                    LoanDL.storeLoanInFile();
                                    BankUI.GoBack();
                                }
                                else if(clientChoice == "8")
                                {
                                    BankUI.Header();
                                    string submenu = "Last Month Transactions";
                                    BankUI.PrintsubMenu(submenu);
                                    TransUI.showLastMonthTransactions(c1);

                                    BankUI.GoBack();
                                }
                                else if(clientChoice == "10")
                                {
                                    BankUI.Header();
                                    string submenu = "Last Month Transactions";
                                    BankUI.PrintsubMenu(submenu);

                                    if (TransDL.checkOneMonthDateDiff(c1).Count > 0)
                                    {
                                        Console.WriteLine("enter 1 to generate pdf of your last month transactions: ");
                                        string opt;
                                        opt = Console.ReadLine();
                                        if(opt == "1")
                                        {

                                        }

                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            while (choice != "2");
        }
    }
}
