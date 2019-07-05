using System;
using System.Drawing;


namespace VP_Project.Blocks
{
    [Serializable]
    public class SquareBlock : Block
    {
        public SquareBlock(float X, float Y, int HP) : base(X, Y, HP)
        {
        }

        /// <summary>
        /// Helper method to draw the HP of each block
        /// </summary>
        private void DrawHP(Graphics g, RectangleF rec)
        {
            Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            if (WasHitRecently)
                g.DrawString(HP + "", font, Brushes.White, rec, stringFormat);
            else
                g.DrawString(HP + "", font, Brushes.LightPink, rec, stringFormat);
        }

        /// <summary>
        /// Helper method to draw the outline of a block
        /// </summary>
        private void DrawBlock(Pen pen, Graphics g)
        {
            RectangleF rec = new RectangleF(this.X, this.Y, Constants.BLOCK_WIDTH, Constants.BLOCK_HEIGHT);
            DrawHP(g, rec);
            if (WasHitRecently)
            {
                WasHitRecently = false;
                g.FillRectangle(pen.Brush, Rectangle.Round(rec));
            }
            else
            {
                g.DrawRectangle(pen, Rectangle.Round(rec));
            }
            
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.LightPink, Constants.PEN_WIDTH);
            DrawBlock(pen, g);
            pen.Dispose();
        }

        public override int WasHit(int amount = 1)
        {
            //Increase score for every hit.
            Game.currentScore += amount * Game.damageMultiplier * Game.scoreMultiplier;

            DeductHP(amount);
            return 0;
        }
    }
}
