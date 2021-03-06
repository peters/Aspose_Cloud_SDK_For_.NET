﻿using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the TextItems resource
    /// </summary>
    public class TextItemsResponse
    {
        public TextItemsResponse() { }
       
        public LinkResponse link { get; set; }
     
        public List<TextItem> TextItemList { get; set; }
    }
}
