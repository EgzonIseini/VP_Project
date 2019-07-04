using System;
using System.Drawing;

namespace VP_Project.Balls
{
	public class BallStart
	{
		public Point currentPosition { get; set; }
		public static Point nextPosition { get; set; }

		public static int Radius = (int)Constants.BALL_RADIUS;
		public static Color currentColor = Color.White;
		public static Color nextColor = Color.LimeGreen;

		public static readonly int BALL_SIZE = 10;
		
		public BallStart()
		{
			int y = Constants.FORM_BOTTOM + BALL_SIZE;
			int x = Constants.RANDOM.Next(0 + BALL_SIZE, Constants.FORM_RIGHT - BALL_SIZE);

			currentPosition = new Point(x, y);
			nextPosition = new Point(-100, -100);
		}

		public void Draw(int ballsLeft, Graphics g)
		{
			SolidBrush currentBrush = new SolidBrush(currentColor), nextBrush = new SolidBrush(nextColor);

			//Next Poistion
			g.FillEllipse(nextBrush, nextPosition.X, nextPosition.Y, 4 * Radius, 4 * Radius);

			//Current Position
			g.FillEllipse(currentBrush, currentPosition.X, currentPosition.Y, 4 * Radius, 4 * Radius);

			DrawBallsLeft(ballsLeft, g);

			currentBrush.Dispose();
			nextBrush.Dispose();
		}

		public void GenerateNewPositions()
		{
			currentPosition = nextPosition;
			nextPosition = new Point(-100, -100);
		}

		private void DrawBallsLeft(int ballsLeft, Graphics g)
		{
			Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;

			g.DrawString(ballsLeft + "", font, Brushes.Black, currentPosition.X + BALL_SIZE, currentPosition.Y + BALL_SIZE, stringFormat);
		}

		private int GetDistance(Point current, Point next)
		{
			return (int)Math.Sqrt((current.X - next.X) * (current.X - next.X) + (current.Y - next.Y) * (current.Y - next.Y));
		}
	}
}