using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L8P1.BL3;

namespace L8P1.DL3
{
    class AnimalDL
    {
        private static List<Animal> animals = new List<Animal>();
        public static void AddanimalinList(Animal a)
        {
            animals.Add(a);
        }
        public static List<Animal> getanimalList()
        {
            return animals;
        }
    }
}
