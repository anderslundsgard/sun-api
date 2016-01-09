using System;
using System.Globalization;
using System.Xml;
using RestSharp;

namespace SunLib.Adapters
{
    public interface IYrNoAdapter
    {
        XmlDocument GetSunInfo(double lat, double lon, DateTime date);
    }

    public class YrNoAdapter : IYrNoAdapter
    {
        public XmlDocument GetSunInfo(double lat, double lon, DateTime date)
        {
            RestClient rest = new RestClient("http://api.yr.no/weatherapi/sunrise/1.1");
            string da = date.ToString("yyyy-MM-dd");
            string la = lat.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
            string lo = lon.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
            RestRequest request = new RestRequest(string.Format($"?lat={la};lon={lo};date={da}"));
            var resp = rest.Get(request);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(resp.Content);

            return doc;
        }
    }
}
