using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Blocks
{
    public abstract class Block
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public int HP { get; set; }
        protected bool MoveDownLock;

        private bool exists; // whether the block still exists, will be used for drawing later
        /// <remarks>
        /// Color is determined according to HP
        /// </remarks>
        public Block(float X, float Y, int HP)
        {
            //Ardian'
            //this.Y = Y;
            //this.X = X;
            //Altered Y and X so they start drawing from the defined constants i.e. actual drawing area size.
            //Ex: drawing from below the toolbar strip rather than cutting inside.
            this.Y = Y + Constants.FORM_TOP;
            this.X = X + Constants.FORM_LEFT;

            this.exists = true;
            Color = Color.Red;
            MoveDownLock = false;
            this.HP = HP;
        }

        /// <summary>
        /// Method to move the block down
        /// </summary>
        public void MoveDown()
        {
            MoveDownLock = true;
        }

        /// <summary>
        /// Method to draw the block
        /// </summary>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Method invoked when block is hit
        /// It should decrease the HP by the amount provided as arg
        /// Default val is 1
        /// </summary>
        public void wasHit(int amount = 1)
        {
            HP -= amount;
            if (HP <= 0)
            {
                exists = false;
            }
        }
    }
}
