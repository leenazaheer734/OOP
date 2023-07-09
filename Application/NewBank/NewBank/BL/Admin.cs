using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Admin
    {
        private Person admin;
        public Admin(Person a)
        {
            this.admin = a;
        }

        internal Person Person
        {
            get => default;
            set
            {
            }
        }

        public Person getAdmin()
        {
            return admin;
        }
    }
}
