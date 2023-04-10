using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace Market_viewer2._0.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Stock
    {
        public int id { get; set; }

        private string name { get; set; }

        private bool isFavourite { get; set; }

        private string image;

        public double Price { get; set; }

        public List<StockDataPoint> StockDataList { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stock()
        {
            StockDataList = new List<StockDataPoint>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticker"></param>
        public Stock(string ticker)
        {
            this.name = ticker;
            this.isFavourite = false;
            this.image = ImageUrl();
            StockDataList = new List<StockDataPoint>();
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return isFavourite;
            }
            set
            {
                this.isFavourite = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ImageUrl()
        {
            if (this.IsFavourite == true) return "/Images/StarYellow.png";
            else return "/Images/StarGray.png";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StockApi"></param>
        /// <returns></returns>
        public PlotModel PlotChart(Api StockApi)
        {
            var plotModel = new PlotModel();

            var series = new LineSeries();

            if (this.StockDataList.Count == 0) StockApi.DownloadData(this);

            int i = 0;
            foreach (var item in StockDataList)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), Convert.ToDouble(StockDataList[i].Open)));
                i++;
            }

            plotModel.Series.Add(series);

            plotModel.Title = this.Name;

            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM" });


            return plotModel;
        }
    }
}
