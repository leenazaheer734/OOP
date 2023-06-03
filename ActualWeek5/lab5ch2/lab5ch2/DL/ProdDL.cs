using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch2.BL;
using lab5ch2.UI;

namespace lab5ch2.DL
{
    class ProdDL
    {
        static List<Product> products = new List<Product>();
        public static void AddProduct(Product p)
        {
            products.Add(p);
        }
        public static void viewProducts()
        {
            foreach (Product p in products)
            {
                StoreUI.showproduct(p);
            }
        }
        public static Product CostlyProduct()
        {
            float largest = products[0].price;
            int index = 0;
            for (int i = 1; i < products.Count; i++)
            {
                if (largest < products[i].price)
                {
                    largest = products[i].price;
                    index = i;
                }
            }
            return products[index];
        }
        public static void ProductToOrder()
        {
            foreach (Product p in products)
            {
                if(p.quantity < p.threshold)
                {
                    StoreUI.showproduct(p);
                }
            }
        }
        public static void CalculateTax()
        {
            foreach (Product p in products)
            {
                if (p.catagory.ToLower() == "grocery")
                {
                    p.tax = (p.price * 0.1F);
                }
                else if (p.catagory.ToLower() == "fruit")
                {
                    p.tax = (p.price * 0.05F);
                }
                else
                {
                    p.tax = (p.price * 0.15F);
                }
            }
        }
        public static void viewTax()
        {
            foreach (Product p in products)
            {
                StoreUI.showtax(p);
            }
        }
        public static bool isproductPresent(string n)
        {
            foreach (Product p in products)
            {
                if (p.name == n && p.quantity > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static Product findProduct(string n)
        {
            foreach (Product p in products)
            {
                if (p.name == n && p.quantity > 0)
                {
                    return p;
                }
            }
            return null;
        }
        public static void removeProduct(Product product)
        {
            int index = 0;
            foreach(Product p in products)
            {
                if (p.name == product.name)
                {
                    if(p.quantity > 0)
                    {
                        p.quantity = p.quantity - 1;
                    }
                    if(p.quantity == 0)
                    {
                        products.RemoveAt(index);
                    }
                }
                index++;
            }
        }
    }
}
