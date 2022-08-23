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
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();//hide FrmStartup
            //open an instance of FrmGame called FrmGame2
            FrmGame FrmGame2 = new FrmGame();
            //Display the Game Form
            FrmGame2.ShowDialog();

        }
    }
}
