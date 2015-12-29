using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SunLib.Models
{
    public class Noon
    {
        [XmlAttribute("altitude")]
        public long Altitude { get; set; }
    }
}