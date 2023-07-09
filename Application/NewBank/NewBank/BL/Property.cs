using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Property : Item
    {
        public string PropertyAddress;
        public Property(string address, double valueofitem) : base(valueofitem)
        {
            this.PropertyAddress = address;
        }
        public override string getPropertyAddress()
        {
            return PropertyAddress;
        }
        public override void setPropertyAddress(string address)
        {
            this.PropertyAddress = address;
        }

    }
}
