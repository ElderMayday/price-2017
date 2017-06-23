using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class Transaction
    {
        public DateTime Time { get; protected set; }
        public int NameId { get; protected set; }
        public double Price { get; protected set; }
        public double Amount { get; protected set; }
        public bool IsBuy { get; protected set; }

        public Transaction(DateTime time, int nameId, double price, double amount, bool isBuy)
        {
            this.Time = time;
            this.NameId = nameId;
            this.Price = price;
            this.Amount = amount;
            this.IsBuy = isBuy;
        }
    }
}
