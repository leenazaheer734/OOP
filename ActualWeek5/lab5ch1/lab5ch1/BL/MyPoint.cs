using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5ch1.BL
{
    class MyPoint
    {
        public int x;
        public int y;
        public MyPoint()
        {
            this.x = 0;
            this.y = 0;
        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public double ditanceWithCords(int x, int y)
        {
            double temp = Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2);
            double fromCords = Math.Sqrt(temp);
            return fromCords;
        }
        public double ditanceWithObject(MyPoint p)
        {
            double temp = Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2);
            double fromObj = Math.Sqrt(temp);
            return fromObj;
        }
        public double ditanceFromZero()
        {
            double temp = Math.Pow(this.x - 0, 2) + Math.Pow(this.y - 0, 2);
            double fromOrigin = Math.Sqrt(temp);
            return fromOrigin;
        }


    }
}

