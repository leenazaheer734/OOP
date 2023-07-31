using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankGUI.BL
{
    class Property : Item
    {
        private string propertyAddress;
        public Property(string address, double valueofitem) : base(valueofitem)
        {
            this.propertyAddress = address;
        }
        public override string getPropertyAddress()
        {
            return propertyAddress;
        }
        public override void setPropertyAddress(string address)
        {
            this.propertyAddress = address;
        }

    }
}
