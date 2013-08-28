using System.Collections.Generic;

namespace Aspose.Cloud.Pdf
{
   
    /// <summary>
    /// represents container part of the Attachment resource response
    /// </summary>
   public  class AttachmentsEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Attachment> List { get; set; }
    }
}
