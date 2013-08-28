using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the MergedCells resource
    /// </summary>
    public class MergedCellsResponse : Aspose.Cloud.Common.BaseResponse
    {      
        public LinkResponse link { get; set; }

        public int Count { get; set; }

        public List<LinkResponse> MergedCellList { get; set; }

        public MergedCell MergedCell { get; set; }

    }
}
