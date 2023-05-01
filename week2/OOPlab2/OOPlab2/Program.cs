using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOPlab2.BL;
using OOPlab2.sign;

namespace OOPlab2
{
    class Program
    {
        class student
        {
            public string sName;
            public int srollNo;
            public float cGPA;
        }
        static void Main(string[] args)
        {
            //Task2();
            //Task3();
            //Task4();
            //SMStask5();
            //Task6();
            Task7();
           // Console.ReadKey();
        }
        static void Task2()
        {
            student s1 = new student();
            s1.sName = "Leena";
            s1.srollNo = 72;
            s1.cGPA = 3.94F;
            Console.WriteLine("Name is {0}, ROLL no. is {1} , CGPA is {2} ", s1.sName, s1.srollNo, s1.cGPA);
        }
        static void Task3()
        {
            student s1 = new student();
            s1.sName = "Leena";
            s1.srollNo = 72;
            s1.cGPA = 3.94F;
            Console.WriteLine("Name is {0}, ROLL no. is {1} , CGPA is {2} ", s1.sName, s1.srollNo, s1.cGPA);

            student s2 = new student();
            s2.sName = "Noor";
            s2.srollNo = 8;
            s2.cGPA = 3.65F;
            Console.WriteLine("Name is {0}, ROLL no. is {1} , CGPA is {2} ", s2.sName, s2.srollNo, s2.cGPA);
        }
        static void Task4()
        {
            student s1 = new student();
            Console.Write("Enter your name: ");
            s1.sName = Console.ReadLine();
            Console.Write("Enter your roll no: ");
            s1.srollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter your cgpa: ");
            s1.cGPA = float.Parse(Console.ReadLine());

            Console.WriteLine("Your name is {0}, ROLL no. is {1} , CGPA is {2} ", s1.sName, s1.srollNo, s1.cGPA);
        }
       
        static void SMStask5()
        {
            students[] s = new students[10];
            int count = 0;
            string option;
            do
            {
                option = SmsMenu();
                if (option == "1")
                {
                    s[count] = AddStudents();
                    count++;
                }
                else if (option == "2")
                {
                    ViewAll(count, s);
                }
                else if (option == "3")
                {
                    TopStudents(count, s);
                }
                else if((option != "1") && (option != "2") && (option != "3") && (option != "4"))
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (option == "4")
                {
                    break;
                }
            }
            while (option != "4");
        }
        static string SmsMenu()
        {
            string option = "";
            Console.Clear();
            Console.WriteLine("-------------MENU--------------");
            Console.WriteLine("Press 1 to add a student.");
            Console.WriteLine("Press 2 to view all students.");
            Console.WriteLine("Press 3 to see top students.");
            Console.Write("Enter your choice..... ");
            option = Console.ReadLine();
            return option;
        }
        static students AddStudents()
        {
            students s1 = new students();
            Console.Clear();
            Console.Write("Enter name of student: ");
            s1.Name = Console.ReadLine();
            Console.Write("Enter student's roll no: ");
            s1.rollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter student's cgpa: ");
            s1.Cgpa = float.Parse(Console.ReadLine());
            Console.Write("Is student hostelite(y / n): ");
            s1.ishostelite = char.Parse(Console.ReadLine());
            Console.Write("Enter name of department: ");
            s1.department = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Student is added!");
            Console.ReadKey();
            return s1;
        }
        static void ViewAll(int count, students[] s)
        {
            Console.Clear();
            if (count != 0)
            {
                Console.WriteLine("Following is list of all students: ");
                Console.WriteLine();
                Console.WriteLine("Name" + "\t" + "rollNo" + "\t" + "Cgpa" + "\t" + "hostelite" + "\t" + "department");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(s[i].Name + "\t" + s[i].rollNo + "\t" + s[i].Cgpa + "\t" + s[i].ishostelite + "\t\t" + s[i].department);
                }
            }
            else
            {
                Console.WriteLine("no students ");
            }
            Console.ReadKey();
        }
        static void TopStudents(int count, students[] s)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("no students ");
            }
            else if(count == 1)
            {
                ViewAll(count, s);
            }
            else if (count == 2)
            {
                int index;
                for (int i = 0; i < 2; i++)
                {
                    index = largest(count, i, s);
                    students temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                ViewAll(2, s);
            }
            else if(count >= 3)
            {
                int index;
                for (int i = 0; i < 3; i++)
                {
                    index = largest(count, i, s);
                    students temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                ViewAll(3, s);
            }
            Console.ReadKey();
        }
        static int largest(int end, int start, students[] s)
        {
            int index = start;
            float largest = s[start].Cgpa;
            for(int i = start; i < end; i++)
            {
                if (largest < s[i].Cgpa)
                {
                    largest = s[i].Cgpa;
                    index = i;
                }
            }
            return index;
        }
        
        static void Task6()
        {
            products[] p = new products[10];
            int count = 0;
            string option;
            do
            {
                option = ProductMenu();
                if (option == "1")
                {
                    p[count] = AddProducts();
                    count++;
                }
                else if (option == "2")
                {
                    ViewProducts(count, p);
                }
                else if (option == "3")
                {
                    CalculateWorth(count, p);
                }
                else if ((option != "1") && (option != "2") && (option != "3") && (option != "4"))
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (option != "4");
        }
        static string ProductMenu()
        {
            string option = "";
            Console.Clear();
            Console.WriteLine("-------------MENU--------------");
            Console.WriteLine("Press 1 to add a product.");
            Console.WriteLine("Press 2 to view all products.");
            Console.WriteLine("Press 3 to see total store worth.");
            Console.Write("Enter your choice..... ");
            option = Console.ReadLine();
            return option;
        }
        static products AddProducts()
        {
            products p1 = new products();
            Console.Clear();

            Console.Write("Enter ID of Product: ");
            p1.pID = int.Parse(Console.ReadLine());
            Console.Write("Enter name of Product: ");
            p1.pName = Console.ReadLine();
            Console.Write("Enter cost price of product: ");
            p1.pPrice = float.Parse(Console.ReadLine());
            Console.Write("Enter catagory of product: ");
            p1.pCatagory = Console.ReadLine();
            Console.Write("Enter name of brand: ");
            p1.pBrand = Console.ReadLine();
            Console.Write("Enter country of manufacturing of product: ");
            p1.pCountry = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Product is added!");
            Console.ReadKey();
            return p1;
        }
        static void ViewProducts(int count, products[] p)
        {
            Console.Clear();
            if (count != 0)
            {
                Console.WriteLine("Following is list of all students: ");
                Console.WriteLine();
                Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Price" + "\t" + "Catagory" + "\t" + "Brand" + "\t" + "Country");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(p[i].pID + "\t" + p[i].pName + "\t" + p[i].pPrice + "\t" + p[i].pCatagory + "\t" + p[i].pBrand + "\t\t" + p[i].pCountry);
                }
            }
            else
            {
                Console.WriteLine("no products ");
            }
            Console.ReadKey();
        }
        static void CalculateWorth(int count, products[] p)
        {
            Console.Clear();
            if (count != 0)
            {
                float sum = 0;
                Console.WriteLine();
                Console.Write("Total store worth is: ");
                for (int i = 0; i < count; i++)
                {
                    sum = sum + p[i].pPrice;
                }
                Console.Write(sum);
            }
            else
            {
                Console.Write(" Total store worth is: 0");
            }
            Console.ReadKey();
        }

        static void Task7()
        {
            string path = "D:\\OOP\\week2\\textfile.txt";
            List<People> p1 = new List<People>();
            string option;
            Readdata(path, p1);
            do
            {
                Console.Clear();
                option = SignMenu();
                Console.Clear();
                if (option == "1")
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string pass = Console.ReadLine();
                    Signin(name, pass, p1);
                }
                else if (option == "2")
                {
                    p1.Add(SignUpMenu());
                    SignUp(path, p1, p1.Count-1);
                }
                if (option == "4")
                {
                    Console.Clear();
                    for (int i = 0; i < p1.Count; i++)
                    {
                        Console.WriteLine(p1[i].username + "," + p1[i].password);
                    }
                    Console.ReadKey();
                }
            }
            while (option != "3");
        }
        static void SignUp(string path, List<People> p1, int usercount)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(p1[usercount].username + "," + p1[usercount].password + ",");
            file.Flush();
            file.Close();
        }
        static string SignMenu()
        {
            string option;
            Console.WriteLine(" 1. SignIn");
            Console.WriteLine(" 2. SignUp");
            Console.WriteLine(" Enter Option..");
            option = Console.ReadLine();
            return option;
        }
        static People SignUpMenu()
        {
            People p2 = new People();
            Console.Write("Enter name: ");
            p2.username = Console.ReadLine();
            Console.Write("Enter password: ");
            p2.password = Console.ReadLine();
            return p2;
        }
        static void Signin(string name, string pass, List<People> p1)
        {
            bool flag = false;
            for (int i = 0; i < p1.Count; i++)
            {
                if (name == p1[i].username && pass == p1[i].password)
                {
                    Console.WriteLine("  Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("  INValid User  ");
            }
            Console.ReadKey();
        }
        static void Readdata(string path,List<People> p1)
        {

            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);

                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    People p = new People();
                    p.username = Parsedata(line, 1);
                    p.password = Parsedata(line, 2);
                    p1.Add(p);
                }

                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not found!!");
                Console.ReadKey();
            }
        }
        static string Parsedata(string line, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item = item + line[x];
                }
            }
            return item;
        }
    }
}
 