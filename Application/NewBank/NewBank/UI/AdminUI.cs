using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.DL;

namespace NewBank.UI
{
    class AdminUI
    {
        public static Admin SignUpAdmin()
        {
            Console.WriteLine("   First Sign Up as Admin");
            Console.WriteLine();
            Console.Write("    Enter name:  ");
            string name = Console.ReadLine();
            name = BankUI.checkNameValidity(name);

            Console.Write("    Enter your 4-digit security pin: ");
            string password = Console.ReadLine();
            password = BankUI.checkPinLength(password);
            password = BankUI.checkPinDigits(password).ToString();

            Console.Write("    Enter your contact number: ");
            string phonenumber = Console.ReadLine();
            phonenumber = BankUI.checkNumberLength(phonenumber);
            phonenumber = BankUI.checkPinDigits(phonenumber).ToString();

            Console.Write("    Enter your address: ");
            string address = Console.ReadLine();
            address = BankUI.checkAddress(address);


            Person p1 = new Person(name, password, "admin", phonenumber, address);
            Admin ad1 = new Admin(p1);
            return ad1;
        }
        public static void ShowAdminIsAdded()
        {
            Console.WriteLine();
            Console.WriteLine("   ADMIN ADDED SUCCESSFULLY");
        }
    }
}
