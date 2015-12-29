using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SunLib;
using SunLib.Models;
using SunLib.Utils;

namespace SunTests
{
    [TestFixture]
    public class IntegrationTests
    {
        private double _lat = 59.158516;
        private double _lon = 17.645391;
        DateTime _date = new DateTime(2015, 11, 26);

        [Test]
        public void Basic_YrNo_Call()
        {
            IYrNoAdapter adapter = new YrNoAdapter();
            
            var result = adapter.GetSunInfo(_lat, _lon, _date);

            Assert.IsTrue(result.InnerXml.Contains("<sun rise=\"2015-11-26T07:06:35Z\" set=\"2015-11-26T14:06:05Z\">"));
        }

        [Test]
        public void Basic_YrNo_Call_With_Parser_Verification()
        {
            IYrNoAdapter adapter = new YrNoAdapter();

            var result = adapter.GetSunInfo(_lat, _lon, _date);
            IYrNoResultParser parser = new YrNoResultParser();
            Astrodata data = parser.GetAstrodataByResult(result);

            Assert.AreEqual(data.Data.Location.Sun.Rise, new DateTime(2015, 11, 26, 07, 06, 35));
        }
    }
}
