﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Wallet> Wallets { get; set; }

        public ObservableCollection<Stock> Tickers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
        }

        public ObservableCollection<Wallet> AddNewTickerToWallet(Wallet wallet)
        {
            using (var context = new StockContext())
            {
                context.Wallets.Add(wallet);
                context.SaveChanges();
            }
            Wallets = new ObservableCollection<Wallet>();
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            }
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }

        public ObservableCollection<Wallet> AddAmountTicker(Wallet wallet, double amount)
        {
            using (var context = new StockContext())
            {
                var walletToUpdate = context.Wallets.Find(wallet.id);
                if (walletToUpdate != null)
                {
                    walletToUpdate.amount += amount;
                    context.SaveChanges();
                }
            }
            Wallets = new ObservableCollection<Wallet>();
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            }
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }

        public ObservableCollection<Wallet> MinusAmountTicker(Wallet wallet, double amount)
        {
            using (var context = new StockContext())
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
            }
            Wallets = new ObservableCollection<Wallet>();
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            }
            OnPropertyChanged(nameof(Wallets));
            return Wallets;
        }

        public ObservableCollection<Stock> AddNewTicker(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            using (var context = new StockContext())
            {
                context.Tickers.Add(stock);
                context.SaveChanges();
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }

        public ObservableCollection<Stock> MakeTickerFavourite(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            using (var context = new StockContext())
            {
                var tickerToMakeFavourite = context.Tickers.Find(stock.id);
                tickerToMakeFavourite.IsFavourite = true;
                context.SaveChanges();
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }

        public ObservableCollection<Stock> RemoveTickerFavourite(Stock stock)
        {
            Tickers = new ObservableCollection<Stock>();
            using (var context = new StockContext())
            {
                var tickerToRemoveFavourite = context.Tickers.Find(stock.id);
                tickerToRemoveFavourite.IsFavourite = false;
                context.SaveChanges();
                Tickers = new ObservableCollection<Stock>(context.Tickers.ToList());
            }
            OnPropertyChanged(nameof(Tickers));
            return Tickers;
        }

        public void RemoveAllTickersNotFavourite()
        {
            using (var context = new StockContext())
            {
                var RemoveListTickers = context.Tickers.Where(s => s.IsFavourite == false).ToList();
                context.Tickers.RemoveRange(RemoveListTickers);
                context.SaveChanges();
            }
        }

        public bool CheckifExists(Wallet wallet)
        {
            using (var context = new StockContext())
            {
                bool walletExists = context.Wallets.Any(u => u.Ticker.Name == wallet.Ticker.Name);
                return walletExists;
            }
        }

        public Wallet GetExistingWallet(Wallet wallet)
        {
            using (var context = new StockContext())
            {
                Wallet existingWallet = context.Wallets.FirstOrDefault(u => u.Ticker.Name == wallet.Ticker.Name);
                return existingWallet;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
