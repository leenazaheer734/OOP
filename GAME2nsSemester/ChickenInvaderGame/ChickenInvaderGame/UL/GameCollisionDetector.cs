using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenInvaderGame.GL;
using System.Drawing;
using System.Windows.Forms;

namespace ChickenInvaderGame.UL
{
    class GameCollisionDetector
    {

        public bool FireWithPlayer(GameFire f)
        {
            bool flag = false;
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
            }
            return flag;
        }
        public bool RewardWithPlayer(GameReward r)
        {
            bool flag = false;
            if (r.NextCell().CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
            }
            return flag;
        }

        public bool FireWithEnemy(GameFire f)
        {
            bool flag = false;
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                flag = true;
            }
            return flag;
        }
        public bool PlayerWithEnemy(GamePlayerShip p, GameEnemy e)
        {
            bool flag = false;

            if (p.CurrentCell == e.CurrentCell)
            {
                flag = true;
            }
            return flag;
        }
    }
}
