using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6T2.BL
{
    class GameObject
    {
        public  char[,] Shape;
        public Point startingpoint;
        public Boundary premises;
        public  string direction;
        public int stepcount = 0;
        public GameObject()
        {
            char[,] Shape = new char[2, 3] {{ '*', '^', '*' },{ '^','*','^'}};
            direction = "lefttoright";
            startingpoint.setXY(0, 0);
            premises.topLeft.setXY(0, 0);
            premises.topRight.setXY(0, 90);
            premises.bottomLeft.setXY(90, 0);
            premises.bottomRight.setXY(90, 90);
        }
        public GameObject(Point sp, char[,] s1)
        {
            startingpoint = sp;
            direction = "lefttoright";
            Shape = s1;
            premises.topLeft.setXY(0, 0);
            premises.topRight.setXY(0, 90);
            premises.bottomLeft.setXY(90, 0);
            premises.bottomRight.setXY(90, 90);
        }
        public GameObject(Point sp, string d, char[,] s1, Boundary b)
        {
            startingpoint = sp;
            direction = d;
            Shape = s1;
            premises = b;
        }
        public  void Draw()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(startingpoint.y + i, startingpoint.x + j);
                    Console.Write(Shape[i, j]);
                }
            }

        }
        public void Erase()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {   
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(startingpoint.y + i , startingpoint.x + j);
                    Console.Write(" ");
                }
            }
        }
        public void Move()
        {
            if (direction == "lefttoright")
            {
                Movetoright();
            }
            if (direction == "righttoleft")
            {
                Movetoleft();
            }
            if (direction == "diagonal")
            {
                MoveDiagonal();
            }
            if (direction == "patrol")
            {
                if (startingpoint.y != premises.topLeft.y)
                {
                    Movetoleft();
                }
                else
                {
                    direction = "pright";
                }
            }
            if (direction == "pright")
            {
                if (startingpoint.y != premises.topRight.y)
                {
                    Movetoright();
                }
                else
                {
                    direction = "patrol";
                }
            }
            if (direction == "projectile")
            {
                if(stepcount < 4 )
                {
                    movetopright();
                }
                else if (stepcount < 7)
                {
                    Movetoright();
                }
                else if (stepcount < 10)
                {
                    MoveDiagonal();
                }
                else if(stepcount == 10)
                {
                    stepcount = 0;
                }
                stepcount++;
            }
        
        
        }
       
        public void Movetoright()
        {
            if (startingpoint.y < premises.topRight.y)
            {
                startingpoint.setXY(startingpoint.x, startingpoint.y + 1);
            }
        }
        public void Movetoleft()
        {
            if (startingpoint.y > premises.topLeft.y)
            {
                startingpoint.setXY(startingpoint.x, startingpoint.y - 1);
            }
        }
        public void MoveDiagonal()
        {
            if (startingpoint.y > premises.topLeft.y && startingpoint.x < premises.bottomRight.x)
            {
                startingpoint.setXY(startingpoint.x+1, startingpoint.y + 1);
            }
        }
        public void movetopright()
        {
            if(startingpoint.y < premises.topRight.y && startingpoint.x > premises.topRight.x)
            {
                startingpoint.setXY(startingpoint.x - 1, startingpoint.y +  1);
            }
        }
    }
}
