using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    public class PdfDocument
    {
        public List<LinkResponse> Links { get; set; }
        public DocumentPropertiesEnvelop DocumentProperties { get; set; }
        public PagesEnvelop Pages { get; set; }
    }
}
