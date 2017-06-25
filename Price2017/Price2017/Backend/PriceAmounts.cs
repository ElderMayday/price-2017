using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class PriceAmounts
    {
        public PriceAmounts(double buy, double sell)
        {
            this.Buy = buy;
            this.Sell = sell;
            this.Difference = buy - sell;
        }


        public double Buy
        {
            get { return Buy; }

            set
            {
                Buy = value;
                Difference = Buy - Sell;
            }
        }

        public double Sell
        {
            get { return Sell; }

            set
            {
                Sell = value;
                Difference = Buy - Sell;
            }
        }

        public double Difference
        {
            get;
            protected set;
        }
    }
}
