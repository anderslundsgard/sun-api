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
        [Test]
        public void OwinAppTest()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var response = server.HttpClient.GetAsync("/api/sunrise").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Assert.IsTrue(content.Contains("Hello world using OWIN TestServer"));
            }
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
