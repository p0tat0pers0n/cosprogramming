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
        public int bombTimer, bombX, bombY, width, height, bomberSpawnSide, startingGameTime;
        // bombTimer - stores how long the bomb has been on screen
        // bombX, bombY - stores where the bomb is so that it can be drawn
        // width, height - defines how large the bomb will be
        // bomberSpawnSide - stores the random number that defines which side the bomber spawns on

        public bool bombGaveDamage;// Stops the bomb from giving damage too many times
        public Rectangle bombRec;// Creates a ectangle for the bomb to be housed in
        public Image bombImg;// Defines an image so the bomb looks good
        public Matrix matrixBomb;// Makes sure the bomb is not rotated in line with the bullets
        Point centreBomb;// Creates a centre so the bomb can be matrix rotated around it
        public Bomb(int leftOrRight, int gameTime)
        {
            // Initial values
            width = 75;
            height = 125;
            startingGameTime = gameTime;
            bombY = 245;
            bombGaveDamage = false;
            bomberSpawnSide = leftOrRight;// Brought from Bomber.cs to decide which side for it to spawn on
            bombTimer = 0;
            bombImg = Properties.Resources.bomb;
            bombRec = new Rectangle(bombX, bombY, width, height);
            makeBomb();
        }

        public void makeBomb()
        {
            // if left or right, spawn there
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

        public void countBombTime()
        {
            bombTimer++;
            if (bombTimer >= 66)// Checks if the bomb has been down long enough before it explodes
            {
                bombImg = Properties.Resources.explosion;// Changes the bomb image to an explosion texture
                bombRec = new Rectangle(bombX, bombY, 150, 150);
            }
        }

        public void drawBomb(Graphics g)
        {   
            if (bombTimer < 67)// Makes sure it does not interfere with the explosion
            {
                //centre bomb 
                centreBomb = new Point(bombX, bombY);
                //instantiate a Matrix object called matrixBomb
                matrixBomb = new Matrix();
                //rotate the matrix (in this case bombRec) about its centre
                matrixBomb.RotateAt(0, centreBomb);
                //Set the current draw location to the rotated matrix point i.e. where bombRec is now
                g.Transform = matrixBomb;
                //Draw the bullet
            }
            if (bombTimer < 76)// Stops drawing the bomb after its exploded
            {
                g.DrawImage(bombImg, bombRec);// Draws the bomb
            }
        }
    }
}
