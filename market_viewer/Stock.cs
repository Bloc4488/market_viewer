using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Stock
    {
        private string ticker;
        private bool ifFavorite;
        public string Ticker   // property
        {
            get { return ticker; }
        }


        Stock(string ticker)
        {
            this.ticker = ticker;
            this.ifFavorite = false;
        }

        public void SetFavorite() { ifFavorite = true; }

    }
}
