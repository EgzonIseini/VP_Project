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

namespace VP_Project
{
    public partial class Game : Form
    {
        Block block, block2;
        bool clicked;
        public Game()
        {
            InitializeComponent();
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            block = new SquareBlock(10, 10, 100);
            block2 = new SquareBlock(200, 500, 50);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            clicked = false;
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        { 
            // This is the first line which sets the canvas for painting. Only use this
            // to initalize the canvas i.e. set color, size etc.
            e.Graphics.Clear(Color.DimGray);

            // Any other type of drawing goes below this comment.
            block.Draw(e.Graphics);
            block2.Draw(e.Graphics);
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            Invalidate(true);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            block.MoveDown();
        }
    }
}
