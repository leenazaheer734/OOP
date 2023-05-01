using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3Tasks.BL;
using Lab3Tasks.CL;
  
namespace Lab3Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //SelfTask1A();
            //SelfTask1B();
            //Task4();
            //Selftask2A();
            //Selftask2B();
            //CopyConstructor();
            //PrintList();
            //Clocktask();
            //Challenge1();
            Challenge2();
            Console.ReadKey();
        }

        static void Task1()
        {
            Students obj = new Students(); 
            Console.WriteLine(obj.sName);            //printing values of attributes without assigning them values     
            Console.WriteLine(obj.matricMarks);
            Console.WriteLine(obj.fscMarks);
            Console.WriteLine(obj.ecatMarks);
            Console.WriteLine(obj.aggregate);
        }

        static void Task2()
        {
            Students obj = new Students();         //creating a default constructor
        }

        static void Task3()
        {
            Students2 obj = new Students2();        //printing default value assigned to one of the attributes
            Console.WriteLine(obj.aggregate);
        }

        static void SelfTask1A()
        {
            Students1 obj = new Students1();
            Console.WriteLine("Name: " + obj.sName);                    //printing values of attributes when assigning them values     
            Console.WriteLine("Matric Marks: " + obj.matricMarks);
            Console.WriteLine("Fsc Marks: " + obj.fscMarks);
            Console.WriteLine("Ecat Marks: " + obj.ecatMarks);
            Console.WriteLine("Aggregate: " + obj.aggregate);
        }

        static void SelfTask1B()
        {
            Students1 obj1 = new Students1();
            Console.WriteLine("Name: " + obj1.sName);                    //printing values of attributes by different objects
            Console.WriteLine("Matric Marks: " + obj1.matricMarks);
            Console.WriteLine("Fsc Marks: " + obj1.fscMarks);
            Console.WriteLine("Ecat Marks: " + obj1.ecatMarks);
            Console.WriteLine("Aggregate: " + obj1.aggregate);
            Console.WriteLine();
            Students1 obj2 = new Students1();
            Console.WriteLine("Name2: " + obj2.sName);                   
            Console.WriteLine("Matric Marks2: " + obj2.matricMarks);
            Console.WriteLine("Fsc Marks2: " + obj2.fscMarks);
            Console.WriteLine("Ecat Marks2: " + obj2.ecatMarks);
            Console.WriteLine("Aggregate2: " + obj2.aggregate);
        }

        static void Task4()
        {
            Students3 obj = new Students3("Leena");                 //parameterized constructor
            Console.WriteLine("Name: " + obj.sName);
            Students3 obj1 = new Students3("Noor");                 
            Console.WriteLine("Name: " + obj1.sName);
        }

         static void Selftask2A()
         {
            Students3 obj = new Students3("Leena", 1055, 1047, 155, 3.9F);                 //parameterized constructor
            Console.WriteLine("Name: " + obj.sName);
            Console.WriteLine("Matric Marks: " + obj.matricMarks);
            Console.WriteLine("Fsc Marks: " + obj.fscMarks);
            Console.WriteLine("Ecat Marks: " + obj.ecatMarks);
            Console.WriteLine("Aggregate: " + obj.aggregate);
         }
         static void Selftask2B()
         {
            Students3 obj = new Students3("Leena", 1055, 1047, 155, 3.9F);   
            
            Console.WriteLine("Name: " + obj.sName);
            Console.WriteLine("Matric Marks: " + obj.matricMarks);
            Console.WriteLine("Fsc Marks: " + obj.fscMarks);
            Console.WriteLine("Ecat Marks: " + obj.ecatMarks);
            Console.WriteLine("Aggregate: " + obj.aggregate);

            Console.WriteLine();

            Students3 obj1 = new Students3("Noor", 1049, 1055, 165, 3.6F);

            Console.WriteLine("Name: " + obj1.sName);                               //printing values of attributes by different objects
            Console.WriteLine("Matric Marks: " + obj1.matricMarks);
            Console.WriteLine("Fsc Marks: " + obj1.fscMarks);
            Console.WriteLine("Ecat Marks: " + obj1.ecatMarks);
            Console.WriteLine("Aggregate: " + obj1.aggregate);
         }

         static void CopyConstructor()
         {
            Students obj = new Students();
            Console.Write("Name: ");
            obj.sName = Console.ReadLine();
            Console.Write("Matric Marks: " );
            obj.matricMarks = float.Parse(Console.ReadLine());
            Console.Write("Fsc Marks: " );
            obj.fscMarks = float.Parse(Console.ReadLine());
            Console.Write("Ecat Marks: " );
            obj.ecatMarks = float.Parse(Console.ReadLine());
            Console.Write("Aggregate: " );
            obj.aggregate = float.Parse(Console.ReadLine());
            Console.WriteLine();

            Students3 stu = new Students3(obj);
            Console.WriteLine("Name: " + stu.sName);
            Console.WriteLine("Matric Marks: " + stu.matricMarks);
            Console.WriteLine("Fsc Marks: " + stu.fscMarks);
            Console.WriteLine("Ecat Marks: " + stu.ecatMarks);
            Console.WriteLine("Aggregate: " + stu.aggregate);
         }
         static void PrintList() 
         {
            List<int> numbers = new List<int>() { 3, 5, 7, 9, 11, 13, 15 };
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }
         }
       
         static void Clocktask()
         {
            // default constructor
            ClockType empty_time = new ClockType();
            Console.Write("Empty time: ");
            empty_time.printTime();

            // Parameterized constructor (one parameter)
            ClockType hour_time = new ClockType(8);
            Console.Write("Hour time: ");
            hour_time.printTime();

            // Parameterized constructor (two parameters)
            ClockType minute_time = new ClockType(8, 10);
            Console.Write("Minute time: ");
            minute_time.printTime();


            // Parameterized constructor (three parameters)
            ClockType full_time = new ClockType(8, 10, 10);
            Console.Write("Full time: ");
            full_time.printTime();


            full_time.Incrementsec();
            Console.Write("Full time (Increment Second): ");       // increment second.
            full_time.printTime();

            
            full_time.Incrementhour();
            Console.Write("Full time (Increment Hours): ");      // increment hours
            full_time.printTime();


            full_time.Incrementmin();
            Console.Write("Full time (Increment minutes): ");         // increment mintues
            full_time.printTime();


            bool flag = full_time.isEqual(9, 11, 11);              // chcek if equal
            Console.WriteLine("Flag: " + flag);

            ClockType cmp = new ClockType(10, 12, 1);
            flag = full_time.isEqual(cmp);                    // chcek if equal with object
            Console.WriteLine("Object Flag: "+ flag);
            
         }
        static void Challenge1()
        {
            ClockTask c1 = new ClockTask(5,35,40);
           
            int t_seconds = c1.CalculateElapsedSec();
            Console.WriteLine("Elapsed Time in Seconds: " + t_seconds);         //elapsed time in seconds
            ClockTask c2 = new ClockTask(t_seconds);
            Console.WriteLine("Elapsed Time in hr:m:s: " + c2.hours + ":" + c2.minutes + ":" + c2.seconds);    //elapsed time in hour:min:sec format

            int remaining_sec = c1.CalculateRemainingSec();
            Console.WriteLine("Reamining Time in Seconds: " + remaining_sec);      //remaining time in seconds
            ClockTask c3 = new ClockTask(remaining_sec);
            Console.WriteLine("Remaining Time in hr:m:s: " + c3.hours + ":" + c3.minutes + ":" + c3.seconds);    //remaining time in hour:min:sec format

            ClockTask c4 = new ClockTask(24,0,0);
            ClockTask c5 = new ClockTask(2,10,30);
            //calculating difference between two times of clock
            c4.Timedifference(c5);                                      
            Console.WriteLine(" Difference in Time in hr:m:s  : " + c4.hours + ":" + c4.minutes + ":" + c4.seconds);
        }
        static void Challenge2()
        {
            List<DeptStore> p = new List<DeptStore>();
            string option = "";

            while(option != "6")
            {
                option = Optionmenu();

                if (option == "1")
                {
                    DeptStore product = new DeptStore();
                    product = Addproduct();
                    p.Add(product);
                    Console.WriteLine(" Product has been added!");
                }

                else if(option == "2")
                {
                    DeptStore view = new DeptStore(); 
                    view.Viewproducts(p);
                }

                else if (option == "3")
                {
                    DeptStore LargestP = new DeptStore();
                    LargestP.CostlyProduct(p);
                }

                else if (option == "4")
                {
                    DeptStore tax = new DeptStore();
                    tax.CalculateTax(p);
                }

                else if(option ==  "5")
                {
                    DeptStore tobeOrdered = new DeptStore();
                    tobeOrdered.ProductstobeOrdered(p);
                }

                Console.ReadKey();
            }
        } 
        static string Optionmenu()
        {
            Console.Clear();
            Console.WriteLine("          DEPARTMENTAL STORE   ");
            Console.WriteLine();
            Console.WriteLine("  1. Add product");
            Console.WriteLine("  2. View all products");
            Console.WriteLine("  3. Product with highest unit price");
            Console.WriteLine("  4. Sales tax of all products");
            Console.WriteLine("  5. Products to be ordered");
            Console.WriteLine("  6. Exit");
            string option = Console.ReadLine();
            return option;
        }
        static DeptStore Addproduct()
        {
            Console.Clear();
            DeptStore p1 = new DeptStore();

            Console.Write("  Enter name of product: ");
            p1.pName = Console.ReadLine();
            Console.Write("  Enter Catagory of product: ");
            p1.pCatagory = Console.ReadLine();
            Console.Write("  Enter cost Price of product: ");
            p1.pPrice = float.Parse(Console.ReadLine());
            Console.Write("  Enter Quantity of product: ");
            p1.pQuantity = int.Parse(Console.ReadLine());
            Console.Write("  Enter minimum Stock Quantity: ");
            p1.minStockQuantity = int.Parse(Console.ReadLine());

            return p1;
        }
    }
} 