using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    class Stock
    {
        public string Ticker { get; set; }
        public List<StockDataPoint> StockDataList { get; set; }
        private bool ifFavorite;
        public Stock(string ticker)
        {
            Ticker = ticker;
            ifFavorite = false;
            StockDataList = new List<StockDataPoint>();
        }

        public void SetFavorite() { ifFavorite = true; }

    }

}