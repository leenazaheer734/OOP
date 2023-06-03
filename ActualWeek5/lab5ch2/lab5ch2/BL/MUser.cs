using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5ch2.BL
{
    class MUser
    {
        public string name;
        public string password;
        public string role;
        public MUser()
        {
        }
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public string getname()
        {
            return this.name;
        }
    }
}
