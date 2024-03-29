﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Balls
{
    public class Balls
    {
        //numbers of balls
        public int numBalls { get; set; }
        public List<Ball> allBalls { get; set; }
		Color color;
		public Point startingPoint { get; set; }
		public float Angle { get; set; }
		public int ballsLeft { get; set; }
        public Balls(int n, Color color, float Angle, BallStart ballStart) 
        {
			//Point addBalls = new Point(ballStart.currentPosition.X + 15, ballStart.currentPosition.Y);
			//balls.Add(new Balls.Ball(addBalls, Color.Black, (float)GetAngle(ballStart.currentPosition, e.Location) / 57.4F));

			startingPoint = new Point(ballStart.currentPosition.X + Constants.BALL_LAUNCHER_SIZE, ballStart.currentPosition.Y + Constants.BALL_LAUNCHER_SIZE);

			this.Angle = Angle;
			this.allBalls = new List<Ball>();
			this.color = color;
			numBalls = n;
			ballsLeft = n;
        }

        public void checkBalls()
        {
            for(int i=0;i<allBalls.Count; i++)
            {
                if(allBalls.ElementAt(i).BallDead)
                {
                    allBalls.RemoveAt(i);
					numBalls--;
                    i--;
                }
            }
        }

        private bool AnyBallsLeft()
        {
            return numBalls == 0;
        }

		public void Draw(Graphics g)
		{
			SolidBrush brush = new SolidBrush(color);
			foreach(Ball b in allBalls)
			{
				b.Draw(g, brush);
			}
			brush.Dispose();
		}

		public void Move()
		{
			foreach(Ball b in allBalls)
			{
				b.Move();
			}
		}

		public void AddBall()
		{
			allBalls.Add(new Ball(startingPoint, color, Angle));
			ballsLeft--;
		}

		public void Terminate()
		{
			ballsLeft = 0;
			numBalls = 0;
			allBalls.Clear();
		}
    }
}
