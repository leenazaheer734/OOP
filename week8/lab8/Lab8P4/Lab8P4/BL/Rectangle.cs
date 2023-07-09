using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8P4.BL
{
    class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height): base("Rectangle")
        {
            this.height = height;
            this.width = width;
        }


        public void setWidth(double width)
        {
            this.width = width;
        }
        public double getWidth()
        {
            return this.width;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getHeight()
        {
            return this.height;
        }

        public override double GetArea()
        {
            double area = this.width * this.height;
            return area;
        }
        public override string toString()
        {
            return "This is a Rectangle with area : " + this.GetArea();
        }

    }
}
