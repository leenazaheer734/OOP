using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labChallenge1.BL
{
    class Degree
    {
        public string title;
        public float duration;
        public int seats;
        public List<Subject> subjects;

        public Degree(string title, float duration, int seats)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public Degree()
        {

        }

        public string getDegreeName()
        {
            return title;
        }
        public float getDegreeDuration()
        {
            return duration;
        }
        public int getSeat()
        {
            return seats;
        }
        public Degree findDegree(string t, List<Degree> allDegreesAvailable)
        {
            foreach(Degree d in allDegreesAvailable)
            {
                if(d.title == t)
                {
                    return d;
                }
            }
            return null;
        }
        public void setSeats(int seats)
        {
            this.seats = seats;
        }
        public int calculateCreditHours()
        {
            int credithours = 0;
            foreach(Subject s in subjects)
            {
                credithours = credithours + s.crHour;
            }
            return credithours;
        }
        public bool isSubjectExists(Subject sub)
        {
            bool flag = false;
            foreach (Subject s in subjects)
            {
                if(s.code == sub.code)
                {
                    return true;
                }
            }
            return flag;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.crHour <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
