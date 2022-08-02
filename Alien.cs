using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Alien
    {
        public Rectangle alienRec;
        public int x,y,width,height,side,xSpawn,ySpawn;
        public Image alienImg;
        //public double xSpeed, ySpeed;
        public Random sideChance;
        public Random xSpawnOffset;
        public Random ySpawnOffset;
        public Alien()
        {
            width = 100;
            height = 100;

            alienRec = new Rectangle(x,y,width,height);
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
            if (side == 1) { y -= 5; alienRec.Location = new Point(x, y); }
            if (side == 2) { x += 5; alienRec.Location = new Point(x, y); }
            if (side == 3) { y += 5; alienRec.Location = new Point(x, y); }
            if (side == 4) { x -= 5; alienRec.Location = new Point(x, y); }

            if (alienRec.Location.X > 660 || alienRec.Location.X < 0)
            {
                
            }
        }

        public void draw(Graphics g)
        {
            g.DrawImage(alienImg, alienRec);
        }
    }
}
