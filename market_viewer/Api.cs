using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Api
    {
        private readonly string datatype;
        private readonly string outputsize;
        private readonly string key;
        private string url = String.Empty;
        Api(string apiKey = "01IC5EI68QVQTUPS")
        {
            datatype = "csv"; // another possibitity is json
            outputsize = "compact"; // 100 data points
            key = apiKey;
        }
        public void SetUrl(Stock stock)
        {
            url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stock.Ticker}&apikey={key}";
        }
    }
}
