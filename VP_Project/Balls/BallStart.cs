using System;
using System.Drawing;

namespace VP_Project.Balls
{
	/// <summary>
	/// BallStart class is used to keep information and manipulate the "launch" pads from where balls are launched.
	/// Should be a Singleton class or a static one.
	/// </summary>
	public class BallStart
	{
		// ----- Current position of the "launchpad". Its the place from which the balls launch and changes every round end.
		// ----- Used only within the class.
		public Point currentPosition { get; set; }

		// ----- Defines the next position where the "launchpad" will move to. Defined as static cause its position
		// ----- depends from the data of another class.
		public static Point nextPosition { get; set; }

		// ----- Radius of the launchpads.
		public static int Radius = (int)Constants.BALL_RADIUS;

		// ----- Static variables which define with what brush (color) the launchpads will be colored.
		// -- Initially current is White and next is LimeGreen.
		private static Brush CurrentBrush = Brushes.White;
		private static Brush NextBrush = Brushes.LimeGreen;

		
		public BallStart()
		{
			// Y - vertical position of the launchpad. Always the same.
			int y = Constants.FORM_BOTTOM + Constants.BALL_LAUNCHER_SIZE;

			// X - horizontal position of the launchpad. Initially is set to a random value (new game)
			int x = Constants.RANDOM.Next(0 + Constants.BALL_LAUNCHER_SIZE, Constants.FORM_RIGHT - Constants.BALL_LAUNCHER_SIZE);

			// Current position is assigned to the above values.
			currentPosition = new Point(x, y);

			// Next position is assigned to -100,-100. Its done in such a way to make the checks easier on the outer classes.
			nextPosition = new Point(-100, -100);
		}

		/// <summary>
		/// Draws the figures. Called from the main Form, OnPaint event.
		/// </summary>
		/// <param name="ballsLeft"> The amounts of balls left to be launched from the launchpad at the current time 
		/// this method is called. Used for the number that is drawn inside the launchpad.</param>
		public void Draw(int ballsLeft, Graphics g)
		{
			// Next Poistion
			g.FillEllipse(NextBrush, nextPosition.X, nextPosition.Y, 4 * Radius, 4 * Radius);

			// Current Position
			g.FillEllipse(CurrentBrush, currentPosition.X, currentPosition.Y, 4 * Radius, 4 * Radius);

			// Method that draws the number of balls left for the launchped.
			DrawBallsLeft(ballsLeft, g);
		}

		/// <summary>
		/// Generates the new positions of the launchpad after round ends.
		/// currentPosition is the nextPosition assigned on the previous round.
		/// nextPosition is sent to -100,-100 again ; as it allows easier checking of its state from outer class.
		/// </summary>
		public void GenerateNewPositions()
		{
			currentPosition = nextPosition;
			nextPosition = new Point(-100, -100);
		}

		/// <summary>
		/// Draws the number of balls left to be launched from the pad at the moment this method is called.
		/// </summary>
		/// <param name="ballsLeft">The number of balls left.</param>
		/// <param name="g">The graphics object on which to draw (OnPaint) event. </param>
		private void DrawBallsLeft(int ballsLeft, Graphics g)
		{
			Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;

			g.DrawString(ballsLeft + "", font, Brushes.Black, currentPosition.X + Constants.BALL_LAUNCHER_SIZE, currentPosition.Y + Constants.BALL_LAUNCHER_SIZE, stringFormat);
		}
	}
}