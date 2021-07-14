using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public DateTimeOffset DateOfTransaction { get; set; }
    }
}
