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
        SquareBlock block;
        public Form1()
        {
            InitializeComponent();
            block = new SquareBlock(new Point(10, 10), 100);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            block.Draw(e.Graphics);
        }
    }
}
