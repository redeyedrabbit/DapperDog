using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Product
{
    public class ProductEdit
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Enter the product name")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Enter the product description")]
        [MinLength(3, ErrorMessage = "The description needs to be longer.")]
        [MaxLength(200, ErrorMessage = "Please enter a more brief description.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Enter the brand ID")]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Enter the category ID")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Enter the size of this product")]
        [Range(0, 5, ErrorMessage = "The size must be 1 = XS, 2 = S, 3 = M, 4 = L, or 5 = XL.")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Enter the price of this product")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Enter the # in stock")]
        [Range(0, 500, ErrorMessage = "The inventory must be between 0 and 500.")]
        public int InventoryCount { get; set; }
    }
}
