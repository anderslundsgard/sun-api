using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SunTests
{
    using System.Security.Cryptography.X509Certificates;

    using SunApi.Misc;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Parse_Correct_QueryString()
        {
            // Arrange
            var queryString = "?lat=57.13;lon=17.1759;date=2015-11-30";
            double lat, lon;
            DateTime date;

            // Act
            SunApiQueryStringParser.Parse(queryString, out lat, out lon, out date);

            // Assert
            Assert.AreEqual(57.13, lat);
            Assert.AreEqual(17.1759, lon);
            Assert.AreEqual("2015-11-30", date.ToString("yyyy-MM-dd"));
        }

        [TestCase("?lat=57.13lon=17.1759&date=2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date==2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date=2015--11-30")]
        public void Parse_Invalid_QueryString_Should_Throw_Exception(string queryString)
        {
            // Arrange
            double lat, lon;
            DateTime date;

            try
            {
                // Act
                SunApiQueryStringParser.Parse(queryString, out lat, out lon, out date);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("QueryString could not be parsed."));
            }
        }
    }
}
