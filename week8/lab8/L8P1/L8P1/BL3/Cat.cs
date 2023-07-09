using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL3
{
    class Cat : Mammal
    {
        public Cat(string name) : base(name)
        {
        }

        public override string toString()
        {
            string s = " Cat [ Mammal [ Animal: [ name = " + this.name + "]";
            return s;
        }
        public override void greets()
        {
            Console.WriteLine(" Meow");
        }

    }
}
