﻿using System.Collections.Generic;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents container part of the Bookmarks resource response
    /// </summary>
    public class BookmarksEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Bookmark> List { get; set; }
    }
}
