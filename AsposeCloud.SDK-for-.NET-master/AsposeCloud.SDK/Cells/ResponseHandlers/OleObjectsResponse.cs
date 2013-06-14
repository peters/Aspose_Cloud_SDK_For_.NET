using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the OleObjects resource
    /// </summary>
    public class OleObjectsResponse : Aspose.Cloud.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        public List<LinkResponse> OleOjectList { get; set; }

        public OleObject OleObject { get; set; }

    }
}
