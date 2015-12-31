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

    using SunApi;

    [TestFixture]
    public class SystemTests
    {
        //private static IDisposable _webApp;

        //[SetUp]
        //public static void SetUp(TestContext context)
        //{
        //    _webApp = WebApp.Start<Startup>("http://*:9443/");
        //}

        //[TearDown]
        //public static void TearDown()
        //{
        //    _webApp.Dispose();
        //}

        //[Test]
        //public async Task TestMethod()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var accessToken = GetAccessToken();
        //        httpClient.DefaultRequestHeaders.Authorization =
        //            new AuthenticationHeaderValue("Bearer", accessToken);
        //        var requestUri = new Uri("http://localhost:9443/api/values");
        //        await httpClient.GetStringAsync(requestUri);
        //    }
        //}
    }
}
