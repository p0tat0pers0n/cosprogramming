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
        public Rectangle alienRec;// Defines the rectangle for the alien
        public int alienX,alienY,width,height,side,xSpawn,ySpawn,startingGameTime;
        // alienX, alienY - Stores where the alien is
        // width, height - Stores how large the alien is going to be
        // side - Stores which side the alien will be on/where it moves

        Image alienImg;
        Random sideChance;// Stores its result in the int side to decide which side it spawns on or moves
        Random xSpawnOffset;// If it spawns on the top or bottom where will it spawn along it
        Random ySpawnOffset;// If it spawns on the left or right where will it spawn along it
        Matrix matrixAlien;// Stops the alien from being rotated due to the bullets
        Point centreAlien;// Creates a centre for the alien to rotate around
        public Alien(int gameTime)
        {
            width = 75;
            height = 75;
            startingGameTime = gameTime;
            alienRec = new Rectangle(alienX,alienY,width,height);
            alienImg = Properties.Resources.alien;
            sideChance = new Random();
            xSpawnOffset = new Random();
            ySpawnOffset = new Random();
            newAlien();
        }

        public void newAlien()
        {
            // Randomises the side that it spawns on and the x and y spawn offset
            xSpawn = xSpawnOffset.Next(50, 600);
            ySpawn = ySpawnOffset.Next(50, 390);
            side = sideChance.Next(1, 5);

            if (side == 1)
            {
                //spawns on top going down
                alienX = xSpawn;
                alienY = 10;
                alienRec.Location = new Point(xSpawn, 10);
            }
            if (side == 2)
            {
                //spawns on right going left
                alienX = 650;
                alienY = ySpawn;
                alienRec.Location = new Point(650, ySpawn);
            }
            if (side == 3)
            {
                //spawns on bottom going up
                alienX = xSpawn;
                alienY = 450;
                alienRec.Location = new Point(xSpawn, 450);
            }
            if (side == 4)
            {
                //spawns on left going right
                alienX = 10;
                alienY = ySpawn;
                alienRec.Location = new Point(10, ySpawn);
            }
        }

        public void moveAlien()
        {
            // Moves the alien depending on its spawn side
            if (side == 1) { alienY += 5; }
            if (side == 2) { alienX -= 5; }
            if (side == 3) { alienY -= 5; }
            if (side == 4) { alienX += 5; }
            alienRec.Location = new Point(alienX, alienY);
        }

        public void draw(Graphics g)
        {
            //centre bullet 
            centreAlien = new Point(alienX, alienY);
            //instantiate a Matrix object called matrixAlien
            matrixAlien = new Matrix();
            //rotate the matrix (in this case alienRec) about its centre
            matrixAlien.RotateAt(0, centreAlien);
            //Set the current draw location to the rotated matrix point i.e. where alienRec is now
            g.Transform = matrixAlien;
            //Draw the bullet
            g.DrawImage(alienImg, alienRec);
        }
    }
}
