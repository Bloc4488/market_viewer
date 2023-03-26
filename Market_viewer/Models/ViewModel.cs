using System;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            }
        }

        public ObservableCollection<Wallet> AddAmountTicker(Wallet Wallet)
        {
            ObservableCollection<Wallet> wallets;
            using (var context = new StockContext()) 
            {
                context.Entry(Wallet).Entity.amount += 1;
                wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
                context.SaveChanges();
            }
            OnPropertyChanged();
            return wallets;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
