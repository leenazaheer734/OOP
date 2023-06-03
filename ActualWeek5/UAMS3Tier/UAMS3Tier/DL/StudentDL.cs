using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;

namespace UAMS3Tier.DL
{
    class StudentDL
    {
        public static List<Student> allStudents = new List<Student>();
        public static List<Student> sortedbymerit = new List<Student>();
        public static void AddStudentinList(Student s)
        {
            allStudents.Add(s);
        }
        public static Student studentexists(string name)
        {
            foreach (Student s in allStudents)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Student> SortStudents()
        {
            foreach (Student s in allStudents)
            {
                s.calculateMerit();
            }
            sortedbymerit = allStudents.OrderByDescending(o => o.getmerit()).ToList();
            return sortedbymerit;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProg d in s.preferences)
                {
                    if (d.getSeat() > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        int seats = d.getSeat();
                        seats--;
                        d.setSeats(seats);
                        break;
                    }
                }
            }
        }
    }
}
