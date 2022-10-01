using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201COS_Game
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();

            // Rotates the star's picturebox so it is parallel to the title
            Image imgStar = PicStar.Image;
            imgStar.RotateFlip(RotateFlipType.Rotate90FlipNone);
            PicStar.Width = 130;
            PicStar.Height = 78;
            PicStar.Image = imgStar;

            // Rotates the bullet's picturebox so that it looks like it comes out of the gun
            Image imgBullet = PicBullet.Image;
            imgBullet.RotateFlip(RotateFlipType.Rotate90FlipNone);
            PicBullet.Width = 67;
            PicBullet.Height = 12;
            PicBullet.Image = imgBullet;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();//hide FrmStartup
            //open an instance of FrmGame called FrmGame2
            FrmGame FrmGame2 = new FrmGame();
            //Display the Game Form
            FrmGame2.ShowDialog();
        }
        private void BtnInstructions_Click(object sender, EventArgs e)
        {
            // Displays instructions when the button is clicked
            MessageBox.Show("Move using WASD, aim with mouse and use left click to shoot.\nKill the green aliens, avoid the bombs and collect the shooting stars for a powerup.", "Instructions");
        }
    }
}
