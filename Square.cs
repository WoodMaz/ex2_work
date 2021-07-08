using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_work
{
    class Square : Shape
    {
        public Square(int x, int y, int a, Color color) : base(x, y, a, color)
        {
        }

        public override void draw(Graphics g)
        {
            SolidBrush fill = new SolidBrush(pen.Color);

            g.DrawRectangle(pen, shape);
            g.FillRectangle(fill, shape);
        }

    }
}
