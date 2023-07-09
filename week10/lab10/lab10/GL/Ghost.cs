using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.GL
{
    abstract class Ghost : GameObject
    {
        public Ghost(GameCell c, char display) : base(display)
        {
            base.currentCell = c;
        }

      /*  public abstract GameCell Move();*/


    }
}
