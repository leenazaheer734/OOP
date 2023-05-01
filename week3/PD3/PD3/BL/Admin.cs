using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD3.BL
{
    class Credentials
    {
        public Credentials(string username, string password)
        {
            this.usernames = username;
            this.passwords = password;
        }
        public bool isAdmin()
        {
            if (roles == "admin")
            {
                return true;
            }
            return false;
        }
        public Credentials(string name, string password, string accounttype, float balance, string  phonenumber, int accountnumber, string status, string role)
        {
            this.usernames = name;
            this.passwords = password;
            this.accounttypes = accounttype;
            this.balances = balance;
            this.phonenumbers = phonenumber;
            this.accountnumbers = accountnumber;
            this.statuses = status;
            this.roles = role;
        }
        public Credentials(string username, string password, int accountnum)
        {
            this.usernames = username;
            this.passwords = password;
            this.accountnumbers = accountnum;
        }
        public Credentials()
        {

        }
        public bool Checkuserexistance(List<Credentials> users)
        {
            foreach (Credentials temp in users)
            {
                if (usernames == temp.usernames &&  passwords == temp.passwords &&  accountnumbers == temp.accountnumbers)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Freeze_account(List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].accountnumbers == accountnumbers && users[idx].passwords == passwords)
                {
                    users[idx].statuses = "freeze";
                    return true;
                }
            }
            return false;
        }
        public bool Search_account(List<Credentials> users)
        {
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (users[idx].usernames == usernames && users[idx].accountnumbers == accountnumbers)
                {
                    Console.WriteLine();
                    Console.WriteLine("    Following are details of " + usernames + ": ");
                    Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
                    Console.WriteLine("     " + users[idx].accountnumbers + "\t\t" + users[idx].usernames + "\t" + users[idx].passwords + "\t" + users[idx].accounttypes + "\t\t" + users[idx].balances + "\t" + users[idx].phonenumbers + "\t" + users[idx].statuses);
                    return true;
                }
            }
            return false;
        }
        public void Account_close(List<Credentials> users)
        {
            for (int index = 1; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].passwords == passwords && users[index].accountnumbers == accountnumbers)
                {
                    users.RemoveAt(index);         // finding index where data of user is stored in list
                }
            }
        }
        public void ViewAllusers(List<Credentials> users)
        {
            Console.WriteLine("    Following  are details of ALL clients: ");
            Console.WriteLine("    Accountno" + "\t" + "Name" + "\t\t" + "Pin" + "\t" + "AccountType" + "\t" + "Balance" + "\t" + "Phonenumber" + "\t" + "Status" + "\t");
            for (int idx = 1; idx < users.Count; idx++)
            {
                {
                    Console.WriteLine("     " + users[idx].accountnumbers + "\t\t" + users[idx].usernames + "\t" + users[idx].passwords + "\t" + users[idx].accounttypes + "\t\t" + users[idx].balances + "\t" + users[idx].phonenumbers + "\t" + users[idx].statuses);
                }
            }
            Console.WriteLine();
        }
        public void UpdateName(string newname, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].usernames = newname;
                    break;
                }
            }
        }
        public void UpdatePin(string newpass, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].passwords = newpass;
                    break;
                }
            }
        }
        public void Updatetype(string newtype, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].accounttypes = newtype;
                    break;
                }
            }
        }
        public void Updatestatus(string newstatus, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].statuses = newstatus;
                    break;
                }
            }
        }
        public void Updatephonenumber(string newnumber, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].phonenumbers = newnumber;
                    break;
                }
            }
        }
        public void Updatebalance(float newbalance, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].balances = newbalance;
                    break;
                }
            }
        }
        public void Updatinguserinfo(Credentials update, List<Credentials> users)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].usernames == usernames && users[index].accountnumbers == accountnumbers)
                {
                    users[index].usernames = update.usernames;
                    users[index].passwords = update.passwords;
                    users[index].balances = update.balances;
                    users[index].accounttypes = update.accounttypes;
                    users[index].statuses = update.statuses;
                    users[index].phonenumbers = update.phonenumbers;
                    break;
                }
            }
        }
        public float Totalmoney(List<Credentials> users)
        {
            float total = 0;
            for (int index = 1; index < users.Count; index++)
            {
                total = total + users[index].balances; // adding money present in bank
            }
            return total;
        }
        public void TaxonSpecific(int percentofTax, List<Credentials> users)
        {
            for (int indx = 1; indx < users.Count; indx++)
            {
                if (users[indx].usernames == usernames && users[indx].accountnumbers == accountnumbers)  // implementing tax on specific account
                {
                    users[indx].balances = users[indx].balances - (users[indx].balances * percentofTax / 100);
                    break;
                }
            }
        }
        public void TaxonAll(int percentofTax, List<Credentials> users)
        {
            for (int indx = 1; indx < users.Count; indx++)     // implementing tax on all accounts
            {
                users[indx].balances = users[indx].balances - (users[indx].balances * percentofTax / 100);
            }
        }
        
        public string usernames;
        public string passwords;
        public string roles;
        public string accounttypes;
        public float balances;
        public string phonenumbers;
        public string statuses;
        public int accountnumbers;
    }

}
