using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _201COS_Game
{
    class Bullet
    {
        public Rectangle BulletRec;
        Image _bulletImg;
        public int StartingGameTime;
        int _bulletRotated, _bulletX, _bulletY, _width, _height;
        double _xSpeed, _ySpeed;
        Matrix _matrixBullet;//matrix to enable us to rotate bullet in the same angle as the player
        Point _centreBullet;//centre of bullet

        public Bullet(Rectangle _playerRec, int _bulletRotate, int _playerX, int _playerY, int _gameTime)
        {
            _bulletX = _playerRec.X + 37; // move bullet to middle of player
            _bulletY = _playerRec.Y;
            _width = 10;
            _height = 60;
            _bulletImg = Properties.Resources.newbullet;
            StartingGameTime = _gameTime;
            BulletRec = new Rectangle(_playerX+50, _playerY+50, _width, _height);

            //this code works out the speed of the bullet to be used in the moveBullet method
            _xSpeed = 30 * (Math.Cos((_bulletRotate - 90) * Math.PI / 180));
            _ySpeed = 30 * (Math.Sin((_bulletRotate + 90) * Math.PI / 180));
            //calculate x,y to move bullet to middle of spaceship in drawBullet method
            _bulletX = _playerX + _playerRec.Width / 2;
            _bulletY = _playerY + _playerRec.Height / 2;
            //pass _bulletRotate angle to bulletRotated so that it can be used in the drawBullet method
            _bulletRotated = _bulletRotate;
        }

        public void draw(Graphics g)
        {
            //centre bullet 
            _centreBullet = new Point(_bulletX, _bulletY);
            //instantiate a Matrix object called matrixBullet
            _matrixBullet = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            _matrixBullet.RotateAt(_bulletRotated, _centreBullet);
            //Set the current draw location to the rotated matrix point i.e. where bulletRec is now
            g.Transform = _matrixBullet;
            //Draw the bullet
            g.DrawImage(_bulletImg, BulletRec);
        }

        public void moveBullet()
        {
            _bulletX += (int)_xSpeed;//cast double to an integer value
            _bulletY -= (int)_ySpeed;
            BulletRec.Location = new Point(_bulletX, _bulletY);//bullets new location
        }
    }
}
