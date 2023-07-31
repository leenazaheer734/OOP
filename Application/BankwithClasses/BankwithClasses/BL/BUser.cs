using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankwithClasses.BL
{
    class BUser
    {
        public string username;
        public string password;
        public string role;
        public BUser(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public BUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public BUser(string username)
        {
            this.username = username;
        }

    }
}
