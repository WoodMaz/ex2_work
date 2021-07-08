using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2_work
{
    public partial class Form1 : Form
    {
        Shape square, circle, clickedShape;
        private Point MouseDownLocation;



        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            square = new Shape(20, 20, 100, Color.Red);
            circle = new Shape(20, 140, 100, Color.Blue);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            square.drawSquare(g);
            circle.drawCircle(g);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
                if (square.isClicked(MouseDownLocation))
                {
                    clickedShape = square;
                }
                else if (circle.isClicked(MouseDownLocation))
                {
                    clickedShape = circle;
                }
            }
        }

        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clickedShape != null)
            {
                switch (colorBox.SelectedItem)
                {
                    case "Red":    clickedShape.Color = Color.Red;    break;
                    case "Orange": clickedShape.Color = Color.Orange; break;
                    case "Yellow": clickedShape.Color = Color.Yellow; break;
                    case "Green":  clickedShape.Color = Color.Green;  break;
                    case "Blue":   clickedShape.Color = Color.Blue;   break;
                    case "Purple": clickedShape.Color = Color.Purple; break;
                    case "White":  clickedShape.Color = Color.White;  break;
                    case "Gray":   clickedShape.Color = Color.Gray;   break;
                    case "Black":  clickedShape.Color = Color.Black;  break;
                }
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (clickedShape != null)
            {
                /*if (e.Button == MouseButtons.Right) //resize
                {
                    clickedShape.Size = e.Y - clickedShape.Y;
                    this.Invalidate();
                }*/

                if (e.Button == MouseButtons.Left) //move
                {
                    clickedShape.move(e, MouseDownLocation);
                    MouseDownLocation = e.Location;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (clickedShape != null)
            {
                // If the mouse wheel is moved forward (Zoom in)
                if (e.Delta > 0)
                {
                    // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                    if ((clickedShape.Size < (15 * this.Width)))
                    {
                        clickedShape.Size = (int)(clickedShape.Size * 1.25);
                    }
                }
                else
                {
                    // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                    if ((clickedShape.Size > (this.Width / 15)))
                    {
                        clickedShape.Size = (int)(clickedShape.Size / 1.25);
                    }
                }
                this.Invalidate();
            }
        }
    }
}
