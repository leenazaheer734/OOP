using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lab5ch2.BL;

namespace lab5ch2.DL
{
    class MUserDL
    {
        static List<MUser> users = new List<MUser>();
        static List<Customer> customers = new List<Customer>();
        static string path = "textfile.txt";
        public static MUser findUser(MUser u)
        {
            foreach (MUser user in users)
            {
                if (user.name == u.name && user.password == u.password)
                {
                    return user;
                }
            }
            return null;
        }
        public static bool isAdmin(MUser u)
        {
            foreach (MUser user in users)
            {
                if (user.name == u.name && user.password == u.password)
                {
                    if( user.role.ToLower() == "admin")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsValidUser(MUser u)
        {
            foreach (MUser user in users)
            {
                if (user.name == u.name && user.password == u.password)
                {
                    return true;
                }
            }
            return false;
        }
        public static void addUserinList(MUser u)
        {
            if(u.role.ToLower() != "admin")
            {
                Customer c = new Customer(u);
                customers.Add(c);
            }
            users.Add(u);
            WriteInFile(u);
        }
        public static void Readdata()
        {
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string line;
                while ((line = myFile.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');
                    MUser u = new MUser(temp[0], temp[1], temp[2]);
                    users.Add(u);
                }

                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not found!!");
                Console.ReadKey();
            }
        }
        public static void WriteInFile(MUser u)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(u.name + "," + u.password + "," + u.role);
            file.Flush();
            file.Close();
        }


    }
}
