using System;
using System.Xml.Serialization;

namespace SunLib.Models
{
    public class Sun
    {
        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        [XmlAttribute("set")]
        public DateTime Set { get; set; }

        [XmlElement("noon")]
        public Noon Noon { get; set; }

        public Sun()
        {
            Noon = new Noon();
        }
    }
}