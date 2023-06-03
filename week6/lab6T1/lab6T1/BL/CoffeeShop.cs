using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6T1.DL;


namespace lab6T1.BL
{
    class CoffeeShop
    {
        public string name;
        public static List<MenuItem> items = new List<MenuItem>();
        public static List<string> orders = new List<string>();
        public CoffeeShop(string name)
        {
            this.name = name;
        }
       
    }
}
