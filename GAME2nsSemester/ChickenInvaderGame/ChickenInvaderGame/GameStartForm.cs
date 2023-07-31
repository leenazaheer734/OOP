using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChickenInvaderGame.GL;
using ChickenInvaderGame.UL;
using EZInput;

namespace ChickenInvaderGame
{
    public partial class GameStartForm : Form
    {
        int rewarddelay = 0;
        int enemyfiredelay = 0;
        Game game;
        GameCollisionDetector collider;


        public GameStartForm()
        {
            InitializeComponent();
            game = new Game(this);
            collider = new GameCollisionDetector();
        }


        private void GameStartForm_Load(object sender, EventArgs e)
        {
            HorizontalEnemy ev1 = new HorizontalEnemy(game.getRedChickenImage(), game.getCell(1, 6));
            RandomEnemy re1 = new RandomEnemy(game.getGreenChickenImage(), game.getCell(1, 10));
            SmartEnemy se1 = new SmartEnemy(game.getBlueChickenImage(), game.getCell(1, 2), game);
            game.addEnemy(re1);
            game.addEnemy(ev1);
            game.addEnemy(se1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowPlayerScore();
            ShowPlayerLives();
            MovePlayerShip();
            MovePlayerFires();
           
            game.RemovePlayerFire();
            game.RemoveReward();
            CheckPlayerEnemyCollision();
            Genrate_Reward_Withdelay();
            CheckGameOver();
        }
        private void enemyMovingTimer_Tick(object sender, EventArgs e)
        {
            MoveReward();
            Generate_EnemyFires_WithDelay();
            MoveEnemyFires();
            game.RemoveEnemyFire();
            MoveEnemies();
        }


        private void ShowPlayerLives()
        {
            lives_lbl.Text = game.GetPlayerLives().ToString();
        }
        private void ShowPlayerScore()
        {
            score_lbl.Text = game.score.ToString();
        }
        private void CheckGameOver()
        {
            if (game.GetPlayerLives() == 0)
            {
                timer1.Stop();
                enemyMovingTimer.Stop();
                this.Hide();
                GameOverForm gof = new GameOverForm(1);
                DialogResult result = gof.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    gof.Close();
                    GameIntro gintro = new GameIntro();
                    gintro.Show();
                }
                if (result == DialogResult.No)
                {
                    gof.Close();
                    GameStartForm gsf = new GameStartForm();
                    gsf.Show();
                }
            }
            if (game.Enemies.Count == 0)
            {
                timer1.Stop();
                enemyMovingTimer.Stop();
                this.Hide();
                GameOverForm gof = new GameOverForm(2);
                DialogResult result = gof.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    GameIntro gintro = new GameIntro();
                    gintro.Show();
                }
                if (result == DialogResult.No)
                {
                    this.Hide();
                    GameStartForm gsf = new GameStartForm();
                    gsf.Show();
                }
            }
        }
        private void MoveEnemies()
        {
            foreach (GameEnemy g in game.Enemies)
            {
                g.move(g.nextCell());
            }
        }
        private void Generate_EnemyFires_WithDelay()
        {
            enemyfiredelay++;
            if (enemyfiredelay == 7)
            {
                game.generateEnemyFire();
                enemyfiredelay = 0;
            }
        }
        private void Genrate_Reward_Withdelay()
        {
            rewarddelay++;
            if (rewarddelay == 25)
            {
                game.GenerateReward();
                rewarddelay = 0;
            }
        }
        private void MoveEnemyFires()
        {
            foreach (GameFire f in game.Enemy_fires)
            {
                if (collider.FireWithPlayer(f))
                {
                    game.DecreasePlayerHealth();
                    health_ProgressBar.Value = game.GetPlayerHealth();
                }
                f.Move(f.NextCell());
            }
        }
        private void MoveReward()
        {
            foreach (GameReward r in game.Rewards)
            {
                if (collider.RewardWithPlayer(r))
                {
                    game.AddPlayerScore(40);
                }
                r.Move(r.NextCell());
            }
        }
        private void MovePlayerShip()
        {
            GamePlayerShip player = game.getplayership();
            GameCell potentialNewCell = player.CurrentCell;

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                potentialNewCell = player.CurrentCell.nextCell(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                potentialNewCell = player.CurrentCell.nextCell(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                potentialNewCell = player.CurrentCell.nextCell(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                potentialNewCell = player.CurrentCell.nextCell(GameDirection.Down);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GameCell NewCell = player.CurrentCell.nextCell(GameDirection.Up);
                GameFire f = new GameFire(ChickenInvaderGame.Properties.Resources.pBullet, NewCell, GameDirection.Up);
                game.AddPlayerFire(f);
            }

            GameCell currentCell = player.CurrentCell;
            currentCell.setGameObject(Game.getBlankGameObject());

            player.move(potentialNewCell);
        }
        private void MovePlayerFires()
        {
            foreach (GameFire f in game.Player_fires)
            {
                if (collider.FireWithEnemy(f))
                {
                    game.AddPlayerScore(20);
                    DecreaseHealthOfCollidedEnemy(f);
                }
                f.Move(f.NextCell());
            }
        }
        private void DecreaseHealthOfCollidedEnemy(GameFire f)
        {
            for (int i = 0; i < game.Enemies.Count; i++)
            {
                if (f.NextCell() == game.Enemies[i].CurrentCell)
                {
                    game.DecreaseEnemyHealth(game.Enemies[i]);
                }
            }
        }
        private void CheckPlayerEnemyCollision()
        {
            for (int i = 0; i < game.Enemies.Count; i++)
            {
                if (collider.PlayerWithEnemy(game.getplayership(), game.Enemies[i]))
                {
                    game.DecreasePlayerLives();
                }
            }
        }
        private void GameStartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}