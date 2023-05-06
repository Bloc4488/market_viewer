
using Market_viewer2._0.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Market_viewer
{
    /// <summary>
    /// Main class
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialization of class Api object
        /// </summary>
        private Api StockApi;
        public MainWindow()
        {
            InitializeComponent();
            StockApi = new Api();
            var viewModel = new ViewModel();
            DataContext = viewModel;
        }
        /// <summary>
        /// Action for the "Buy" button. This method adds amount to existing wallet or creats new wallet and adds amount to this wallet. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSelectedItemAmount_Click(object sender, RoutedEventArgs e)
        {
            double amount = 0.0;
            try
            {
                amount = Convert.ToDouble(AmountOfTickerToAddOrMinus.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number");
            }
            finally
            {
                var tickerFromWallet = listOfWallet.SelectedItem as Wallet;
                if (tickerFromWallet == null)
                {
                    var tickerFromStock = listOfStock.SelectedItem as Stock;
                    if (tickerFromStock == null)
                    {
                        MessageBox.Show("Choose ticker");
                    }
                    else
                    {
                        Wallet wallet = new Wallet(tickerFromStock, 0);
                        var viewModel = DataContext as ViewModel;
                        if (viewModel.CheckifExists(wallet))
                        {
                            wallet = viewModel?.GetExistingWallet(wallet);
                            viewModel?.AddAmountTicker(wallet, amount);
                        }
                        else
                        {
                            viewModel?.AddNewTickerToWallet(wallet);
                            viewModel?.AddAmountTicker(wallet, amount);
                        }
                    }
                    listOfStock.SelectedItem = null;
                }
                else
                {
                    var viewModel = DataContext as ViewModel;
                    viewModel?.AddAmountTicker(tickerFromWallet, amount);
                    listOfWallet.SelectedItem = null;
                }
            }
            AmountOfTickerToAddOrMinus.Text = "";
        }
        /// <summary>
        /// Action for the "Sell" button. This method removes amount from existing wallet and removes this wallet if amount is less that zero. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinusSelectedItemAmount_Click(object sender, RoutedEventArgs e)
        {
            double amount = 0.0;
            try
            {
                amount = Convert.ToDouble(AmountOfTickerToAddOrMinus.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number");
            }
            finally
            {
                var ticker = listOfWallet.SelectedItem as Wallet;
                if (ticker == null)
                {
                    MessageBox.Show("Choose ticker");
                }
                else
                {
                    var viewModel = DataContext as ViewModel;
                    viewModel?.MinusAmountTicker(ticker, amount);
                }
                listOfWallet.SelectedItem = null;
            }
            AmountOfTickerToAddOrMinus.Text = "";
        }
        /// <summary>
        /// Action for the "Add" button. This method adds to list of stocks new stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTickerToTickers_Click(object sender, RoutedEventArgs e)
        {
            var tickerName = Convert.ToString(AddNewTicker.Text).ToUpper();
            Stock ticker = new Stock(tickerName);
            try
            {
                StockApi.DownloadData(ticker);
            }
            catch (Exception)
            {
                MessageBox.Show("No such stock, please write right name");
                AddNewTicker.Text = null;
                return;
            }
            var viewModel = DataContext as ViewModel;
            viewModel?.AddNewTicker(ticker);
            AddNewTicker.Text = null;
        }
        /// <summary>
        /// Method to show chart information of chosen stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ListOfStock_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            Stock selectedStock = (Stock)listOfStock.SelectedItem;
            if (selectedStock == null)
            {
                return;
            }
            StockApi.SetUrl(selectedStock);

            var plotModel = selectedStock.PlotChart(StockApi);
            StockChart.Model = plotModel;
        }
        /// <summary>
        /// Method to change image of star if stock adds or removes from list of favourite stocks. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMakeOrRemoveFavourite_Click(object sender, MouseButtonEventArgs e)
        {
            var clickedimage = sender as Image;
            if (clickedimage != null)
            {
                var ticker = clickedimage.DataContext as Stock;
                if (ticker.IsFavourite == true)
                {
                    var viewModel = DataContext as ViewModel;
                    viewModel?.RemoveTickerFavourite(ticker);
                }
                else
                {
                    var viewModel = DataContext as ViewModel;
                    viewModel?.MakeTickerFavourite(ticker);
                }
            }
        }
        /// <summary>
        /// Method to remove all not favourite stocks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = DataContext as ViewModel;
            viewModel?.RemoveAllTickersNotFavourite();
        }
    }
}
