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
            RectangleF rec = new RectangleF(this.X, this.Y, Constants.BLOCK_WIDTH, Constants.BLOCK_HEIGHT);
            DrawHP(g, rec);
            g.DrawRectangle(pen, Rectangle.Round(rec));
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, Constants.PEN_WIDTH);
            DrawBlock(pen, g);
            pen.Dispose();
        }

        private float GetDistance(Point p1, Point p2)
        {
            return (float) Math.Sqrt(((p1.Y - p2.Y) * (p1.Y - p2.Y)) + (p1.X - p2.X) * (p1.X - p2.X));
        }

        public override bool CollisionTest(float X, float Y, int BallPower = 1)
        {
            int x = (int) this.X;
            int y = (int) this.Y;
            Point a = new Point(x, y);
            Point b = new Point(x + Constants.BLOCK_WIDTH, y);
            Point c = new Point(x, y + Constants.BLOCK_HEIGHT);
            Point d = new Point(x + Constants.BLOCK_WIDTH, y + Constants.BLOCK_HEIGHT);
            Point Circle = new Point((int) X, (int) Y);

            float o1 = GetDistance(Circle, a);
            float o2 = GetDistance(Circle, b);
            float o3 = GetDistance(Circle, c);
            float o4 = GetDistance(Circle, d);

            return false;
        }
    }
}
