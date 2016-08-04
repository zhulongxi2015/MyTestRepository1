using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Utilities
{
    //{"code":0,"data":{"country":"\u7f8e\u56fd","country_id":"US","area":"","area_id":"","region":"","region_id":"","city":"","city_id":"","county":"","county_id":"","isp":"","isp_id":"","ip":"172.0.0.1"}}
    public static class IpHelper
    {

        public static string GetAddress(string ip)
        {
            var url= "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
            try
            {
                using (var client = new WebClient())
                {
                    var html = client.DownloadString(url);
                    return Serializer.FromJson<IpModel>(html).GetAddress();
                }
            }

            catch
            {
                return string.Empty;
            }
        }
    }
    internal class IpModel
    {
        public string Code { get; set; }
        public IpDataModel Data { get; set;}

        public string GetAddress()
        {
            if (this.Data == null)
            {
                return string.Empty;
            }
            return this.Data.Country + " " + this.Data.City;
        }
    }
    internal class IpDataModel
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
