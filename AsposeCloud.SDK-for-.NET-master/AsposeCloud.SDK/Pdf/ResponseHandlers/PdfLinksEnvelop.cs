using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents container part of the Pdf Links resource response
    /// </summary>
   public  class PdfLinksEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Link> List { get; set; }
    }
}
