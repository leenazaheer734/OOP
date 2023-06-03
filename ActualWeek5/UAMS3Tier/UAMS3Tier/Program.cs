using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;
using UAMS3Tier.DL;
using UAMS3Tier.UI;

namespace UAMS3Tier
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            while (option != "8")
            {
                StudentUI.Header();
                option = StudentUI.MainMenu();
                if (option == "1")
                {
                    StudentUI.Header();
                    Student s = StudentUI.AddStudent();
                    if (s != null)
                    {
                        StudentDL.AddStudentinList(s);
                    }
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    StudentUI.Header();
                    DegreeProg d = DegreeUI.AddDegreeProgram();
                    DegreeDL.AddDegreeinList(d);
                }
                else if (option == "3")
                {
                    StudentUI.Header();
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.SortStudents();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    StudentUI.Header();
                    StudentUI.ViewRegStudents();
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    StudentUI.Header();
                    Console.Write("Enter Degree Name: ");
                    string degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                    Console.ReadKey();
                }
                else if (option == "6")
                {
                    StudentUI.Header();
                    Console.Write("  Enter student name: ");
                    string name = Console.ReadLine();
                    Student stud = StudentDL.studentexists(name);
                    if (stud != null)
                    {
                        SubjectUI.viewSubjects(stud);
                        SubjectUI.regsubject(stud);
                    }

                    Console.ReadKey();
                }
                else if (option == "7")
                {
                    StudentUI.Header();
                    StudentUI.showgeneratedfees();
                    Console.ReadKey();
                }
                else if (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7" && option != "8")
                {
                    Console.WriteLine(" Invalid choice entered!");
                    Console.ReadKey();
                }
            }
        }
    }
}
