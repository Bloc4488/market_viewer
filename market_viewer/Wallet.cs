using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Wallet
    {
        public int id {  get; set; }

        private float value;

        private int ticker_id;


        public Wallet() { }

        public Wallet(int id, float value, int ticker_id)
        {
            this.id = id;
            this.value = value;
            this.ticker_id = ticker_id;
        }

    }
}
