using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
	public partial class cheatMenu : Form
	{
		public int newScore { get; set; }
		public int newBalls { get; set; }

		public int newBallMult { get; set; }
		public int newScoreMult { get; set; }
		public int newDamageMult { get; set; }

		public cheatMenu(int score, int scoremult, int damagemult, int ballmult)
		{
			InitializeComponent();

			newScore = score;
			newScoreMult = scoremult;
			newDamageMult = damagemult;
			newBallMult = ballmult;

			numCurrentScore.Value = score;
			numScoreMult.Value = scoremult;
			numDamageMult.Value = damagemult;
			numBallMult.Value = ballmult;
		}

		private void cheatMenu_Load(object sender, EventArgs e)
		{

		}

		private void numDamageMult_ValueChanged(object sender, EventArgs e)
		{
			newDamageMult = (int)numDamageMult.Value;
		}

		private void numScoreMult_ValueChanged(object sender, EventArgs e)
		{
			newScoreMult = (int)numScoreMult.Value;
		}

		private void numBallMult_ValueChanged(object sender, EventArgs e)
		{
			newBallMult = (int)numBallMult.Value;
		}

		private void numCurrentScore_ValueChanged(object sender, EventArgs e)
		{
			newScore = (int)numCurrentScore.Value;
		}
	}
}
