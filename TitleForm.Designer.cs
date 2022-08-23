
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
            ((System.ComponentModel.ISupportInitialize)(this.PicAlien)).BeginInit();
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
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(688, 568);
            this.Controls.Add(this.PicAlien);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.TextAngryBirds);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TitleForm";
            this.Text = "Angry Nerds";
            ((System.ComponentModel.ISupportInitialize)(this.PicAlien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TextAngryBirds;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.PictureBox PicAlien;
    }
}