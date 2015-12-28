using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Xml.Serialization;

namespace SunApi.Models
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