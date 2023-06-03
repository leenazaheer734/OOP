using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD5Problem1.BL;


namespace PD5Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();

            string option = "";
            while (option != "5")
            {
                Header();
                option = MainMenu();
                Header();
                if (option == "1")
                {
                    ships.Add(AddShip());
                    Console.WriteLine("  Ship is Added");
                    Console.ReadKey();
                }
                else if(option == "2")
                {
                    ViewShipPosition(ships);
                    Console.ReadKey();
                }
                else if(option == "3")
                {
                    FindShipNumber(ships);
                    Console.ReadKey();
                }
                else if(option =="4")
                {
                    ChangeShipPosition(ships);
                    Console.ReadKey();
                }
               
            }
           
        }
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("   ^^^^^ OCEAN NAVIGATION SYSTEM ^^^^");
            Console.WriteLine("   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
        }
        static string MainMenu()
        {
            Console.WriteLine("   1. Add  SHIP. ");
            Console.WriteLine("   2. View Ship Poition. ");
            Console.WriteLine("   3. View Ship Serial Number. ");
            Console.WriteLine("   4. Change Ship Position. ");
            Console.WriteLine("   5. Exit.");
            Console.WriteLine();
            Console.Write(" Enter an option: ");
            string option = Console.ReadLine();
            return option;
        }
        static Ship AddShip()
        {
            Console.Write("  Enter Ship Number: ");
            string shipnum = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("  Enter Latitude: ");
            Console.Write("  Enter Latitude Degree(0 to 90): ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("  ENter Latitude Minute: ");
            float latminute = float.Parse(Console.ReadLine());
            Console.Write("  ENter Latitude Direction(N/S): ");
            char latdirection = char.Parse(Console.ReadLine());

            Angle lat = new Angle(latdegree,latminute,latdirection);

            Console.WriteLine();
            Console.WriteLine("  Enter Longitude: ");
            Console.Write("  Enter Longitude Degree(0 to 180): ");
            int londegree = int.Parse(Console.ReadLine());
            Console.Write("  ENter Longitude Minute: ");
            float lonminute = float.Parse(Console.ReadLine());
            Console.Write("  ENter Longitude Direction(E/W): ");
            char londirection = char.Parse(Console.ReadLine());

            Angle lon = new Angle(londegree, lonminute, londirection);

            Ship s = new Ship();
            s.shipNumber = shipnum;
            s.latitude = lat;
            s.longitude = lon;
            return s;
        }
        static void ViewShipPosition(List<Ship> ships)
        {
            Ship s1 = new Ship();
            Console.Write("  Enter Ship Number to find its position: ");
            s1.shipNumber = Console.ReadLine();

            bool flag = s1.isShipPresent(ships);
            if(flag == true)
            {
                if(s1.findposition(ships) != null)
                {
                    Console.WriteLine(s1.findposition(ships));
                }
            }
            else
            {
                Console.Write("  " + s1.shipNumber + " Ship does not exists!");
            }
        }
        static void FindShipNumber(List<Ship> ships)
        {
            Console.WriteLine();
            Console.WriteLine("  Enter Latitude of ship you want to find: ");
            Console.Write("  Enter Latitude Degree(0 to 90): ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("  ENter Latitude Minute: ");
            float latminute = float.Parse(Console.ReadLine());
            Console.Write("  ENter Latitude Direction(N/S): ");
            char latdirection = char.Parse(Console.ReadLine());

            Angle lat = new Angle(latdegree, latminute, latdirection);

            Console.WriteLine();
            Console.WriteLine("  Enter Longitude of ship you want to find: ");
            Console.Write("  Enter Longitude Degree(0 to 180): ");
            int londegree = int.Parse(Console.ReadLine());
            Console.Write("  ENter Longitude Minute: ");
            float lonminute = float.Parse(Console.ReadLine());
            Console.Write("  ENter Longitude, Direction(E/W): ");
            char londirection = char.Parse(Console.ReadLine());

            Angle lon = new Angle(londegree, lonminute, londirection);

            Ship s3 = new Ship();
            s3.longitude = lon;
            s3.latitude = lat;
           
            if (s3.findshipserial(ships) != null)
            {
                Console.Write("  Ship's serial number is: "+ s3.findshipserial(ships));
            }
            else
            {
                Console.Write("  Ship does not exists!");
            }
        }
        static void ChangeShipPosition(List<Ship> ships)
        {
            Console.Write("  Enter Ship Number whose position you want to change: ");
            string shipnum = Console.ReadLine();
            Console.WriteLine();

            Ship s5 = new Ship();
            s5.shipNumber = shipnum;
            bool flag = s5.isShipPresent(ships);
            if (flag == true)
            {

                Console.WriteLine();
                Console.WriteLine("  Enter Ship's Latitude: ");
                Console.Write("  Enter Latitude Degree(0 to 90): ");
                int latdegree = int.Parse(Console.ReadLine());
                Console.Write("  ENter Latitude Minute: ");
                float latminute = float.Parse(Console.ReadLine());
                Console.Write("  ENter Latitude Direction(N/S): ");
                char latdirection = char.Parse(Console.ReadLine());

                Angle lat = new Angle(latdegree, latminute, latdirection);

                Console.WriteLine();
                Console.WriteLine("  Enter Ship's Longitude: ");
                Console.Write("  Enter Longitude Degree(0 to 180): ");
                int londegree = int.Parse(Console.ReadLine());
                Console.Write("  ENter Longitude Minute: ");
                float lonminute = float.Parse(Console.ReadLine());
                Console.Write("  ENter Longitude Direction(E/W): ");
                char londirection = char.Parse(Console.ReadLine());
                Angle lon = new Angle(londegree, lonminute, londirection);
                s5.longitude = lon;
                s5.latitude = lat;
                s5.changePosition(ships);
                Console.WriteLine("  Ship's Position has been changed!");
            }
            else
            {
                Console.Write("  " + s5.shipNumber + " Ship does not exists!");
            }

        }

    }
}
