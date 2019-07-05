using System;
using System.Collections.Generic;
using VP_Project.Blocks;

namespace VP_Project
{
    [Serializable]
    public class GameState
    {
        public List<Row> Rows { get; set; }
        public int Score { get; set; }
        public int DamagePowerUp { get; set; }
        public int ScorePowerUp { get; set; }
        public int BallPowerUp { get; set; }
        public int BallsToAdd { get; set; }

        public GameState(List<Row> rows, int score, int damagePowerUp, int scorePowerUp, int ballPowerUp, int ballsToAdd)
        {
            Rows = rows;
            Score = score;
            DamagePowerUp = damagePowerUp;
            ScorePowerUp = scorePowerUp;
            BallPowerUp = ballPowerUp;
            BallsToAdd = ballsToAdd;
        }

        public GameState()
        {
            Rows = new List<Row>();
        }
    }
}
