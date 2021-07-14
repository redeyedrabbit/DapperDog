using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public class Checkout
    {
        public bool BillingAddressSameAsHomeAddress { get; set; }

        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public BillingState BillingState { get; set; }
        public string BillingZipcode { get; set; }
        public int BillingPhoneNumber { get; set; }
    }
}
