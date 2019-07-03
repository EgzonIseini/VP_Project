using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Blocks
{
    [Serializable]
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

					if( current == 1 )
					{
						int powerupType = Constants.RANDOM.Next(1, 5);
						Blocks.Add(new PowerUp(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT + 3, Constants.BLOCK_HEIGHT + Constants.FORM_TOP, powerupType));
					}
					else
					{
						Blocks.Add(new SquareBlock(i * Constants.BLOCK_WIDTH + Constants.FORM_LEFT + 3, Constants.BLOCK_HEIGHT + Constants.FORM_TOP, RowNum));
					}
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

        /// <summary>
        /// Checks if row contains any blocks
        /// </summary>
        /// <returns>true if empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return Blocks.Count == 0;
        }

        /// <summary>
        /// Method to check whether row is out of the bounds of the window
        /// </summary>
        /// <returns>true if it is out of bounds, false otherwise</returns>
        public bool IsOut()
        {
            Block tmp = Blocks[0];
            return (tmp.Y + 3 * Constants.BLOCK_HEIGHT > Constants.WINDOW_HEIGHT);
        }

        /// <summary>
        /// Method used when game is reseted, resets the row num to 0
        /// </summary>
        public static void ResetGame()
        {
            RowNum = 0;
        }

        /// <summary>
        /// Method used for getting the ordered number of row
        /// </summary>
        public static int SetRowNum(int n)
        {
            return RowNum = n;
        }
    }
}
