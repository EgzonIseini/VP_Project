using System;
using System.Drawing;

namespace VP_Project.Balls
{
	public class BallStart
	{
		public Point currentPosition { get; set; }
		public Point nextPosition { get; set; }

		public static int Radius = (int)Constants.BALL_RADIUS;
		public static Color currentColor = Color.White;
		public static Color nextColor = Color.LimeGreen;
		
		public BallStart()
		{
			int y = Constants.FORM_BOTTOM + (int)Constants.BALL_RADIUS;
			int x = Constants.RANDOM.Next(0 + (int)Radius, Constants.FORM_RIGHT - (int)Radius);

			currentPosition = new Point(x, y);
		}

		public void Draw(int ballsLeft, Graphics g)
		{
			SolidBrush currentBrush = new SolidBrush(currentColor), nextBrush = new SolidBrush(nextColor);

			//Current Position
			g.FillEllipse(currentBrush, currentPosition.X, currentPosition.Y, 2 * Radius, 2 * Radius);

			//Next Poistion
			g.FillEllipse(nextBrush, nextPosition.X, nextPosition.Y, 2 * Radius, 2 * Radius);

			DrawBallsLeft(ballsLeft, g);

			currentBrush.Dispose();
			nextBrush.Dispose();
		}

		public void GenerateNewPositions()
		{
			int y = Constants.FORM_BOTTOM + (int)Constants.BALL_RADIUS;
			int x = Constants.RANDOM.Next(0 + (int)Radius, Constants.FORM_RIGHT - (int)Radius);

			currentPosition = new Point(x, y);
			nextPosition = new Point(x, y);

			while (GetDistance(currentPosition, nextPosition) <= 2 * Radius)
			{
				x = Constants.RANDOM.Next(0 + Radius, Constants.FORM_RIGHT - Radius);
				nextPosition = new Point(x, y);
			}
		}

		private void DrawBallsLeft(int ballsLeft, Graphics g)
		{
			Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;

			g.DrawString(ballsLeft + "", font, Brushes.Black, currentPosition.X + Radius, currentPosition.Y + Radius, stringFormat);
		}

		private int GetDistance(Point current, Point next)
		{
			return (int)Math.Sqrt((current.X - next.X) * (current.X - next.X) + (current.Y - next.Y) * (current.Y - next.Y));
		}
	}
}