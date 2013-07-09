using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Words
{
    public class BookmarkData
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
    public class BookmarkResponse : Aspose.Cloud.Common.BaseResponse
    {
        public Bookmark bookmark { get; set; }
    }
    public class Bookmark
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
