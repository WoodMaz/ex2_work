using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2_work
{
    public class Shape
    {
        Rectangle shape;
        Pen pen;

        public Shape(int x, int y, int a, Color color)
        {
            shape = new Rectangle(x, y, a, a);
            pen = new Pen(color);
        }

        public void drawSquare(Graphics g)
        {
            g.DrawRectangle(pen, shape);

            SolidBrush fill = new SolidBrush(pen.Color);
            g.FillRectangle(fill, shape);
        }

        public void drawCircle(Graphics g)
        {
            g.DrawEllipse(pen, shape);

            SolidBrush fill = new SolidBrush(pen.Color);
            g.FillEllipse(fill, shape);
        }

        public void move(MouseEventArgs e, Point MouseDownLocation)
        {
            shape.Location = new Point((e.X - MouseDownLocation.X) + shape.Left, (e.Y - MouseDownLocation.Y) + shape.Top);
        }

        public bool isClicked(Point p)
        {
            if (p.X >= shape.X && p.X <= shape.X + shape.Width &&
                p.Y >= shape.Y && p.Y <= shape.Y + shape.Height)
                {
                     return true;
                }
            return false;
        }

        public Color Color
        {
            get => pen.Color;
            set => pen.Color = value;
        }

        public int X
        {
            get => shape.X;
        }

        public int Y
        {
            get => shape.Y;
        }

        public int Size
        {
            get => shape.Width;
            set
            {
                shape.Width = value;
                shape.Height = value;
            }
        }
    }
}
