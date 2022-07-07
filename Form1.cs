using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace _201COS_Game
{
    public partial class FrmGame : Form
    {
        Graphics g; //declare a graphics object called g so we can draw on the Form
        bool up, down, left, right;
        int x, y;
        readonly Player player = new Player();
        Image _Image = Properties.Resources.Player;
        public FrmGame()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
        }

        private void FrmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W) { up = false; }
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.S) { down = false; }
            if (e.KeyData == Keys.D) { right = false; }
        }
        private void PnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            //get the direction of the mouse by looking at the position of the picture box in relation to the mouse pointer
            Vector2 PicPlayerPlane = new Vector2(e.X - PicPlayer.Location.X, e.Y - PicPlayer.Location.Y);

            //https://en.wikipedia.org/wiki/Atan2
            //atan2 - calculates the angle between the x axis and the ray line to a point. gt 0
            //57.2978 is a constant used for radians to degrees conversion (One radian is equal 57.295779513 degrees)
            //https://en.wikipedia.org/wiki/Radian
            float convertToDeg = (float)(180 / Math.PI);

            float angleCalc = (float)(Math.Atan2(PicPlayerPlane.Y, PicPlayerPlane.X) * convertToDeg);

            //dispose the previously drawn image if there was an image (? - null conditional)
            PicPlayer.Image?.Dispose();

            Bitmap calcBitmap = new Bitmap(_Image, PicPlayer.Size.Width, PicPlayer.Size.Height);

            //set picture box 2 to the rotated source image.
            PicPlayer.Image = RotateImage(calcBitmap, angleCalc);
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

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.W) { up = true; }
           if (e.KeyData == Keys.A) { left = true; }
           if (e.KeyData == Keys.S) { down = true; }
           if (e.KeyData == Keys.D) { right = true; }
        }
        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            PicPlayer.Location = new Point(x, y);
            if (up) { y -= 5; PicPlayer.Location = new Point (x,y); }
            if (down) { y += 5; PicPlayer.Location = new Point(x, y); }
            if (left) { x -= 5; PicPlayer.Location = new Point(x, y); }
            if (right) { x += 5; PicPlayer.Location = new Point(x, y); }

            PnlGame.Invalidate();
        }
    }
}