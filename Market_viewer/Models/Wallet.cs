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
        public int Id { get; set; }

        public double amount { get; set; }

        [ForeignKey("Ticker")]
        public int tickerId { get; set; }

        public virtual Ticker Ticker { get; set; }
        
        public Wallet() { }
    }
}
