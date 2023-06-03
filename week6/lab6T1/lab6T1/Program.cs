using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6T1.BL;
using lab6T1.DL;
using lab6T1.UI;

namespace lab6T1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDL.loadDatafromFile();
            string option = "";
            while(option != "9")
            {
                option = ShopUI.ShopMenu();
                if(option == "1")
                {
                    ShopUI.AddItem();
                }
                else if( option == "2")
                {
                    ShopUI.CheapestItem();
                }
                else if(option == "3")
                {
                    ShopUI.ViewDrinks();
                }
                else if(option == "4")
                {
                    ShopUI.ViewFood();
                }
                else if(option == "5")
                {
                    ShopUI.AddOrder();
                }
                else if(option == "6")
                {
                    ShopUI.FulfillOrder();
                }
                else if(option == "7")
                {
                    ShopUI.ViewOrders();
                }
                else if(option == "8")
                {
                    ShopUI.ShowAmountDue();
                }
                Console.ReadKey();
            }
        }
    }
}
