using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL2
{
    class Person
    {
        protected string name;
        protected string address;

        public Person (string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public string getName()
        {
            return this.name;
        }
        public string getAddress()
        {
            return this.address;
        }
        public void setAddress(string addr)
        {
            this.address = addr;
        }
        public virtual string Tostring()
        {
            string s = " person: [ name = "+ this.name + " , adddress = " + this.address + "]";
            return s;
        }
    }
}
