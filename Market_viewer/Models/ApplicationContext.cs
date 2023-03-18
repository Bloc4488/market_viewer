using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market_viewer2._0.Models
{
    public class StockContext : DbContext
    {
        public StockContext() : base("name = StockDB") 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Ticker> Tickers { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasRequired(w => w.Ticker)
                .WithMany(t => t.Wallets)
                .HasForeignKey(w => w.tickerId);
        }
    }

    public class StockDbInitializer : DropCreateDatabaseAlways<StockContext>
    {

        /*protected override void Seed(StockContext context)
        {
            var tickers = new List<Ticker>
            {
                new Ticker() {id = 1, name = "KND", isFavorite = 0},
                new Ticker() {id = 2, name = "SGE", isFavorite = 0},
                new Ticker() {id = 3, name = "WDF", isFavorite = 0}
            };
            tickers.ForEach(ticker => context.Tickers.Add(ticker));
            context.SaveChanges();

            List<Ticker> ticker_db = context.Tickers.ToList();

            var wallets = new List<Wallet>
            {
                new Wallet()
                {
                    id = 1,
                    amount = 0.6,
                    Ticker = ticker_db[0],
                    tickerId = ticker_db[0].id                                        
                },
                new Wallet()
                {
                    id = 2,
                    amount = 2.6,
                    Ticker = ticker_db[1],
                    tickerId = ticker_db[1].id
                }
            };
            wallets.ForEach(s =>  context.Wallets.Add(s));
            context.SaveChanges();
        }*/
    }
}
