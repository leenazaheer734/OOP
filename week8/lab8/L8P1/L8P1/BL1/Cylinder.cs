using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL1
{
    class Cylinder : Circle
    {
        private double height;
        public Cylinder()
        {
            height = 1.0;
        }
        public Cylinder(double radius, double height ,string color) : base(radius, color)
        {
            this.height = height;
        }
        public Cylinder(double radius, double height) : base(radius)
        {
            this.height = height;
        }
        public Cylinder(double radius): base(radius)
        {

        }

        public void setheight(double height)
        {
            this.height = height;
        }
        public double getheight()
        {
            return this.height;
        }
        public double getVolume()
        {
            return Math.PI * base.radius * base.radius * height;
        }
    }
}
