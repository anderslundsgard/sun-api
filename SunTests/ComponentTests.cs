namespace SunTests
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using NUnit.Framework;
    using SunLib.Models;

    [TestFixture]
    public class ComponentTests
    {
        [Test]
        public void DezerializeDefaultResponse()
        {
            // Arange
            var mc = new Astrodata();
            XmlSerializer ser = new XmlSerializer(typeof(Astrodata));
            StringWriter sw = new StringWriter();

            // Act
            ser.Serialize(sw, mc);
            string ass = sw.ToString();

            // Assert
            Assert.IsTrue(ass.Contains("phase=\"Unknown\""));
        }

        [Test]
        public void DezerializeSampleResponse_CheckSun()
        {
            // Arange
            var mc = CreateSampleAstrodata();
            XmlSerializer ser = new XmlSerializer(typeof(Astrodata));
            StringWriter sw = new StringWriter();

            // Act
            ser.Serialize(sw, mc);
            string ass = sw.ToString();

            // Assert
            Assert.IsTrue(ass.Contains("sun rise=\"2015-12-09T06:00:00\" set=\"2015-12-09T18:00:00\""));
        }

        [Test]
        public void DezerializeSampleResponse_CheckMoon()
        {
            // Arange
            var mc = CreateSampleAstrodata();
            XmlSerializer ser = new XmlSerializer(typeof(Astrodata));
            StringWriter sw = new StringWriter();

            // Act
            ser.Serialize(sw, mc);
            string ass = sw.ToString();

            // Assert
            Assert.IsTrue(ass.Contains("moon phase=\"Unknown\" rise=\"2015-12-09T14:00:00\" set=\"2015-12-09T15:00:00\""));
        }

        private static Astrodata CreateSampleAstrodata()
        {
            var mc = new Astrodata()
            {
                Data =
                    new Data()
                    {
                        DateTime = new DateTime(2015, 12, 9),
                        Location =
                            new Location()
                            {
                                Long = 57,
                                Lat = 17,
                                Sun =
                                    new Sun()
                                    {
                                        Noon = new Noon() {Altitude = 8},
                                        Rise = new DateTime(2015, 12, 9, 6, 0, 0),
                                        Set = new DateTime(2015, 12, 9, 18, 0, 0)
                                    },
                                Moon =
                                    new Moon()
                                    {
                                        Phase = "Unknown",
                                        Set = new DateTime(2015, 12, 9, 15, 0, 0),
                                        Rise = new DateTime(2015, 12, 9, 14, 0, 0)
                                    }
                            }
                    }
            };
            return mc;
        }
    }
}
