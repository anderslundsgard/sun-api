using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace SunTests
{
    using System;
    using NUnit.Framework;
    using SunLib.Adapters;
    using SunLib.Models;
    using SunLib.Utils;

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
    }
}
