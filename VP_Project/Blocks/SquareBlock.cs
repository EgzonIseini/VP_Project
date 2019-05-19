using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project.Blocks
{
    public class SquareBlock : Block
    {

        public SquareBlock(float X, float Y, int HP) : base(X, Y, HP)
        {
        }

        private void DrawHP(Graphics g, RectangleF rec)
        {
            Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(HP + "", font, Brushes.Red, rec, stringFormat);
        }

        private void DrawBlock(Pen pen, Graphics g)
        {
            RectangleF rec = new RectangleF(X, Y, Constants.SQUARE_BLOCK_WIDTH, Constants.SQUARE_BLOCK_HEIGHT);
            DrawHP(g, rec);
            g.DrawRectangle(pen, Rectangle.Round(rec));
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, Constants.PEN_WIDTH);
            DrawBlock(pen, g);
            pen.Dispose();
        }
    }
}
