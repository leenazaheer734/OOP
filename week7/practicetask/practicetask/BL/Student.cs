using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicetask.BL
{
    class Student
    {
        protected string name;
        protected int session;
        protected bool isDayScholar;
        protected float HSmarks;
        protected float EntryTestmarks;
        
        private float CalculateMerit()
        {
            float merit = this.HSmarks * 100 / 1100;
            return merit;
        }
        public void Setname(string name)
        {
            this.name = name;
        }
        public string Getname()
        {
            return this.name;
        }


    }
}
