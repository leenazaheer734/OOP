using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanProblem.GL;
using System.Threading;

namespace PacmanProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\OOP\\week6\\pd6\\maze.txt";
            Grid mazeGrid = new Grid(24,66, path);

            PacMan player = new PacMan(2,9,mazeGrid);
            Ghost g1 = new Ghost(5,10,'H',"left", 0.1F,' ',mazeGrid);
            List<Ghost> ghosts = new List<Ghost>();
            ghosts.Add(g1);

            mazeGrid.draw();
            player.draw();
            bool gamerunning = true;

            while(gamerunning)
            {
                Thread.Sleep(90);

                player.remove();
                player.move();
                player.draw();
                foreach(Ghost g in ghosts)
                {
                    g.remove();
                    g.draw();
                }

            }
            Console.ReadKey();
        }
    }
}
