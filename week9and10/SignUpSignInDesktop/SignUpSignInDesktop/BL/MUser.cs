using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUpSignInDesktop.BL
{
    public class MyObject
    {
        public string ss;
        public MyObject(string ss)
        {
            this.ss = ss;
        }
    }
    class MUser
    {
        private string name;
        private string password;
        private string role;

        // {Name, Password, Role, Obj.ss}


        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public MUser(string name, string password, string role, string ss)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.role = "NA";
        }
        public string getName()
        {
            return this.name;
        }
        public string getPassword()
        {
            return this.password;
        }
        public string getRole()
        {
            return this.role;
        }
        public bool isAdmin()
        {
            if(this.role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
