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
        /// <summary>
        /// Genertes new Row in Game
        /// </summary>
        public Row()
        {
            blocks = new List<Block>();
            RowNum++;
            GenerateRow();
        }
        
        /// <summary>
        /// Internal method to generate row in random fashion
        /// </summary>
        private void GenerateRow()
        {
            for (int i = 0; i < Constants.NUM_OF_BLOCKS_IN_ROW; i++)
            {
                int current = Constants.RANDOM.Next(1, 10);
               
                if (current < Constants.PROBABILITY_OF_BLOCK)
                {
					//Delete this, only for testing...
					//int randomPowerUp = Constants.RANDOM.Next(0, 101);
					//int type = Constants.RANDOM.Next(1, 5);

					//if(randomPowerUp % 2 == 0) blocks.Add(new SquareBlock(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT, 0F + Constants.FORM_TOP, RowNum));
					//else blocks.Add(new PowerUp((int)i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT, (int)0F + Constants.FORM_TOP, type));

					blocks.Add(new SquareBlock(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT, 0F + Constants.FORM_TOP, RowNum));
				}
            }
        }

        /// <summary>
        /// Draws the Blocks
        /// </summary>
        public void DrawBlocks(Graphics g)
        {
            foreach (Block b in blocks)
            {
                b.Draw(g);
            }
        }

        /// <summary>
        /// Checks if any collision has happened and takes action accordingly
        /// </summary>
        /// <param name="X">X-coordinate of ball</param>
        /// <param name="Y">Y-coordinate of ball</param>
        /// <param name="BallPower">Power of Ball, default value 1</param>
        public void CollisionsTest(float X, float Y, int BallPower = 1)
        {
            foreach (Block block in blocks)
            {
                block.CollisionTest(X, Y, BallPower);
            }

            for (int i = 0; i < blocks.Count; i++)
            {
                if (!blocks[i].exists)
                    blocks.RemoveAt(i--);
            }
        }

        public void MoveRowDown()
        {
            foreach (Block block in blocks)
            {
                block.Y = block.Y + Constants.BLOCK_MOVE_SPEED;
            }
        }


    }
}
