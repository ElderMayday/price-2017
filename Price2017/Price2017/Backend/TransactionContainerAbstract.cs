using System;
using System.Collections.Generic;

namespace Price2017.Backend
{
    abstract class TransactionContainerAbstract
    {
        protected Dictionary<long, Transaction> transactions { get; set; }

        protected Dictionary<int, string> names { get; set; }

        protected SortedDictionary<double, PriceAmount> priceAmounts;

        public SortedDictionary<double, PriceAmount> PriceAmounts
        {
            get
            {
                if (modified)
                    recomputePriceAmounts();

                return priceAmounts;
            }

            protected set
            {
                modified = true;
                priceAmounts = value;
            }
        }

        protected bool modified;

        public abstract void AddTransaction(long id, DateTime time, string name, double price, double amount, bool isBuy);

        public virtual void Clear()
        {
            transactions = new Dictionary<long, Transaction>();
            names = new Dictionary<int, string>();
        }

        protected abstract void recomputePriceAmounts();
    }
}