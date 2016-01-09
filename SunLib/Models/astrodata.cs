using System.Xml.Serialization;

namespace SunLib.Models
{
    [XmlRoot("astrodata")]
    public class Astrodata
    {
        [XmlElement("time")]
        public Data Data { get; set; }

        public Astrodata()
        {
            this.Data = new Data();
        }
    }
}