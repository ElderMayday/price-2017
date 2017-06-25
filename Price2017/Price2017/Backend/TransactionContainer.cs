using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class TransactionContainer : ITransactionContainer
    {
        public Dictionary<long, Transaction> transactions { get; protected set; }
        public Dictionary<int, string> names { get; protected set; }

        public TransactionContainer()
        {
            transactions = new Dictionary<long, Transaction>();
            names = new Dictionary<int, string>();
        }

        public void AddTransaction(long id, DateTime time, string name, double price, double amount, bool isBuy)
        {
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
}
