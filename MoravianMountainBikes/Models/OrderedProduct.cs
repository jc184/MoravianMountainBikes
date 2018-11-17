using System;
using System.Collections.Generic;

namespace MoravianMountainBikes.Models
{
    public partial class OrderedProduct
    {
        public long CustomerOrderId { get; set; }
        public long ProductCode { get; set; }
        public int Quantity { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public Product ProductCodeNavigation { get; set; }
    }
}
