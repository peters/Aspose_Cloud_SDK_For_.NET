using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Comments resource
    /// </summary>
    public class CommentsResponse : Aspose.Cloud.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        public List<LinkResponse> CommentList { get; set; }

        public Comment Comment { get; set; }
    }
}
