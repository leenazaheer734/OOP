using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Tasks.BL
{
    class Students
    {
        public Students()
        {
            Console.WriteLine("This is a default constructor");            //default Constructor
        }
        public string sName;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
    class Students1
    {
        public Students1()
        {
            sName = "leena";
            matricMarks = 1055;
            fscMarks = 1047;
            aggregate = 3.94F;                                    //assigning unique value to all atribures
            ecatMarks = 135;
        }
        public string sName;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
    class Students2
    {
        public Students2()
        {
            aggregate = 3.94F;                            //assigning unique value to aggregate
        }
        public float aggregate;
    }
    class Students3
    {
        public Students3(string inputname)
        {                                                //assigning value to one attribute using parameterized constructor
            sName = inputname;
        }
        public Students3(string sName, float matricMarks, float fscMarks, float ecatMarks, float aggregate)
        {
            this.sName = sName;
            this.matricMarks = matricMarks;
            this.fscMarks = fscMarks;
            this.aggregate = aggregate;                          //assigning unique value to all atribures through parameter
            this.ecatMarks = ecatMarks;
        }
        public Students3(Students s)
        {
            sName = s.sName;
            matricMarks = s.matricMarks;
            fscMarks = s.fscMarks;
            aggregate = s.aggregate;             //assigning unique value to all atribures by object/copy constructor
            ecatMarks = s.ecatMarks;
        }

        public string sName;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
    class DeptStore
    {
        public string pName;
        public string pCatagory;
        public float pPrice;
        public int pQuantity;
        public int minStockQuantity;
        public float salesTax;
        public void Viewproducts(List<DeptStore> p)
        {
            Console.Clear();
            Console.WriteLine("         ALL PRODUCTS");
            Console.WriteLine();
            Console.WriteLine("  Name" + "\t\t" + "Catagory" + "\t" + "Price" + "\t" + "Quantity");
            foreach (DeptStore view in p)
            {
                Console.WriteLine("  " + view.pName + "\t" + view.pCatagory + "\t\t" + view.pPrice + "\t" + view.pQuantity);
            }
        }
        public void CostlyProduct(List<DeptStore> p)
        {
            float largest = p[0].pPrice;
            int index = 0;
            for(int i = 1; i < p.Count; i++)
            {
                if(largest < p[i].pPrice)
                {
                     largest = p[i].pPrice;
                    index = i;
                }
            }
            Console.Clear();
            Console.WriteLine("   Product with highest unit price is: ");
            Console.WriteLine();
            Console.WriteLine("  Name" + "\t\t" + "Catagory" + "\t" + "Price" + "\t" + "Quantity");
            Console.WriteLine("  " + p[index].pName + "\t" + p[index].pCatagory + "\t\t" + p[index].pPrice + "\t" + p[index].pQuantity);
        }
        public void ProductstobeOrdered(List<DeptStore> p)
        {
            Console.Clear();
            Console.WriteLine("   Products to be ordered are: ");
            Console.WriteLine();
            Console.WriteLine("  Name" + "\t\t" + "Catagory" + "\t" + "Price");
            for (int i=0; i<p.Count; i++)
            {
                if(p[i].pQuantity < p[i].minStockQuantity)
                {
                    
                    Console.WriteLine("  " + p[i].pName + "\t" + p[i].pCatagory + "\t\t" + p[i].pPrice);
                }
            }
        }
        public void CalculateTax(List<DeptStore> p)
        {
            foreach(DeptStore tax in p)
            {
                if(tax.pCatagory == "grocery")
                {
                    tax.salesTax = (tax.pPrice * 0.1F);
                }
                else if(tax.pCatagory == "fruits")
                {
                    tax.salesTax = (tax.pPrice * 0.05F);
                }
                else
                {
                    tax.salesTax = (tax.pPrice * 0.15F);
                }
            }
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                          Sales Tax");
            Console.WriteLine("  Name" + "\t\t" + "Catagory" + "\t" + "Price" + "\t" + "Sales Tax");
            for (int i =0; i < p.Count; i++)
            {
                Console.WriteLine("  " + p[i].pName + "\t\t" + p[i].pCatagory + "\t\t" + p[i].pPrice + "\t"+ p[i].salesTax);
            }
        }
    }
}
