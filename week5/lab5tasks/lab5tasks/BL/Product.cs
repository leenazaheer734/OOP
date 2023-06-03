using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5tasks.BL
{
    class Product
    {
       public string name;
       public string catagory;
       public int price;
       
        public Product(string name, string catagory, int price)
        {
            this.name = name;
            this.catagory = catagory;
            this.price = price;
        }
       public float CalculateTax()
       {
            float tax;
            if (catagory == "fruit")
            {
                tax = (price * 10) / 100.0F;
            }
            else if (catagory == "grocery")
            {
                tax = (price * 15) / 100.0F;
            }
            else
            {
                tax = (price * 25) / 100.0F;
            }
            return tax;
       }
    }
}
