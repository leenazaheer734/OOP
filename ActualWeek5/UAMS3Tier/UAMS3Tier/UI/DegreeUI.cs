using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;
using UAMS3Tier.DL;

namespace UAMS3Tier.UI
{
    class DegreeUI
    {
        public static DegreeProg AddDegreeProgram()
        {
            Console.Write("  Enter name of Degree: ");
            string degName = Console.ReadLine();
            Console.Write("  Enter duration of Degree: ");
            int degDuration = int.Parse(Console.ReadLine());
            Console.Write("  Enter no. of seats available: ");
            int seats = int.Parse(Console.ReadLine());
            Console.WriteLine();
            DegreeProg degree = new DegreeProg(degName, degDuration, seats);

            Console.Write("  How many subjects you want to enter: ");
            int noofSubs = int.Parse(Console.ReadLine());
            for (int i = 0; i < noofSubs; i++)
            {
                if (degree.AddSubject(SubjectUI.takeInputForSubject()) == true)
                {
                    Console.WriteLine(" Subject added in Degree");
                }
                else
                {
                    Console.WriteLine("  credit hour limit exceeded");
                }

            }
            return degree;
        }
        public static void AllPrograms()
        {
            Console.WriteLine("----------ALL DEGREES AVAILABLE-------");
            for (int i = 0; i < DegreeDL.getallDegrees().Count; i++)
            {
                Console.WriteLine("  " + DegreeDL.getallDegrees()[i].title);
            }
        }
    }
}
