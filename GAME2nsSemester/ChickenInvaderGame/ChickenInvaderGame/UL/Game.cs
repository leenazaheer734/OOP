using ChickenInvaderGame.GL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChickenInvaderGame.UL
{
    class Game
    {
        Form currentForm;
        GamePlayerShip player;
        GameGrid grid;
        List<GameEnemy> enemies;
        List<GameFire> player_fires;
        List<GameFire> enemy_fires;
        List<GameReward> rewards;
        public int score;

        internal List<GameEnemy> Enemies { get => enemies; set => enemies = value; }
        internal List<GameFire> Enemy_fires { get => enemy_fires; set => enemy_fires = value; }
        internal List<GameFire> Player_fires { get => player_fires; set => player_fires = value; }
        internal List<GameReward> Rewards { get => rewards; set => rewards = value; }

        public Game(Form cf)
        {
            this.currentForm = cf;
            grid = new GameGrid("maze.txt", 14, 21);
            player = new GamePlayerShip(ChickenInvaderGame.Properties.Resources.playerShipImage, grid.getCell(5, 6));
            Enemies = new List<GameEnemy>();
            Player_fires = new List<GameFire>();
            Enemy_fires = new List<GameFire>();
            Rewards = new List<GameReward>();
            score = 0;
            PrintMaze(grid);
        }

        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {

            Image img = null;
            if (displayCharacter == '#')
            {
                img = ChickenInvaderGame.Properties.Resources.border;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = ChickenInvaderGame.Properties.Resources.playerShipImage;
            }
            return img;
        }
        public Image getRewardImage()
        {
            return ChickenInvaderGame.Properties.Resources.orangePowerUpImage;
        }
        public Image getRedChickenImage()
        {
            return ChickenInvaderGame.Properties.Resources.redC;
        }
        public Image getBlueChickenImage()
        {
            return ChickenInvaderGame.Properties.Resources.blueC;
        }
        public Image getGreenChickenImage()
        {
            return ChickenInvaderGame.Properties.Resources.greenC;
        }
        public void addEnemy(GameEnemy e)
        {
            enemies.Add(e);
        }
        public void addEnemyFire(GameFire ef)
        {
            Enemy_fires.Add(ef);
        }
        public void AddPlayerFire(GameFire f)
        {
            Player_fires.Add(f);
        }
        public void AddReward(GameReward r)
        {
            Rewards.Add(r);
        }
        public GameCell getCell(int x, int y)
        {
            return grid.getCell(x, y);
        }
        public GamePlayerShip getplayership()
        {
            return player;
        }
        public int GetPlayerHealth()
        {
            return player.Health;
        }
        public int GetPlayerLives()
        {
            return player.Lives;
        }
        public void AddPlayerScore(int increment)
        {
            score = score + increment;
        }
        public void DecreasePlayerLives()
        {
            player.Health = 0;
        }
        public void DecreaseEnemyHealth(GameEnemy e)
        {
            if (e.Health > 0)
            {
                e.Health -= 20;
            }
            if(e.Health == 0)
            {
                getCell(e.CurrentCell.X, e.CurrentCell.Y).setGameObject(getBlankGameObject()); 
                RemoveEnemyFromList(e);
            }
        }
        public void RemoveEnemyFromList(GameEnemy e)
        {
            for(int i = 0; i< enemies.Count; i++)
            {
                if(enemies[i] == e)
                {
                    enemies.RemoveAt(i);
                }
            }
        }
        public void RemoveRewardFromList(GameReward r)
        {
            for (int i = 0; i < Rewards.Count; i++)
            {
                if (Rewards[i] == r)
                {
                    Rewards.RemoveAt(i);
                }
            }
        }
        public void DecreasePlayerHealth()
        {
            if (player.Health > 0)
            {
                player.Health -= 50;
            }
            if (player.Lives > 0 && player.Health == 0)
            {
                player.Lives--;
                player.Health = 100;
            }
            if (player.Lives == 0)
            {
                player.Health = 0;
            }
        }
        public void generateEnemyFire()
        {
            foreach (GameEnemy e in enemies)
            {
                GameCell NewCell = e.CurrentCell.nextCell(GameDirection.Down);
                GameFire f = new GameFire(ChickenInvaderGame.Properties.Resources.egg, NewCell, GameDirection.Down);
                addEnemyFire(f);
            }
        }
        public void GenerateReward()
        {
            Random rnd = new Random();
            int x, y;
            x = rnd.Next(1, 15);
            y = rnd.Next(1, 6);
            GameCell cell = grid.getCell(y, x);
            GameReward r = new GameReward(getRewardImage(), cell);
            AddReward(r);
        }
        public void RemoveEnemyFire()
        {
            for (int i = 0; i < enemy_fires.Count; i++)
            {
                if (enemy_fires[i].X)
                {
                    enemy_fires[i].CurrentCell.setGameObject(getBlankGameObject());
                    enemy_fires.RemoveAt(i);
                }
            }
        }
        public void RemoveReward()
        {
            for (int i = 0; i < Rewards.Count; i++)
            {
                if (Rewards[i].X)
                {
                    Rewards[i].CurrentCell.setGameObject(getBlankGameObject());
                    Rewards.RemoveAt(i);
                }
            }
        }
        public void RemovePlayerFire()
        {
            for (int i = 0; i < player_fires.Count; i++)
            {
                if (player_fires[i].X)
                {
                    player_fires[i].CurrentCell.setGameObject(getBlankGameObject());
                    player_fires.RemoveAt(i);
                }
            }
        }
        void PrintMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    currentForm.Controls.Add(cell.PictureBox);
                }
            }
        }
    }
}