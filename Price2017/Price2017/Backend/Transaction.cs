using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2017.Backend
{
    class Transaction
    {
        public DateTime Time { get; set; }
        int NameId { get; set; }
        double Price { get; set; }
        double Amount { get; set; }
        bool IsBut { get; set; }
    }
}
