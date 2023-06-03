using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicetask.BL
{
    class DayScholar : Student
    {
        private bool isBusCardissued;
        private float pickUpPoint;
        private int busNo;
        private float pickUpdistance;
        private float GetBusFee()
        {
            float fee = pickUpdistance * 50.0F;
            return fee;
        }
        public void SetbusNo(int number)
        {
            this.busNo = number;
        }
        public float GetbusNo()
        {
            return busNo;
        }
    }
}
