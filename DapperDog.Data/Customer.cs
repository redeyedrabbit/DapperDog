using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    // Make drop down option
    public enum State { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY }
    public enum BillingState { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zipcode { get; set; }

        //Checkout
        public bool BillingAddressSameAsHomeAddress { get; set; }

        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public BillingState BillingState { get; set; }
        public string BillingZipcode { get; set; }
        public int BillingPhoneNumber { get; set; }



    }
}
