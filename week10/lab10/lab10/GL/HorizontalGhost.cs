using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.GL
{
    class HorizontalGhost : Ghost
    {
        public HorizontalGhost(GameCell c, char display) : base(c,display)
        {}
       /* public override GameCell Move()
        {
            return this.currentCell.NextCell(GameDirection.RIGHT);
        }*/
    }

}
