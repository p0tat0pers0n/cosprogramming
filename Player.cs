using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201COS_Game
{
    class Player
    {
        Image _playerImg;// So it isn't a blank rectangle
        public int X, Y;// For movement
        Bitmap _playerBitmap;// So it can be modified
        public float AngleCalc;// The angle it needs to be rotated

        //Create a constructor (initialises the values of the fields)
        public Player()
        {
            X = 280;
            Y = 210;
            _playerImg = Properties.Resources.player2;// Sets the player image 
        }
        public void MoveRotatePlayer(Rectangle PlayerRec, float _mouseX, float _mouseY, Graphics g)
        {
            PlayerRec.Location = new Point(X, Y);// Sets the player's location

            //get the direction of the mouse by looking at the position of the picture box in relation to the mouse pointer
            Vector2 _picPlayerPlane = new Vector2(_mouseX - PlayerRec.Location.X, _mouseY - PlayerRec.Location.Y);

            //https://en.wikipedia.org/wiki/Atan2
            //atan2 - calculates the angle between the x axis and the ray line to a point. gt 0
            //57.2978 is a constant used for radians to degrees conversion (One radian is equal 57.295779513 degrees)
            //https://en.wikipedia.org/wiki/Radian
            float _convertToDeg = (float)(180 / Math.PI);

            AngleCalc = (float)(Math.Atan2(_picPlayerPlane.Y - 10, _picPlayerPlane.X - 10) * _convertToDeg);// Calculates the angle that the player needs to rotate to point at the cursor

            Bitmap _calcBitmap = new Bitmap(_playerImg, 100, 100);// Creates a bitmap with the image so it can be manipulated

            _playerBitmap = RotateImage(_calcBitmap, AngleCalc);// Runs the rotate function with the calculated angle
            g.DrawImage(_playerBitmap, PlayerRec);// Draws the player after its been rotated
        }

        public Bitmap RotateImage(Bitmap _calcBitMap, float _angle)
        {
            using (Graphics g = Graphics.FromImage(_calcBitMap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)_calcBitMap.Width / 2, (float)_calcBitMap.Height / 2);
                //rotate
                g.RotateTransform(_angle);
                //move image back
                g.TranslateTransform(-(float)_calcBitMap.Width / 2, -(float)_calcBitMap.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(_calcBitMap, new PointF(0, 0));
            }
            return _calcBitMap;// Returns so it can be used to draw the player
        }
    }
}
