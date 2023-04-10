namespace Market_viewer2._0.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Wallet
    {
        public int id { get; set; }

        public double amount { get; set; }

        public int tickerId { get; set; }

        public Stock Ticker { get; set; }

        public Wallet() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="value"></param>
        public Wallet(Stock ticker, double value)
        {
            Ticker = ticker;
            tickerId = ticker.id;
            amount = value;
        }
    }
}
