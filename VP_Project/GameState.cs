using System;
using System.Collections.Generic;
using VP_Project.Blocks;

namespace VP_Project
{
    [Serializable]
    public class GameState
    {
        public Balls.Balls Balls { get; set; }
        public List<Row> Rows { get; set; }
        public int Score { get; set; }
        public int DamagePowerUp { get; set; }
        public int ScorePowerUp { get; set; }
        public int BallPowerUp { get; set; }
        public int BallsToAdd { get; set; }

        public GameState(Balls.Balls balls, List<Row> rows, int score, int damagePowerUp, int scorePowerUp, int ballPowerUp, int ballsToAdd)
        {
            Balls = balls;
            Rows = rows;
            Score = score;
            DamagePowerUp = damagePowerUp;
            ScorePowerUp = scorePowerUp;
            BallPowerUp = ballPowerUp;
            BallsToAdd = ballsToAdd;
        }

        public GameState()
        {
        }
    }
}
