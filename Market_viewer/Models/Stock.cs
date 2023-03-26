using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    public class Stock
    {
        public int id { get; set; }

        public string name { get; set; }

        private bool isFavorite { get; set; }

        public List<StockDataPoint> StockDataList { get; set; }

        public ICollection<Wallet> Wallets { get; set; }

        public Stock() { }

        public Stock(string ticker)
        {
            this.name = name;
            this.isFavorite = false;
            StockDataList = new List<StockDataPoint>();
        }

        public void SetFavorite() { isFavorite = true; }
    }
}
