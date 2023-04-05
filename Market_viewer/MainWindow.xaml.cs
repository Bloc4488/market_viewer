﻿using System;
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
using OxyPlot;
using Market_viewer2._0.Models;

namespace Market_viewer
{

    public partial class MainWindow : Window
    {

        private Api StockApi;
        public MainWindow()
        {
            InitializeComponent();
            StockApi = new Api();
            var viewModel = new ViewModel();
            DataContext = viewModel;
        }

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

        private void btnAddTickerToTickers_Click(object sender, RoutedEventArgs e)
        {
            var tickerName = Convert.ToString(AddNewTicker.Text);
            var viewModel = DataContext as ViewModel;
            Stock ticker = new Stock(tickerName);
            viewModel?.AddNewTicker(ticker);
        }

        private void btnMakeFavouriteTicker_Click(object sender, RoutedEventArgs e)
        {
            var ticker = listOfStock.SelectedItem as Stock;
            if (ticker == null)
            {
                MessageBox.Show("Choose ticker");
            }
            else
            {
                var viewModel = DataContext as ViewModel;
                viewModel?.MakeTickerFavourite(ticker);
            }
            listOfStock.SelectedItem = null;
        }

        private void btnRemoveFavouriteTicker_Click(object sender, RoutedEventArgs e)
        {
            var ticker = listOfStock.SelectedItem as Stock;
            if (ticker == null)
            {
                MessageBox.Show("Choose ticker");
            }
            else
            {
                var viewModel = DataContext as ViewModel;
                viewModel?.RemoveTickerFavourite(ticker);
            }
            listOfStock.SelectedItem = null;
        }

        public void ListOfStock_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            Stock selectedStock = (Stock)listOfStock.SelectedItem;
            StockApi.SetUrl(selectedStock);

            var plotModel = selectedStock.PlotChart(StockApi);
            StockChart.Model = plotModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = DataContext as ViewModel;
            viewModel?.RemoveAllTickersNotFavourite();
        }
    }
}
