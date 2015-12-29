using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SunLib.Models
{
    public class Moon
    {
        [XmlAttribute("phase")]
        public string Phase { get; set; }

        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        [XmlAttribute("set")]
        public DateTime Set { get; set; }

        public Moon()
        {
            Phase = "Unknown";
        }
    }
}