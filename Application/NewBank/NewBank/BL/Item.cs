using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Item
    {
        protected double value;

        public Item(double valueofitem)
        {
            this.value = valueofitem;
        }

        internal Loan Loan
        {
            get => default;
            set
            {
            }
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
