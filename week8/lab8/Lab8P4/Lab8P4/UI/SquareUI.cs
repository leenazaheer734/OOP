using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8P4.BL;

namespace Lab8P4.UI
{
    class SquareUI
    {
        public static Square TakeinputforSquare()
        {
            Console.Write(" Enter side of square: ");
            double side = double.Parse(Console.ReadLine());
            Square s = new Square(side);
            return s;
        }
    }
}
