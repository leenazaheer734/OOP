using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7CH1.BL
{
    class HosePipe
    {
        private float diameter;
        private float waterflowrate;

        public void SetDiamter(float diameter)
        {
            this.diameter = diameter;
        }
        public void SetFlowrate(float flowrate)
        {
            this.waterflowrate = flowrate;
        }
        public float Getdiameter()
        {
            return this.diameter;
        }
        public float Getflowrate()
        {
            return this.waterflowrate;
        }

    }
}
