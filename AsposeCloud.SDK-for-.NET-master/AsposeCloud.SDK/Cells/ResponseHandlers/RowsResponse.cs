using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Rows resource
    /// </summary>
    public class RowsResponse : Aspose.Cloud.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public int RowCount { get; set; }
               
        public List<LinkResponse> RowsList { get; set; }


        public Row Row { get; set; }
       
    }
}
