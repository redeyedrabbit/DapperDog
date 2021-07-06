using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        // Do I need this with new user roles method? **REMOVE BEFORE TURNING IN**
       // [Required]
        //public Guid ManagerId { get; set; }

        [Required]
        //[ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        // 
        //The ForeignKeyAttribute on property 'BrandId' on type 'DapperDog.Data.Product' is not valid.The navigation property 'Brand' was not found on the dependent type 'DapperDog.Data.Product'. The Name value should be a valid navigation property name.

                [Required]
        //[ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int InventoryCount { get; set; }

        public virtual IEnumerable<Brand> Brands { get; set; }
    }
}
