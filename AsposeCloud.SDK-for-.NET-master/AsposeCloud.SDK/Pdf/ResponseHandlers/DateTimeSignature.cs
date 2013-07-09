using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Globalization;
using System.Xml.Schema;
using System.Xml;
using Aspose.Cloud.Pdf;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// Represents Signature DateTime.
    /// </summary>
    [XmlRoot("DateTime")]
    public class DateTimeSignature : LinkElement, IXmlSerializable
    {
        private static readonly CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
        private const string datePattern = "MM/dd/yyyy hh:mm:ss.fff tt";

        private System.DateTime dateTime;
        public DateTimeSignature() { }
        public DateTimeSignature(int year, int month, int day, int hour, int minute, int second)
            : this(new DateTime(year, month, day, hour, minute, second))
        {

        }
        public DateTimeSignature(System.DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public System.DateTime ToNativeDateTime()
        {
            return dateTime;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            this.dateTime = DateTime.ParseExact(reader.ReadString(), datePattern, ci);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(dateTime.ToString(datePattern, ci));
        }
    }

}
