using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using BankwithClasses.DL;
using BankwithClasses.UI;

namespace BankwithClasses
{
    class Program
    {
        static int accountnum = 0;
        static void Main(string[] args)
        {
            string choice = "", adminChoice = "", clientChoice = "";

            ClientDL.LoadDatafromFile1(ref accountnum);
            TransactionDL.loadDatafromFile2();
            LoanDL.loadDatafromFile3();
            LoanDL.loadDatafromFile4();

            while (choice != "2")
            {
                BankUI.Header();
                choice = BankUI.Firstinterface();
                if(choice == "1")
                {
                    BankUI.Header();
                    Console.WriteLine("                              Login Menu                               ");
                    Console.WriteLine("    ===================================================================");
             
                    BUser user = BUserUI.Takeinputwithoutrole();

                    if(user != null)
                    {
                        user = BUserDL.SignIn(user);
                        if (user == null)
                        {
                            Console.WriteLine("    User not found");
                            BankUI.GoBack();
                        }
                        else if (BUserDL.isAdmin(user))
                        {
                            while (adminChoice != "12")
                            {
                                BankUI.Header();
                                adminChoice = BankUI.AdminMenu();
                                if (adminChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "Create Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client nperson = BUserUI.Takeinputwithrole(accountnum);
                                    Console.WriteLine();
                                    Console.WriteLine("    Account number " + accountnum + " successfully created! ");
                                    ClientDL.AddClientinList(nperson);
                                    ClientDL.StoreinFile1(nperson);        // storing data in people file
                                    accountnum++;
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "2")
                                {
                                    BankUI.Header();
                                    Console.WriteLine();
                                    string submenu = "Delete Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = BUserUI.Takeinput();
                                    bool check = ClientDL.Checkuserexistance(d);
                                    if (check == true)
                                    {
                                        ClientDL.Account_close(d);
                                        ClientDL.Updatedatainfile1();
                                        Console.WriteLine();
                                        Console.WriteLine("   Account succesfully closed! ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("   User does not exists! ");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "3")
                                {
                                    BankUI.Header();
                                    string submenu = "Freeze Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client f = BUserUI.Takeinput();
                                    bool flag = ClientDL.Freeze_account(f);

                                    if (flag == true)
                                    {
                                        ClientDL.Updatedatainfile1();
                                        Console.WriteLine("                Account is blocked now!");
                                    }
                                    else if (flag == false)
                                    {
                                        Console.WriteLine("   Account does not exists..");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "4")
                                {
                                    BankUI.Header();
                                    string submenu = "Search Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client d = BUserUI.Takeinput();
                                    bool flag = BUserUI.findspecificperson(d);   // searching a user's details
                                    if (flag == false)
                                    {
                                        Console.Write("    Account  not  found!");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "5")
                                {
                                    BankUI.Header();
                                    string submenu = "Updating Client's Record";
                                    BankUI.PrintsubMenu(submenu);

                                    Client updt = BUserUI.Takeinput();
                                    bool flag = BUserUI.findspecificperson(updt);
                                    if (flag == true)
                                    {
                                        string option = BankUI.UpdateMenu();   // updating a user's deatils
                                        if (option == "1")
                                        {
                                            string newname = BUserUI.inputName();
                                            ClientDL.UpdateName(newname, updt);
                                        }
                                        else if (option == "2")
                                        {
                                            string newpin = BUserUI.inputPin();
                                            ClientDL.UpdatePin(newpin, updt);

                                        }
                                        else if (option == "3")
                                        {
                                            string newaccType = BUserUI.inputType();
                                            ClientDL.Updatetype(newaccType, updt);
                                        }
                                        else if (option == "4")
                                        {
                                            float newbalance = BUserUI.inputBalance();
                                            ClientDL.Updatebalance(newbalance, updt);
                                        }
                                        else if (option == "5")
                                        {
                                            string newstatus = BUserUI.inputstatus();
                                            ClientDL.Updatestatus(newstatus, updt);
                                        }
                                        else if (option == "6")
                                        {
                                            string newnumber = BUserUI.inputPhoneno();
                                            ClientDL.Updatephonenumber(newnumber, updt);
                                        }
                                        else if (option == "7")
                                        {
                                            ClientDL.Updatinguserinfo(BUserUI.updateAll(updt.accountnumbers), updt);
                                        }
                                        ClientDL.Updatedatainfile1();
                                        Console.WriteLine("   UPdated account details.. ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("    Account doesnot exists!");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "6")
                                {
                                    BankUI.Header();
                                    string submenu = "View Clients personal info";
                                    BankUI.PrintsubMenu(submenu);
                                    Client view = new Client();
                                    BUserUI.ViewAllusers();
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "7")
                                {
                                    BankUI.Header();
                                    string submenu = "Give loan";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.showLoanRequests();
                                    Console.Write("    Do you want to give loan?(y/n) ");
                                    char opt = char.Parse(Console.ReadLine());
                                    if (opt == 'y')
                                    {
                                        LoanUI.giveLoan();
                                        BankUI.GoBack();
                                    }
                                    else
                                    {
                                        BankUI.GoBack();
                                    }
                                }
                                else if (adminChoice == "8")
                                {
                                    BankUI.Header();
                                    string submenu = "View loan holders";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.viewloanholders();
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "9")
                                {
                                    BankUI.Header();
                                    string submenu = "View total money";
                                    BankUI.PrintsubMenu(submenu);
                                    Client view = new Client();
                                    Console.WriteLine("  TOtal money present in bank is : " + ClientDL.Totalmoney());
                                    BankUI.GoBack();
                                }
                                else if (adminChoice == "11")
                                {
                                    BankUI.Header();
                                    string submenu = "Transaction details";
                                    BankUI.PrintsubMenu(submenu);
                                    TransUI.headofdata();
                                    BankUI.GoBack();
                                }
                            }
                        }
                        else
                        {
                            Client login = ClientDL.loginperson(user);
                            while (clientChoice != "9")
                            {
                                BankUI.Header();
                                clientChoice = BankUI.ClientMenu();
                                if (clientChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "View Balance";
                                    BankUI.PrintsubMenu(submenu);
                                    BUserUI.showbalance(login);
                                }
                                else if(clientChoice == "2")
                                {
                                    BankUI.Header();
                                    string submenu = "Deposit Moeny";
                                    BankUI.PrintsubMenu(submenu);
                                    
                                    bool flag = ClientDL.checkstatus(login);
                                    if (flag == true)
                                    {
                                        TransUI.depositMoney(login);
                                        Console.WriteLine("    Money has been deposited");
                                    }
                                    else if (flag == false)
                                    {
                                        Console.WriteLine("    You cannot deposit money, your account is blocked");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "3")
                                {
                                    BankUI.Header();
                                    string submenu = "TRansfer Money";
                                    BankUI.PrintsubMenu(submenu);
                                    bool flag = ClientDL.checkstatus(login);
                                    if (flag == true)
                                    {
                                        TransUI.transfermoney(login);
                                    }
                                    else if (flag == false)
                                    {
                                        Console.WriteLine("   You cannot transfer money, your account is blocked");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "4")
                                { 
                                    BankUI.Header();
                                    string submenu = "Withdraw Money";
                                    BankUI.PrintsubMenu(submenu);
                                    bool flag = ClientDL.checkstatus(login);

                                    if (flag == true)
                                    {
                                        TransUI.withdrawMoney(login);
                                    }
                                    else if (flag == false)
                                    {
                                        Console.WriteLine("    You cannot withdraw money, your account is blocked");
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "5")
                                {
                                    BankUI.Header();
                                    string submenu = "Request Loan";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.Requestloan(login);
                                }
                                else if (clientChoice == "6")
                                {
                                    BankUI.Header();
                                    string submenu = "Loan info";
                                    BankUI.PrintsubMenu(submenu);
                                    LoanUI.displayLoanDetails(login) ;
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "7")
                                {
                                    BankUI.Header();
                                    string submenu = "REturn LoAn";
                                    BankUI.PrintsubMenu(submenu);
                                    Console.Write("   Do you want to return all your loan(y/n)?  ");
                                    string op = Console.ReadLine();
                                    if(op == "y")
                                    {
                                        LoanDL.Return_Loan(login);
                                    }
                                    BankUI.GoBack();
                                }
                                else if (clientChoice == "8")
                                {
                                    BankUI.Header();
                                    string submenu = "Pay bills";
                                    BankUI.PrintsubMenu(submenu);
                                    TransUI.payBills(login.accountnumbers);
                                    BankUI.GoBack();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
