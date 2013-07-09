using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Words
{
    public class ProtectionRequest
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ProtectionType { get; set; }
    }

    public enum ProtectionType
    {
        AllowOnlyComments,
        AllowOnlyFormFields,
        AllowOnlyRevisions,
        ReadOnly,
        NoProtection
    }

    public class DocumentLink
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public object Type { get; set; }
        public object Title { get; set; }
    }
    public class ProtectionData
    {
        public string ProtectionType { get; set; }
    }
    public class ProtectionResponse: Aspose.Cloud.Common.BaseResponse
    {

        public DocumentLink DocumentLink { get; set; }
            public ProtectionData ProtectionData { get; set; }
    }
}
