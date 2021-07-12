using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        //FK
        public virtual Customer Customer { get; set; }
        [Required]
        public int ProductId { get; set; }
        //FK
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset DateOfTransaction { get; set; }

    }
}
