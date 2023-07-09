using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL1
{
    class Circle
    {
        protected double radius;
        protected string color;
        public Circle()
        {
            radius = 1.0;
            color = "red";
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle (double radius,string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public void setradius(double radius)
        {
            this.radius = radius;
        }
        public void setcolor(string color)
        {
            this.color = color;
        }
        public double getradius()
        {
            return this.radius;
        }
        public string getcolor()
        {
            return this.color;
        }
        public string Tostring()
        {
            string r = "Circle [radius = " + this.radius + " , color = "+ this.color + "]";
            return r;
        }
        public double getArea()
        {
            return 2 * Math.PI * this.radius * this.radius;
        }

    }
}
