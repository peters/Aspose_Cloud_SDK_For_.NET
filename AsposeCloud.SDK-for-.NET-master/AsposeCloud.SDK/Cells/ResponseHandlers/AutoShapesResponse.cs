using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    /// Represents response from the Autoshape resource
    /// </summary>
    public class AutoShapesResponse : Aspose.Cloud.Common.BaseResponse
    {
       
        public LinkResponse link { get; set; }
                
        public List<LinkResponse> AuotShapeList { get; set; }

        public AutoShape AutoShape { get; set; }
    }
}
