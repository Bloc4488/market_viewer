namespace Market_viewer2._0.Models
{
    /// <summary>
    /// Class represents wallet containing stocks provided by the user.
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
        /// <param name="ticker">Ticker of the stock of intrest.</param>
        /// <param name="value">Price value of the given stock</param>
        public Wallet(Stock ticker, double value)
        {
            Ticker = ticker;
            tickerId = ticker.id;
            amount = value;
        }
    }
}
