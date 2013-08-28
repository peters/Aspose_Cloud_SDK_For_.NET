using Aspose.Cloud.Common;
using System.Collections.Generic;

namespace Aspose.Cloud.BarCode
{
    public class RecognitionResponse : BaseResponse
    {
        //public RecognitionEnvelop Barcodes { get; set; }
        public List<RecognizedBarCode> Barcodes { get; set; }
    }
}
