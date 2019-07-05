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
	/*
	 *  Powerup Types:
	 *  
	 *		None			- 0
	 *		AddBall			- 1
	 *		Extra Points	- 2
	 *		Double Damage	- 3
	 *		Double Balls	- 4
	 *		FINKI (NU)		- 5
	 *		
	 *		NU - Not used.
	 */


    [Serializable]
    public class PowerUp : Block
    {
		// ----- Type of powerup.
		public int Type { get; set; }

		// ----- Powerup center coordinates.
		public Point Center { get; set; }

		// ----- Powerup center + its diameter.
		public Point Collision { get; set; }

		// ----- Image of the powerup itself. Images are defined within CONSTANTS
		public Bitmap Image { get; set; }

		public PowerUp(int X, int Y, int type) : base(X, Y, 1)
		{
			Center = new Point(X, Y);
			Collision = new Point(X + Constants.POWERUP_X, Y + Constants.POWERUP_X);
			Type = type;
			if(type != 0) Image = new Bitmap(Constants.powerUpImages[type]);
		}

		/// <summary>
		/// Function which draws the power-ups, called from OnPain event of the main Form.
		/// </summary>
		/// <param name="g"> The Graphics object on which to draw on. </param>
		public override void Draw(Graphics g)
		{
			// if Powerup is 0 i.e. None, will skip drawing. For every other powerup, it will draw it,
			if( Type != 0)
			{
				Point center = new Point((int)this.X, (int)this.Y);
				g.DrawImage(Image, center);
			}
		}

		/// <summary>
		///	Called from Block class when the ball hit goes through this.powerup , 
		///	and adds it type to the powerup list in the Main form.
		/// </summary>
		public void PowerupHit()
		{
			Game.powerups.Add(Type);
		}

		/// <summary>
		///	Internal GetDistance method for the powerups. Block i.e. base class already has this,
		///	but here its redefined to match the different shape of the power-ups (Circle instead of Square).
		/// </summary>
		/// <param name="powerup"> Center point of the powerup. </param>
		/// <param name="X"> Ball X-Coordinate </param>
		/// <param name="Y"> Ball Y-Coordinate</param>
		/// <returns> Returns distance between the ball and the powerup. If inside powerup returns =< Diameter.</returns>
		private int GetDistance(Point powerup, int X, int Y)
		{
			return (int)Math.Sqrt((powerup.X - X) * (powerup.X - X) + (powerup.Y - Y) * (powerup.Y - Y));
		}

		/// <summary>
		/// Called when powerup is hit / passed by with a ball. To be used more extensively later.
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
        public override int WasHit(int amount = 1)
        {
            DeductHP(amount);
            return Type;
        }
    }
}