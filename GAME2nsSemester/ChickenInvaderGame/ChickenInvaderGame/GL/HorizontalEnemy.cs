using ChickenInvaderGame.UL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenInvaderGame.GL
{
    class HorizontalEnemy : GameEnemy
    {
        public HorizontalEnemy(Image image, GameCell startCell) : base(image, startCell)
        {
            this.enemydirection = GameDirection.Right;
        }


        public override GameCell nextCell()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = this.CurrentCell.nextCell(enemydirection);
           
            if (currentCell == nextCell)  //changing direction when enemy reaches to the border
            {
                if (this.enemydirection == GameDirection.Right)
                {
                    this.enemydirection = GameDirection.Left;
                }
                else if (this.enemydirection == GameDirection.Left)
                {
                    this.enemydirection = GameDirection.Right;
                }
            }
            else
            {
                currentCell = nextCell;
            }

            return currentCell;
        }
        public override void move(GameCell gamecell)
        {
            if (this.CurrentCell != null)
            {
                this.CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            this.CurrentCell = gamecell;
        }
    }
}
