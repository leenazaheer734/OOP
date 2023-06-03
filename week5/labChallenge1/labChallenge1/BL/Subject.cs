using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labChallenge1.BL
{
    class Subject
    {
        public string code;
        public string type;
        public float fees;
        public int crHour;
        public Subject(string code, string type, float fees, int crHour)
        {
            this.code = code;
            this.type = type;
            this.fees = fees;
            this.crHour = crHour; 
        }
        public string getCode()
        {
            return code;
        }
        public string getType()
        {
            return type;
        }
        public int getCreditHours()
        {
            return crHour;
        }
        public float getSubjectFees()
        {
            return fees;
        }
    }
}
