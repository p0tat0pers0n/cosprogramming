using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201COS_Game
{
    class Player
    {
        public int x, y, width, height, rotationAngle, mouseX, mouseY;//variables for the rectangle
        public Image player;//variable for the spaceship's image
        public Matrix matrix;
        public Point centre;

        public Rectangle playerRec;//variable for a rectangle to place our image in
       


        //Create a constructor (initialises the values of the fields)
        public Player()
        {
            x = 10;
            y = 350;
            mouseX = 0;
            mouseY = 0;
            rotationAngle = 0;
            width = 73;
            height = 39;
            player = Properties.Resources.Player;
            playerRec = new Rectangle(x, y, width, height);
        }
        public void RotatePlayer()
        {
            rotationAngle = mouseX - mouseY - 15;
        }

        public void MovePlayer()
        {
            playerRec.X = x;
            playerRec.Y = y;
        }

        public void DrawPlayer(Graphics g)
        {
            //find the centre point of spaceRec
            centre = new Point(playerRec.X + width / 2, playerRec.Y + width / 2);
            //instantiate a Matrix object called matrix
            matrix = new Matrix();
            //rotate the matrix (spaceRec) about its centre
            matrix.RotateAt(rotationAngle, centre);
            //Set the current draw location to the rotated matrix point
            g.Transform = matrix;
            g.DrawImage(player, playerRec);
        }
    }
}
