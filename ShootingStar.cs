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
        public int StarX, StarY, StartingGameTime;
        // starX, starY - the location of the star
        int _width, _height, _rotationAngle, _side;
        // width, height - the size of the star
        // _rotationAngle - changes depending on which side it spawns on

        public Rectangle StarRec;// creates rectangle to hold the star -- is public for collision detection with player
        Random _spawnSide, _spawnY;// randoms for if it spawns on left or right and how high it spawns on either side

        Image _starImg = Properties.Resources.shootingStar;// image for the star
        Matrix _matrixStar;// to rotate the star depending on the side it spawns on
        Point _centreStar;// the point where the star rotates around
        public ShootingStar(int _gameTime)
        {
            _width = 75;
            _height = 125;
            _rotationAngle = 90;// default angle
            StartingGameTime = _gameTime;

            _spawnSide = new Random();
            _spawnY = new Random();

            StarY = _spawnY.Next(100, 390);
            _side = _spawnSide.Next(1, 3);
            StarRec = new Rectangle(StarX, StarY, _width, _height);

            newStar();
        }

        public void newStar()
        {
            if (_side == 1)
            {
                //Spawns on left
                _rotationAngle = 90;
                StarX = 0;
            }
            if (_side == 2)
            {
                //Spawns on right
                _rotationAngle = 270;
                StarX = 660;
            }
            StarRec.Location = new Point(StarX, StarY);
        }
        public void moveStar()
        {
            // Moves the star depending on its spawn side e.g. spawns on left so must move right
            if (_side == 1) { StarX += 5; }
            if (_side == 2) { StarX -= 5; }
            StarRec.Location = new Point(StarX, StarY);
        }
        public void drawStar(Graphics g)
        {
            //centre of the star 
            _centreStar = new Point(StarX, StarY);
            //instantiate a Matrix object called _matrixStar
            _matrixStar = new Matrix();
            //rotate the matrix (in this case starRec) about its centre
            _matrixStar.RotateAt(_rotationAngle, _centreStar);
            //Set the current draw location to the rotated matrix point i.e. where starRec is now
            g.Transform = _matrixStar;
            //Draw the star
            g.DrawImage(_starImg, StarRec);
        }
    }
}
