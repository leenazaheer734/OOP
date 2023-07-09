using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.GL
{
    class GameObject
    {
        public char displayCharacter;
        public GameCell currentCell;
        public GameObjectType objectType;
        public GameObject(GameObjectType type, char display)
        {
            objectType = type;
            displayCharacter = display;
        }
        public GameObject(char display)
        {
            objectType = getGameObjectType(display);
            displayCharacter = display;
        }

        public static GameObjectType getGameObjectType(char dc)
        {
            if (dc == 'p')
            {
                return GameObjectType.PLAYER;
            }
            else if (dc == '%' || dc == '|' || dc == '#')
            {
                return GameObjectType.WALL;
            }
            else if (dc == 'g')
            {
                return GameObjectType.ENEMY;
            }
            else if (dc == '.')
            {
                return GameObjectType.REWARD;
            }
            else
                return GameObjectType.NONE;
        }

       
    }
}
