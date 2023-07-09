using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;
using Lab8P4.DL;

namespace Lab8P4.UI
{
    class ShapeUI
    {
        public static void printallShapes(List<Shape> shapes)
        {
            int count = 0;
            foreach(Shape s in shapes)
            {
                count++;
                Console.WriteLine(" " + count + ". " + s.toString());
            }
        }
    }
}
