using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace signUpIn
{
    class Program
    {
        class People
        {
            public string username;
            public string password;
            public string role;
            public People(string username, string password, string role)
            {
                this.username = username;
                this.password = password;
                this.role = role;
            }
            public People(string username, string password)
            {
                this.username = username;
                this.password = password;
            }
            public bool isAdmin()
            {
                if (role == "Admin")
                {
                    return true;
                }
                return false;
            }
        }
        static void Main(string[] args)
        { 
            List<People> users = new List<People>();
            string path = "D:\\OOP\\week2\\textfile.txt";
            string option;
            bool flag = Readdata(path, users);
            if (flag == true)
            {
                do
                {
                    Console.Clear();
                    option = SignMenu();
                    Console.Clear();
                    if (option == "1")
                    {
                        People user = takeInputWithoutRole();
                        if (user != null)
                        {
                            user = signIn(user, users);
                            if (user == null)
                                Console.WriteLine("Invalid User");
                            else if (user.isAdmin())
                                Console.WriteLine("Admin Menu");
                            else
                                Console.WriteLine("User Menu");
                            Console.ReadKey();
                        }
                    }
                    else if (option == "2")
                    {
                        People u = takeInputWithRole();
                        if (u != null)
                        {
                            storeDataInFile(path, u);
                            storeDataInList(users, u);

                        }
                    }
                    if (option == "4")
                    {
                            Console.Clear();
                            for (int i = 0; i < users.Count; i++)
                            {
                                Console.WriteLine(users[i].username + "," + users[i].password + "," + users[i].role);
                            }
                            Console.ReadKey();
                    }
                }
                while (option != "3");
            }
            else
            {
                    Console.WriteLine("Data not found");
            }
        }

        static void storeDataInFile(string path, People user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.username + "," + user.password + "," + user.role);
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
           
        static People takeInputWithRole()
        {
             Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = Console.ReadLine();
        if (name != null && password != null && role != null)
        {
            People user = new People(name, password, role);
            return user;
        }
        return null;
        }

        static People takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                People user = new People(name, password);
                return user;
            }
                return null;
        }

        static People signIn(People user, List<People> users)
        {
            foreach (People storedUser in users)
            {
                if (user.username == storedUser.username && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }

        static bool Readdata(string path, List<People> users)
        {

            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);

                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    string username = Parsedata(line, 1);
                    string password = Parsedata(line, 2);
                    string role = Parsedata(line, 3);
                    People user = new People(username,password,role);
                    storeDataInList(users, user);
                }

                myFile.Close();
            }
            else
            {
                return false;
            }
            return true;
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
        static void storeDataInList(List<People> users, People u)
        {
            users.Add(u);
        }
        }
    }
