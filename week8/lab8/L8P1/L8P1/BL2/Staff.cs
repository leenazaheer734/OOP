using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8P1.BL2
{
    class Staff : Person
    {
        private string school;
        private double pay;

        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }

        public void setPay(double pay)
        {
            this.pay = pay;
        }
        public void setSchool(string school)
        {
            this.school = school;
        }
        public double getPay()
        {
            return this.pay;
        }
        public string getSchool()
        {
            return this.school;
        }
        public override string Tostring()
        {
            string s = " person: [ name = " + base.name + " , adddress = " + base.address + " , school = " + this.school + " , pay = " + this.pay + "]";
            return s;
        }

    }
}
