using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicetask.BL
{
    class Hostelite: Student
    {
        private int roomNumber;
        private bool isFridgeAvailable;
        private bool isInternetAvailable;
        private float GethostelFee()
        {
            float fee = 500.0F;
            return fee;
        }
        public void SetRoomnumber(int roomnumber)
        {
            this.roomNumber = roomnumber;
        }
        public int GetRoomnumber()
        {
            return this.roomNumber;
        }

    }
}
