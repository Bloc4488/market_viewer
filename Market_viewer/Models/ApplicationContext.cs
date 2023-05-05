using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace Market_viewer2._0.Models
{
    /// <summary>
    /// Class connects database entities to the classes included in the project.
    /// </summary>
    public class StockContext : DbContext
    {

        public StockContext() : base("name = StockDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Stock> Tickers { get; set; }
        public DbSet<StockDataPoint> StockDataPoints { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        /// <summary>
        /// Sets model of database by creating entities.
        /// </summary>
        /// <param name="modelBuilder">Required builder for the model</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockDataPoint>()
                .HasKey(p => p.ID)
                .Property(e => e.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<StockDataPoint>()
                .HasRequired(w => w.Ticker)
                .WithMany(w => w.StockDataList)
                .HasForeignKey(w => w.tickerId);
            modelBuilder.Entity<Wallet>()
                .HasKey(p => p.id)
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Wallet>()
                .HasRequired(w => w.Ticker)
                .WithMany(t => t.Wallets)
                .HasForeignKey(w => w.tickerId);
            modelBuilder.Entity<Stock>()
                .HasKey(p => p.id)
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    /// <summary>
    /// Initializes database so that app starts with sample data present.
    /// </summary>
    public class StockDbInitializer : DropCreateDatabaseAlways<StockContext>
    {
        /// <summary>
        /// Seed funtion for given context linkage.
        /// </summary>
        /// <param name="context">Context for entities and the class</param>
        protected override void Seed(StockContext context)
        {
            var tickers = new List<Stock>
            {
                new Stock("KND"),
                new Stock("SGE"),
                new Stock("WDF")
            };
            tickers.ForEach(ticker => context.Tickers.Add(ticker));
            context.SaveChanges();

            List<Stock> ticker_db = context.Tickers.ToList();

            var wallets = new List<Wallet>
            {
                new Wallet(ticker_db[0], 0.6),
                new Wallet(ticker_db[1], 2.6)
            };
            wallets.ForEach(s => context.Wallets.Add(s));
            context.SaveChanges();
        }
    }
}
