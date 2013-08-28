using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Hyperlinks resource
    /// </summary>
    public class HyperlinksResponse : Aspose.Cloud.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        public int Count { get; set;}
               
        public List<LinkResponse> HyperlinkList { get; set; }

        public Hyperlink Hyperlink { get; set; }

    }
}
