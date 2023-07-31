using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        int enemy1FireTimer = 5;
        int enemy2FireTimer = 5;
        int enemy1LastTimeToFire = 0;
        int enemy2LastTimeToFire = 0;
        bool isenemy1alive = true;
        bool isenemy2alive = true;
        int meteorGenerationTime = 25;
        int lastmeteorTime = 0;
        int score = 0;
        PictureBox playerFire;
        ProgressBar playerHealth;
        PictureBox enemy1 = new PictureBox();
        PictureBox enemy2 = new PictureBox();
        Random rand = new Random();

        List<PictureBox> playerFires = new List<PictureBox>();
        List<PictureBox> enemies = new List<PictureBox>();
        List<PictureBox> enemyFires = new List<PictureBox>();
        List<PictureBox> meteorslist = new List<PictureBox>();
        string enemy1Direction = "Left";
        string enemy2Direction = "Right";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createPlayer();
            enemy1 = createEnemy(SpaceShooter.Properties.Resources.enemyShip);
            enemy2 = createEnemy(SpaceShooter.Properties.Resources.otherEnemy);
            this.Controls.Add(enemy1);
            this.Controls.Add(enemy2);
        }

        private void timeGameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                playerShip.Left = playerShip.Left + 30;
                playerHealth.Left = playerHealth.Left + 30;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                playerShip.Left = playerShip.Left - 30;
                playerHealth.Left = playerHealth.Left - 30;
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                playerShip.Top = playerShip.Top - 25;
                playerHealth.Top = playerHealth.Top - 25;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                playerShip.Top = playerShip.Top + 30;
                playerHealth.Top = playerHealth.Top + 30;
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image fireimg = SpaceShooter.Properties.Resources.bullet;
                playerFire = new PictureBox();
                playerFire.Image = fireimg;
                //creating a picture Box for player's fire

                playerFire.Width = fireimg.Width;
                playerFire.Height = fireimg.Height;
                playerFire.BackColor = Color.Transparent;
                //setting its width and height

                System.Drawing.Point firelocation = new System.Drawing.Point();
                firelocation.X = playerShip.Left + (playerShip.Width / 2) - 7;
                firelocation.Y = playerShip.Top;
                //setting its location

                playerFire.Location = firelocation;
                this.Controls.Add(playerFire);
                playerFires.Add(playerFire);
                //adding fire in list and in form

            }//player firing


            for (int i = 0; i < playerFires.Count; i++)
            {
                if (playerFires[i] != null)
                {
                    playerFires[i].Top = playerFires[i].Top - 30;

                    if(isenemy1alive == true && playerFires[i].Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        enemy1.Hide();
                        isenemy1alive = false;
                    }
                    if (isenemy2alive == true && playerFires[i].Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        enemy2.Hide();
                        isenemy2alive = false;
                    }
                    if(isenemy1alive == false && isenemy2alive == false)
                    {
                        timeGameLoop.Enabled = false;
                        MessageBox.Show("YOu Won :) yaaayyyy");
                        this.Close();
                    }
                    if (playerFires[i].Bottom < 0)
                    {
                        this.Controls.Remove(playerFires[i]);
                        playerFires.RemoveAt(i);
                    }
                }
            }//moving player's fires
           
            moveENemy(enemy1, ref enemy1Direction, 10);
            moveENemy(enemy2, ref enemy2Direction, 10);

            enemy1LastTimeToFire++;
            enemy2LastTimeToFire++;
            if (enemy1LastTimeToFire == enemy1FireTimer && isenemy1alive == true)
            {
                Image fireimg = SpaceShooter.Properties.Resources.Fire2;
                PictureBox enemyFire = createFire(fireimg, enemy1);
                this.Controls.Add(enemyFire);
                enemyFires.Add(enemyFire);
                enemy1LastTimeToFire = 0;
            }
            if (enemy2LastTimeToFire == enemy2FireTimer  && isenemy2alive  == true)
            {
                Image fireimg = SpaceShooter.Properties.Resources.Fire1;
                PictureBox enemy2Fire = createFire(fireimg, enemy2);
                this.Controls.Add(enemy2Fire);
                enemyFires.Add(enemy2Fire);
                enemy2LastTimeToFire = 0;
            }

            for (int i = 0; i < enemyFires.Count; i++)
            {
                enemyFires[i].Top = enemyFires[i].Top + 20;

                if (enemyFires[i].Top > this.Height)
                {
                    enemyFires.RemoveAt(i);
                }
                if(enemyFires[i].Bounds.IntersectsWith(playerShip.Bounds) && (playerHealth.Value>0))
                {
                    playerHealth.Value = playerHealth.Value - 10;
                }
            }



            if (playerHealth.Value <= 0)
            {
                showGameEnd(SpaceShooter.Properties.Resources.gover);
            }
            lastmeteorTime++;
            if(lastmeteorTime == meteorGenerationTime)
            {
                Image metImg = SpaceShooter.Properties.Resources.meteor;
                PictureBox meteor = createMeteor(metImg);
                this.Controls.Add(meteor);
                meteorslist.Add(meteor);
                lastmeteorTime = 0;
            }
            for(int i = 0; i<meteorslist.Count; i++)
            {
                meteorslist[i].Top = meteorslist[i].Top + 15;
            }

            for(int i = 0; i< playerFires.Count;i++)
            {
                bool removebullet = false;
                foreach(PictureBox singlemeteor in meteorslist)
                {
                    if(singlemeteor.Bounds.IntersectsWith(playerFires[i].Bounds))
                    {
                        score = score + 5;
                        scorelabel.Text = "Score =  " + score.ToString();
                        singlemeteor.Top = this.Height + 20000;
                        singlemeteor.Hide();
                        removebullet = true;
                    }
                }
                if(removebullet == true)
                {
                    playerFires[i].Hide();
                    playerFires.RemoveAt(i);
                }
              
            }


        }//timer

        private PictureBox createFire(Image fireimg, PictureBox ship)
        {
            PictureBox fire = new PictureBox();
            fire.Image = fireimg;
            //creating a picture Box for player's fire

            fire.Width = fireimg.Width;
            fire.Height = fireimg.Height;
            fire.BackColor = Color.Transparent;
            //setting its width and height

            System.Drawing.Point firelocation = new System.Drawing.Point();
            firelocation.X = ship.Left + (ship.Width / 2) - 7;
            firelocation.Y = ship.Top + ship.Height - 7;
            //setting its location

            fire.Location = firelocation;
            return fire;
        }

        private PictureBox createEnemy(Image img)
        {
            PictureBox enemy = new PictureBox();
            enemy.Image = img;
            //creating a picture Box for enemy

            enemy.Width = img.Width;
            enemy.Height = img.Height;
            enemy.BackColor = Color.Transparent;
            //setting its width and height 

            int left = rand.Next(20, this.Width);
            int top = rand.Next(6, img.Height + 20);
            enemy.Left = left;
            enemy.Top = top;
            //setting its location
            enemies.Add(enemy);
            return enemy;
        }

        private void moveENemy(PictureBox enemy, ref string direction, int steps)
        {
            if (direction == "Left")
            {
                enemy.Left = enemy.Left - steps;
            }
            if (direction == "Right")
            {
                enemy.Left = enemy.Left + steps;
            }
            if (enemy.Left <= 3)
            {
                direction = "Right";
            }
            if ((enemy.Left + enemy.Width) >= this.Width)
            {
                direction = "Left";
            }
        }

        private PictureBox createMeteor(Image metImg)
        {
            Random rand1 = new Random();
            PictureBox meteor = new PictureBox();
            meteor.Image = metImg;
            //creating a picture Box for meteor
            meteor.Width = metImg.Width;
            meteor.Height = metImg.Height;
            meteor.BackColor = Color.Transparent;

            System.Drawing.Point meteorlocation = new System.Drawing.Point();
            meteorlocation.X = rand1.Next(20, this.Width - 20);
            meteorlocation.Y = rand1.Next(10, this.Height - 200);
            meteor.Location = meteorlocation;
            return meteor;
        }
        
        private void showGameEnd(Image img)
        {
            timeGameLoop.Enabled = false;
            this.Hide();
            frmGameEnd gameOver = new frmGameEnd(img);
            DialogResult result = gameOver.ShowDialog();

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            if (result == DialogResult.No)
            {
                Restart();
            }
        }

        private void Restart()
        {
            score = 0;
            this.Controls.Clear();
            createPlayer();
            playerFires = new List<PictureBox>();
            enemyFires = new List<PictureBox>();
            enemies = new List<PictureBox>();
            meteorslist = new List<PictureBox>();
            rand = new Random();
            enemy1Direction = "Left";
            enemy2Direction = "Right";
            enemy2LastTimeToFire = 0;
            enemy2LastTimeToFire = 0;
            enemy2FireTimer = 5;
            enemy1FireTimer = 5;
            isenemy1alive = true;
            isenemy2alive = true;
            meteorGenerationTime = 25;
            lastmeteorTime = 0;

            Image i1 = SpaceShooter.Properties.Resources.enemyShip;
            enemy1 = createEnemy(i1);
            Image i2 = SpaceShooter.Properties.Resources.otherEnemy;
            enemy2 = createEnemy(i2);
            this.Controls.Add(enemy1);
            this.Controls.Add(enemy2);
            timeGameLoop.Enabled = true;
            this.Controls.Add(scorelabel);
            this.Show();
        }
        private void createPlayer()
        {
            playerShip = new PictureBox();
            Image playerimg = SpaceShooter.Properties.Resources.playerShip;
            playerShip.Image = playerimg;
            playerShip.Height = playerimg.Height;
            playerShip.Width = playerimg.Width;
            playerShip.Top = this.Height - (playerimg.Height + 60);
            playerShip.BackColor = Color.Transparent;

            playerHealth = new ProgressBar();
            playerHealth.Value = 100;
            playerHealth.Step = 5;
            playerHealth.Height = 10;
            playerHealth.Left = playerShip.Left + 7;
            playerHealth.Width = 84;
            playerHealth.Top = playerShip.Bottom + 10;

            this.Controls.Add(playerShip);
            this.Controls.Add(playerHealth);
        }


    }
}
