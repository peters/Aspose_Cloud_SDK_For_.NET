using System.Collections.Generic;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// represents container part of the Annotations resource response
    /// </summary>
   public  class AnnotationsEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Annotation> List { get; set; }
    }
}
