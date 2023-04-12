using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Market_viewer2._0.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Wallet> Wallets { get; set; }

        public ObservableCollection<Stock> Tickers { get; set; }

        private StockContext context = new StockContext();

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        public ViewModel()
        {
            Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            GetFullAmountOfWallet();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public ObservableCollection<Wallet> AddNewTickerToWallet(Wallet wallet)
        {
            context.Wallets.Add(wallet);
            context.SaveChanges();
            Wallets = new ObservableCollection<Wallet>();
            Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallet"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public ObservableCollection<Wallet> AddAmountTicker(Wallet wallet, double amount)
        {
            var walletToUpdate = context.Wallets.Find(wallet.id);
            if (walletToUpdate != null)
            {
                walletToUpdate.amount += amount;
                context.SaveChanges();
            }
            Wallets = new ObservableCollection<Wallet>();
            Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            GetFullAmountOfWallet();
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallet"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public ObservableCollection<Wallet> MinusAmountTicker(Wallet wallet, double amount)
        {
            var walletToUpdate = context.Wallets.Find(wallet.id);
            if (walletToUpdate != null)
            {
                walletToUpdate.amount -= amount;
                if (walletToUpdate.amount <= 0)
                {
                    context.Wallets.Remove(walletToUpdate);
                }
                context.SaveChanges();
            }
            Wallets = new ObservableCollection<Wallet>();
            Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            GetFullAmountOfWallet();
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ObservableCollection<Stock> AddNewTicker(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            if (!context.Tickers.Any(p => p.Name == stock.Name))
            {
                context.Tickers.Add(stock);
                context.SaveChanges();
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
            else
            {
                MessageBox.Show("Ticker exists in list");
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ObservableCollection<Stock> MakeTickerFavourite(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            var tickerToMakeFavourite = context.Tickers.Find(stock.id);
            tickerToMakeFavourite.IsFavourite = true;
            tickerToMakeFavourite.Image = tickerToMakeFavourite.ImageUrl();
            context.SaveChanges();
            Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ObservableCollection<Stock> RemoveTickerFavourite(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            var tickerToRemoveFavourite = context.Tickers.Find(stock.id);
            tickerToRemoveFavourite.IsFavourite = false;
            tickerToRemoveFavourite.Image = tickerToRemoveFavourite.ImageUrl();
            context.SaveChanges();
            Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }
        /// <summary>
        /// 
        /// </summary>
        public void RemoveAllTickersNotFavourite()
        {
            var RemoveListTickers = context.Tickers.Where(s => s.IsFavourite == false).ToList();
            for (int i = RemoveListTickers.Count - 1; i >= 0; i--)
            {
                var ticker = RemoveListTickers[i];
                if (ticker.StockDataList == null) continue;
                if (context.Wallets.Any(w => w.Ticker.id == ticker.id))
                {
                    if (MessageBox.Show($"Do you want to remove {ticker.Name} from wallet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        RemoveListTickers.Remove(ticker);
                        ticker.IsFavourite = true;
                        ticker.Image = ticker.ImageUrl();
                        MessageBox.Show($"{ticker.Name} now is in your favourite list of stocks");
                    }
                    else
                    {
                        MessageBox.Show($"You removed {context.Wallets.FirstOrDefault(w => w.Ticker.id == ticker.id).amount} {ticker.Name} from wallet.");
                        context.StockDataPoints.RemoveRange(ticker.StockDataList);
                    }
                }
            }
            context.Tickers.RemoveRange(RemoveListTickers);
            context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public bool CheckifExists(Wallet wallet)
        {
            bool walletExists = context.Wallets.Any(u => u.Ticker.Name == wallet.Ticker.Name);
            return walletExists;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public Wallet GetExistingWallet(Wallet wallet)
        {
            Wallet existingWallet = context.Wallets.FirstOrDefault(u => u.Ticker.Name == wallet.Ticker.Name);
            return existingWallet;
        }
        public void GetFullAmountOfWallet()
        {
            var FullAmountOfWallet = (TextBlock)Application.Current.MainWindow.FindName("FullAmountOfWallet");
            double fullAmount = 0;
            foreach(var wallet in Wallets)
            {
                fullAmount += (wallet.amount) * (wallet.Ticker.Price);
            }
            FullAmountOfWallet.Text = fullAmount.ToString() + "$";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
