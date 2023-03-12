using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Stock
    {
        public int id {  get; set; }

        private string ticker;

        private int ifFavorite;// 0 - false, 1 - true
        
        public Stock() { }

        Stock(string ticker)
        {
            this.ticker = ticker;
            this.ifFavorite = 0;
        }

        public string Ticker   // property
        {
            get { return ticker; }
        }

        public void SetFavorite() { ifFavorite = 1; }

    }
}
