using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7CH1.BL
{
    class Person
    {
        protected string name;
        public void setName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
    }
}
