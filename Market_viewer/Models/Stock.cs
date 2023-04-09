using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Series;
using OxyPlot;
using Newtonsoft.Json.Linq;
using OxyPlot.Axes;

namespace Market_viewer2._0.Models
{
    public class Stock
    {
        public int id { get; set; }

        private string name { get; set; }

        private bool isFavourite { get; set; }

        private string image;

        public List<StockDataPoint> StockDataList { get; set; }

        public ICollection<Wallet> Wallets { get; set; }

        public Stock() 
        {
            StockDataList = new List<StockDataPoint>();
        }

        public Stock(string ticker)
        {
            this.name = ticker;
            this.isFavourite = false;
            this.image = ImageUrl();
            StockDataList = new List<StockDataPoint>();
        }

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

        public string ImageUrl()
        {
            if (this.IsFavourite == true) return "/Images/StarYellow.png";
            else return "/Images/StarGray.png";
        }

        public PlotModel PlotChart(Api StockApi)
        {
            var plotModel = new PlotModel();

            var series = new LineSeries();

            if (this.StockDataList.Count == 0) StockApi.DownloadData(this);
            //for (int i = 0; i < 100; i++)
            //{
            //   series.Points.Add(new DataPoint(i, Convert.ToDouble(StockDataList[i].Open)));
            //}

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
