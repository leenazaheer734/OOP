using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch1.BL;

namespace lab5ch1.UI
{
    class MenusUI
    {
        public static string Menu()
        {
            Console.Clear();
            Console.WriteLine( " ----------------------MENU---------------------");
            Console.WriteLine();
            Console.WriteLine(" 1. Make a Line");
            Console.WriteLine(" 2. Update Begin Point");
            Console.WriteLine(" 3. Update End Point");
            Console.WriteLine(" 4. Show the begin Point");
            Console.WriteLine(" 5. Show the end point");
            Console.WriteLine(" 6. Get the Length of the line");
            Console.WriteLine(" 7. Get the Gradient of the Line");
            Console.WriteLine(" 8. Find the distance of begin point from zero coordinates");
            Console.WriteLine(" 9. Find the distance of end point from zero coordinates");
            Console.WriteLine(" 10. Exit");
            Console.Write(" ENter option: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static MyLine Option1()
        {
            Console.Clear();
            Console.WriteLine(" ----------------------Mark Line---------------------");
            Console.WriteLine(" Enter coordinates of begin point:");
            Console.Write(" Enter x: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y1 = int.Parse(Console.ReadLine());
            MyPoint b = new MyPoint(x1, y1);

            Console.WriteLine(" Enter coordinates of end point:");
            Console.Write(" Enter x: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y2 = int.Parse(Console.ReadLine());
            MyPoint e = new MyPoint(x2, y2);

            MyLine l1 = new MyLine(b, e);
            Console.WriteLine("                Line Created");
            Console.WriteLine();
            Cont();
            return l1;
        }
        public static MyPoint Option2()
        {
            Console.Clear();
            Console.WriteLine(" ----------------------UPdate Begining POint---------------------");

            Console.WriteLine(" Enter new coordinates of begin point:");
            Console.Write(" Enter x: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y1 = int.Parse(Console.ReadLine());
            Cont();
            MyPoint b = new MyPoint(x1, y1);
            return b;
        }
        public static MyPoint Option3()
        {
            Console.Clear();
            Console.WriteLine(" ----------------------UPdate End POint---------------------");
            Console.WriteLine(" Enter new coordinates of end point:");
            Console.Write(" Enter x: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write(" Enter y: ");
            int y2 = int.Parse(Console.ReadLine());
            Cont();
            MyPoint e = new MyPoint(x2, y2);
            return e;
        }
        public static void ShowBeginPoint(int x, int y)
        {
            Console.Clear();
            Console.WriteLine(" ----------------------View Begning POiint---------------------");
            Console.WriteLine(" Coordintes of begin of line are :");
            Console.WriteLine("                  x  = " + x);
            Console.WriteLine("                  y  = " + y);
            Cont();
        }
        public static void ShowEndPoint(int x,int y)
        {
            Console.Clear();
            Console.WriteLine(" ----------------------View Begning POiint---------------------");
            Console.WriteLine(" Coordintes of End of line are :");
            Console.WriteLine("                  x  = " + x);
            Console.WriteLine("                  y  = " + y);
            Cont();
        }
        public static void  GetLengthofLine(double length)
        {
            Console.Clear();
            Console.WriteLine(" ----------------------Get Length of Line---------------------");
            Console.WriteLine();
            Console.WriteLine("                    Length of line is: "+ length);
            Console.WriteLine();
            Cont();
        }
        public static void GetGradientofLine(double gradient)
        {
            Console.Clear();
            Console.WriteLine(" ----------------------Get Length of Line---------------------");
            Console.WriteLine();
            Console.WriteLine("                     Gradient of line is: " + gradient);
            Console.WriteLine();
            Cont();
        }
        public static void Option8(double distance)
        {
            Console.Clear();
            Console.WriteLine(" -------------Distance of begining from zero--------------");
            Console.WriteLine();
            Console.WriteLine("            Distance of begining from zero is: " + distance);
            Console.WriteLine();
            Cont();
        }
        public static void Option9(double distance)
        {
            Console.Clear();
            Console.WriteLine(" ------------Distance of end point from zero--------------");
            Console.WriteLine();
            Console.WriteLine("          Distance of end point from zero is: " + distance);
            Console.WriteLine();
            Cont();
        }
        public static void Cont()
        {
            Console.WriteLine(" Press Any Key To Continue....");
        }
    }
}