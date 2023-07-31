using ChickenInvaderGame.UL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenInvaderGame.GL
{
    class GameReward : GameObject
    {
        bool x = false;
        public GameReward(Image image, GameCell startCell) : base(GameObjectType.FIRE, image)
        {
            this.CurrentCell = startCell;
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
            GameCell nextCell = this.CurrentCell.nextCell(GameDirection.Down);

            if (nextCell == currentCell || nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
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
