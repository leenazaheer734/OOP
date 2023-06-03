using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch2.BL;

namespace lab5ch2.DL
{
    class CustDL
    {
        public static void addInCart(Product p , Customer c)
        {
            c.getproducts().Add(p);
        }
        public static float showInvoice(Customer c)
        {
            ProdDL.CalculateTax();
            float bill = 0;
            foreach (Product pro in c.getproducts())
            {
                bill = bill + (pro.price + pro.tax);
            }
            return bill;
        }
        public static float showallTax(Customer c)
        {
            ProdDL.CalculateTax();
            float bill = 0;
            foreach (Product pro in c.getproducts())
            {
                bill = bill +  pro.tax;
            }
            return bill;
        }
        public static float showWithoutTax(Customer c)
        {
            ProdDL.CalculateTax();
            float bill = 0;
            foreach (Product pro in c.getproducts())
            {
                bill = bill + (pro.price );
            }
            return bill;
        }
    }
}
