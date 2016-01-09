namespace SunLib.Models
{
    using System;
    using System.Xml.Serialization;

    public class Moon
    {
        public Moon()
        {
            this.Phase = "Unknown";
        }

        [XmlAttribute("phase")]
        public string Phase { get; set; }

        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        [XmlAttribute("set")]
        public DateTime Set { get; set; }
    }
}