using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Xml.Serialization;

namespace SunApi.Models
{
    [XmlRoot("astrodata")]
    public class Astrodata
    {
        [XmlElement("time")]
        public Data Data { get; set; }

        public Astrodata()
        {
            Data = new Data();
        }
    }
}