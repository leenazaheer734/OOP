using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;

namespace Lab8P4.DL
{
    class ShapeDL
    {
        private static List<Shape> shapes = new List<Shape>();
        public static void addshapeinList(Shape s)
        {
            shapes.Add(s);
        }
        public static List<Shape> getallShapes()
        {
            return shapes;
        }
    }
}
