using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Bomber
    {
        public Random spawnSide;
        public int bomberX, bomberY, width, height, leftOrRight;
        public Rectangle bomberRec;
        public Image bomberImg;
        public Matrix matrixBomber;
        Point centreBomber;
        public Bomber()
        {
            width = 125;
            height = 125;
            bomberX = 100;
            bomberY = 490;
            spawnSide = new Random();
            bomberImg = Properties.Resources.taiFighter;
            bomberRec = new Rectangle(bomberX, bomberY, width, height);
            spawnBomber();
        }

        public void spawnBomber()
        {
            leftOrRight = spawnSide.Next(1, 3);
            // Spawns the bomber
            if ( leftOrRight == 1 )
            {
                bomberX = 100;
            }
            if ( leftOrRight == 2)
            {
                bomberX = 500;
            }
            bomberRec.Location = new Point(bomberX, bomberY);
        }

        public void moveBomber()
        {
            bomberY -= 7;
            bomberRec.Location = new Point(bomberX, bomberY);
        }

        public void drawBomber(Graphics g)
        {
            //centre bullet 
            centreBomber = new Point(bomberX, bomberY);
            //instantiate a Matrix object called matrixBomber
            matrixBomber = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixBomber.RotateAt(0, centreBomber);
            //Set the current draw location to the rotated matrix point i.e. where alienRec is now
            g.Transform = matrixBomber;
            //Draw the bullet
            g.DrawImage(bomberImg, bomberRec);
        }
    }
}
