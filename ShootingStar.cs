using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class ShootingStar
    {
        public int starX, starY, width, height, rotationAngle, side, startingGameTime;
        // starX, starY - the location of the star
        // width, height - the size of the star
        // rotationAngle - changes depending on which side it spawns on

        public Rectangle starRec;// creates rectangle to hold the star -- is public for collision detection with player
        Random spawnSide, spawnY;// randoms for if it spawns on left or right and how high it spawns on either side
        Image starImg = Properties.Resources.shootingStar;// image for the star
        public Matrix matrixStar;// to rotate the star depending on the side it spawns on
        Point centreStar;// the point where the star rotates around
        public ShootingStar(int gameTime)
        {
            width = 75;
            height = 125;
            rotationAngle = 90;// default angle
            startingGameTime = gameTime;

            spawnSide = new Random();
            spawnY = new Random();

            starY = spawnY.Next(100, 390);
            side = spawnSide.Next(1, 3);
            starRec = new Rectangle(starX, starY, width, height);

            newStar();
        }

        public void newStar()
        {
            if (side == 1)
            {
                //Spawns on left
                rotationAngle = 90;
                starX = 0;
            }
            if (side == 2)
            {
                //Spawns on right
                rotationAngle = 270;
                starX = 660;
            }
            starRec.Location = new Point(starX, starY);
        }
        public void moveStar()
        {
            // Moves the star depending on its spawn side e.g. spawns on left so must move right
            if (side == 1) { starX += 5; }
            if (side == 2) { starX -= 5; }
            starRec.Location = new Point(starX, starY);
        }
        public void drawStar(Graphics g)
        {
            //centre of the star 
            centreStar = new Point(starX, starY);
            //instantiate a Matrix object called matrixStar
            matrixStar = new Matrix();
            //rotate the matrix (in this case starRec) about its centre
            matrixStar.RotateAt(rotationAngle, centreStar);
            //Set the current draw location to the rotated matrix point i.e. where starRec is now
            g.Transform = matrixStar;
            //Draw the star
            g.DrawImage(starImg, starRec);
        }
    }
}
