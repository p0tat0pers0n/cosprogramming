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
        Random _spawnSide; 
        int _width, _height;
        // width, height - the width and height of the bomber
        
        public int BomberX, BomberY, LeftOrRight, StartingGameTime;
        // bomberX, bomberY - stores the position of the bomber
        // LeftOrRight - stores which side of the bottom it spawns on

        Rectangle _bomberRec;// Rectangle for the bomber to be held in
        Image _bomberImg;// Defines the bomber's image
        Matrix _matrixBomber;// For rotation of the bomber to avoid it rotating with the bullet
        Point _centreBomber;// Centre of the bomber
        public Bomber(int gameTime)
        {
            _width = 125;
            _height = 125;
            BomberX = 100;
            BomberY = 490;
            StartingGameTime = gameTime;
            _spawnSide = new Random();
            _bomberImg = Properties.Resources.taiFighter;
            _bomberRec = new Rectangle(BomberX, BomberY, _width, _height);
            spawnBomber();
        }

        public void spawnBomber()
        {
            LeftOrRight = _spawnSide.Next(1, 3);
            // Spawns the bomber
            if ( LeftOrRight == 1 )
            {
                // Left side spawn
                BomberX = 100;
            }
            if ( LeftOrRight == 2 )
            {
                // Right side spawn
                BomberX = 500;
            }
            _bomberRec.Location = new Point(BomberX, BomberY);
        }

        public void moveBomber()
        {
            BomberY -= 7;// Moves up the screen
            _bomberRec.Location = new Point(BomberX, BomberY);
        }

        public void drawBomber(Graphics g)
        {
            //centre bomber 
            _centreBomber = new Point(BomberX, BomberY);
            //instantiate a Matrix object called _matrixBomber
            _matrixBomber = new Matrix();
            //rotate the matrix (in this case bomberRec) about its centre
            _matrixBomber.RotateAt(0, _centreBomber);
            //Set the current draw location to the rotated matrix point i.e. where bomberRec is now
            g.Transform = _matrixBomber;
            //Draw the bomber
            g.DrawImage(_bomberImg, _bomberRec);
        }
    }
}
