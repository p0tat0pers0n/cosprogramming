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
        bool up, down, left, right, endGame, gameState;
        int mouseX, mouseY, score, timeElapsed, lives;
        Player player = new Player();
        Random spawnChance = new Random();
        Rectangle PlayerRec = new Rectangle();
        List<Bullet> bullets = new List<Bullet>();
        List<Alien> aliens = new List<Alien>();
        List<Bomber> bombers = new List<Bomber>();
        List<Bomb> bombs = new List<Bomb>();


        public FrmGame()
        {
            InitializeComponent();
            lives = 10;
            gameState = false;
            MnuPause.Enabled = false;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
        }

        public void LostGame()
        {
            TmrEnemySpawn.Enabled = false;
            TmrGun.Enabled = false;
            TmrPlayer.Enabled = false;
            TmrTime.Enabled = false;
            MessageBox.Show("You lost\nWith a time of: " + timeElapsed.ToString() + " seconds\nAnd " + score.ToString() + " kills", "Game End");
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
                        lives++;
                        score++;
                        LblScore.Text = score.ToString();
                        LblLives.Text = lives.ToString();
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
                }
            }
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Count() > 3 && TxtName.Text != "Please input your name")
            {
                if (!gameState)
                {
                    TmrEnemySpawn.Enabled = true;
                    TmrGun.Enabled = true;
                    TmrPlayer.Enabled = true;
                    TmrTime.Enabled = true;
                }
                MnuStart.Enabled = false;
                MnuPause.Enabled = true;
                gameState = true;
                TxtName.Enabled = false;
            }else
            {
                MessageBox.Show("Please enter a name", "oops");
            }
        }

        private void MnuPause_Click(object sender, EventArgs e)
        {
            if (gameState)
            {
                TmrEnemySpawn.Enabled = false;
                TmrGun.Enabled = false;
                TmrPlayer.Enabled = false;
                TmrTime.Enabled = false;
            }
            MnuPause.Enabled = false;
            MnuStart.Enabled = true;
            gameState = false;
            TxtName.Enabled = true;
        }

        private void PnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
        }

        private void PnlGame_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            lblTime.Text = timeElapsed.ToString();
            TmrEnemySpawn.Interval = 1000 - timeElapsed * 2;
        }

        private void TmrEnemySpawn_Tick(object sender, EventArgs e)
        {
            aliens.Add(new Alien());
            if (spawnChance.Next(1, 10) == 1)
            {
                bombers.Add(new Bomber());
            }
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

            foreach (Alien a in aliens.ToList())
            {
                a.draw(g);
                a.moveAlien();

                /////////////////////////////////////////////////////////////
                if (a.alienRec.Location.X > 660 || a.alienRec.Location.X < 0)
                {
                    aliens.Remove(a);
                    lives--;
                }
                if (a.alienRec.Location.Y > 490 || a.alienRec.Location.Y < 0)
                {
                    aliens.Remove(a);
                    lives--;
                }

                LblLives.Text = lives.ToString();
                if (lives <= 0 && !endGame)
                {
                    endGame = true;
                    LostGame();
                }
            }

            foreach (Bomber t in bombers.ToList())
            {
                t.moveBomber();
                t.drawBomber(g);

                if (t.bomberY >= 225 && t.bomberY <= 245)
                {
                    bombs.Add(new Bomb(t.leftOrRight));
                }
            }

            foreach (Bomb d in bombs.ToList())
            {
                d.drawBomb(g);
                d.countBombTime();
                if (d.bombTimer >= 77)
                {
                    bombs.Remove(d);
                }

                foreach (Alien a in aliens.ToList())
                {
                    if (d.bombRec.IntersectsWith(a.alienRec) && d.bombTimer >= 66)
                    {
                        aliens.Remove(a);
                    }
                }
            }
        }

        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.W) { up = true; }
           if (e.KeyData == Keys.A) { left = true; }
           if (e.KeyData == Keys.S) { down = true; }
           if (e.KeyData == Keys.D) { right = true; }

           if (e.KeyData == Keys.G) { lives = 500; LblLives.Text = lives.ToString(); }
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