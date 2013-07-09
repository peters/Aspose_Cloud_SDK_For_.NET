using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Words
{
    public class SplitResultResponse : Aspose.Cloud.Common.BaseResponse
    {
        public SplitResult SplitResult { get; set; }
    }
    public class Page
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public object Title { get; set; }
        public object Type { get; set; }
    }

    public class SourceDocument
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public object Title { get; set; }
        public object Type { get; set; }
    }

    public class SplitResult
    {
        public List<Page> Pages { get; set; }
        public SourceDocument SourceDocument { get; set; }
    }

    
}
