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
        private readonly DateTime _date = new DateTime(2015, 11, 26);

        private double _lat = 59.158516;
        private double _lon = 17.645391;

        [Test]
        public void Basic_YrNo_Call()
        {
            IYrNoAdapter adapter = new YrNoAdapter();
            
            var result = adapter.GetSunInfo(this._lat, this._lon, this._date);

            Assert.IsTrue(result.InnerXml.Contains("<sun rise=\"2015-11-26T07:06:35Z\" set=\"2015-11-26T14:06:05Z\">"));
        }

        [Test]
        public void Basic_YrNo_Call_With_Parser_Verification()
        {
            IYrNoAdapter adapter = new YrNoAdapter();

            var result = adapter.GetSunInfo(this._lat, this._lon, this._date);
            IYrNoResultParser parser = new YrNoResultParser();
            Astrodata data = parser.GetAstrodataByResult(result);

            Assert.AreEqual(data.Data.Location.Sun.Rise, new DateTime(2015, 11, 26, 07, 06, 35));
        }
    }
}
