using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd9.BL
{
    class Product
    {
        public string price;
    }
    class MUser
    {
        private string name;
        private string password;
        private string role;
        private Product product;

        public MUser(string name, string password, string role, Product p)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            product = p;
        }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        internal Product Product { get => product; set => product = value; }
    }
}
