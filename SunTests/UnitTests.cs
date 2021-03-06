﻿namespace SunTests
{
    using System;
    using NUnit.Framework;
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

        //http://sunriseandfall.azurewebsites.net/api/sunrise/?lat=59.213133%3Blon%3D17.411662%3Bdate%3D2016-01-07
        [Test]
        public void Parse_QueryString_With_UrlEncoded_Markup()
        {
            // Arrange
            var queryString = "?lat=59.21%3Blon%3D17.411%3Bdate%3D2016-01-07";
            double lat, lon;
            DateTime date;

            // Act
            SunApiQueryStringParser.Parse(queryString, out lat, out lon, out date);

            // Assert
            Assert.AreEqual(59.21, lat);
            Assert.AreEqual(17.411, lon);
            Assert.AreEqual("2016-01-07", date.ToString("yyyy-MM-dd"));
        }

        [TestCase("?lat=57.13lon=17.1759&date=2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date==2015-11-30")]
        [TestCase("?lat=57.13&lon=17.1759&date=2015--11-30")]
        public void Parse_Invalid_QueryString_Should_Throw_Exception(string queryString)
        {
            try
            {
                // Arrange
                double lat;
                double lon;
                DateTime date;
                
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
