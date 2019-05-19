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
    public partial class Form1 : Form
    {
        Block block;
        public Form1()
        {
            InitializeComponent();
            timerDraw.Enabled = true;
            timerDraw.Interval = Constants.TIMER_60_FPS;
            block = new SquareBlock(10, 10, 100);
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            block.Draw(e.Graphics);
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            Invalidate(true);   
        }
    }
}
