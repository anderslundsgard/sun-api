﻿using System.Diagnostics;
using SunLib.Utils;

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

        [Test]
        public void Verify_CalcSunTimes_By_Zacky_Pickholz()
        {
            DateTime date = new DateTime(2016, 1, 10);
            bool isSunrise = false;
            bool isSunset = false;
            DateTime sunrise = DateTime.Now;
            DateTime sunset = DateTime.Now;

            SunTimes.Instance.CalculateSunRiseSetTimes(
                59.21318747,
                17.41151598,
                date, 
                ref sunrise, 
                ref sunset,
                ref isSunrise, 
                ref isSunset);

            Debug.Print(date + ": Sunrise @" + sunrise.ToString("HH:mm") + "Sunset @" + sunset.ToString("HH:mm"));

            Assert.AreEqual(sunrise.Hour, 7);
            Assert.AreEqual(sunrise.Minute, 39);
            Assert.AreEqual(sunset.Hour, 14);
            Assert.AreEqual(sunset.Minute, 17);

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
