using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 

namespace SunTests
{
    using System.Diagnostics.CodeAnalysis;
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

        [SetUp]
        public void SetUp()
        {
            this._server = TestServer.Create<Startup>();
        }

        [TearDown]
        public void TearDown()
        {
            this._server.Dispose();
        } 

        [Test]
        public void Verify_ApiSunrise_Root()
        {
            // Arrange
            var uri = "/api/sunrise";
            var expectedresult = "[\"Refer\",\"to\",\"Swagger\",\"documentation\"]";
            
            // Act
            var response = this._server.HttpClient.GetAsync(uri).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.AreEqual(content, expectedresult);
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
