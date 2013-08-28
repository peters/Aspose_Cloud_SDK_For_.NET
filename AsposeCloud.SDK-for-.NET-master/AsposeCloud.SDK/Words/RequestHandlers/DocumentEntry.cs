using System;
using System.Xml.Serialization;

namespace Aspose.Cloud.Words
{
    public class DocumentEntry
    {
        public DocumentEntry()
        {
        }

        public DocumentEntry(String href, String importFormatMode)
        {
            Href = href;
            ImportFormatMode = importFormatMode;
        }

        [XmlAttribute(AttributeName = "href")]
        public String Href { get; set; }

        [XmlAttribute(AttributeName = "importFormatMode")]
        public String ImportFormatMode { get; set; }
    }
}
