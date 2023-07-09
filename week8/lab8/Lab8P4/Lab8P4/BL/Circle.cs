using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8P4.BL
{
    class Circle:Shape
    {
        private double radius;

        public Circle (double radius) : base("Circle")
        {
            this.radius = radius;
        }
       
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public double getRadius()
        {
            return this.radius;
        }

        public override double GetArea()
        {
            double area = 2 * Math.PI * this.radius * this.radius;
            return area;
        }
        public override string toString()
        {
            return "This is a Circle with area : " + this.GetArea();
        }
    }
}
