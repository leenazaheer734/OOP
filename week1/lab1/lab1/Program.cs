using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PracticeTasks();
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            //Task8();
            Task9();
            Console.ReadKey();
        }

        static void PracticeTasks()
        {
            Console.WriteLine("Hello World!!");
            Console.WriteLine("Hello World!!");

            int number = 8;
            Console.Write("The number is:  " + number);

            string line = "i am leena";
            Console.WriteLine("Hi! ");
            Console.WriteLine(line);

        }

        static void Task1()
        {
            int marks;
            Console.Write("Enter marks: ");
            marks = int.Parse(Console.ReadLine());

            if (marks > 50)
            {
                Console.WriteLine("You are Pass!");
            }
            else
            {
                Console.WriteLine("You are Fail!!!!");
            }
        }


        static void Task2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Welcome to OOP Lab!");
            }

            int number;
            int sum = 0;
            Console.Write("Enter number : ");
            number = int.Parse(Console.ReadLine());
            while (number != -1)
            {
                sum = sum + number;
                Console.Write("Enter number: ");
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Sum is: {0} ", sum);


            int number1;
            int sum1 = 0;
            do                             //using do while loop
            {
                Console.Write("Enter number : ");
                number1 = int.Parse(Console.ReadLine());
                sum1 = sum1 + number1;
            }
            while (number1 != -1);
            sum1 = sum1 + 1;
            Console.WriteLine("Sum is: {0} ", sum1);
        }

        static void Task3()
        {
            int[] numbers = new int[3];

            for (int index = 0; index < 3; index++)
            {
                Console.Write("Enter number: ");
                numbers[index] = int.Parse(Console.ReadLine());
            }
            int temp = numbers[0];

            for (int x = 1; x < 3; x++)
            {
                if (numbers[x] > temp)
                    temp = numbers[x];
            }
            Console.WriteLine("Largest number is: " + temp);
        }

        static void Task4()
        {
            float age, Machine_price, toyPrice;

            Console.Write("Enter age of lily: ");
            age = float.Parse((Console.ReadLine()));

            Console.Write("Enter price of each unit toy: ");
            toyPrice = float.Parse((Console.ReadLine()));

            Console.Write("Enter cost of machine: ");
            Machine_price = float.Parse((Console.ReadLine()));

            float saved_money = 0, increment = 10, even_count = 0;

            for (int i = 2; i <= age; i = i + 2)   /*for even Birthdays*/
            {
                saved_money = saved_money + increment;
                increment = increment + 10;
                even_count++;
            }

            int odd_count = 0;                      /*for odd birthadys*/
            for (int i = 1; i <= age; i = i + 2)
            {
                odd_count++;
            }


            toyPrice = toyPrice * odd_count;
            float total_gift = toyPrice + (saved_money - even_count);

            if (Machine_price <= total_gift)
            {
                Console.WriteLine("You can buy Washing Machine!" + total_gift);
            }
            else
            {
                Console.WriteLine("You can't buy Washing Machine!" + total_gift);
            }
        }

        static int addNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        static void Task5()
        {

            int number1, number2, output;

            Console.Write("Enter first number: ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            number2 = int.Parse(Console.ReadLine());

            output = addNumbers(number1, number2);
            Console.WriteLine("The sum of two numbers is: " + output);
        }

        static void Task6()
        {
            string path = "D:\\OOP\\week1\\data.txt";
            if(File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not found!!");
            }
        }

        static void Task7()
        {
            string path = "D:\\OOP\\week1\\data.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine("hello");
            myFile.Flush();
            myFile.Close();
        }

        static void Task8()
        {
            string path = "D:\\OOP\\week1\\textfile.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            string option;
            do
            {
                Readdata(path, names, passwords);
                Console.Clear();
                option = SignMenu();
                Console.Clear();
                if (option == "1")
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string pass = Console.ReadLine();
                    Signin(name, pass, names, passwords);
                }
                else if (option == "2")
                {
                    Console.Write("Enter new name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new password: ");
                    string pass = Console.ReadLine();
                    SignUp(path, name, pass);
                }
            }
            while (option != "4");
        }

        static void SignUp(string path, string name, string pass)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + pass);
            file.Flush();
            file.Close();
        }
        
        static string Parsedata(string line, int field)
        {
            int commaCount = 1;
            string item = "";
            for(int x = 0; x < line.Length; x++)
            {
                if(line[x] == ',')
                {
                    commaCount++;
                }
                else if(commaCount == field)
                {
                    item = item + line[x];
                }
            }
            return item;
        }

        static string SignMenu()
        {
            string option;
            Console.WriteLine("--------MENU-------");
            Console.WriteLine(" 1. SignIn");
            Console.WriteLine(" 2. SignUp");
            Console.WriteLine(" Enter Option..");
            option = Console.ReadLine();
            return option;
        }

        static void Signin(string name, string pass, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int i=0; i<5; i++)
            {
                if (name == names[i] && pass == passwords[i])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("INValid User  ");
            }
            Console.ReadKey();
        }

        static void Readdata(string path, string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    names[x] = Parsedata(line, 1);
                    passwords[x] = Parsedata(line, 2);
                    x++;
                    if( x>= 5)
                    {
                        break;
                    }
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not found!!");
            }
            Console.ReadKey();
        }


        static void Task9()
        {
            int orders, leastPrice, arrSize=0;
            string[] people = new string[10]; 

            Console.WriteLine("Enter least orders: ");
            orders = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter least price: ");
            leastPrice = int.Parse(Console.ReadLine());
            arrSize = Checkpeople(people,leastPrice, orders, arrSize);
            for(int i = 0 ; i < arrSize; i++)
            {
                Console.WriteLine(" ' " + people[i] + " ' " );
            }
            Console.ReadKey();
        }

        static int Checkpeople(string[] people,int leastPrice,int orders, int arrSize)
        {
            int x = 0;
            string temp_name;
            int temp_price, temp_orders;
            int counter = 0;

            string path = "D:\\OOP\\week1\\pizzaData.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    temp_name = Parseinfo(line, 1, false);
                    temp_orders = int.Parse(Parseinfo(line, 2, false));

                    for(int i = 1; i <= temp_orders; i++)
                    {
                        temp_price = int.Parse(Parseinfo(line, i, true));
                        if(temp_price >= leastPrice)
                        {
                            counter++;
                        }
                    }
                    if(counter >= orders)
                    {
                        people[arrSize] = temp_name;
                        arrSize++;
                    }
                    counter = 0;
                    x++;
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not found!!");
            }
            return arrSize;
        }
        static string Parseinfo(string line, int field, bool prices)
        {
            string result = "";
            int spaceCount = 0;
            int commaCount = 1;

            for(int i = 0; i<line.Length ; i++)
            {
                if(line[i] == ' ' && prices == false)
                {
                    spaceCount++;
                }
                else if (field == 1 && line[i] != ' ' && spaceCount == 0 && prices == false)
                {
                    result = result + line[i];
                }

                else if (field == 2 && line[i] != ' ' && spaceCount==1 && prices == false)
                { 
                    result = result + line[i];
                }

                if(line[i] == '[' && prices == true)
                {
                    int n = i;
                    while(line[n] != ']')
                    {
                        if(line[n+1] == ',' || line[n+1] == ']')
                        {
                            commaCount++;
                        }
                        if (line[n+1] != ',' && commaCount == field)
                        {
                            result = result + line[n+1];
                        }
                        n++;
                    }
                }
            }
            return result;
        }
    }
}
