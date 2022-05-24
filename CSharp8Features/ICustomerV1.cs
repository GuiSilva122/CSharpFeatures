using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8Features
{
    public interface ICustomerV1
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }

        // Version 1:
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
            if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
                return 0.10m;

            return 0;
        }
    }
}
