using System.Collections.Generic;
using System.Xml.Serialization;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// Represents base object.
    /// </summary>
    public class LinkElement
    {
        /// <summary>
        /// Link to the document.
        /// </summary>
        [XmlElement("link")]
        public List<Link> Links { get; set; }
    }

}
