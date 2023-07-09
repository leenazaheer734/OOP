using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignUpSignInDesktop.BL;
using System.IO;

namespace SignUpSignInDesktop.DL
{
    class MUserDL
    {
        private static List<MUser> userList = new List<MUser>();

        public static List<MUser> UserList { get => userList; set => userList = value; }

        public static void addUserInList(MUser user)
        {
            userList.Add(user);
        }
        public static MUser SignIN(MUser user)
        {
            foreach(MUser m in userList)
            {
                if(m.getName() == user.getName() && m.getPassword() == user.getPassword())
                {
                    return m;
                }
            }
            return null;
        }
        public static bool readDatafromFile()
        {
            string path = "data.txt";
            String line;
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

                        MUser user = new MUser(name, password, role);
                        addUserInList(user);
                    }
                }
                myFile.Close();
                return true;
            }
            return false;
        }
        public static void storeUserInFile(MUser u, string path)
        {
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(u.getName() + "," + u.getPassword() + "," + u.getRole());
            myFile.Flush();
            myFile.Close();
        }
        public static void EditUserFromList(MUser previous, MUser updated)
        {
            foreach (MUser m in userList)
            {
                if (m.getName() == previous.getName() && m.getPassword() == previous.getPassword())
                {
                    m.Name = updated.Name;
                    m.Password = updated.Password;
                    m.Role = updated.Role;
                    
                }
            }
        }
        public static void deleteUserFromList(MUser u)
        {
            for (int i = 0; i < userList.Count ; i++)
            {
                if (userList[i].getName() == u.getName() && userList[i].getPassword() == u.getPassword())
                {
                    userList.RemoveAt(i);

                }
            }
        }

        public static bool readDatafromFile(string path)
        {
            
            String line;
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

                        MUser user = new MUser(name, password, role);
                        addUserInList(user);
                    }
                }
                myFile.Close();
                return true;
            }
            return false;
        }

    }
}
