﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer2._0
{
    class StockDataPoint
    {
        public string Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Adj_close { get; set; }
        public string Volume { get; set; }
        public string Dividend { get; set; }
    }
}