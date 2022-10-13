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
        Random spawnSide; 
        public int bomberX, bomberY, width, height, leftOrRight, startingGameTime;
        // bomberX, bomberY - stores the position of the bomber
        // width, height - the width and height of the bomber
        // leftOrRight - stores which side of the bottom it spawns on
        Rectangle bomberRec;// Rectangle for the bomber to be held in
        Image bomberImg;// Defines the bomber's image
        Matrix matrixBomber;// For rotation of the bomber to avoid it rotating with the bullet
        Point centreBomber;// Centre of the bomber
        public Bomber(int gameTime)
        {
            width = 125;
            height = 125;
            bomberX = 100;
            bomberY = 490;
            startingGameTime = gameTime;
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
                // Left side spawn
                bomberX = 100;
            }
            if ( leftOrRight == 2)
            {
                // Right side spawn
                bomberX = 500;
            }
            bomberRec.Location = new Point(bomberX, bomberY);
        }

        public void moveBomber()
        {
            bomberY -= 7;// Moves up the screen
            bomberRec.Location = new Point(bomberX, bomberY);
        }

        public void drawBomber(Graphics g)
        {
            //centre bomber 
            centreBomber = new Point(bomberX, bomberY);
            //instantiate a Matrix object called matrixBomber
            matrixBomber = new Matrix();
            //rotate the matrix (in this case bomberRec) about its centre
            matrixBomber.RotateAt(0, centreBomber);
            //Set the current draw location to the rotated matrix point i.e. where bomberRec is now
            g.Transform = matrixBomber;
            //Draw the bomber
            g.DrawImage(bomberImg, bomberRec);
        }
    }
}
