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
        public SquareBlock(Point Location, int HP) : base(Location, HP)
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

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, Constants.PEN_WIDTH);
            RectangleF rec = new RectangleF(Location.X, Location.Y, Constants.SQUARE_BLOCK_WIDTH, Constants.SQUARE_BLOCK_HEIGHT);
            DrawHP(g, rec);
            g.DrawRectangle(pen, Rectangle.Round(rec));
            pen.Dispose();
        }

        public override void Move()
        {
            
        }
    }
}
