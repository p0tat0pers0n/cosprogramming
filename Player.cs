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
        Image playerImg;// So it isn't a blank rectangle
        public int x, y;// For movement
        Bitmap PlayerImg;// So it can be modified
        public float angleCalc;// The angle it needs to be rotated
        public Rectangle playerRec;// To allow star collection

        //Create a constructor (initialises the values of the fields)
        public Player()
        {
            playerImg = Properties.Resources.player2;// Sets the player image 
        }
        public void MoveRotatePlayer(float mouseX, float mouseY, Rectangle PlayerRec, Graphics g, bool up, bool down, bool left, bool right)
        {
            // moves the player depending on the bools status
            if (up) { y -= 5; }
            if (down) { y += 5; }
            if (left) { x -= 5; }
            if (right) { x += 5; }
            playerRec = PlayerRec;// Required for the star collection

            playerRec.Location = new Point(x, y);// Sets the player's location

            //get the direction of the mouse by looking at the position of the picture box in relation to the mouse pointer
            Vector2 PicPlayerPlane = new Vector2(mouseX - playerRec.Location.X, mouseY - playerRec.Location.Y);

            //https://en.wikipedia.org/wiki/Atan2
            //atan2 - calculates the angle between the x axis and the ray line to a point. gt 0
            //57.2978 is a constant used for radians to degrees conversion (One radian is equal 57.295779513 degrees)
            //https://en.wikipedia.org/wiki/Radian
            float convertToDeg = (float)(180 / Math.PI);

            angleCalc = (float)(Math.Atan2(PicPlayerPlane.Y - 10, PicPlayerPlane.X - 10) * convertToDeg);// Calculates the angle that the player needs to rotate to point at the cursor

            Bitmap calcBitmap = new Bitmap(playerImg, 100, 100);// Creates a bitmap with the image so it can be manipulated

            PlayerImg = RotateImage(calcBitmap, angleCalc);// Runs the rotate function with the calculated angle
            g.DrawImage(PlayerImg, playerRec);// Draws the player after its been rotated
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
            return calcBitMap;// Returns so it can be used to draw the player
        }
    }
}
