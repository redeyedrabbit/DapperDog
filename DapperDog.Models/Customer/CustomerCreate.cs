using DapperDog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Customer
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "First Name:")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(15, ErrorMessage = "Please enter a more brief name.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name:")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(15, ErrorMessage = "Please enter a more brief name.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address:")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        [MinLength(3, ErrorMessage = "The city name needs to be longer.")]
        [MaxLength(20, ErrorMessage = "Please enter a valid city")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Select your State:")]
        public State State { get; set; }

        [Required]
        [Display(Name = "ZipCode:")]
        [StringLength(5, ErrorMessage = "Please enter a valid zipcode.")]
        public string Zipcode { get; set; }
    }
}
