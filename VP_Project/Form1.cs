using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Project.Blocks;
using System.Windows.Forms;
using System.Diagnostics;

namespace VP_Project
{
    public partial class Game : Form
    {
        List<Row> rows;

		// powerupType is equals to the powerupTypes. IF 0 => player has no powerups!
		// Can't have more than one powerup at a time. Initialized originally to 0.
		private int powerupType;

        public Game()
        {
            InitializeComponent();
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            rows = new List<Row>();
            rows.Add(new Row());
			this.powerupType = 0;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        { 
            // This is the first line which sets the canvas for painting. Only use this
            // to initalize the canvas i.e. set color, size etc.
            e.Graphics.Clear(Color.DimGray);
            
            // Any other type of drawing goes below this comment.
            foreach (Row row in rows) { 
                row.DrawBlocks(e.Graphics);
            }
        }

        private void MoveRowsDown()
        {
            timerDraw.Enabled = false;
            for (float f = 0; f < Constants.BLOCK_HEIGHT; f += Constants.BLOCK_MOVE_SPEED)
            {
                foreach (Row row in rows)
                {
                    row.MoveRowDown();
                    this.Refresh();
                }
            }
            rows.Add(new Row());
            this.Refresh();
            timerDraw.Enabled = true;
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            Invalidate(true);
        }

		private void Game_MouseClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine("Clicked at X: {0}, Y: {1}", e.X, e.Y);
			foreach(Row row in rows)
			{
				row.CollisionsTest(e.X, e.Y);
			}

			powerupType = PowerUp.currentPowerup;

			Invalidate(true);

			if (powerupType != 0)
			{
				MessageBox.Show(string.Format("Picked up a powerup of type: {0}", powerupType.ToString()));
			}
		}
	}
}
