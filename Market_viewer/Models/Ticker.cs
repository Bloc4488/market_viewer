using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    public class Ticker
    {
        public int id { get; set; }

        public string name { get; set; }

        public int isFavorite { get; set; }

        public virtual ICollection<Wallet> Wallets { get; set; }

        public Ticker() { }
    }
}
