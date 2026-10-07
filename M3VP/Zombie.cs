using System;
using System.Collections.Generic;
using System.Text;

namespace M3VP
{
    internal class Zombie
    {
        public PictureBox pic;
        public Label lblHp;
        public int currentHp;
        public int maxHp;
        public int row;
        public bool isEating;
        public Plant targetPlant;

        public Zombie(PictureBox pic, Label lblHp, int row)
        {
            this.pic = pic;
            this.lblHp = lblHp;
            this.row = row;
            this.maxHp = 100;
            this.currentHp = 100;
            this.isEating = false;
            this.targetPlant = null;
        }
    }
}
