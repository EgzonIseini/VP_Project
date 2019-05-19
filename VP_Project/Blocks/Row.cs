using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Blocks
{
    public class Row
    {
        private List<Block> blocks;
        private static int RowNum = 0;

        public Row()
        {
            blocks = new List<Block>();
            RowNum++;
            GenerateRow();
        }
        
        private void GenerateRow()
        {
            for (int i = 0; i < Constants.NUM_OF_BLOCKS_IN_ROW; i++)
            {
                int current = Constants.RANDOM.Next(1, 10);
                if (current <= Constants.PROBABILITY_OF_BLOCK)
                {
                    blocks.Add(new SquareBlock(i * Constants.SQUARE_BLOCK_WIDTH + Constants.FORM_LEFT, 0F + Constants.FORM_TOP, RowNum));
                }
            }
        }

        public void DrawBlocks(Graphics g)
        {
            foreach (Block b in blocks)
            {
                b.Draw(g);
            }
        }

    }
}
