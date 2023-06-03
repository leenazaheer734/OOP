using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.BL;

namespace UAMS3Tier.DL
{
    class DegreeDL
    {
        static List<DegreeProg> allDegreesAvailable = new List<DegreeProg>();
        public static void AddDegreeinList(DegreeProg d)
        {
            allDegreesAvailable.Add(d);
        }
        public static DegreeProg findDegree(string t)
        {
            foreach (DegreeProg d in allDegreesAvailable)
            {
                if (d.title == t)
                {
                    return d;
                }
            }
            return null;
        }
        public static List<DegreeProg> getallDegrees()
        {
            return allDegreesAvailable;
        }
    }
}
