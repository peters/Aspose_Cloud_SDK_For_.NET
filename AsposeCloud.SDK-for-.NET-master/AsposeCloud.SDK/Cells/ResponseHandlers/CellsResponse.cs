﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the Cells resource
    /// </summary>
    public class CellsResponse : Aspose.Cloud.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public int CellCount { get; set; }
               
        public List<LinkResponse> CellList { get; set; }

        public int MaxRow { get; set; }

        public int MaxColumn { get; set; }

        public Cell Cell { get; set; }

        public Style Style { get; set; }
    }
}
