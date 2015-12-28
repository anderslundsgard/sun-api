using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Xml.Serialization;

namespace SunApi.Models
{
    public class Location
    {
        [DataMember, XmlAttribute("latitude")]
        public long Lat { get; set; }

        [DataMember, XmlAttribute("longitude")]
        public long Long { get; set; }

        [XmlElement("sun")]
        public Sun Sun { get; set; }

        [XmlElement("moon")]
        public Moon Moon { get; set; }

        public Location()
        {
            Lat = 99;
            Long = 98;
            Sun = new Sun();
            Moon = new Moon();
        }
    }
}