
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
            this.PnlGame = new System.Windows.Forms.Panel();
            this.TmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TextName
            // 
            this.TextName.AutoSize = true;
            this.TextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextName.ForeColor = System.Drawing.Color.White;
            this.TextName.Location = new System.Drawing.Point(12, 9);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(62, 22);
            this.TextName.TabIndex = 1;
            this.TextName.Text = "Name:";
            // 
            // TxtName
            // 
            this.TxtName.Enabled = false;
            this.TxtName.Location = new System.Drawing.Point(90, 12);
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
            this.TextScore.Location = new System.Drawing.Point(410, 9);
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
            this.LblScore.Location = new System.Drawing.Point(478, 11);
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
            this.TextLives.Location = new System.Drawing.Point(542, 11);
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
            this.LblLives.Location = new System.Drawing.Point(605, 11);
            this.LblLives.Name = "LblLives";
            this.LblLives.Size = new System.Drawing.Size(20, 22);
            this.LblLives.TabIndex = 6;
            this.LblLives.Text = "5";
            // 
            // PnlGame
            // 
            this.PnlGame.BackgroundImage = global::_201COS_Game.Properties.Resources.Background;
            this.PnlGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlGame.Location = new System.Drawing.Point(12, 63);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(660, 490);
            this.PnlGame.TabIndex = 0;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            // 
            // TmrPlayer
            // 
            this.TmrPlayer.Enabled = true;
            this.TmrPlayer.Tick += new System.EventHandler(this.TmrPlayer_Tick);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 564);
            this.Controls.Add(this.LblLives);
            this.Controls.Add(this.TextLives);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.TextScore);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.PnlGame);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FrmGame";
            this.Text = "Angry Nerds";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmGame_KeyUp);
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
    }
}

