using Market_viewer2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Market_viewer
{
    class Api
    {
        private readonly string datatype;
        private readonly string outputsize;
        private readonly string key;
        private string apiUrl = string.Empty;
        public Api(string apiKey = "01IC5EI68QVQTUPS")
        {
            datatype = "csv"; // another possibitity is json
            outputsize = "compact"; // 100 data points
            key = apiKey;
        }
        public void SetUrl(Stock stock)
        {
            apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={stock.Ticker}" +
                $"&apikey={key}&datatype={datatype}&outputsize{outputsize}";
        }

        public void DownloadData(Stock stock)
        {
            SetUrl(stock);

            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(apiUrl);
                Console.Write(data);
            }
        }
    }
}