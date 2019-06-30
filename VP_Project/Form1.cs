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

		// powerupType is equals to the powerupTypes. IF 0 => player has no powerups!
		// Can't have more than one powerup at a time. Initialized originally to 0.
		private int powerupType;
		
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
            powerupType = PowerUp.currentPowerup;
            Invalidate(true);
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
                        if (ball.CheckCollision(block))
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
                ballStart.Draw(ballsToAdd, e.Graphics);
                if (ShotWasTaken)
                {
                    ShotWasTaken = false;
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

        // <------------------- HELPER METHODS ------------------>
        /// <summary>
        /// Method to move the blocks down when play ends
        /// </summary>
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
            ballsToAdd++;
            if (IsGameOver())
            {
                MessageBox.Show("GAME OVER");
                GenerateNewGame();
            }
        }

        /// <summary>
        /// Method to throw the balls at given location
        /// </summary>
        /// <param name="location">Final location where the balls should be thrown at</param>
        private void ThrowBalls(Point location)
        {
            if (powerupType != 3)
                _balls = new Balls.Balls(ballsToAdd, Color.Black, GetAngle(ballStart.currentPosition, location), ballStart);
            else
            {
                _balls = new Balls.Balls(ballsToAdd * 2, Color.Black, GetAngle(ballStart.currentPosition, location), ballStart);
                powerupType = 0;
            }

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
            soundPlayer = new SoundPlayer(Properties.Resources.hitSound);
            Constants.WINDOW_HEIGHT = this.Height;
            Constants.WINDOW_WIDTH = this.Width;

            ballBrush = new SolidBrush(Color.White);
            ballStart = new Balls.BallStart();
            _balls = new Balls.Balls(0, Color.Black, 0, ballStart);

            this.ballsToAdd = 1;
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
