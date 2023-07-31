using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenInvaderGame.UL;

namespace ChickenInvaderGame.GL
{
    class RandomEnemy : GameEnemy
    {
        public RandomEnemy(Image image, GameCell startCell) : base(image, startCell)
        {
            this.enemydirection = GameDirection.Right;
        }


        public override GameCell nextCell()
        {
            setRandomDirection();
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
        public void setRandomDirection()
        {
            Random rand = new Random();
            int direction = rand.Next(1, 4);
            if (direction == 1)
            {
                this.enemydirection = GameDirection.Up;
            }
            else if (direction == 2)
            {
                this.enemydirection = GameDirection.Down;
            }
            else if (direction == 3)
            {
                this.enemydirection = GameDirection.Right;
            }
            else if (direction == 4)
            {
                this.enemydirection = GameDirection.Left;
            }
           
        }
    }
}
