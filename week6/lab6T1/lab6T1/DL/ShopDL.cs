using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lab6T1.BL;

namespace lab6T1.DL
{
    class ShopDL
    {
        public static void AddIteminList(MenuItem m)
        {
            CoffeeShop.items.Add(m);
        }
        public static List<MenuItem> ViewDrinks()
        {
            List<MenuItem> drinks = new List<MenuItem>();
            foreach (MenuItem mi in CoffeeShop.items)
            {
                if (mi.type.ToLower() == "drink")
                {
                    drinks.Add(mi);
                }
            }
            return drinks;
        }
        public static List<MenuItem> ViewFood()
        {
            List<MenuItem> food = new List<MenuItem>();
            foreach (MenuItem mi in CoffeeShop.items)
            {
                if (mi.type.ToLower() == "food")
                {
                    food.Add(mi);
                }
            }
            return food;
        }
        public static MenuItem CheapestItem()
        {
            MenuItem m = CoffeeShop.items[0];
            float price = CoffeeShop.items[0].price;
            for (int i = 1; i < CoffeeShop.items.Count; i++)
            {
                if(price > CoffeeShop.items[i].price)
                {
                    price = CoffeeShop.items[i].price;
                    m = CoffeeShop.items[i];
                }
            }
            return m;
        }
        public static bool AddOrder(string name)
        {
            foreach(MenuItem mi in CoffeeShop.items)
            {
                if(mi.name == name)
                {
                    CoffeeShop.orders.Add(name);
                    return true;
                }
            }
            return false;
        }
        public static List<string> listorders()
        {
            if(CoffeeShop.orders.Count == 0)
            {
                return null;
            }
            else
            {
                return CoffeeShop.orders;
            }
        }
        public static float DueAmount()
        {
            float tprice = 0;
            foreach(String order in CoffeeShop.orders)
            {
                tprice = tprice + findPrice(order);
            }
            return tprice;
        }
        public static float findPrice(string name)
        {
            float price = 0;
            foreach(MenuItem m in CoffeeShop.items)
            {
                if(m.name == name)
                {
                    price = m.price;
                }
            }
            return price;
        }
        public static string fulfillorder()
        {
            if (CoffeeShop.orders.Count != 0)
            {
                return CoffeeShop.orders[0];
            }
            else
            {
                return null;
            }

        }
        public static void deleteOrder(string name)
        {
            int index = 0;
            foreach(String o in CoffeeShop.orders)
            {
                if(o == name)
                {
                    CoffeeShop.orders.RemoveAt(index);
                    break;
                }
                index++;
            }
        }
        public static void storedatainfile()
        {
            string path = "D:\\OOP\\week6\\coffeeshop.txt";
            StreamWriter myFile = new StreamWriter(path);
            foreach(MenuItem mi in CoffeeShop.items)
            {
                myFile.WriteLine(mi.name+","+ mi.type + ","+mi.price);
            }
            myFile.Flush();
            myFile.Close();
        }
        public static void loadDatafromFile()
        {
            string line, path = "D:\\OOP\\week6\\coffeeshop.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');

                        string name = filedata[0];
                        string type = filedata[1];
                        float price = float.Parse(filedata[2]);
                        MenuItem m1 = new MenuItem(name, type, price);
                        AddIteminList(m1);
                    }
                }
                myFile.Close();
            }
        }
    }
}
