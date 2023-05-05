using System;

namespace Market_viewer2._0.Models
{
    /// <summary>
    /// Class represents single data point of stock prices. Contains also additional data returned by API.
    /// </summary>
    public class StockDataPoint
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Adj_close { get; set; }
        public string Volume { get; set; }
        public string Dividend { get; set; }
        public int tickerId { get; set; }
        public Stock Ticker { get; set; }

        /// <summary>
        /// Debugging purpose function for returning info about a data point. 
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine(ID.ToString() + Date + Open + High + Low + Close + Adj_close + Volume + Dividend);
        }
    }
}
