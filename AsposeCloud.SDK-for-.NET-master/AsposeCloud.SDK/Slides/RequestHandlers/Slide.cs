using System.Collections.Generic;

namespace Aspose.Cloud.Slides
{
    public class Slide
    {
        public List<LinkResponse> _links { get; set; }
        public Images Images { get; set; }
        public Placeholders Placeholders { get; set; }
        public Shapes Shapes { get; set; }
        public SlideTheme Theme { get; set; }
    }
}
