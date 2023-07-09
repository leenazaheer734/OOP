using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L8P1.BL1;
using L8P1.BL2;
using L8P1.BL3;
using L8P1.DL2;
using L8P1.DL3;

namespace L8P1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();
            //Problem2();
            Problem3();
            Console.ReadLine();
        }
        static void Problem1()
        {
            Cylinder c1 = new Cylinder();
            Cylinder c2 = new Cylinder(56, 10, "red");
            Cylinder c3 = new Cylinder(3.4, 1.2);
            c1.setheight(1);
            Console.WriteLine(c1.getVolume());
            Console.WriteLine(c2.getVolume());
            Console.WriteLine(c3.getVolume());

            Console.WriteLine(c1.Tostring());
            Console.WriteLine(c2.Tostring());
            Console.WriteLine(c3.Tostring());
        }
        static void Problem2()
        {
            Student s1 = new Student("leena", "Grw", "Cs", 1, 55000);
            Student s2 = new Student("opp", "Grw", "CE", 1, 75000);
            Staff sf1 = new Staff("uu", "lhr", "bb", 20000);
            Staff sf2 = new Staff("vv", "lhr", "cc", 30000);

            PersonDL.AddpersoninList(s1);
            PersonDL.AddpersoninList(s2);
            PersonDL.AddpersoninList(sf1);
            PersonDL.AddpersoninList(sf2);


            foreach (Person pn in PersonDL.getPersons())
            {
                Console.WriteLine(pn.Tostring());
            }
        } 
        static void Problem3()
        {
            Cat cat1 = new Cat("billi1");
            Cat cat2 = new Cat("billi2");
            Dog d1 = new Dog("dog1");
            Dog d2 = new Dog("dog2");

            AnimalDL.AddanimalinList(cat1);
            AnimalDL.AddanimalinList(cat2);
            AnimalDL.AddanimalinList(d1);
            AnimalDL.AddanimalinList(d2);


            foreach (Animal a in AnimalDL.getanimalList())
            {
                Console.WriteLine(a.toString());
                a.greets();
            }
        }
    }
}
