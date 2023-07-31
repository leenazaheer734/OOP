using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenInvaderGame.UL;

namespace ChickenInvaderGame.GL
{
    class SmartEnemy : GameEnemy
    {
        Game game;

        public SmartEnemy(Image image, GameCell startCell, Game g) : base(image, startCell)
        {
            enemydirection = GameDirection.Right;
            this.game = g;
        }


        public override GameCell nextCell()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = this.CurrentCell.nextCell(SetDirection());

            if (currentCell == nextCell)  //changing direction when enemy reaches to the border
            {
                if (this.enemydirection == GameDirection.Right) {
                    this.enemydirection = GameDirection.Left;
                }
                else if (this.enemydirection == GameDirection.Left) {
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
        private GameDirection SetDirection()
        {
            int y = game.getplayership().CurrentCell.Y;
            if (y > CurrentCell.Y)
            {
                enemydirection = GameDirection.Right;
            }
            if (y < CurrentCell.Y)
            {
                enemydirection = GameDirection.Left;
            }
            if(y == CurrentCell.Y)
            {
                enemydirection = GameDirection.None;
            }
            return enemydirection;
        }

    }
}
