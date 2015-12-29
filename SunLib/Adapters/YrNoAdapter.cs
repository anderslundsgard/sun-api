using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RestSharp;

namespace SunLib
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
            string la = lat.ToString().Replace(",", ".");
            string lo = lon.ToString().Replace(",", ".");
            RestRequest request = new RestRequest(string.Format($"?lat={la};lon={lo};date={da}"));
            var resp = rest.Get(request);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(resp.Content);

            return doc;
        }
    }
}
