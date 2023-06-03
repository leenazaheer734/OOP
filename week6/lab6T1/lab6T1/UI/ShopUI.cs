using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6T1.BL;
using lab6T1.DL;

namespace lab6T1.UI
{
    class ShopUI
    {
        
        public static string ShopMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  1.  Add an Item in Menu ");
            Console.WriteLine("  2.  View Cheapest Item on Menu");
            Console.WriteLine("  3.  View the Drink's Menu");
            Console.WriteLine("  4.  View the Food's Menu");
            Console.WriteLine("  5.  Add Order");
            Console.WriteLine("  6.  Fulfill the order");
            Console.WriteLine("  7.  View the Orders's List");
            Console.WriteLine("  8.  Total Payable Amount");
            Console.WriteLine("  9.  Exit");
            Console.WriteLine();
            string option = Console.ReadLine();
            return option;
        }
        public static void AddItem()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("  Enter name of Item to add in Menu: ");
            string name = Console.ReadLine();
            Console.Write("  Enter type of item (Drink/Food): ");
            string type = Console.ReadLine();
            Console.Write("  Enter price of item: ");
            float price = float.Parse(Console.ReadLine());

            MenuItem m = new MenuItem(name, type, price);
            bool flag = MenuItem.CheckIteminMenu(name);
            if(flag == false)
            {
                ShopDL.AddIteminList(m);
                ShopDL.storedatainfile();
                Console.WriteLine("  Item is added in the Menu!!");
            }
            else
            {
                Console.WriteLine("  This item is already on the Menu!!");
            }
        }
        public static void ViewDrinks()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   Following are all the Drinks on the Menu: ");
            Console.WriteLine();
            Console.WriteLine("   Name\t\tPrice");

            foreach (MenuItem mi in ShopDL.ViewDrinks())
            {
                 Console.WriteLine("   " + mi.name+ "\t      " + mi.price);
            }
        }
        public static void ViewFood()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   Following is all the Food on the Menu: ");
            Console.WriteLine();
            Console.WriteLine("   Name\t\tPrice");

            foreach (MenuItem mi in ShopDL.ViewFood())
            {
                Console.WriteLine("   " + mi.name + "\t\t" + mi.price);
            }
        }
        public static void CheapestItem()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine( "  The cheapest menu item is: {0} with price {1} Rupees", ShopDL.CheapestItem().name, ShopDL.CheapestItem().price);
        }
        public static void AddOrder()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("  Enter name of item: ");
            string itemName = Console.ReadLine();
            bool ispresent = ShopDL.AddOrder(itemName);
            if(ispresent)
            {
                Console.WriteLine( "  Order is taken!");
            }
            else
            {
                Console.WriteLine("  This item is currently unavailable!!");
            }
        }
        public static void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine();
            List<string> orderName = ShopDL.listorders();

            if(orderName != null)
            {
                Console.WriteLine("   Following is the complete order: ");
                Console.WriteLine();
                Console.WriteLine("   Name");
                foreach (String name in ShopDL.listorders())
                {
                    Console.WriteLine("   " + name);
                }
            }
            else
            {
                Console.WriteLine("   NO orders!");
            }
        }
        public static void ShowAmountDue()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  The amount due is: {0} Rupees",  ShopDL.DueAmount());
        }
        public static void FulfillOrder()
        {
            string forder = ShopDL.fulfillorder();
            if(forder != null)
            {
                Console.WriteLine("   {0} is ready!!",forder);
                ShopDL.deleteOrder(forder);
            }
            else
            {
                Console.WriteLine("  All orders have been fulfilled!");
            }
        }

    }
}
