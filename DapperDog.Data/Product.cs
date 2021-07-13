using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public enum Size { XS, S, M, L, XL, OS}
    // XS Toy breed (up to 5lbs)
    // S Small breed (5-10lbs)
    // M Medium breed (10-30lbs)
    // L Large breed (30-50lbs)
    // XL Extra Large Breed (50-80lbs)
    // OS One Size fits all (0-15lbs or 30-50lbs)

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        // Do I need this with new user roles method? **REMOVE BEFORE TURNING IN**
        // [Required]
        //public Guid ManagerId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //[Required]
        public Size Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int InventoryCount { get; set; }

        public virtual string BrandName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
