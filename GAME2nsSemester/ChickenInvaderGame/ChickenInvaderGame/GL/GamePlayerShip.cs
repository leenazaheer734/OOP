using ChickenInvaderGame.UL;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenInvaderGame.GL
{
    class GamePlayerShip : GameObject
    {
        private int health;
        private int lives;

        public GamePlayerShip(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
            Lives = 3;
            Health = 100;
        }

        public int Lives { get => lives; set => lives = value; }
        public int Health { get => health; set => health = value; }

        public void move(GameCell gamecell)
        {
            this.CurrentCell = gamecell;
        }

    }
}
