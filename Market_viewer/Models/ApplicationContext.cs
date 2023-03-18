using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext() : base() { }

        public DbSet<Ticker> Tickers { get; set; }

        public DbSet<Wallet> Wallets { get; set; } 
    }
}
