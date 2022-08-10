using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Bomb
    {
        int bombTimer, bombX, bombY, width, height, bomberSpawnSide;
        public Rectangle bombRec;
        public Image bombImg;
        public Matrix matrixBomb;
        Point centreBomb;
        public Bomb(int leftOrRight)
        {
            width = 75;
            height = 125;
            bombY = 245;
            bomberSpawnSide = leftOrRight;
            bombTimer = 0;
            bombImg = Properties.Resources.bomb;
            bombRec = new Rectangle(bombX, bombY, width, height);
            makeBomb();
        }

        public void makeBomb()
        {
            if (bomberSpawnSide == 1)
            {
                bombX = 100;
            }
            if (bomberSpawnSide == 2)
            {
                bombX = 500;
            }
            bombRec.Location = new Point(bombX, bombY);
        }

        public void drawBomb(Graphics g)
        {
            //centre bullet 
            centreBomb = new Point(bombX, bombY);
            //instantiate a Matrix object called matrixBomber
            matrixBomb = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixBomb.RotateAt(0, centreBomb);
            //Set the current draw location to the rotated matrix point i.e. where alienRec is now
            g.Transform = matrixBomb;
            //Draw the bullet
            g.DrawImage(bombImg, bombRec);
        }
    }
}
