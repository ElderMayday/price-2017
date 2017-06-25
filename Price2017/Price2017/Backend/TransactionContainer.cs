using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class TransactionContainer : TransactionContainerAbstract
    {
        public TransactionContainer()
        {
            Clear();
        }

        public override void AddTransaction(long id, DateTime time, string name, double price, double amount, bool isBuy)
        {
            if (!transactions.ContainsKey(id))
            {
                modified = true;

                var pair = names.FirstOrDefault(x => x.Value == name);

                int nameId;

                if (pair.Value == null)
                {
                    nameId = names.Count + 1;
                    names.Add(nameId, name);
                }
                else
                    nameId = pair.Key;

                transactions.Add(id, new Transaction(time, nameId, price, amount, isBuy));
            }
        }

        protected override void recomputePriceAmounts()
        {
            modified = false;

            priceAmounts = new Dictionary<double, PriceAmount>();

            foreach (var transaction in transactions)
            {
                if (!priceAmounts.ContainsKey(transaction.Value.Price))
                    priceAmounts[transaction.Value.Price] = new PriceAmount(0.0, 0.0);

                if (transaction.Value.IsBuy)
                    priceAmounts[transaction.Value.Price].Buy += transaction.Value.Amount;
                else
                    priceAmounts[transaction.Value.Price].Sell += transaction.Value.Amount;
            }
        }
    }
}
