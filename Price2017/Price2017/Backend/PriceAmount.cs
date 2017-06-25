using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class PriceAmount
    {
        public PriceAmount(double buy, double sell)
        {
            this.buy = buy;
            this.sell = sell;
            this.difference = buy - sell;
        }

        protected double buy;
        protected double sell;
        protected double difference;


        public double Buy
        {
            get { return buy; }

            set
            {
                buy = value;
                difference = buy - sell;
            }
        }

        public double Sell
        {
            get { return sell; }

            set
            {
                sell = value;
                difference = buy - sell;
            }
        }

        public double Difference
        {
            get
            {
                return difference;
            }

            protected set
            {
                difference = value;
            }
        }
    }
}
