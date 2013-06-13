using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cloud.Slides;

namespace Aspose.Cloud.Slides
{
    public class Minor
    {
        public string ComplexScript { get; set; }
        public string EastAsian { get; set; }
        public string Latin { get; set; }
    }
    public class Major
    {
        public string ComplexScript { get; set; }
        public string EastAsian { get; set; }
        public string Latin { get; set; }
    }
    public class FontScheme
    {
        public FontScheme() { }
        public UriResponse SelfUri { get; set; }
        public Major Major { get; set; }
        public Minor Minor { get; set; }
        public string Name { get; set; }

    }

}
