using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL3
{
    class Mammal : Animal
    {
        public Mammal(string name) : base(name)
        {

        }
        public override string toString()
        {
            string s = " Mammal [ Animal: [ name = " + this.name + "]";
            return s;
        }
        public override void greets()
        { }


    }
}
