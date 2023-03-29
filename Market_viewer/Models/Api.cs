using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Market_viewer2._0.Models
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
            apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={stock.Name}" +
                $"&apikey={key}&datatype={datatype}&outputsize{outputsize}";
        }

        public void DownloadData(Stock stock)
        {
            SetUrl(stock);

            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(apiUrl);
                string line = string.Empty;

                using (System.IO.StringReader reader = new System.IO.StringReader(data))
                {
                    while (null != (line = reader.ReadLine()))
                    {
                        StockDataPoint point = new StockDataPoint();
                        string[] elements = line.Split(',');
                        point.Date = elements[0];
                        point.Open = elements[1];
                        point.High = elements[2];
                        point.Low = elements[3];
                        point.Close = elements[4];
                        point.Adj_close = elements[5];
                        point.Volume = elements[6];
                        point.Dividend = elements[7];

                        stock.StockDataList.Add(point);
                    }
                }
            }
        }
    }
}