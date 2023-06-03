using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5Problem1.BL
{
    class Ship
    {
        public string shipNumber;
        public Angle latitude;
        public Angle longitude;
        public string findposition(List<Ship> ships)
        {
            string position = "";
            foreach (Ship s in ships)
            {
                if(s.shipNumber == shipNumber)
                {
                    string l1 = s.latitude.DisplayAngleinFormat();
                    string l2 = s.longitude.DisplayAngleinFormat();
                    position = "  Ship is " + l1 + " and " + l2;
                    break;
                }
            }
            return position;
        }
        public bool isShipPresent(List<Ship> ships)
        {
            foreach (Ship s in ships)
            {
                if (s.shipNumber == shipNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public string findshipserial(List<Ship> ships)
        {
            foreach (Ship s in ships)
            {
                if (s.latitude.degree == this.latitude.degree && s.longitude.degree == this.longitude.degree &&
                    s.latitude.minute == this.latitude.minute && s.longitude.minute == this.longitude.minute &&
                    s.latitude.direction ==  this.latitude.direction && s.longitude.direction == this.longitude.direction)
                {
                    return s.shipNumber;
                }
            }
            return null;
        }
        public void changePosition(List<Ship> ships)
        {
            for (int i=0; i<ships.Count; i++)
            {
                if (shipNumber == ships[i].shipNumber)
                {
                    ships[i].latitude.direction = this.latitude.direction;
                    ships[i].latitude.minute = this.latitude.minute;
                    ships[i].latitude.degree = this.latitude.degree;

                    ships[i].longitude.direction = this.longitude.direction;
                    ships[i].longitude.minute = this.longitude.minute;
                    ships[i].longitude.degree = this.longitude.degree;
                }
            }
        }
    }
}
