using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class TransactionContainer
    {
        SortedDictionary<long, Transaction> transactions;
        Dictionary<int, string> names;
    }
}
