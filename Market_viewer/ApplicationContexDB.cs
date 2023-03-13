using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Market_viewer
{
    internal class ApplicationContexDB : DbContext
    {
        public DbSet<Ticker> Tickers { get; set; }

        public DbSet<Wallet> Wallet { get; set; }

        public ApplicationContexDB() : base("DefaultConnection") { }
    }
}
