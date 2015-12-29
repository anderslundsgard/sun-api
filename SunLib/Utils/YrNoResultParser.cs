using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SunLib.Models;

namespace SunLib.Utils
{
    public interface IYrNoResultParser
    {
        Astrodata GetAstrodataByResult(XmlDocument xml);
    }

    public class YrNoResultParser : IYrNoResultParser
    {
        public Astrodata GetAstrodataByResult(XmlDocument xml)
        {
            Astrodata astrodata = new Astrodata();
            Data data = new Data();
            Location location = new Location();
            Sun sun = new Sun();
            Noon noon = new Noon();
            Moon moon = new Moon();

            var daystr = xml.SelectSingleNode(@"//time/@date")?.Value;
            data.DateTime = GetDateTimeByYrNoDateString(daystr);
            
            var latitudestr = xml.SelectSingleNode(@"//time/location/@latitude")?.Value;
            location.Lat = double.Parse(latitudestr, NumberFormatInfo.InvariantInfo);

            var longitudestr = xml.SelectSingleNode(@"//time/location/@longitude")?.Value;
            location.Long = double.Parse(longitudestr, NumberFormatInfo.InvariantInfo);

            var sunrisestr = xml.SelectSingleNode(@"//time/location/sun/@rise")?.Value;
            sun.Rise = GetDateTimeByYrNoDateTimeString(sunrisestr);

            var sunsetstr = xml.SelectSingleNode(@"//time/location/sun/@set")?.Value;
            sun.Set = GetDateTimeByYrNoDateTimeString(sunsetstr);

            var noonstr = xml.SelectSingleNode(@"//time/location/sun/noon/@altitude")?.Value;
            noon.Altitude = double.Parse(noonstr, NumberFormatInfo.InvariantInfo);

            var moonrisestr = xml.SelectSingleNode(@"//time/location/moon/@rise")?.Value;
            moon.Rise = GetDateTimeByYrNoDateTimeString(moonrisestr);

            var moonsetstr = xml.SelectSingleNode(@"//time/location/moon/@set")?.Value;
            moon.Set = GetDateTimeByYrNoDateTimeString(moonsetstr);

            moon.Phase = xml.SelectSingleNode(@"//time/location/moon/@phase")?.Value;

            sun.Noon = noon;
            location.Sun = sun;
            location.Moon = moon;
            data.Location = location;
            astrodata.Data = data;

            return astrodata;
        }

        private DateTime GetDateTimeByYrNoDateTimeString(string yrNoDateTime)
        {
            var datetime = DateTime.ParseExact(yrNoDateTime, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

            return datetime;
        }

        private DateTime GetDateTimeByYrNoDateString(string yrNoDate)
        {
            var datetime = DateTime.ParseExact(yrNoDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

            return datetime;
        }
    }
}
