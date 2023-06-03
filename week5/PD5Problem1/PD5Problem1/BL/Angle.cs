using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5Problem1.BL
{
    class Angle
    {
        public int degree;
        public float minute;
        public char direction;
        public Angle(int degree, float minute, char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }
        public string DisplayAngleinFormat()
        {
            return degree + "\u00b0" + minute + "'" + direction;
        }
    }
}
