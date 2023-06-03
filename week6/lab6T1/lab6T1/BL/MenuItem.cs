using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6T1.BL
{
    class MenuItem
    {
        public string name;
        public string type;
        public float price;
        public MenuItem(string name, string type, float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public static bool CheckIteminMenu(string name)
        {
            foreach (MenuItem mi in CoffeeShop.items)
            {
                if (mi.name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
