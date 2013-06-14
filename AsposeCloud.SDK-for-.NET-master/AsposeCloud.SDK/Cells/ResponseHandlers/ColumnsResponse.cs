using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Column resource
    /// </summary>
    public class ColumnsResponse : Aspose.Cloud.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public int MaxColumn { get; set; }
               
        public List<LinkResponse> ColumnsList { get; set; }


        public Column Column { get; set; }
       
    }
}
