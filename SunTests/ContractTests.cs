using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 

namespace SunTests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.Testing;

    using Owin;

    using SunApi;

    [TestFixture]
    public class ContractTests
    {
        TestServer _server;

        [OneTimeSetUp]
        public void SetUp()
        {
            this._server = TestServer.Create<Startup>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this._server.Dispose();
        }

        [Test]
        public void Verify_ApiSunrise_2015_11_30()
        {
            // Arrange
            var uri = "/api/sunrise?lat=59.76&lon=17.13&date=2015-11-30";
            var expectedxmlresult = "<?xml version=\"1.0\" encoding=\"utf-8\"?><astrodata xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><time date=\"2015-11-30T00:00:00Z\"><location latitude=\"59.76\" longitude=\"17.13\"><sun rise=\"2015-11-30T07:21:34Z\" set=\"2015-11-30T13:57:57Z\"><noon altitude=\"8.617\" /></sun><moon phase=\"Third quarter\" rise=\"2015-11-30T19:18:10Z\" set=\"2015-11-30T10:30:30Z\" /></location></time></astrodata>";

            // Act
            var returnedXml = this.GetXmlRequest(uri);

            // Assert
            Assert.AreEqual(returnedXml, expectedxmlresult);
        }

        private string GetXmlRequest(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/xml");
            var returnedXml = this._server.HttpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            return returnedXml;
        }
    }

    public class MyStartup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage().UseErrorPage(); // See Microsoft.Owin.Diagnostics
            //app.Us("/Welcome"); // See Microsoft.Owin.Diagnostics 
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello world using OWIN TestServer");
            });
        }
    }
}
