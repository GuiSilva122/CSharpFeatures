using System;
using System.Collections.Generic;

namespace CSharp8Features
{
    public interface ICustomerV0
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }
    }

}
