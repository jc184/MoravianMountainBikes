using System;
using System.Collections.Generic;

namespace MoravianMountainBikes.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderedProduct = new HashSet<OrderedProduct>();
        }

        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Orderdate { get; set; }
        public long ConfirmationNumber { get; set; }
        public long CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderedProduct> OrderedProduct { get; set; }
    }
}
