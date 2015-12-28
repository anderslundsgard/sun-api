using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Xml.Serialization;

namespace SunApi.Models
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