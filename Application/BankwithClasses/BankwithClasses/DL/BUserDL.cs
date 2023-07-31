using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using System.IO;

namespace BankwithClasses.DL
{
    class BUserDL
    {
        static List<BUser> users = new List<BUser>();
        public static void storeuserinlist(BUser nu)
        {
            users.Add(nu);
        }
        public static bool isAdmin(BUser u)
        {
            foreach (BUser user in users)
            {
                if (user.username == u.username && user.password == u.password)
                {
                    if (user.role.ToLower() == "admin")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static BUser SignIn(BUser user)
        {
            foreach (BUser storedUser in users)
            {
                if (user.username == storedUser.username && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static bool CheckalphabetsinName(string name)
        {
            bool flag = false;
            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
