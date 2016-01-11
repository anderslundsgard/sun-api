using System.Diagnostics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;

namespace SunTests
{
    using System;
    using NUnit.Framework;
    using SunLib.Adapters;
    using SunLib.Models;
    using SunLib.Utils;

    // Latitude : max/min +90 to -90
    // Longitude : max/min +180 to -180


    [TestFixture]
    public class IntegrationTests
    {
        [TestCase(59.158516, 17.645391, 2015, 11, 26, "<sun rise=\"2015-11-26T07:06:35Z\" set=\"2015-11-26T14:06:05Z\">")]
        [TestCase(39.1, 19.4554, 2016, 04, 13, "sun rise=\"2016-04-13T04:08:07Z\" set=\"2016-04-13T17:17:46Z")]
        public void Basic_YrNo_Call(double lat, double lon, int year, int month, int day, string expected)
        {
            IYrNoAdapter adapter = new YrNoAdapter();
            
            var result = adapter.GetSunInfo(lat, lon, new DateTime(year, month, day));

            Assert.IsTrue(result.InnerXml.Contains(expected));
        }

        [Test]
        public void Basic_YrNo_Call_With_Parser_Verification()
        {
            IYrNoAdapter adapter = new YrNoAdapter();

            var result = adapter.GetSunInfo(59.158516, 17.645391, new DateTime(2015, 11, 26));
            IYrNoResultParser parser = new YrNoResultParser();
            Astrodata data = parser.GetAstrodataByResult(result);

            Assert.AreEqual(data.Data.Location.Sun.Rise, new DateTime(2015, 11, 26, 07, 06, 35));
        }

        [Test]
        public void Compare_YrNo_And_Zacky_Pickholz_Algorithm()
        {
            IYrNoAdapter adapter = new YrNoAdapter();

            for (int i = 0; i < 10; i++)
            {
                double lat = this.GetRandLat();
                double lon = this.GetRandLong();
                DateTime date = new DateTime(2015, 09, 23);

                try
                {
                    var resultYr = adapter.GetSunInfo(lat, lon, date);
                    IYrNoResultParser parser = new YrNoResultParser();
                    Astrodata dataYr = parser.GetAstrodataByResult(resultYr);

                    bool isSunrise = false;
                    bool isSunset = false;
                    DateTime sunrise = DateTime.MinValue;
                    DateTime sunset = DateTime.MinValue;
                    SunTimes.Instance.CalculateSunRiseSetTimes(lat, lon, date, ref sunrise, ref sunset, ref isSunrise,
                        ref isSunset);

                    bool areclosetoequal = this.AreCloseToEqual(dataYr.Data.Location.Sun.Rise, sunrise);
                    Assert.IsTrue(areclosetoequal);

                    bool areclosetoequal2 = this.AreCloseToEqual(dataYr.Data.Location.Sun.Set, sunset);
                    Assert.IsTrue(areclosetoequal2);

                    Thread.Sleep(300);
                }
                catch (ArgumentNullException ex)
                {
                    i--; // Probably got a no rise result
                }
            }
        }
        
        private bool AreCloseToEqual(DateTime date1, DateTime date2)
        {
            date1 = new DateTime(date1.Year, date1.Month, date2.Day, date1.Hour, date1.Minute, date1.Second); // Ensure same day, yrno sometimes send the next day
            long ticksdiff = Math.Abs(date1.Ticks - date2.Ticks);
            double secondsdiff = TimeSpan.FromTicks(ticksdiff).TotalSeconds;

            return secondsdiff < 300; // Max 5 minutes diff
        }

        private double GetRandLat()
        {
            return this.GetRandomNumber(-85, 85);
        }

        private double GetRandLong()
        {
            return this.GetRandomNumber(-150, 150); // (-180, 180);
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            double randDouble = random.NextDouble() * (maximum - minimum) + minimum;

            return randDouble;
        }
    }
}
