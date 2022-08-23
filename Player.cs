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
        Image _Image;
        public int x, y;
        Bitmap PlayerImg;
        public float angleCalc;
        public Rectangle playerRec;

        //Create a constructor (initialises the values of the fields)
        public Player()
        {
            _Image = Properties.Resources.player2;   
        }
        public void MoveRotatePlayer(float mouseX, float mouseY, Rectangle PlayerRec, Graphics g, bool up, bool down, bool left, bool right)
        {
            if (up) { y -= 5; }
            if (down) { y += 5; }
            if (left) { x -= 5; }
            if (right) { x += 5; }
            playerRec = PlayerRec;

            playerRec.Location = new Point(x, y);

            //get the direction of the mouse by looking at the position of the picture box in relation to the mouse pointer
            Vector2 PicPlayerPlane = new Vector2(mouseX - playerRec.Location.X, mouseY - playerRec.Location.Y);

            //https://en.wikipedia.org/wiki/Atan2
            //atan2 - calculates the angle between the x axis and the ray line to a point. gt 0
            //57.2978 is a constant used for radians to degrees conversion (One radian is equal 57.295779513 degrees)
            //https://en.wikipedia.org/wiki/Radian
            float convertToDeg = (float)(180 / Math.PI);

            angleCalc = (float)(Math.Atan2(PicPlayerPlane.Y - 10, PicPlayerPlane.X - 10) * convertToDeg);

            Bitmap calcBitmap = new Bitmap(_Image, 100, 100);

            //set picture box 2 to the rotated source image.
            PlayerImg = RotateImage(calcBitmap, angleCalc);
            g.DrawImage(PlayerImg, playerRec);
        }

        public Bitmap RotateImage(Bitmap calcBitMap, float angle)
        {
            using (Graphics g = Graphics.FromImage(calcBitMap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)calcBitMap.Width / 2, (float)calcBitMap.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)calcBitMap.Width / 2, -(float)calcBitMap.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(calcBitMap, new PointF(0, 0));
            }
            return calcBitMap;
        }
    }
}
