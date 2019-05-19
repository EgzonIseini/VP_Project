using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Balls
{
    class Balls
    {
        //numbers of balls
        int n;
        List<Ball> allBalls;
        public Balls(int n, Color color, float Angle) 
        {
            this.allBalls = new List<Ball>();
            for(int i=0;i<n;i++)
            {
                allBalls.Add(new Ball(new Point(Constants.FORM_RIGHT / 2, 0), color, Angle));
            }
        }
        public void checkBalls()
        {
            for(int i=0;i<n;i++)
            {
                if(allBalls.ElementAt(i).BallDead)
                {
                    if (n == 0) break;
                    allBalls.RemoveAt(i);
                    n--;
                    i--;
                }
            }
        }
        public bool AnyBallsLeft()
        {
            return n == 0;
        }

    }
}
