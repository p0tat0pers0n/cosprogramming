
namespace _201COS_Game
{
    partial class TitleForm
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
            this.TextAngryBirds = new System.Windows.Forms.Label();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.PicAlien = new System.Windows.Forms.PictureBox();
            this.BtnInstructions = new System.Windows.Forms.Button();
            this.PicStar = new System.Windows.Forms.PictureBox();
            this.PicBomber = new System.Windows.Forms.PictureBox();
            this.PicBomb = new System.Windows.Forms.PictureBox();
            this.PicPlayer = new System.Windows.Forms.PictureBox();
            this.PicBullet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBomber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBullet)).BeginInit();
            this.SuspendLayout();
            // 
            // TextAngryBirds
            // 
            this.TextAngryBirds.AutoSize = true;
            this.TextAngryBirds.Font = new System.Drawing.Font("MV Boli", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAngryBirds.Location = new System.Drawing.Point(189, 153);
            this.TextAngryBirds.Name = "TextAngryBirds";
            this.TextAngryBirds.Size = new System.Drawing.Size(274, 55);
            this.TextAngryBirds.TabIndex = 0;
            this.TextAngryBirds.Text = "Angry Nerds";
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(281, 330);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(75, 23);
            this.BtnPlay.TabIndex = 1;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // PicAlien
            // 
            this.PicAlien.Image = global::_201COS_Game.Properties.Resources.alien;
            this.PicAlien.Location = new System.Drawing.Point(526, 406);
            this.PicAlien.Name = "PicAlien";
            this.PicAlien.Size = new System.Drawing.Size(150, 150);
            this.PicAlien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAlien.TabIndex = 2;
            this.PicAlien.TabStop = false;
            // 
            // BtnInstructions
            // 
            this.BtnInstructions.Location = new System.Drawing.Point(281, 360);
            this.BtnInstructions.Name = "BtnInstructions";
            this.BtnInstructions.Size = new System.Drawing.Size(75, 23);
            this.BtnInstructions.TabIndex = 3;
            this.BtnInstructions.Text = "How to Play";
            this.BtnInstructions.UseVisualStyleBackColor = true;
            this.BtnInstructions.Click += new System.EventHandler(this.BtnInstructions_Click);
            // 
            // PicStar
            // 
            this.PicStar.Image = global::_201COS_Game.Properties.Resources.shootingStar;
            this.PicStar.Location = new System.Drawing.Point(50, 153);
            this.PicStar.Name = "PicStar";
            this.PicStar.Size = new System.Drawing.Size(78, 123);
            this.PicStar.TabIndex = 4;
            this.PicStar.TabStop = false;
            // 
            // PicBomber
            // 
            this.PicBomber.Image = global::_201COS_Game.Properties.Resources.taiFighter;
            this.PicBomber.Location = new System.Drawing.Point(516, 35);
            this.PicBomber.Name = "PicBomber";
            this.PicBomber.Size = new System.Drawing.Size(140, 131);
            this.PicBomber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBomber.TabIndex = 5;
            this.PicBomber.TabStop = false;
            // 
            // PicBomb
            // 
            this.PicBomb.Image = global::_201COS_Game.Properties.Resources.bomb;
            this.PicBomb.Location = new System.Drawing.Point(563, 172);
            this.PicBomb.Name = "PicBomb";
            this.PicBomb.Size = new System.Drawing.Size(61, 78);
            this.PicBomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBomb.TabIndex = 6;
            this.PicBomb.TabStop = false;
            // 
            // PicPlayer
            // 
            this.PicPlayer.Image = global::_201COS_Game.Properties.Resources.player2;
            this.PicPlayer.Location = new System.Drawing.Point(32, 432);
            this.PicPlayer.Name = "PicPlayer";
            this.PicPlayer.Size = new System.Drawing.Size(104, 101);
            this.PicPlayer.TabIndex = 7;
            this.PicPlayer.TabStop = false;
            // 
            // PicBullet
            // 
            this.PicBullet.Image = global::_201COS_Game.Properties.Resources.bullet;
            this.PicBullet.Location = new System.Drawing.Point(170, 478);
            this.PicBullet.Name = "PicBullet";
            this.PicBullet.Size = new System.Drawing.Size(12, 67);
            this.PicBullet.TabIndex = 8;
            this.PicBullet.TabStop = false;
            // 
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(688, 568);
            this.Controls.Add(this.PicBullet);
            this.Controls.Add(this.PicPlayer);
            this.Controls.Add(this.PicBomb);
            this.Controls.Add(this.PicBomber);
            this.Controls.Add(this.PicStar);
            this.Controls.Add(this.BtnInstructions);
            this.Controls.Add(this.PicAlien);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.TextAngryBirds);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TitleForm";
            this.Text = "Angry Nerds";
            ((System.ComponentModel.ISupportInitialize)(this.PicAlien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBomber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBullet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TextAngryBirds;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.PictureBox PicAlien;
        private System.Windows.Forms.Button BtnInstructions;
        private System.Windows.Forms.PictureBox PicStar;
        private System.Windows.Forms.PictureBox PicBomber;
        private System.Windows.Forms.PictureBox PicBomb;
        private System.Windows.Forms.PictureBox PicPlayer;
        private System.Windows.Forms.PictureBox PicBullet;
    }
}