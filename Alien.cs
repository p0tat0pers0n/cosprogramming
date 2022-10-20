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
        public Rectangle AlienRec;// Defines the rectangle for the alien
        public int StartingGameTime;

        int _alienX, _alienY, _width, _height, _side, _xSpawn, _ySpawn;
        // _alienX, _alienY - Stores where the alien is
        // width, height - Stores how large the alien is going to be
        // _side - Stores which _side the alien will be on/where it moves
        // xSpawn, ySpawn - Stores the random number where the alien spawns

        Image _alienImg;
        Random _sideChance;// Stores its result in the int _side to decide which _side it spawns on or moves
        Random _xSpawnOffset;// If it spawns on the top or bottom where will it spawn along it
        Random _ySpawnOffset;// If it spawns on the left or right where will it spawn along it
        Matrix _matrixAlien;// Stops the alien from being rotated due to the bullets
        Point _centreAlien;// Creates a centre for the alien to rotate around
        public Alien(int _gameTime)
        {
            _width = 75;
            _height = 75;
            StartingGameTime = _gameTime;
            AlienRec = new Rectangle(_alienX, _alienY, _width, _height);
            _alienImg = Properties.Resources.alien;
            _sideChance = new Random();
            _xSpawnOffset = new Random();
            _ySpawnOffset = new Random();
            newAlien();
        }

        public void newAlien()
        {
            // Randomises the side that it spawns on and the x and y spawn offset
            _xSpawn = _xSpawnOffset.Next(50, 600);
            _ySpawn = _ySpawnOffset.Next(50, 390);
            _side = _sideChance.Next(1, 5);

            if (_side == 1)
            {
                //spawns on top going down
                _alienX = _xSpawn;
                _alienY = 10;
                AlienRec.Location = new Point(_xSpawn, 10);
            }
            if (_side == 2)
            {
                //spawns on right going left
                _alienX = 650;
                _alienY = _ySpawn;
                AlienRec.Location = new Point(650, _ySpawn);
            }
            if (_side == 3)
            {
                //spawns on bottom going up
                _alienX = _xSpawn;
                _alienY = 450;
                AlienRec.Location = new Point(_xSpawn, 450);
            }
            if (_side == 4)
            {
                //spawns on left going right
                _alienX = 10;
                _alienY = _ySpawn;
                AlienRec.Location = new Point(10, _ySpawn);
            }
        }

        public void moveAlien()
        {
            // Moves the alien depending on its spawn side
            if (_side == 1) { _alienY += 5; }
            if (_side == 2) { _alienX -= 5; }
            if (_side == 3) { _alienY -= 5; }
            if (_side == 4) { _alienX += 5; }
            AlienRec.Location = new Point(_alienX, _alienY);
        }

        public void draw(Graphics g)
        {
            //centre bullet 
            _centreAlien = new Point(_alienX, _alienY);
            //instantiate a Matrix object called matrixAlien
            _matrixAlien = new Matrix();
            //rotate the matrix (in this case AlienRec) about its centre
            _matrixAlien.RotateAt(0, _centreAlien);
            //Set the current draw location to the rotated matrix point i.e. where AlienRec is now
            g.Transform = _matrixAlien;
            //Draw the bullet
            g.DrawImage(_alienImg, AlienRec);
        }
    }
}