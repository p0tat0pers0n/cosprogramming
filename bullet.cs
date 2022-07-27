using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace _201COS_Game
{
    class Bullet
    {
        public Rectangle BulletRec = new Rectangle();
        int x, y, width, height;
        width = 60;
        height = 40;
    }

    public Bullet(Rectangle PlayerRec)
    {

    }

    public void draw(Graphics g)
    {
        y -= 30;//speed of missile
        BulletRec = new Rectangle(x, y, width, height);
        g.DrawImage(missile, missileRec);
    }
}
