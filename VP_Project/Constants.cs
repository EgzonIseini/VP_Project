using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project
{
    /// <summary>
    /// This class will store the constants used accros the app
    /// </summary>
    public class Constants
    {
        public static readonly int BLOCK_WIDTH = 40;
        public static readonly int BLOCK_HEIGHT = 40;
        public static readonly float PEN_WIDTH = 4.5F;
        public static readonly Random RANDOM = new Random();
        public static readonly int TIMER_60_FPS = 16; //unit is ms
        public static readonly int TIMER_30_FPS = 32;
        public static readonly float BLOCK_MOVE_SPEED = 5F;
        public static readonly int PROBABILITY_OF_BLOCK = 5; // determines the probability of a block being generated in a row
        public static readonly int NUM_OF_BLOCKS_IN_ROW = 10;
        public static readonly float BALL_RADIUS = 5F; // dummy value for calcuation purposes, change it accordingly
        public static readonly int DELTA = 0;
        public static int WINDOW_HEIGHT;
        public static int WINDOW_WIDTH;

        public static readonly int FORM_TOP = 30;
        public static readonly int FORM_BOTTOM = 600;
        public static readonly int FORM_LEFT = 0;
        public static readonly int FORM_RIGHT = 420;

		public static readonly int POWERUP_X = 15;
		public static readonly int POWERUP_Y = 15;
		public static readonly int POWERUP_RADIUS = 15;

		public static readonly int PROBABILITY_OF_POWERUPS = 3;

		public static Image[] powerUpImages =
		{
			null,
			Properties.Resources.ball,
			Properties.Resources.coin,
			Properties.Resources.doubledmg,
			Properties.Resources.doubleball,
			Properties.Resources.finki
		};

		// <--------------- PER GAME POWERUP VARS ---------------------->

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
	}
}
