using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5tasks.BL
{
    class Customer
    {
        public string name;
        public string address;
        public string contact;
        List<Product> products = new List<Product>();

        public Customer(string name, string address, string contact)
        {
            this.name = name;
            this.address = address;
            this.contact = contact; 
        }
        public List<Product> getAllProduct()
        {
            return products;
        }
        public void addProduct(Product p)
        {
            products.Add(p);
        }
    }
}
