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
        public static readonly float BLOCK_MOVE_SPEED = 3F;
        public static readonly int PROBABILITY_OF_BLOCK = 5; // determines the probability of a block being generated in a row
        public static readonly int NUM_OF_BLOCKS_IN_ROW = 10;
        public static readonly float BALL_RADIUS = 5F; // dummy value for calcuation purposes, change it accordingly
        public static readonly int DELTA = 0;

        public static readonly int FORM_TOP = 30;
        public static readonly int FORM_BOTTOM = 620;
        public static readonly int FORM_LEFT = 0;
        public static readonly int FORM_RIGHT = 420;

		public static readonly int POWERUP_X = 15;
		public static readonly int POWERUP_Y = 15;
		public static readonly int POWERUP_RADIUS = 15;

		public static Image[] powerUpImages =
		{
			null,
			Properties.Resources.coin,
			Properties.Resources.doubledmg,
			Properties.Resources.doubleball,
			Properties.Resources.finki
		};
	}
}
