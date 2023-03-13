using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Wallet
    {
        public int id { get; set; }

        private float amount;

        private int tickerId;


        public Wallet() { }

        public Wallet(int id, float value, int ticker_id)
        {
            this.id = id;
            this.amount = value;
            this.tickerId = ticker_id;
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int TickerId
        {
            get { return tickerId; }
            set { tickerId = value; }
        }
    }
}
