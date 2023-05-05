using System;
using System.Net;

namespace Market_viewer2._0.Models
{
    /// <summary>
    /// Class for managing external "Alphavantage" API. The API is used to retrieve information about set stock.
    /// </summary>
    public class Api
    {
        private readonly string datatype;
        private readonly string outputsize;
        private readonly string key;
        private string apiUrl = string.Empty;

        /// <summary>
        /// Constructor with basic API parameters.
        /// </summary>
        /// <param name="apiKey">Key needed to authorize API communication. It can be obtained from the alphavantage page.</param>
        public Api(string apiKey = "01IC5EI68QVQTUPS")
        {
            datatype = "csv"; // another possibitity is json
            outputsize = "compact"; // 100 data points
            key = apiKey;
        }
        /// <summary>
        /// Sets url to site from which the datapoints will be returned.
        /// </summary>
        /// <param name="stock">Ticker to the stock of concerned.</param>
        public void SetUrl(Stock stock)
        {
            apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={stock.Name}" +
                $"&apikey={key}&datatype={datatype}&outputsize={outputsize}";
        }
        /// <summary>
        /// Downloads price datapoints of the given stock and sets it atributes to obtained data.
        /// </summary>
        /// <param name="stock"></param>
        public void DownloadData(Stock stock)
        {
            SetUrl(stock);

            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(apiUrl);
                string line = string.Empty;

                using (System.IO.StringReader reader = new System.IO.StringReader(data))
                {
                    reader.ReadLine(); //skipping first line
                    while (null != (line = reader.ReadLine()))
                    {
                        StockDataPoint point = new StockDataPoint();
                        string[] elements = line.Split(',');

                        DateTime parsedDate = DateTime.ParseExact(elements[0], "yyyy-MM-dd", null);
                        point.Date = parsedDate;
                        point.Open = elements[1];
                        point.High = elements[2];
                        point.Low = elements[3];
                        point.Close = elements[4];
                        point.Adj_close = elements[5];
                        point.Volume = elements[6];
                        point.Dividend = elements[7];
                        point.tickerId = stock.id;
                        point.Ticker = stock;

                        stock.StockDataList.Add(point);
                    }
                    stock.Price = Convert.ToDouble(stock.StockDataList[0].Adj_close);
                }
            }
        }
    }
}