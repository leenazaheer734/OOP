using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChickenInvaderGame.UL;

namespace ChickenInvaderGame.GL
{
    class GameFire : GameObject
    {
        GameDirection dir;
        bool x = false;
        public GameFire(Image image, GameCell startCell, GameDirection dir) : base(GameObjectType.FIRE, image)
        {
            this.CurrentCell = startCell;
            this.dir = dir;
        }

        public bool X { get => x; set => x = value; }

        public void Move(GameCell gameCell)
        {
            if (this.CurrentCell != null)
            {
                this.CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            this.CurrentCell = gameCell;
        }

        public GameCell NextCell()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = this.CurrentCell.nextCell(dir);

            if (nextCell == currentCell || nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER || nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY  || nextCell.CurrentGameObject.GameObjectType == GameObjectType.FIRE)
            {
                x = true;
                currentCell = nextCell;
            }
            else
            {
                currentCell = nextCell;
            }
            return currentCell;
        }

    }
}
