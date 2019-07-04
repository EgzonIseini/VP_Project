using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Balls
{
    public class Ball
    {
        //radius of the ball
        public float r { get; set; }
        //color of the ball
        public Color Color { get; set; }
        //location, center of the ball
        public Point Center { get; set; }
        //velocity or speed of the ball
        public float Speed { get; set; }
        //The angle of the ball
        public float Angle { get; set; }
        //Velocity on the X and on the Y axis
        private float velocityX;
        private float velocityY;
        //if the ball hits the bottom of the form
        public bool BallDead { get; set; }
        //Variable used to avoid multiple hits at the same time
        public bool HitOnce;

        /// <summary>
        /// Generate new ball
        /// </summary>
        /// <param name="Center">Center point of the ball</param>
        /// <param name="Color">Color of the ball</param>
        /// <param name="Angle">Angle of the movement in radians</param>
        public Ball(Point Center, Color Color, float Angle)
        {
            this.r = Constants.BALL_RADIUS;
            this.Center = Center;
            this.Color = Color;
            this.Speed = 10;
            SetDirection(Angle);
        }
       
        /// <summary>
        /// Method to determine the x and y velocity of the ball
        /// </summary>
        /// <param name="Angle">Angle in radians</param>
        public void SetDirection(float Angle)
        {
            this.Angle = Angle;
            this.velocityX = (float)(Math.Cos(Angle) * Speed);
            this.velocityY = (float)(Math.Sin(Angle) * Speed);
        }

        /// <summary>
        /// Method to draw the ball
        /// </summary>
        public void Draw(Graphics g, SolidBrush brush)
        {
            g.FillEllipse(brush, Center.X - r, Center.Y - r, 2 * r , 2 * r);
        }
        
        /// <summary>
        /// Helper method to find distance between a point o and line defined by points a and b
        /// </summary>
        /// <param name="o">Point in the problem</param>
        /// <param name="a">First point of the line</param>
        /// <param name="b">Second point of the line</param>
        /// <returns>Distance between point and line</returns>
        private double DistanceToLine(PointF o, PointF a, PointF b)
        {
            return Math.Abs(((a.Y - b.Y) * o.X) - ((a.X - b.X) * o.Y) + a.X * b.Y - b.X * a.Y) 
                    / Math.Sqrt((a.Y - b.Y) * (a.Y - b.Y) + (a.X - b.X) * (a.X - b.X));
        }

        /// <summary>
        /// Checks for collision between ball and block, and changes the behavior of the ball accordingly
        /// </summary>
        /// <param name="block">Block for which collision is checked</param>
        /// <returns>The type of block hit, if no block is hit -1 is returned</returns>
        public int CheckCollision(Blocks.Block block)
        {
            //Points are labeled starting from the top-left corner and continuing clockwise

            PointF a = new PointF(block.X, block.Y);
            PointF b = new PointF(block.X + Constants.BLOCK_WIDTH, block.Y);
            PointF c = new PointF(block.X + Constants.BLOCK_WIDTH, block.Y + Constants.BLOCK_HEIGHT);
            PointF d = new PointF(block.X, block.Y + Constants.BLOCK_HEIGHT);

            //Check if the ball is totally away from the block

            //Line 1 a-b
            //Line 2 b-c
            //Line 3 c-d
            //Line 4 d-a
            Point Center = new Point(this.Center.X + (int)r, this.Center.Y + (int)r);
            double d1 = DistanceToLine(Center, a, b);
            double d2 = DistanceToLine(Center, b, c);
            double d3 = DistanceToLine(Center, c, d);
            double d4 = DistanceToLine(Center, d, a);

            bool WasHit = false;
            int x = this.Center.X, y = this.Center.Y;

			bool isSquareBlock = (block is Blocks.SquareBlock);

            if (d1 <= r && Center.X + r >= a.X && Center.X - r <= b.X)
            {
                //Ball hit the top side
                if(isSquareBlock) this.velocityY = -Math.Abs(this.velocityY);
                WasHit = true;
            }

            if (d2 <= r && Center.Y + r >= b.Y && Center.Y - r <= c.Y)
            {
				//Ball hit the right side
				if (isSquareBlock) this.velocityX = Math.Abs(this.velocityX);
               // x += (int)(Constants.DELTA + r);
                WasHit = true;
            }

            if (d3 <= r && Center.X + r >= a.X && Center.X - r <= b.X)
            {
				//Ball hit the bottom side
				if (isSquareBlock) this.velocityY = Math.Abs(this.velocityY);
                WasHit = true;
            }
            if (d4 <= r && Center.Y + r >= b.Y && Center.Y - r <= c.Y)
            {
				//Ball hit the left side
				if (isSquareBlock) this.velocityX = -Math.Abs(this.velocityX);
                WasHit = true;
            }  

            if (WasHit) {
                HitOnce = true;
                Move();
                Center = new Point(x, y);
                return block.WasHit();
            }
            return -1;
        }
        
        /// <summary>
        /// Moves the ball according to the game rules
        /// </summary>
        public void Move()
        {
            int left = Constants.FORM_LEFT;
            int top = Constants.FORM_TOP;
            int width = Constants.FORM_RIGHT;
            int height = Constants.FORM_BOTTOM;

            float nextX = Center.X + velocityX;
            float nextY = Center.Y + velocityY;
            if (nextX <= left || nextX -8*r >= width + left)
            {
                velocityX = -velocityX;

				// Slows the vertical speed of the balls, so they gradually start falling down
				// instead of going left-right endlessly.
				velocityY += 0.15F;
            }
            if (nextY + r >= height + top)
            {
                BallDead = true;

				int y = Constants.FORM_BOTTOM + (int)Constants.BALL_RADIUS;
				int x = Center.X - (int)Constants.BALL_RADIUS;

				if( BallStart.nextPosition.X == -100 ) BallStart.nextPosition = new Point(x, y);
			}
            if (nextY - r <= top)
            {
                velocityY = -velocityY;
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));

        }

    }
}
