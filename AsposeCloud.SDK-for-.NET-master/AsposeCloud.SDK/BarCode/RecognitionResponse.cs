using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cloud.Common;

namespace Aspose.Cloud.BarCode
{
    public class RecognitionResponse : BaseResponse
    {
        //public RecognitionEnvelop Barcodes { get; set; }
        public List<RecognizedBarCode> Barcodes { get; set; }
    }
}
