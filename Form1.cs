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
        //       Declarations       //

        Graphics g; //declare a graphics object called g so we can draw on the Form
        bool up, down, left, right, endGame, gameState, powerUpStatus, mouseState, afkTimerCheck, isAFK;
        // up, down, left and right - used for moving the player inside Player.cs
        // endGame - stores when the game is over so it does not spam messageboxes
        // gameState - stores whether the game is active or yet to be started
        // powerUpStatus - stores whether the powerUp is active
        // mouseState - used for the powerup and the slower mouse hold shooting
        // afkTimerCheck - this stops the player from being able to hold down a button to stop the "campfire"
        // isAFK - stores whether or not the player has been standing still

        int mouseX, mouseY, score, timeElapsed, lives, powerUpTime, mouseHeldTime, afkTimer, blinkCoolDown;
        // mouseX, mouseY - sets the mouse x and y for use in the cursor rotation tracking
        // score - to hold the player's current score
        // timeElapsed - stores the amount of time that the player has spent in the game (seconds)
        // lives - stores the number of lives that the player has
        // powerUpTime - for turning off the power up when 10 seconds has passed
        // mouseHeldTime - stores how long the mouse is held down for the slow shoot function to avoid a double fire for every single click
        // afkTimer - stores how long since the player has pressed and released a keyboard button
        // blinkCoolDown - stops the move text from blinking too often

        string filePath, fileName, pathString, playerName;
        // filePath - stores where the highscore save file is going
        // fileName - defines what the file's name is going to be
        // pathString - stores a combination of the filePath and the fileName for easy saving

        Player player = new Player();// creates a new instance of the player class

        Random bomberChance = new Random(369523922);// Defines the random number for bomber chance and its seed number
        Random starChance = new Random(58489772);// Defines the random number for shooting star chance and its seed number
        // ^ These seed numbers are different because if they were the same(or not defined at all) they can often spawn at the same time ^ \\
        
        Rectangle powerUpRec;// Defines the powerup rectangle
        Image powerUpImg;// Defines the powerup image
        Rectangle PlayerRec = new Rectangle();// Sets the rectangle for the player

        // Lists to create more than one instance of the class
        List<Bullet> bullets = new List<Bullet>();
        List<Alien> aliens = new List<Alien>();
        List<Bomber> bombers = new List<Bomber>();
        List<Bomb> bombs = new List<Bomb>();
        List<ShootingStar> stars = new List<ShootingStar>();

        public FrmGame()
        {
            InitializeComponent();
            // Initial declarations
            lives = 10;
            afkTimer = 0;
            blinkCoolDown = 0;
            gameState = false;
            MnuPause.Enabled = false;

            // Prepares highscore saving
            filePath = @"H:\";
            fileName = "angrynerdssave.txt";
            pathString = System.IO.Path.Combine(filePath, fileName);

            powerUpImg = Properties.Resources.powerupIcon;// Sets the powerup icon image
            powerUpRec = new Rectangle(ClientSize.Width - 100, ClientSize.Height - 150, 36, 56);// Creates the rectangle to hold the powerup icon

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
                string[] resetSaveData = { "null", "0", "0" };// Sets the data to overwrite the current save file
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
                // Adds a bullet with the following information
                // PlayerRec - for getting the player width and height
                // player.angleCalc - for rotating the bullet when the player is rotated
                // player.x and player.y - For getting the spawn-in position for the bullets
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
            // ^ This avoids the highscore message from showing when the game is force closed

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
                    lives++;// Star gives a life
                    powerUpStatus = true;
                    TmrPowerUp.Enabled = true;// Counts how long the powerup is active
                }

                if (s.starRec.Location.X > 660 || s.starRec.Location.X < 0)
                {
                    stars.Remove(s);// Removes the star if its off-screen
                }
                if (s.starRec.Location.Y > 490 || s.starRec.Location.Y < 0)
                {
                    stars.Remove(s);// Removes the star if its off-screen
                }
            }

            foreach (Alien a in aliens.ToList())
            {
                a.draw(g);
                a.moveAlien();

                /////////////////////////////////////////////////////////////
                if (a.alienRec.Location.X > 660 || a.alienRec.Location.X < 0)
                {
                    aliens.Remove(a);// Removes the alien if its off-screen and removes a life
                    lives--;
                }
                if (a.alienRec.Location.Y > 490 || a.alienRec.Location.Y < 0)
                {
                    aliens.Remove(a);// Removes the alien if its off-screen and removes a life
                    lives--;
                }

                LblLives.Text = lives.ToString();
                if (lives <= 0 && !endGame) // Checks if the game is over
                {
                    endGame = true;// Makes sure this isn't called multiple times
                    LostGame(false);// Saves the highscore
                }
            }

            foreach (Bomber t in bombers.ToList())
            {
                t.moveBomber();
                t.drawBomber(g);

                if (t.bomberY >= 225 && t.bomberY <= 245)// Drops a bomb when the bomber is half way up the screen
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
                        aliens.Remove(a);// When the bomb explodes it removes any aliens touching it
                    }
                }

                if (d.bombRec.IntersectsWith(player.playerRec) && d.bombTimer >= 66 && d.bombGaveDamage == false)
                {
                    d.bombGaveDamage = true;// Stops the bomb from removing too many lives
                    lives--;// Removes player lives if its touching the bomb when it explodes
                }
            }
        }

        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.W) { up = true; }
           if (e.KeyData == Keys.A) { left = true; }
           if (e.KeyData == Keys.S) { down = true; }
           if (e.KeyData == Keys.D) { right = true; }
           if (!afkTimerCheck) { afkTimer = 0; afkTimerCheck = true; isAFK = false; }// Checks if the player has pressed a key and marks them not afk
        }
        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            //Stops player from going off-screen
            if (player.x > ClientSize.Width - 120) { player.x -= 10; }
            if (player.x < 0) { player.x += 10; }
            if (player.y > ClientSize.Height - 170) { player.y -= 10; }
            if (player.y < 0) { player.y += 10; }

            PnlGame.Invalidate();
            afkTimer++;// If the player is currently afk
            blinkCoolDown++;// The afk move text blink cooldown (so it only blinks every so often)
            if (afkTimer >= 450)
            {
                // Starts removing lives if the player is afk
                isAFK = true;
                lives--;
                afkTimer = 375;
            }
            // Blinks the MOVE text when the player is afk
            if (blinkCoolDown == 50 && isAFK)
            {
                TextMove.Visible = true;
            }else if (blinkCoolDown == 100)
            {
                TextMove.Visible = false;
                blinkCoolDown = 0;
            }
        }
    }
}