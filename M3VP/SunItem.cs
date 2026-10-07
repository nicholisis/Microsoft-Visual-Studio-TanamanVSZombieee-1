using System;
using System.Collections.Generic;
using System.Text;

namespace M3VP
{
    internal class SunItem
    {
        public PictureBox pic;
        public int lifeTime; // Bertahan maks 9 detik
        public bool isFalling;
        public int targetY;

        public SunItem(PictureBox pic, int targetY, bool isFalling = false)
        {
            this.pic = pic;
            this.lifeTime = 9;
            this.targetY = targetY;
            this.isFalling = isFalling;
        }
    }
}
