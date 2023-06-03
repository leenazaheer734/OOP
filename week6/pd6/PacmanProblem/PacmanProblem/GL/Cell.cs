using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanProblem.GL
{
    class Cell
    {
        public int x;
        public int y;
        public char value;
        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public bool isPacmanPresent()
        {
            if(this.value == 'P')
            {
                return true;
            }
            return false;
        }
        public bool isGhostPresent(char ghostchar)
        {
            if(this.value == ghostchar)
            {
                return true;
            }
            return false;
        }
    }
}
