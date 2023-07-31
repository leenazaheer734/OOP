using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankGUI.BL
{
    class Item
    {
        private double value;

        public Item(double valueofitem)
        {
            this.value = valueofitem;
        }

       
        public double getValue()
        {
            return value;
        }
        public virtual void setValue(double value)
        {
            this.value = value;
        }
        public virtual void setPurity(string purity)
        {
        }
        public virtual void setWeight(double weight)
        {
        }
        public virtual string getPurity()
        {
            return "";
        }
        public virtual double getWeight()
        {
            return 0;
        }
        public virtual string getPropertyAddress()
        {
            return "";
        }
        public virtual void setPropertyAddress(string address)
        {
        }
    }
}
