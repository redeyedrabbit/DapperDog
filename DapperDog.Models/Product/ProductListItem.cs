using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Product
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }        

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

    }
}
