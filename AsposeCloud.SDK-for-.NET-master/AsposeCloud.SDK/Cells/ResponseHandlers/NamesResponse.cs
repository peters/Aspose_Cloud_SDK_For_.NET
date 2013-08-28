using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Names resource
    /// </summary>
    public class NamesResponse : Aspose.Cloud.Common.BaseResponse
    {
       
        public LinkResponse link { get; set; }

        public int Count { get; set; }

        public List<Name> NameList { get; set; }
    }
}
