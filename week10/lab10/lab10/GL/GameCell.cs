using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.GL
{
    class GameCell
    {
        public int x;
        public int y;
        public GameObject currentGameObject;
        public GameGrid gameGrid;

        public GameCell(int x, int y, GameGrid g)
        {
            this.x = x;
            this.y = y;
            this.gameGrid = g;
        }
        public GameCell NextCell(GameDirection d)
        {
            if( d == GameDirection.UP)
            {
                if (this.x > 0)
                {
                    GameCell Cell = gameGrid.getCell(x - 1, y);
                    if (Cell.currentGameObject.objectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }

            }
            else if (d == GameDirection.DOWN)
            {
                if (this.x < gameGrid.rows - 1)
                {
                    GameCell Cell = gameGrid.getCell(x + 1, y);
                    if (Cell.currentGameObject.objectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }

            else if(d == GameDirection.RIGHT)
            {
                if (this.y < gameGrid.cols - 1)
                {
                    GameCell Cell = gameGrid.getCell(x, y + 1);
                    if (Cell.currentGameObject.objectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }

            else if(d == GameDirection.LEFT)
            {
                if (this.y > 0)
                {
                    GameCell Cell = gameGrid.getCell(x, y - 1);
                    if (Cell.currentGameObject.objectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }

            return this;
        }
    }
}
