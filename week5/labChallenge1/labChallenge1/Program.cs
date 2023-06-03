using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labChallenge1.BL;

namespace labChallenge1
{
    class Program
    {
        static List<Degree> allDegreesAvailable = new List<Degree>();
        static List<Student> allStudents = new List<Student>();
        static List<Student> sortedbymerit = new List<Student>();

        static void Main(string[] args)
        {
            string option = "";
            while(option != "8")
            {
                Header();
                option = MainMenu();
                if (option == "1")
                {
                    Header();
                    Student s = AddStudent();
                    if ( s != null)
                    {
                        AddStudentinList(s);
                    }
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    Header();
                    Degree d = AddDegreeProgram();
                    AddDegreeinList(d);
                }
                else if (option == "3")
                {
                    Header();
                    SortStudents();
                    giveAdmission(sortedbymerit);
                    printStudents();
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    Header();
                    ViewRegStudents();
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    Header();
                    Console.Write("Enter Degree Name: ");
                    string degName = Console.ReadLine();
                    viewStudentInDegree(degName);
                    Console.ReadKey();
                }
                else if (option == "6")
                {
                    Header();
                    Console.Write("  Enter student name: ");
                    string name = Console.ReadLine();
                    Student stud = studentexists(name, allStudents);
                    if(stud != null)
                    {
                        viewSubjects(stud);
                        regsubject(stud);
                    }
                    
                    Console.ReadKey();
                }
                else if (option == "7")
                {
                    Header();
                    showgeneratedfees();
                    Console.ReadKey();
                }
                else if (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7" && option != "8")
                {
                    Console.WriteLine(" Invalid choice entered!");
                    Console.ReadKey();
                }
            }
            
        }
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("   ^^^^^^^^^^     UAMS     ^^^^^^^^^^");
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
        }
        static string MainMenu()
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
        static Degree AddDegreeProgram()
        {
            Console.Write("  Enter name of Degree: ");
            string degName = Console.ReadLine();
            Console.Write("  Enter duration of Degree: ");
            int degDuration = int.Parse(Console.ReadLine());
            Console.Write("  Enter no. of seats available: ");
            int seats = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Degree degree = new Degree(degName, degDuration, seats);

            Console.Write("  How many subjects you want to enter: ");
            int noofSubs = int.Parse(Console.ReadLine());
            for(int i = 0; i<noofSubs; i++)
            {
                if(degree.AddSubject(takeInputForSubject()) == true)
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
        static Subject takeInputForSubject()
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
        static void AddDegreeinList(Degree d)
        {
           allDegreesAvailable.Add(d);
           Console.WriteLine("  "+ d.title + " degree is added");
           Console.ReadKey();
        }
        static Student AddStudent()
        {
            if (allDegreesAvailable.Count > 0)
            {
                Console.Write("  Enter name of Student: ");
                string stuName = Console.ReadLine();
                Console.Write("  Enter Student Age: ");
                int stuAge = int.Parse(Console.ReadLine());
                Console.Write("  Enter Student's Fsc marks: ");
                float fscM = float.Parse(Console.ReadLine());
                Console.Write("  Enter Student's ecat marks: ");
                float ecatM = float.Parse(Console.ReadLine());

                AllPrograms();

                Console.Write("  How many preferences you want to enter: ");
                int i = int.Parse(Console.ReadLine());
                List<Degree> pref = new List<Degree>();
                    for (int x = 0; x < i; x++)
                    {
                        bool flag = false;
                        Console.Write(" " + i + ". Preference: ");
                        string title = Console.ReadLine();
                        foreach (Degree d in allDegreesAvailable)
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
        static void AllPrograms()
        {
            Console.WriteLine("----------ALL DEGREES AVAILABLE-------");
            for(int i =0; i<allDegreesAvailable.Count; i++)
            {
                Console.WriteLine("  "+allDegreesAvailable[i].title);
            }
        }
        static void AddStudentinList(Student s)
        {
            allStudents.Add(s);
            Console.WriteLine("   A student is added");
        }
        static void SortStudents()
        {
            foreach (Student s in allStudents)
            {
                s.calculateMerit();
            }
            sortedbymerit = allStudents.OrderByDescending(o => o.getmerit()).ToList();
        }
        static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (Degree d in s.preferences)
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
        static void printStudents()
        {
            foreach (Student s in sortedbymerit)
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
        static void ViewRegStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in sortedbymerit)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("  Students in "+degName +" are:");
            Console.WriteLine();
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in sortedbymerit)
            {
                if (s.regDegree != null && s.regDegree.title == degName)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        static void regsubject(Student stud)
        {
            Console.Write("  Enter how many subjects u want to register: ");
            int times = int.Parse(Console.ReadLine());
            if(stud != null)
            {
                for (int i = 0; i < times; i++)
                {
                    Console.Write("  Enter subject Code: ");
                    string subjcode = Console.ReadLine();
                    bool flag = false;
                    
                    foreach(Subject sub in stud.regDegree.subjects)
                    {
                        if (sub.code == subjcode && !(stud.regSubjects.Contains(sub))) ;
                        stud.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                    if(flag == false)
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
        static Student studentexists(string name, List<Student> allStudents)
        {
            foreach (Student  s in allStudents)
            {
                if(name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        static void showgeneratedfees()
        {
            Console.WriteLine("\tName\tRegDegree\tFees");
            foreach(Student s in sortedbymerit)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine("\t" + s.name + "\t" + s.regDegree.title + "\t\t" + s.calcculateFee());
                }
            }
        }
        static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine( "Sub Code\tSub Type");
                foreach(Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
    
    }

}
