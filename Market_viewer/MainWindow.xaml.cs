using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Market_viewer2._0.Models;

namespace Market_viewer
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*using (var context = new StockContext())
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
                wallets.ForEach(s => context.Wallets.Add(s));
                context.SaveChanges();
            }*/
            List<Ticker> listOfTickers;
            using (var context = new StockContext())
            {
                listOfTickers = context.Tickers.ToList();
            }

            listOfTic.ItemsSource = listOfTickers;

            List<Wallet> listOfWal;
            using (var context = new StockContext())
            {
                listOfWal = context.Wallets.ToList();
            }

            listOfWallet.ItemsSource = listOfWal;
            Console.WriteLine(listOfWal);
        }
    }
}
