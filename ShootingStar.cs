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
        public int starX, starY, width, height, rotationAngle, side;
        // starX, starY - the location of the star
        // width, height - the size of the star
        // rotationAngle - changes depending on which side it spawns on

        public Rectangle starRec;
        Random spawnSide, spawnY;
        Image starImg = Properties.Resources.shootingStar;
        public Matrix matrixStar;
        Point centreStar;
        public ShootingStar()
        {
            width = 75;
            height = 125;
            rotationAngle = 90;

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
            if (side == 1) { starX += 5; }
            if (side == 2) { starX -= 5; }
            starRec.Location = new Point(starX, starY);
        }
        public void drawStar(Graphics g)
        {
            //centre bullet 
            centreStar = new Point(starX, starY);
            //instantiate a Matrix object called matrixBomber
            matrixStar = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixStar.RotateAt(rotationAngle, centreStar);
            //Set the current draw location to the rotated matrix point i.e. where alienRec is now
            g.Transform = matrixStar;
            //Draw the bullet
            g.DrawImage(starImg, starRec);
        }
    }
}
