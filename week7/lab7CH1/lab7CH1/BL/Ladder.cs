using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7CH1.BL
{
    class Ladder
    {
        private float length;
        private string color;

        public void SetLength(float length)
        {
            this.length = length;
        }
        public void SetColor(string color)
        {
            this.color = color;
        }
        public float GetLength()
        {
            return this.length;
        }
        public string SetLength()
        {
            return this.color;
        }

    }
}
