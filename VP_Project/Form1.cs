using System;
using System.Collections.Generic;
using System.Drawing;
using VP_Project.Blocks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VP_Project
{
    public partial class Game : Form
    {
        // <------------------ MEMBER VARIABLES ---------------->
        private List<Row> rows;

        // powerupType is equals to the powerupTypes. IF 0 => player has no powerups!
        // Can't have more than one powerup at a time. Initialized originally to 0.
        private static SolidBrush ballBrush;

        private Timer ballsDraw;

        private Balls.BallStart ballStart;

        private Point lastMouseLocation;

        private Balls.Balls _balls;

        private int ballsToAdd;

        private bool ShotWasTaken;

        private SoundPlayer hitSoundPlayer;

        private SoundPlayer powerUpSoundPlayer;

		private KonamiSequence konami;

        public object ApplicationData { get; private set; }

		public static List<int> powerups { get; set; }

        // Current score player has. Calculated as Damage done * damage multiplier * score multiplier
        public static int currentScore = 0;

        // Multiplies score per every block destroyed. Stacks up multiple double score powerups.
        // Score Returned = initial score * scoreMultiplier; --- initially 1, double score is 2, trple score is 3 and so on.
        public static int scoreMultiplier = 1;

        // Same as above, just multiplies the balls to be launched in the next round. Returns ballsToAdd * ballMultiplier
        public static int ballMultiplier = 1;

        // Same as above, does x times more damage per ball to a block. Stacks up. Returns 1 * damageMultiplier
        public static int damageMultiplier = 1;

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
            Invalidate(true);
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DimGray);

            DrawLine(e.Graphics);

            DrawRows(e.Graphics);

            DrawBalls(e.Graphics);
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
                ballsDraw.Interval = 28;
            }
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
			_balls.Move();

            _balls.checkBalls();

			Invalidate(true);
		}

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateNewGame();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveGame();
            }
            catch (Exception)
            {
                //Do nothing
            }

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
            if (IsGameOver())
            {
                MessageBox.Show("GAME OVER");
                GenerateNewGame();
            }

			ballStart.GenerateNewPositions();
        }

        /// <summary>
        /// Method to throw the balls at given location
        /// </summary>
        /// <param name="location">Final location where the balls should be thrown at</param>
        private void ThrowBalls(Point location)
        {
			_balls = new Balls.Balls(ballsToAdd * Game.ballMultiplier, Color.Black, GetAngle(ballStart.currentPosition, location), ballStart);
            Game.ballMultiplier = 1;
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
            return (float)radian;
        }

        /// <summary>
        /// Method to initialize all the member variabless
        /// </summary>
        private void InitGame()
        {
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            OpenPreviousGame();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ballsDraw = new Timer();
            ballsDraw.Interval = 28;
            ballsDraw.Tick += new EventHandler(timerDraw_Tick);
            ballsDraw.Start();
            hitSoundPlayer = new SoundPlayer(Properties.Resources.hitSound);
            powerUpSoundPlayer = new SoundPlayer(Properties.Resources.powerUpSound);
            Constants.WINDOW_HEIGHT = this.Height;
            Constants.WINDOW_WIDTH = this.Width;

            ballBrush = new SolidBrush(Color.White);
            ballStart = new Balls.BallStart();
            _balls = new Balls.Balls(0, Color.Black, 0, ballStart);

			// Sets score to 0 and all other multipliers to 1.
			NewGameStats();

			powerups = new List<int>();

			scoreMultiplierLabel.Text = "";
			damageMultiplierLabel.Text = "";
			ballMultiplierLabel.Text = "";
			scoreLabel.Text = "Score: 0";

			konami = new KonamiSequence();
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


			// Sets score to 0 and all multipliers to 1;
			NewGameStats();

			scoreMultiplierLabel.Text = "";
			damageMultiplierLabel.Text = "";
			ballMultiplierLabel.Text = "";
			scoreLabel.Text = "Score: 0";
		}

        /// <summary>
        /// Method to draw the rows, before that it calls CollisionDetection
        /// </summary>
        private void DrawRows(Graphics g)
        {
            CollisionDetection();
            foreach (Row row in rows)
            {
                row.DrawBlocks(g);
            }
        }

        /// <summary>
        /// Method to draw the balls
        /// </summary>
        private void DrawBalls(Graphics g)
        {
            _balls.Draw(g);

            if (_balls.allBalls.Count == 0)
            {
                ballStart.Draw(ballsToAdd * Game.ballMultiplier, g);
                if (ShotWasTaken)
                {
                    ShotWasTaken = false;
					ResetPowerups();
					Powerup();
					MoveRowsDown();
                }
            }
            else
            {
                ballStart.Draw(_balls.ballsLeft, g);
                ShotWasTaken = true;
            }
        }


        /// <summary>
        /// Method where the effects of collisions are taken care of
        /// </summary>
        private void CollisionDetection()
        {
            foreach (Balls.Ball ball in this._balls.allBalls)
            {
                ball.HitOnce = false;
                foreach (Row row in rows)
                {
                    foreach (Block block in row.Blocks)
                    {
                        int tmp = ball.CheckCollision(block);
                        if (tmp == 0)
                            hitSoundPlayer.Play();
                        else if (tmp > 0)
                            powerUpSoundPlayer.Play();
						// Update Score after collision detection.
						scoreLabel.Text = String.Format("Score: {0}", Game.currentScore);

						//TODO: Checks for other kinds of block should be put here, check summary of CheckCollision
						//Call powerUpPlayer's Play method accordingly
					}
                }
            }
        }

        /// <summary>
        /// Method to draw the dotted line
        /// </summary>
        private void DrawLine(Graphics g)
        {
            Brush black = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(black, 3);
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            Point newPoint = new Point(ballStart.currentPosition.X + Balls.BallStart.BALL_SIZE, ballStart.currentPosition.Y + Balls.BallStart.BALL_SIZE);
            g.DrawLine(blackPen, newPoint, lastMouseLocation);
        }

        /// <summary>
        /// Method to save game
        /// </summary>
        private void SaveGame()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "last_game.bb");
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                fileStream.Position = 0;
                GameState gameState = new GameState(rows, Game.currentScore, Game.damageMultiplier, Game.scoreMultiplier, Game.ballMultiplier, this.ballsToAdd);
                formatter.Serialize(fileStream, gameState);
            }


        }

        /// <summary>
        /// Method to open game if previously saved
        /// </summary>
        private void OpenPreviousGame()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "last_game.bb");
            Console.WriteLine(fileName);
            GameState gameState = null;
            try
            {
                using(FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    gameState = (GameState) formatter.Deserialize(fileStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (gameState == null)
            {
                GenerateNewGame();
            }
            else
            {
                //_balls = gameState.Balls;
                ballsToAdd = gameState.BallsToAdd;
                Game.ballMultiplier = gameState.BallPowerUp;
                Game.currentScore = gameState.Score;
                Game.damageMultiplier = gameState.DamagePowerUp;
                Game.scoreMultiplier = gameState.ScorePowerUp;
                rows = gameState.Rows;
                Row.SetRowNum(rows.Count);
                powerups = new List<int>();
                this.Powerup();
            }
        }

		private void Powerup()
		{
			for (int i = 0; i < powerups.Count; i++)
			{
				// ---- Set powerup multipliers.
				int powerup = powerups[i];

				switch (powerup)
				{
					case 1: ballsToAdd++; break;
					case 2: Game.scoreMultiplier++; break;
					case 3: Game.damageMultiplier++; break;
					case 4: Game.ballMultiplier++; break;
				}
			}

			if (Game.scoreMultiplier != 1) scoreMultiplierLabel.Text = String.Format("Score Mult x{0}", Game.scoreMultiplier);
			else scoreMultiplierLabel.Text = "";

			if (Game.damageMultiplier != 1) damageMultiplierLabel.Text = String.Format("Damage Mult x{0}", Game.damageMultiplier);
			else damageMultiplierLabel.Text = "";

			if (Game.ballMultiplier != 1) ballMultiplierLabel.Text = String.Format("Ball Mult x{0}", Game.ballMultiplier);
			else ballMultiplierLabel.Text = "";

			// Reset powerup array after everything is done.
			powerups.Clear();
		}

		private void ResetPowerups()
		{
            Game.scoreMultiplier = 1;
            Game.damageMultiplier = 1;
		}

		private void NewGameStats()
		{
			this.ballsToAdd = 1;
            Game.currentScore = 0;
            Game.scoreMultiplier = 1;
            Game.ballMultiplier = 1;
            Game.damageMultiplier = 1;
		}

		private void hintLabel_Click(object sender, EventArgs e)
		{
			MessageBox.Show("KONAMI :)");
		}

		private void Game_KeyUp(object sender, KeyEventArgs e)
		{
			if(konami.IsCompletedBy(e.KeyCode))
			{
				cheatMenu form = new cheatMenu(Game.currentScore, Game.scoreMultiplier, Game.damageMultiplier, Game.ballMultiplier);
				
				if( form.ShowDialog() == DialogResult.OK )
				{
                    Game.currentScore = form.newScore;
                    Game.scoreMultiplier = form.newScoreMult;
                    Game.damageMultiplier = form.newDamageMult;
                    Game.ballMultiplier = form.newBallMult;

					scoreMultiplierLabel.Text = String.Format("Score Mult x{0}", Game.scoreMultiplier);
					damageMultiplierLabel.Text = String.Format("Damage Mult x{0}", Game.damageMultiplier);
					ballMultiplierLabel.Text = String.Format("Ball Mult x{0}", Game.ballMultiplier);
					scoreLabel.Text = String.Format("Score: {0}", Game.currentScore);

					powerups.Clear();
				}
			}
		}
	}

	public class KonamiSequence
	{
		readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };

		private int _offset;
		private readonly int _length, _target;

		public KonamiSequence()
		{
			_length = _code.Length - 1;
			_target = _code.Length;
		}

		public bool IsCompletedBy(Keys key)
		{
			_offset %= _target;

			if (key == _code[_offset]) _offset++;
			else if (key == _code[0]) _offset = 2;  // repeat index

			return _offset > _length;
		}
	}
}
