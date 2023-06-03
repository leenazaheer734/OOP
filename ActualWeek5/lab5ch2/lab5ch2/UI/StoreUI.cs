using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch2.BL;
using lab5ch2.DL;

namespace lab5ch2.UI
{
    class StoreUI
    {
        public static void Heading()
        {
            Console.Clear();
            Console.WriteLine(" ------------DePARTMENTAL  sTORE---------");
            Console.WriteLine();
        }
        public static void Cont()
        {
            Console.WriteLine();
            Console.WriteLine("  Press any Key to Continue...");
            Console.ReadKey();
        }
        public static string MainMenu()
        {
            Heading();
            Console.WriteLine( "  1. Sign In.");
            Console.WriteLine( "  2. Sign Up.");
            Console.WriteLine( "  3. Exit.");
            Console.Write( "  Enter your choice: ");
            string choice  = Console.ReadLine();
            return choice; 
        }
        public static MUser SignUp()
        {
            Console.Clear();
            Console.WriteLine(" ------------Sign UP---------");
            Console.WriteLine();
            Console.Write( "  Enter name: ");
            string name = Console.ReadLine();
            Console.Write( "  Enter password: ");
            string password = Console.ReadLine();
            Console.Write( "  Enter role(admin/customer): ");
            string role = Console.ReadLine();
            Console.WriteLine();

            MUser u = new MUser(name, password, role);
            return u;
        }
        public static MUser SignIn()
        {
            Console.Clear();
            Console.WriteLine(" ------------Sign In---------");
            Console.WriteLine();
            Console.Write("  Enter name: ");
            string name = Console.ReadLine();
            Console.Write("  Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            MUser u = new MUser(name, password);
            return u;
        }
        public static string AdminMenu()
        {
            Console.Clear();
            Console.WriteLine(" ------------ADmin Menu---------");
            Console.WriteLine();
            Console.WriteLine("  1. Add Product.");
            Console.WriteLine("  2. View All Products.");
            Console.WriteLine("  3. Find Product with Highest Unit Price.");
            Console.WriteLine("  4. View Sales Tax of All Products.");
            Console.WriteLine("  5. Products to be Ordered.");
            Console.WriteLine("  6. Exit.");
            Console.Write("  Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static Product AddProducts()
        {
            Product p1 = new Product();
            Console.Clear();
            Console.Clear();
            Console.WriteLine(" ----------------ADD PRODUCT-------------");
            Console.WriteLine();
            Console.Write("  Enter name of Product: ");
            p1.name = Console.ReadLine();
            Console.Write("  Enter catagory of product: ");
            p1.catagory = Console.ReadLine();
            Console.Write("  Enter cost price of product: ");
            p1.price = float.Parse(Console.ReadLine());
            Console.Write("  Enter quantity of product: ");
            p1.quantity = int.Parse(Console.ReadLine());
            Console.Write("  Enter threshold quantity of product: ");
            p1.threshold = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return p1;
        }
        public static void AdminOption2()
        {
            Console.Clear();
            Console.WriteLine(" ------------View All Products---------");
            Console.WriteLine();
            Console.WriteLine(" Following is list of all products: ");
            Console.WriteLine();
            Console.WriteLine(" Name\tPrice\tCatagory\tQuantity");
            ProdDL.viewProducts();
        }
        public static void showproduct(Product p)
        {
            Console.WriteLine(" "+p.name+"\t"+p.price+"\t"+p.catagory+"\t\t"+p.quantity);
        }
        public static void AdminOption3()
        {
            Console.Clear();
            Console.WriteLine(" ------------Product With Highest Price---------");
            Console.WriteLine();
            Console.WriteLine(" Following is product with highest price: ");
            Console.WriteLine();
            Console.WriteLine(" Name\tPrice\tCatagory\tQuantity ");
            Product p = ProdDL.CostlyProduct();
            Console.WriteLine("  " + p.name + "\t" + p.price + "\t" + p.catagory + "\t" + p.quantity);
        }
        public static void AdminOption4()
        {
            Console.Clear();
            Console.WriteLine(" ------------Sales Tax---------");
            Console.WriteLine();
            Console.WriteLine(" Following is list of products with tax: ");
            Console.WriteLine();
            Console.WriteLine(" Name\tPrice\tCatagory\tTax");
            ProdDL.viewTax();
        }
        public static void showtax(Product p)
        {
            Console.WriteLine(" " + p.name + "\t" + p.price + "\t" + p.catagory + "\t\t" + p.tax);
        }
        public static void AdminOption5()
        {
            Console.Clear();
            Console.WriteLine(" ------------Products to be ordered---------");
            Console.WriteLine();
            Console.WriteLine(" Following is list of products that are less than threshold quantity: ");
            Console.WriteLine();
            Console.WriteLine(" Name\tPrice\tCatagory\tQuantity");
            Product p = ProdDL.CostlyProduct();
            showproduct(p);
        }
        public static string CustomerMenu()
        {
            Console.Clear();
            Console.WriteLine(" ------------Customer Menu---------");
            Console.WriteLine();
            Console.WriteLine("  1. View all the products.");
            Console.WriteLine("  2. Buy Products.");
            Console.WriteLine("  3. Generate Invoice.");
            Console.WriteLine("  4. Exit.");
            Console.Write("  Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static void CustOption2(Customer c)
        {
            Console.Clear();
            Console.WriteLine(" ------------BuY PRoDucts---------");
            Console.WriteLine();
            Console.Write("  Enter how many products you want to buy: ");
            int i = int.Parse(Console.ReadLine());
            for(int x = 0; x < i; x++)
            {
                Console.Write("  Enter name of product: ");
                string name = Console.ReadLine();
                bool flag = ProdDL.isproductPresent(name);
                if(flag == true)
                {
                    Product buyp = ProdDL.findProduct(name);
                    CustDL.addInCart(buyp,c);
                    ProdDL.removeProduct(buyp);
                }
                else
                {
                    Console.WriteLine(" Product Not Found ");
                }
            }
        }
        public static void CustOption3(Customer c)
        {
            Console.Clear();
            Console.WriteLine(" ------------GeNerate InVoiCe---------");
            Console.WriteLine();
            Console.WriteLine("  Your bill without Tax: " + CustDL.showWithoutTax(c));
            Console.WriteLine("  Tax on bill is: " + CustDL.showallTax(c));
            Console.WriteLine("  Your bill is: " + CustDL.showInvoice(c));
        }
    
    }
}
