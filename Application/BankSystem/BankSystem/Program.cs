using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.UI;
using BankSystem.BL;
using BankSystem.DL;

namespace BankSystem
{
    class Program
    {

        static int accountnum = 0;

        static void Main(string[] args)
        {
            string choice = "";


            Admin adm = AdminDL.getAdminInfo();
            if(adm == null)
            {
                BankUI.Header();
                adm = BankUI.SignUPasAdmin();
            }

            do
            {
                BankUI.Header();
                choice = BankUI.Firstinterface();

                if (choice == "1")
                {
                    BankUI.Header();
                    BankUI.PrintLoginMenu();
                    BankUI.PrintLine();
                    Person user = BankUI.Takeinputwithoutrole();


                    if (user != null)
                    {
                        bool isvalid = PersonDL.SignIn(user);

                        if (isvalid == false)
                        {
                            Console.WriteLine("    User not found");
                            BankUI.GoBack();
                        }
                        else if (isvalid == true && PersonDL.isAdmin(user))
                        {
                            string adminChoice = "";
                            while (adminChoice != "12")
                            {
                                BankUI.Header();
                                adminChoice = BankUI.AdminMenu();
                                if (adminChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "Create Client Account";
                                    BankUI.PrintsubMenu(submenu);

                                    Client nperson = BankUI.Takeinputwithrole(accountnum);
                                    ClientDL.AddClientinList(nperson);
                                   //ClientDL.StoreinFile1(nperson);        // storing data in people file
                                    
                                    BankUI.GoBack();
                                }
                            }
                        }
                        else
                        {
                            Client login = ClientDL.loginperson(user);
                            string clientChoice = "";

                            while(clientChoice != "9")
                            {
                                BankUI.Header();
                                clientChoice = BankUI.ClientMenu();
                                if(clientChoice == "1")
                                {
                                    BankUI.Header();
                                    string submenu = "View Balance";
                                    BankUI.PrintsubMenu(submenu);
                                }
                            }
                            //client menu
                        }
                    }
                }
            } while (choice != "2");
        }
    }
}
