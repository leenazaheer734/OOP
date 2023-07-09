using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BL;

namespace BankSystem.DL
{
    class PersonDL
    {
        public static bool isAdmin(Person person)
        {
            foreach (Person user in users)
            {
                if (user.getName() == person.getName() && user.getPassword() == person.getPassword())
                {
                    if (user.getRole().ToLower() == "admin")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool SignIn(Person person)
        {
            Person admin = admin.getAdminInfo();

            if(person.getName()== admin.getName())




            foreach (Client c in ClientDL.getClientsList())
            {
                if (c.getClient().getName() == person.getName() && c.getClient().getPassword() == person.getPassword())
                {
                    return true;
                }
            }
            
            return false;
        }


    }
}
