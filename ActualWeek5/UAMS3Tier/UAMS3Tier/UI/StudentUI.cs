using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;
using UAMS3Tier.DL;

namespace UAMS3Tier.UI
{
    class StudentUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("   ^^^^^^^^^^     UAMS     ^^^^^^^^^^");
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
        }
        public static string MainMenu()
        {
            Console.WriteLine("   1. Add  Student. ");
            Console.WriteLine("   2. Add Degree Program . ");
            Console.WriteLine("   3. Generate Merit. ");
            Console.WriteLine("   4. View Registered Students. ");
            Console.WriteLine("   5. View Students Of Specific program. ");
            Console.WriteLine("   6. Register Subject For Specific Student.");
            Console.WriteLine("   7. Calculate Fees For All Registered Students.");
            Console.WriteLine("   8. Exit.");
            Console.WriteLine();
            Console.Write(" Enter an option: ");
            string option = Console.ReadLine();
            return option;
        }
        public static Student AddStudent()
        {
            if (DegreeDL.getallDegrees().Count > 0)
            {
                Console.Write("  Enter name of Student: ");
                string stuName = Console.ReadLine();
                Console.Write("  Enter Student Age: ");
                int stuAge = int.Parse(Console.ReadLine());
                Console.Write("  Enter Student's Fsc marks: ");
                float fscM = float.Parse(Console.ReadLine());
                Console.Write("  Enter Student's ecat marks: ");
                float ecatM = float.Parse(Console.ReadLine());

                DegreeUI.AllPrograms();

                Console.Write("  How many preferences you want to enter: ");
                int i = int.Parse(Console.ReadLine());
                List<DegreeProg> pref = new List<DegreeProg>();
                for (int x = 0; x < i; x++)
                {
                    bool flag = false;
                    Console.Write(" " + i + ". Preference: ");
                    string title = Console.ReadLine();
                    foreach (DegreeProg d in DegreeDL.getallDegrees())
                    {
                        if (title == d.title && !(pref.Contains(d)))
                        {
                            pref.Add(d);
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("  Enter valid degree program name");
                        x--;
                    }
                }
                Student s = new Student(stuName, stuAge, fscM, ecatM, pref);
                return s;
            }
            else
            {
                Console.WriteLine("  No degrees offered!");
                return null;
            }
        }
        public static void printStudents()
        {
            foreach (Student s in StudentDL.sortedbymerit)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.getDegreeName());
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");
                }
            }
        }
        public static void ViewRegStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.sortedbymerit)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("  Students in " + degName + " are:");
            Console.WriteLine();
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.sortedbymerit)
            {
                if (s.regDegree != null && s.regDegree.title == degName)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        public static void showgeneratedfees()
        {
            Console.WriteLine("\tName\tRegDegree\tFees");
            foreach (Student s in StudentDL.sortedbymerit)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine("\t" + s.name + "\t" + s.regDegree.title + "\t\t" + s.calcculateFee());
                }
            }
        }
    }
}
