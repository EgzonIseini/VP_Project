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
        SquareBlock block;
        public Game()
        {
            InitializeComponent();
            block = new SquareBlock(new Point(10, 10), 100);
            
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        { 
            // This is the first line which sets the canvas for painting. Only use this
            // to initalize the canvas i.e. set color, size etc.
            e.Graphics.Clear(Color.DimGray);

            // Any other type of drawing goes below this comment.
            block.Draw(e.Graphics);
        }
    }
}
