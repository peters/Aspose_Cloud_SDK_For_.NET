using System.Collections.Generic;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents a single text item
    /// </summary>
    public class TextFormat
    {
        public TextFormat() { }

        public List<LinkResponse> Links { get; set; }
        public Color Color { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }

    }
}
