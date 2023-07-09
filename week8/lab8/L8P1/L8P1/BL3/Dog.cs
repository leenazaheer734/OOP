using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL3
{
    class Dog : Mammal
    {
        public Dog(string name) : base(name)
        {
        }

        public override string toString()
        {
            string s = " Dog [ Mammal [ Animal: [ name = " + this.name + "]";
            return s;
        }

        public override void greets()
        {
            Console.WriteLine(" Woof");
        }
    
    
    }
}
