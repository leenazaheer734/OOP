using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankGUI.BL
{
    class Gold : Item
    {
        private string GoldPurity;
        private double GoldWeight;
        public Gold(string purity, double weight, double valueofitem) : base(valueofitem)
        {
            this.GoldPurity = purity;
            this.GoldWeight = weight;
        }
        public override void setPurity(string purity)
        {
            this.GoldPurity = purity;
        }
        public override void setWeight(double weight)
        {
            this.GoldWeight = weight;
        }
        public override string getPurity()
        {
            return this.GoldPurity;
        }
        public override double getWeight()
        {
            return this.GoldWeight;
        }
    }
}
