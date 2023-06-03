using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacmanProblem.GL
{
    class PacMan
    {
        public int x;
        public int y;
        public int score;
        public Grid mazeGrid;
        public PacMan(int x, int y, Grid mazegrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazegrid;
        }

        public void remove()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(" ");
        }

        public void draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine("P");
        }

        public void move()
        {
            Cell current = this.mazeGrid.maze[x,y];
           
            if(Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                Cell next = mazeGrid.getLeftcell(current);
                moveLeft(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Cell next = mazeGrid.getRightcell(current);
                moveRight(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                Cell next = mazeGrid.getUpcell(current);
                moveUp(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                Cell next = mazeGrid.getDowncell(current);
                moveDown(current, next);
            }
        }
        public void moveLeft(Cell current, Cell next)
        {
            if(next.value != '%')
            {
                x = next.x;
                y = next.y;
            }
        }
        public void moveRight(Cell current, Cell next)
        {
            if (next.value != '%')
            {
                this.x = next.x;
                this.y = next.y;
            }
        }
        public void moveUp(Cell current, Cell next)
        {
            if (next.value != '%')
            {
                x = next.x;
                y = next.y;
            }
        }
        public void moveDown(Cell current, Cell next)
        {
            if (next.value != '%')
            {
                this.x = next.x;
                this.y = next.y;
            }
        }
    }
}

