using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _201COS_Game
{
    class Bullet
    {
        public Rectangle bulletRec;
        public Image bullet;
        public int bulletX, bulletY, width, height;
        public int bulletRotated;
        public double xSpeed, ySpeed;
        public Matrix matrixBullet;//matrix to enable us to rotate bullet in the same angle as the player
        Point centreBullet;//centre of bullet

        public Bullet(Rectangle playerRec, int bulletRotate, int playerX, int playerY)
        {
            bulletX = playerRec.X + 37; // move bullet to middle of player
            bulletY = playerRec.Y;
            width = 10;
            height = 60;
            bullet = Properties.Resources.bullet;
            bulletRec = new Rectangle(playerX+50, playerY+50, width, height);

            //this code works out the speed of the bullet to be used in the moveBullet method
            xSpeed = 30 * (Math.Cos((bulletRotate - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((bulletRotate + 90) * Math.PI / 180));
            //calculate x,y to move bullet to middle of spaceship in drawBullet method
            bulletX = playerX + playerRec.Width / 2;
            bulletY = playerY + playerRec.Height / 2;
            //pass bulletRotate angle to bulletRotated so that it can be used in the drawBullet method
            bulletRotated = bulletRotate;
        }

        public void draw(Graphics g)
        {
            //centre bullet 
            centreBullet = new Point(bulletX, bulletY);
            //instantiate a Matrix object called matrixBullet
            matrixBullet = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixBullet.RotateAt(bulletRotated, centreBullet);
            //Set the current draw location to the rotated matrix point i.e. where bulletRec is now
            g.Transform = matrixBullet;
            //Draw the bullet
            g.DrawImage(bullet, bulletRec);
        }

        public void moveBullet()
        {
            bulletX += (int)xSpeed;//cast double to an integer value
            bulletY -= (int)ySpeed;
            bulletRec.Location = new Point(bulletX, bulletY);//bullets new location
        }
    }
}
