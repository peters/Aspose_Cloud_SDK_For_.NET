using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.OCR 
{
    public class OCRResponse : Aspose.Cloud.Common.BaseResponse
    {
        public OCREnvelop PartsInfo { get; set; }
        public string Text { get; set; }
    }
}
