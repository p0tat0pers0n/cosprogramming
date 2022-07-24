﻿using System;
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
        Player player = new Player();
        Rectangle PlayerRec = new Rectangle();

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

        private void FrmGame_Load(object sender, EventArgs e)
        {
            PlayerRec = new Rectangle(278, 210, 100, 100);
        }

        private void PnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            player.RotatePlayer(e.X, e.Y, PlayerRec, g);
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