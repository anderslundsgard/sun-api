using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SunApi.Models;

namespace SunTests
{
    [TestFixture]
    public class ComponentTests
    {
        [Test]
        public void DezerializeSampleResponse()
        {
            var mc = new Astrodata();
            XmlSerializer ser = new XmlSerializer(typeof(Astrodata));
            StringWriter sw = new StringWriter();
            ser.Serialize(sw, mc);
            string ass = sw.ToString();
            Assert.IsTrue(ass.Contains("phase=\"Unknown\""));
        }
    }
}
