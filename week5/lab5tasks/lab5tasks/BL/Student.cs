using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5tasks.BL
{
    class Student
    {
        public string name;
        public int rollno;
        public float cgpa;
        public int maticMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostelite;
        public bool istakingScholarship;

        public Student(string name, int rollno, float cgpa, int maticMarks, int fscMarks, int ecatMarks, string homeTown, bool isHostelite, bool istakingScholarship)
        {
            this.name = name;
            this.rollno = rollno;
            this.cgpa = cgpa;
            this.maticMarks = maticMarks;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.homeTown = homeTown;
            this.isHostelite = isHostelite;
            this.istakingScholarship = istakingScholarship;
        }
        public float CalculateMerit()
        {
            float merit = (fscMarks * (60F/1100F)) + (ecatMarks * (40F/400F));
            return merit;
        }
        public bool IsEligibleforScholarship(float merit)
        {
            if(merit > 80F)
            {
                return true;
            }
            return false;
        }
    }
}
