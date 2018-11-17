using System;
using System.Collections.Generic;

namespace MoravianMountainBikes.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderedProduct = new HashSet<OrderedProduct>();
        }

        public long Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<OrderedProduct> OrderedProduct { get; set; }
    }
}
