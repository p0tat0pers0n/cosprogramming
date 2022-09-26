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
        // Declarations //
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

            powerUpImg = Properties.Resources.powerupIcon;
            powerUpRec = new Rectangle(ClientSize.Width - 100, ClientSize.Height - 150, 36, 56);

            // Sets double buffering for the game panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });

            // Displays highscore on menubar
            if (File.Exists(pathString))
            {
                string[] saveFileData = System.IO.File.ReadAllLines(pathString);
                MnuHighScore.Text = "Highscore: " + saveFileData[2];
            }
            MessageBox.Show("Please enter a name to begin.\nThen press the start button.", "Instructions");
        }

        private void MnuHighScore_Click(object sender, EventArgs e)
        {
            // The menu button which displays the highscore
            if (File.Exists(pathString))
            {
                string[] resetSaveData = { "null", "0", "0" };
                DialogResult result;
                result = MessageBox.Show("Would you like to reset your save file?", "IMPORTANT", MessageBoxButtons.YesNo); // Checks if save exists and if so asks the player if they want to delete it
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    File.WriteAllLines(pathString, resetSaveData);
                    MnuHighScore.Text = "Highscore: 0";
                }
            }
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // I did this because the title form would not close after closing the game form
            // This also makes sure that all tasks are stopped
            LostGame(true); // This runs the save highscore function without displaying the new highscore text
            System.Environment.Exit(1);
        }

        private void TmrSlowShoot_Tick(object sender, EventArgs e)
        {
            // This function allows you to hold down the left mouse button to shoot slowly compared to clicking rapidly
            if (mouseState && !powerUpStatus && mouseHeldTime > 3)
            {
                bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
            }
        }

        public void LostGame(bool onlyHighscore)
        {
            // This saves the highscore(if it is a highscore) and stops the game
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
            // Shows the powerup icon and turns it off when its over
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
                mouseHeldTime++; // This stops double firing from the inital click and the held down function which would be an exploit
            }
            if (mouseState && powerUpStatus)
            {
                bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y)); // This is the powerup which is gained from the shooting star
            }
            foreach (Bullet b in bullets.ToList())
            {

                foreach (Alien a in aliens.ToList())
                {
                    if (b.bulletRec.IntersectsWith(a.alienRec))
                    {
                        bullets.Remove(b); //Adds score if the bullet touches an alien
                        aliens.Remove(a);
                        score++;
                        LblScore.Text = score.ToString();
                        break;
                    }
                    
                    if (b.bulletRec.Location.X > 660 || b.bulletRec.Location.X < 0)
                    {
                        bullets.Remove(b); // Removes bullets if they leave the screen
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
            if (Regex.IsMatch(playerName, @"^[a-zA-Z0-9]+$")) // Checks if the name contains only letters and numbers
            {
                if (TxtName.Text.Count() > 3 && TxtName.Text != "Please input your name")
                {
                    if (!gameState)// Starts the game
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
            if (gameState) // Pauses the game to play later 
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
            // Generates a bullet when the player clicks
            bullets.Add(new Bullet(PlayerRec, (int)player.angleCalc + 90, player.x, player.y));
            mouseState = true;
        }

        private void PnlGame_MouseUp(object sender, MouseEventArgs e)
        {
            // Stops the firing when the player is not holding down the mouse button
            mouseState = false;
            mouseHeldTime = 0;
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            // Manages the enemy spawn speed and the timer
            timeElapsed++;
            lblTime.Text = timeElapsed.ToString();
            if (TmrEnemySpawn.Interval > 110)
            {
                TmrEnemySpawn.Interval = 1000 - (int)(timeElapsed * 2.5);
            }
        }

        private void TmrEnemySpawn_Tick(object sender, EventArgs e)
        {
            aliens.Add(new Alien()); // Adds an alien every tick and occasionally adds a bomber or shooting star
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
            mouseX = e.X; // Allows the mouse tracking function to work
            mouseY = e.Y;
        }
        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.MoveRotatePlayer(mouseX, mouseY, PlayerRec, g, up, down, left, right); // Moves and rotates the player according to the mouse down and mouse x and y

            if (powerUpStatus)
            {
                g.DrawImage(powerUpImg, powerUpRec); // Draws the powerup icon if its active
            }

            // Draws the bullets, stars, aliens, bombers and bombs if they are on screen
            foreach (Bullet b in bullets)
            {
                b.draw(g);
                b.moveBullet();
            }

            foreach (ShootingStar s in stars.ToList())
            {
                s.drawStar(g);
                s.moveStar();
                if (player.playerRec.IntersectsWith(s.starRec)) // Checks if the player collides with the star and if so gives them the powerup
                {
                    stars.Remove(s);
                    powerUpTime = 0;
                    lives++;
                    powerUpStatus = true;
                    TmrPowerUp.Enabled = true;
                }

                if (s.starRec.Location.X > 660 || s.starRec.Location.X < 0)
                {
                    stars.Remove(s); // Removes the star if its off-screen
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
                    aliens.Remove(a); // Removes the alien if its off-screen and removes a life
                    lives--;
                }
                if (a.alienRec.Location.Y > 490 || a.alienRec.Location.Y < 0)
                {
                    aliens.Remove(a);
                    lives--;
                }

                LblLives.Text = lives.ToString();
                if (lives <= 0 && !endGame) // Checks if the game is over
                {
                    endGame = true;// Makes sure this isn't called multiple times
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
                d.countBombTime();// Starts the countdown for the bomb to explode
                if (d.bombTimer >= 77)
                {
                    bombs.Remove(d); // Removes the bomb after it explodes
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
           if (e.KeyData == Keys.G) { stars.Add(new ShootingStar()); }
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