using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practicetask.BL;

namespace practicetask
{
    class Program
    {
        static void Main(string[] args)
        {
              //mainforDayScholar();
              mainforHostelite();
            Console.ReadKey();
        }
        static void mainforDayScholar()
        {
            DayScholar std = new DayScholar();
            std.Setname("Leena");
            std.SetbusNo(1);

            Console.WriteLine(std.Getname() + " is Allocated bus " + std.GetbusNo());
        }
        static void mainforHostelite()
        {
            Hostelite std = new Hostelite();
            std.Setname("Leena");
            std.SetRoomnumber(107);

            Console.WriteLine(std.Getname() + " is Alloted room " + std.GetRoomnumber());
        }
    }
}
