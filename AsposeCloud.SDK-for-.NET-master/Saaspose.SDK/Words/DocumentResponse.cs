using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Words
{
    public class DocumentResponse : Aspose.Cloud.Common.BaseResponse
    {
        /// <summary>
        /// Document Properties response
        /// </summary>
        public DocumentPropertiesResponse DocumentProperties { get; set; }

        /// <summary>
        /// Document Property response
        /// </summary>
        public DocumentProperty DocumentProperty { get; set; }
    }
}
