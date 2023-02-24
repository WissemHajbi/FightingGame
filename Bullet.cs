using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace FIghtGame
{
    internal class Bullet
    {
        public string direction;
        public int top;
        public int left;
        public int speed = 20;

        private PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer BulletTimer = new System.Windows.Forms.Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.Yellow;
            bullet.Size = new Size (5, 5);
            bullet.Tag = "bullet";
            bullet.Left = left;
            bullet.Top = top;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            BulletTimer.Interval = speed;
            BulletTimer.Tick += new EventHandler(BulletTimerEvent);
            BulletTimer.Start();
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {

            switch (direction)
            {
                case "up": bullet.Top -= speed;
                    break;
                case "down": bullet.Top += speed;
                    break;
                case "right": bullet.Left += speed;
                    break;
                case "left": bullet.Left -= speed;
                    break;
            }   

            if(bullet.Left < 10 || bullet.Left > 1200 || bullet.Top < 10 || bullet.Top > 700)
            {
                BulletTimer.Stop();
                BulletTimer.Dispose();
                bullet.Dispose();
                BulletTimer = null;
                bullet = null;
            }

        }

    }
}
