using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7CH1.BL
{
    class FireTruck
    {
        private Ladder ladder;
        private HosePipe hosepipe;
        private Person worker;
        public FireTruck()
        {
            ladder = new Ladder();
            ladder.SetLength(7);
            ladder.SetColor("red");
        }
        public void AttachPipe(HosePipe hp)
        {
            this.hosepipe = hp;
        }
        public void AllocateFireFighter(Person p)
        {
            this.worker = p;
        }
    }
}
