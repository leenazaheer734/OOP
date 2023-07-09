using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;
using Lab8P4.DL;
using Lab8P4.UI;

namespace Lab8P4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeDL.addshapeinList(RectangleUI.TakeinputforRectangle());
            ShapeDL.addshapeinList(CircleUI.TakeinputforCircle());
            ShapeDL.addshapeinList(SquareUI.TakeinputforSquare());

            ShapeUI.printallShapes(ShapeDL.getallShapes());

            Console.ReadKey();
        }
    }
}
