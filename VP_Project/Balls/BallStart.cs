using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Diagnostics;

namespace VP_Project.Blocks
{
	public class BallStart
	{
		public Point currentPosition { get; set; }
		public Point nextPosition { get; set; }

		public static int Radius = (int)Constants.BALL_RADIUS;
		public static Color currentColor = Color.Red;
		public static Color nextColor = Color.LimeGreen;
		
		public BallStart()
		{
			int y = Constants.FORM_BOTTOM + (int)Constants.BALL_RADIUS;
			int x = Constants.RANDOM.Next(0 + (int)Radius, Constants.FORM_RIGHT - (int)Radius);

			currentPosition = new Point(x, y);
		}

		public void Draw(Graphics g)
		{
			SolidBrush currentBrush = new SolidBrush(currentColor), nextBrush = new SolidBrush(nextColor);

			//Current Position
			g.FillEllipse(currentBrush, currentPosition.X, currentPosition.Y, 2 * Radius, 2 * Radius);

			//Next Poistion
			g.FillEllipse(nextBrush, nextPosition.X, nextPosition.Y, 2 * Radius, 2 * Radius);

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

		private int GetDistance(Point current, Point next)
		{
			return (int)Math.Sqrt((current.X - next.X) * (current.X - next.X) + (current.Y - next.Y) * (current.Y - next.Y));
		}
	}
}