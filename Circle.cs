using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_work
{
    class Circle : Shape
    {
        public Circle(int x, int y, int a, Color color) : base(x, y, a, color)
        {
        }

        public override void draw(Graphics g)
        {
            SolidBrush fill = new SolidBrush(pen.Color);

            g.DrawEllipse(pen, shape);
            g.FillEllipse(fill, shape);
        }

    }
}
