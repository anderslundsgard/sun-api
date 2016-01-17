using System;
using System.Web;

namespace SunApi.Misc
{
    using System.Globalization;

    public static class SunApiQueryStringParser
    {
        public static void Parse(string querystring, out double lat, out double lon, out DateTime date)
        {
            try
            {
                lat = lon = double.MinValue;
                date = DateTime.MinValue;

                var qs = querystring.Replace("?", string.Empty).Replace("/", string.Empty);
                qs = HttpUtility.UrlDecode(qs);
                var parameters = qs.Split(';');
                foreach (var parameter in parameters)
                {
                    var kv = parameter.Split('=');
                    if (kv[0] == "lat")
                    {
                        lat = double.Parse(kv[1], CultureInfo.InvariantCulture);
                    }
                    else if (kv[0] == "lon")
                    {
                        lon = double.Parse(kv[1], CultureInfo.InvariantCulture);
                    }
                    else if (kv[0] == "date")
                    {
                        date = DateTime.Parse(kv[1]);
                    }
                }

                if (Math.Abs(lat - double.MinValue) < 0.02 || Math.Abs(lon - double.MinValue) < 0.02 || date == DateTime.MinValue)
                {
                    throw new Exception($"some of the querystrings was wrong: lat: {lat}, lon: {lon}, date: {date}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("QueryString could not be parsed.", ex);
            }
        }
    }
}