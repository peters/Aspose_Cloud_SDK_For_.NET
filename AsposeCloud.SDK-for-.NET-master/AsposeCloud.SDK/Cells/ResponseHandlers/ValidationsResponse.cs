using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Validations resource
    /// </summary>
    public class ValidationsResponse : Aspose.Cloud.Common.BaseResponse
    {       
        public LinkResponse link { get; set; }

        public int Count { get; set; }
            
        public List<LinkResponse> ValidationList { get; set; }

        public Validation Validation { get; set; }

    }
}
