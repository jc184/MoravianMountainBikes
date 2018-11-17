using System;
using System.Collections.Generic;

namespace MoravianMountainBikes.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Creditcardexpiry { get; set; }
        public string Creditcardnumber { get; set; }
        public string Creditcardtype { get; set; }
        public string Emailaddress { get; set; }
        public string Loginpassword { get; set; }

        public ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
