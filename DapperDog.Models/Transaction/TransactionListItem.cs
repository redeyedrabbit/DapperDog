﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Transaction
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset DateOfTransaction { get; set; }
    }
}
