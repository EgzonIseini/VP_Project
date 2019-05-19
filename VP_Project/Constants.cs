﻿using System;
using System.Collections.Generic;
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
        public static readonly int SQUARE_BLOCK_WIDTH = 40;
        public static readonly int SQUARE_BLOCK_HEIGHT = 40;
        public static readonly float PEN_WIDTH = 4.5F;
        public static readonly Random RANDOM = new Random();
        public static readonly int TIMER_60_FPS = 16; //unit is ms
        public static readonly int TIMER_30_FPS = 32;
        public static readonly int BLOCK_MOVE_SPEED;
    }
}
