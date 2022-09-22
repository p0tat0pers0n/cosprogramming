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
using System.IO;
using System.Text.RegularExpressions;

namespace _201COS_Game
{
    public partial class FrmGame : Form
    {
        Graphics g; //declare a graphics object called g so we can draw on the Form
        bool up, down, left, right, endGame, gameState, powerUpStatus, mouseState, afkTimerCheck, isAFK;
        int mouseX, mouseY, score, timeElapsed, lives, powerUpTime, mouseHeldTime, afkTimer, blinkCD;
        string filePath, fileName, pathString, playerName;
        Player player = new Player();
        Random bomberChance = new Random(369523922);
        Random starChance = new Random(58489772);
        Rectangle powerUpRec;
        Image powerUpImg;

        Rectangle PlayerRec = new Rectangle();
        List<Bullet> bullets = new List<Bullet>();
        List<Alien> aliens = new List<Alien>();
        List<Bomber> bombers = new List<Bomber>();
        List<Bomb> bombs = new List<Bomb>();
        List<ShootingStar> stars = new List<ShootingStar>();

        public FrmGame()
        {
            InitializeComponent();
            lives = 10;
            afkTimer = 0;
            blinkCD = 0;
            gameState = false;
            MnuPause.Enabled = false;
            filePath = @"H:\";
            fileName = "angrynerdssave.txt";
            pathString = System.IO.Path.Combine(filePath, fileName);

            powerUpImg = Properties.Resources.fireyfirearm;
            powerUpRec = new Rectangle(ClientSize.Width - 100, ClientSize.Height - 150, 75, 75);

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });

            //displays highscore on menubar
            if (File.Exists(pathString))
            {
                string[] saveFileData = System.IO.File.ReadAllLines(pathString);
                MnuHighScore.Text = "Highscore: " + saveFileData[2];
            }
        }

        private void MnuHighScore_Click(object sender, EventArgs e)
        {
            if (File.Exists(pathString))
            {
                string[] resetSaveData = { "null", "0", "0" };
                DialogResult result;
                result = MessageBox.Show("Would you like to reset your save file?", "IMPORTANT", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    File.WriteAllLines(pathString, resetSaveData);
                    MnuHighScore.Text = "Highscore: 0";
                }
            }
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            LostGame(true);
            System.Environment.Exit(1);
        }

        private void TmrSlowShoot_Tick(object sender, EventArgs e)
        {
            if (mouseState && !powerUpStatus && mouseHeldTime > 3)
            {
                bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
            }
        }

        public void LostGame(bool onlyHighscore)
        {
            TmrEnemySpawn.Enabled = false;
            TmrGun.Enabled = false;
            TmrPlayer.Enabled = false;
            TmrTime.Enabled = false;
            if (!onlyHighscore) { MessageBox.Show("You lost\nWith a time of: " + timeElapsed.ToString() + " seconds\nAnd " + score.ToString() + " kills", "Game End"); }

            if (score != 0)
            {
                string[] saveData = { playerName, timeElapsed.ToString(), score.ToString() };
                if (File.Exists(pathString))
                {
                    string[] oldSaveData = System.IO.File.ReadAllLines(pathString);

                    //Checks if the score is greater than before
                    if (Convert.ToInt32(oldSaveData[2]) < Convert.ToInt32(saveData[2]))
                    {
                        //High score saving
                        File.WriteAllLines(pathString, saveData);
                        if (!onlyHighscore) { MessageBox.Show("Congratulations!\nYou've gotten a new highscore of: " + score.ToString() + " kills in " + timeElapsed.ToString() + " seconds", "New Highscore!"); }
                    }
                }else
                {
                    File.WriteAllLines(pathString, saveData);
                }
            }
            Application.Exit();
        }

        private void FrmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W) { up = false; }
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.S) { down = false; }
            if (e.KeyData == Keys.D) { right = false; }
            afkTimerCheck = false;
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            PlayerRec = new Rectangle(278, 210, 100, 100);
        }

        private void TmrPowerUp_Tick(object sender, EventArgs e)
        {
            powerUpTime++;
            if (powerUpTime == 10)
            {
                powerUpStatus = false;
                TmrPowerUp.Enabled = false;
            }
        }

        private void TmrGun_Tick(object sender, EventArgs e)
        {
            if (mouseState)
            {
                mouseHeldTime++;
            }
            if (mouseState && powerUpStatus)
            {
                bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
            }
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
                }
            }
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            playerName = TxtName.Text;
            if (Regex.IsMatch(playerName, @"^[a-zA-Z0-9]+$"))
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
                }
            }else
            {
                MessageBox.Show("Please enter a name\nWith only letters and numbers(no spaces)", "oops");
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
            mouseState = true;
        }

        private void PnlGame_MouseUp(object sender, MouseEventArgs e)
        {
            mouseState = false;
            mouseHeldTime = 0;
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            lblTime.Text = timeElapsed.ToString();
            if (TmrEnemySpawn.Interval > 110)
            {
                TmrEnemySpawn.Interval = 1000 - (int)(timeElapsed * 2.5);
            }
        }

        private void TmrEnemySpawn_Tick(object sender, EventArgs e)
        {
            aliens.Add(new Alien());
            if (bomberChance.Next(1, 10) == 1)
            {
                bombers.Add(new Bomber());
            }
            if (starChance.Next(1, 20) == 3)
            {
                stars.Add(new ShootingStar());
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

            if (powerUpStatus)
            {
                g.DrawImage(powerUpImg, powerUpRec);
            }

            foreach (Bullet b in bullets)
            {
                b.draw(g);
                b.moveBullet();
            }

            foreach (ShootingStar s in stars.ToList())
            {
                s.drawStar(g);
                s.moveStar();
                if (player.playerRec.IntersectsWith(s.starRec))
                {
                    stars.Remove(s);
                    powerUpTime = 0;
                    lives++;
                    powerUpStatus = true;
                    TmrPowerUp.Enabled = true;
                }

                if (s.starRec.Location.X > 660 || s.starRec.Location.X < 0)
                {
                    stars.Remove(s);
                }
                if (s.starRec.Location.Y > 490 || s.starRec.Location.Y < 0)
                {
                    stars.Remove(s);
                }
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
                    LostGame(false);
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

                if (d.bombRec.IntersectsWith(player.playerRec) && d.bombTimer >= 66 && d.bombGaveDamage == false)
                {
                    d.bombGaveDamage = true;
                    lives--;
                }
            }
        }

        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.W) { up = true; }
           if (e.KeyData == Keys.A) { left = true; }
           if (e.KeyData == Keys.S) { down = true; }
           if (e.KeyData == Keys.D) { right = true; }
           if (!afkTimerCheck) { afkTimer = 0; afkTimerCheck = true; isAFK = false; }
        }
        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            //Stops player from going off-screen
            if (player.x > ClientSize.Width - 120) { player.x -= 10; }
            if (player.x < 0) { player.x += 10; }
            if (player.y > ClientSize.Height - 170) { player.y -= 10; }
            if (player.y < 0) { player.y += 10; }

            PnlGame.Invalidate();
            afkTimer++;
            blinkCD++;
            if (afkTimer >= 450)
            {
                isAFK = true;
                lives--;
                afkTimer = 375;
            }
            if (blinkCD == 50 && isAFK)
            {
                TextMove.Visible = true;
            }else if (blinkCD == 100)
            {
                TextMove.Visible = false;
                blinkCD = 0;
            }
        }
    }
}