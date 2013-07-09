using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// Represents rectangle.
    /// </summary>
    public class Rectangle
    {
        public Rectangle() { }
        public Rectangle(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
        public Rectangle(System.Drawing.Rectangle rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        {

        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public System.Drawing.Rectangle ToNative()
        {
            return new System.Drawing.Rectangle(X, Y, Width, Height);
        }
    }
}
