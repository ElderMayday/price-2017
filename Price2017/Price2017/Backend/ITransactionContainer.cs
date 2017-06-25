using System;

namespace Price2017.Backend
{
    interface ITransactionContainer
    {
        void AddTransaction(long id, DateTime time, string name, double price, double amount, bool isBuy);

        void Clear();
    }
}