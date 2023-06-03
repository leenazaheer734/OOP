using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5ch1.BL;
using lab5ch1.UI;

namespace lab5ch1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLine ml = new MyLine();
            string option = "";
            while(option != "10")
            {
                option = MenusUI.Menu();

                if(option == "1")
                {
                    ml = MenusUI.Option1();      //creating a line
                }
                else if (option == "2")
                {
                    MyPoint b = new MyPoint();
                    b = MenusUI.Option2();
                    ml.begin.setX(b.x);      //updating x coordinate of begining of line
                    ml.begin.setY(b.y);      //updating y coordinate of begining of line
                }
                else if (option == "3")
                {
                    MyPoint e = new MyPoint();
                    e = MenusUI.Option3();
                    ml.end.setX(e.x);       //updating x coordinate of ending of line
                    ml.end.setY(e.y);       //updating y coordinate of ending of line
                }
                else if (option == "4")
                {
                    int x = ml.begin.getX();
                    int y = ml.begin.getY();
                    MenusUI.ShowBeginPoint(x,y);     //displaying begining point of line
                }
                else if (option == "5")
                {
                    int x = ml.end.getX();
                    int y = ml.end.getY();
                    MenusUI.ShowEndPoint(x,y);      //displaying ending point of line
                }
                else if (option == "6")
                {
                    double length = ml.getLength();
                    MenusUI.GetLengthofLine(length);    //displaying length of line
                }
                else if (option == "7")
                {
                    double gradient = ml.getGradient(); 
                    MenusUI.GetGradientofLine(gradient);    //displaying gradient of line
                }
                else if (option == "8")
                {
                    double distance = ml.begin.ditanceFromZero();
                    MenusUI.Option8(distance);                        //distance of begining point fom zero zero
                }
                else if (option == "9")
                {
                    double distance = ml.end.ditanceFromZero();
                    MenusUI.Option8(distance);                    //distance of ending point fom zero zero
                }
                Console.ReadKey();
            }
        }
        
    }
}
