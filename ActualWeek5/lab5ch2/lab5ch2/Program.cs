using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch2.BL;
using lab5ch2.DL;
using lab5ch2.UI;

namespace lab5ch2
{
    class Program
    {
        static void Main(string[] args)
        {
            MUserDL.Readdata();
            string option = "";
            while( option != "3")
            {
                option = StoreUI.MainMenu();
                if(option == "1")
                {
                    MUser user = StoreUI.SignIn();
                    if (user != null)
                    {
                        user = MUserDL.findUser(user);

                        if (user == null)
                        {
                            Console.WriteLine("   Invalid User");
                        }
                        else if (MUserDL.isAdmin(user))
                        {
                            string choice = "";
                            while (choice != "6")
                            {
                                choice = StoreUI.AdminMenu();
                                if (choice == "1")
                                {
                                    Product product = StoreUI.AddProducts();
                                    ProdDL.AddProduct(product);
                                    Console.WriteLine("  Product is added!");
                                    StoreUI.Cont();
                                }
                                else if (choice == "2")
                                {
                                    StoreUI.AdminOption2();
                                    StoreUI.Cont();
                                }
                                else if (choice == "3")
                                {
                                    StoreUI.AdminOption3();
                                    StoreUI.Cont();
                                }
                                else if (choice == "4")
                                {
                                    ProdDL.CalculateTax();
                                    StoreUI.AdminOption4();
                                    StoreUI.Cont();
                                }
                                else if (choice == "5")
                                {
                                    StoreUI.AdminOption5();
                                    StoreUI.Cont();
                                }
                            }
                        }
                        else 
                        {
                            Customer cu = new Customer(user);
                            string choice = "";
                            while (choice != "4")
                            {
                                choice = StoreUI.CustomerMenu();
                                if(choice == "1")
                                {
                                    StoreUI.AdminOption2();
                                    StoreUI.Cont();
                                }
                                else if(choice == "2")
                                {
                                    StoreUI.CustOption2(cu);
                                    StoreUI.Cont();
                                }
                                else if(choice == "3")
                                {
                                    StoreUI.CustOption3(cu);
                                    StoreUI.Cont();
                                }
                            }
                        }

                    }
                }
                else if(option == "2")
                {
                    MUser user = StoreUI.SignUp();
                    bool flag = MUserDL.IsValidUser(user);

                    if(flag == false)
                    {
                        MUserDL.addUserinList(user);
                        Console.WriteLine( "        Account created!");
                    }
                    else
                    {
                        Console.WriteLine( "        User ALready Exists!");
                    }
                    StoreUI.Cont();
                }
            }
        }
    }
}
