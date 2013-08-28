using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Pictures resource
    /// </summary>
    public class PicturesResponse : Aspose.Cloud.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public List<LinkResponse> PictureList { get; set; }

        public Picture Picture { get; set; }

    }
}
