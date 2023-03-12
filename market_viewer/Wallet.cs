using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Wallet
    {
        private List<Stock> stocksList;
        private float walletValue;

        Wallet()
        {
            stocksList = new List<Stock>();
            walletValue = 0;
        }
    }
}
