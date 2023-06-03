using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;
using UAMS3Tier.DL;


namespace UAMS3Tier.UI
{
    class SubjectUI
    {
        public static Subject takeInputForSubject()
        {
            Console.Write("  Enter Subject Code: ");
            string subCode = Console.ReadLine();
            Console.Write("  Enter Subject Type: ");
            string subType = Console.ReadLine();
            Console.Write("  Enter no. of credit hours: ");
            int credithours = int.Parse(Console.ReadLine());
            Console.Write("  Enter Subject Fees: ");
            float subFees = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Subject s = new Subject(subCode, subType, subFees, credithours);
            return s;
        }
        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach (Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
        public static void regsubject(Student stud)
        {
            Console.Write("  Enter how many subjects u want to register: ");
            int times = int.Parse(Console.ReadLine());
            if (stud != null)
            {
                for (int i = 0; i < times; i++)
                {
                    Console.Write("  Enter subject Code: ");
                    string subjcode = Console.ReadLine();
                    bool flag = false;

                    foreach (Subject sub in stud.regDegree.subjects)
                    {
                        if (sub.code == subjcode && !(stud.regSubjects.Contains(sub))) ;
                        stud.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("   The degree in which u applied does not offers this course!");
                        i--;
                    }
                }
            }
            else
            {
                Console.WriteLine("  Student does not exists.");
            }

        }
    }
}
