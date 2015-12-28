using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SunLib;

namespace SunTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Basic_YrNo_Call()
        {
            YrNoAdapter adapter = new YrNoAdapter();
            double lat = 59.158516;
            double lon = 17.645391;
            DateTime date = new DateTime(2015, 11, 26);

            var result = adapter.GetSunInfo(lat, lon, date);

            Assert.IsTrue(result.InnerXml.Contains("<sun rise=\"2015-11-26T07:06:35Z\" set=\"2015-11-26T14:06:05Z\">"));
        }
    }
}
