using System.Collections.Generic;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents a single text item
    /// </summary>
    public class Color
    {
        public Color() { }
        public Color(int a, int r, int g, int b)
        {
            A = a;
            B = b;
            R = r;
            G = g;
        }
        public List<LinkResponse> Links { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public int R { get; set; }

        

    }
}
