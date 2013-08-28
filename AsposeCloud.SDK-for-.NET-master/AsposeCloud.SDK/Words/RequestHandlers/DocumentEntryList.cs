using System.Collections.Generic;
using System.Xml.Serialization;

namespace Aspose.Cloud.Words
{
    

    [XmlRoot(ElementName = "documents")]
    public class DocumentEntryList
    {
        [XmlElement("document")]
        public List<DocumentEntry> DocumentEntries { get; set; }
    }
}
