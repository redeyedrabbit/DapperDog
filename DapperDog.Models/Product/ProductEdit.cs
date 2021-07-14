using DapperDog.Data;
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
        [Display(Name = "Name:")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description:")]
        [MinLength(3, ErrorMessage = "The description needs to be longer.")]
        [MaxLength(200, ErrorMessage = "Please enter a more brief description.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Select the Brand:")]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Select the Category:")]
        public int CategoryId { get; set; }

        
        [Display(Name = "Select the Size:")]
        
        public Size Size { get; set; }

        [Required]
        [Display(Name = "Price:")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Number in Stock:")]
        [Range(0, 500, ErrorMessage = "The inventory must be between 0 and 500.")]
        public int InventoryCount { get; set; }
    }
}
