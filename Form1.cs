using FIghtGame.Properties;
using System.Numerics;

namespace FIghtGame
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "left";
        int health = 100;
        int speed = 10;
        int ammoNumber = 10;
        int killsNumber = 0;
        int zombieSpeed = 3;    

        Random randNum = new Random();

        List<PictureBox> Zombies = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MAinGameTimerEvent(object sender, EventArgs e)
        {
            if (health > 1)
            {
                healthBar.Value = health;
            }
            else
            {
                Player.Image = Resources.dead;
                GameTimer.Stop();
                gameOver = true;
            }

            ammoField.Text = "Ammo : " + ammoNumber;
            killsField.Text = $"Kills : {killsNumber}";

            if (health < 20)
            {
                healthBar.ForeColor = Color.Red;  
            }

            if (goLeft && Player.Left > 0)
            {
                Player.Left -= speed;
            }
            if (goRight && Player.Left + Player.Width < 1185)
            {
                Player.Left += speed;
            }
            if (goUp && Player.Top > 60)
            {
                Player.Top -= speed;
            }
            if (goDown && Player.Top + Player.Height < 700)
            {
                Player.Top += speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "ammo" && Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        ammoNumber += 5;
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                    }

                    if ((string)x.Tag == "zombie")
                    {

                        if (x.Bounds.IntersectsWith(Player.Bounds))
                        {
                            health -= 1;
                        }

                        if (x.Left > Player.Left)
                        {
                            x.Left -= zombieSpeed;
                            ((PictureBox)x).Image = Resources.zleft;
                        }
                        if(x.Left < Player.Left)
                        {
                            x.Left += zombieSpeed;
                            ((PictureBox)x).Image = Resources.zright;
                        }

                        if (x.Top > Player.Top)
                        {
                            x.Top -= zombieSpeed;
                            ((PictureBox)x).Image = Resources.zup;
                        }
                        if(x.Top < Player.Top)
                        {
                            x.Top += zombieSpeed;
                            ((PictureBox)x).Image = Resources.zdown;
                        }
                    }


                }

                foreach (Control i in this.Controls)
                {
                    if (i is PictureBox && (string)i.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(i.Bounds))
                        {
                            killsNumber++;

                            Zombies.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            this.Controls.Remove(i);
                            ((PictureBox)x).Dispose();
                            ((PictureBox)i).Dispose();
                            GenerateZomies();
                        }
                    }
                }

            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Space && ammoNumber > 0)
            {
                ammoNumber--;
                Shoot(facing);

                if(ammoNumber < 1)
                {
                    GenerateAmmo();
                }
            }
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                Player.Image = Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                Player.Image = Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                Player.Image = Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                Player.Image = Resources.down;
            }
        }

        private void Shoot(String direction)
        {
            Bullet bullet = new();
            bullet.direction = direction;
            bullet.top = Player.Top + (Player.Height / 2);
            bullet.left = Player.Left + (Player.Width / 2);
            bullet.MakeBullet(this);
        }

        private void GenerateZomies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Image = Resources.zdown;
            zombie.Tag = "zombie";
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.Top = new Random().Next(0, 800);
            zombie.Left = new Random().Next(0, 900);
            Zombies.Add(zombie);
            this.Controls.Add(zombie);
            Player.BringToFront();
        }

        private void GenerateAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Tag = "ammo";
            ammo.Top = new Random().Next(30, this.ClientSize.Height - ammo.Height);
            ammo.Left = new Random().Next(30, this.ClientSize.Width - ammo.Width);
            this.Controls.Add(ammo);
            ammo.BringToFront();
            Player.BringToFront();
        }

        private void RestartGame()
        {
            Player.Image = Resources.up;

            foreach(PictureBox x in Zombies)
            {
                this.Controls.Remove(x);
            }

            Zombies.Clear();

            for (int i = 0; i < 2; i++)
            {
                GenerateZomies();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;

            health = 100;
            killsNumber = 0;
            ammoNumber = 10;

            GameTimer.Start();
        }
    }
}