using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L8P1.BL2;

namespace L8P1.DL2
{
    class PersonDL
    {
        private static List<Person> persons = new List<Person>();
        public static void AddpersoninList(Person p)
        {
            persons.Add(p);
        }
        public static List<Person> getPersons()
        {
            return persons;
        }
    }
}
