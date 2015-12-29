using System.Xml.Serialization;

namespace SunLib.Models
{
    public class Location
    {
        [XmlAttribute("latitude")]
        public double Lat { get; set; }

        [XmlAttribute("longitude")]
        public double Long { get; set; }

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