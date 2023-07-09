using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using System.IO;

namespace NewBank.DL
{
    class AdminDL
    {
        private static List<Admin> admins = new List<Admin>();

        public static List<Admin> getAdminList()
        {
            return admins;
        }
        public static void StoreAdminInList(Admin a)
        {
            if (admins.Count == 0)
            {
                admins.Add(a);
            }
        }
        public static bool CheckAdminPresence()
        {
            if(admins.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static Admin checkAdmin(Person person)
        {
            foreach (Admin a in admins)
            {
                if (a.getAdmin().getName() == person.getName() && a.getAdmin().getPassword() == person.getPassword())
                {
                    return a;
                }
            }
            return null;
        }
        public static void StoreAdminDatainFile(Admin info)
        {
            string path = "admindata.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(info.getAdmin().getName() + "," + info.getAdmin().getPassword() + "," + "admin" + "," + info.getAdmin().getNumber() + "," + info.getAdmin().getAddress());
            myFile.Flush();
            myFile.Close();
        }
        public static void LoadAdminDataFromFile()
        {
            string line, path = "admindata.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');

                        string name = filedata[0];
                        string password = filedata[1];
                        string role = filedata[2];
                        string number = filedata[3];
                        string address = filedata[4];

                        Person p1 = new Person(name, password, role, number, address);
                        Admin a1 = new Admin(p1);
                        StoreAdminInList(a1);
                    }
                }
                myFile.Close();
            }
        }
    }
}
