using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Diagnostics;

namespace VP_Project.Blocks
{
    [Serializable]
    public enum PowerupType
	{
		None = 0,
		ExtraPoints = 1,
		DoubleDamage = 2,
		DoubleBalls = 3,
		FINKI = 4
	}
    [Serializable]
    public class PowerUp : Block
    {
		public static int currentPowerup = 0;

		public int Type { get; set; }

		public Point Center { get; set; }

		public Point Collision { get; set; }

		public Bitmap Image { get; set; }

		public PowerUp(int X, int Y, int type) : base(X, Y, 1)
		{
			Center = new Point(X, Y);
			Collision = new Point(X + Constants.POWERUP_X, Y + Constants.POWERUP_X);
			Type = type;
			if(type != 0) Image = new Bitmap(Constants.powerUpImages[type]);
		}

		public override void Draw(Graphics g)
		{
			if( Type != 0)
			{
				Point center = new Point((int)this.X, (int)this.Y);
				g.DrawImage(Image, center);
			}
		}

		private int GetDistance(Point powerup, int X, int Y)
		{
			return (int)Math.Sqrt((powerup.X - X) * (powerup.X - X) + (powerup.Y - Y) * (powerup.Y - Y));
		}

        public override int WasHit(int amount = 1)
        {
            DeductHP(amount);
            return Type;
        }
    }
}