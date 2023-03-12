using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Market_viewer
{
    internal class ApplicationContextDB : DbContext
    {

        public DbSet<Stock> Tickers { get; set; }

        public DbSet<Wallet> Wallet { get; set; }

        public ApplicationContextDB() : base("DefaultConnection") { }

    }
}
