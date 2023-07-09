using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;

namespace Lab8P4.UI
{
    class RectangleUI
    {
        public static Rectangle TakeinputforRectangle()
        {
            Console.Write(" Enter width of rectangle: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write(" Enter height of rectangle: ");
            double height = double.Parse(Console.ReadLine());

            Rectangle r = new Rectangle(width, height);
            return r;
        }
    }
}
