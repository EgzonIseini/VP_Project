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

		private List<Balls.Ball> balls;

		private static SolidBrush ballBrush = new SolidBrush(Color.Red);

		private Timer ballsDraw;

		private BallStart ballStart;

		private Point lastMouseLocation;


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
			this.balls = new List<Balls.Ball>();
			this.ballsDraw = new Timer();
			ballsDraw.Interval = 32;
			ballsDraw.Tick += new EventHandler(timerDraw_Tick);
			ballsDraw.Start();

			ballStart = new BallStart();
		}

        private void Game_Paint(object sender, PaintEventArgs e)
        { 
            // This is the first line which sets the canvas for painting. Only use this
            // to initalize the canvas i.e. set color, size etc.
            e.Graphics.Clear(Color.DimGray);

			Brush black = new SolidBrush(Color.Black);
			Pen blackPen = new Pen(black, 3);
			blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;


			Point newPoint = new Point(ballStart.currentPosition.X + BallStart.Radius, ballStart.currentPosition.Y + BallStart.Radius);
			e.Graphics.DrawLine(blackPen, newPoint, lastMouseLocation);
            
            // Any other type of drawing goes below this comment.
            foreach (Row row in rows) { 
                row.DrawBlocks(e.Graphics);
            }

			// Testing out Mladens BALLS
			foreach (Balls.Ball ball in balls)
			{
				ball.Draw(e.Graphics, ballBrush);
			}

			ballStart.Draw(e.Graphics);
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
			foreach (Balls.Ball ball in balls)
			{
				ball.Move();
			}
			Invalidate(true);
        }

		private void Game_MouseClick(object sender, MouseEventArgs e)
		{
			Point addBalls = new Point(ballStart.currentPosition.X + 15, ballStart.currentPosition.Y);
			balls.Add(new Balls.Ball(addBalls, Color.Black, (float)GetAngle(ballStart.currentPosition, e.Location) / 57.2F));
			
			//balls.Add(new Balls.Ball(addBalls, Color.Black, 5.4F));

			Debug.WriteLine(string.Format("Angle is {0}", (float)GetAngle(ballStart.currentPosition, e.Location) / 57.2F));

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

		private double GetAngle(Point start, Point arrival)
		{
			var deltaX = Math.Pow((arrival.X - start.X), 2);
			var deltaY = Math.Pow((arrival.Y - start.Y), 2);

			var radian = Math.Atan2((arrival.Y - start.Y), (arrival.X - start.X));
			var angle = (radian * (180 / Math.PI) + 360) % 360;

			return angle;
		}
	}
}
