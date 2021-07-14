using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Brand
{
    public class BrandCreate
    {
        [Required]
        [Display(Name = "Brand Name:")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief name.")]
        public string Name { get; set; }
    }
}
