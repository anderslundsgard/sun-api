using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunLib;
using SunLib.Models;

namespace SunApi.Controllers
{
    public class SunriseController : ApiController
    {
        // Sample request so far: http://sunriseandfall.azurewebsites.net/api/sunrise?lat=57.13&lon=17.1759&date=2015-11-30
        // localhost:4410/api/sunrise?lat=59.76&lon=17.13&date=2015-11-30
        // GET: api/sunrise?lat=57.3&lon=17.16&2015-11-30
        public Astrodata Get(double lat, double lon, DateTime date)
        {
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;

            YrNoAdapter adapter = new YrNoAdapter();
            var result = adapter.GetSunInfo(lat, lon, date);

            //return result.InnerXml;
            return new Astrodata();
        }

        // GET: api/sunrise
        public IEnumerable<string> Get()
        {
            return new string[] { "Just", "Test", "Call" };
        }

        //// get: api/sun/5
        //public string get(int id)
        //{
        //    return "value " + id;
        //}

        //// post: api/sun
        //public void post([frombody]string value)
        //{
        //}

        //// put: api/sun/5
        //public void put(int id, [frombody]string value)
        //{
        //}

        //// delete: api/sun/5
        //public void delete(int id)
        //{
        //}
    }
}
