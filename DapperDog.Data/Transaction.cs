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
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
