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
        int mouseX, mouseY, score;
        Player player = new Player();
        Rectangle PlayerRec = new Rectangle();
        List<Bullet> bullets = new List<Bullet>();
        List<Alien> aliens = new List<Alien>();

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

        private void TmrGun_Tick(object sender, EventArgs e)
        {
            foreach (Bullet b in bullets.ToList())
            {

                foreach (Alien a in aliens.ToList())
                {
                    if (b.bulletRec.IntersectsWith(a.alienRec))
                    {
                        bullets.Remove(b);
                        aliens.Remove(a);
                        score++;
                        LblScore.Text = score.ToString();
                        break;
                    }
                    
                    if (b.bulletRec.Location.X > 660 || b.bulletRec.Location.X < 0)
                    {
                        bullets.Remove(b);
                    }
                    if (b.bulletRec.Location.Y > 490 || b.bulletRec.Location.Y < 0)
                    {
                        bullets.Remove(b);
                    }
                    /////////////////////////////////////////////////////////////
                    if (a.alienRec.Location.X > 660 || a.alienRec.Location.X < 0)
                    {
                        aliens.Remove(a);
                    }
                    if (a.alienRec.Location.Y > 490 || a.alienRec.Location.Y < 0)
                    {
                        aliens.Remove(a);
                    }
                }
            }
        }

        private void PnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
        }

        private void PnlGame_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void TmrAlienSpawn_Tick(object sender, EventArgs e)
        {
            aliens.Add(new Alien());
        }

        private void PnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.MoveRotatePlayer(mouseX, mouseY, PlayerRec, g, up, down, left, right);

            foreach (Bullet b in bullets)
            {
                b.draw(g);
                b.moveBullet();
            }

            foreach (Alien a in aliens)
            {
                a.draw(g);
                a.moveAlien();
            }
        }

        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.W) { up = true; }
           if (e.KeyData == Keys.A) { left = true; }
           if (e.KeyData == Keys.S) { down = true; }
           if (e.KeyData == Keys.D) { right = true; }

           if (e.KeyData == Keys.G) { MessageBox.Show(player.x.ToString(), player.y.ToString()); }
        }
        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            //Stops player from going off-screen
            if (player.x > ClientSize.Width - 120) { player.x -= 10; }
            if (player.x < 0) { player.x += 10; }
            if (player.y > ClientSize.Height - 170) { player.y -= 10; }
            if (player.y < 0) { player.y += 10; }

            PnlGame.Invalidate();
        }
    }
}