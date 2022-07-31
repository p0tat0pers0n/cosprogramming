using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Bullet
    {
        public Rectangle bulletRec;
        public Image bullet;
        public int x, y, width, height;
        public int bulletRotated;
        public double xSpeed, ySpeed;
        public Matrix matrixBullet;//matrix to enable us to rotate missile in the same angle as the spaceship
        Point centreBullet;//centre of missile


        public Bullet(Rectangle playerRec, int bulletRotate, int playerX, int playerY)
        {
            x = playerRec.X + 37; // move missile to middle of spaceship
            y = playerRec.Y;
            width = 60;
            height = 40;
            bullet = Properties.Resources.bullet;
            bulletRec = new Rectangle(x, y, width, height);

            //this code works out the speed of the missile to be used in the moveMissile method
            xSpeed = 30 * (Math.Cos((bulletRotate - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((bulletRotate + 90) * Math.PI / 180));
            //calculate x,y to move missile to middle of spaceship in drawMissile method
            x = playerX + playerRec.Width / 2;
            y = playerY + playerRec.Height / 2;
            //pass missileRotate angle to missileRotated so that it can be used in the drawMissile method
            bulletRotated = bulletRotate;
        }

        public void draw(Graphics g)
        {
            //centre missile 
            centreBullet = new Point(x, y);
            //instantiate a Matrix object called matrixMissile
            matrixBullet = new Matrix();
            //rotate the matrix (in this case missileRec) about its centre
            matrixBullet.RotateAt(bulletRotated, centreBullet);
            //Set the current draw location to the rotated matrix point i.e. where missileRec is now
            g.Transform = matrixBullet;
            //Draw the missile
            g.DrawImage(bullet, bulletRec);
        }

        public void moveBullet(Graphics g)
        {
            x += (int)xSpeed;//cast double to an integer value
            y -= (int)ySpeed;
            bulletRec.Location = new Point(x, y);//missiles new location

        }
    }
}
