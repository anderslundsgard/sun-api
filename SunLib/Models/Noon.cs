namespace SunLib.Models
{
    using System.Xml.Serialization;

    public class Noon
    {
        [XmlAttribute("altitude")]
        public double Altitude { get; set; }
    }
}