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
        public int BombTimer, BombX, BombY, StartingGameTime;
        // bombTimer - stores how long the bomb has been on screen
        // BombX, BombY - stores where the bomb is so that it can be drawn
        // bomberSpawnSide - stores the random number that defines which side the bomber spawns on

        int _width, _height, _bomberSpawnSide;
        // width, height - defines how large the bomb will be

        public bool BombGaveDamage;// Stops the bomb from giving damage too many times

        public Rectangle BombRec;// Creates a ectangle for the bomb to be housed in
        Image _bombImg;// Defines an image so the bomb looks good
        Matrix _matrixBomb;// Makes sure the bomb is not rotated in line with the bullets
        Point _centreBomb;// Creates a centre so the bomb can be matrix rotated around it
        public Bomb(int LeftOrRight, int _gameTime)
        {
            // Initial values
            _width = 75;
            _height = 125;
            StartingGameTime = _gameTime;
            BombY = 245;
            BombGaveDamage = false;
            _bomberSpawnSide = LeftOrRight;// Brought from Bomber.cs to decide which side for it to spawn on
            BombTimer = 0;
            _bombImg = Properties.Resources.bomb;
            BombRec = new Rectangle(BombX, BombY, _width, _height);
            makeBomb();
        }

        public void makeBomb()
        {
            // if left or right, spawn there
            if (_bomberSpawnSide == 1)
            {
                BombX = 100;
            }
            if (_bomberSpawnSide == 2)
            {
                BombX = 500;
            }
            BombRec.Location = new Point(BombX, BombY);
        }

        public void countBombTime()
        {
            BombTimer++;
            if (BombTimer >= 66)// Checks if the bomb has been down long enough before it explodes
            {
                _bombImg = Properties.Resources.explosion;// Changes the bomb image to an explosion texture
                BombRec = new Rectangle(BombX, BombY, 150, 150);
            }
        }

        public void drawBomb(Graphics g)
        {   
            // Ensures the bomb does not rotate with the bullets
            //centre bomb 
            _centreBomb = new Point(BombX, BombY);
            //instantiate a Matrix object called _matrixBomb
            _matrixBomb = new Matrix();
            //rotate the matrix (in this case BombRec) about its centre
            _matrixBomb.RotateAt(0, _centreBomb);
            //Set the current draw location to the rotated matrix point i.e. where BombRec is now
            g.Transform = _matrixBomb;
            //Draw the bullet
            if (BombTimer < 76)// Stops drawing the bomb after its exploded
            {
                g.DrawImage(_bombImg, BombRec);// Draws the bomb
            }
        }
    }
}
