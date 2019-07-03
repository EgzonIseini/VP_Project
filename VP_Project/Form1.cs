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
using System.Media;

namespace VP_Project
{
    public partial class Game : Form
    {
        // <------------------ MEMBER VARIABLES ---------------->
        private List<Row> rows;

		// powerupType is equals to the powerupTypes. IF its 0 then player has no powerups!
		// Can't have more than one powerup at a time. Initialized originally to 0.
		public static List<Int32> powerups { get; set; }
		
		private static SolidBrush ballBrush;

		private Timer ballsDraw;

		private Balls.BallStart ballStart;

		private Point lastMouseLocation;

		private Balls.Balls _balls;

		private int ballsToAdd;

        private bool ShotWasTaken;

        private SoundPlayer soundPlayer;

		// <--------------- FORM METHODS ---------------------->

		public Game()
        {
            InitializeComponent();
            InitGame();
        }

        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            lastMouseLocation = e.Location;
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            if (_balls.allBalls.Count == 0)
            {
                ThrowBalls(e.Location);
            }
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

            foreach (Balls.Ball ball in this._balls.allBalls)
            {
                ball.HitOnce = false;
                foreach (Row row in rows)
                {
                    foreach (Block block in row.Blocks)
                    {
                        if (ball.CheckCollision(block) > 0)
                            soundPlayer.Play();
                    }
                }
            }

            // An other type of drawing goes below this comment.
            foreach (Row row in rows)
            {
                row.DrawBlocks(e.Graphics);
            }

            _balls.Draw(e.Graphics);

            if (_balls.allBalls.Count == 0)
            {
                ballStart.Draw(ballsToAdd * Constants.ballMultiplier, e.Graphics);
                if (ShotWasTaken)
                {
                    ShotWasTaken = false;

					//Round has finished. Resetting powerups.
					ResetPowerups();

					MoveRowsDown();
                }
            }
            else
            { 
                ballStart.Draw(_balls.ballsLeft, e.Graphics);
                ShotWasTaken = true;
            }
        }

        private void ballAdder_Tick(object sender, EventArgs e)
        {
            if (_balls.allBalls.Count < _balls.numBalls)
                _balls.AddBall();
        }

        private void button_FastForward_Click(object sender, EventArgs e)
        {
            if (button_FastForward.Text == "Fast Forward")
            {
                ballsDraw.Interval = 8;
                button_FastForward.Text = "Normal";
            }
            else
            {
                button_FastForward.Text = "Fast Forward";
                ballsDraw.Interval = 32;
            }
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            // Testing out the BALLS
            _balls.Move();

            Invalidate(true);

            _balls.checkBalls();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateNewGame();
        }

		private void Powerup()
		{	
			for(int i = 0; i < powerups.Count; i++)
			{
				// ---- Set powerup multipliers.
				int powerup = powerups.ElementAt(i);

				switch (powerup)
				{
					case 1: ballsToAdd++; break;
					case 2: Constants.scoreMultiplier++; break;
					case 3: Constants.damageMultiplier++; break;
					case 4: Constants.ballMultiplier++; break;
				}
			}

			if (Constants.scoreMultiplier != 1) scoreMultiplierLabel.Text = String.Format("Score Mult: {0}", Constants.scoreMultiplier);
			else scoreMultiplierLabel.Text = "";

			if (Constants.damageMultiplier != 1) damageMultiplierLabel.Text = String.Format("Damage Mult: {0}", Constants.damageMultiplier);
			else damageMultiplierLabel.Text = "";

			if (Constants.ballMultiplier != 1) ballMultiplierLabel.Text = String.Format("Ball Mult: {0}", Constants.ballMultiplier);
			else ballMultiplierLabel.Text = "";

			// Clear pwoerup array for next use.
			powerups.Clear();
		}

		private void ResetPowerups()
		{
			Constants.scoreMultiplier = 1;
			Constants.damageMultiplier = 1;
		}

        // <------------------- HELPER METHODS ------------------>
        /// <summary>
        /// Method to move the blocks down when play ends
        /// </summary>
        private void MoveRowsDown()
        {
			//Activate any powerup.
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
            if (IsGameOver())
            {
                MessageBox.Show("GAME OVER");
                GenerateNewGame();
            }
			Powerup();
		}

        /// <summary>
        /// Method to throw the balls at given location
        /// </summary>
        /// <param name="location">Final location where the balls should be thrown at</param>
        private void ThrowBalls(Point location)
        {
			_balls = new Balls.Balls(ballsToAdd * Constants.ballMultiplier, Color.Black, GetAngle(ballStart.currentPosition, location), ballStart);
			Constants.ballMultiplier = 1;
        }

        /// <summary>
        /// Method to calculate the angle given two points
        /// </summary>
        /// <param name="start">First Point</param>
        /// <param name="arrival">Second Point</param>
        /// <returns>Angle between start and arrival in radians</returns>
        private float GetAngle(Point start, Point arrival)
        {
            var radian = Math.Atan2((arrival.Y - start.Y), (arrival.X - start.X));             
            return (float) radian;
        }

        /// <summary>
        /// Method to initialize all the member variabless
        /// </summary>
        private void InitGame()
        {
			powerups = new List<int>();
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            rows = new List<Row>();
            rows.Add(new Row());
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ballsDraw = new Timer();   
            ballsDraw.Interval = 28;
            ballsDraw.Tick += new EventHandler(timerDraw_Tick);
            ballsDraw.Start();
            soundPlayer = new SoundPlayer(Properties.Resources.hitSound);
            Constants.WINDOW_HEIGHT = this.Height;
            Constants.WINDOW_WIDTH = this.Width;

            ballBrush = new SolidBrush(Color.White);
            ballStart = new Balls.BallStart();
            _balls = new Balls.Balls(0, Color.Black, 0, ballStart);

            this.ballsToAdd = 1;
			
			scoreMultiplierLabel.Text = "";
			damageMultiplierLabel.Text = "";
			ballMultiplierLabel.Text = "";
			scoreLabel.Text = "Score: 0";
		}
        
        /// <summary>
        /// Method to check whether game is over
        /// </summary>
        /// <returns>true if it is, false otherwise</returns>
        private bool IsGameOver()
        {
            foreach (Row row in rows)
            {
                if (row.IsEmpty())
                    continue;
                return row.IsOut();
            }
            return false;
        }

        /// <summary>
        /// Method to generate new game
        /// </summary>
        private void GenerateNewGame()
        {
            Row.ResetGame();
            rows = new List<Row>();
            rows.Add(new Row());
            this.ballsToAdd = 1;
        }
    }
}
