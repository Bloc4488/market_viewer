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

        private string name { get; set; }

        private bool isFavourite { get; set; }

        public List<StockDataPoint> StockDataList { get; set; }

        public ICollection<Wallet> Wallets { get; set; }

        public Stock() { }

        public Stock(string ticker)
        {
            this.name = ticker;
            this.isFavourite = false;
            StockDataList = new List<StockDataPoint>();

        }

        public bool IsFavourite
        { 
            get 
            { 
                return isFavourite; 
            } 
            set 
            { 
                this.isFavourite = value;
            } 
        }

        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }
    }
}
