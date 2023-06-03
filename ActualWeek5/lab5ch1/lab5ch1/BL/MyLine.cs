using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5ch1.BL
{
    class MyLine
    {
        public MyPoint begin;
        public MyPoint end;
        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;
        }
        public MyLine()
        {}

        public MyPoint getBegin()
        {
            return this.begin;
        }
        public MyPoint getEnd()
        {
            return this.end;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }
        public void getBegin(MyPoint end)
        {
            this.end = end;
        }
        public double getLength()
        {
            double temp = Math.Pow(this.end.x - this.begin.x, 2) + Math.Pow(this.end.y - this.begin.y, 2);
            double len = Math.Sqrt(temp);
            return len;
        }
        public double getGradient()
        {
            double len = (this.end.y - this.begin.y) / (this.end.x - this.begin.x);
            return len;
        }
    }
}
