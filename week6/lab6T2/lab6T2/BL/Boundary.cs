using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6T2.BL
{
    class Boundary
    {
        public Point topLeft;
        public Point topRight;
        public Point bottomLeft;
        public Point bottomRight;
        public Boundary()
        {
            topLeft.setXY(0, 0);
            topRight.setXY(0, 90);
            bottomLeft.setXY(90, 0);
            bottomRight.setXY(90, 90);
        }
        public Boundary(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {

            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }
       
    }
}
