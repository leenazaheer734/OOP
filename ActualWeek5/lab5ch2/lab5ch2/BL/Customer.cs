using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab5ch2.BL
{
    
    class Customer
    {
        public MUser customer;
        static List<Product> custBought = new List<Product>();

        public Customer (MUser u1)
        {
            this.customer = u1;
        }
        public List<Product> getproducts()
        {
            return custBought;
        }

    }
}
