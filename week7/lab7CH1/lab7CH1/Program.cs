using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab7CH1.BL;

namespace lab7CH1
{
    class Program
    {
        static void Main(string[] args)
        {
            FireTruck ft = new FireTruck();

            HosePipe hp = new HosePipe();
            hp.SetDiamter(10);
            hp.SetFlowrate(5);
            ft.AttachPipe(hp);


            Person w = new FireFighter();
            w.setName("tttt");

            ft.AllocateFireFighter(w);
          


        }
    }
}
