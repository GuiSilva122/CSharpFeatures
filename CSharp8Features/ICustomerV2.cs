using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8Features
{
    public interface ICustomerV2
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }

        public static void SetLoyaltyThresholds(TimeSpan ago,
                                                int minimumOrders = 10,
                                                decimal percentageDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentageDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0); // two years
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;

        public decimal ComputeLoyaltyDiscount()
        {
            DateTime start = DateTime.Now - length;

            if ((DateJoined < start) && (PreviousOrders.Count() > orderCount))
                return discountPercent;

            return 0;
        }
    }
}
