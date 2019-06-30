﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Blocks
{
    public class Row
    {
        public List<Block> Blocks { get; }
        private static int RowNum = 0;
        /// <summary>
        /// Genertes new Row in Game
        /// </summary>
        public Row()
        {
            Blocks = new List<Block>();
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

					//if(randomPowerUp % 2 == 0) Blocks.Add(new SquareBlock(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT, 0F + Constants.FORM_TOP, RowNum));
					//else Blocks.Add(new PowerUp((int)i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT, (int)0F + Constants.FORM_TOP, type));

					Blocks.Add(new SquareBlock(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT + 3, Constants.BLOCK_HEIGHT + Constants.FORM_TOP, RowNum));
				}
            }
        }

        /// <summary>
        /// Draws the Blocks
        /// </summary>
        public void DrawBlocks(Graphics g)
        {
            RemoveKilledBlocks();

            foreach (Block b in Blocks)
            {
                b.Draw(g);
            }
        }

        /// <summary>
        /// Helper method to remove blocks with HP<=0 
        /// </summary>
        private void RemoveKilledBlocks()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (!Blocks[i].exists)
                    Blocks.RemoveAt(i--);
            }
        }

        /// <summary>
        /// Moves the blocks one row down
        /// </summary>
        public void MoveRowDown()
        {
            foreach (Block block in Blocks)
            {
                block.Y = block.Y + Constants.BLOCK_MOVE_SPEED;
            }
        }

    }
}
