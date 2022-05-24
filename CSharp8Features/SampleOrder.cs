using System;

namespace CSharp8Features
{
    public partial class DefaultInterfaceMethods
    {
        public class SampleOrder : IOrder
        {
            public SampleOrder(DateTime purchase, decimal cost) =>
                (Purchased, Cost) = (purchase, cost);

            public DateTime Purchased { get; }

            public decimal Cost { get; }
        }
    }
}
