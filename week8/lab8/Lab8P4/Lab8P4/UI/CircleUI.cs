using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;

namespace Lab8P4.UI
{
    class CircleUI
    {
        public static Circle TakeinputforCircle()
        {
            Console.Write(" Enter radius of circle: ");
            double radius = double.Parse(Console.ReadLine());
            Circle c = new Circle(radius);
            return c;
        }
    }
}
