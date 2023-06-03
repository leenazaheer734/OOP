using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS3Tier.DL;

namespace UAMS3Tier.BL
{
    class Student
    {
        public string name;
        public int age;
        public float fscMarks;
        public float ecatMarks;
        public float merit;
        public DegreeProg regDegree;

        public List<DegreeProg> preferences = new List<DegreeProg>();
        public List<Subject> regSubjects;

        public Student(string name, int age, float fscMarks, float ecatMarks, List<DegreeProg> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubjects = new List<Subject>();
        }
        public void calculateMerit()
        {
            this.merit = ((fscMarks * 45) / 1100F) + ((ecatMarks * 55) / 400F);
        }
        public double getmerit()
        {
            return this.merit;
        }
        public int getCreditHours()
        {
            int credithours = 0;
            foreach (Subject s in regSubjects)
            {
                credithours = credithours + s.crHour;
            }
            return credithours;
        }
        public float calcculateFee()
        {
            float fee = 0F;
            if (regDegree != null)
            {
                foreach (Subject s in regSubjects)
                {
                    fee = fee + s.getSubjectFees();
                }
            }
            return fee;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.crHour <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
