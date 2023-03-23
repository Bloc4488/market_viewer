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
                var ticker = new Ticker { name = "AAAS", isFavorite = 0 };
                context.Tickers.Add(ticker);
                context.SaveChanges();

                var wallet = new Wallet { tickerId = ticker.id, amount = 10};
                context.Wallets.Add(wallet);
                context.SaveChanges();
            }*/
            var viewModel = new ViewModel();
            DataContext = viewModel;

            IList<Ticker> tickerList = new List<Ticker>();
            using (var context = new StockContext())
            {
                tickerList = context.Tickers.ToList();
            }
            listOfTic.ItemsSource = tickerList;
        }

        private void btnAddSelectedItemAmount_Click(object sender, RoutedEventArgs e)
        {
            var ticker = listOfWallet.SelectedItem as Wallet;
            if (ticker == null) 
            {
                MessageBox.Show("Choose ticker");
            }
            else
            {
                var ViewModel = new ViewModel();
                ViewModel.AddAmountTicker(ticker);
                DataContext = ViewModel;
            }
        }
    }
}
