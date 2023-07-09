using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL2
{
    class Student : Person
    {
        private string program;
        private int year;
        private double fee;

        public Student(string name, string address, string program, int year, double fee) : base(name,address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }

        public void setProgram(string program)
        {
            this.program = program;
        }
        public void setYear(int year)
        {
            this.year = year;
        }
        public void setFee(double fee)
        {
            this.fee = fee;
        }
        public string getProgram()
        {
            return this.program;
        }
        public int getYear()
        {
            return this.year;
        }
        public double getFee()
        {
            return this.fee ;
        }
        public override string Tostring()
        {
            string s = " person: [ name = " + base.name + " , adddress = " + base.address +" , program = " + this.program + " , year = " + this.year + " , fee = " + this.fee + "]" ;
            return s;
        }

    }
}
