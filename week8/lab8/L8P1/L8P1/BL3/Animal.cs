using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL3
{
    class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }
        public virtual string toString()
        {
            string s = " Animal: [ name = " + this.name + "]";
            return s;
        }
        public virtual void greets()
        {
            Console.WriteLine(" This is an animal");
        }
    }
}
