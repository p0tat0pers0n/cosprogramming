using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Alien
    {
        public Rectangle alienRec;
        public int alienX,alienY,width,height,side,xSpawn,ySpawn;
        public Image alienImg;
        //public double xSpeed, ySpeed;
        public Random sideChance;
        public Random xSpawnOffset;
        public Random ySpawnOffset;
        public Matrix matrixAlien;
        Point centreAlien;
        public Alien()
        {
            width = 75;
            height = 75;

            alienRec = new Rectangle(alienX,alienY,width,height);
            alienImg = Properties.Resources.alien;
            sideChance = new Random();
            xSpawnOffset = new Random();
            ySpawnOffset = new Random();

            side = sideChance.Next(1, 4);
            xSpawn = xSpawnOffset.Next(50, 600);
            ySpawn = ySpawnOffset.Next(50, 390);
            newAlien();
        }

        public void newAlien()
        {
            if (side == 1)
            {
                //spawns on top going down
                alienRec.Location = new Point(xSpawn, 0);
            }
            if (side == 2)
            {
                //spawns on top going down
                alienRec.Location = new Point(620, ySpawn);
            }
            if (side == 3)
            {
                //spawns on top going down
                alienRec.Location = new Point(xSpawn, 450);
            }
            if (side == 4)
            {
                //spawns on top going down
                alienRec.Location = new Point(0, ySpawn);
            }
        }

        public void moveAlien()
        {
            if (side == 1) { alienY -= 5; }
            if (side == 2) { alienX += 5; }
            if (side == 3) { alienY += 5; }
            if (side == 4) { alienX -= 5; }
            alienRec.Location = new Point(alienX, alienY);
        }

        public void draw(Graphics g)
        {
            //centre bullet 
            centreAlien = new Point(alienX, alienY);
            //instantiate a Matrix object called matrixBullet
            matrixAlien = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixAlien.RotateAt(0, centreAlien);
            //Set the current draw location to the rotated matrix point i.e. where bulletRec is now
            g.Transform = matrixAlien;
            //Draw the bullet
            g.DrawImage(alienImg, alienRec);
        }
    }
}
