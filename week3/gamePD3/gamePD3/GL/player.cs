using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame.GL
{
    class Player
    {
        public Player(int playerX, int playerY)
        {
            this.playerX = playerX;
            this.playerY = playerY;
        }
        public int playerX;
        public int playerY;
    }
    class Bullet
    {
        public int bulletX;
        public int bulletY;
    }
    class Enemy1
    {
        public Enemy1(int enemy1X, int enemy1Y)
        {
            this.enemy1X = enemy1X;
            this.enemy1Y = enemy1Y;
        }
        public int enemy1X;
        public int enemy1Y;
    }
    class E1Fire
    {
        public int enemy1fX;
        public int enemy1fY;
    }
}
