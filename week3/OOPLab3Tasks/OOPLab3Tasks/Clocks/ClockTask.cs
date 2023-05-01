using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3Tasks.Clocks
{
    class ClockType
    {
        public ClockType()
        {
            hour = 0;
            minutes = 0;
            seconds = 0;
        }
        public ClockType(int h)
        {
            hour = h;
        }
        public ClockType(int h, int m)
        {
            hour = h;
            minutes = m;
        }
        public ClockType(int h, int m, int s)
        {
            hour = h;
            minutes = m;
            seconds = s;
        }
        public void Incrementhour()
        {
            hour++;
        }
        public void Incrementmin()
        {
            minutes++;
        }
        public void Incrementsec()
        {
            seconds++;
        }
        public void printTime()
        {
            Console.WriteLine(hour + ":" + minutes + ":" + seconds);
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hour == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(ClockType c)
        {
            if (hour == c.hour && minutes == c.minutes && seconds == c.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int hour;
        public int minutes;
        public int seconds;
    }
    class ClockTask
    {
            public ClockTask(int hours, int minutes, int seconds)
            {
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
            }

            public ClockTask(int seconds)
            {
                this.hours = seconds / 3600;                 //converting time from seconds to hour;min:sec format
                this.minutes = (seconds % 3600) / 60;
                this.seconds = seconds % 60;
            }
            public int CalculateElapsedSec()
            {
                int timeInSec;
                timeInSec = (hours * 3600) + (minutes * 60) + (seconds * 1);
                return timeInSec;
            }

            public int CalculateRemainingSec()
            {
                int rem_sec;
                rem_sec = (24 * 3600) - ((hours * 3600) + (minutes * 60) + (seconds * 1));
                return rem_sec;
            }
         public void Timedifference(ClockTask c)
         {
              if (c.hours > hours)
              {
                   hours = c.hours - hours;
              }
              else
              {
                   hours = hours - c.hours;
              }
              if (c.minutes > minutes)
              {
                   minutes = c.minutes - minutes;
              }
              else
              {
                   minutes = minutes - c.minutes;
              }
              if (c.seconds > seconds)
              {
                  seconds = c.seconds - seconds;
              }
              else
              {
                  seconds = seconds - c.seconds;
              }
         }

         public int hours;
         public int minutes;
         public int seconds;
    }
}
