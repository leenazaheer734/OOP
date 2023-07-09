using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.GL
{
    class Pacman : GameObject
    {
        public GameCell previous;
        public Pacman(GameCell c, char display) : base(display)
        {
            base.currentCell = c;
        }

        public GameCell move(GameDirection gd)
        {
            // return next cell
            return this.currentCell.NextCell(gd);
        }

        public void playermove(GameDirection gd)
        {
           // previous = this.move(gd).gameGrid.getCell( currentCell.x-1 , currentCell.y);

            currentCell = this.move(gd);
        }
    }
}
