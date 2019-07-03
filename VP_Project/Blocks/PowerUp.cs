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
	public enum PowerupType
	{
		None = 0,
		AddBall = 1,
		ExtraPoints = 2,
		DoubleDamage = 3,
		DoubleBalls = 4,
		FINKI = 5
	}

	public class PowerUp : Block
    {
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
	
		public PowerUp(int X, int Y, PowerupType powerup) : this(X, Y, (int)powerup)
		{ }

		public override void Draw(Graphics g)
		{
			if( Type != 0)
			{
				Point center = new Point((int)this.X, (int)this.Y);
				g.DrawImage(Image, center);
			}
		}

		/// <summary>
		///	Called from Block class.
		/// </summary>
		public void PowerupHit()
		{
			Game.powerups.Add(Type);
		}

		private int GetDistance(Point powerup, int X, int Y)
		{
			return (int)Math.Sqrt((powerup.X - X) * (powerup.X - X) + (powerup.Y - Y) * (powerup.Y - Y));
		}
	}
}