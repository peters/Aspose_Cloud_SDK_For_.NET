using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Charts resource
    /// </summary>
    public class ChartsResponse : Aspose.Cloud.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        /// <summary>
        /// Document Property
        /// </summary>
        public List<LinkResponse> ChartList { get; set; }

        public Chart Chart { get; set; }

    }
}
