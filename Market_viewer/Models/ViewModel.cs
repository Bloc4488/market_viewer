using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0.Models
{
    public class ViewModel
    {
        public ObservableCollection<Wallet> Wallets { get; set; }

        public ViewModel() 
        {
            using (var context = new StockContext())
            {
                Wallets = new ObservableCollection<Wallet>(context.Wallets.Include("Ticker").ToList());
            }
        }
    }
}
