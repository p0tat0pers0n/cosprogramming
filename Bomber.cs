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
        Random spawnSide, spawnChance;
        int bomberX, bomberY, width, height;
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
            bomberRec = new Rectangle(bomberX, bomberY, bomberX, bomberY);
            spawnBomber();
        }

        public void spawnBomber()
        {
            // Spawns the bomber
            if (spawnSide.Next(1,2) == 1 )
            {
                bomberX = 150;
            }
            if (spawnSide.Next(1, 2) == 2)
            {
                bomberX = 450;
            }
        }

        public void moveBomber()
        {
            bomberY -= 5;
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
