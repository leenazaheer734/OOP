using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab10.GL
{
    class GameGrid
    {
        public GameCell[,] cells;
        public int rows;
        public int cols;
        public GameGrid(string filename, int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            cells = new GameCell[rows, cols];
            loadGrid(filename);
        }
        private void loadGrid(string filename)
        {
            StreamReader fp = new StreamReader(filename);
            string record;

            for (int x = 0; x < this.rows; x++)
            {
                record = fp.ReadLine();
                for (int y = 0; y < this.cols; y++)
                {
                    char displaych = record[y];
                    GameObjectType type = GameObject.getGameObjectType(displaych);
                    GameObject gameobject = new GameObject(type, displaych);
                    GameCell gc = new GameCell(x, y, this);
                    gc.currentGameObject = gameobject;
                    cells[x, y] = gc;
                }
            }

            fp.Close();
        }
        public GameCell getCell(int x, int y)
        {
            return cells[x, y];
        }
    }
}
