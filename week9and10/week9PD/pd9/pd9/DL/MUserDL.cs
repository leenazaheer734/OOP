using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pd9.BL;
using System.IO;

namespace pd9.DL
{
    class MUserDL
    {
        private static List<MUser> usersList = new List<MUser>();
       // public static List<MUser> UsersList1 { get => usersList; set => usersList = value; }
        public static List<MUser> getList()
        {
            return usersList;
        }

        public static void addUserInList(MUser user)
        {
            usersList.Add(user);
        }
        
        public static void loaddumydata()
        {
            Product p = new Product();
            p.price = "ghg";

            MUser s1 = new MUser("leena", "123", "admin", p );
            MUser s2 = new MUser("Amna", "231", "admin", p);
            MUser s3 = new MUser("Noor", "wewq", "customwer", p);
            addUserInList(s1);
            addUserInList(s2);
            addUserInList(s3);
        }

        public static void EditUserFromList(MUser previous, MUser updated)
        {
            foreach (MUser m in usersList)
            {
                if (m.Name == previous.Name && m.Password == previous.Password)
                {
                    m.Name = updated.Name;
                    m.Password = updated.Password;
                    m.Role = updated.Role;

                }
            }
        }

        public static void deleteUserFromList(int index)
        {
            usersList.RemoveAt(index);
        }
        public static bool findUserInList(string name)
        {
            foreach (MUser m in usersList)
            {
                if (m.Name == name )
                {
                    return true;

                }
            }
            return false;
        }
    
    }
}
