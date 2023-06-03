using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6T2.BL;
using System.Threading;

namespace lab6T2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { {'#',' ',' '}, { '#', '#', ' ' }, { '#', '#', '#' }, { '#', '#', ' ' }, { '#', ' ', ' ' } };
            char[,] optriangle = new char[5, 3] { { ' ', ' ', '#' }, { ' ', '#', '#' }, { '#', '#', '#' }, { ' ', '#', '#' }, { ' ', ' ', '#' } };
            char[,] mine = new char[5, 5] {{  ' ', ' ', '&', ' ', ' ' }, { ' ', '&', '&', '&' ,' '}, { '&', '&', '&', '&', '&' }, { ' ', '&', '&', '&', ' ' }, { ' ', ' ', '&', ' ' ,' '},};


            Boundary b = new Boundary(new Point(0,0), new Point(0, 90), new Point(90, 0), new Point(90, 90));
            GameObject g1 = new GameObject(new Point(10, 40), "projectile", triangle, b);
            GameObject g2 = new GameObject(new Point(15, 20), "lefttoright", optriangle, b);
            GameObject g3 = new GameObject(new Point(4, 20), "patrol", mine, b);
            List<GameObject> go = new List<GameObject>();
             go.Add(g1);
             go.Add(g2);
             go.Add(g3);
            while(true)
            {
                Thread.Sleep(100);
                foreach(GameObject g in go)
                {
                    g.Erase();
                    g.Move();
                    g.Draw();
                }
            }
        }
    }
}
