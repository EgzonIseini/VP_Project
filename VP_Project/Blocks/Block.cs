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
        public bool exists; // whether the block still exists, will be used for drawing later
        /// <remarks>
        /// Color is determined according to HP
        /// </remarks>
        public Block(float X, float Y, int HP)
        {
            this.Y = Y;
            this.X = X;
            this.exists = true;
            Color = Color.Red;
            this.HP = HP;
        }

        /// <summary>
        /// Method to move the block down
        /// </summary>
        public void MoveDown()
        {
            
        }

        /// <summary>
        /// Method to draw the block
        /// </summary>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Method to check whether there is collision with this block
        /// </summary>
        /// <param name="X">X-Coordinate of ball</param>
        /// <param name="Y">Y-Coordinate of ball</param>
        /// <param name="BallPower">Power of the Ball, default 1</param>
        /// <returns>true if a collision happened, false otherwise</returns>
        public abstract bool CollisionTest(float X, float Y, int BallPower = 1);

        /// <summary>
        /// Method to find the distance between ball and block
        /// </summary>
        /// <param name="X">X-Coordinate of ball</param>
        /// <param name="Y">Y-Coordinate of ball</param>
        /// <returns>Distance as float</returns>
        protected float GetDistance(float X, float Y)
        {
            return (float)Math.Sqrt((this.X - X) * (this.X - X) + (this.Y - Y) * (this.Y - Y));

        }

        /// <summary>
        /// Method invoked when block is hit
        /// It should decrease the HP by the amount provided as arg
        /// Default val is 1
        /// </summary>
        public void WasHit(int amount = 1)
        {
            HP -= amount;
            if (HP <= 0)
            {
                exists = false;
            }
        }
    }
}
