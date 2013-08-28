using System.Collections.Generic;
using System.Xml.Serialization;

namespace Aspose.Cloud.SDK.Slides
{
    

    [XmlRoot(ElementName = "DocumentProperties")]
    public class CustomPropertyList
    {
        [XmlElement("DocumentProperty")]
        public List<CustomProperty> Entries { get; set; }
    }

}
