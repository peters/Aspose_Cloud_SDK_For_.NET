﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents response of a single text item
    /// </summary>
    public class ReplaceTextResponse : Aspose.Cloud.Common.BaseResponse
    {
        public List<LinkResponse> Links { get; set; }
        public int Matches { get; set; }        
    }
}
