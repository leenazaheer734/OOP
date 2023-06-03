using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanProblem.GL
{
    class Ghost
    {
        public int x;
        public int y;
        public string ghostDirection;
        public char ghostcharacter;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public Grid mazeGrid;
        public Ghost(int x, int y, char ghostchar, string ghostdirection , float speed, char previousitem, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostcharacter = ghostchar;
            setDirection(ghostdirection);
            this.speed = speed;
            this.previousItem = previousitem;
            this.mazeGrid = mazeGrid;
        }
        public void setDirection(string gDirection)
        {
            this.ghostDirection = gDirection;
        }
        public string getDirection()
        {
            return ghostDirection;
        }
        public void remove()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(" ");
        }
        public void draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(ghostcharacter);
        }
        public char getCharacter()
        {
            return ghostcharacter;
        }


    }
}
