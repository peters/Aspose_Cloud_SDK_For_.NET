using System;
using System.Xml.Serialization;

namespace Aspose.Cloud.SDK.Slides
{
    public class CustomProperty
    {
        public CustomProperty()
        {
        }

        public CustomProperty(String name, String value)
        {
            Name = name;
            Value = value;
        }

        [XmlElement("Name")]
        public String Name { get; set; }

        [XmlElement("Value")]
        public String Value { get; set; }
    }
}
