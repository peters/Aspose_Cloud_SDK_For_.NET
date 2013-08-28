using System.Collections.Generic;

namespace Aspose.Cloud.Slides
{
    /// <summary>
    /// represents container part of the slides resource response
    /// </summary>
    public class SlidesEnvelop
    {

        public List<string> AlternateLinks { get; set; }
        public List<string> Links { get; set; }
        public string SelfUri { get; set; }
        public List<SlideResponse> SlideList { get; set; }
    }
}
