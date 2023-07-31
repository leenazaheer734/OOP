using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenInvaderGame.UL;
using System.Drawing;

namespace ChickenInvaderGame.GL
{
    abstract class GameEnemy : GameObject
    {
        int health;
        public GameDirection enemydirection;
        GameObject currentCellWithoutEnemy = Game.getBlankGameObject();


        public GameEnemy(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            enemydirection = new GameDirection();
            Health = 100;
        }

        public int Health { get => health; set => health = value; }

        public abstract void move(GameCell gc);
        public abstract GameCell nextCell();
    }
}
