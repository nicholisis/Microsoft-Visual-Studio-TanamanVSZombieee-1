using System;
using System.Collections.Generic;
using System.Text;

namespace M3VP
{
    internal class Plant
    {
        public PictureBox pic;
        public Label lblHp;
        public string type;
        public int currentHp;
        public int maxHp;
        public int row;
        public int col;
        public int timerAction;

        public Plant(PictureBox pic, Label lblHp, string type, int maxHp, int row, int col)
        {
            this.pic = pic;
            this.lblHp = lblHp;
            this.type = type;
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.row = row;
            this.col = col;
            this.timerAction = 0;
        }
    }
}
