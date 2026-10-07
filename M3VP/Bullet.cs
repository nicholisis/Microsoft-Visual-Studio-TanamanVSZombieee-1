using System;
using System.Collections.Generic;
using System.Text;

namespace M3VP
{
    internal class Bullet
    {
        public PictureBox pic;
        public int row;

        public Bullet(PictureBox pic, int row)
        {
            this.pic = pic;
            this.row = row;
        }
    }
}
