using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Market_viewer2._0.Models
{
    public class Wallet
    {
        public int id { get; set; }

        public double amount { get; set; }

        public int tickerId { get; set; }

        public Stock Ticker { get; set; }

        public Wallet() { }

        public Wallet(Stock ticker, double value)
        {
            Ticker = ticker;
            tickerId = ticker.id;
            amount = value;
        }
    }
}
