using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5tasks.BL;

namespace lab5tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();   
            //Problem2();
            //Problem3();
            Console.ReadKey();
        }
        static void Problem1()
        {
            Console.WriteLine("Enter student's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student's roll number: ");
            int rollno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student's cGPA: ");
            float cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter student's matric Marks: ");
            int maticMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student's Fsc Marks: ");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student's Ecat Marks: ");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student's Home Town: ");
            string homeTown = Console.ReadLine();
            Console.WriteLine("Is student hostellite? (true/false)");
            bool isHostelite = bool.Parse(Console.ReadLine());
            Console.WriteLine("Is student taking scholarship? (true/false)");
            bool istakingScholarship = bool.Parse(Console.ReadLine());
            Console.WriteLine();

            Student stu = new Student(name, rollno, cgpa, maticMarks, fscMarks, ecatMarks, homeTown, isHostelite, istakingScholarship);

            float meritPercentage = stu.CalculateMerit();
            Console.WriteLine("Student's merit is: " + meritPercentage);

            if (isHostelite == true && istakingScholarship == false)
            {
                bool isEligible = stu.IsEligibleforScholarship(meritPercentage);
                if (isEligible == true)
                {
                    Console.WriteLine("Student is eligible for scholarship");
                }
                else
                {
                    Console.WriteLine("Student is not eligible for scholarship");
                }
            }
            else
            {
                Console.WriteLine("Student is not eligible for scholarship");
            }
            Console.ReadKey();
        }

        static void Problem2()
        {
            Book book = new Book("rameen",1000,600);
            book.addChapter("intro");
            book.addChapter("ABC");
            book.addChapter("XYZ");

            Console.WriteLine("Name of chapter 2 is: " + book.getChapter(2));
            book.setBookMark(414);
            Console.WriteLine("Book mark is on page: " + book.getBookMark());
            book.setBookPrice(560);
            Console.WriteLine("Price of book is: " + book.getBookPrice());
        }

        static void Problem3()
        {
            Product p1 = new Product("apple", "fruit",56);
            Product p2 = new Product("sugar", "grocery", 89);
            Customer cust = new Customer("Ahmad", "lahore", "87878978");

            cust.addProduct(p1);
            cust.addProduct(p2);
            Console.WriteLine("-------------PRODUCTS BOUGHT------------- ");
            foreach (Product p in cust.getAllProduct())
            {
                Console.WriteLine(p.name + " : " + p.catagory + " : " + p.price);
            }

            Console.WriteLine("-------------TAX ON EACH PRODUCT------------- ");
            Console.WriteLine(" tax on product 1 is: " + p1.CalculateTax());
            Console.WriteLine(" tax on product 2 is: " + p2.CalculateTax());
        }
    }
}
