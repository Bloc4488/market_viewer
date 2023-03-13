using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_viewer
{
    internal class Ticker
    {
        public int id { get; set; }

        private string name;

        private int ifFavorite;// 0 - false, 1 - true

        public Ticker() { }

        Ticker(string ticker)
        {
            this.name = ticker;
            this.ifFavorite = 0;
        }

        public string Name   // property
        {
            get { return name; }
            set { name = value; }
        }

        public int IfFavorite
        {
            get { return ifFavorite; }
        }

        public void SetFavorite() { ifFavorite = 1; }

    }
}
