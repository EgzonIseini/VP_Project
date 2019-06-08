using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Project.Blocks;
using System.Windows.Forms;
using System.Diagnostics;

namespace VP_Project
{
    public partial class Game : Form
    {
        List<Row> rows;

		// powerupType is equals to the powerupTypes. IF 0 => player has no powerups!
		// Can't have more than one powerup at a time. Initialized originally to 0.
		private int powerupType;
		
		private static SolidBrush ballBrush = new SolidBrush(Color.White);

		private Timer ballsDraw;

		private Balls.BallStart ballStart;

		private Point lastMouseLocation;

		private Balls.Balls _balls;

		private int ballsToAdd;


		public Game()
        {
            InitializeComponent();
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            rows = new List<Row>();
            rows.Add(new Row());
			this.powerupType = 0;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
			this.ballsDraw = new Timer();
			ballsDraw.Interval = 32;
			ballsDraw.Tick += new EventHandler(timerDraw_Tick);
			ballsDraw.Start();

			ballStart = new Balls.BallStart();
			_balls = new Balls.Balls(0, Color.Black, 0, ballStart);

			this.ballsToAdd = 1;
		}

        private void Game_Paint(object sender, PaintEventArgs e)
        { 
            // This is the first line which sets the canvas for painting. Only use this
            // to initalize the canvas i.e. set color, size etc.
            e.Graphics.Clear(Color.DimGray);

			Brush black = new SolidBrush(Color.Black);
			Pen blackPen = new Pen(black, 3);
			blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;


			Point newPoint = new Point(ballStart.currentPosition.X + Balls.BallStart.Radius, ballStart.currentPosition.Y + Balls.BallStart.Radius);
			e.Graphics.DrawLine(blackPen, newPoint, lastMouseLocation);
            
            // Any other type of drawing goes below this comment.
            foreach (Row row in rows) { 
                row.DrawBlocks(e.Graphics);
            }

			/* Testing out Mladens BALLS
			foreach (Balls.Ball ball in balls)
			{
				ball.Draw(e.Graphics, ballBrush);
			}*/

			_balls.Draw(e.Graphics);

			if(_balls.ballsLeft == 0) ballStart.Draw(ballsToAdd, e.Graphics);
			else ballStart.Draw(_balls.ballsLeft, e.Graphics);
		}

        private void MoveRowsDown()
        {
            timerDraw.Enabled = false;
            for (float f = 0; f < Constants.BLOCK_HEIGHT; f += Constants.BLOCK_MOVE_SPEED)
            {
                foreach (Row row in rows)
                {
                    row.MoveRowDown();
                    this.Refresh();
                }
            }
            rows.Add(new Row());
            this.Refresh();
            timerDraw.Enabled = true;
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
			// Testing out the BALLS
			_balls.Move();

			Invalidate(true);

			_balls.checkBalls();
		}

		private void Game_MouseClick(object sender, MouseEventArgs e)
		{
			if (_balls.allBalls.Count == 0)
			{
				if( powerupType != 3) _balls = new Balls.Balls(ballsToAdd, Color.Black, GetAngle(ballStart.currentPosition, e.Location), ballStart);
				else
				{
					_balls = new Balls.Balls(ballsToAdd * 2, Color.Black, GetAngle(ballStart.currentPosition, e.Location), ballStart);
					powerupType = 0;
				}
			}
			
			//Point addBalls = new Point(ballStart.currentPosition.X + 15, ballStart.currentPosition.Y);
			//balls.Add(new Balls.Ball(addBalls, Color.Black, (float)GetAngle(ballStart.currentPosition, e.Location) / 57.4F));
			
			//balls.Add(new Balls.Ball(addBalls, Color.Black, 5.4F));

			//Debug.WriteLine("Clicked at X: {0}, Y: {1}", e.X, e.Y);
			foreach(Row row in rows)
			{
				row.CollisionsTest(e.X, e.Y);
			}

			powerupType = PowerUp.currentPowerup;

			//ballStart.GenerateNewPositions();

			Invalidate(true);

			/*|if (powerupType != 0)
			{
				MessageBox.Show(string.Format("Picked up a powerup of type: {0}", powerupType.ToString()));
			}*/
		}

		private void Game_MouseMove(object sender, MouseEventArgs e)
		{
			lastMouseLocation = e.Location;
		}

		private float GetAngle(Point start, Point arrival)
		{
			var deltaX = Math.Pow((arrival.X - start.X), 2);
			var deltaY = Math.Pow((arrival.Y - start.Y), 2);

			var radian = Math.Atan2((arrival.Y - start.Y), (arrival.X - start.X));
			var angle = (radian * (180 / Math.PI) + 360) % 360;

			return (float)angle / 57.4F;
		}

		private void button_FastForward_Click(object sender, EventArgs e)
		{
			if (button_FastForward.Text == "Fast Forward")
			{
				ballsDraw.Interval = 8;
				button_FastForward.Text = "Normal";
			} else
			{
				button_FastForward.Text = "Fast Forward";
				ballsDraw.Interval = 32;
			}
		}

		private void ballAdder_Tick(object sender, EventArgs e)
		{
			if (_balls.allBalls.Count < _balls.numBalls) _balls.AddBall();
			//Debug.WriteLine(string.Format("ballAdder called. {0} {1}", _balls.allBalls.Count, _balls.numBalls));
		}
	}
}
