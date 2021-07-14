using DapperDog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Product
{
    public class ProductDetail
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public Size Size { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

        public virtual string BrandName { get; set; }
    }
}
