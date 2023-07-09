using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab10.GL;
using System.Threading;
using EZInput;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            GameGrid gr = new GameGrid("maze.txt", 24, 71);
            printMaze(gr);
            GameCell start = new GameCell(22, 19, gr);
            Pacman pacman = new Pacman(start, 'p');
            printGameObject(pacman);


           /* GameCell gstart = new GameCell(2, 4, gr);
            List<Ghost> ghosts = new List<Ghost>();
            HorizontalGhost hg1 = new HorizontalGhost(gstart, 'g');
            ghosts.Add(hg1);
            printGameObject(hg1);*/


            Console.ReadKey();

            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    pacman.playermove(GameDirection.UP);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {

                    moveGameObject(pacman, GameDirection.DOWN);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.RIGHT);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.LEFT);
                }
               
                
            }
        }


        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.currentGameObject.displayCharacter);
        }

 
        static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.currentCell.y, gameObject.currentCell.x);
            Console.Write(gameObject.displayCharacter);
        }

        static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.currentCell.NextCell(direction);
            if (nextCell != gameObject.currentCell)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');

                GameCell currentCell = gameObject.currentCell;

                gameObject.currentCell = nextCell;

            }
        }

      
        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.rows; x++)
            {
                for (int y = 0; y < grid.cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    printCell(cell);
                }
            }
        }

    }
}
