using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PacmanProblem.GL
{
    class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int colSize;
        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = new Cell[rowSize, colSize];
            readMazefromFile(path);
        }
        public void draw()
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    Console.Write(maze[x, y].value);
                }
                Console.WriteLine();
            }
        }
        public void readMazefromFile(string path)
        {
            StreamReader borderfile = new StreamReader(path);
            string line;
            int row = 0;
            while ((line = borderfile.ReadLine()) != null)
            {
                for (int i = 0; i < colSize; i++)
                {
                    Cell c = new Cell(line[i], row, i);
                    maze[row, i] = c;
                }
                row++;
            }
            borderfile.Close();
        }
        public Cell getLeftcell(Cell c)
        {

            foreach(Cell cn in maze)
            {
                if(c == cn)
                {
                    return maze[c.x -1 , c.y];
                }
            }
            return null;
        }
        public Cell getRightcell(Cell c)
        {

            foreach (Cell cn in maze)
            {
                if (c == cn)
                {
                    return maze[c.x+1, c.y];
                }
            }
            return null;
        }
        public Cell getUpcell(Cell c)
        {

            foreach (Cell cn in maze)
            {
                if (c == cn)
                {
                    return maze[c.x, c.y - 1];
                }
            }
            return null;
        }
        public Cell getDowncell(Cell c)
        {
            foreach (Cell cn in maze)
            {
                if (c == cn)
                {
                    return maze[c.x, c.y+1];
                }
            }
            return null;
        }
        public Cell findPacman(Cell c)
        {
            foreach (Cell cn in maze)
            {
                if (c == cn && cn.value == 'P')
                {
                    return cn;
                }
            }
            return null;
        }
        public Cell findGhost(char ghostChar)
        {
            foreach (Cell cn in maze)
            {
                if (cn.value == ghostChar)
                {
                    return cn;
                }
            }
            return null;
        }
    }
}
