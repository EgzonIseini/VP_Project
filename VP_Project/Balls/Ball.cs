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
        public enum HitDirection { top, right, bottom, left, none }
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

        public bool HitOnce;

        public Ball(Point Center, Color color, float Angle)
        {
            this.r = Constants.BALL_RADIUS;
            this.Center = Center;
            this.Color = color;
            this.Speed = 10;
            setDirection(Angle);
        }
        //set the direction of the ball
        public void setDirection(float Angle)
        {
            this.Angle = Angle;
            this.velocityX = (float)(Math.Cos(Angle) * Speed);
            this.velocityY = (float)(Math.Sin(Angle) * Speed);
        }
        //change the direction of the ball corresponding to the direction which it is hit
        public void ChangeDirection(HitDirection dir)
        {
            float angle = this.Angle;
            if (dir == HitDirection.left || dir == HitDirection.right)
            {
                this.velocityX = (-1) * this.velocityX;
            }
            else if (dir == HitDirection.top || dir == HitDirection.bottom)
            {
                this.velocityY = (-1) * this.velocityY;
            }

            this.setDirection(angle);
        }

        public void Draw(Graphics g, SolidBrush brush)
        {
            g.FillEllipse(brush, Center.X - r, Center.Y - r, 2 * r , 2 * r);
        }
        

        private double DistanceToLine(PointF o, PointF a, PointF b)
        {
            return Math.Abs(((a.Y - b.Y) * o.X) - ((a.X - b.X) * o.Y) + a.X * b.Y - b.X * a.Y) 
                    / Math.Sqrt((a.Y - b.Y) * (a.Y - b.Y) + (a.X - b.X) * (a.X - b.X));
        }

        public bool checkCollision(Blocks.Block block)
        {
            //Points are labeled starting from the top-left corner and continuing clockwise


            //return CheckCollision(block);

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

            //Console.WriteLine(string.Format("{0} {1} {2} {3}\n", d1, d2, d3, d4));

            bool WasHit = false;
            int x = this.Center.X, y = this.Center.Y;

            if (d1 <= r && Center.X + r >= a.X && Center.X - r <= b.X)
            {
                //Ball hit the top side
                this.velocityY = -Math.Abs(this.velocityY);
                WasHit = true;
            }

            if (d2 <= r && Center.Y + r >= b.Y && Center.Y - r <= c.Y)
            {
                //Ball hit the right side
                this.velocityX = Math.Abs(this.velocityX);
               // x += (int)(Constants.DELTA + r);
                WasHit = true;
            }

            if (d3 <= r && Center.X + r >= a.X && Center.X - r <= b.X)
            {
                //Ball hit the bottom side
                this.velocityY = Math.Abs(this.velocityY);
                WasHit = true;
            }
            if (d4 <= r && Center.Y + r >= b.Y && Center.Y - r <= c.Y)
            {
                //Ball hit the left side
                this.velocityX = -Math.Abs(this.velocityX);
                WasHit = true;
            }  

            if (WasHit) { 
                block.WasHit();
                HitOnce = true;
                Move();
                Center = new Point(x, y);
            }
            return WasHit;
        }

        public void Move()
        {
            int left = Constants.FORM_LEFT;
            int top = Constants.FORM_TOP;
            int width = Constants.FORM_RIGHT;
            int height = Constants.FORM_BOTTOM;

            float nextX = Center.X + velocityX;
            float nextY = Center.Y + velocityY;
            if (nextX <= left || nextX - r - r - r >= width + left)
            {
                velocityX = -velocityX;
            }
            if (nextY + r >= height + top)
            {
                BallDead = true;
            }
            if (nextY - r <= top)
            {
                velocityY = -velocityY;
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));

        }

    }
}
