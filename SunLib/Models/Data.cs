using System;
using System.Xml.Serialization;

namespace SunLib.Models
{
    public class Data
    {
        [XmlAttribute(AttributeName = "date")]
        public DateTime DateTime { get; set; }

        [XmlElement("location")]
        public Location Location { get; set; }

        public Data()
        {
            Location = new Location();
        }

    }
}