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
        public enum HitDirection {top, right, bottom, left, none}
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

        public Ball(Point Center, Color color, float Angle)
        {
            this.Center = Center;
            this.Color = color;
            this.Speed = 20;
			this.r = Constants.BALL_RADIUS;
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
            if(dir == HitDirection.left ||dir==HitDirection.right)
            {
                this.velocityX = -this.velocityX;
            }
            else if(dir == HitDirection.top || dir == HitDirection.bottom)
            {
                this.velocityY = -this.velocityY;
            }
            
            this.setDirection(angle);
        }

        public void Draw(Graphics g, SolidBrush brush)
        {
           // Brush brush = new SolidBrush(this.Color);
            g.FillEllipse(brush, Center.X - r, Center.Y - r, r * 2, r * 2);
           //brush.Dispose();
        }
        //check if the ball is hitting a block
        public int checkCollision(Blocks.Block block)
        {
            HitDirection dir = HitDirection.none;
            float cx = this.Center.X;
            float cy = this.Center.Y;
            float radius = this.r;
            float rx = block.X;
            float ry = block.Y;
            float rw = Constants.BLOCK_HEIGHT;
            float rh = Constants.BLOCK_WIDTH;
            float testX = cx;
            float testY = cy;
            if (cx < rx)
            {
                testX = rx;
                dir = HitDirection.left;
            }// left edge
            else if (cx > rx + rw)
            {
                 testX = rx + rw;
                dir = HitDirection.right;
            }// right edge

            if (cy < ry)
            {
                dir = HitDirection.top;
                testY = ry;
            }// top edge
            else if (cy > ry + rh)
            {
                dir = HitDirection.bottom;
                testY = ry + rh;
            }// bottom edge

            float distX = cx - testX;
            float distY = cy - testY;
            float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

            if (distance <= radius)
            {
                return (int)dir;
            }
            return -1;
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
				velocityY += 0.2F;
            }
            if (nextY + r >= height + top)
            {
				BallDead = true;
				//velocityY = -velocityY;
			}
            if(nextY - r <= top)
            {
				velocityY = -velocityY; 
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
        }
    }
}
