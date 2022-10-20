
namespace _201COS_Game
{
    partial class FrmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TextName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TextScore = new System.Windows.Forms.Label();
            this.LblScore = new System.Windows.Forms.Label();
            this.TextLives = new System.Windows.Forms.Label();
            this.LblLives = new System.Windows.Forms.Label();
            this.TmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.TmrGun = new System.Windows.Forms.Timer(this.components);
            this.TmrEnemySpawn = new System.Windows.Forms.Timer(this.components);
            this.LblTime = new System.Windows.Forms.Label();
            this.TextTime = new System.Windows.Forms.Label();
            this.TmrTime = new System.Windows.Forms.Timer(this.components);
            this.PnlGame = new System.Windows.Forms.Panel();
            this.TextMove = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHighScore = new System.Windows.Forms.ToolStripMenuItem();
            this.TmrPowerUp = new System.Windows.Forms.Timer(this.components);
            this.TmrSlowShoot = new System.Windows.Forms.Timer(this.components);
            this.PnlGame.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextName
            // 
            this.TextName.AutoSize = true;
            this.TextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextName.ForeColor = System.Drawing.Color.White;
            this.TextName.Location = new System.Drawing.Point(12, 34);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(62, 22);
            this.TextName.TabIndex = 1;
            this.TextName.Text = "Name:";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(90, 37);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(117, 20);
            this.TxtName.TabIndex = 2;
            this.TxtName.Text = "Please input your name";
            // 
            // TextScore
            // 
            this.TextScore.AutoSize = true;
            this.TextScore.BackColor = System.Drawing.Color.Transparent;
            this.TextScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextScore.ForeColor = System.Drawing.Color.White;
            this.TextScore.Location = new System.Drawing.Point(381, 34);
            this.TextScore.Name = "TextScore";
            this.TextScore.Size = new System.Drawing.Size(62, 22);
            this.TextScore.TabIndex = 3;
            this.TextScore.Text = "Score:";
            // 
            // LblScore
            // 
            this.LblScore.AutoSize = true;
            this.LblScore.BackColor = System.Drawing.SystemColors.Control;
            this.LblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScore.Location = new System.Drawing.Point(449, 36);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(20, 22);
            this.LblScore.TabIndex = 4;
            this.LblScore.Text = "0";
            // 
            // TextLives
            // 
            this.TextLives.AutoSize = true;
            this.TextLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLives.ForeColor = System.Drawing.Color.White;
            this.TextLives.Location = new System.Drawing.Point(530, 34);
            this.TextLives.Name = "TextLives";
            this.TextLives.Size = new System.Drawing.Size(57, 22);
            this.TextLives.TabIndex = 5;
            this.TextLives.Text = "Lives:";
            // 
            // LblLives
            // 
            this.LblLives.AutoSize = true;
            this.LblLives.BackColor = System.Drawing.SystemColors.Control;
            this.LblLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLives.Location = new System.Drawing.Point(593, 34);
            this.LblLives.Name = "LblLives";
            this.LblLives.Size = new System.Drawing.Size(30, 22);
            this.LblLives.TabIndex = 6;
            this.LblLives.Text = "10";
            // 
            // TmrPlayer
            // 
            this.TmrPlayer.Interval = 15;
            this.TmrPlayer.Tick += new System.EventHandler(this.TmrPlayer_Tick);
            // 
            // TmrGun
            // 
            this.TmrGun.Interval = 50;
            this.TmrGun.Tick += new System.EventHandler(this.TmrGun_Tick);
            // 
            // TmrEnemySpawn
            // 
            this.TmrEnemySpawn.Interval = 1000;
            this.TmrEnemySpawn.Tick += new System.EventHandler(this.TmrEnemySpawn_Tick);
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.BackColor = System.Drawing.SystemColors.Control;
            this.LblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.Location = new System.Drawing.Point(298, 35);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(20, 22);
            this.LblTime.TabIndex = 8;
            this.LblTime.Text = "0";
            // 
            // TextTime
            // 
            this.TextTime.AutoSize = true;
            this.TextTime.BackColor = System.Drawing.Color.Transparent;
            this.TextTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTime.ForeColor = System.Drawing.Color.White;
            this.TextTime.Location = new System.Drawing.Point(237, 35);
            this.TextTime.Name = "TextTime";
            this.TextTime.Size = new System.Drawing.Size(55, 22);
            this.TextTime.TabIndex = 7;
            this.TextTime.Text = "Time:";
            // 
            // TmrTime
            // 
            this.TmrTime.Interval = 1000;
            this.TmrTime.Tick += new System.EventHandler(this.TmrTime_Tick);
            // 
            // PnlGame
            // 
            this.PnlGame.BackgroundImage = global::_201COS_Game.Properties.Resources.Background;
            this.PnlGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlGame.Controls.Add(this.TextMove);
            this.PnlGame.Location = new System.Drawing.Point(12, 63);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(660, 490);
            this.PnlGame.TabIndex = 0;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            this.PnlGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlGame_MouseDown);
            this.PnlGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlGame_MouseMove);
            this.PnlGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlGame_MouseUp);
            // 
            // TextMove
            // 
            this.TextMove.AutoSize = true;
            this.TextMove.BackColor = System.Drawing.Color.Transparent;
            this.TextMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextMove.ForeColor = System.Drawing.Color.Red;
            this.TextMove.Location = new System.Drawing.Point(135, 175);
            this.TextMove.Name = "TextMove";
            this.TextMove.Size = new System.Drawing.Size(459, 153);
            this.TextMove.TabIndex = 0;
            this.TextMove.Text = "MOVE";
            this.TextMove.Visible = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStart,
            this.MnuPause,
            this.MnuHighScore});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(684, 24);
            this.MenuStrip.TabIndex = 9;
            this.MenuStrip.Text = "menuStrip";
            // 
            // MnuStart
            // 
            this.MnuStart.Name = "MnuStart";
            this.MnuStart.Size = new System.Drawing.Size(43, 20);
            this.MnuStart.Text = "Start";
            this.MnuStart.Click += new System.EventHandler(this.MnuStart_Click);
            // 
            // MnuPause
            // 
            this.MnuPause.Name = "MnuPause";
            this.MnuPause.Size = new System.Drawing.Size(50, 20);
            this.MnuPause.Text = "Pause";
            this.MnuPause.Click += new System.EventHandler(this.MnuPause_Click);
            // 
            // MnuHighScore
            // 
            this.MnuHighScore.Name = "MnuHighScore";
            this.MnuHighScore.Size = new System.Drawing.Size(85, 20);
            this.MnuHighScore.Text = "Highscore: 0";
            this.MnuHighScore.Click += new System.EventHandler(this.MnuHighScore_Click);
            // 
            // TmrPowerUp
            // 
            this.TmrPowerUp.Enabled = true;
            this.TmrPowerUp.Interval = 1000;
            this.TmrPowerUp.Tick += new System.EventHandler(this.TmrPowerUp_Tick);
            // 
            // TmrSlowShoot
            // 
            this.TmrSlowShoot.Enabled = true;
            this.TmrSlowShoot.Interval = 200;
            this.TmrSlowShoot.Tick += new System.EventHandler(this.TmrSlowShoot_Tick);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 564);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.TextTime);
            this.Controls.Add(this.LblLives);
            this.Controls.Add(this.TextLives);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.TextScore);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.PnlGame);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmGame";
            this.Text = "Angry Nerds";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmGame_KeyUp);
            this.PnlGame.ResumeLayout(false);
            this.PnlGame.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Label TextName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label TextScore;
        private System.Windows.Forms.Label LblScore;
        private System.Windows.Forms.Label TextLives;
        private System.Windows.Forms.Label LblLives;
        private System.Windows.Forms.Timer TmrPlayer;
        private System.Windows.Forms.Timer TmrGun;
        private System.Windows.Forms.Timer TmrEnemySpawn;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label TextTime;
        private System.Windows.Forms.Timer TmrTime;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuStart;
        private System.Windows.Forms.ToolStripMenuItem MnuPause;
        private System.Windows.Forms.Timer TmrPowerUp;
        private System.Windows.Forms.ToolStripMenuItem MnuHighScore;
        private System.Windows.Forms.Timer TmrSlowShoot;
        private System.Windows.Forms.Label TextMove;
    }
}

