using System;
using System.Collections.Generic;

namespace MoravianMountainBikes.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
