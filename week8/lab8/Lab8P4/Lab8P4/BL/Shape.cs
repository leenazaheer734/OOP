using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8P4.BL
{
    class Shape
    {
        protected string type;
        public Shape(string type)
        {
            this.type = type;
        }

        public virtual double GetArea()
        {
            double area = 0.0;
            return area;
        }
        public virtual string toString()
        {
            return "This is a shape";
        }


    }
}
