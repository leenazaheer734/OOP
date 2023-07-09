using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8P4.BL
{
    class Square : Shape
    {
        private double side;
        public Square (double side) : base("Square")
        {
            this.side = side;
        }
        
        public void setSide(double side)
        {
            this.side = side;
        }
        public double getSide()
        {
            return this.side;
        }
        public override double GetArea()
        {
            double area = this.side * this.side;
            return area;
        }
        public override string toString()
        {
            return "This is a Rectangle with area : " + GetArea() ;
        }

    }
}
