using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunLib;
using SunLib.Models;
using SunLib.Utils;

namespace SunApi.Controllers
{
    using SunApi.Misc;

    /// <summary>
    /// API for sun and moon rise and fall
    /// </summary>
    public class SunriseController : ApiController
    {
        // Sample request so far: http://sunriseandfall.azurewebsites.net/api/sunrise?lat=57.13&lon=17.1759&date=2015-11-30
        // localhost:4410/api/sunrise?lat=59.76&lon=17.13&date=2015-11-30
        // GET: api/sunrise?lat=57.3&lon=17.16&2015-11-30
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="lat">
        /// The lat.
        /// </param>
        /// <param name="lon">
        /// The lon.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// The <see cref="Astrodata"/>.
        /// </returns>
        //[HttpGet]
        //public Astrodata Get(double lat, double lon, DateTime date)
        //{
        //    var astrodata = GetAstrodata(lat, lon, date);

        //    return astrodata;
        //}

        // GET: api/sunrise
        [HttpGet]
        public Astrodata Get()
        {
            Astrodata astrodata;
            try
            {
                astrodata = GetAstrodata(this.Request.RequestUri.Query);
            }
            catch (Exception ex)
            {
                throw new Exception("Nagat fel hände... " + ex.Message + "  -  " + ex.InnerException.StackTrace);
            }

            return astrodata;
        }

        private static Astrodata GetAstrodata(double lat, double lon, DateTime date)
        {
            IYrNoAdapter adapter = new YrNoAdapter();
            IYrNoResultParser parser = new YrNoResultParser();

            var doc = adapter.GetSunInfo(lat, lon, date);
            var astrodata = parser.GetAstrodataByResult(doc);

            return astrodata;
        }

        private static Astrodata GetAstrodata(string querystring)
        {
            double lat, lon;
            DateTime date;

            SunApiQueryStringParser.Parse(querystring, out lat, out lon, out date);
            var astrodata = GetAstrodata(lat, lon, date);

            return astrodata;
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
