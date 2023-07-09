using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;

namespace NewBank.UI
{
    class PersonUI
    {
        public static Person TakeInputWithoutRole()
        {
            Console.Write("    Enter your name:  ");
            string loginusername = Console.ReadLine();
            loginusername = BankUI.checkNameValidity(loginusername);

            Console.Write("    Enter your 4-digit security pin: ");
            string loginpassword = Console.ReadLine();
            loginpassword = BankUI.checkPinLength(loginpassword);
            loginpassword = BankUI.checkPinDigits(loginpassword).ToString();

            if (loginusername != null && loginpassword != null)
            {
                Person user = new Person(loginusername, loginpassword);
                return user;
            }
            return null;
        }
    }
}
